using System;
using System.Windows.Forms;
using AccesoDatosNet;
using CommonTools;
using System.Data.SqlClient;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using EspackFormControlsNS;
using PowerShellControl;
using static Sistemas.Values;
using static CommonToolsWin.CTWin;
using Renci.SshNet;

namespace Sistemas
{
    public partial class fUsers : Form
    {
        private string _prevStatus;
        public fUsers()
        {
            InitializeComponent();

            //CTLM definitions
            //Who
            CTLM.Conn = gDatos;
            CTLM.sSPAdd = "pAddUsers";
            CTLM.sSPUpp = "pUppUsers";
            CTLM.sSPDel = "";
            CTLM.AddItem(txtUserCode, "UserCode", true, true, false, 1, true, true);
            CTLM.AddItem(txtName, "Name", true, true, false, 0, false, true);
            CTLM.AddItem(txtSurname1, "Surname1", true, true, false, 0, false, true);
            CTLM.AddItem(txtSurname2, "Surname2", true, true, false, 0, false, true);
            CTLM.AddItem(txtUserNumber, "UserNumber", false, true, false, 0, false, true);
            //Where
            CTLM.AddItem(cboCOD3, "MainCOD3", true, true, false, 1, false, true);
            CTLM.AddItem(txtDesCod3, "desCOD3", CTLMControlTypes.NoSearch);
            CTLM.AddItem(listCOD3, "COD3", true, true, false, 1, false, true);
            CTLM.AddItem(cboPosition, "Position", true, true, false, 1, false, true);
            CTLM.AddItem(cboPositionLevel, "PositionLevel", false, true, false, 0, false, true);
            CTLM.AddItem(cboSecurityLevel, "SecurityLevel", true, true, false, 0, false, true);
            CTLM.AddItem(cboArea, "area", true, true, false, 0, false, true);
            //Systems
            CTLM.AddItem(txtPWD, "Password", false, true, false, 0, false, false);
            CTLM.AddItem(txtPasswordEXP, "PasswordEXP", false, true, false, 0, false, false);
            CTLM.AddItem(txtPIN, "PIN", false, true, false, 0, false, false);
            CTLM.AddItem(cboDomain, "domain", true, false, false, 0, false, true);
            CTLM.AddItem(txtEmail, "emailAddress", false, false, false, 0, false, true);
            CTLM.AddItem(txtQuota, "EmailQuota", false, true, false, 0, false, false);
            CTLM.AddItem(lstFlags, "Flags", true, true, false, 0, false, true);
            CTLM.AddItem(txtTicket, "Ticket", CTLMControlTypes.NoSearch);
            CTLM.AddItem(txtTicketExp, "TicketExp", CTLMControlTypes.NoSearch);
            CTLM.AddItem(lstEmailAliases, "Aliases", true, true, false, 0, false, false, pSPAddParamName: "alias", pSPUppParamName: "alias");
            CTLM.AddDefaultStatusStrip();
            CTLM.DBTable = string.Format("(Select * from vUsers where isnull(PositionLevel,50)>={0}) B", SecurityLevel);
            CTLM.ReQuery = true;
            cboCOD3.Source("select n.COD3,g.Descripcion from NetworkSedes n inner join general..sedes g on g.cod3=n.COD3 order by n.Cod3", txtDesCod3);
            listCOD3.Source("select n.COD3,g.Descripcion from NetworkSedes n inner join general..sedes g on g.cod3=n.COD3 order by n.Cod3");
            listCOD3.ValueChanged += ListCOD3_Changed;
            cboDomain.Source("Select domain from domain where domain<>'ALL' order by domain");
            cboPosition.Source(string.Format("select PositionCode,PositionDescription from MasterUserPositions where MinSecurityLevel>={0} order by MinSecurityLevel", SecurityLevel), txtPosition);
            cboPositionLevel.Source(string.Format("select SecurityLevel from MasterSecurityLevels where SecurityLevel>={0} order by SecurityLevel", SecurityLevel));
            cboSecurityLevel.Source(string.Format("select SecurityLevel from MasterSecurityLevels where SecurityLevel>={0} order by SecurityLevel", SecurityLevel));
            cboArea.Source(string.Format("select idArea from MasterAreas order by idArea", SecurityLevel));
            lstFlags.Source("Select codigo,DescFlagEng from flags where Tabla='Users'");
            CTLM.AfterButtonClick += CTLM_AfterButtonClick;
            CTLM.Start();
            _prevStatus = listCOD3.Text;
            cboCOD3.ComboBox.SelectedValueChanged += delegate
            {
                if (cboCOD3.SelectedValue != null && (CTLM.Status == EnumStatus.EDIT || CTLM.Status == EnumStatus.ADDNEW))
                    listCOD3.CheckItem(cboCOD3.Text);
            };

            listCOD3.CheckedListBox.ItemCheck += delegate (object sender, ItemCheckEventArgs e)
            {
                if ((e.NewValue == CheckState.Unchecked) && (listCOD3.keyItem(e.Index) == cboCOD3.Text) && (CTLM.Status == EnumStatus.EDIT || CTLM.Status == EnumStatus.ADDNEW))
                {
                    MessageBox.Show("Cannot remove Main COD3 from COD3 list", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.NewValue = CheckState.Checked;
                    return;
                }
                if (CTLM.Status == EnumStatus.EDIT)
                    lstEmailAliases.UpdateEspackControl();
            };
            txtSurname1.Validating += TxtSurname1_Validating;

            //this.FormClosed += FUsers_FormClosed;
        }

        private bool changeAliases = false;
        private void ListCOD3_Changed(object sender, ValueChangedEventArgs e)
        {
            if (e.NewValue.ToString() != "")
            {
                changeAliases = true;
            }
        }


        private void TxtSurname1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            {
                //if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
                if (CTLM.Status == EnumStatus.ADDNEW)
                {
                    if (txtUserCode.Text == "" && txtSurname1.Text != "")
                    {
                        var _possible = CT.ToASCII(txtName.Text.Substring(0, 1) + txtSurname1.Text).ToLower();
                        gDatos.AdoCon.Open();
                        SqlCommand query = new SqlCommand("SELECT 0 from Users where UserCode=@UserCode; ", gDatos.AdoCon);
                        query.Parameters.AddWithValue("@UserCode", "");
                        for (var i = 2; i < 100; i++)
                        {
                            query.Parameters["@UserCode"].Value = _possible;
                            var reader = query.ExecuteReader();
                            if (!reader.HasRows)
                                break;
                            _possible = _possible + i.ToString();
                            reader.Close();
                        }
                        gDatos.AdoCon.Close();
                        txtUserCode.Text = _possible;
                    }
                }
            };
        }

