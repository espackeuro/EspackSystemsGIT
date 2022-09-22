using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace JaguarLandRover.SupplierBroadcast.Client
{
    class cJLR : IDisposable
    {
        public static string ServiceURL; //= "https://motersuppliermsgqa.jlrext.com/SupplierBroadCast";
        public static string User; //="ESPACK";
        public static string Password;// = "Jag@2022";
        public static string APIKey; // = "2c50fb8f-787f-4b56-b510-2767703aef1c"; //"c7a4284c-2ddf-4b07-ab6a-b489fa8ba1d5";

        private SupplierWebService.SupplierServiceContractClient Client;
        public string Messages;

        public cJLR(string serviceURL, string apiKey, string user, string password)
        {
            ServiceURL = serviceURL;
            User = user;
            Password = password;
            APIKey = apiKey;
        }

        public bool GetMessages()
        {
            string _stage = "";
            
            try
            {
                _stage = "Getting messages";
                Messages = Client.GetMessages(APIKey);
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            
            
            return true;
        }

        public bool RemoveTimestampFromSecurityBinding<TChannel>(ClientBase<TChannel> serviceClient) where TChannel : class
        {
            string _stage = "";
            try
            {
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
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            return true;
        }

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
        public void Dispose()
        {
            try
            {
                Disconect();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
