using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace APICallsConsole
{
    public partial class fMain : Form
    {
        private object API;
        private byte SecondsCounter;
        private const byte REFRESH_INTERVAL = 120;

        public fMain(string[] args)
        {
            InitializeComponent();
            SecondsCounter = REFRESH_INTERVAL;
            chkAutoRefresh.Text = $"Perform an autorefresh in {SecondsCounter} seconds";
            API = new cJLRComm("https://motersuppliermsgqa.jlrext.com/SupplierBroadCast", "ESPACK", "Jag@2022", "2c50fb8f-787f-4b56-b510-2767703aef1c");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string _stage = "";

            try
            {
                ////
                //_stage = "Connecting to JLR API";
                //if (!((cJLR)API).Connect())
                //    throw new Exception("Error unknown");

                //
                _stage = "Getting new messages";
                ((cJLRComm)API).GetMessages();


                // 
                _stage = "Loading messages into XML";
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(((cJLRComm)API).MessagesString);


                txtLog.Text = ((cJLRComm)API).MessagesString.ToString();
                XmlNodeList elemlist = xml.GetElementsByTagName("message");
                string result = elemlist[0].InnerXml; // header of the first message

                //
                _stage = "Getting first messageID from list";
                txtLastMessageID.Text = elemlist[0].Attributes.GetNamedItem("messageID").InnerXml.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }

        }

        private void btnACK_Click(object sender, EventArgs e)
        {
            string _stage = "";

            try
            {
                //
                _stage = "Checkings";
                if (API == null)
                    throw new Exception("API not created");
                if (txtLastMessageID.Text=="")
                    throw new Exception("Enter a last message ID");

                //
                _stage = "Calling ACK function";
                ((cJLRComm)API).AcknowledgeLastMessageReceived(txtLastMessageID.Text);
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            SecondsCounter--;
            if (SecondsCounter == 0)
            {
                SecondsCounter = REFRESH_INTERVAL;
                btnConnect_Click(sender, e);
            }
            chkAutoRefresh.Text = $"Perform an autorefresh in {SecondsCounter} seconds";

        }

        private void chkAutoRefresh_CheckedChanged(object sender, EventArgs e)
        {
            SecondsCounter = REFRESH_INTERVAL;
            chkAutoRefresh.Text = $"Perform an autorefresh in {SecondsCounter} seconds";
            tmrRefresh.Enabled = chkAutoRefresh.Checked;
            btnConnect.Enabled = !chkAutoRefresh.Checked;
        }
    }
    
}
