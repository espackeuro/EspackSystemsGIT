﻿using AccesoDatosNet;
using CommonTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EspackControls;
using EspackFormControlsNS;
using System.IO;
using System.Net;
using System.Threading;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using LogOnObjects;
using static LogOnObjects.Values;
using System.Reflection;
using DiverseControls;
using CommonToolsWin;
using MasterClass;
using System.Xml.Linq;

namespace LogOn
{


    public partial class fMain : Form
    {
        
        // Definitions for dynamically create the toolbar and accessing its panels
        public StatusStrip mDefaultStatusStrip;
        public ToolStripStatusLabel Panel1;
        public ToolStripStatusLabel Panel2;
        public ToolStripStatusLabel Panel3;
        public ToolStripStatusLabel Panel4;
        public ToolStripStatusLabel PanelName;
        public ScrollingStatusLabel PanelQOTD;
        public ToolStripStatusLabel PanelTime;
        private System.Timers.Timer _timer;
        private int _time;
        private bool _update;
        private bool noXML;

        //public List<cUpdaterThread> UpdatingThreads = new List<cUpdaterThread>();
        //public static int NUMTHREADS = 10;
        public const int MAXTIMER = 300;
        delegate void gbDebugCallBack(Control c);
        delegate void LogOnChangeStatusCallBack(LogOnStatus l);
        delegate void ClearListAppsCallBack();
        delegate void DrawListAppsCallback();

        private LogOnStatus previousStatus { get; set; }


        private void LogOnChangeStatus(LogOnStatus pStatus)
        {
            if (this.InvokeRequired)
            {
                LogOnChangeStatusCallBack a = new LogOnChangeStatusCallBack(LogOnChangeStatus);
                this.Invoke(a, new object[] { pStatus });
            }
            else
            {
                Status=pStatus;
            }
        }

