using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace JaguarLandRover.SupplierBroadcast.Client
{
    class Program
    {

        void Main(string[] args)
        {
            string _stage = "";
            cJLR _api = new cJLR("https://motersuppliermsgqa.jlrext.com/SupplierBroadCast", "ESPACK", "Jag@2022", "2c50fb8f-787f-4b56-b510-2767703aef1c");

            try
            {
                //
                _stage = "";
                if (!_api.Connect())
                    throw new Exception("Error unknown");


                _api.GetMessages();


				//
				// Acknowledge the last message ID received from the messages payload...
				//
				// client.AcknowledgeLastMessageReceived(API_KEY, lastMessageID);
				//

                
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(_api.Messages);
                Console.WriteLine(_api.messages);
                XmlNodeList elemlist = xml.GetElementsByTagName("message");
                string result = elemlist[0].InnerXml;

                Console.WriteLine($"{elemlist[0].Attributes.GetNamedItem("messageID").InnerXml}\n{result}");
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Hit any key to exit...");
                Console.ReadKey();
            }
        }

    }
}