        private void CTLM_AfterButtonClick(object sender, CTLMEventArgs e)
        {
            Application.DoEvents();
            if (lstFlags.Text.Split('|').Contains("EMAIL"))
            {
                if (changeAliases)
                {
                    lstEmailAliases.Source("select Address,a2=Address from mail..aliasCAB a where exists( select 0 from dbo.Split(a.COD3,'|') where valor in (select valor from dbo.Split('" + listCOD3.Value + "','|'))) and dbo.CheckFlag(a.flags,'STATIC')=0 order by address");
                    lstEmailAliases.UpdateEspackControl();
                    Application.DoEvents();
                    changeAliases = false;
                }
            }
            else
            {
                lstEmailAliases.DataSource = null;
                changeAliases = true;
            }
            btnMigrateToExchange.Enabled = false;
            lblStatus.Text = "";
            if (lstFlags.CheckedValues.Contains("EMAIL"))
                if (lstFlags.CheckedValues.Contains("EXCHANGE"))
                    lblStatus.Text = "MIGRATED";
                else if (lstFlags.CheckedValues.Contains("MIGRATING"))
                {
                    using (var client = new SshClient("proxy.val.local", Values.DefaultUserForServers, Values.DefaultPasswordForServers))
                    {
                        client.Connect();
                        var sshCommand = string.Format("pgrep -f imapsync.*{0}", txtUserCode.Text);
                        var result = client.RunCommand(sshCommand);
                        if (result.Result != "")
                        {
                            lblStatus.Text = "MIGRATION CURRENTLY RUNNING.";
                        }
                        else
                        {
                            lblStatus.Text = "MIGRATION PROCESS FINISHED, CHECK LOGS.";
                        }
                    }
                    btnMigrateToExchange.Enabled = true;
                }
                else
                {
                    btnMigrateToExchange.Enabled = true;
                }

        }

