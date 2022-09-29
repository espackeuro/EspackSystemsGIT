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
        private string pTLS;
        private string pTimeStamp;
        private string pAssemblyTrack;
        private string pDrive;
        private string pSendToMarket;
        private string pBuildToMarket;
        private string pFullVIN;
        private string pLastLaunchTLS;
        private string pColour;
        private string pModel;
        private string pModelYear;
        private string pBSN;
        private string pVFifoQty;
        private string pShortVIN;
        private string pEECVINPrefix;

        // Public read only access
        public string TLS { get { return pTLS; } }
        public string TimeStamp { get { return pTimeStamp; } }
        public string AssemblyTrack { get { return pAssemblyTrack; } }
        public string Drive { get { return pDrive; } }
        public string SendToMarket { get { return pSendToMarket; } }
        public string BuildToMarket { get { return pBuildToMarket; } }
        public string FullVIN { get { return pFullVIN; } }
        public string LastLaunchTLS { get { return pLastLaunchTLS; } }
        public string Colour { get { return pColour; } }
        public string Model { get { return pModel; } }
        public string ModelYear { get { return pModelYear; } }
        public string BSN { get { return pBSN; } }
        public string VFifoQty { get { return pVFifoQty; } }
        public string ShortVIN { get { return pShortVIN; } }
        public string EECVINPrefix { get { return pEECVINPrefix; } }

        // Constructor
        public cJLRMessageAttributes(string tls, string timeStamp, string assemblyTrack, string drive, string sendToMarket, string buildToMarket, string fullVIN, string lastLaunchTLS, string colour, string model, string modelYear, string bsn, string vFifoQty, string shortVIN, string eecVINPrefix)
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
        private string pMessageID;
        private string pOrderNumber;
        private string pModel;
        private string pTLS;
        private string pStatus;
        private string pTimeStamp;
        private cJLRMessageAttributes pAttributes;
        private Dictionary<string, string> pProperties;

        // Public read only access
        public string MessageID { get { return pMessageID; } }
        public string OrderNumber { get { return pOrderNumber; } }
        public string Model { get { return pModel; } }
        public string TLS { get { return pTLS; } }
        public string Status { get { return pStatus; } }
        public string TimeStamp { get { return pTimeStamp; } }
        public cJLRMessageAttributes Attributes { get { return pAttributes; } }
        public Dictionary<string,string> Properties { get { return pProperties; } }

        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
           // set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        // Constructor
        public cJLRMessage(string messageID, string orderNumber, string model, string tls, string status, string timeStamp, cJLRMessageAttributes attributes)
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
                IEnumerable<Tuple<string, string>> _messageProps =                              // And here we go, my beloved nemesis: Linq queries
                    (from property in this.GetType().GetProperties()                            // <- Get automatically the list of public properties of this class
                     where property.PropertyType == typeof(string)                              // <- But only those whose type is string 
                     select new Tuple<string, string>(property.Name,                            // <- Create a tuple (Property Name...
                                       (string)property.GetValue(this))                         // <- ... and Value)
                     ).Union(from property in this.Attributes.GetType().GetProperties()         // <- Join obtained list with the list of the properties of the Attribute class
                             where property.PropertyType == typeof(string)                      // <- Again, only those which are string
                             select new Tuple<string, string>("Att" + property.Name,            // <- Create a tuple again, but the property name will start with "Att"
                                               (string)property.GetValue(this.Attributes)));    // Done

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

        // Public read only access
        public string ServiceURL { get { return pServiceURL; } }
        public string User { get { return pUser; } }
        public string Password { get { return pPassword; } }
        public string APIKey { get { return pAPIKey; } }

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
//                    throw new Exception("There are already messages in the pending list");

                //
                _stage = "Connecting to API";
                if (!Connect())
                    throw new Exception("Error unknown");

                //
                _stage = "Getting messages";
                MessagesString = Client.GetMessages(APIKey);

                //
                _stage = "Disconnecting";
                Disconect();

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
                        _nodeAttributes[0].Attributes[1].Value,     // TLS
                        _nodeAttributes[1].Attributes[1].Value,     // TIMESTAMP
                        _nodeAttributes[2].Attributes[1].Value,     // ASSEMBLYTRACK
                        _nodeAttributes[3].Attributes[1].Value,     // DRIVE
                        _nodeAttributes[4].Attributes[1].Value,     // SEND_TO_MARKET
                        _nodeAttributes[5].Attributes[1].Value,     // BUILD_TO_MARKET
                        _nodeAttributes[6].Attributes[1].Value,     // FULL_VIN
                        _nodeAttributes[7].Attributes[1].Value,     // LAST_LAUNCH_TLS
                        _nodeAttributes[8].Attributes[1].Value,     // COLOUR
                        _nodeAttributes[9].Attributes[1].Value,     // MODEL
                        _nodeAttributes[10].Attributes[1].Value,    // MODEL_YEAR
                        _nodeAttributes[11].Attributes[1].Value,    // BSN
                        _nodeAttributes[12].Attributes[1].Value,    // VFIFO_QTY
                        _nodeAttributes[13].Attributes[1].Value,    // SHORT_VIN
                        _nodeAttributes[14].Attributes[1].Value);   // EEC_VIN_PREFIX

                    //
                    _stage = $"Creating object for message {_messageID}";
                    _message = new cJLRMessage(_node.Attributes["messageID"].Value,
                        _node.Attributes["orderNumber"].Value,
                        _node.Attributes["model"].Value,
                        _node.Attributes["tls"].Value,
                        _node.Attributes["status"].Value,
                        _node.Attributes["timestamp"].Value,
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
                _stage = "Connecting to API";
                if (!Connect())
                    throw new Exception("Error unknown");

                //
                _stage = $"Acknowledging message {lastMessageID}";
                Client.AcknowledgeLastMessageReceived(APIKey, lastMessageID);
                
                //
                _stage = "Disconnecting";
                Disconect();

            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            return true;
        }

        // Connect to the Web API
        private bool Connect()
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
        private bool Disconect()
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
    }
}
