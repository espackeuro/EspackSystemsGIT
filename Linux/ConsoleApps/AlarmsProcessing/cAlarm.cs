using System;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using ConsoleTools;
using System.Text.RegularExpressions;
using DataAccess;

namespace AlarmsProcessing
{

    class cAlarm:IDisposable
    {
        private cDataAccess DA;
        public string DBServer { get { return DA.Server; } set { DA.Server = value; } }
        public string DBUser { get { return DA.User; } set { DA.User = value; } }
        public string DBPassword { get { return DA.Password; } set { DA.Password = value; } }
        public string DB { get { return DA.DB; } set { DA.DB = value; } }
        public int? TimeOut { get { return DA.TimeOut; } set { DA.TimeOut = value; } }

        public string Code, Table, AlarmField, IdRegName, EmailSubject, EmailList, SelectCondition, SelectFields, Server, Contents, ErrorMessage;
        public int? IdRegValue;
        public bool Flagged, ColumnDate, Error, Triggered;

        public cAlarm(cDataAccess da, string code, string db, string table, string alarmField, string idRegName, int idRegValue, string emailSubject, string emailList, string selectCondition, string selectFields, bool flagged, string server, bool columnDate)
        {
            string _stage = "Creating object";
            try
            {
                DA = da;
                Code = code;
                DB = db;
                Table = table;
                AlarmField = alarmField;
                IdRegName = idRegName;
                IdRegValue = idRegValue;
                EmailSubject = emailSubject;
                EmailList = emailList;
                SelectCondition = selectCondition;
                SelectFields = selectFields;
                Flagged = flagged;
                Server = server;
                ColumnDate = columnDate;
            }
            catch(Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        public void Process()
        {
            string _where, _dateField, _sql, _str;
            string _stage = "";
            List<string> _xmlFields = new List<string>();
            Dictionary<int, Dictionary<string, string>> _results;

            try
            {
                //
                _stage = "Preparing WHERE clause";
                _where = String.IsNullOrEmpty(SelectCondition) ? "" : " and (" + SelectCondition + ")";
                _where += String.IsNullOrEmpty(AlarmField) ? "" : $" and {AlarmField} in (select valor_alarma from det_alarmas where codigo='{Code}')";

                // Changes the date column name from xfec to fecha when true
                _dateField = ColumnDate ? "fecha" : "xfec";

                //
                _stage = "Identify XML fields";
                var _fields = SelectFields.Split(",");
                foreach (string _field in _fields)
                {
                    if (_field.Contains("\\XML"))
                        _xmlFields.Add(_field.Replace("\\XML", ""));
                }
                if (_xmlFields.Count > 0)
                    SelectFields = SelectFields.Replace("\\XML", "");


                //
                _stage = "Building SQL";
                _sql = $"select {SelectFields},Fecha=convert(varchar(17),{_dateField},113), Registro={IdRegName} from {DB}..{Table} ";

                // If it is a "flagged" alarm, it has to take into consideration the REPORTED flag in the table, not the idreg value.
                if (!Flagged)
                {
                    _sql += $"where {IdRegName}>{(int)(IdRegValue == null ? 0 : IdRegValue)} {_where}";
                }
                else
                {
                    _sql += $"where GENERAL.dbo.checkFlag(flags,'REPORTED')=0 {_where}";
                }
                _sql += $" order by {_dateField}";

                //
                // Server change (for future improvement)
                // if (String.IsNullOrEmpty(Server)) ...

                //
                _stage = "Executing query";
                Recordset _rs = new Recordset(_sql, DA);
                _rs.Open();

                // If no results, the alarm was not triggered
                Triggered = !_rs.EOF;
                if (!Triggered)
                    return;

                //
                _stage = "Converting data to dictionary";
                _results = null;// cDBt.ToDictionary();

                //
                _stage = "Building contents from results";
                Contents = $"<table><tr><th colspan=2>Alarm {Code} triggered by the following values:</th></tr> ";
                while (!_rs.EOF)
                {
                    foreach (var _field in _rs.Fields)
                    {
                        if (_xmlFields.Contains(_field))
                        {
                            XmlDocument _xml = new XmlDocument();
                            _xml.LoadXml(_rs[_field].ToString());
                            _str = XMLToString(_xml, 0, false);
                        }
                        {
                            _str = _rs[_field].ToString();
                        }
                        Contents += $"<tr><td align=\"right\" valign=\"top\">{_field}:  </td><td>{_str}</td></tr>";
                    }
                    Contents += "<tr><td colspan=2 align=\"center\">-------------------------------</td></tr>";
                    _rs.MoveNext();
                }

                using (SP _sp = new SP(DA,"pControl_Alarmas"))
                {
                    string _msg = "", _warningMsg = "";

                    _sp.AddParameterValues("msg", _msg);
                    _sp.AddParameterValues("msg_aviso", _warningMsg);
                    _sp.AddParameterValues("codigo", Code);
                    _sp.AddParameterValues("resultado", Contents);
                    _sp.AddParameterValues("idreg", IdRegValue);
                    _sp.Execute();
                    _msg = _sp.Msg;

                }
            }
            catch (Exception ex)
            {
                Error = true;
                string _errorMessage = $"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}";

                // Match the last occurrence of [xxx#xxx] to ensure it's part of our error message, not part of the system error. This is to show the error message in bold.
                Match _match = Regex.Match(_errorMessage, @"\[([^\[]*)#([^\[]*)\]", RegexOptions.RightToLeft);
                int _i = _match.Index + _match.Length;

                // Set to bold the error message, ignoring all the "call stack" string, and prepare the html code.
                Contents = _errorMessage.Substring(0, _i) + "<ul><strong>" + _errorMessage.Substring(_i + 1);
                Contents = $"<html><body>Alarm: {Code}<br>Error:<br>" + Contents.Replace("] ", "]<ul>") + "</strong></body></html>";
            }
            return;
        }

        // Transforms a XML doc into a formated string
        public string XMLToString(XmlDocument xml, int level, bool showNodes)
        {
            string _stage = $"Converting XML to string (level {level+1})";
            try
            {
                string _str = "", _strPrefix = "";
                XmlDocument _subXml;

                // First level has no >>
                if (level > 0)
                {
                    _strPrefix = new StringBuilder(level * 2).Insert(0, ">>", 2).ToString();
                }
                level++;

                // For each node, we evaluate and call again this function recursively
                foreach (XmlNode _node in xml)
                {
                    _stage = $"Procesing XML node {_node.Name} (level {level})";
                    if (_node.HasChildNodes)
                    {
                        _subXml = new XmlDocument();

                        //
                        _stage = $"Importing XML node {_node.Name} (level {level})";
                        _subXml.ImportNode(_node, true);

                        //
                        _stage = $"Recursively processing node level {_node.Name} childs (level {level})";
                        _str += (!showNodes ? "" : $"{_strPrefix} {_node.Name}<br>") + XMLToString(_subXml, level, showNodes);
                        if (level == 1)
                            _str += "<br>";
                    }
                    else
                    {
                        // This is last node (no children)
                        _str += $"{_strPrefix} {_node.Name}: {_node.Value}<br>";
                    }
                }
                return _str;
            }
            catch(Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        public void MarkAsProcessed()
        {
            /*
            using (SP _sp = new SP("pControl_Alarmas"))
            {
                _sp.AddParam("msg",)
            }
            */
        }
        public void Dispose()
        {

        }

    }
}
