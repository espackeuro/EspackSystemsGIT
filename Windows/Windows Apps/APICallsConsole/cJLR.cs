using System;
using System.Collections.Generic;
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

        // Public read only access
        public string MessageID { get { return pMessageID; } }
        public string OrderNumber { get { return pOrderNumber; } }
        public string Model { get { return pModel; } }
        public string TLS { get { return pTLS; } }
        public string Status { get { return pStatus; } }
        public string TimeStamp { get { return pTimeStamp; } }
        public cJLRMessageAttributes Attributes { get { return pAttributes; } }

        // Constructor
        public cJLRMessage(string messageID, string orderNumber, string model, string tls, string status, string timeStamp, cJLRMessageAttributes attributes)
        {
            pMessageID = messageID;
            pOrderNumber = orderNumber;
            pModel = model;
            pTLS = tls;
            pStatus = status;
            pTimeStamp = timeStamp;
            pAttributes = attributes;
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
        public SortedDictionary<string, cJLRMessage> Messages = null;

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
            string _stage = "";
            cJLRMessageAttributes _attributes;
            cJLRMessage _message;

            try
            {
                //
                _stage = "Checkings";
                if (Messages != null)
                    throw new Exception("There are already messages in the pending list");

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
                Messages = new SortedDictionary<string, cJLRMessage>();

                XmlDocument _xml = new XmlDocument();
                _xml.LoadXml(MessagesString);

                XmlNodeList _nodes = _xml.SelectNodes("messages/*");
                foreach (XmlNode _node in _nodes)
                {
                    XmlNodeList _nodeAttributes = _node.SelectNodes("attributes/*");
                    _attributes = null;

                    _attributes = new cJLRMessageAttributes(_nodeAttributes[0].Attributes[1].Value,
                        _nodeAttributes[1].Attributes[1].Value,
                        _nodeAttributes[2].Attributes[1].Value,
                        _nodeAttributes[3].Attributes[1].Value,
                        _nodeAttributes[4].Attributes[1].Value,
                        _nodeAttributes[5].Attributes[1].Value,
                        _nodeAttributes[6].Attributes[1].Value,
                        _nodeAttributes[7].Attributes[1].Value,
                        _nodeAttributes[8].Attributes[1].Value,
                        _nodeAttributes[9].Attributes[1].Value,
                        _nodeAttributes[10].Attributes[1].Value,
                        _nodeAttributes[11].Attributes[1].Value,
                        _nodeAttributes[12].Attributes[1].Value,
                        _nodeAttributes[13].Attributes[1].Value,
                        _nodeAttributes[14].Attributes[1].Value);
                    
                    //_attributes = new cJLRMessageAttributes(_nodeAttributes.Attributes["TLS"].Value,
                    //    _nodeAttributes.Attributes["TIMESTAMP"].Value,
                    //    _nodeAttributes.Attributes["ASSEMBLYTRACK"].Value,
                    //    _nodeAttributes.Attributes["DRIVE"].Value,
                    //    _nodeAttributes.Attributes["SEND_TO_MARKET"].Value,
                    //    _nodeAttributes.Attributes["BUILD_TO_MARKET"].Value,
                    //    _nodeAttributes.Attributes["FULL_VIN"].Value,
                    //    _nodeAttributes.Attributes["LAST_LAUNCH_TLS"].Value,
                    //    _nodeAttributes.Attributes["COLOUR"].Value,
                    //    _nodeAttributes.Attributes["MODEL"].Value,
                    //    _nodeAttributes.Attributes["MODEL_YEAR"].Value,
                    //    _nodeAttributes.Attributes["BSN"].Value,
                    //    _nodeAttributes.Attributes["VFIFO_QTY"].Value,
                    //    _nodeAttributes.Attributes["SHORT_VIN"].Value,
                    //    _nodeAttributes.Attributes["EEC_VIN_PREFIX"].Value);

                    //_attributes = new cJLRMessageAttributes(_nodeAttributes.Item(0).Attributes["TLS"].Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value,
                    //    _nodeAttributes.Item(0).Value);

                    _message = new cJLRMessage(_node.Attributes["messageID"].Value,
                        _node.Attributes["orderNumber"].Value,
                        _node.Attributes["model"].Value,
                        _node.Attributes["tls"].Value,
                        _node.Attributes["status"].Value,
                        _node.Attributes["timestamp"].Value,
                        _attributes);

                    Messages.Add(_message.MessageID, _message);
                }
                //
                _stage = "Getting first messageID from list";
                //txtLastMessageID.Text = elemlist[0].Attributes.GetNamedItem("messageID").InnerXml.ToString();


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
