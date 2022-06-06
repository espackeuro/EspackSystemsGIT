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
    public interface IsValuable
    {
        event EventHandler TextChanged;
        string Text { get; set; }
        object Value { get; set; }
    }

    /*
    public static class CObjectFactory
    {
        public static object CreateObject(string objectClass, string objectType, object param1 = null, object param2 = null, string serial = null)
        {

            switch (objectClass)
            {

                case "Conn":
                    object _conn;
                    if (objectType == "Socks") _conn = new cAccesoDatosXML(); else _conn = new cAccesoDatosNet();
                    EspackCommServer.Server.Serial = serial;
                    return _conn;
                case "SP": if (objectType == "Socks") return new SPXML((cAccesoDatosXML)param1, (string)param2); else return new SP((cAccesoDatosNet)param1, (string)param2);
                case "RS": if (objectType == "Socks") return new XMLRS((string)param1, (cAccesoDatosXML)param2); else return new DynamicRS((string)param1, (cAccesoDatosNet)param2);
                default:
                    return null;
            }
        }
    }
    */
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
            string _stage = "Creating object";
            try
            {
                ConnDetails = connDetails;
            }
            catch(Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
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
            string _stage = "Closing connection";
            try
            {
                Conn.Close();
            }
            catch(Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        public cDataAccess Clone()
        {
            string _stage = "Cloning object";
            try
            {
                return (cDataAccess)MemberwiseClone();
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        object ICloneable.Clone()
        {
            return Clone();
        }

        public void Dispose()
        {

        }
    }

    public class ControlParameter
    {
        public Object LinkedControl;
        public DbParameter Parameter;
    }

    public class Recordset : IDisposable
    {
        public enum RSState
        {
            Closed = 0,
            Open = 1,
            Connecting = 2,
            Executing = 4,
            Fetching = 8
        }

        // Database
        private cDataAccess DA = null;
        private SqlDataReader DR = null;
        private DataSet DS = null;
        private DataTable DT;
        private DbParameterCollection Parameters;
        private List<DataRow> Result = null;
        private RSState State;
        public SqlCommand Command { get; set; }
        public List<ControlParameter> ControlParameters { set; get; }


        // Events
        public event EventHandler<EventArgs> AfterExecution; //launched when the query is executed
        public event EventHandler<EventArgs> BeforeExecution;

        // Recordset control
        public string SQL { get; set; }
        public int Index { get; protected set; } = 0;

        public bool EOF { get; protected set; } = false;

        public bool BOF { get; protected set; } = false;
        public bool AutoUpdate { get; set; }
        public List<string> Fields { get; private set; }
        public List<DataRow> Rows
        {
            get;
        }
        public object this[string index] => RecordCount != 0 ? Result[Index][index] : null; //Field<string>(Idx):null;

        public object this[int index] => Result[index];

        public int RecordCount
        {
            get
            {
                string _stage = "Getting data";
                try
                {
                    return Result.Count;
                }
                catch (Exception ex)
                {
                    throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
                }
            }
        }

        public int FieldCount
        {
            get
            {
                string _stage = "Getting data";
                try
                {
                    //return Fields?.Count ?? 0;
                    return Fields.Count;
                }
                catch (Exception ex)
                {
                    throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
                }
            }
        }

        public bool HasRows 
        {
            get
            {
                string _stage = "Getting data";
                try
                {
                    return (Result.Count > 0);
                } 
                catch (Exception ex)
                {
                    throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
                }
            }
        }

        public object DataObject
        {
            get
            {
                string _stage = "Getting data";
                try
                {
                    return DT;
                }
                catch (Exception ex)
                {
                    throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
                }
            }
        }

        public List<DataRow> GetList()
        {
            string _stage = "Getting list from rows";
            try
            {
                return DS.Tables["Result"].Rows.OfType<DataRow>().ToList();
            }
            catch(Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        public List<DataRow> ToList()
        {
            return GetList();
        }

        // Navigate through the recordset
        public async Task MoveNext(bool async = false)
        {
            if (!async)
                Move(Index + 1);
            else
                await Task.Run(() => Move(Index + 1));
        }
        public async Task MovePrevious(bool async = false)
        {
            if (!async)
                Move(Index - 1);
            else
                await Task.Run(() => Move(Index - 1));
        }
        public async Task MoveFirst(bool async = false)
        {
            if (!async)
                Move(0);
            else
                await Task.Run(() => Move(0));
        }
        public async Task MoveLast(bool async = false)
        {
            if (!async)
                Move(RecordCount - 1);
            else
                await Task.Run(() => Move(RecordCount - 1));
        }

        private void Move(int index)
        {
            string _stage = "Moving record pointer";
            try
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
                else if (index > RecordCount - 1)
                {
                    Index = RecordCount - 1;
                    EOF = true;
                    BOF = false;
                }
                else
                {
                    Index = index;
                    BOF = false;
                    EOF = false;
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        // Constructor
        public Recordset() : base()
        {
            string _stage = "Creating object";
            try
            {
                DR = null;
                Command = new SqlCommand();
                State = RSState.Closed;
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }
        public Recordset(string Sql, cDataAccess da) : base()
        {
            string _stage = "Creating object";
            try
            {
                SQL = Sql;
                DA = da;
                State = RSState.Closed;
            }
            catch(Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

         private async Task Execute(bool async = false)
        {
            string _stage = "Checking connection";
            try
            {
                //
                ConnectionState prevState = DA.Conn.State;
                if (prevState != ConnectionState.Open)
                {
                    if (!async)
                        DA.Conn.Open();
                    else
                        await DA.Conn.OpenAsync();
                }

                //
                _stage = "Creating command object";
                Command = new SqlCommand(SQL, DA.Conn);
                State = RSState.Executing;

                //
                _stage = "Executing reader";
                if (!async)
                    DR = Command.ExecuteReader();
                else
                    DR = await Command.ExecuteReaderAsync();

                // 
                _stage = "Getting fields list";
                Fields = DR.GetSchemaTable().Rows.OfType<DataRow>().Select(r => r["ColumnName"].ToString()).ToList();

                //
                _stage = "Loading data table";
                DT = new DataTable();
                if (!async)
                    DT.Load(DR);
                else
                    await Task.Run(() => DT.Load(DR));
                
                //
                _stage = "Creating list of results";
                Result = DT.Rows.OfType<DataRow>().ToList();
                EOF = Result.Count() == 0;
                Index = 0;
                State = RSState.Open;

                // Close the connection in case it was closed before this execution (leave things as they were)
                if (prevState != ConnectionState.Open)
                {
                    _stage = "Closing connection";
                    DA.Conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        public async Task Open(bool async = false)
        {
            AssignParameterValues();
            var e = new EventArgs();
            OnBeforeExecution(e);
            if (!async)
                Execute();
            else
                await Execute(true);
            OnAfterExecution(e);
        }

        public async Task Open(string sql, cDataAccess da, bool async = false)
        {
            SQL = sql;
            DA = da;
            if (!async)
                Open();
            else
                await Open(true);
        }

        private void OnAfterExecution(EventArgs e)
        {
            EventHandler<EventArgs> handler = AfterExecution;
            if (handler != null)
            {
                handler(this, e);
            }

        }

        private void OnBeforeExecution(EventArgs e)
        {
            EventHandler<EventArgs> handler = BeforeExecution;
            if (handler != null)
            {
                handler(this, e);
            }

        }
        private void RSFrame_TextChanged(object sender, EventArgs e)
        {
            Open();
        }
        public void AssignParameterValues()
        {
            if (ControlParameters != null)
                ControlParameters.Where(x => x.LinkedControl is IsValuable && (x.Parameter.Direction == ParameterDirection.InputOutput || x.Parameter.Direction == ParameterDirection.Output)).ToList().ForEach(p => ((IsValuable)p.LinkedControl).Value = p.Parameter.Value);
        }

        public void AddControlParameter(string ParamName, object ParamControl)
        {
            {
                SqlParameter lParam = new SqlParameter()
                {
                    ParameterName = ParamName
                };
                ControlParameters.Add(new ControlParameter()
                {
                    Parameter = lParam,
                    LinkedControl = ParamControl
                });
                Parameters.Add(lParam);
                if (AutoUpdate && ParamControl is IsValuable)
                {
                    ((IsValuable)ParamControl).TextChanged += Recordset_TextChanged;
                }
            }
        }

        private void Recordset_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            string _stage = "Closing recordset";
            try
            {
                DR.Close();
                DR = null;
                Command = null;
                Result = null;
                State = RSState.Closed;
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        public Dictionary<int, Dictionary<string, string>> ToDictionary()
        {
            string _stage = "";
            Dictionary<int, Dictionary<string, string>> _dict = new Dictionary<int, Dictionary<string, string>>();

            try
            {

                //
                _stage = "Checkings";
                if (DR is null)
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

                if (!HasRows)
                    return _dict;

                //
                _stage = "Loop through the recordset";
                do
                {
                    //_dict=Result.ToDictionary(x => x.Field, y=>y);
                    _stage = $"Add row {_dict.Count + 1}";
                    _dict.Add(_dict.Count + 1, new Dictionary<string, string>());
                    for (int i = 0; i < Fields.Count; i++)
                    {
                        _stage = $"Add row {_dict.Count}/field {DR.GetColumnSchema()[i].ColumnName}";
                        _dict[_dict.Count].Add(DR.GetColumnSchema()[i].ColumnName, DR.GetValue(i).ToString());
                    }
                } while (DR.Read());
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            return _dict;
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
            string _stage = "Creating object";
            try
            {
                ConnDetails = connDetails;
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        public cDatabase(string server, string user, string password, string db) : this(new cConnDetails(server, user, password, db))
        {
        }

        public bool Connect()
        {

            string _stage = "Trying connection";
            try
            {
                // 
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
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }

            // OK
            return true;
        }
        public bool Disconnect()
        {

            string _stage = "Trying disconnection";
            try
            {
                // 
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
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }

            // OK
            return true;
        }

        public bool ChangeDB(string NewDB)
        {
            string _stage = "Checking connection";
            try
            {
                //
                if (Conn == null || Conn.State == System.Data.ConnectionState.Closed)
                    throw new Exception("Not connected");

                if (NewDB.ToUpper() == Conn.Database.ToUpper())
                    return true;

                //
                _stage = "Closing Data Reader";
                if (RS != null && !RS.IsClosed) RS.Close();

                //
                _stage = $"Changing to {NewDB} DB";
                Conn.ChangeDatabase(NewDB);

            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            return true;
        }

        public bool Query(string SQL, eRSTypes RSType = eRSTypes.Static)
        {
            string _stage = "Checking query";
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
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
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