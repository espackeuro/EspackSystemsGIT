using AccesoDatosNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace APICallsConsole
{
    
    // Class cJLRMessageAttributes: contains the data included in the attributes of each the message
    class cJLRMessageAttributes : IDisposable
    {
        // Private properties
        private int? pTLS;
        private DateTime? pTimeStamp;
        private string pAssemblyTrack;
        private string pDrive;
        private string pSendToMarket;
        private string pBuildToMarket;
        private string pFullVIN;
        private int? pLastLaunchTLS;
        private string pColour;
        private string pModel;
        private string pModelYear;
        private int? pBSN;
        private int? pVFifoQty;
        private string pShortVIN;
        private string pEECVINPrefix;

        // Public read only access
        public int? TLS { get { return pTLS; } }
        public DateTime? TimeStamp { get { return pTimeStamp; } }
        public string AssemblyTrack { get { return pAssemblyTrack; } }
        public string Drive { get { return pDrive; } }
        public string SendToMarket { get { return pSendToMarket; } }
        public string BuildToMarket { get { return pBuildToMarket; } }
        public string FullVIN { get { return pFullVIN; } }
        public int? LastLaunchTLS { get { return pLastLaunchTLS; } }
        public string Colour { get { return pColour; } }
        public string Model { get { return pModel; } }
        public string ModelYear { get { return pModelYear; } }
        public int? BSN { get { return pBSN; } }
        public int? VFifoQty { get { return pVFifoQty; } }
        public string ShortVIN { get { return pShortVIN; } }
        public string EECVINPrefix { get { return pEECVINPrefix; } }

        // Constructor
        public cJLRMessageAttributes(int? tls, DateTime? timeStamp, string assemblyTrack, string drive, string sendToMarket, string buildToMarket, string fullVIN, int? lastLaunchTLS, string colour, string model, string modelYear, int? bsn, int? vFifoQty, string shortVIN, string eecVINPrefix)
        {
            pTLS = tls;
            pTimeStamp = timeStamp;
            pAssemblyTrack = assemblyTrack;
            pDrive = drive;
            pSendToMarket = sendToMarket;
            pBuildToMarket = buildToMarket;
            pFullVIN = fullVIN;
            pLastLaunchTLS = lastLaunchTLS;
            pColour = colour;
            pModel = model;
            pModelYear = modelYear;
            pBSN = bsn;
            pVFifoQty = vFifoQty;
            pShortVIN = shortVIN;
            pEECVINPrefix = eecVINPrefix;
        }

        // Destructor
        public void Dispose()
        {

        }
    }

    // Class cJLRMessage: contains the data included in the main node of the message
    class cJLRMessage : IDisposable
    {
        // Private properties
        private int pMessageID;
        private int pOrderNumber;
        private string pModel;
        private int pTLS;
        private int pStatus;
        private DateTime pTimeStamp;
        private cJLRMessageAttributes pAttributes;
        private Dictionary<string, dynamic> pProperties;

        // Public read only access
        public int MessageID { get { return pMessageID; } }
        public int OrderNumber { get { return pOrderNumber; } }
        public string Model { get { return pModel; } }
        public int TLS { get { return pTLS; } }
        public int Status { get { return pStatus; } }
        public DateTime TimeStamp { get { return pTimeStamp; } }
        public cJLRMessageAttributes Attributes { get { return pAttributes; } }
        public Dictionary<string, dynamic> Properties { get { return pProperties; } }

        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
           // set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        // Constructor
        public cJLRMessage(int messageID, int orderNumber, string model, int tls, int status, DateTime timeStamp, cJLRMessageAttributes attributes)
        {
            string _stage = "";

            try
            {

                //
                _stage = "Assigning values";
                pMessageID = messageID;
                pOrderNumber = orderNumber;
                pModel = model;
                pTLS = tls;
                pStatus = status;
                pTimeStamp = timeStamp;
                pAttributes = attributes;

                //
                _stage = "Generating list of properties";
                IEnumerable<Tuple<string, dynamic>> _messageProps =                              // And here we go, my beloved nemesis: Linq queries
                    (from property in this.GetType().GetProperties()                            // <- Get automatically the list of public properties of this class
                     where property.PropertyType == typeof(string)               // <- But not of type cJLRMessageAttributes
                     || property.PropertyType == typeof(int)
                     || property.PropertyType == typeof(DateTime)
                     // && property.PropertyType != typeof(Dictionary<string, dynamic>)          // <- neiter of type Dictionary<string,string>
                     select new Tuple<string, dynamic>(property.Name,                            // <- Create a tuple (Property Name...
                                       property.GetValue(this))                         // <- ... and Value)
                     ).Union(from property in this.Attributes.GetType().GetProperties()         // <- Join obtained list with the list of the properties of the Attribute class
//                             where property.PropertyType == typeof(string)                      // <- Again, only those which are string
                             select new Tuple<string, dynamic>("Att" + property.Name,            // <- Create a tuple again, but the property name will start with "Att"
                                               property.GetValue(this.Attributes)));    // Done

                //
                _stage = "Creating properties dictionary";
                pProperties = _messageProps.ToDictionary(x => x.Item1, x => x.Item2);

            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }

        }

        // Destructor
        public void Dispose()
        {
            pAttributes = null;
        }
    }

    // Class cJLRComm: it performs the communication stuff
    class cJLRComm : IDisposable
    {

        // Private properties
        private string pServiceURL; //= "https://motersuppliermsgqa.jlrext.com/SupplierBroadCast";
        private string pUser; //="ESPACK";
        private string pPassword;// = "Jag@2022";
        private string pAPIKey; // = "2c50fb8f-787f-4b56-b510-2767703aef1c"; //"c7a4284c-2ddf-4b07-ab6a-b489fa8ba1d5";
        private string pSessionID;

        // Public read only access
        public string ServiceURL { get { return pServiceURL; } }
        public string User { get { return pUser; } }
        public string Password { get { return pPassword; } }
        public string APIKey { get { return pAPIKey; } }
        public string SessionID { get { return pSessionID; } }

        // Private vars
        private SupplierWebService.SupplierServiceContractClient Client;

        // To be decided
        public string MessagesString;
        public Dictionary<string, cJLRMessage> Messages = null;

        // Constructor
        public cJLRComm(string serviceURL, string user, string password, string apiKey)
        {
            pServiceURL = serviceURL;
            pUser = user;
            pPassword = password;
            pAPIKey = apiKey;
            pSessionID = null;
        }

        // Public functions

        // GetMessages: get the pending messages from the Web API
        public bool GetMessages()
        {
            string _stage = "", _messageID = "";
            cJLRMessageAttributes _attributes;
            cJLRMessage _message;

            try
            {
                //
                _stage = "Checkings";
                if (Messages != null)
                {
                    Messages.Clear();
                    Messages = null;
                }

                //
                if (Client == null)
                {
                    _stage = "Connecting to API";
                    if (!Connect())
                        throw new Exception("Error unknown");
                }

                //
                _stage = "Getting messages";
                MessagesString = Client.GetMessages(APIKey);

                ////
                //_stage = "Disconnecting";
                //Disconect();

                //
                _stage = "Formatting XML data";
                Messages = new Dictionary<string, cJLRMessage>();

                XmlDocument _xml = new XmlDocument();
                _xml.LoadXml(MessagesString);

                XmlNodeList _nodes = _xml.SelectNodes("messages/*");
                foreach (XmlNode _node in _nodes)
                {
                    //
                    _stage = "Getting messageID";
                    _messageID = _node.Attributes["messageID"].Value;

                    _stage = $"Getting attributes from message {_messageID}";
                    XmlNodeList _nodeAttributes = _node.SelectNodes("attributes/*");
                    
                    //
                    _stage = $"Creating attributes object for message {_messageID}";
                    _attributes = new cJLRMessageAttributes(
                        Int32.TryParse(_nodeAttributes[0].Attributes[1].Value, out int _tls) ? _tls : (int?)null,                   // TLS
                        DateTime.TryParse(_nodeAttributes[1].Attributes[1].Value, out DateTime _date) ? (DateTime?)_date : null,    // TIMESTAMP
                        _nodeAttributes[2].Attributes[1].Value,                                                                     // ASSEMBLYTRACK
                        _nodeAttributes[3].Attributes[1].Value,                                                                     // DRIVE
                        _nodeAttributes[4].Attributes[1].Value,                                                                     // SEND_TO_MARKET
                        _nodeAttributes[5].Attributes[1].Value,                                                                     // BUILD_TO_MARKET
                        _nodeAttributes[6].Attributes[1].Value,                                                                     // FULL_VIN
                        Int32.TryParse(_nodeAttributes[7].Attributes[1].Value, out int _launch) ? _launch : (int?)null,             // LAST_LAUNCH_TLS
                        _nodeAttributes[8].Attributes[1].Value,                                                                     // COLOUR
                        _nodeAttributes[9].Attributes[1].Value,                                                                     // MODEL
                        _nodeAttributes[10].Attributes[1].Value,                                                                    // MODEL_YEAR
                        Int32.TryParse(_nodeAttributes[11].Attributes[1].Value, out int _bsn) ? _bsn : (int?)null,                  // BSN
                        Int32.TryParse(_nodeAttributes[12].Attributes[1].Value, out int _qty) ? _qty : (int?)null,                  // VFIFO_QTY                        
                        _nodeAttributes[13].Attributes[1].Value,                                                                    // SHORT_VIN
                        _nodeAttributes[14].Attributes[1].Value);                                                                   // EEC_VIN_PREFIX

                    //
                    _stage = $"Creating object for message {_messageID}";
                    _message = new cJLRMessage(
                        Int32.Parse(_node.Attributes["messageID"].Value),
                        Int32.Parse(_node.Attributes["orderNumber"].Value),
                        _node.Attributes["model"].Value,
                        Int32.Parse(_node.Attributes["tls"].Value),
                        Int32.Parse(_node.Attributes["status"].Value),
                        DateTime.Parse(_node.Attributes["timestamp"].Value),
                        _attributes);

                    //
                    _stage = $"Adding message {_messageID} to dictionary";
                    Messages.Add(_messageID, _message);

                }
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }

            return true;
        }

        // Bind the client service elements (don't ask, please)
        private bool RemoveTimestampFromSecurityBinding<TChannel>(ClientBase<TChannel> serviceClient) where TChannel : class
        {
            string _stage = "";
            try
            {
                //
                _stage = "Checking";
                if (Client == null)
                    throw new Exception("Client is not connected");

                //
                _stage = "Binding elements";
                BindingElementCollection elements = serviceClient.Endpoint.Binding.CreateBindingElements();
                SecurityBindingElement sbe = elements.Find<SecurityBindingElement>();

                if (sbe != null)
                {
                    sbe.IncludeTimestamp = false;
                }

                //
                _stage = "Creating custom binding";
                serviceClient.Endpoint.Binding = new CustomBinding(elements);
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            return true;
        }

        // Acknowledge the message by ID. If success, next messages 
        public bool AcknowledgeLastMessageReceived(string lastMessageID)
        {
            string _stage = "";

            try
            {
                //
                if (Client == null)
                {
                    _stage = "Connecting to API";
                    if (!Connect())
                        throw new Exception("Error unknown");
                }

                //
                _stage = $"Acknowledging message {lastMessageID}";
                Client.AcknowledgeLastMessageReceived(APIKey, lastMessageID);
                
                ////
                //_stage = "Disconnecting";
                //Disconect();

            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            return true;
        }

        // Connect to the Web API
        public bool Connect()
        {
            string _stage = "";

            try
            {
                //
                _stage = "Checking";
                if (Client != null)
                    throw new Exception("Client already connected");

                //
                _stage = "Creating client";
                Client = new SupplierWebService.SupplierServiceContractClient();
                Client.Endpoint.Address = new EndpointAddress(ServiceURL);
                Client.ClientCredentials.UserName.UserName = User;
                Client.ClientCredentials.UserName.Password = Password;

                //
                _stage = "Binding client elements";
                if (!RemoveTimestampFromSecurityBinding<SupplierWebService.ISupplierServiceContract>(Client))
                    throw new Exception("Error unknown");

                //
                _stage = "Clearing dictionary";
                if (Messages != null)
                    Messages.Clear();
                Messages = null;
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            return true;
        }

        // Disconnect from the Web API
        public bool Disconect()
        {
            string _stage = "";

            try
            {
                //
                _stage = "Checking";
                if (Client == null)
                    throw new Exception("Client is not connected");

                //
                _stage = "";
                Client.Close();
                Client = null;
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            return true;
        }

        // Destructor
        public void Dispose()
        {
            string _stage = "";
            try
            {
                //
                _stage = "Disconnecting";
                Disconect();
            }
            catch(Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        public bool Save(string MessageID)
        {
            string _stage = "";

            try
            {
                //
                _stage = $"Getting message Id {MessageID}";
                cJLRMessage _message = Messages[MessageID];

                //
                _stage = $"Getting message Id {MessageID}";
                cJLRMessageAttributes _attributes = _message.Attributes;

                //
                _stage = "Preparing SP";
                using (var _sp = new SP(Values.gDatos, "pJLRTLSDataAdd"))
                {
                    //
                    _stage = "Adding parameters to SP";
                    _sp.AddParameterValue("@sessionID", pSessionID);
                    _sp.AddParameterValue("@messageID", _message.MessageID);
                    _sp.AddParameterValue("@orderNumber", _message.OrderNumber);
                    _sp.AddParameterValue("@model", _message.Model);
                    _sp.AddParameterValue("@TLS", _message.TLS);
                    _sp.AddParameterValue("@status", _message.Status);
                    _sp.AddParameterValue("@timeStamp", _message.TimeStamp);
                    _sp.AddParameterValue("@attTLS", _attributes.TLS);
                    _sp.AddParameterValue("@attTimeStamp", _attributes.TimeStamp);
                    _sp.AddParameterValue("@attAssemblyTrack", _attributes.AssemblyTrack);
                    _sp.AddParameterValue("@attDrive", _attributes.Drive);
                    _sp.AddParameterValue("@attSendToMarket", _attributes.SendToMarket);
                    _sp.AddParameterValue("@attBuildToMarket", _attributes.BuildToMarket);
                    _sp.AddParameterValue("@attFullVIN", _attributes.FullVIN);
                    _sp.AddParameterValue("@attLastLaunchTLS", _attributes.LastLaunchTLS);
                    _sp.AddParameterValue("@attColour", _attributes.Colour);
                    _sp.AddParameterValue("@attModel", _attributes.Model);
                    _sp.AddParameterValue("@attModelYear", _attributes.ModelYear);
                    _sp.AddParameterValue("@attBSN", _attributes.BSN);
                    _sp.AddParameterValue("@attVFifoQty", _attributes.VFifoQty);
                    _sp.AddParameterValue("@attShortVIN", _attributes.ShortVIN);
                    _sp.AddParameterValue("@attEECVINPrefix", _attributes.EECVINPrefix);
                    _sp.AddParameterValue("@service", Values.Service);
                    _sp.AddParameterValue("@cod3", Values.COD3);

                    //
                    _stage = "Executing SP";
                        _sp.Execute();

                    //
                    _stage = "Checking SP results";
                    if (_sp.LastMsg.Substring(0, 2) != "OK")
                        throw new Exception($"{_sp.LastMsg}");

                    //
                    _stage = "Setting new session ID";
                    if (String.IsNullOrEmpty(pSessionID))
                        pSessionID = _sp.LastMsg.Substring(3);

                    //
                    _stage = $"Removing message ID {MessageID}";
                    Messages.Remove(MessageID);
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            return true;
        }
    }
}
