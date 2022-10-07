using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using PdfSharpCore;

namespace AutomaticProcesses
{
    class cProcess
    {
        public cConnDetails ConnDetailsDB;
        public cConnDetails ConnDetailsMail;
        public string DBServer { get { return ConnDetailsDB.Server; } set { ConnDetailsDB.Server = value; } }
        public string DBUser { get { return ConnDetailsDB.User; } set { ConnDetailsDB.User = value; } }
        public string DBPassword { get { return ConnDetailsDB.Password; } set { ConnDetailsDB.Password = value; } }
        public string DB { get { return ConnDetailsDB.DB; } set { ConnDetailsDB.DB = value; } }
        public int? TimeOut { get { return ConnDetailsDB.TimeOut; } set { ConnDetailsDB.TimeOut = value; } }
        public string MailServer { get { return ConnDetailsMail.Server; } set { ConnDetailsMail.Server = value; } }
        public string MailUser { get { return ConnDetailsMail.User; } set { ConnDetailsMail.User = value; } }
        public string MailPassword { get { return ConnDetailsMail.Password; } set { ConnDetailsMail.Password = value; } }
        public bool NoSend { get { return (!Error && String.IsNullOrEmpty(Contents) && NoEmpty); } }

        public int? QueryNumber, SubQueryNumber;
        public cMiscFunctions.eFileType FileType;
        public cMiscFunctions.eOrientation Orientation;
        public string ArgsString, FileName, Title, MailTo, MailErrorTo, ErrorMessage, EmptyMessage, Contents = "", CopyTo;
        public int? FontSize;
        public bool NoBand, Error, NoEmpty, MailSkipped, NoExecutionDate;
        public Dictionary<int, Dictionary<string, string>> Results = null;
        
        private Dictionary<int, string> Args;

