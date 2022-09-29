using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using AccesoDatosNet;
using CommonTools;

namespace APICallsConsole
{
    public partial class fMain : Form
    {
        // When we need another kind of API here to do general calls, the definition should be this one and the calls with (cJLRComm) prefix:
        // ((cJLRComm)API).GetMessages(). But for the moment, for clarity and comfort, the class for API object will be explicitly cJLRComm.
        // private object API; 
        private cJLRComm API;
        private byte SecondsCounter;
        private const byte REFRESH_INTERVAL = 120;

        public fMain(string[] args)
        {
            InitializeComponent();

            var espackArgs = CT.LoadVars(args);
            Values.ProjectName = "WebAPIDownloader";
            Values.gDatos.DataBase = espackArgs.DataBase;
            Values.gDatos.Server = espackArgs.Server;
            Values.gDatos.User = espackArgs.User;
            Values.gDatos.Password = espackArgs.Password;

            try
            {
                Values.gDatos.Connect();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error connecting to database: " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            Values.gDatos.Close();

            SecondsCounter = REFRESH_INTERVAL;
            API = new cJLRComm("https://motersuppliermsgqa.jlrext.com/SupplierBroadCast", "ESPACK", "Jag@2022", "2c50fb8f-787f-4b56-b510-2767703aef1c");
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string _stage = "";

            try
            {
                //
                btnConnect.Enabled = false;
                tmrRefreshPending.Enabled = false;
                SecondsCounter = REFRESH_INTERVAL;

                //
                _stage = "Getting new messages";
                if (API.GetMessages())
                {
                    FillPendingMessages();
                    FillProcessedMessages();
                }

            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
            finally
            {
                btnConnect.Enabled = true;
                tmrRefreshPending.Enabled = true;
            }

        }

        private void FillPendingMessages()
        {
            string _stage = "";

            try
            {
                //
                _stage = "Checkings";
                if (API.Messages == null)
                    return;

                //
                _stage = "Defining columns";
                if (dgvPendingMessages.Columns.Count == 0)
                {

                    //
                    _stage = "Getting list of message columns";
                    foreach (string _columnName in API.Messages.First().Value.Properties.Keys)
                    {
                        _stage = $"Adding column {_columnName}";
                        dgvPendingMessages.Columns.Add(_columnName, ColumnizeName(_columnName));
                    }

                }

                //
                _stage = "Adding data to the grid";
                dgvPendingMessages.Rows.Clear();
                foreach (cJLRMessage _message in API.Messages.Values)
                {
                    //
                    _stage = $"Adding row ";
                    dgvPendingMessages.Rows.Add(_message.Properties.Values.ToArray());

                }

                lblPendingMessages.Text = $"Pending messages ({dgvPendingMessages.Rows.Count})";
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        private void FillProcessedMessages()
        {
            string _stage = "";


            // TO SHOW DB DATA (all bellow has to be changed)
            try
            {
                //
                _stage = "Checkings";

                // Add the results of the query to the DataGrid            
                //select * from JLRSequences where xfec>dateadd(hour,-8,getdate()) order by xfec desc
                using (var _rs = new StaticRS($"select * from JLRSequences", Values.gDatos))
                {
                    _rs.Open();
                    dgvLastProcessedMessages.DataSource = _rs.DataObject;

                }
                dgvLastProcessedMessages.CurrentCell = null;
                dgvLastProcessedMessages.Refresh();
                //if (dgvLastProcessedMessages.Rows.Count == 0) dgvLastProcessedMessages.Tag = "";


                lblLastProcessedMessages.Text = $"Last Processed Messages ({dgvLastProcessedMessages.Rows.Count})";
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        private string ColumnizeName(string text)
        {
            string _stage = "";

            try
            {
                //
                _stage = "Checkings";
                if (string.IsNullOrWhiteSpace(text))
                    return "";

                //
                _stage = "Creating string builder and adding fist character";
                StringBuilder _newText = new StringBuilder(text.Length * 2);
                _newText.Append(text[0]);

                //
                _stage = "Looping into characters";
                for (int i = 1; i < text.Length; i++)
                {
                    // 
                    _stage = "Inserting space to string";
                    if (char.IsUpper(text[i]) && text[i - 1] != ' ' && char.IsLower(text[i - 1]))
                        _newText.Append(' ');

                    //
                    _stage = $"Adding character {i}";
                    _newText.Append(text[i]);
                }
                return _newText.ToString();
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
                API.AcknowledgeLastMessageReceived(txtLastMessageID.Text);
            }
            catch (Exception ex)
            {
                throw new Exception($"[{this.GetType().Name}/{System.Reflection.MethodBase.GetCurrentMethod().Name}#{_stage}] {ex.Message}");
            }
        }

        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            SecondsCounter--;
            lblAutoRefreshCounter.Text = $"An autorefresh will be executed in {SecondsCounter} seconds";
            if (SecondsCounter == 0)
            {
                SecondsCounter = REFRESH_INTERVAL;
                btnConnect_Click(sender, e);
            }
            
        }

    }
    public static class Values
    {
        public static cAccesoDatosNet gDatos = new cAccesoDatosNet();
        public static string LabelPrinterAddress = "";
        public static string COD3 = "NIT";
        public static string ProjectName = "Web API Communications";
    }

}
