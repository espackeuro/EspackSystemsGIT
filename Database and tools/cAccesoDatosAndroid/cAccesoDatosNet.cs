using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Net;
/*
using System.Windows.Forms;
using EspackControls;
*/
using CommonTools;
using System.Data.Common;

namespace AccesoDatosNet
{

    public class ControlParameter
    {
        public Object LinkedControl;
        public SqlParameter Parameter;
    }
    public class ObjectParameter
    {
        public object Container;
        public SqlParameter Parameter;
    }
    public class cAccesoDatosNet : ICloneable
    {
        public SqlConnection AdoCon { get; set; }
        public string Path { get; set; }
        public string AppName { get; set; }
        public string ServerIP
        {
            get
            {
                return oServer.IP.ToString();
            }
            set
            {
                if (oServer != null)
                {
                    IPAddress _serverIP;
                    if (IPAddress.TryParse(value, out _serverIP))
                        oServer.IP = _serverIP;
                }
            }
        }

        public string Server
        {
            get
            {
                if (oServer != null)
                    return oServer.HostName;
                else
                    return null;
            }
            set
            {
                if (oServer != null)
                {
                    IPAddress _serverIP;
                    string _hostName = "";

                    if (!IPAddress.TryParse(value, out _serverIP))
                    {
                        _hostName = value;
                        try
                        {
                            var result = Dns.GetHostEntry(value);
                            _hostName = result.HostName;
                            _serverIP = result.AddressList[0];
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        _hostName = value;
                        //try
                        //{
                        //    var result = Dns.GetHostEntry(_serverIP);
                        //    _hostName = result.HostName;
                        //} catch (Exception ex)
                        //{
                        //    _hostName = value;
                        //}
                    }
                    oServer.HostName = _hostName;
                    oServer.IP = _serverIP;
                }
            }
        }
        public string Printer { get; set; }
        public string DataBase { get; set; }
        public string User
        {
            get
            {
                if (oServer != null)
                    return oServer.User;
                else return null;
            }
            set
            {
                if (oServer != null)
                    oServer.User = value;
            }
        }

        public string Password
        {
            get
            {
                if (oServer != null)
                    return oServer.Password;
                else return null;
            }
            set
            {
                if (oServer != null)
                    oServer.Password = value;
            }
        }
        public bool Silent { get; set; }
        public IPAddress IP { get; set; }
        public DateTime TimeTic { get; set; }
        public long TimeOut { get; set; }
        public string Cod3 { get; set; }
        public byte[] context_info { get; set; }
        public cServer oServer { get; set; }

        public System.Data.ConnectionState State
        {
            get
            {
                return AdoCon.State;
            }
        }

        public string ConnectionString
        {
            get
            {
                return AdoCon.ConnectionString;
            }
            set
            {
                AdoCon.ConnectionString = value;
            }
        }


        //constructores
        public cAccesoDatosNet()
        {
            AdoCon = new SqlConnection();
            //Provider = "SQLOLEDB";
            Silent = false;
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            var lIP = ipHostInfo.AddressList.FirstOrDefault(x => x.GetAddressBytes()[0] == 10);
            if (lIP == null)
                lIP = ipHostInfo.AddressList.First(x => x.GetAddressBytes()[0] == 192);
            //foreach (IPAddress lIP in ipHostInfo.AddressList)
            //{
            //    if (lIP.AddressFamily.ToString() == "InterNetwork" && ((lIP.GetAddressBytes()[0] == 192 && lIP.GetAddressBytes()[1] == 168) || lIP.GetAddressBytes()[0] == 10))
            //    { //IPV4
            //        IP = lIP;
            //        break;
            //    }
            //}
            IP = lIP;
            if (oServer == null)
            {
                oServer = new cServer() { Type = ServerTypes.DATABASE };
            }

        }

        public cAccesoDatosNet(string pServer, string pDataBase, string pUser, string pPassword)
            : this()
        {
            //Server = pServer;
            //User = pUser;
            //Password = pPassword;

            Server = pServer;
            User = pUser;
            Password = pPassword;
            DataBase = pDataBase;

        }

        public cAccesoDatosNet(cServer pServer, string pDataBase)
            : this()
        {
            oServer = pServer;
            DataBase = pDataBase;
        }
        public cAccesoDatosNet(cAccesoDatosNet parent)
        {
            AdoCon = new SqlConnection();
            Server = parent.Server;
            DataBase = parent.DataBase;
            User = parent.User;
            Password = parent.Password;
            //AdoCon.ConnectionString = parent.ConnectionString;
        }
        public cAccesoDatosNet(EspackParamArray pParams)
        {
            AdoCon = new SqlConnection();
            Server = pParams.Server;
            DataBase = pParams.DataBase;
            User = pParams.User;
            Password = pParams.Password;
            Cod3 = pParams.Cod3;
            AppName = pParams.AppName;
        }
        public DateTime ServerDate
        {
            get
            {
                StaticRS lRs = new StaticRS();
                lRs.Open("Select Date=convert(varchar,Getdate(),120)", this);
                if (!lRs.HasRows)
                {
                    throw new Exception("Server not available");
                }
                string[] lDateTot = lRs[0].ToString().Split(' ');
                lRs.Close();
                string[] lDate = lDateTot[0].Split('-');
                string[] lTime = lDateTot[1].Split(':');
                DateTime lRes = new DateTime(Convert.ToInt32(lDate[0]), Convert.ToInt32(lDate[1]), Convert.ToInt32(lDate[2]), Convert.ToInt32(lTime[0]), Convert.ToInt32(lTime[1]), Convert.ToInt32(lTime[2]));
                return lRes;
            }
        }
        public string HostName
        {
            get
            {
                StaticRS lRs = new StaticRS();
                lRs.Open("Select HostName=host_name()", this);
                if (lRs.EOF)
                {
                    throw new Exception("Server not available");
                }
                string lRes = lRs[0].ToString();
                lRs.Close();
                return lRes;
            }
        }

        public void Connect()
        {
            try
            {
                AdoCon.ConnectionString = "Server=" + Server.Replace(".local", "") + ";Initial Catalog=" + DataBase + ";User Id=" + User + ";Password=" + Password + ";MultipleActiveResultSets=True;";
                AdoCon.Open();
                if (context_info != null)
                {
                    SqlCommand cmd = AdoCon.CreateCommand();
                    string lSql = "set CONTEXT_INFO @C";
                    cmd.CommandText = lSql;
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@C";
                    param.DbType = DbType.Binary;
                    param.Size = 127;
                    param.Value = context_info;
                    cmd.Parameters.Add(param);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public void Open()
        {
            Connect();
        }
        public void Close()
        {
            AdoCon.Close();
        }

        public cAccesoDatosNet Clone()
        {
            return (cAccesoDatosNet)this.MemberwiseClone();
        }

        object ICloneable.Clone()
        {
            return Clone();
        }
    }

    public enum RSState
    {
        Closed = 0,
        Open = 1,
        Connecting = 2,
        Executing = 4,
        Fetching = 8
    }

    public abstract class RSFrame : IDisposable
    {
        //private SqlDataReader mDR = null;
        //private SqlCommand mCmd = null;
        protected cAccesoDatosNet mConn = null;
        protected bool mEOF;
        protected bool mBOF;
        protected RSState mState;
        protected int mIndex = 0;
        //events
        //Events
        public event EventHandler<EventArgs> AfterExecution; //launched when the query is executed
        public event EventHandler<EventArgs> BeforeExecution;
        //properties
        public string SQL { get; set; }
        public int Index
        {
            get
            {
                return mIndex;
            }
        }
        public bool EOF
        {
            get
            {
                return mEOF;
            }
        }
        public bool BOF
        {
            get
            {
                return mBOF;
            }
        }
        public RSState State
        {
            get
            {
                return mState;
            }
        }
        public abstract object this[string Idx]
        {
            get;
        }
        public abstract object this[int Idx]
        {
            get;
        }
        public abstract object DataObject
        {
            get;
        }

        public List<object> ToList()
        {
            return getList();
        }

        public bool HasRows { get; set; }
        public bool AutoUpdate { get; set; }
        public abstract SqlCommand Cmd { get; set; }

        public abstract void MoveNext();
        public abstract void MovePrevious();
        public abstract void MoveLast();
        public abstract void MoveFirst();
        public abstract void Move(int Idx);
        public abstract void Execute();
        public void Open()
        {
            AssignParameterValues();
            var e = new EventArgs();
            OnBeforeExecution(e);
            Execute();
            OnAfterExecution(e);
        }
        public void Open(string Sql, cAccesoDatosNet Conn)
        {
            SQL = Sql;
            mConn = Conn;
            Open();
        }

        public abstract void Close();

        public SqlParameterCollection Parameters
        {
            get
            {
                return Cmd.Parameters;
            }
        }
        public List<ControlParameter> ControlParameters { set; get; }



        public RSFrame()
        {
            ControlParameters = new List<ControlParameter>();
            AutoUpdate = false;
        }

        protected virtual void OnAfterExecution(EventArgs e)
        {
            EventHandler<EventArgs> handler = AfterExecution;
            if (handler != null)
            {
                handler(this, e);
            }

        }

        protected virtual void OnBeforeExecution(EventArgs e)
        {
            EventHandler<EventArgs> handler = BeforeExecution;
            if (handler != null)
            {
                handler(this, e);
            }

        }

        public void AddControlParameter(string ParamName, Object ParamControl)
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
                ((IsValuable)ParamControl).TextChanged += RSFrame_TextChanged;
            }
        }
        void RSFrame_TextChanged(object sender, EventArgs e)
        {
            Open();
        }

        public void AssignParameterValues()
        {
            ControlParameters.Where(x => x.LinkedControl is IsValuable).ToList().ForEach(p => p.Parameter.Value = ((IsValuable)p.LinkedControl).Value);
            ControlParameters.Where(x => !(x.LinkedControl is IsValuable)).ToList().ForEach(p => p.Parameter.Value = p.LinkedControl);
        }

        public abstract List<object> getList();

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~RSFrame() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Close();
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }


    public class StaticRS : RSFrame
    {
        protected SqlDataReader mDR = null;
        //private cAccesoDatosNet mConn = null;
        //Events
        public new event EventHandler<EventArgs> AfterExecution; //launched when the query is executed
                                                                 //properties

        public override SqlCommand Cmd { get; set; }

        public override object this[string Idx]
        {
            get
            {
                return mDR[Idx];
            }
        }
        public override object this[int Idx]
        {
            get
            {
                return mDR[Idx];
            }
        }

        public new bool HasRows
        {
            get
            {
                return mDR.HasRows;
            }
        }

        public override object DataObject
        {
            get
            {
                if (mDR == null)
                    Open();
                return mDR;
            }
        }

        public StaticRS()
            : base()
        {
            mDR = null;
            Cmd = new SqlCommand();
            mState = RSState.Closed;

        }

        public StaticRS(string Sql, cAccesoDatosNet Conn)
            : base()
        {
            SQL = Sql;
            mConn = Conn;
            mState = RSState.Closed;
        }
        public override void Execute()
        {
            ConnectionState prevState = mConn.State;
            if (prevState != ConnectionState.Open)
            {
                mConn.Open();
            }
            Cmd = new SqlCommand(SQL, mConn.AdoCon);
            mState = RSState.Executing;
            mDR = Cmd.ExecuteReader();
            mEOF = !mDR.Read();
            mState = RSState.Open;
            if (prevState != ConnectionState.Open)
            {
                mConn.Close();
            }
            mIndex = 1;
        }



        public override void MoveNext()
        {
            mState = RSState.Fetching;
            if (mDR.Read())
            {
                mEOF = false;
            }
            mEOF = true;
            mState = RSState.Open;
        }

        public override void MovePrevious() { }
        public override void MoveLast() { }
        public override void MoveFirst()
        {
            mDR = null;
            Open();
        }
        public override void Move(int Idx) { }

        public override void Close()
        {
            mDR.Close();
            mDR = null;
            Cmd = null;
            mState = RSState.Closed;
        }
        ~StaticRS()
        {
            if (mDR != null)
                mDR.Close();
            mDR = null;
            Cmd = null;
        }


        public override List<object> getList()
        {
            var _list = new List<object>();
            MoveFirst();
            while (!EOF)
            {
                var _array = new Object[mDR.FieldCount];
                mDR.GetValues(_array);
                _list.Add(_array.ToList<object>());
                MoveNext();
            }
            return _list;
        }

    }

    public class DynamicRS : RSFrame
    {
        protected DataSet mDS;
        protected SqlDataAdapter mDA = new SqlDataAdapter();
        //Events
        new public event EventHandler<EventArgs> AfterExecution; //launched when the query is executed     
        new public event EventHandler<EventArgs> BeforeExecution;
        //private cAccesoDatosNet mConn;
        public new int Index
        {
            get
            {
                return mIndex;
            }
            set
            {
                mIndex = value;
            }
        }
        public int RecordCount
        {
            get
            {
                return mDS.Tables["Result"].Rows.Count;
            }
        }

        public override object this[string Idx]
        {
            get
            {
                return mDS.Tables["Result"].Rows[Index][Idx];
            }
        }
        public override object this[int Idx]
        {
            get
            {
                return mDS.Tables["Result"].Rows[Index][Idx];
            }
        }
        public int FieldCount
        {
            get
            {
                return mDS.Tables["Result"].Columns.Count;
            }
        }

        public List<string> Fields
        {
            get
            {
                return mDS.Tables["Result"].Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
            }
        }

        public SqlDataAdapter DA
        {
            get
            {
                return mDA;
            }
            set
            {
                mDA = value;
            }
        }

        public DataSet DS
        {
            get
            {
                return mDS;
            }
        }

        public override SqlCommand Cmd
        {
            get
            {
                return mDA.SelectCommand;
            }
            set
            {
                mDA.SelectCommand = value;
            }
        }

        public new List<DataRow> ToList()
        {
            return mDS.Tables["Result"].Rows.Cast<DataRow>().ToList();
        }
        public override object DataObject
        {
            get
            {
                if (mDS == null)
                    Open();
                return mDS.Tables["Result"];
            }
        }

        public DynamicRS()
            : base()
        {
            //mDS = new DataSet();

        }
        public DynamicRS(string Sql, cAccesoDatosNet Conn)
            : base()
        {
            SQL = Sql;
            mConn = Conn;
            //mDS = new DataSet();
            mDA.SelectCommand = new SqlCommand(SQL, mConn.AdoCon);

        }

        public override void Execute()
        {
            ConnectionState prevState = mConn.State;
            if (prevState != ConnectionState.Open)
            {
                mConn.Open();
            }
            mDS = new DataSet();
            mState = RSState.Executing;
            mDA.Fill(mDS, "Result");
            Index = 0;
            mState = RSState.Open;
            if (prevState != ConnectionState.Open)
            {
                mConn.Close();
            }
        }



        public void Open(int pCurrentIndex, int pPageSize)
        {
            AssignParameterValues();
            var e = new EventArgs();
            OnBeforeExecution(e);

            ConnectionState prevState = mConn.State;
            if (prevState != ConnectionState.Open)
            {
                mConn.Open();
            }
            mDS = new DataSet();
            mState = RSState.Executing;
            mDA.Fill(mDS, pCurrentIndex, pPageSize, "Result");
            Index = 0;
            mState = RSState.Open;
            if (prevState != ConnectionState.Open)
            {
                mConn.Close();
            }
            OnAfterExecution(e);
        }



        public override void MoveNext()
        {
            mState = RSState.Fetching;
            if (mIndex < RecordCount - 1)
            {
                mIndex++;
                mBOF = false;
            }
            else
            {
                mEOF = true;
            }
            mState = RSState.Open;
        }

        public void FillSchema()
        {
            mDS = new DataSet();
            mDA.FillSchema(DS, SchemaType.Mapped);
        }

        public override void MovePrevious()
        {
            mState = RSState.Fetching;
            if (mIndex > 0)
            {
                mIndex--;
                mEOF = false;
            }
            else
            {
                mBOF = true;
            }
            mState = RSState.Open;
        }
        public override void MoveFirst()
        {
            mState = RSState.Fetching;
            mIndex = 0;
            mState = RSState.Open;
        }
        public override void MoveLast()
        {
            mState = RSState.Fetching;
            mIndex = RecordCount - 1;
            mState = RSState.Open;
        }

        public override void Move(int Idx)
        {
            mState = RSState.Fetching;
            Index = Idx;
            mState = RSState.Open;
        }

        public override void Close()
        {
            mDS = null;
            mDA = null;
        }

        ~DynamicRS()
        {
            mDS = null;
            mDA = null;
        }
        public override List<Object> getList()
        {
            //var _list = new List<DbDataRecord>();
            var rows = new string[RecordCount];
            int i = 0;

            foreach (DataRow dataRow in mDS.Tables["Result"].Rows)
            {
                rows[i] = string.Join(";", dataRow.ItemArray.Select(item => item.ToString()));
                i++;
            }
            return rows.ToList<object>();
        }
    }

    public class SP
    {
        private cAccesoDatosNet mConn;

        public List<ControlParameter> ControlParameters { set; get; }
        public List<SqlParameter> OutputParameters { get; set; }
        //public List<ObjectParameter> ObjectParameters { get; set; }
        public SqlCommand Cmd { get; set; }

        public SqlParameterCollection Parameters
        {
            get
            {
                return Cmd.Parameters;
            }
        }
        public SqlConnection Connection
        {
            get
            {
                return Cmd.Connection;
            }
            set
            {
                Cmd.Connection = value;
            }
        }

        public cAccesoDatosNet Conn
        {
            get
            {
                return mConn;
            }
            set
            {
                mConn = value;
                Cmd.Connection = mConn.AdoCon;
            }
        }
        public CommandType CommandType
        {
            get
            {
                return Cmd.CommandType;
            }
            set
            {
                Cmd.CommandType = value;
            }
        }
        public string CommandText
        {
            get
            {
                return Cmd.CommandText;
            }
            set
            {
                Cmd.CommandText = value;
            }
        }
        public bool MsgOut
        {
            get
            {
                try
                {
                    return (Parameters[1].ParameterName == "@msg");
                }
                catch
                {
                    return false;
                }
            }
        }
        public string SPName { get; set; }
        public string LastMsg { get; set; }

        public SP(cAccesoDatosNet pConn, string pSPName = "")
        {
            Cmd = new SqlCommand();
            ControlParameters = new List<ControlParameter>();
            OutputParameters = new List<SqlParameter>();
            //ObjectParameters = new List<ObjectParameter>();
            SPName = pSPName;
            Conn = pConn;
            Connection = Conn.AdoCon;
            CommandType = System.Data.CommandType.StoredProcedure;
            CommandText = pSPName;
            ConnectionState prevState = mConn.State;
            if (prevState != ConnectionState.Open)
            {
                mConn.Open();
            }
            SqlCommandBuilder.DeriveParameters(Cmd);
            if (MsgOut)
            {
                Parameters["@msg"].Value = "";
            }
            Cmd.CommandTimeout = 300;
            if (prevState != ConnectionState.Open)
            {
                mConn.Close();
            }
        }

        public void AddParameterValue(string pParamName, object pValue, string DBFieldName = "")
        {
            try
            {
                if (pParamName.Substring(0, 1) != "@")
                {
                    pParamName = '@' + pParamName;
                }
                DateTime res;
                if (Parameters[pParamName].SqlDbType.IsNumericType())
                {
                    if (pValue != null && pValue.ToString() == "")
                    {
                        pValue = null;
                    }
                }

                if (Parameters[pParamName].SqlDbType == SqlDbType.Timestamp)
                {
                    if (pValue is DateTime)
                    {
                        Parameters[pParamName].Value = (DateTime)pValue;
                        return;
                    }
                    if (!DateTime.TryParse(pValue.ToString(), out res))
                    {
                        throw new Exception("Wrong DateTime parameter " + pParamName);
                    }
                    else
                    {
                        Parameters[pParamName].Value = res;
                    }
                }
                if (pValue != null && pValue is System.String)
                {
                    Parameters[pParamName].Value = pValue.ToString();
                }
                else if (pValue == null)
                {
                    Parameters[pParamName].Value = DBNull.Value;
                }
                else
                {
                    Parameters[pParamName].Value = pValue;
                }
                if (DBFieldName != "")
                {
                    Parameters[pParamName].SourceColumn = DBFieldName;
                }
            }
            catch
            {
                //AdoPar = null;
                throw;
            }

        }

        public void AddControlParameter(string pParamName, object ParamControl)
        {
            if (pParamName.Substring(0, 1) != "@")
            {
                pParamName = '@' + pParamName;
            }
            SqlParameter lParam;
            if (Parameters[pParamName] != null)
            {
                lParam = Parameters[pParamName];
            }
            else
            {
                lParam = new SqlParameter()
                {
                    ParameterName = pParamName
                };
                Parameters.Add(lParam);
            }

            ControlParameters.Add(new ControlParameter()
            {
                Parameter = lParam,
                LinkedControl = ParamControl
            });

        }
        public void AssignOutputParameter(string ParamName, SqlParameter pParam)
        {
            if (Parameters[ParamName] != null)
            {
                pParam = Parameters[ParamName];
            }
            else
            {
                pParam = new SqlParameter()
                {
                    ParameterName = ParamName
                };
                Parameters.Add(pParam);
            }

            OutputParameters.Add(pParam);
        }
        public void AssignParameterValues()
        {
            ControlParameters.Where(x => x.LinkedControl is IsValuable).ToList().ForEach(p => AddParameterValue(p.Parameter.ParameterName, ((IsValuable)p.LinkedControl).Value));
        }
        public void AssignOutputParameterContainer(string ParamName, out SqlParameter ParamOut, object Value = null)
        {
            SqlParameter _param;
            if (ParamName.Substring(0, 1) != "@")
            {
                ParamName = '@' + ParamName;
            }
            if (Parameters[ParamName] != null)
            {
                _param = Parameters[ParamName];
            }
            else
            {
                _param = new SqlParameter()
                {
                    ParameterName = ParamName
                };
                Parameters.Add(_param);
            }
            if (Value != null)
            {
                AddParameterValue(ParamName, Value);
            }
            OutputParameters.Add(_param);
            ParamOut = _param;
            //ObjectParameters.Add(new ObjectParameter() {Container=Container, Parameter=_param });

        }
        public void AssignValuesParameters()
        {
            ControlParameters.Where(x => x.LinkedControl is IsValuable && (x.Parameter.Direction == ParameterDirection.InputOutput || x.Parameter.Direction == ParameterDirection.Output)).ToList().ForEach(p => AddParameterValue(p.Parameter.ParameterName, ((IsValuable)p.LinkedControl).Value));
        }

        public void Execute()
        {
            AssignParameterValues();
            if (Conn.State == ConnectionState.Open)
            {
                Cmd.ExecuteNonQuery();
            }
            else
            {
                Conn.Open();
                Cmd.ExecuteNonQuery();
                Conn.Close();
            }
            AssignValuesParameters();
            try
            {
                LastMsg = Parameters.OfType<SqlParameter>().ToList().First(x => x.ParameterName == "@msg").Value.ToString();
            }
            catch
            {
                LastMsg = "";
            }

        }
        public Dictionary<string, object> ReturnValues()
        {
            return Parameters.OfType<SqlParameter>()
                .Where(p => p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                .ToDictionary(i => i.ParameterName, i => i.Value);

            //Dictionary<string, object> Result = new Dictionary<string, object>();
            //foreach (SqlParameter Param in Parameters)
            //{
            //    if (Param.Direction == ParameterDirection.InputOutput || Param.Direction == ParameterDirection.Output)
            //    {
            //        Result.Add(Param.ParameterName, Param.Value);
            //    }
            //}
            //return Result;
        }
    }

    public class DA
    {
        protected SqlDataAdapter mDA;
        //private DataSet mDS;
        protected string msSPAdd = "";
        protected string msSPUpp = "";
        protected string msSPDel = "";
        protected DynamicRS mSelectRS { get; set; }
        protected SP mInsertCommand;
        protected SP mUpdateCommand;
        protected SP mDeleteCommand;
        public cAccesoDatosNet Conn { get; set; }


        public virtual DynamicRS SelectRS
        {
            get
            {
                return mSelectRS;
            }
            set
            {
                mSelectRS = value;
                mDA.SelectCommand = value.Cmd;
            }
        }

        public DataTable Table
        {
            get
            {
                return SelectRS.DS.Tables["Result"];
            }
        }

        public SP InsertCommand
        {
            get
            {
                return mInsertCommand;
            }
            set
            {
                mInsertCommand = value;
                mDA.InsertCommand = value.Cmd;
            }
        }
        public SP UpdateCommand
        {
            get
            {
                return mUpdateCommand;
            }
            set
            {
                mUpdateCommand = value;
                mDA.UpdateCommand = value.Cmd;
            }
        }
        public SP DeleteCommand
        {
            get
            {
                return mDeleteCommand;
            }
            set
            {
                mDeleteCommand = value;
                mDA.DeleteCommand = value.Cmd;
            }
        }


        //Properties with SPs but in string format, we will use this when assigning a SP by its name
        public string sSPAdd
        {
            set
            {
                if (value != "") InsertCommand = new SP(Conn, value);
                msSPAdd = value;
            }
            get
            {
                return msSPAdd;
            }
        }

        public string sSPUpp
        {
            set
            {
                if (value != "") UpdateCommand = new SP(Conn, value);
                msSPUpp = value;
            }
            get
            {
                return msSPUpp;
            }
        }

        public string sSPDel
        {
            set
            {
                if (value != "") DeleteCommand = new SP(Conn, value);
                msSPDel = value;
            }
            get
            {
                return msSPDel;
            }
        }

        public string SQL
        {
            set
            {
                SelectRS = new DynamicRS(value, Conn);
                ConnectionState prevState = Conn.State;
            }
            get
            {
                return SelectRS.Cmd.CommandText;
            }
        }
        public SqlParameterCollection Parameters
        {
            get
            {
                return SelectRS.Parameters;
            }
        }

        public DataColumnCollection Schema
        {
            get
            {
                if (mSelectRS.DS == null || mSelectRS.DS.Tables["Table"] == null)
                {
                    try
                    {
                        FillSchema();
                    }
                    catch (Exception e)
                    {
                        return null;
                    }

                }
                return mSelectRS.DS.Tables["Table"].Columns;
            }
        }

        public void Update()
        {
            mDA.Update(SelectRS.DS, "Result");
        }

        public void Open()
        {
            SelectRS.Open();
        }

        public void Open(int pCurrentIndex, int pPageSize)
        {
            SelectRS.Open(pCurrentIndex, pPageSize);
        }

        public void FillSchema()
        {
            SelectRS.FillSchema();
        }
        public DA(cAccesoDatosNet pConn)
        {
            Conn = pConn;
            mDA = new SqlDataAdapter();
        }
        public DA(cAccesoDatosNet pConn, string pSql)
        {
            Conn = pConn;
            mDA = new SqlDataAdapter();
            SQL = pSql;
        }
        public DA()
        {
            mDA = new SqlDataAdapter();
        }

        public void AddParameter(string pParameterName, Object LinkedControl = null)
        {
            if (LinkedControl != null)
            {
                mSelectRS.AddControlParameter(pParameterName, LinkedControl);
            }
            else
            {
                SqlParameter lParam = new SqlParameter();
                lParam.ParameterName = pParameterName;
                Parameters.Add(lParam);
            }
        }
    }






}