        public cProcess(cConnDetails connDetailsDB, cConnDetails connDetailsMail, int? queryNumber, string args, string title, string mailTo, string mailErrorTo, int? subQueryNumber = null, string emptyMessage = null, bool noBand = false, bool noExecutionDate = false, bool noEmpty = false, string fileName = null, cMiscFunctions.eFileType fileType = cMiscFunctions.eFileType.HTML, cMiscFunctions.eOrientation orientation = cMiscFunctions.eOrientation.PORTRAIT, int? fontSize = 11, string copyTo=null)
        {
            ConnDetailsDB = connDetailsDB;
            ConnDetailsMail = connDetailsMail;
            QueryNumber = queryNumber;
            ArgsString = args;
            Title = title;
            NoBand = noBand;
            NoExecutionDate = noExecutionDate;
            FileType = fileType;
            Orientation = orientation;
            FileName = fileName;
            SubQueryNumber = subQueryNumber;
            MailTo = mailTo;
            MailErrorTo = mailErrorTo;
            NoEmpty = noEmpty;
            EmptyMessage = emptyMessage;
            FontSize = fontSize;
            if (!String.IsNullOrEmpty(copyTo)) CopyTo = copyTo + (copyTo.Substring(copyTo.Length - cMiscFunctions.PathSeparator().Length) != cMiscFunctions.PathSeparator() ? cMiscFunctions.PathSeparator() : "");
        }
        public cProcess(string serverDB, string userDB, string passwordDB, string db, cConnDetails connDetailsMail, int? queryNumber, string args, string title, string mailTo, string mailErrorTo, int? subQueryNumber = null, string emptyMessage = null, bool noBand = false, bool noExecutionDate = false, bool noEmpty = false, string fileName = null, cMiscFunctions.eFileType fileType = cMiscFunctions.eFileType.HTML, cMiscFunctions.eOrientation orientation = cMiscFunctions.eOrientation.PORTRAIT, int? fontSize = null, string copyTo = null) : this(new cConnDetails(serverDB, userDB, passwordDB, db), connDetailsMail, queryNumber, args, title, mailTo, mailErrorTo, subQueryNumber, emptyMessage, noBand, noEmpty, noExecutionDate, fileName, fileType, orientation, fontSize, copyTo)
        {

        }
        public cProcess(cConnDetails connDetailsDB, string serverMail, string userMail, string passwordMail, int? queryNumber, string args, string title, string mailTo, string mailErrorTo, int? subQueryNumber = null, string emptyMessage = null, bool noBand = false, bool noExecutionDate = false, bool noEmpty = false, string fileName = null, cMiscFunctions.eFileType fileType = cMiscFunctions.eFileType.HTML, cMiscFunctions.eOrientation orientation = cMiscFunctions.eOrientation.PORTRAIT, int? fontSize = null, string copyTo = null) : this(connDetailsDB, new cConnDetails(serverMail, userMail, passwordMail), queryNumber, args, title, mailTo, mailErrorTo, subQueryNumber, emptyMessage, noBand, noEmpty, noExecutionDate, fileName, fileType, orientation, fontSize, copyTo)
        {

        }
        private bool ParseSQL(ref string sql, Dictionary<int, string> args, Dictionary<string, string> queryParams)
        {
            string _stage = "";
            int _count;

            try
            {
                //
                _stage = "Checkings";
                if (args.Count != queryParams.Count)
                    throw new Exception($"Number of args ({args.Count}) differ the number of parameters ({queryParams.Count})");

                //
                _stage = "Matching parameters with arguments";
                _count = 1;
                foreach (var _a in queryParams)
                {
                    sql = sql.Replace($"?{_count}", args[_count]);
                    _count++;
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine($"[cProcess/ParseSQL#{_stage}] {ex.Message}.");
                //return false;
                throw new Exception($"[cProcess/ParseSQL#{_stage}] {ex.Message}");
            }
            return true;
        }
        private bool GetQueryDetails(cDBTools dbt, ref string sql, ref string queryDB, ref Dictionary<string, string> queryParams)
        {
            string _stage = "";

            try
            {
                //
                _stage = $"Getting SQL for query {QueryNumber}";
                dbt.Query($"select SQL,Base_Datos from cabecera_consultas where idreg={QueryNumber}");
                if (dbt.EOF)
                    throw new Exception("Query not found");
                sql = "set dateformat dmy " + dbt.FieldValue(0).ToString();
                queryDB = dbt.FieldValue(1);

                //
                _stage = $"Getting parameters for query {QueryNumber}";
                dbt.Query($"select Param=Nombre_Parametro from detalle_consultas where consulta={QueryNumber} order by linea");
                queryParams = dbt.ToDictionaryKeys();
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"[cProcess/GetQueryDetails#{_stage}] {ex.Message}.");
                //return false;
                throw new Exception($"[cProcess/GetQueryDetails#{_stage}] {ex.Message}");
            }
            return true;
        }
        public async Task Process()
        {
            string _stage = "";
            Dictionary<string, string> _params = null;
            string _sql = "", _queryDB = "", _skipField = null;

            try
            {

                //
                _stage = $"Connecting to {ConnDetailsDB.Server}";
                cDBTools _dbt = new cDBTools(ConnDetailsDB);
                _dbt.Connect();

                //
                _stage = "Getting query details";
                if (!GetQueryDetails(_dbt, ref _sql, ref _queryDB, ref _params))
                    throw new Exception("Unknown error!");

                //
                _stage = "Processing args string";
                Args = cMiscFunctions.CheckArgs(ArgsString);

                //
                _stage = "Parsing SQL";
                if (!ParseSQL(ref _sql, Args, _params))
                    throw new Exception("Unknown error!");

                //
                _stage = $"Changing to {_queryDB} DB";
                _dbt.ChangeDB(_queryDB);

                //
                _stage = "Executing query";
                if (!_dbt.Query(_sql))
                    throw new Exception("Unknown error!");

                //
                if ((FileName ?? "").ToUpper().Contains("{FIELD:"))
                {
                    int _pos = FileName.IndexOf("{FIELD:");
                    _skipField = FileName.Substring(_pos + 7, FileName.IndexOf("}", _pos + 7) - _pos - 7);
                }

                //
                _stage = "Converting data to dictionary";
                if (_dbt.RS.HasRows)
                {
                    Results = _dbt.ToDictionary(_skipField);
                    if (!String.IsNullOrEmpty(_skipField))
                        FileName = FileName.Replace("{FIELD:" + _skipField + "}", _dbt.SkippedValue);
                }

                // Disconnect from DB
                _dbt.Disconnect();

                // If no results, exit with empty content. This also works for queries with SubQuery, which have to be treated in a different way
                if (Results == null || SubQueryNumber != null)
                {
                    Contents = null;
                    FileName = null;
                    Console.WriteLine($">> {QueryNumber}/{ArgsString} completed!");
                    return;
                }

                //
                switch (FileType)
                {
                    case cMiscFunctions.eFileType.TXT:

                        // For TXT queries
                        _stage = "Converting data to TXT";
                        ProcessTXT();
                        break;
                    case cMiscFunctions.eFileType.HTML:
                    case cMiscFunctions.eFileType.XLS:
                    case cMiscFunctions.eFileType.PDF:

                        // Create HTML contents
                        _stage = "Converting data to HTML";
                        ProcessHTML();
                        break;
                }

                // For XLS and PDF
                if (FileType == cMiscFunctions.eFileType.XLS || FileType == cMiscFunctions.eFileType.PDF || FileType == cMiscFunctions.eFileType.TXT)
                {
                    _stage = $"Converting data to {FileType} file";
                    FileName = ToFile();
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine($"[cProcess#Process] {QueryNumber}/{ArgsString}: {ex.Message}");
                ErrorMessage = $"[cProcess#Process] {ex.Message}";
                Console.WriteLine(ErrorMessage);

                // Prepare the _result message for the email.
                string _processQueryParams = String.IsNullOrEmpty(ArgsString) ? "NONE" : ArgsString;
                string _processQuery = (QueryNumber == null) ? "NONE" : QueryNumber.ToString();

                // Match the last occurrence of [xxx#xxx] to ensure it's part of our error message, not part of the system error. This is to show the error message in bold.
                Match _match = Regex.Match(ErrorMessage, @"\[([^\[]*)#([^\[]*)\]", RegexOptions.RightToLeft);
                int _i = _match.Index + _match.Length;

                // Set to bold the error message, ignoring all the "call stack" string, and prepare the html code.
                Contents = ErrorMessage.Substring(0, _i) + "<ul><strong>" + ErrorMessage.Substring(_i + 1);
                Contents = $"<html><body>Query: {_processQuery}<br>Params: {_processQueryParams}<br>Error:<br>" + Contents.Replace("] ", "]<ul>") + "</strong></body></html>";

                //
                Error = true;
            }
            return;
        }

        private string ToFile()
        {
            string _stage = "";
            string _filePath, _fullFilePath="";
            string _format = "";
            int _pos=0;
            

            // Check file name null
            try
            {
                _stage = "Preparing temp path";
                _filePath = Path.GetTempPath();

                _stage = "Obtaining DATE format";
                if (FileName.ToUpper().Contains("{DATE:"))
                {
                    _pos = FileName.IndexOf("{DATE:");
                    _format = FileName.Substring(_pos+6, FileName.IndexOf("}",_pos+6)-_pos-6);
                    FileName = FileName.Replace("{DATE:"+_format+"}", DateTime.Now.ToString(_format));
                }

                // For TXT type, let us to choose the extension if we want
                if (FileType == cMiscFunctions.eFileType.TXT && FileName.ToUpper().EndsWith($".CSV"))
                {
                    // do nothing
                }
                else
                {
                    if (!FileName.ToUpper().EndsWith($".{FileType}"))
                        FileName += $".{FileType.ToString().ToLower()}";
                }
                _fullFilePath = $"{_filePath}{FileName}";
                if (File.Exists(_fullFilePath))
                {
                    //
                    _stage = $"Deleting {_fullFilePath}";
                    File.Delete(_fullFilePath);
                }
                //
                _stage = $"Saving to {FileType} file";
                switch (FileType)
                {
                    case cMiscFunctions.eFileType.XLS:
                    case cMiscFunctions.eFileType.TXT:
                        using (FileStream _fs = File.Create(_fullFilePath))
                        {
                            byte[] _info = new UTF8Encoding(true).GetBytes(Contents);
                            // Add some information to the file.
                            _fs.Write(_info, 0, _info.Length);
                        }
                        break;
                    case cMiscFunctions.eFileType.PDF:
                        var config = new PdfGenerateConfig();
                        if (Orientation.ToString().ToUpper() == "LANDSCAPE")
                        {
                            config.PageOrientation = PdfSharpCore.PageOrientation.Landscape;
                        }
                        else
                        {
                            config.PageOrientation = PdfSharpCore.PageOrientation.Portrait;
                        }
                        config.PageSize = PdfSharpCore.PageSize.A4;
                        PdfDocument pdfDocument = PdfGenerator.GeneratePdf(Contents, config);
                        pdfDocument.Save(_fullFilePath);
                        break;
                    default:
                        throw new Exception("Non supported format");
                }
                return _fullFilePath;
            }
            catch (Exception ex)
            {
                throw new Exception($"[cProcess/ToFile#{_stage}] {ex.Message}.");
            }
        }

        private void ProcessTXT()
        {
            string _stage = "";
            string _rowContents = "";

            try
            {
                //
                _stage = "Building the txt file";
                foreach (var _currentRow in Results)
                {
                    _rowContents += String.Join(";",_currentRow.Value.Values.ToList())+ "\r\n";
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"[cProcess/ProcessTXT#{_stage}] {ex.Message}");
            }
            Contents = _rowContents;
            return;
        }

        private void ProcessHTML()
        {
            //string _stage = "";
            string _html = "";
            string _extra = (NoBand ? "border-bottom-style: solid;" : "");
            int? fontSize = FontSize;

            _html = "<html><head>";
            if (FileType != cMiscFunctions.eFileType.XLS)
            {
                _html += "<meta http-equiv=\"content-type\" content=\"text/html; charset=utf-8\">";
            }
            else
            {
                _html += "<html xmlns:o=\"urn:schemas-microsoft-com:office:office\"";
                _html += "xmlns:x=\"urn:schemas-microsoft-com:office:excel\"";
                _html += "xmlns=\"http://www.w3.org/TR/REC-html40\">";
                _html += "<head><meta http-equiv=Content-Type content=\"text/html; charset=windows-1252\">";
                _html += "<meta name = ProgId content=Excel.Sheet>";
                _html += "<meta name=Generator content=\"Microsoft Excel 11\"";
            }

            _html += "<style type='text/css'>";
            _html += ".titulo {";
            _html += "font-family: Helvetica;";
            _html += "font-size: 20pt;";
            _html += "font-weight: bold;";
            _html += "text-align: left;";
            _html += "}";
            _html += ".tabla {";
            _html += "page-break-after: always;";
            _html += "}";
            _html += ".timestamp {";
            _html += "font-family: Helvetica;";
            _html += "font-size: 12pt;";
            _html += "font-weight: bold;";
            _html += "text-align: right;";
            _html += "}";
            _html += ".subtitulo {";
            _html += "font-family: Helvetica;";
            _html += "font-size: 14pt;";
            _html += "font-weight: bold;";
            _html += "text-align: left;";
            _html += "}";
            _html += ".cabecera {";
            _html += "font-family: Courier;";
            _html += $"font-size: {fontSize}pt;";
            _html += "font-weight: bold;";
            _html += $"{_extra}}}";
            _html += ".titulo_tabla {";
            _html += "font-family: Courier;";
            _html += $"font-size: {fontSize + 3}pt;";
            _html += "font-weight: bold;";
            _html += $"{_extra}}}";
            _html += ".detalle {";
            _html += "font-family: Courier;";
            _html += $"font-size: {fontSize}pt;";
            _html += $"{_extra}}}";
            _html += ".fondogris {";
            _html += "background-color: #CCCCCC;";
            _html += "}";
            _html += "</style></head><body>";

            bool _firstLine = true;
            bool _firstPage = true;
            string _bgColor = "FFFFFF";
            string _styleIni, _style;
            int _cols = 0;
            string[] _Titles = null;
            string _value;

            Dictionary<string, string> _currentRow;

            for (int _i = 0; _i < Results.Count; _i++)
            {
                _currentRow = Results.Values.ElementAt(_i);
                if (_firstLine)
                {
                    _html += HTMLHeader(_firstPage, _currentRow, Title, ref _cols, _Titles);
                    _firstLine = false;
                    _firstPage = false;
                }

                // For banded results
                if (!NoBand)
                    _bgColor = _bgColor == "DDDDDD" ? "FFFFFF" : "DDDDDD";

                _styleIni = $"color:#000000; background-color:#{_bgColor};";

                if (_currentRow.ElementAt(0).Key == "&COLOR")
                {
                    if (_currentRow.ElementAt(0).Value.Length == 12)
                        _styleIni = " color:#" + _currentRow.ElementAt(0).Value.Substring(0, 6) + "; background-color:#" + _currentRow.ElementAt(0).Value.Substring(6, 6) + ";";
                }

                _html += $"<tr class='detalle' style='{_styleIni}'>";

                // Go for each field
                foreach (var _field in _currentRow)
                {
                    // Prepare the field value for HTML code
                    _value = HTMLCheckCode(_field.Value);

                    // When the field name starts with &, it requires a special treatment
                    if (!_field.Key.StartsWith("&"))
                    {
                        // If the field value contains the string [Titulo], it is a Title and it has to be shown as it
                        if (_value.IndexOf("[Titulo]") != -1)
                        {
                            _value = _value.Replace("[Titulo]", "");
                            _html += $"<td colspan={_cols}>--------</td></tr><tr><td {_extra} class='titulo_tabla' colspan={_cols}>{_value}</td></tr>"; //insertamos el t�tulo sin [Titulo]
                            _i++;
                            _currentRow = Results.Values.ElementAt(_i);

                            _Titles = _currentRow.Keys.ToList().Where(x => !x.StartsWith("&")).Select(x => HTMLCheckCode(_currentRow[x])).ToArray();
                            _html += "<tr>";
                            foreach (var _item in _Titles)
                            {
                                _value = _item;
                                _style = _styleIni;
                                HTMLGetStyle(ref _style, ref _value);
                                _html += ((_value == "") ? "<td>&nbsp</td>" : $"<td {_extra} class='cabecera'><div style='{_style}'>" + HttpUtility.HtmlEncode(_value)) + "</div></td>";
                            }
                            break;
                        }
                        _style = _styleIni;

                        // Process the style prefixes: [D], [I], etc...
                        HTMLGetStyle(ref _style, ref _value);

                        _html += (_value == "" ? "<td><div>" : $"<td {_extra} class='detalle'><div style='{_style}'>") + $"{_value}</div></td>";

                    }

                }
                _html += "</tr>";
            }
            _html += "</table></body></html>"; //insertamos el pie de p�gina con los n�meros de p�gina

            Contents = _html;
            return;
        }

        // translated from origina PHP code: define the HTML code for the header
        //private static void Header(ref int row, ref int page, ref string html, ref Dictionary<string, string> rowData, string title, ref int cols, string[] titles)
        private string HTMLHeader(bool firstPage, Dictionary<string, string> rowData, string title, ref int cols, string[] titles)
        {
            int _hidden;
            string _field, _style, _value;
            string _html = "";

            cols = rowData.Count;
            if (!firstPage)
                _html += "</table></div>";

            _html += "<div id='Cabecera' style='position:absolute; top:0; left:0;'>";
            _html += "<table width='100%'><tr><td class='titulo'>" + HttpUtility.HtmlEncode("ESPACK EUROLOGÍSTICA") + "</td><td class='timestamp'>" + DateTime.Now.ToString("r") + "</td></tr>";

            if (firstPage)
                _html += $"<tr><td class='subtitulo' colspan=2>{title}</td></tr>";

            _html += "</table></div><div id = 'Cuerpo'style='position:absolute; top:150; left:0;'>";
            _html += "<table class='tabla' align='center'>"; // End of header
            _html += "<tr class='cabecera'>";

            //row = 1;
            _hidden = 0;

            for (int _i = 0; _i < cols; _i++)
            {
                _field = rowData.ElementAt(_i).Key;
                if (!_field.StartsWith("&"))
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(_field, "[c][0-9]"))
                    {
                        _field = " ";
                    }
                    else
                    {
                        _field = HTMLCheckCode(_field);
                    }
                    _html += $"<td class='cabecera'>{_field}</td>";
                }
                else
                {
                    _hidden++;
                }
            }
            if (titles != null)
            {
                _html += "</tr><tr class='detalle'>";
                foreach (var _item in titles)
                {
                    _style = "";
                    _value = _item;
                    HTMLGetStyle(ref _style, ref _value);
                    _html += $"<td class='cabecera'><div style='{_style}'>{_value}</div></td>";
                }
                //row = 2;
            }
            //page++;
            cols -= _hidden;
            _html += "</tr>";

