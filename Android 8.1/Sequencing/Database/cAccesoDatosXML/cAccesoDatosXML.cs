﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using CommonTools;
using System.Net;
using System.Collections;
using System.Threading.Tasks;
using Messages;
using System.ComponentModel;
using SocketsClient;
using System.Threading;
using AccesoDatos;


namespace AccesoDatosXML
{
    public class XMLParameter : DbParameter
    {

        public XElement XParameter
        {
            get
            {
                XElement _root = new XElement("parameter");
                _root.Add(new XElement("parameterName", ParameterName));
                _root.Add(new XElement("parameterValue", this.Value));
                return _root;
            }


        }

        public string XMLParameterText
        {
            get
            {
                return XParameter.ToString();
            }
        }

        public override DbType DbType { get; set; }

        public override ParameterDirection Direction { get; set; }


        public override bool IsNullable { get; set; }

        public override string ParameterName { get; set; }


        public override int Size { get; set; }


        public override string SourceColumn { get; set; }


        public override bool SourceColumnNullMapping { get; set; }


        public override DataRowVersion SourceVersion { get; set; }

        public override object Value { get; set; }


        public override void ResetDbType()
        {
            throw new NotImplementedException();
        }

        public XMLParameter()
        {

        }


    }

    public class XMLParameterCollection : DbParameterCollection
    {
        private List<XMLParameter> _paramList = new List<XMLParameter>();

        public XElement XParameterCollection
        {
            get
            {
                XElement _root = new XElement("parameterCollection");
                _paramList.ForEach(o => { _root.Add((XElement)o.XParameter); });
                return _root;
            }
        }

        public string XMLParameterCollectionText
        {
            get
            {
                return XParameterCollection.ToString();
            }
        }

        public new XMLParameter this[string paramName]
        {
            get
            {
                return _paramList.FirstOrDefault(o => o.ParameterName == paramName);
            }
            set
            {
                _paramList[this.IndexOf(paramName)] = value;
            }
        }

        public new XMLParameter this[int index]
        {
            get
            {
                return _paramList[index];
            }
            set
            {
                _paramList[index] = value;
            }
        }

        public override int Count
        {
            get
            {
                return _paramList.Count();
            }
        }

        public override bool IsFixedSize
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override bool IsSynchronized
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override object SyncRoot
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override int Add(object value)
        {
            _paramList.Add((XMLParameter)value);
            return Count;
        }

        public override void AddRange(Array values)
        {
            _paramList.AddRange((IEnumerable<XMLParameter>)values);
        }

        public override void Clear()
        {
            _paramList.Clear();
        }