        private async void btnMigrateToExchange_Click(object sender, EventArgs e)
        {
            var _listFlags = lstFlags.Text.Split('|');
            if (_listFlags.Contains("EXCHANGE"))
            {
                MsgError("This account is already in Exchange.");
                return;

            }
            if (_listFlags.Contains("MIGRATING"))
            {
                using (var client = new SshClient("proxy.val.local", Values.DefaultUserForServers, Values.DefaultPasswordForServers))
                {
                    client.Connect();
                    var sshCommand = string.Format("pgrep -f imapsync.*{0}", txtUserCode.Text);
                    var result = client.RunCommand(sshCommand);
                    if (result.Result != "")
                    {
                        MsgError("Migration has not yet finished for this user.");
                        return;
                    }
                    if (MessageBox.Show("The process has finished, do you want to see the log file?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (var scpClient = new ScpClient("proxy.val.local", Values.DefaultUserForServers, Values.DefaultPasswordForServers))
                        {
                            scpClient.Connect();
                            scpClient.Download(string.Format("/root/{0}.log", txtUserCode.Text), new DirectoryInfo(Path.GetTempPath()));
                            System.Diagnostics.Process.Start("notepad.exe", string.Format("{0}{1}.log", Path.GetTempPath(), txtUserCode.Text));
                        }
                        if (MessageBox.Show("Do you want to finish the migration process?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            await changeUserFlag("EXCHANGE");
                            MsgError(string.Format("Don't forget to setup forward from horde to {0}@systems.espackeuro.com.",txtUserCode.Text));
                            return;
                        }
                    }
                    else return;
                    if (MessageBox.Show("Do you want to relaunch the sync process?", "", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;


                }
            }
            await changeUserFlag("MIGRATING");
            AD.EC.ServerName = "EXCHANGE01";
            AD.EC.UserName = @"SYSTEMS\administrador";
            AD.EC.Password = "Y?D6d#b@";
            var command = new PowerShellCommand();
            command.EC = AD.EC;
            var c = string.Format(@"if (![bool](Get-Mailbox -Identity '{0}')) {{Enable-Mailbox -Identity '{0}';}}", txtUserCode.Text);
            command.Command = c;
            var res = await command.InvokeAsyncExchange();
            var Results = command.SResults;
            // now the sync
            using (var client = new SshClient("proxy.val.local", Values.DefaultUserForServers, Values.DefaultPasswordForServers))
            {
                client.Connect();
                var sshCommand = string.Format("pgrep -f imapsync.*{0}", txtUserCode.Text);
                var result = client.RunCommand(sshCommand);
                if (result.Result != "")
                {
                    MsgError("There is a running sync process for this user, aborting.");
                    return;
                }
                //var sshCommand = string.Format(@"sshpass -p {3} ssh -o StrictHostKeyChecking=no {2}@proxy.val.local ""nohup imapsync --host1 mail.espackeuro.com --port1 993 --ssl1 --user1 {0}@espackeuro.com --password1 {1} --host2 exchange01.systems.espackeuro.com --port2 143 --user2 {0} --password2 {1} --exchange2 --exclude '(?i)\b(Junk|Spam|Trash|Deleted\ Items)\b' --errorsmax 1000 & """, txtUserCode.Text, txtPWD.Text, Values.DefaultUserForServers, Values.DefaultPasswordForServers);
                sshCommand = string.Format(@"imapsync --host1 mail.espackeuro.com --port1 993 --ssl1 --user1 {0}@espackeuro.com --password1 {1} --host2 exchange01.systems.espackeuro.com --port2 143 --user2 {0} --password2 {1} --exchange2 --exclude '(?i)\b(Junk|Spam|Trash|Deleted\ Items)\b' --errorsmax 1000 > {0}.log 2>&1 & ", txtUserCode.Text, txtPWD.Text);
                result = client.RunCommand(sshCommand);

                //var result = client.RunCommand(string.Format("/root/imapsync.sh {0} {1}", txtUserCode.Text, txtPWD.Text));
                client.Disconnect();
            }
        }



        private async Task<bool> changeUserFlag(string flag)
        {
            using (SP sp = new SP(gDatos, "pUppUserFlags"))
            {
                List<string> _flags = lstFlags.Text.Split('|').ToList<string>();
                if (!_flags.Contains(flag))
                {
                    _flags.Add(flag);
                    var _stringFlags = string.Join("|", _flags);
                    sp.AddParameterValue("flags", _stringFlags);
                    sp.AddParameterValue("UserCode", txtUserCode.Text);
                    try
                    {
                        await sp.ExecuteAsync();
                    }
                    catch (Exception ex)
                    {
                        MsgError(ex.Message);
                        return false;
                    }
                    if (sp.LastMsg != "OK")
                    {
                        MsgError(sp.LastMsg);
                        return false;
                    }
                    lstFlags.Value = _stringFlags;
                }
                return true;
            }
        }
    }
}
