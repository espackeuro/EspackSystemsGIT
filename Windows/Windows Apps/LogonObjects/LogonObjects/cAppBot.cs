﻿using AccesoDatosNet;
using CommonTools;
using FluentFTP;
using FTP;
using LogonObjects.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.IO.File;
using static LogOnObjects.Values;
using System.Xml.Linq;

namespace LogOnObjects
{
    public enum AppBotStatus {INIT, CHECKING, PENDING_UPDATE, UPDATED, ERROR}

    // Class cAppBot: It contains the data for each APP, some methods for the APP management (run, update, etc) and some visual controls (progress bar, button, etc).
    public class cAppBot : Control
    {
        public string Code { get; set; }
        private string Description { get; set; }
        private string DataBase { get; set; }
        private cServer DBServer { get; set; }
        public cServer ShareServer { get; set; }
        private string ExeName { get; set; }
        private cAccesoDatosNet Conn { get; set; }
        public MyPanel grpApp { get; set; }
        public Button pctApp { get; set; }
        public ProgressBar prgApp { get; set; }
        public Label lblDescriptionApp { get; set; }
        public Label lblVersionApp { get; set; }
        //private AppBotStatus _status;
        public Bitmap AppIcon { get; set; }
        public string LocalPath { get; set; }
        public bool Special { get; set; }
        public int ProgressValue
        {
            get
            {
                return prgApp.Value;
            }
            set
            {
                prgApp.Value = value;
            }
        }
        public string version { get; set; }
        //Events
        public event EventHandler AfterLaunch;
        protected virtual void OnAfterLaunch(EventArgs e)
        {
            EventHandler handler = AfterLaunch;
            if (handler != null)
                handler(this, e);
        }
        // For the calls from different threads
        delegate void ShowStatusCallback();
        delegate void ChangeProgressCallback(int Value);
        // List of PENDING TO UPDATE items
        public List<cUpdateListItem> PendingItems
        {
            get
            {
                return UpdateList.Where(x => x.AppBotCode == this.Code && x.Status == LogonItemUpdateStatus.PENDING).ToList();
            }
        }

        // List of items BEING UPDATED
        public List<cUpdateListItem> UpdatingItems
        {
            get
            {
                return UpdateList.Where(x => x.AppBotCode == this.Code && x.Status == LogonItemUpdateStatus.UPDATING).ToList();
            }
        }
        
        // List of ALL items
        public List<cUpdateListItem> Items
        {
            get
            {
                return UpdateList.Where(x => x.AppBotCode == this.Code).ToList();
            }
        }

        // List of UPDATED items
        public List<cUpdateListItem> UpdatedItems
        {
            get
            {
                return UpdateList.Where(x => x.AppBotCode == this.Code && x.Status == LogonItemUpdateStatus.UPDATED).ToList();
            }
        }

        // Overwrite Size property (to change grpApp.Size when this.Size is changed)
        public new Size Size
        {
            get
            {
                if (grpApp != null)
                    return grpApp.Size;
                else
                    return new Size(0, 0);
            }
            set
            {
                if (grpApp != null)
                    grpApp.Size = value;

            }
        }
        