            return _html;

        }

        // translated from origina PHP code: define the style string for html
        private void HTMLGetStyle(ref string style, ref string value)
        {
            string _styleStr = "";

            // Compatibility with old queries for portalnet (<strong></strong> -> [N])
            if (value.StartsWith("&lt;strong&gt;"))
                value = value.Replace("&lt;strong&gt;", "[N]").Replace("&lt;/strong&gt;", "");

            //gestion de estilos, si el campo empieza con [ busca [IDCNSK]
            if (value.StartsWith("["))
            {
                _styleStr = value.Substring(1, value.IndexOf("]") - 1);
                value = value.Substring(value.IndexOf("]") + 1);

                for (int _i = 0; _i < _styleStr.Length; _i++)
                {
                    switch (_styleStr.Substring(_i, 1))
                    {
                        case "I":
                            style += " text-align:left;";
                            break;
                        case "D":
                            style += " text-align:right;";
                            break;
                        case "C":
                            style += " text-align:center;";
                            break;
                        case "N":
                            style += " font-weight:bold;";
                            break;
                        case "S":
                            style += " text-decoration: underline;";
                            break;
                        case "K":
                            style += " font-style: italic;";
                            break;
                    }
                }
            }
            else
            {
                int _dummy;
                if (Int32.TryParse(value, out _dummy)) style += " text-align:right;";
            }
        }

