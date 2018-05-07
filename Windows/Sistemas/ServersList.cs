using System;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatosNet;
using System.Collections.Generic;

namespace Sistemas
{
    public partial class ServersList : UserControl
    {
        
        public List<ServerCheckWithInfo> ListServers { get; set; }
        private bool IsExecuting { get; set; }
        public string Command { get; set; }
        public object CallingButton { get; set; }

        public ServersList()
        {
            InitializeComponent();
            txtCheckoutUser.Upp = true;
            txtCheckoutUser.ReadOnly = false;
            txtCheckoutPwd.Upp = true;
            txtCheckoutPwd.ReadOnly = false;
            chkSelectAll.CheckedChanged += ChkSelectAll_CheckedChanged;
        }

        private void ChkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            ListServers.ForEach(f => f.CheckBox.Checked = ((CheckBox)sender).Checked);
        }

        public void Start(string pServerType, string pCommand, object pCallingButton)
        {
            ListServers = new List<ServerCheckWithInfo>();
            using (var rs = new StaticRS(string.Format("Select {0}, COD3 from NetworkSedes where dbo.CheckFlag(flags, 'ACTIVE') = 1 AND dbo.CheckFlag(flags, 'CHECKOUT') = 1", pServerType), Values.gDatos))
            {
                rs.Open();
                Point location = new Point() { X = 10, Y = 30 + chkSelectAll.Height };
                rs.Rows.ForEach((r) =>
                {
                    //checkbox
                    var cs = new CheckBox()
                    {
                        Text = r[pServerType].ToString()
                    };
                    cs.Width = (int)(cs.Width * 0.9);
                    grpServers.Controls.Add(cs);
                    cs.Location = location;
                    //label
                    var ls = new Label()
                    {
                        Text = string.Format("Server for {0}", r["COD3"])
                    };
                    grpServers.Controls.Add(ls);
                    ls.Location = new Point() { X = location.X + cs.Width + 5, Y = location.Y + 3 };
                    ls.Width = grpServers.Width - cs.Width - 25;
                    location.Y = location.Y + cs.Height;
                    //Server element
                    var se = new ServerCheckWithInfo()
                    {
                        CheckBox = cs,
                        Label = ls,
                        Info = new ServerInfo() { COD3= r["COD3"].ToString(), ServerName = r[pServerType].ToString(), FileName = "", FileContent = "" }
                    };

                    ListServers.Add(se);
                });
            }
            Command = pCommand;
            CallingButton = pCallingButton;
        }
        public async Task ExecuteCommandInServers()
        {
            if (IsExecuting)
                return;
            if (txtCheckoutUser.Text == "" || txtCheckoutPwd.Text == "")
            {
                MessageBox.Show("Wrong User or password!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsExecuting = true;
            Image OldImage;
            if (CallingButton is ToolStripButton)
            {
                OldImage = ((ToolStripButton)CallingButton).Image;
                ((ToolStripButton)CallingButton).Image = global::Sistemas.Properties.Resources.rolling;
            }
            else if (CallingButton is Button)
            {
                OldImage = ((Button)CallingButton).Image;
                ((Button)CallingButton).Image = global::Sistemas.Properties.Resources.rolling;
            }
            else
            {
                MessageBox.Show("Not Implemented!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var serverList = ListServers.Where(w => w.CheckBox.Checked == true).Select(s => s.Info).ToList<ServerInfo>();
            //clean all server messages.
            ListServers.ForEach(f =>
            {
                f.Label.Text = "--";
                LabelStyle(f.Label, LabelStyles.NORMAL);
            });
            //create the task
            var ServerTask = new ServerCommand(serverList, txtCheckoutUser.Text, txtCheckoutPwd.Text, Command);
            ServerTask.Callback += ServerTask_Callback; ;
            ServerTask.ErrorCallback += ServerTask_ErrorCallback; ;
            //launch and wait
            await ServerTask.Start();
            if (CallingButton is ToolStripButton)
            {
                ((ToolStripButton)CallingButton).Image = OldImage;
            }
            else if (CallingButton is Button)
            {
                ((Button)CallingButton).Image = OldImage;
            }
            else
            {
                MessageBox.Show("Not Implemented!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("All tasks finished!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            IsExecuting = false;

        }

        private void ServerTask_ErrorCallback(object sender, AsyncTaskResponse e)
        {
            if (e.ServerName != "")
            {
                var elLabel = ListServers.First(s => s.CheckBox.Text == e.ServerName).Label;
                LabelStyle(elLabel, LabelStyles.ERROR);
                elLabel.Text = e.Message;
            }
            else
            {
                MessageBox.Show(e.Message + Environment.NewLine,
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                ListServers.ToList().ForEach(f =>
                {
                    f.Label.Text = "--";
                    LabelStyle(f.Label, LabelStyles.NORMAL);
                });
            }
        }

        private void ServerTask_Callback(object sender, AsyncTaskResponse e)
        {
            if (e.ServerName != "")
            {
                var elLabel = ListServers.First(s => s.CheckBox.Text == e.ServerName).Label;
                LabelStyle(elLabel, LabelStyles.NORMAL);
                elLabel.Text = e.Message;
                if (e.Message == "Command completed.")
                    ListServers.First(s => s.CheckBox.Text == e.ServerName).CheckBox.Checked = false;
            }
            else
            {
                MessageBox.Show("Info: " + e.Message + Environment.NewLine,
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                ListServers.ToList().ForEach(f =>
                {
                    f.Label.Text = "--";
                    LabelStyle(f.Label, LabelStyles.NORMAL);
                });
            }
        }

        private enum LabelStyles { NORMAL, ERROR };
        private void LabelStyle(Label pLabel, LabelStyles pStyle)
        {
            switch (pStyle)
            {
                case LabelStyles.ERROR:
                    {
                        pLabel.BackColor = Color.Red;
                        pLabel.ForeColor = Color.White;
                        pLabel.Font = new Font(pLabel.Font, FontStyle.Bold);
                        break;
                    }
                case LabelStyles.NORMAL:
                    {
                        pLabel.BackColor = Color.Transparent;
                        pLabel.ForeColor = Color.Black;
                        pLabel.Font = new Font(pLabel.Font, FontStyle.Regular);
                        break;
                    }
            }
        }

    }

}
