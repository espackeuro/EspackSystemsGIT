using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace JaguarLandRover.SupplierBroadcast.Client.TestConsole
{
    class Program
    {
        private static readonly string API_KEY = "2c50fb8f-787f-4b56-b510-2767703aef1c"; //"c7a4284c-2ddf-4b07-ab6a-b489fa8ba1d5";
        private static readonly string SERVICE_URL = "https://motersuppliermsgqa.jlrext.com/SupplierBroadCast";
        private static readonly string USERNAME = "ESPACK";
        private static readonly string PASSWORD = "Jag@2022";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                SupplierWebService.SupplierServiceContractClient client = new SupplierWebService.SupplierServiceContractClient();
				
				client.Endpoint.Address = new EndpointAddress(SERVICE_URL);

				client.ClientCredentials.UserName.UserName = USERNAME;
				client.ClientCredentials.UserName.Password = PASSWORD;

				RemoveTimestampFromSecurityBinding<SupplierWebService.ISupplierServiceContract>(client);

				//
				// Retrieve any pending messages for this API key, limited to a max payload of 50 messages...
				//
                string messages = client.GetMessages(API_KEY);

				//
				// Acknowledge the last message ID received from the messages payload...
				//
				// client.AcknowledgeLastMessageReceived(API_KEY, lastMessageID);
				//

                
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(messages);
                Console.WriteLine(messages);
                XmlNodeList elemlist = xml.GetElementsByTagName("message");
                string result = elemlist[0].InnerXml;

                Console.WriteLine($"{elemlist[0].Attributes.GetNamedItem("messageID").InnerXml}\n{result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Hit any key to exit...");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TChannel"></typeparam>
        /// <param name="serviceClient"></param>
        public static void RemoveTimestampFromSecurityBinding<TChannel>(ClientBase<TChannel> serviceClient) where TChannel : class
        {
            BindingElementCollection elements = serviceClient.Endpoint.Binding.CreateBindingElements();
            SecurityBindingElement sbe = elements.Find<SecurityBindingElement>();

            if (sbe != null)
            {
                sbe.IncludeTimestamp = false;
            }

            serviceClient.Endpoint.Binding = new CustomBinding(elements);
        }
    }
}
