using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Common;
using ConsoleTools;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess
{
    public class cDataAccess : ICloneable, IDisposable
    {
        // Connection details
        public cConnDetails ConnDetails;
        public string Server { get { return ConnDetails.Server; } set { ConnDetails.Server = value; } }
        public string User { get { return ConnDetails.User; } set { ConnDetails.User = value; } }
        public string Password { get { return ConnDetails.Password; } set { ConnDetails.Password = value; } }
        public string DB { get { return ConnDetails.DB; } set { ConnDetails.DB = value; } }
        public Nullable<int> TimeOut { get { return ConnDetails.TimeOut; } set { ConnDetails.TimeOut = value; } }
        
        // SQL connection object
        public new SqlConnection Conn { get; set; }

        // For security purpose
        public byte[] ContextInfo { get; set; }

        public cDataAccess(cConnDetails connDetails)
        {
            ConnDetails = connDetails;
        }

        public cDataAccess(string server, string user, string password, string db) : this(new cConnDetails(server, user, password, db))
        {

        }

        private void PrepareConnection()
        {
            string _stage = "Starting";

            try
            {
                //
                _stage = "Checking connection object";
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        //
                        _stage = "Closing existing connection";
                        Close();
                    }
                    Conn = null;
                }

                //
                if (TimeOut == null) TimeOut = 60;

                //
                _stage = "Preparing connection details";
                SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder();
                _builder.DataSource = Server;
                _builder.UserID = User;
                _builder.Password = Password;
                _builder.InitialCatalog = DB;
                _builder.MultipleActiveResultSets = true;
                _builder.LoadBalanceTimeout = 3;
                _builder.MaxPoolSize = 3;
                _builder.ConnectTimeout = (int)TimeOut;

                //
                _stage = "Creating SQL Connection";
                Conn = new SqlConnection(_builder.ConnectionString);
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        public SqlCommand SetContextInfo()
        {
            string _stage = "Starting";
            SqlCommand _cmd = null;

            try
            {
                if (ContextInfo != null)
                {
                    //
                    _stage = "Creating command";
                    _cmd = Conn.CreateCommand();
                    string _sql = "set CONTEXT_INFO @C";
                    _cmd.CommandText = _sql;

                    //
                    _stage = "Creating SQL parameter";
                    SqlParameter _param = new SqlParameter();
                    _param.ParameterName = "@C";
                    _param.DbType = DbType.Binary;
                    _param.Size = 128;
                    _param.Value = ContextInfo;

                    //
                    _stage = "Adding parameter to command";
                    _cmd.Parameters.Add(_param);
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            return _cmd;
        }
            

        public async Task ConnectAsync()
        {
            string _stage = "Starting";

            try
            {
                //
                _stage = "Preparing Async Connection";
                PrepareConnection();

                // 
                _stage = "Opening Async Connection";
                await Conn.OpenAsync();

                //
                _stage = "Async setting context info";
                if (ContextInfo != null) 
                    await SetContextInfo().ExecuteNonQueryAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }

        }
        public void Connect()
        {
            string _stage="Starting";

            try
            {
                //
                _stage = "Preparing Async Connection";
                PrepareConnection();

                // 
                _stage = "Opening Async Connection";
                Conn.Open();

                //
                _stage = "Setting context info";
                if (ContextInfo != null)
                    SetContextInfo().ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }
        public void Close()
        {
            Conn.Close();
        }

        public cDataAccess Clone()
        {
            return (cDataAccess)MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public void Dispose()
        {

        }
    }

    public class Recordset : IDisposable
    {
        // Database
        private cDataAccess DA = null;
        private DataSet DS = null;
        private DbParameterCollection Parameters;

        // Events
        public event EventHandler<EventArgs> AfterExecution; //launched when the query is executed
        public event EventHandler<EventArgs> BeforeExecution;

        // Recordset control
        public string SQL { get; set; }
        public int Index { get; protected set; } = 0;

        public bool EOF { get; protected set; } = false;

        public bool BOF { get; protected set; } = false;
        public int RecordCount { get; }
        public int FieldCount { get; }

        public bool HasRows { get; set; }
        public bool AutoUpdate { get; set; }
        public List<string> Fields { get; private set; }
        public List<DataRow> Rows
        {
            get;
        }

        public List<DataRow> GetList()
        {
            //var _list = new List<DbDataRecord>();
            return DS.Tables["Result"].Rows.OfType<DataRow>().ToList();
        }

        public List<DataRow> ToList()
        {
            return GetList();
        }

        // Navigate through the recordset
        public void MoveNext()
        {
            Move(Index + 1);
        }
        public void MovePrevious()
        {
            Move(Index - 1);
        }
        public void MoveFirst()
        {
            Move(0);
        }
        public void MoveLast()
        {
            Move(RecordCount - 1);
        }
        private void Move(int index)
        {
            if (RecordCount == 0)
            {
                EOF = true;
                BOF = true;
                return;
            }
            if (index < 0)
            {
                Index = 0;
                EOF = false;
                BOF = true;
            }
            if (index > RecordCount - 1)
            {
                Index = RecordCount - 1;
                EOF = true;
                BOF = false;
            }
            if (index < RecordCount)
                EOF = false;
            
            //mState = RSState.Fetching;
            Index = index;
            //mState = RSState.Open;
        }

        public void Dispose()
        {

        }
    }
    public class cDatabase
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

        public cDatabase(cConnDetails connDetails)
        {
            ConnDetails = connDetails;
        }

        public cDatabase(string server, string user, string password, string db) : this(new cConnDetails(server, user, password, db))
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

    public class SP:IDisposable
    {
        public string Name;
        public enum eParamType { OUT, IN };

        public virtual DbParameterCollection Parameters { get; }


        public Dictionary<string,Tuple<dynamic,eParamType>> Params;

        public SP(string name)
        {
            Name = name;
        }

        public void AddParam(string name, dynamic value)
        {
            if (name.Substring(0, 1) != "@")
                name = "@" + name;

            //if (Parameters[name].DbType.IsNumericType())

            Params.Add(name, new Tuple<dynamic, eParamType>(value, eParamType.IN));
        }

        //public void AddParam(string name, ref dynamic value)
        //{
        //    Params.Add(name, new Tuple<dynamic, eParamType>(value, eParamType.OUT));
        //}

        public void Exec()
        {
            string _stage;

            try
            {
              /*  using (SqlCommand _cmd = new SqlCommand(Name, Conn))
                {

                    _cmd.CommandType = CommandType.StoredProcedure;
                    
                    foreach(var _param in Params.Keys)
                    {
                        _cmd.Parameters.AddWithValue
                        _cmd.ExecuteNonQuery();
                    }

                    //
                    _stage = "Executing SP";
                    _cmd.CommandTimeout = (int)TimeOut;
                    RS = _cmd.ExecuteReader();

                }*/
            }
            catch
            {

            }
        }

        public void Dispose()
        {

        }
    }
}