        // Status property: Sets the status value and changes the appearance of some related controls
        public AppBotStatus Status { get; set; }
        public void SetStatus(AppBotStatus status)
        {
            Status = status;
            ShowStatus();
        }
        public void ShowStatus()
        {
            try
            {
                if (debugBox != null)
                {
                    debugBox.AppendText(string.Format("App {0} status: {1}\n", Code, Status));
                }
                switch (Status)
                {
                    // When INIT/UPDATED -> Button enabled, ProgressBar not visible.
                    case AppBotStatus.INIT:
                    case AppBotStatus.UPDATED:
                        if (Special)
                            AppIcon = Resources.Engineering_48;
                        else
                            try
                            {
                                // First try to get the App icon from the exe file.
                                AppIcon = Icon.ExtractAssociatedIcon(LocalPath).ToBitmap();
                            }
                            catch
                            {
                                // If not possible, we use the default App icon.
                                AppIcon = Resources.Prototype_96;
                            }
                        pctApp.Image = AppIcon;
                        pctApp.Enabled = Status == AppBotStatus.UPDATED;
                        prgApp.Visible = false;
                        break;
                    // When CHECKING -> Button disabled, ProgressBar not visible.
                    case AppBotStatus.CHECKING:
                        pctApp.Enabled = false;
                        prgApp.Visible = false;
                        break;
                    // When PENDING_UPDATE -> Button disabled, ProgressBar visible and running.
                    case AppBotStatus.PENDING_UPDATE:
                        prgApp.Style = ProgressBarStyle.Continuous;
                        prgApp.Minimum = 0;
                        prgApp.Maximum = PendingItems.Count + 1;
                        //prgApp.MarqueeAnimationSpeed = 50;
                        prgApp.Visible = true;
                        pctApp.Enabled = false;

                        break;
                    case AppBotStatus.ERROR:
                        pctApp.Image = Resources.Forbid;
                        pctApp.Enabled = false;
                        prgApp.Visible = false;
                        this.PendingItems.ForEach(i => i.Status = LogonItemUpdateStatus.ERROR);
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        // Some "constants" for the appearance of this control.
        public static int GROUP_HEIGHT = 125;
        public static int GROUP_WIDTH = 125;

        public static int PROGRESS_PADDING = 10;
        public static int PROGRESS_HEIGHT = 15;
        public static int PROGRESS_WIDTH = GROUP_WIDTH - (PROGRESS_PADDING * 2);

        public static int DESCRIPTION_PADDING = PROGRESS_PADDING;
        public static int DESCRIPTION_HEIGHT = 35;
        public static int DESCRIPTION_WIDTH = GROUP_WIDTH - (DESCRIPTION_PADDING * 2);

        public static int VERSION_PADDING = PROGRESS_PADDING;
        public static int VERSION_HEIGHT = 10;
        public static int VERSION_WIDTH = GROUP_WIDTH - (DESCRIPTION_PADDING * 2);


        public static int PICTURE_PADDING = PROGRESS_PADDING;
        public static int PICTURE_HEIGHT = GROUP_HEIGHT - DESCRIPTION_PADDING - DESCRIPTION_HEIGHT - VERSION_HEIGHT - PICTURE_PADDING * 2;
        public static int PICTURE_WIDTH = GROUP_WIDTH - PICTURE_PADDING * 2;

        // Constructor (with args) -> Calls the base constructor and sets some properties
        public cAppBot(string pCode, string pDescription, string pDatabase, string pExeName, string ServiceZone, cServer pDBServer, cServer pShareServer, string pName, bool pSpecial=false, string pVersion="")
            : this()
        {
            Code = pCode;
            Description = pDescription;
            DataBase = pDatabase;
            ExeName = pExeName;
            LocalPath= LOCAL_PATH + Code + "/" + ExeName;
            DBServer = pDBServer;
            ShareServer = pShareServer;
            lblDescriptionApp.Text = Description;
            pctApp.Image = AppIcon;
            Special = pSpecial;
            Name = pName;
            version = pVersion;
            lblVersionApp.Text = pVersion;
            // Set Initial Status.
            SetStatus(AppBotStatus.INIT);
        }

        // Constructor (without args) -> Creates the Button, the ProgressBar, the Label and a GroupBox that will contain them. 
        public cAppBot()
        {
            grpApp = new MyPanel() { Size = new Size(GROUP_WIDTH, GROUP_HEIGHT), Location = new Point(0, 0), BorderStyle = BorderStyle.None};
            pctApp = new Button();
            prgApp = new ProgressBar()
            {
                Size = new Size(PROGRESS_WIDTH, PROGRESS_HEIGHT),
                Location = new Point(PROGRESS_PADDING, PICTURE_HEIGHT + PICTURE_PADDING), //(GROUP_HEIGHT / 2) - (PROGRESS_HEIGHT / 2)),
                Visible = false,
                ForeColor = Color.Blue
            };
            lblDescriptionApp = new Label()
            {
                Size = new Size(DESCRIPTION_WIDTH, DESCRIPTION_HEIGHT),
                Location = new Point(DESCRIPTION_PADDING, GROUP_HEIGHT - DESCRIPTION_HEIGHT - DESCRIPTION_PADDING - VERSION_HEIGHT),
                Font = new Font("MS Sans Serif", 7, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter
            };
            lblVersionApp = new Label()
            {
                Size = new Size(VERSION_WIDTH, VERSION_HEIGHT),
                Location = new Point(VERSION_PADDING, GROUP_HEIGHT - VERSION_HEIGHT - VERSION_PADDING),
                Font = new Font("MS Sans Serif", 5, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Gray
            };
            pctApp = new Button() { Size = new Size(PICTURE_WIDTH, PICTURE_HEIGHT), Location = new Point(PICTURE_PADDING, PICTURE_PADDING) };
#if DEBUG
            lblDescriptionApp.BorderStyle = BorderStyle.FixedSingle;
            lblVersionApp.BorderStyle = BorderStyle.FixedSingle;
#else
            pctApp.FlatAppearance.BorderSize = 0;
            pctApp.FlatStyle = FlatStyle.Flat;
#endif

            // Add prgApp, pctApp and lblDescriptionApp to the grpApp GroupBox.
            grpApp.Controls.Add(prgApp);
            grpApp.Controls.Add(pctApp);
            grpApp.Controls.Add(lblDescriptionApp);
            grpApp.Controls.Add(lblVersionApp);
            MaximumSize = Size;
            MinimumSize = Size;
            this.Controls.Add(grpApp);

            // Add the Click event.
            pctApp.Click += PctApp_Click;
        }

        private async void PctApp_Click(object sender, EventArgs e)
        {
            if (!Special)
                await LaunchApp(true);
        }

        // Overwrite resize event 
        protected override void OnResize(EventArgs e)
        {
            this.Size = new Size(GROUP_WIDTH, GROUP_HEIGHT);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }



        public bool CheckUpdatedXML()
        {
            bool clean = true;
            XElement xe = null;
            XElement xs = null;
            XElement zipFile = null;
            string zipFileName = "";
            string zipFilePath = "";
            DateTime zipFileDateTime = DateTime.MinValue;
            string zipLocalFilePath = "";
            try
            {
                if (Special)
                {
                    xs = XMLSystemState.Descendants("special").First(s => s.Attribute("name").Value == Code.ToLower());
                    zipFile = xs.Descendants("File").First();
                    zipFileName = zipFile.Attribute("fileName").Value;
                    zipFilePath = zipFile.Attribute("path").Value.Replace("\\", "/");
                    zipFileDateTime = DateTime.Parse(zipFile.Attribute("fileTime").Value);
                    zipLocalFilePath = LOCAL_PATH + zipFilePath + zipFileName;
                    if (File.Exists(zipLocalFilePath))
                        File.Delete(zipLocalFilePath);
                }
                xe = XMLSystemState.Descendants("system").First(s => s.Attribute("name").Value == Code.ToLower());
            } catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            foreach (var file in xe.Descendants("File").ToList())
            {
                var fileName = file.Attribute("fileName").Value;
                var filePath = file.Attribute("path").Value.Replace("\\", "/");
                var fileDateTime = DateTime.Parse(file.Attribute("fileTime").Value);
                var localFilePath = LOCAL_PATH + filePath + fileName;
                if (File.Exists(localFilePath))
                {
                    if (!Special)
                    {
                        var localFileDate = GetLastWriteTime(localFilePath);
                        //var localFileInfo = new FileInfo(localFilePath);
                        if ((localFileDate - fileDateTime).Duration().TotalSeconds > 10)
                        {
                            clean = false;
                        }
                    }
                }
                else
                {
                    clean = false;
                }
                if (!clean)
                {
                    if (Special) //adds only the zip file
                    {
                        UpdateList.Add(new cUpdateListItem()
                        {
                            AppBotCode = this.Code,
                            AppPath = this.LocalPath,
                            Item = new DirectoryItem()
                            {
                                Server = ShareServer,
                                DateCreated = zipFileDateTime,
                                IsDirectory = false,
                                Name = zipFileName,
                                BaseUri = new UriBuilder("ftp://" + ShareServer.HostName + "/APPS_CS/" + zipFilePath).Uri
                            },
                            LocalPath = zipLocalFilePath,
                            Status = LogonItemUpdateStatus.PENDING,
                            zipFile = true
                            //ThreadNum = UpdateList.Count % Values.MaxNumThreads
                        });
                        break;
                    }
                    else
                        UpdateList.Add(new cUpdateListItem()
                        {
                            AppBotCode = this.Code,
                            AppPath = this.LocalPath,
                            Item = new DirectoryItem()
                            {
                                Server = ShareServer,
                                DateCreated = fileDateTime,
                                IsDirectory = false,
                                Name = fileName,
                                BaseUri = new UriBuilder("ftp://" + ShareServer.HostName + "/APPS_CS/" + filePath).Uri
                            },
                            LocalPath = localFilePath,
                            Status = LogonItemUpdateStatus.PENDING,
                            //ThreadNum = UpdateList.Count % Values.MaxNumThreads
                        });
                }

            }
            return clean;
        }

        // CheckUpdated -> Returns true if all the files for this APP are updated.
        public async Task<bool> CheckUpdated(bool force=false)
        {
            //ShowStatus(AppBotStatus.CHECKING);
            
            bool _clean = true;
            if (!File.Exists(LocalPath) || File.Exists(LocalPath) && FileVersionInfo.GetVersionInfo(LocalPath).FileVersion.ToString()!=version || Special==true || force==true)
            {
                using (var client = new FtpClient())
                {
                    client.ConnectTimeout = 120000;
                    client.Host = ShareServer.IP.ToString();
                    client.Credentials = new NetworkCredential(ShareServer.User, ShareServer.Password);
                    client.DataConnectionType = FtpDataConnectionType.EPSV;
                    try
                    {
                        await client.ConnectAsync();
                    }
                    catch
                    {
                        await Task.Delay(500);
                        try
                        {
                            await client.ConnectAsync();
                        }
                        catch
                        {
                            await Task.Delay(500);
                            await client.ConnectAsync();
                        }
                    }
                    if (Special)
                    {
                        var specialFilePath = LOCAL_PATH + Code.ToLower() + ".zip";
                        FtpListItem a;
                        try
                        {
                            a = (await client.GetListingAsync("/APPS_CS/")).FirstOrDefault(x => x.Name == Code.ToLower() + ".zip");
                        } catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        if (GetLastWriteTime(specialFilePath) != a.Modified || !Exists(specialFilePath) || !Directory.Exists(Path.GetDirectoryName(LocalPath)))
                        {
                            UpdateList.Add(new cUpdateListItem()
                            {
                                AppBotCode = this.Code,
                                AppPath = this.LocalPath,
                                Item = new DirectoryItem()
                                {
                                    Server = ShareServer,
                                    DateCreated = a.Modified,
                                    IsDirectory = false,
                                    Name = a.Name,
                                    BaseUri = new UriBuilder("ftp://" + ShareServer.HostName + "/APPS_CS").Uri
                                },
                                LocalPath = specialFilePath,
                                Status = LogonItemUpdateStatus.PENDING,
                                //ThreadNum = UpdateList.Count % Values.MaxNumThreads
                            });
                            _clean = false;
                        }
                        else
                            _clean = true;
                    }
                    else
                        _clean = await readDirFTP(client, "/APPS_CS/", Code.ToLower());
                }
            } 
            return _clean;

        }
        //public bool CheckUpdatedSync()
        //{
        //    ShowStatus(AppBotStatus.CHECKING);
        //    bool _clean = true;
        //    using (var client = new FtpClient())
        //    {
        //        client.ConnectTimeout = 60000;
        //        client.Host = ShareServer.HostName;
        //        client.Credentials = new NetworkCredential(ShareServer.User, ShareServer.Password);
        //        client.DataConnectionType = FtpDataConnectionType.AutoActive;
        //        client.Connect();
        //        _clean = readDirFTP(client, "/APPS_CS/", Code.ToLower());
        //    }
        //    if (!_clean)
        //        ShowStatus(AppBotStatus.PENDING_UPDATE);
        //    return _clean;
        //}


        private async Task<bool> readDirFTP(FtpClient client, string basePath, string relativePath, bool _checkFiles=true)
        {
            bool _clean = true;
            //client.ChangeDirectory(basePath + relativePath);
            var _path = basePath + relativePath;




            var list = await client.GetListingAsync(_path);

            foreach (var a in list.Where(x => x.Type == FtpFileSystemObjectType.Directory))
            {
                bool _condition = !Directory.Exists(LOCAL_PATH + relativePath + "/" + a.Name);
                if (_condition == false)
                    _condition = (a.Modified != Directory.GetLastWriteTime(LOCAL_PATH + relativePath + "/" + a.Name));
                if (_condition)
                {
                    UpdateDir.Add(new cUpdateListItem()
                    {
                        AppBotCode = this.Code,
                        AppPath = this.LocalPath,
                        Item = new DirectoryItem()
                        {
                            Server = ShareServer,
                            DateCreated = a.Modified,
                            IsDirectory = true,
                            Name = ".",
                            BaseUri = new UriBuilder("ftp://" + ShareServer.HostName + "/APPS_CS/" + relativePath + "/" + a.Name).Uri
                        },
                        LocalPath = LOCAL_PATH + relativePath + "/" + a.Name,
                        Status = LogonItemUpdateStatus.PENDING
                    });
                }
                _clean = await readDirFTP(client, basePath, relativePath + "/" + a.Name, _condition) && _clean;
            };

            if (_checkFiles)
            {
                foreach (var a in list.Where(x => x.Type == FtpFileSystemObjectType.File))
                {
                    if (Exists(LOCAL_PATH + relativePath + "/" + a.Name))
                    {
                        if (GetLastWriteTime(LOCAL_PATH + relativePath + "/" + a.Name) != a.Modified)
                        {
                            //if (Status != AppBotStatus.PENDING_UPDATE)
                            //    ShowStatus(AppBotStatus.PENDING_UPDATE);
                            UpdateList.Add(new cUpdateListItem()
                            {
                                AppBotCode = this.Code,
                                AppPath = this.LocalPath,
                                Item = new DirectoryItem()
                                {
                                    Server = ShareServer,
                                    DateCreated = a.Modified,
                                    IsDirectory = false,
                                    Name = a.Name,
                                    BaseUri = new UriBuilder("ftp://" + ShareServer.HostName + "/APPS_CS/" + relativePath).Uri
                                },
                                LocalPath = LOCAL_PATH + relativePath + "/" + a.Name,
                                Status = LogonItemUpdateStatus.PENDING
                            });
                            _clean = false;
                        }
                    }
                    else
                    {
                        UpdateList.Add(new cUpdateListItem()
                        {
                            AppBotCode = this.Code,
                            AppPath = this.LocalPath,
                            Item = new DirectoryItem()
                            {
                                Server = ShareServer,
                                DateCreated = a.Modified,
                                IsDirectory = false,
                                Name = a.Name,
                                BaseUri = new UriBuilder("ftp://" + ShareServer.HostName + "/APPS_CS/" + relativePath).Uri
                            },
                            LocalPath = LOCAL_PATH + relativePath + "/" + a.Name,
                            Status = LogonItemUpdateStatus.PENDING
                        });
                        _clean = false;
                    }

                }
            }
            // this part added to remove local files not present in remote directory
            if (Directory.Exists(LOCAL_PATH + relativePath + "/"))
            {
                var localList = new DirectoryInfo(LOCAL_PATH + relativePath + "/").EnumerateFileSystemInfos();
                foreach (var _file in localList)
                {
                    if (list.FirstOrDefault(x => x.Name == _file.Name) == null)
                    {
                        if(_file is FileInfo)
                            _file.Delete();
                        if (_file is DirectoryInfo)
                            ((DirectoryInfo)_file).Delete(true);

                    }
                }
            }
            return _clean;
        }
        //public bool CheckUpdateSync()
        //{
        //    bool _clean = true;
        //    //_clean = readDir("/APPS_CS/", Code.ToLower());
        //    using (var client = new SftpClient(ShareServer.IP.ToString(), ShareServer.User, ShareServer.Password))
        //    {
        //        client.Connect();
        //        _clean = readDirSSH(client,"/APPS_CS/", Code.ToLower(),true);
        //    }
        //    return _clean;
        //}

        private async Task<bool> readDir(string basePath, string relativePath)
        {
            bool _clean = true;
            List<DirectoryItem> list;
            using (var ftp = new cFTP(ShareServer, basePath + relativePath))
            {
                list = await ftp.GetDirectoryList("", getDateTimes: true);
            }
            list.Where(x => x.IsDirectory).ToList().ForEach(async a =>
            {
                _clean = (await readDir(basePath, relativePath + "/" + a.Name) && _clean);
            });
            list.Where(x => !x.IsDirectory).ToList().ForEach(a =>
            {
                if (Exists(LOCAL_PATH + relativePath + "/" + a.Name))
                {
                    if (GetLastWriteTime(LOCAL_PATH + relativePath + "/" + a.Name) != a.DateCreated)
                    {
                        UpdateList.Add(new cUpdateListItem()
                        {
                            AppBotCode = this.Code,
                            AppPath = this.LocalPath,
                            //ServerPath = basePath + relativePath + "/" + a.Name,
                            LocalPath = LOCAL_PATH + relativePath + "/" + a.Name,
                            Item = a,
                            Status = LogonItemUpdateStatus.PENDING
                        });
                        _clean = false;
                    }
                }
                else
                {
                    UpdateList.Add(new cUpdateListItem()
                    {
                        AppBotCode = this.Code,
                        AppPath = this.LocalPath,
                        //ServerPath = basePath + relativePath + "/" + a.Name,
                        LocalPath = LOCAL_PATH + relativePath + "/" + a.Name,
                        Item = a,
                        Status = LogonItemUpdateStatus.PENDING
                    });
                    _clean = false;
                }
            });


            return _clean;
        }




        public void ChangeProgress(int Value)
        {
            if (Value > prgApp.Maximum)
                Value = prgApp.Maximum;
            if (Value < prgApp.Minimum)
                Value = prgApp.Minimum;
            try
            {
                prgApp.Value = Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task LaunchApp(bool temp = false)
        {


            //if (!Special && !External)
            //{
            //    SetStatus(AppBotStatus.PENDING_UPDATE);
            //    //if (!await CheckUpdated().ConfigureAwait(false))
            //    if (!await CheckUpdated(true))
            //    {
            //        Application.DoEvents();
            //        ActiveThreads++;
            //        var _thread = new cUpdaterThread(debugBox, ActiveThreads);
            //        // launch task not async
            //        await _thread.Process();
            //    }
            //    SetStatus(AppBotStatus.UPDATED);
            //}
            if (DBServer.HostName != gDatos.Server && DBServer.User != "procesos")
            {
                var _datos = new cAccesoDatosNet();
                _datos.User = gDatos.User;
                _datos.Password = gDatos.Password;
                _datos.DataBase = gDatos.DataBase;
                _datos.Server = DBServer.HostName;
                // check the password in the new server
                var _SP = new SP(_datos, "pLogOnUser");
                _SP.AddParameterValue("User", DBServer.User);
                _SP.AddParameterValue("Ticket", DBServer.Password);
                _SP.AddParameterValue("Origin", "LOGON_CS");
                try
                {
                    _SP.Execute();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nIf you have recently changed your password, wait a couple of minutes before opening this app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string _tempPath = string.Format("{0}\\{1}", Path.GetTempPath(), this.Code);
            if (temp)
            {
                //copy to temp folder

                DirectoryInfo _dir = new DirectoryInfo(_tempPath);
                if (_dir.Exists)
                    try
                    {
                        _dir.Delete(true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "\nIt looks like the application is already open.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                var _odir = new DirectoryInfo(LOCAL_PATH + Code + "/");
                _odir.DirectoryCopy(_tempPath);
                _tempPath = string.Format("{0}\\{1}", _tempPath, ExeName);
            }
            else
                _tempPath = LocalPath;
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;
            startInfo.FileName = _tempPath;
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            startInfo.Arguments = string.Format("/srv={0} /db={1} /usr={2} /pwd={3} /loc={4} /app={5}{6}{7}", DBServer.IP.ToString(), DataBase, DBServer.User, DBServer.Password, "OUT", Name, External ? " /ext=1" : "", Code=="logon"?" /noxml=1":"");

            try
            {
                Process exeProcess = Process.Start(startInfo);
                OnAfterLaunch(new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

    }





    // Class cAppList
    public class cAppList: IEnumerable<cAppBot>, IDisposable
    {
        private List<cAppBot> AppList { get; set; } = new List<cAppBot>();

        public List<cAppBot> CheckingApps
        {
            get
            {
                return AppList.Where(x => x.Status == AppBotStatus.CHECKING).ToList();
            }
        }

        public List<cAppBot> PendingApps
        {
            get
            {
                return AppList.Where(x => x.Status == AppBotStatus.PENDING_UPDATE).ToList();
            }
        }
        public cAppBot this[string pCode]
        {
            get
            {
                return AppList.FirstOrDefault(x => x.Code == pCode);
            }
            
        }
        public cAppBot this[int pKey]
        {
            get
            {
                return AppList[pKey];
            }

        }
        public int Count
        {
            get
            {
                return AppList.Count;
            }
        }
        public void Add(cAppBot pApp)
        {
            AppList.Add(pApp);
        }

        public void Clear()
        {
            AppList.Clear();
        }


        public IEnumerator<cAppBot> GetEnumerator()
        {
            return ((IEnumerable<cAppBot>)AppList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<cAppBot>)AppList).GetEnumerator();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    AppList.ToList().ForEach(x => x.Dispose());
                    AppList.Clear();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~cAppList() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
            disposedValue = false;
        }
        #endregion
    }

    [System.ComponentModel.DesignerCategory("Code")]
    public class MyPanel : Panel
    {
        public MyPanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (SolidBrush brush = new SolidBrush(BackColor))
                e.Graphics.FillRectangle(brush, ClientRectangle);
            e.Graphics.DrawRectangle(Pens.White, 0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
        }

    }

}