        public override bool Contains(string value)
        {
            try
            {
                var p = _paramList.First(o => o.ParameterName == value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override bool Contains(object value)
        {
            return _paramList.Contains((XMLParameter)value);
        }

        public override void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public override IEnumerator GetEnumerator()
        {
            return _paramList.GetEnumerator();
            //throw new NotImplementedException();
        }

        public override int IndexOf(string parameterName)
        {
            try
            {
                return _paramList.IndexOf(this[parameterName]);
            }
            catch
            {
                return -1;
            }
        }

        public override int IndexOf(object value)
        {
            try
            {
                return _paramList.IndexOf((XMLParameter)value);
            }
            catch
            {
                return -1;
            }
        }

        public override void Insert(int index, object value)
        {
            _paramList.Insert(index, (XMLParameter)value);
        }

        public override void Remove(object value)
        {
            _paramList.Remove((XMLParameter)value);
        }

        public override void RemoveAt(string parameterName)
        {
            _paramList.Remove(this[parameterName]);
        }

        public override void RemoveAt(int index)
        {
            Remove(_paramList[index]);
        }

        protected override DbParameter GetParameter(string parameterName)
        {
            return this[parameterName];
        }

        protected override DbParameter GetParameter(int index)
        {
            return this[index];
        }

        protected override void SetParameter(string parameterName, DbParameter value)
        {
            this[parameterName] = (XMLParameter)value;
        }

        protected override void SetParameter(int index, DbParameter value)
        {
            this[index] = (XMLParameter)value;
        }
    }

    public interface XMLEspackDataThing
    {
        XElement XThingElement { get; }
        XDataMessageRequest XMessage { get; }
    }

    public class cAccesoDatosXML : cAccesoDatos, IDisposable, XMLEspackDataThing
    {
        public bool Compression { get; set; } = true;
        String Origin { get; set; } = "LOGON";
        //string SessionNumber { get; set; }
        public override string HostName()
        {
            var lRs = new XMLRS();
            lRs.Open("Select HostName=host_name()", this);
            if (lRs.EOF)
            {
                throw new Exception("Server not available");
            }
            string lRes = lRs[0].ToString();
            lRs.Close();
            return lRes;
        }
        public override async Task<string> HostNameAsync()
        {
            var lRs = new XMLRS();
            await lRs.OpenAsync("Select HostName=host_name()", this);
            if (lRs.EOF)
            {
                throw new Exception("Server not available");
            }
            string lRes = lRs[0].ToString();
            lRs.Close();
            return lRes;
        }
        public override DateTime ServerDate()
        {
            var lRs = new XMLRS();
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
        public override async Task<DateTime> ServerDateAsync()
        {
            var lRs = new XMLRS();
            await lRs.OpenAsync("Select Date=convert(varchar,Getdate(),120)", this);
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
        public override ConnectionState State
        {
            get
            {
                return ConnectionState.Closed;
            }
        }


        public override string Server
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
                if (oServer == null)
                    oServer = new cServer(value) { Resolve = false };
                else
                    oServer.Server = value;
            }
        }

        public XElement XThingElement
        {
            get
            {
                XElement _root = new XElement("connection");
                _root.Add(oServer.xServer);
                _root.Add(new XElement("DataBase", DataBase));
                return _root;
            }
        }

        public XDataMessageRequest XMessage
        {
            get
            {
                var _x = new XDataMessageRequest();
                _x.SetActionDefinition("Database Connection");
                var _d = new XElement(XThingElement);
                _d.Name = "data";
                _x.SetActionData(_d);
                _x.SetSession(EspackCommServer.Server.SessionNumber);
                return _x;
            }
        }

        public override void Close()
        {
            // do nothing
        }

        public override void Connect()
        {
            try
            {
                //EspackCommServer.Serial = DeviceSerial;
                XDocument _msgOut = Task.Run(() => EspackCommServer.Server.Transmit(XMessage)).Result;
                if (_msgOut.Element("result").Value != "OK")
                    throw new Exception(_msgOut.Element("result").Value);
            }
            catch //(Exception ex)
            {
                //second try
                try
                {
                    //EspackCommServer.Serial = DeviceSerial;
                    XDocument _msgOut = Task.Run(() => EspackCommServer.Server.Transmit(XMessage)).Result;
                    if (_msgOut.Element("result").Value != "OK")
                        throw new Exception(_msgOut.Element("result").Value);
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }
        }

        public async override Task ConnectAsync()
        {
            try
            {
                //EspackCommServer.Serial = DeviceSerial;
                XDocument _msgOut = await EspackCommServer.Server.Transmit(XMessage);
                if (_msgOut.Element("result").Value != "OK")
                    throw new Exception(_msgOut.Element("result").Value);
            }
            catch //(Exception ex)
            {
                //second try
                try
                {
                    //EspackCommServer.Serial = DeviceSerial;
                    XDocument _msgOut = await EspackCommServer.Server.Transmit(XMessage);
                    if (_msgOut.Element("result").Value != "OK")
                        throw new Exception(_msgOut.Element("result").Value);
                }
                catch (Exception exc)
                {
                    throw new Exception(exc.Message);
                }
            }
        }
        public cAccesoDatosXML() : base()
        {
            oServer.Resolve = false;
        }

        public cAccesoDatosXML(cAccesoDatosXML parent)
        {
            oServer.Resolve = false;
            Server = parent.Server;
            DataBase = parent.DataBase;
            User = parent.User;
            Password = parent.Password;
        }
        public new cAccesoDatosXML Clone()
        {
            return (cAccesoDatosXML)this.MemberwiseClone();
        }
    }



    public class SPXML : SPFrame, XMLEspackDataThing
    {
        public bool Compression { get; set; } = false;
        protected new cAccesoDatosXML mConn;
        //private string SPName {get;set;}
        private XMLParameterCollection _parameters = new XMLParameterCollection();

        //public new XMLParameterCollection Parameters
        //{
        //    get
        //    {
        //        return _parameters;
        //    }
        //}

        public override DbParameterCollection Parameters
        {
            get
            {
                return _parameters;
            }
        }

        public new cAccesoDatosXML Conn
        {
            get
            {
                return mConn;
            }
            set
            {
                mConn = (cAccesoDatosXML)value;
            }
        }

        public XElement XThingElement
        {
            get
            {
                var _x = new XElement("procedure");
                _x.Add(Conn.XThingElement);
                _x.Add(_parameters.XParameterCollection);
                _x.Add(new XElement("procedureName", SPName));
                return _x;
            }
        }
        public XDataMessageRequest XMessage
        {
            get
            {
                var _x = new XDataMessageRequest();
                _x.SetActionDefinition("Stored Procedure");
                var _d = new XElement(XThingElement);
                _d.Name = "data";
                _x.SetActionData(_d);
                _x.SetSession(EspackCommServer.Server.SessionNumber);
                return _x;
            }
        }
        public override CommandType CommandType
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool MsgOut
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

        public SPXML(cAccesoDatosXML pConn, string pSPNAme = "")
        {
            SPName = pSPNAme;
            Conn = pConn;
        }
        public SPXML(cAccesoDatos pConn, string pSPNAme = "") : this((cAccesoDatosXML)pConn, pSPNAme) { }

        public override void AddParameterValue(string pParamName, object pValue, string DBFieldName = "")
        {
            try
            {
                if (pParamName.Substring(0, 1) != "@")
                {
                    pParamName = '@' + pParamName;
                }
                DateTime res;
                if (Parameters[pParamName] == null)
                    Parameters.Add(new XMLParameter() { ParameterName = pParamName, DbType = DbType.String });
                if (Parameters[pParamName].DbType.IsNumericType())
                {
                    if (pValue != null && pValue.ToString() == "")
                    {
                        pValue = null;
                    }
                }

                if (Parameters[pParamName].DbType == DbType.DateTime)
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
        public override void AddControlParameter(string pParamName, object ParamControl)
        {
            if (pParamName.Substring(0, 1) != "@")
            {
                pParamName = '@' + pParamName;
            }
            XMLParameter lParam;
            if (Parameters[pParamName] != null)
            {
                lParam = _parameters[pParamName];
            }
            else
            {
                lParam = new XMLParameter()
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
        public void AssignOutputParameterContainer(string ParamName, out XMLParameter ParamOut, object Value = null)
        {
            XMLParameter _param;
            if (ParamName.Substring(0, 1) != "@")
            {
                ParamName = '@' + ParamName;
            }
            if (Parameters[ParamName] != null)
            {
                _param = _parameters[ParamName];
            }
            else
            {
                _param = new XMLParameter()
                {
                    ParameterName = ParamName
                };
                Parameters.Add(_param);
            }
            if (Value != null)
            {
                AddParameterValue(ParamName, Value);
            }
            ParamOut = _param;
            //ObjectParameters.Add(new ObjectParameter() {Container=Container, Parameter=_param });

        }
        public override void AssignValuesParameters()
        {
            if (ControlParameters != null)
                ControlParameters.Where(x => x.LinkedControl is IsValuable && (x.Parameter.Direction == ParameterDirection.InputOutput || x.Parameter.Direction == ParameterDirection.Output)).ToList().ForEach(p => ((IsValuable)p.LinkedControl).Value = p.Parameter.Value);
        }
        public override void Execute()
        {
            AssignParameterValues();

            XDocument _msgOut = Task.Run(() => EspackCommServer.Server.Transmit(XMessage)).Result;

            if (_msgOut.Element("result").Value.Substring(0, 5) == "ERROR")
                throw new Exception(_msgOut.Element("result").Value);
            //to do: recover parameter values for output parameters
            _msgOut.Root.Element("parameters").Elements("parameter").ToList().ForEach(p =>
            {
                AddParameterValue(p.Element("Name").Value, p.Element("Value").Value);
                Parameters[p.Element("Name").Value].Direction = (ParameterDirection)Enum.Parse(typeof(ParameterDirection), p.Element("Direction").Value.ToString());
            });
            AssignValuesParameters();
            string _msg = "";
            try
            {
                _msg = Parameters["@msg"].Value.ToString();
            }
            catch
            {
                _msg = "";
            }
            LastMsg = _msg;
        }
        public override async Task ExecuteAsync()
        {
            AssignParameterValues();

            XDocument _msgOut = await EspackCommServer.Server.Transmit(XMessage);

            if (_msgOut.Element("result").Value.Substring(0, 5) == "ERROR")
                throw new Exception(_msgOut.Element("result").Value);
            //to do: recover parameter values for output parameters
            _msgOut.Root.Element("parameters").Elements("parameter").ToList().ForEach(p =>
            {
                AddParameterValue(p.Element("Name").Value, p.Element("Value").Value);
                Parameters[p.Element("Name").Value].Direction = (ParameterDirection)Enum.Parse(typeof(ParameterDirection), p.Element("Direction").Value.ToString());
            });
            AssignValuesParameters();
            string _msg = "";
            try
            {
                _msg = Parameters["@msg"].Value.ToString();
            }
            catch
            {
                _msg = "";
            }
            LastMsg = _msg;
        }
        public override Dictionary<string, object> ReturnValues()
        {
            return Parameters.OfType<XMLParameter>()
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
        protected override void Dispose(bool disposing)
        {
            //for future uses
        }
    }

    public class XMLRS : RSFrame, XMLEspackDataThing
    {
        public bool Compression { get; set; } = false;
        protected DataSet mDS;
        protected new XMLParameterCollection Parameters { get; set; }

        public override int RecordCount
        {
            get
            {
                return mDS.Tables["Result"]?.Rows.Count ?? 0;
            }
        }

        public override object this[string Idx]
        {
            get
            {
                return mDS.Tables["Result"]?.Rows[Index][Idx];
            }
        }
        public override object this[int Idx]
        {
            get
            {
                return mDS.Tables["Result"]?.Rows[Index][Idx];
            }
        }
        public override int FieldCount
        {
            get
            {
                return mDS.Tables["Result"]?.Columns.Count ?? 0;
            }
        }

        public override List<string> Fields
        {
            get
            {
                return mDS.Tables["Result"]?.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToList();
            }
            protected set
            {
                //base.Fields = value;
            }
        }

        public DataSet DS
        {
            get
            {
                return mDS;
            }
        }

        public override List<DataRow> ToList()
        {
            return mDS.Tables["Result"]?.Rows.Cast<DataRow>().ToList();
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

        public override void Close()
        {
            mDS = null;
        }

        public override List<DataRow> getList()
        {
            //var _list = new List<DbDataRecord>();
            return mDS.Tables["Result"]?.Rows.OfType<DataRow>().ToList();
        }

        public override void AddControlParameter(string ParamName, object ParamControl)
        {
            {
                XMLParameter lParam = new XMLParameter()
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
        }

        private cAccesoDatosXML Conn
        {
            get
            {
                return (cAccesoDatosXML)mConn;
            }
            set
            {
                mConn = value;
            }
        }

        public XDataMessageRequest XMessage
        {
            get
            {
                var _x = new XDataMessageRequest();
                _x.SetActionDefinition("Recordset");
                var _d = new XElement(XThingElement);
                _d.Name = "data";
                _x.SetActionData(_d);
                _x.SetSession(EspackCommServer.Server.SessionNumber);
                return _x;
            }
        }

        public XElement XThingElement
        {
            get
            {
                var _x = new XElement("recordset");
                _x.Add(Conn.XThingElement);
                _x.Add(new XElement("sql", SQL));
                return _x;
            }
        }

        public override List<DataRow> Rows
        {
            get
            {
                return mDS.Tables["Result"].Rows.OfType<DataRow>().ToList();
            }
        }

        //public override List<string> Fields { protected set => throw new NotImplementedException(); }

        public override void Execute()
        {
            XDocument _msgOut = Task.Run(() => EspackCommServer.Server.Transmit(XMessage)).Result;
            if (_msgOut.Element("result").Value.Substring(0, 5) == "ERROR")
                throw new Exception(_msgOut.Element("result").Value);
            //to do: recover parameter values for output parameters
            mDS = new DataSet();
            mDS.ReadXml(_msgOut.CreateReader());


        }

        public override async Task ExecuteAsync()
        {
            XDocument _msgOut = await EspackCommServer.Server.Transmit(XMessage);
            var _res = _msgOut.Element("result").Value;
            if (_res.Length >= 5 && _res.Substring(0, 5) == "ERROR")
                throw new Exception(_msgOut.Element("result").Value);
            //to do: recover parameter values for output parameters
            mDS = new DataSet();
            mDS.ReadXml(_msgOut.CreateReader());


        }
        public XMLRS()
            : base()
        {
            //mDS = new DataSet();

        }
        public XMLRS(string Sql, cAccesoDatosXML Conn)
            : base()
        {
            SQL = Sql;
            mConn = Conn;
            //mDS = new DataSet();
        }
    }

    public static class EspackCommServer
    {
        public static CommServer Server { get; } = new CommServer();
    }


    public class CommServer : INotifyPropertyChanged
    {
        //public const string MAINSERVERIP;
        private string _serial = null;
        public string Serial
        {
            get
            {
                _serial = _serial ?? Environment.MachineName;
                return _serial;
            }
            set
            {
                _serial = value;
            }
        }
        //session number
        private string _session = null;
        private string _COD3 = null;
        private string _DBServer = null;

        public string SessionNumber
        {
            get
            {
                return _session;
            }
            set
            {
                _session = value;
            }
        }

        public IPAddress IP { get; set; }
        public int Port { get; set; }
        public string Cod3 => _COD3;
        public string DBServer => _DBServer;

        public static List<IPAddress> IPServerList { get; set; } = new List<IPAddress>();

        public async Task getSocksConnection()
        {
            IPServerList.Clear();
            Status = CommStatus.TRYCONNECT;

            List<string> serverList = new List<string>()
            {
                //"10.200.90.40", /***/
                "azuradio01.uksouth.cloudapp.azure.com",    // Azure UK South
                "val-tel1.espackeuro.com",                  // Valencia Tel1
                "val-vndjzkmdjv.dynamic-m.com",             // Valencia Meraki
                "liv-bkrgrgvmjv.dynamic-m.com",             // Liverpool Meraki
                "nit-cwcgtdrrjv.dynamic-m.com",             // Nitra Meraki
                "cas-wired-wcwqhcjnjv.dynamic-m.com"        // Castle Bromwich Meraki
                
                //"val-nwckkdjtjv.dynamic-m.com", // Old one
                //"gra-bghgwkwqjv-1.dynamic-m.com", // GRA doesn't exist anymore
                //"nit-cwcgtdrrjv-1.dynamic-m.com", // Old one?
                
            };
            foreach (var server in serverList)
            {
                try
                {
                    IPServerList.Add((await Dns.GetHostAddressesAsync(server))[0]);
                }
                catch
                {

                }
            };
            if (IPServerList.Count == 0)
            {
                
                IPServerList.Add(IPAddress.Parse("20.0.110.239"));      // azuradio01.uksouth.cloudapp.azure.com
                IPServerList.Add(IPAddress.Parse("213.0.111.218"));     // val-tel1.espackeuro.com & val-vndjzkmdjv.dynamic-m.com
                IPServerList.Add(IPAddress.Parse("81.131.22.66"));      // liv-bkrgrgvmjv.dynamic-m.com
                IPServerList.Add(IPAddress.Parse("62.168.66.218"));     // nit-cwcgtdrrjv.dynamic-m.com
                IPServerList.Add(IPAddress.Parse("109.159.205.186"));   // cas-wired-wcwqhcjnjv.dynamic-m.com

                //IPServerList.Add(IPAddress.Parse("46.24.173.2"));     // Unknown
                //IPServerList.Add(IPAddress.Parse("81.150.8.34"));     // Unknown
                //IPServerList.Add(IPAddress.Parse("81.12.170.94"));    // Unknown

            }


            _session = "";
            var _message = new XDataMessageRequest();
            _message.SetActionDefinition("Start Session");
            _message.SetActionData(new XElement("data", Serial));
            _message.SetSession("");
            XDocument _msgOut = new XDocument();
//            Port = 17011;
            Port = 20001;   /***/
            string _ip = "";
            string _messages = "";
            foreach (var _IP in IPServerList)
            {
                _ip = $"{_ip}-{_IP.ToString()}";
//#if DEBUG
//                IP = IPAddress.Parse("10.120.90.11");
//#else
                IP = _IP;
//#endif
                try
                {
                    _msgOut = await Transmit(_message);
                    break;
                }
                catch (Exception ex)
                {
                    _messages = $"{_messages}-{ex.Message}";
                }
            }

            //first phase, get the destination external IP to connect
            //create the xml message with the session information

            var _result = _msgOut.Root;
            if (_result == null || _result.Value.Substring(0, 5) == "ERROR")
            {
                _session = null;
                throw new Exception(_result?.Value ?? $"Cannot connect to any server. Last IP {_ip}, messages received: {_messages}");
            }
            else
            {
                var _parameters = _result.Element("parameters").Elements("parameter");

                string _sIP = (from _par in _parameters where _par.Element("Name").Value.ToString() == "@ExternalIP" select _par.Element("Value").Value).First();
                Port = (from _par in _parameters where _par.Element("Name").Value.ToString() == "@Port" select _par.Element("Value").Value).First().ToInt();
                
                //DBServer = (from _par in _parameters where _par.Element("Name").Value.ToString() == "@DBServer" select _par.Element("Value").Value).First().ToInt();

                #if DEBUG
                //_sIP = "10.200.90.40";//"46.24.173.2"; /***/
                //_sIP = "20.0.110.239";
                //Port = 18011;
                #endif
                _COD3 = (from _par in _parameters where _par.Element("Name").Value.ToString() == "@COD3" select _par.Element("Value").Value).First();
                _session = (from _par in _parameters where _par.Element("Name").Value.ToString() == "@SessionNumber" select _par.Element("Value").Value).First();
                _DBServer = (from _par in _parameters where _par.Element("Name").Value.ToString() == "@DBServer" select _par.Element("Value").Value).First();
                
                IP = IPAddress.Parse(_sIP);
            }
        }
        public async Task<XDocument> Transmit(XDataMessageRequest x)
        {
            string aux="";
            try
            {
                Status = CommStatus.CONNECTED;
                if (_session == null)
                    await getSocksConnection();

                if (Cod3 != null  ) /***/
                {
                    try
                    {
                        // no way to update or add items in the XML. every test and try takes minutes, which i don't have... so the "cheapest" solution is:
                        aux = x.ToString().Replace("<COD3 />", $"<COD3>{Cod3}</COD3><DBServer>{DBServer}</DBServer>"); /***/
                        //x.Data.Element("data").Element("server").Element("COD3").Value = Cod3;
                        //x.Data.Element("data").Element("server").Element("HostName").Value = DBServer;
                        //x.Data.Element("data").Element("server").Add(new XElement("DBServer", DBServer));
                    } catch {
                        aux = x.ToString();
                    }
                } else
                {
                    aux = x.ToString();
                }

                var msgOut = new Message();
                var encryptedCompressedMsgOut = new EncryptMessageOutput(new CompressMessageOutput(msgOut)) { MsgIn = aux }; /***/
                await encryptedCompressedMsgOut.process();
                var Socket = new AsynchronousSocketClient() { ServerIP = IP, ServerPort = Port };
                var _result = await Socket.AsyncConversation(encryptedCompressedMsgOut.MsgOut);
                if (_result == "" || _result.Substring(0, 5) == "ERROR")
                {
                    throw new Exception(_result);
                }
                var msgIn = new Message();
                var decryptedUncompressedMsgIn = new DecryptMessageInput(new DecompressMessageInput(msgIn)) { MsgIn = _result };
                await decryptedUncompressedMsgIn.process();
                //Thread.Sleep(2000);
                //var m = new TransmitEntcryptedCompressedMessage() { ServerIP = IP, Port = Port };
                //m.MsgIn = x.ToString();
                //await m.process();
                //var _res= XDocument.Parse(m.MsgOut);
                var _res = XDocument.Parse(decryptedUncompressedMsgIn.MsgOut);
                Status = CommStatus.OFFLINE;
                return _res;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Status = CommStatus.ERROR;
                throw e;
            }
        }

        public async Task<string> Transmit(string s)
        {
            var msgOut = new Message();
            var encryptedCompressedMsgOut = new EncryptMessageOutput(new CompressMessageOutput(msgOut)) { MsgIn = s };
            await encryptedCompressedMsgOut.process();
            var Socket = new AsynchronousSocketClient() { ServerIP = IP, ServerPort = Port };
            var _result = Socket.SyncConversation(encryptedCompressedMsgOut.MsgOut);
            var msgIn = new Message();
            var decryptedUncompressedMsgIn = new DecompressMessageInput(new DecryptMessageInput(msgIn)) { MsgIn = _result };
            await decryptedUncompressedMsgIn.process();
            return decryptedUncompressedMsgIn.MsgOut;
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        private CommStatus oStatus = CommStatus.OFFLINE;

        public CommStatus Status
        {
            get
            {
                return oStatus;
            }
            set
            {
                if (value != oStatus)
                {
                    oStatus = value;
                    OnPropertyChanged("Status");
                }

            }
        }
    }

    public enum CommStatus { OFFLINE, TRYCONNECT, CONNECTED, ERROR }
}
