using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTools;

namespace AlarmsProcessing
{

    class cAlarm:IDisposable
    {
        cConnDetails ConnDetailsDB;
        public string DBServer { get { return ConnDetailsDB.Server; } set { ConnDetailsDB.Server = value; } }
        public string DBUser { get { return ConnDetailsDB.User; } set { ConnDetailsDB.User = value; } }
        public string DBPassword { get { return ConnDetailsDB.Password; } set { ConnDetailsDB.Password = value; } }
        public string DB { get { return ConnDetailsDB.DB; } set { ConnDetailsDB.DB = value; } }
        public int? TimeOut { get { return ConnDetailsDB.TimeOut; } set { ConnDetailsDB.TimeOut = value; } }

        public string Code, Table, AlarmField, IdRegName, EmailSubject, EmailList, SelectCondition, SelectFields, Server;
        public int? IdRegValue;
        public bool Flagged, ColumnDate, Error;

        public Dictionary<int, Dictionary<string, string>> Results = null;

        public cAlarm(cConnDetails connDetailsDB, string code, string db, string table, string alarmField, string idRegName, int idRegValue, string emailSubject, string emailList, string selectCondition, string selectFields, bool flagged, string server, bool columnDate)
        {
            ConnDetailsDB = connDetailsDB;
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

        public void Process(cDBTools cDBt)
        {
            string _where, _dateField, _sql;
            string _stage = "";
            List<string> _xmlFields = new List<string>();
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
                cDBt.Query(_sql);

                //
                _stage = "Converting data to dictionary";
                Results = cDBt.ToDictionary();

            }
            catch (Exception ex)
            {
                Error = true;
                Results=($"[cAlarm/Process#{_stage}] {ex.Message}");
            }
            return;
        }

        public void Dispose()
        {

        }

    }
}
