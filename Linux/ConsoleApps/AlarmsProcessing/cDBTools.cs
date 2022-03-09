using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace AlarmsProcessing
{
    class cDBTools
    {
        private static string _sql = "";
        private static bool pEOF = false;
        
        public static string Server = null;
        public static string User = null;
        public static string Password = null;
        public static string DB = null;
        
        public SqlConnection Conn = null;

        public SqlDataReader RS = null;


        public cDBTools(string server,string user,string password,string db)
        {
            Server = server;
            User = user;
            Password = password;
            DB = db;
        }

        public bool Connect()
        {
            
            string _stage = "";
            try
            {
                // 
                _stage = "Trying connection";
                if (Conn != null)
                    throw new Exception($"Already connected to {Server}.");

                //
                _stage = "Preparing connection details";
                SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder();
                _builder.DataSource = Server;
                _builder.UserID = User;
                _builder.Password = Password;
                _builder.InitialCatalog = DB;

                //
                _stage = "Opening connection";
                Console.WriteLine($"Connecting to DB server {Server}...");
                Conn = new SqlConnection(_builder.ConnectionString);
                Conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{_stage}] {ex.Message}.");
                return false;
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
                    throw new Exception($"Not connected.");

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
                Console.WriteLine($"[{_stage}] {ex.Message}.");
                return false;
            }

            // OK
            return true;
        }

        public bool Query(string SQL)
        {
            string _stage = "";
            _sql = SQL;

            try
            {
                using (SqlCommand _cmd = new SqlCommand(SQL, Conn))
                {
                    //
                    _stage = "Executing query";
                    RS = _cmd.ExecuteReader();
                    pEOF = !RS.HasRows;
                    if (!pEOF) RS.Read();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Query#{_stage}] {ex.Message}.");
                return false;
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
                    throw new Exception($"Recordset not defined.");

                // Just in case we had used the recordset already (it would not show all the records otherwise)
                if (!RS.HasRows)
                {
                    _stage = "Refreshing query";
                    RS.Close();
                    Query(_sql);
                }
                if (!RS.HasRows)
                    throw new Exception($"Recordset is empty.");

                //
                _stage = "Loop through the recordset";
                while (RS.Read())
                {
                    _stage = $"Add row {_dict.Count}";
                    _dict.Add(_dict.Count + 1, new Dictionary<string, string>());
                    for (int i = 0; i < RS.FieldCount; i++)
                    {
                        _stage = $"Add row {_dict.Count}/field {RS.GetColumnSchema()[i].ColumnName}";
                        _dict[_dict.Count].Add(RS.GetColumnSchema()[i].ColumnName, RS.GetValue(i).ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ToDictionary#{_stage}] {ex.Message}.");
                _dict = null;
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
        public bool EOF()
        {
            return pEOF;
        }

    }
}
