using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using CommonTools;
using FTP;
//using FluentFTP;
using System.Net;
using System.Windows.Forms;
using CommonToolsWin;
using System.IO.Compression;

namespace LogOnObjects

{
    public static class myLock
    {
        public static object Lock { get; set; } = new object();
    }
    public class DebugTextbox : TextBox
    {
        public DebugTextbox()
            : base()
        {
            Multiline = true;
        }
        delegate void AppendTextCallback(string text);
        delegate void DisposeCallBack();
        public new void AppendText(string text)
        {
            if (this.InvokeRequired)
            {
                AppendTextCallback a = new AppendTextCallback(AppendText);
                this.Invoke(a, new object[] { text });
            }
            else
            {
                base.AppendText(text);
            }
        }
        public new void Dispose()
        {
            if (this.InvokeRequired)
            {
                DisposeCallBack a = new DisposeCallBack(Dispose);
                this.Invoke(a);
            }
            else
            {
                base.Dispose();
            }
        }
    }
    public enum LogonItemUpdateStatus { PENDING, UPDATING, UPDATED, ERROR}
    public class cUpdateListItem
    {
        public cAppBot Parent;
        //public string ServerPath;
        public string LocalPath;
        public DirectoryItem Item;
        public int ThreadNum;
        public cUpdaterThread Thread;
        public LogonItemUpdateStatus Status;
    }
    public class cUpdateList : List<cUpdateListItem>
    {

    }

    public class cUpdaterThread: IDisposable
    {
        
        private cServer Server { get; set; }
        private DebugTextbox debug { get; set; }
        public int NumThread { get; set; } 
        delegate void AppendTextCallback(string text);
        

        public cUpdaterThread(DebugTextbox pDebug =null, int pNum=0)
        {
            debug = pDebug;
            NumThread = pNum;
        }

