using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Web;

namespace AutomaticProcesses
{
    class cProcess
    {

        public cCredentials Credentials;
        public string Server { get { return Credentials.Server; } set { Credentials.Server = value; } }
        public string User { get { return Credentials.User; } set { Credentials.User = value; } }
        public string Password { get { return Credentials.Password; } set { Credentials.Password = value; } }
        public string DB { get { return Credentials.DB; } set { Credentials.DB = value; } }

        public cMiscFunctions.eFileType FileType;
        public cMiscFunctions.eOrientation Orientation;
        public string ArgsString, FileName, Title, Contents = "";
        public int QueryNumber, PDFFontSize = 25;
        public bool NoBand, Error;

        public cProcess(cCredentials credentials, int queryNumber, string args, string title, bool noBand = false, string fileName = null, cMiscFunctions.eFileType fileType = cMiscFunctions.eFileType.HTML, cMiscFunctions.eOrientation orientation = cMiscFunctions.eOrientation.PORTRAIT)
        {
            Credentials = credentials;
            QueryNumber = queryNumber;
            ArgsString = args;
            Title = title;
            NoBand = noBand;
            FileType = fileType;
            Orientation = orientation;
            FileName = fileName;
        }
        public cProcess(string server, string user, string password, string db, int queryNumber, string args, string title, bool noBand = false, string fileName = null, cMiscFunctions.eFileType fileType = cMiscFunctions.eFileType.HTML, cMiscFunctions.eOrientation orientation = cMiscFunctions.eOrientation.PORTRAIT) : this(new cCredentials(server, user, password, db), queryNumber, args, title, noBand, fileName, fileType, orientation)
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
                    throw new Exception($"Number of args ({args.Count}) differ the number of parameters ({queryParams.Count}).");

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
                throw new Exception($"[cProcess/ParseSQL#{_stage}] {ex.Message}.");
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
                    throw new Exception("Query not found.");
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
                throw new Exception($"[cProcess/GetQueryDetails#{_stage}] {ex.Message}.");
            }
            return true;
        }
        public string Process()
        {
            string _stage = "";
            Dictionary<string, string> _params = null;
            Dictionary<int, Dictionary<string, string>> _result = null;
            Dictionary<int, string> _args;
            string _sql = "", _queryDB = "", _fullFilePath, _filePath;

            try
            {
                //
                _stage = $"Check process args";


                //
                _stage = $"Connecting to {Credentials.Server}";
                cDBTools _dbt = new cDBTools(Credentials);
                _dbt.Connect();

                //
                _stage = "Getting query details";
                if (!GetQueryDetails(_dbt, ref _sql, ref _queryDB, ref _params))
                    throw new Exception("Unknown error!");

                //
                _stage = "Processing args string";
                _args = cMiscFunctions.CheckArgs(ArgsString);

                //
                _stage = "Parsing SQL";
                if (!ParseSQL(ref _sql, _args, _params))
                    throw new Exception("Unknown error!");

                //
                _stage = $"Changing to {_queryDB} DB";
                _dbt.ChangeDB(_queryDB);

                //
                _stage = "Executing query";
                if (!_dbt.Query(_sql))
                    throw new Exception("Unknown error!");

                //
                _stage = "Converting data to dictionary";
                if (_dbt.RS.HasRows) _result = _dbt.ToDictionary();
                _dbt.Disconnect();

                if (_result == null)
                {
                    FileName = null;
                    return null;
                }
            
                //
                switch (FileType)
                {
                    case cMiscFunctions.eFileType.TXT:
                        _stage = "Converting data to TXT";
                        ProcessTXT(_result);
                        FileName = ToFile();
                        break;
                    case cMiscFunctions.eFileType.HTML:
                    case cMiscFunctions.eFileType.XLS:
                        
                        //
                        _stage = "Converting data to HTML";
                        ProcessHTML(_result, Title, "", NoBand);
                        
                        //
                        if (FileType == cMiscFunctions.eFileType.XLS)
                        {
                            _stage = "Converting data to XLS";
                            FileName = ToFile();
                        }

                        break;
                    case cMiscFunctions.eFileType.PDF:
                        throw new Exception("Not implemented!");
                }

            }
            catch (Exception ex)
            {
                Error = true;
                throw new Exception($"[cProcess/Process#{_stage}] {ex.Message}");
                
                //Contents = $"[cProcess/Process#{_stage}] {ex.Message}";
                //Console.WriteLine(Contents);
                
            }


            //function recorset_proceso($args= Array())
            return Contents;
        }

        private string ToFile()
        {
            string _stage = "";
            string _filePath, _fullFilePath;

            // Check file name null


            _stage = "Preparing temp path";
            _filePath = Path.GetTempPath();

            if (!FileName.ToUpper().EndsWith($".{FileType}")) FileName += $".{FileType.ToString().ToLower()}";
            _fullFilePath = $"{_filePath}{Path.DirectorySeparatorChar}{FileName}";
            if (File.Exists(_fullFilePath))
            {
                //
                _stage = $"Deleting {_fullFilePath}";
                File.Delete(_fullFilePath);
            }

            //
            _stage = $"Saving to {FileType} file";
            using (FileStream _fs = File.Create(_fullFilePath))
            {
                byte[] _info = new UTF8Encoding(true).GetBytes(Contents);
                // Add some information to the file.
                _fs.Write(_info, 0, _info.Length);
            }

            return _fullFilePath;
        }

        private void ProcessTXT(Dictionary<int, Dictionary<string, string>> data)
        {
            string _stage = "";
            string _rowContents = "";

            try
            {
                //
                _stage = "";
                foreach (var _currentRow in data)
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

        public void ProcessHTML(Dictionary<int, Dictionary<string, string>> data, string title, string orientation, bool noBand = false, bool excel = false)
        {
            string _stage = "";
            string _html = "";
            string _extra = (noBand ? "border-bottom-style: solid;" : "");
            int fontSize = 11;

            _html = "<html><head>";
            if (!excel)
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
            _html += $"font-size: {fontSize};";
            _html += "font-weight: bold;";
            _html += $"{_extra}}}";
            _html += ".titulo_tabla {";
            _html += "font-family: Courier;";
            _html += $"font-size: {fontSize + 3};";
            _html += "font-weight: bold;";
            _html += $"{_extra}}}";
            _html += ".detalle {";
            _html += "font-family: Courier;";
            _html += "font-size: {fontSize};";
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
            string[] _titles = null;
            string _value;

            Dictionary<string, string> _currentRow;

            for (int _i = 0; _i < data.Count; _i++)
            {
                _currentRow = data.Values.ElementAt(_i);
                if (_firstLine)
                {
                    _html += HTMLHeader(_firstPage, _currentRow, title, ref _cols, _titles);
                    _firstLine = false;
                    _firstPage = false;
                }

                // For banded results
                if (!noBand)
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
                        // If the field value contains the string [Titulo], it is a title and it has to be shown as it
                        if (_value.IndexOf("[Titulo]") != -1)
                        {
                            _value = _value.Replace("[Titulo]", "");
                            _html += $"<td colspan={_cols}>--------</td></tr><tr><td {_extra} class='titulo_tabla' colspan={_cols}>{_value}</td></tr>"; //insertamos el t�tulo sin [Titulo]
                            _i++;
                            _currentRow = data.Values.ElementAt(_i);

                            _titles = _currentRow.Keys.ToList().Where(x => !x.StartsWith("&")).Select(x => HTMLCheckCode(_currentRow[x])).ToArray();
                            _html += "<tr>";
                            foreach (var _item in _titles)
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
    }



}
