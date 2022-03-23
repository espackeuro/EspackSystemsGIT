using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

namespace AutomaticProcesses
{
    class cDBTools
    {
        public cConnDetails ConnDetails;
        public string Server { get { return ConnDetails.Server; } set { ConnDetails.Server = value; } }
        public string User { get { return ConnDetails.User; } set { ConnDetails.User = value; } }
        public string Password { get { return ConnDetails.Password; } set { ConnDetails.Password = value; } }
        public string DB { get { return ConnDetails.DB; } set { ConnDetails.DB = value; } }
        public Nullable<int> TimeOut { get { return ConnDetails.TimeOut; } set { ConnDetails.TimeOut = value; } }
        public enum eRSTypes { Static, Dynamic }
        
        private static string _sql = "";
        private static bool pEOF = false;
           
        public bool EOF { get { return pEOF; } }
        public SqlConnection Conn = null;

        public SqlDataReader RS = null;

        public cDBTools(cConnDetails connDetails)
        {
            ConnDetails = connDetails;
        }

        public cDBTools(string server,string user,string password,string db):this(new cConnDetails(server, user, password, db))
        {
        }

        public bool Connect()
        {
            
            string _stage = "";
            try
            {
                // 
                _stage = "Trying connection";
                if (Conn != null)
                    throw new Exception($"Already connected to {Server}");

                //
                _stage = "Preparing connection details";
                SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder();
                _builder.DataSource = Server;
                _builder.UserID = User;
                _builder.Password = Password;
                _builder.InitialCatalog = DB;
                
                //
                if (TimeOut == null) TimeOut = 60;

                //
                _stage = "Opening connection";
                Conn = new SqlConnection(_builder.ConnectionString);
                
                Conn.Open();
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"[{_stage}] {ex.Message}.");
                //return false;
                throw new Exception($"[cDBTools/Connect#{_stage}] {ex.Message}");
            }

            // OK
            return true;
        }
        public bool Disconnect()
        {

            string _stage = "";
            try
            {
                // 
                _stage = "Trying desconnection";
                if (Conn == null)
                    throw new Exception($"Not connected");

                //
                _stage = "Closing connection";
                if (Conn.State == System.Data.ConnectionState.Open)
                    Conn.Close();

                //
                _stage = "Disposing object";
                Conn = null;

            }
            catch (Exception ex)
            {
                //Console.WriteLine($"[{_stage}] {ex.Message}.");
                //return false;
                throw new Exception($"[cDBTools/Disconnect#{_stage}] {ex.Message}");
            }

            // OK
            return true;
        }

        public bool ChangeDB(string NewDB)
        {
            string _stage = "";
            try
            {
                _stage = "Checking connection";
                if (Conn == null || Conn.State == System.Data.ConnectionState.Closed)
                    throw new Exception("Not connected");

                if (NewDB.ToUpper() == Conn.Database.ToUpper())
                    return true;
                    //throw new Exception($"The current DB is {NewDB} already.");

                //
                _stage = "Closing Data Reader";
                if (RS != null && !RS.IsClosed) RS.Close();
                
                //
                _stage = $"Changing to {NewDB} DB";
                Conn.ChangeDatabase(NewDB);

            }
            catch (Exception ex)
            {
                //Console.WriteLine($"[ChangeDB#{_stage}] {ex.Message}.");
                //return false;
                throw new Exception($"[cDBTools/ChangeDB#{_stage}] {ex.Message}");
            }
            return true;
        }

        public bool Query(string SQL, eRSTypes RSType = eRSTypes.Static)
        {
            string _stage = "";
            _sql = SQL;

            try
            {
                if (RSType != eRSTypes.Static)
                    throw new Exception("Recordset type not supported yet");

                if (RS != null && !RS.IsClosed)
                    RS.Close();

                using (SqlCommand _cmd = new SqlCommand(SQL, Conn))
                {
                    //
                    _stage = "Executing query";
                    _cmd.CommandTimeout = (int)TimeOut;
                    RS = _cmd.ExecuteReader();
                    pEOF = !RS.HasRows;
                    if (!pEOF) RS.Read();
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine($"[Query#{_stage}] {ex.Message}.");
                //return false;
                throw new Exception($"[cDBTools/Query#{_stage}] {ex.Message}");
            }

            // OK
            return true;
        }

        // Return a dictionary 
        public Dictionary<int, Dictionary<string, string>> ToDictionary()
        {
            string _stage = "";
            Dictionary<int, Dictionary<string, string>> _dict = new Dictionary<int, Dictionary<string, string>>();

            try
            {

                //
                _stage = "Checkings";
                if (RS is null)
                    throw new Exception($"Recordset not defined");

                //// Just in case we had used the recordset already (it would not show all the records otherwise)
                //if (!RS.HasRows)
                //{
                //    _stage = "Refreshing query";
                //    RS.Close();
                //    Query(_sql);
                //}
                //if (!RS.HasRows)
                //    throw new Exception($"Recordset is empty.");

                if (!RS.HasRows)
                    return _dict;

                //
                _stage = "Loop through the recordset";
                do
                {
                    _stage = $"Add row {_dict.Count + 1}";
                    _dict.Add(_dict.Count + 1, new Dictionary<string, string>());
                    for (int i = 0; i < RS.FieldCount; i++)
                    {
                        _stage = $"Add row {_dict.Count}/field {RS.GetColumnSchema()[i].ColumnName}";
                        _dict[_dict.Count].Add(RS.GetColumnSchema()[i].ColumnName, RS.GetValue(i).ToString());
                    }
                } while (RS.Read());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[cDBTools/ToDictionary#{_stage}] {ex.Message}.");
                //_dict = null;
            }
            return _dict;
        }

        public Dictionary<string, string> ToDictionaryKeys()
        {
            string _stage = "";
            Dictionary<string, string> _dict = new Dictionary<string, string>();

            try
            {

                //
                _stage = "Checkings";
                if (RS is null)
                    throw new Exception($"Recordset not defined");

                //// Just in case we had used the recordset already (it would not show all the records otherwise)
                //if (!RS.HasRows)
                //{
                //    _stage = "Refreshing query";
                //    RS.Close();
                //    Query(_sql);
                //}
                //if (!RS.HasRows)
                //    throw new Exception($"Recordset is empty.");

                if (!RS.HasRows)
                    return _dict;

                //
                _stage = "Loop through the recordset";
                do
                {
                    _stage = $"Add key {RS.GetValue(0)}";
                    _dict.Add(RS.GetValue(0).ToString(), null);
                } while (RS.Read());
            }
            catch (Exception ex)
            {
                throw new Exception($"[cDBTools/ToDictionaryKeys#{_stage}] {ex.Message}");
                //  _dict = null;
            }
            return _dict;
        }
        public string FieldName(int Index)
        {
            return RS.GetColumnSchema()[Index].ColumnName;
        }
        public string FieldValue(int Index)
        {
            return RS.GetValue(Index).ToString();
        }

        public bool MoveNext()
        {
            pEOF = !RS.Read();
            return true;
        }

    }
}