        private bool IsEspackIP(ref string COD3)
        {
            //#if DEBUG
            //            COD3 = "OUT";
            //            return false;
            //#else
            int _zone;
            var _IP = Values.gDatos.IP.GetAddressBytes();
            if (_IP[0] == 10)
                _zone = _IP[1];
            else
                _zone = _IP[2];
            using (var _RS = new StaticRS(string.Format("Select COD3 from GENERAL..Sedes where zone='{0}'", _zone), Values.gDatos))
            {
                _RS.Open();
                if (_RS.RecordCount == 0)
                {
                    COD3 = "OUT";
                    return false;
                }
                COD3 = _RS["COD3"].ToString();
            }
            return true;
//#endif
        } 
        // Main
        public fMain(string[] args)
        {
            //MessageBox.Show("Pollo1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (args.Contains("/ext=1"))
                External = true;
              noXML = args.Contains("/noxml=1");
//#if DEBUG
//            noXML = true;
//#endif 
            try
            {
                InitializeComponent();
                txtUser.SetStatus(EnumStatus.EDIT);
                txtPassword.SetStatus(EnumStatus.EDIT);
                txtNewPassword.SetStatus(EnumStatus.EDIT);
                txtNewPasswordConfirm.SetStatus(EnumStatus.EDIT);
                txtNewPIN.SetStatus(EnumStatus.EDIT);
                txtNewPINConfirm.SetStatus(EnumStatus.EDIT);
                ServicePointManager.DnsRefreshTimeout = 0;
                this.Text = string.Format("LogOn Build {0} - ({1:yyyyMMdd})*", Assembly.GetExecutingAssembly().GetName().Version.ToString(), CT.GetBuildDateTime(Assembly.GetExecutingAssembly()));
                // Customize the textbox controls 
                txtUser.Multiline = false;
                txtPassword.Multiline = false;
                txtNewPassword.Multiline = false;
                txtNewPasswordConfirm.Multiline = false;
                txtNewPIN.Multiline = false;
                txtNewPINConfirm.Multiline = false;
                btnOk.Enabled = false;
                //timer control
                _time = 0;
                _timer = new System.Timers.Timer() { Interval = 1000, Enabled = false };
                _timer.Elapsed += _timer_Elapsed;

                // Add the toolbar and set the panels texts
                AddDefaultStatusStrip();

                LogOnChangeStatus(LogOnStatus.INIT);

#if DEBUG
                chkDebug.Checked = true;
                txtUser.Text = "dvalles";
                txtPassword.Text = "*Kru0DMar*";
#endif
                //MessageBox.Show("Pollo2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            } catch (Exception ex)
            {
                
                throw new Exception(string.Format("Error 1 {0}", ex.Message));
            }


            string _dbserver = "";
            string _shareserver = "";
            string _cod3 = "";
            if (External)
                CTWin.InputBox("", "Enter database server.", ref _dbserver);
            else
                try
                {
                    try
                    {
                        var _dnsDB = Dns.GetHostEntry("appdb.local");
                        _dbserver = _dnsDB.AddressList[0].ToString(); //.HostName;
                        var _dnsShare = Dns.GetHostEntry("appshare.local");
                        _shareserver = _dnsShare.AddressList[0].ToString();
                    }
                    catch
                    {
                        CTWin.InputBox("", "Enter database server.", ref _dbserver);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Error 2 {0}", ex.Message));
                }
            //MessageBox.Show("Pollo4", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            string[] FilesToUpdate= new string[] { };
            try
            {
                Values.gDatos.DataBase = "SISTEMAS";
                Values.gDatos.Server = _dbserver;
                Values.gDatos.User = "procesos";
                Values.gDatos.Password = "*seso69*";
#if DEBUG
                /*_dbserver = "db02.cr2.local";
                _shareserver = "net01.cr2.local";
                Values.gDatos.Server = _dbserver;
                Values.gDatos.User = "sa";
                Values.gDatos.Password = "5380";*/
#endif
                // Connect (or try)
                try
                {
                    //MessageBox.Show("Pollo4.1 "+ Values.gDatos.Server, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Values.gDatos.Connect();
                    Values.gDatos.Close();
                    //MessageBox.Show("Pollo4.2", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception e)
                {
                    //MessageBox.Show("Pollo4.3"+e.Message+e.InnerException, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new Exception("Error connecting database server: " + e.Message);
                }
                // tries to check if we are inside of Espack
                // only updates if in Espack

                _update = IsEspackIP(ref _cod3) && !External;
                if (!_update)
                {
                    MessageBox.Show("This location does not allow application updates.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    _cod3 = "OUT";
                }

                if (_update)
                    FilesToUpdate = new string[] { "logonloader.exe", "logonloader.exe.config" };

                Values.FillServers(_cod3);
                
                //this.Load += FMain_Load;
                //if we are out, we add the server we just entered
                if (_cod3=="OUT")
                    Values.DBServerList.Add(new cServer() { HostName = _dbserver, COD3 = "OUT", Type = ServerTypes.DATABASE, User = Values.User, Password = Values.Password });

                Panel1.Text = "You are connected to " + Values.gDatos.oServer.IP;//HostName.Replace(".local", "") + "!";
                Panel2.Text = "My IP: " + Values.gDatos.IP.ToString();
                Panel3.Text = "DB Server IP: " + Values.gDatos.Server;
                if (_update)
                    Panel4.Text = "Share Server IP: " + Values.ShareServerList[Values.COD3].IP;
                //MessageBox.Show("Pollo5", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (_update)
                    FilesToUpdate = FilesToUpdate.Concat(System.IO.Directory.GetFiles("lib").Select(x => x.Replace("\\", "/")).Where(x => Path.GetExtension(x) == ".dll")).ToArray();
                if (!Directory.Exists(Values.LOCAL_PATH + "/lib"))
                    Directory.CreateDirectory(Values.LOCAL_PATH + "/lib");
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error 3 {0}", ex.Message));
            }
            try
            {
                // Check LogOnLoader update
                //#if !DEBUG
                if (_update)
                {
                    FilesToUpdate.ToList().ForEach(x =>
                    {
                        x = x.Replace("\\", "/");
                        if (File.Exists(Values.LOCAL_PATH + x))
                        {
                            if (!File.Exists(Values.LOCAL_PATH + "logon/" + x))
                            {
                                File.Delete(Values.LOCAL_PATH + x);
                            }
                            else if (File.GetLastWriteTime(Values.LOCAL_PATH + x) != File.GetLastWriteTime(Values.LOCAL_PATH + "logon/" + x))
                            {
                                File.Delete(Values.LOCAL_PATH + x);
                                File.Copy(Values.LOCAL_PATH + "logon/" + x, Values.LOCAL_PATH + x);
                            }
                        }
                        else
                        {
                            if (File.Exists(Values.LOCAL_PATH + "logon/" + x))
                                File.Copy(Values.LOCAL_PATH + "logon/" + x, Values.LOCAL_PATH + x);
                        }
                    });
                }



                // MessageBox.Show("Pollo6", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //#endif

                KeyPress += FMain_KeyPress;
                MouseClick += FMain_MouseClick; ;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Pollo7: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception(string.Format("Error 3 {0}", ex.Message));
            }
            //check Autologon with windows credentials
            var _enviromentUser = Environment.UserName;
#if !DEBUG
            using (var _rs = new StaticRS(string.Format("Select flags,Password from vUsers where UserCode='{0}'", _enviromentUser), Values.gDatos))
            {
                Values.gDatos.context_info = MasterPassword.MasterBytes;
                _rs.Open();
                if (!_rs.EOF)
                {
                    var _flags = _rs["flags"].ToString().Split('|');
                    if (_flags.Contains("AUTOLOGON"))
                    {
                        this.Show();
                        this.txtUser.Text = _enviromentUser;
                        this.txtPassword.Text = _rs["Password"].ToString();
                        btnOk_Click(null, null);
                    }
                }

            };
#endif
         
        }




        private void FMain_MouseClick(object sender, MouseEventArgs e)
        {
            restartTimer();
        }

        private void FMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            restartTimer();
            // ENTER Key
            if (e.KeyChar == (char)13) 
            {
                e.Handled = true;
                // Focus on Password Textbox -> Press OK button
                if (txtPassword.ContainsFocus)
                {

                    btnOk.PerformClick();
                }
                // Focus on PINConfirm Textbox -> Press OKChange button
                else if (txtNewPINConfirm.ContainsFocus)
                {
                    btnOKChange.PerformClick();
                }
                // Focus on any other control in gbCred or gbChangePassword -> Send TAB Key
                else if (gbCred.ContainsFocus || gbChangePassword.ContainsFocus)
                {
                    SendKeys.Send("{tab}");
                }
                // Any other case -> Do base OnKeyDown
            }

            // ESC Key
            if (e.KeyChar == (char)27)
            {
                e.Handled = true;
                // Focus on gbCred controls (when not connected) -> Clean the credentials fields (done in LogOnStatus.INIT)
                if (Status == LogOnStatus.INIT && gbCred.ContainsFocus)
                    LogOnChangeStatus(LogOnStatus.INIT);
                // Focus on gbChangePassword controls -> Cancel the ChangePassword status
                else if (gbChangePassword.ContainsFocus)
                    LogOnChangeStatus(LogOnStatus.CONNECTED);
            }
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _time--;
            if (_time == 0)
            {
                Application.Exit();
                //LogOnChangeStatus(LogOnStatus.INIT);
                return;
            }
            var t = TimeSpan.FromSeconds(_time);
            try
            {
                PanelTime.Text = t.ToString(@"mm\:ss");
            } catch { }
        }

        protected override void OnResize (EventArgs e)
        {
            base.OnResize(e);
            if (this.WindowState!= FormWindowState.Minimized)
            {
                var _numApps = Values.AppList.Count;
                if (_numApps == 0)
                    return;
                int _numColumns = gbApps.Width / cAppBot.GROUP_WIDTH;
                tlpApps.AutoScroll = false;
                tlpApps.ColumnCount = _numColumns;
                tlpApps.RowCount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(_numApps) / Convert.ToDouble(_numColumns)));
                tlpApps.AutoScroll = true;
            }
        }

        // Add the toolbar dynamically: we did not find the way to add separators in design time.
        public void AddDefaultStatusStrip()
        {
            mDefaultStatusStrip = new StatusStrip();
            //SizeType lSize = new SizeType(118, 17);
            Panel1 = new ToolStripStatusLabel("Disconnected") { AutoSize = true };
            mDefaultStatusStrip.Items.Add(Panel1);
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());

            Panel2 = new ToolStripStatusLabel("My IP: None") { AutoSize = true };
            mDefaultStatusStrip.Items.Add(Panel2);
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());

