using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmsProcessing
{

    class cAlarm:IDisposable
    {
        public string Code = null;
        public string DB = null;
        public string Table = null;
        public string AlarmField = null;
        public string IdRegName = null;
        public int? IdRegValue= null;
        public string EmailSubject = null;
        public string EmailList = null;
        public string SelectCondition = null;
        public string SelectFields = null;
        public bool Flagged = false;
        public string Server = null;
        public bool ColumnDate = false;

        public cAlarm(string code, string db,string table,string alarmField, string idRegName,int idRegValue,string emailSubject,string emailList,string selectCondition,string selectFields,bool flagged,string server,bool columnDate)
        {
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

        public void Process()
        {
            string _where, _dateField, _sql;
            string _stage = "";
            List<string> _xmlFields = new List<string>();

            _where = string.IsNullOrEmpty(SelectCondition) ? "" : " and (" + SelectCondition + ")";
            _where += string.IsNullOrEmpty(AlarmField) ? "" : $" and {AlarmField} in (select valor_alarma from det_alarmas where codigo='{Code}')";
            _dateField = ColumnDate ? "fecha" : "xfec";

            //
            _stage = "Identify XML fields";
            var _fields = SelectFields.Split(",");
            foreach(string _field in _fields)
            {
                if (_field.Contains("\\\\XML"))
                    _xmlFields.Add(_field.Replace("\\\\XML", ""));
            }
            if (_xmlFields.Count > 0)
                SelectFields = SelectFields.Replace("\\\\XML", "");


            //
            _stage = "Building SQL";
            _sql = $"select {SelectFields},Fecha=convert(varchar(17),{_dateField},113), Registro={IdRegName} from {DB}..{Table} ";

            //
            if (!Flagged)
            {
                _sql += $"where {IdRegName}>{(int)(IdRegValue == null ? 0 : IdRegValue)} {_where}";
            }
            else
            {
                _sql += $"where dbo.checkFlag(flags,'REPORTED')=0 {_where}";
            }
            _sql += $" order by {_dateField}";

            Console.WriteLine($"{_stage}/{_sql}");
        }

        public void Dispose()
        {

        }

    }
}