        private string HTMLCheckCode(string html)
        {
            System.Text.RegularExpressions.Regex _regHtml = new System.Text.RegularExpressions.Regex("<[^>]*>");
            string _result = _regHtml.Replace(HttpUtility.HtmlEncode(html), "");
            return _result;
        }
        public void SendEmail()
        {
            string _stage = "", _subject = "";
            try
            {
                // We send the email if email settings are defined:
                //  - And there was an error
                //  - Or the process worked properly and there are data to show
                //  - Or there are no results, but _noEmpty is false
                if (ConnDetailsMail != null && !String.IsNullOrEmpty(ConnDetailsMail.Server) && !String.IsNullOrEmpty(ConnDetailsMail.User) && !String.IsNullOrEmpty(ConnDetailsMail.Password))
                {
                    if (!NoSend)
                    {

                        // Send errors to informatica
                        if (Error)
                        {
                            Title = "ERROR on " + (!String.IsNullOrEmpty(Title) ? Title : $" process QUERY {QueryNumber}");
                            FileName = null;
                        }

                        //
                        Console.Write($"> Sending {(Error ? "error " : "")}email ({QueryNumber}/{ArgsString})... ");

                        //
                        _stage = "Connecting to email server";
                        ExchangeAttachments _email = new ExchangeAttachments();
                        _email.Connect(ConnDetailsMail);

                        //
                        Contents = !String.IsNullOrEmpty(Contents) ? (String.IsNullOrEmpty(FileName)?Contents: "<html><body><b>Message sent automatically.</b><br><i>Mensaje enviado automáticamente.</i></body></html>") : $"<html><body>{(!String.IsNullOrEmpty(EmptyMessage) ? EmptyMessage : "<b>No results found.</b><br><i>No se encontraron resultados.</i>")}</body></html>";

                        // This is to implement a feature to add the values from parameters in the subject at runtime
                        _subject = (!String.IsNullOrEmpty(Title) ? Title : $"Process QUERY {QueryNumber}"); ;
                        if (_subject.Contains("?"))
                        {
                            _stage = "Replacing arguments in subject";
                            foreach (var _arg in Args)
                            {
                                _subject = _subject.Replace($"?{_arg.Key}", _arg.Value);
                            }
                        }
                        if (!NoExecutionDate)
                            _subject += $" - Executed on {DateTime.Now.ToString("dd/MM/yyyy")}";

                        //
                        if (!String.IsNullOrEmpty(MailTo) || Error)
                        {
                            _stage = "Sending email";
                            if (!_email.SendEmail(Error ? MailErrorTo : MailTo, _subject, Contents, FileName))
                                throw new Exception("Could not send the email");
                        }

                        // 
                        Console.WriteLine("OK!");

                        //
                        _stage = "Disconnecting";
                        _email.Dispose();
                    }
                    else
                    {
                        //
                        MailSkipped = true;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[cProcess/SendEmail#{_stage}] {ex.Message}.");
            }

        }

        public void DoCopy()
        {
            string _stage = "", _destination = CopyTo + Path.GetFileName(FileName);

            try
            {
                _stage = "Copying file ";
                Console.Write($"> Copying {FileName} to {_destination}... ");
                File.Copy(FileName, _destination, true);
                Console.WriteLine("OK!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[cProcess/DoCopy#{_stage}] {ex.Message}.");
            }
        }
    }
}