            Panel3 = new ToolStripStatusLabel("DB Server IP: None") { AutoSize = true };
            mDefaultStatusStrip.Items.Add(Panel3);
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());

            Panel4 = new ToolStripStatusLabel("Share Server IP: None") { AutoSize = true };
            mDefaultStatusStrip.Items.Add(Panel4);
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());

            PanelName = new ToolStripStatusLabel("") { AutoSize = true };
            mDefaultStatusStrip.Items.Add(PanelName);
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());

            PanelQOTD = new ScrollingStatusLabel("") {AutoSize=false, Width=350 , Interval=150};
            mDefaultStatusStrip.Items.Add(PanelQOTD);
            mDefaultStatusStrip.Items.Add(new ToolStripSeparator());

            PanelTime = new ToolStripStatusLabel("") { AutoSize = false, Width = 100 };
            mDefaultStatusStrip.Items.Add(PanelTime);
            //mDefaultStatusStrip.Items.Add(new ToolStripSeparator());

            Controls.Add(mDefaultStatusStrip);
            KeyPreview = true;
        }

        public enum LogOnStatus { INIT, CONNECTING, CONNECTED, CHANGE_PASSWORD, CHANGING_PASSWORD, ERROR }
        private LogOnStatus _status;

        public LogOnStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                switch (value)
                {
                    case LogOnStatus.INIT:
                        _time = MAXTIMER;
                        txtUser.Text = "";
                        txtPassword.Text = "";
                        txtUser.Enabled = true;
                        txtPassword.Enabled = true;
                        btnOk.Text= "Connect";
                        btnOk.Enabled = true;
                        btnChange.Visible = false;
                        txtNewPassword.Visible = false;
                        txtNewPasswordConfirm.Visible = false;
                        txtNewPIN.Visible = false;
                        txtNewPINConfirm.Visible = false;
                        btnOKChange.Visible = false;
                        btnCancelChange.Visible = false;
                        ActiveControl = txtUser;
                        _timer.Stop();
                        ClearListApps();
                        PanelName.Text = "";
                        PanelQOTD.Text = "";
                        PanelTime.Text = "";
                        chkDebug.Enabled = true;
                        break;
                    case LogOnStatus.CONNECTING:
                        txtUser.Enabled = false;
                        txtPassword.Enabled = false;
                        btnOk.Text = "Connecting";
                        btnOk.Enabled = false;
                        btnChange.Visible = false;
                        txtNewPassword.Visible = false;
                        txtNewPasswordConfirm.Visible = false;
                        txtNewPIN.Visible = false;
                        txtNewPINConfirm.Visible = false;
                        btnOKChange.Visible = false;
                        btnCancelChange.Visible = false;
                        chkDebug.Enabled = false;
                        break;
                    case LogOnStatus.CONNECTED:
                        txtUser.Enabled = false;
                        txtPassword.Enabled = false;
                        btnOk.Text = "Disconnect";
                        btnOk.Enabled = true;
                        btnChange.Visible = true;
                        txtNewPassword.Visible = false;
                        txtNewPasswordConfirm.Visible = false;
                        txtNewPIN.Visible = false;
                        txtNewPINConfirm.Visible = false;
                        btnOKChange.Visible = false;
                        btnCancelChange.Visible = false;
                        _timer.Start();
                        chkDebug.Enabled = false;
                        break;
                    case LogOnStatus.CHANGE_PASSWORD:
                        txtUser.Enabled = false;
                        txtPassword.Enabled = false;
                        btnOk.Text = "Disconnect";
                        btnOk.Enabled = false;
                        btnChange.Visible = false;
                        txtNewPassword.Visible = true;
                        txtNewPasswordConfirm.Visible = true;
                        txtNewPassword.Enabled = true;
                        txtNewPasswordConfirm.Enabled = true;
                        txtNewPIN.Visible = true;
                        txtNewPINConfirm.Visible = true;
                        txtNewPIN.Enabled = true;
                        txtNewPINConfirm.Enabled = true;
                        btnOKChange.Visible = true;
                        btnCancelChange.Visible = true;
                        btnOKChange.Enabled = true;
                        btnCancelChange.Enabled = true;
                        txtNewPassword.Text = "";
                        txtNewPasswordConfirm.Text = "";
                        txtNewPIN.Text = "";
                        txtNewPINConfirm.Text = "";
                        ActiveControl = txtNewPassword;
                        chkDebug.Enabled = false;
                        break;
                    case LogOnStatus.CHANGING_PASSWORD:
                        txtUser.Enabled = false;
                        txtPassword.Enabled = false;
                        btnOk.Text = "Disconnect";
                        btnOk.Enabled = false;
                        btnChange.Visible = false;
                        txtNewPassword.Visible = true;
                        txtNewPasswordConfirm.Visible = true;
                        txtNewPassword.Enabled = false;
                        txtNewPasswordConfirm.Enabled = false;
                        txtNewPIN.Visible = true;
                        txtNewPINConfirm.Visible = true;
                        txtNewPIN.Enabled = false;
                        txtNewPINConfirm.Enabled = false;
                        btnOKChange.Visible = true;
                        btnCancelChange.Visible = true;
                        btnOKChange.Enabled = false;
                        btnCancelChange.Enabled = false;
                        chkDebug.Enabled = false;
                        break;
                    case LogOnStatus.ERROR:
                        txtUser.Enabled = false;
                        txtPassword.Enabled = false;
                        btnOk.Text = "...";
                        btnOk.Enabled = false;
                        btnChange.Visible = false;
                        txtNewPassword.Visible = false;
                        txtNewPasswordConfirm.Visible = false;
                        txtNewPIN.Visible = false;
                        txtNewPINConfirm.Visible = false;
                        btnOKChange.Visible = false;
                        btnCancelChange.Visible = false;
                        chkDebug.Enabled = false;
                        break;
                }
                _status = value;
            }
        }

        private void gbDebugAdd(Control c)
        {
            if (gbDebug.InvokeRequired)
            {
                gbDebugCallBack a = new gbDebugCallBack(gbDebugAdd);
                Invoke(a, new object[] { c });
            } else
            {
                gbDebug.Controls.Add(c);
            }
        }

        private void FillApps()
        {

            using (var _RS = new DynamicRS("select Code=ServiceCode,Description,DB,ExeName=s.app,Zone=s.location,s.ServiceCode,s.version from general..Permiso_Servicios p inner join services s on s.ServiceCode=p.codigo where p.LoginSql= '" + Values.User + "' and general.dbo.checkFlag(flags,'OBS')=0", Values.gDatos))
            {
                _RS.Open();
                _RS.ToList()
                    //.Where(a => a["Code"].ToString()=="LOGISTICA").ToList()
                    .ForEach(x =>
                {
                    var _app = new cAppBot(x["Code"].ToString(), x["Description"].ToString(), x["DB"].ToString(), x["ExeName"].ToString(), x["Zone"].ToString(), Values.DBServerList[x["Zone"].ToString()], Values.ShareServerList[Values.COD3], x["ServiceCode"].ToString(),pVersion: x["version"].ToString());
                    _app.AfterLaunch += _app_AfterLaunch; ;
                    Values.AppList.Add(_app);
                });
            }
            Values.AppList.Add(new cAppBot("Tools", "TOOLS", "", "", "", null, Values.ShareServerList[Values.COD3], "",true));
            //Values.AppList.Add(new cAppBot("lib", "lib", "", "", "", null, Values.ShareServerList[Values.COD3], true));
        }

        private void _app_AfterLaunch(object sender, EventArgs e)
        {
            restartTimer();
        }

        private void restartTimer()
        {
            _time=MAXTIMER;
        }

        

        private void DrawListApps()
        {
            if (this.InvokeRequired)
            {
                DrawListAppsCallback a = new DrawListAppsCallback(DrawListApps);
                this.Invoke(a);
            }
            else
            {
                var _numApps = Values.AppList.Count;
                if (_numApps == 0)
                    return;
                tlpApps.ColumnStyles.Clear();
                tlpApps.RowStyles.Clear();
                tlpApps.RowStyles.Add(new RowStyle(SizeType.Absolute, cAppBot.GROUP_HEIGHT));
                int _numColumns = _numApps;
                tlpApps.ColumnCount = _numColumns;
                int x = 0;
                foreach (cAppBot _app in Values.AppList)
                {
                    tlpApps.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cAppBot.GROUP_WIDTH));

                    tlpApps.Controls.Add(_app, x, 0);
                    //bool _clean = await _app.CheckUpdate();
                    //bool _clean = _app.CheckUpdateSync();
                    //if (_clean)
                    //    _app.Activate();
                    x++;
                }
                tlpApps.AutoScroll = false;
                tlpApps.ColumnCount = gbApps.Width / cAppBot.GROUP_WIDTH;
                tlpApps.RowCount = Convert.ToInt16(Math.Ceiling(Convert.ToDouble(_numApps) / Convert.ToDouble(_numColumns)));
                tlpApps.AutoScroll = true;
                return;
            }
        }

        private void ClearListApps()
        {
            if (this.InvokeRequired)
            {
                ClearListAppsCallBack a = new ClearListAppsCallBack(ClearListApps);
                this.Invoke(a);
            }
            else
            {
                //Values.AppList.ToList().ForEach(x => x.Dispose());
                Values.AppList.Dispose();
                tlpApps.ColumnCount = 0;
                tlpApps.RowCount = 0;
            }
        }

        private async Task CheckUpdatableApps()
        {
            //return Task.Run(() =>
            //{
            //int _numThreads = 0;
            foreach (var x in Values.AppList.ToList())
            {
                x.SetStatus(AppBotStatus.CHECKING);
                Application.DoEvents();
                try
                {
                    if (x.CheckUpdatedXML())
                    {
                        x.Status = AppBotStatus.UPDATED;
                    }
                    else
                    {
                        x.Status = AppBotStatus.PENDING_UPDATE;
                    }
                    x.ShowStatus();
                } catch (Exception ex)
                {
                    if (debugBox != null)
                    {
                        debugBox.AppendText(string.Format("App {0} Error: {1}\n", x.Code, ex.Message));
                    }
                }
                /*
                _numThreads++;
                new Thread(async () =>
                {
                    //if (await x.CheckUpdated().ConfigureAwait(false))
                    //if (await x.CheckUpdated())
                    if (await x.CheckUpdatedXML())
                    {
                        _numThreads--;
                        x.Status = AppBotStatus.UPDATED;
                    }
                    else
                    {
                        _numThreads--;
                        x.Status = AppBotStatus.PENDING_UPDATE;
                    }
                    x.ShowStatus();
                }).Start();
                SpinWait.SpinUntil(() => _numThreads < Values.MaxNumThreads);
                */
            }
            await Task.Delay(100);
            SpinWait.SpinUntil(() => Values.AppList.CheckingApps.Count == 0);
            //});
            //await task.ConfigureAwait(false);
        }
        private async void btnOk_Click(object sender, EventArgs e)
        {
//#if DEBUG
//            noXML = true;
//#endif
            if (noXML)
                XMLSystemState = XDocument.Load(LOCAL_PATH + "systems.xml");
            else
                await Values.getSystemVersions(ShareServerList[Values.COD3]);
            previousStatus = Status;
            if (Status == LogOnStatus.INIT)
            {
                LogOnChangeStatus(LogOnStatus.CONNECTING);
                SqlParameter _flags;
                SqlParameter _fullName;
                var _SP = new SP(Values.gDatos, "pLogOnUser");
                _SP.AddControlParameter("User", txtUser);
                _SP.AddControlParameter("Password", txtPassword);
                _SP.AddParameterValue("Origin", "LOGON_CS");
                _SP.AssignOutputParameterContainer("flags",out _flags);
                _SP.AssignOutputParameterContainer("FullName", out _fullName);
                try
                {
                    _SP.Execute();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Text = "";
                    Status = LogOnStatus.INIT;
                    return;
                }
                //txtUser.Text = _SP.ReturnValues()["User"].ToString();
                Values.userFlags = _flags.Value.ToString().Split('|').Where(x => x!="").ToList() ;
                Values.FullName = _fullName.Value.ToString();
                PanelName.Text = Values.FullName;
                Values.DBServerList.ServerList.ForEach(x => { x.User = txtUser.Text; x.Password = txtPassword.Text; }) ;
                var _SPQuote = new SP(Values.gDatos, "pGetQOTD");
                SqlParameter _quote;
                _SPQuote.AssignOutputParameterContainer("quote", out _quote);
                try
                {
                    _SPQuote.Execute();
                    PanelQOTD.Text = _quote.Value.ToString();
                }
                catch 
                {
                    PanelQOTD.Text = "";
                }
                
                if (_SP.LastMsg == "OK/CHANGE")
                {
                    this.Status = LogOnStatus.CHANGE_PASSWORD;
                    CTWin.MsgError("Your password has expired, please change it.");
                    return;
                }
                Values.User = txtUser.Text;
                Values.Password = _SP.ReturnValues()["@Password"].ToString();// txtPassword.Text;
                FillApps();
                DrawListApps();
                if (_update)
                    await CheckUpdatableApps();
                else
                    Values.AppList.ToList().ForEach(x => x.SetStatus(AppBotStatus.UPDATED));
                Values.AppList.ToList().ForEach(x => x.ShowStatus());
                //while (Values.AppList.CheckingApps.Count != 0)
                //{
                //    System.Threading.Thread.Sleep(500);
                //}
                /*
                if (Values.AppList.PendingApps.Count != 0)
                {
                    //var maxThreads = Values.AppList.PendingApps.Count > Values.MaxNumThreads ? Values.MaxNumThreads : Values.AppList.PendingApps.Count;
                    var maxThreads = Values.UpdateList.PendingCount > Values.MaxNumThreads ? Values.MaxNumThreads : Values.UpdateList.PendingCount;
                    for (var i = 0; i < maxThreads; i++)
                    {
                        Values.ActiveThreads++;
                        var _thread = new cUpdaterThread(Values.debugBox, Values.ActiveThreads);
                        this.UpdatingThreads.Add(_thread);
                        new Thread(async () => await _thread.Process()).Start();
                        await Task.Delay(200);
                    }
                }
                */
                var UpdaterTask = new Updater(Values.UpdateList, Values.MaxNumThreads);
                UpdaterTask.Callback += UpdaterTask_Callback;
                UpdaterTask.ErrorCallback += UpdaterTask_ErrorCallback;
                await UpdaterTask.Start();
                LogOnChangeStatus(LogOnStatus.CONNECTED);
            }
            else
            {
                LogOnChangeStatus(LogOnStatus.INIT);
            }
        }

        private void UpdaterTask_ErrorCallback(object sender, AsyncTaskResponse e)
        {
            var _App = e.AppBotCode != "" ? Values.AppList.Where(a => a.Code == e.AppBotCode).First() : null;
            if (_App != null)
            {
                _App.SetStatus(AppBotStatus.ERROR);
            }
            CTWin.MsgError(e.Message);
            if (debugBox != null)
                debugBox.AppendText(e.Message);

        }

        private void UpdaterTask_Callback(object sender, AsyncTaskResponse e)
        {
            var _App = e.AppBotCode != "" ? Values.AppList.Where(a => a.Code == e.AppBotCode).First() : null;
            switch (e.Message)
            {
                case "PROGRESS":
                    _App.ProgressValue++;
                    break;
                case "UPDATED":
                    if (_App.PendingItems.Count() == 0 && _App.UpdatingItems.Count()==0)
                        _App.SetStatus(AppBotStatus.UPDATED);
                    break;
                default:
                    if (debugBox != null)
                        debugBox.AppendText(e.Message);

                    break;
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            previousStatus = Status;
            LogOnChangeStatus(LogOnStatus.CHANGE_PASSWORD);
        }

        private void btnOKChange_Click(object sender, EventArgs e)
        {
            Status = LogOnStatus.CHANGING_PASSWORD;
            if (txtNewPassword.Text != txtNewPasswordConfirm.Text || txtNewPIN.Text != txtNewPINConfirm.Text)
            {
                MessageBox.Show("Passwords and PINs must match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Status = LogOnStatus.CHANGE_PASSWORD;
                return;
            }
            Values.gDatos.context_info = MasterPassword.MasterBytes;
            Values.gDatos.Connect();
            // Call the SP for Password/PIN change
            var _SP = new SP(Values.gDatos, "pLogOnUser");
            _SP.AddControlParameter("User", txtUser);
            _SP.AddParameterValue("Password", txtPassword.Text);
            _SP.AddParameterValue("Origin", "LOGON_CS");
            _SP.AddParameterValue("NewPassword", txtNewPassword.Text);
            _SP.AddParameterValue("NewPIN", txtNewPIN.Text);
            try
            {
                _SP.Execute();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //txtPassword.Text = "";
                Status = LogOnStatus.CHANGE_PASSWORD;
                return;
            }
            Values.gDatos.Close();
            if (_SP.LastMsg.Substring(0, 2) != "OK")
            {
                CTWin.MsgError(_SP.LastMsg);
                return;
            }
            MessageBox.Show("Password and PIN changed OK", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PanelName.Text = Values.FullName;
            Values.User = txtUser.Text;
            Values.Password = txtPassword.Text = txtNewPassword.Text;
            LogOnChangeStatus(previousStatus);
            txtUser.Text = Values.User;
            txtPassword.Text = Values.Password;
            btnOk.PerformClick();

            if (Status==LogOnStatus.INIT)
            {
                txtUser.Text = Values.User;
                txtPassword.Text = Values.Password;
                btnOk.PerformClick();
            }
                
        }

        private void btnCancelChange_Click(object sender, EventArgs e)
        {
            LogOnChangeStatus(previousStatus);
            //LogOnChangeStatus(LogOnStatus.CONNECTED);
        }

        private void chkDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                Values.debugBox = new TextBox() { Multiline=true };
                Values.debugBox.Dock = System.Windows.Forms.DockStyle.Bottom;
                Values.debugBox.Location = new System.Drawing.Point(3, 411);
                Values.debugBox.Multiline = true;
                Values.debugBox.Size = new System.Drawing.Size(300, 98);
                Values.debugBox.TabIndex = 3;
                gbDebugAdd(Values.debugBox);
            } else
            {
                if (Values.debugBox != null)
                {
                    Values.debugBox.Dispose();
                    Values.debugBox = null;
                }
            }

        }
    }



   

    

}