        private cUpdateListItem stealOne(cUpdaterThread pThread, cUpdateList pList)
        {
            //semaforo
            lock (myLock.Lock)
            {
                cUpdateListItem _item;
                try
                {
                    _item = pList.OrderBy(x => x.Parent.Code).FirstOrDefault(x => x.Status == LogonItemUpdateStatus.PENDING);
                    if (_item != null)
                    {
                        _item.Thread = pThread;
                        _item.Status = LogonItemUpdateStatus.UPDATING;
                        if (debug != null)
                        {
                            AppendDebugText(string.Format("Thread {0} Updating {1}\n", NumThread, _item.LocalPath));
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                    //fin semaforo
                }
                //fin semaforo
                return _item;
            }


        }
        public void AppendDebugText(string text)
        {

            try
            {
                if (this.debug.InvokeRequired)
                {
                    AppendTextCallback a = new AppendTextCallback(AppendDebugText);
                    this.debug.Invoke(a, new object[] { text });
                }
                else
                {
                    debug.AppendText(text);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Process()
        {
            while (Values.AppList.PendingApps.Count != 0 || Values.AppList.CheckingApps.Count != 0)
            {
                cUpdateListItem item= new cUpdateListItem();
                try
                {
                    item = stealOne(this, Values.UpdateList);
                    if (item != null)
                    {
                        using (var ftp = new cFTP(Values.ShareServerList[Values.COD3], ""))
                        {
                            await ftp.DownloadItemAsync(item.Item, item.LocalPath);
                        }
                        item.Status = LogonItemUpdateStatus.UPDATED;
                        item.Parent.ChangeProgress(item.Parent.ProgressValue + 1);
                        if (item.Parent.UpdatedItems.Count == item.Parent.Items.Count())
                        {
                            item.Parent.SetStatus(AppBotStatus.UPDATED);
                        }
                        if (item.Parent.Special) //if its special unzip it
                        {
                            try
                            {
                                var _localPath = Path.GetDirectoryName(item.Parent.LocalPath);
                                if (Directory.Exists(_localPath))
                                    Directory.Delete(_localPath, true);
                                await (Task.Run(() => ZipFile.ExtractToDirectory(item.LocalPath, Values.LOCAL_PATH)));
                            }
                            catch (Exception ex)
                            {
                                AppendDebugText(string.Format("Thread {0} Error {1}\n", NumThread, ex.Message));
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    CTWin.MsgError(ex.Message+"\n"+ex.InnerException.Message);
                    if (null != item)
                    {
                        item.Status = LogonItemUpdateStatus.ERROR;
                        item.Parent.SetStatus(AppBotStatus.ERROR);
                    }


                }
                catch (InvalidOperationException ex)
                {
                    CTWin.MsgError(ex.InnerException.Message ?? ex.Message);
                    if (debug != null)
                    {
                        AppendDebugText(string.Format("Thread {0} Done.\n", NumThread));
                        Values.ActiveThreads--;
                        if (Values.ActiveThreads == 1)
                            break;
                        this.Dispose();
                    }
                    System.Threading.Thread.Sleep(500);
                }
                catch (Exception ex)
                {
                    CTWin.MsgError(ex.InnerException.Message ?? ex.Message);
                    if (debug != null)
                    {
                        AppendDebugText(string.Format("Thread {0} Waiting {1}\n",NumThread,ex.Message));
                    }
                    System.Threading.Thread.Sleep(500);

                }

            }
            if (Values.ActiveThreads == 1)
            {
                while (Values.AppList.PendingApps.Count != 0)
                //while (Values.UpdateDir.Where(x => x.Status == LogonItemUpdateStatus.PENDING).ToList().Count != 0)
                {
                    if (debug != null)
                        AppendDebugText(string.Format("Thread {0} Syncing directories.\n",NumThread));
                    cUpdateListItem _item;
                    try
                    {
                        _item = stealOne(this, Values.UpdateDir);
                        Directory.SetLastWriteTime(_item.LocalPath, _item.Item.DateCreated);
                        _item.Status = LogonItemUpdateStatus.UPDATED;
                    }
                    catch (Exception ex)
                    {
                        CTWin.MsgError(ex.InnerException.Message);
                        if (debug != null)
                        {
                            AppendDebugText(ex.Message + "\n");
                        }
                        System.Threading.Thread.Sleep(500);

                    }
                }
            }
            Values.ActiveThreads--;
            this.Dispose();
        }

        public void Dispose()
        {
            //if (Values.ActiveThreads==0)
            //    debug.Dispose();
        }

        //public async void Process()
        //{
        //    await Task.Run(() =>
        //    {
        //        using (Client = new SftpClient(Values.ShareServerList[Values.COD3].IP.ToString(), Values.ShareServerList[Values.COD3].User, Values.ShareServerList[Values.COD3].Password))
        //        {
        //            try
        //            {
        //                Client.Connect();
        //            }
        //            catch (Exception ex)
        //            {
        //                throw ex;
        //            }

        //            while (Values.AppList.PendingApps.Count != 0 || Values.AppList.CheckingApps.Count != 0)
        //            {
        //                var _item = stealOne(this);
        //                //lblMsg.Text = "Connecting the server.";

        //                //lblMsg.Text = "Server Connected!";
        //                //Client.ChangeDirectory("/etc/dhcp/");
        //                var _path = Path.GetDirectoryName(_item.LocalPath);
        //                if (!Directory.Exists(_path))
        //                    Directory.CreateDirectory(_path);
        //                using (var fileStream = new FileStream(_item.LocalPath, FileMode.Create))
        //                {
        //                    //Client.BufferSize = 20 * 1024; // bypass Payload error large files
        //                    try
        //                    {
        //                        Client.DownloadFile(_item.ServerPath, fileStream);
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        throw ex;
        //                    }
        //                }
        //                _item.Status = LogonItemUpdateStatus.UPDATED;
        //                if (_item.Parent.UpdatedItems.Count == _item.Parent.Items.Count())
        //                {
        //                    _item.Parent.Activate();
        //                }
        //            }
        //        }
        //    });
        //    return;
        //}



    }



}
