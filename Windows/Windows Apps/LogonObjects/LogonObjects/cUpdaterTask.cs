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
using FluentFTP;
using System.Threading;
using System.ComponentModel;

namespace LogOnObjects

{
    public static class myLock
    {
        public static object Lock { get; set; } = new object();
    }
    
    public enum LogonItemUpdateStatus { PENDING, UPDATING, UPDATED, ERROR }
    public class cUpdateListItem
    {
        public string AppBotCode;
        public string AppPath;
        //public string ServerPath;
        public string LocalPath;
        public DirectoryItem Item;
        public LogonItemUpdateStatus Status;
        public bool zipFile;
    }
    public class cUpdateList : List<cUpdateListItem>
    {
        public List<cUpdateListItem> PendingUpdateItems
        {
            get
            {
                return this.Where(x => x.Status == LogonItemUpdateStatus.PENDING).ToList();
            }

        }
        public int PendingCount
        {
            get
            {
                return PendingUpdateItems.Count();
            }
        }
    }

    public class AsyncTaskResponse
    {
        public string Message { get; set; }
        public bool IsDebug { get; set; } = false;
        public string AppBotCode { get; set; } = "";
    }

    public class Updater
    {
        public event EventHandler<AsyncTaskResponse> Callback;
        public event EventHandler<AsyncTaskResponse> ErrorCallback;
        private readonly SynchronizationContext SyncContext;
        private int MaxTasks;
        public int RunningTasks { get; set; }
        private cUpdateList ElementsToUpdate { get; }
        public void SendMessage(string Text, bool pIsDebug, string pAppBotCode)
        {
            SyncContext.Post(e => triggerCallback(new AsyncTaskResponse() { Message = Text, IsDebug = pIsDebug, AppBotCode=pAppBotCode }), null);
        }
        public void SendError(string Text, bool pIsDebug, string pAppBotCode)
        {
            SyncContext.Post(e => triggerErrorCallback(new AsyncTaskResponse() { Message = Text, IsDebug = pIsDebug, AppBotCode = pAppBotCode }), null);
        }
        // Métodos que ejecutan los callback si y solo si fueron declarados durante la instanciación de la clase HeavyTask
        private void triggerCallback(AsyncTaskResponse response)
        {
            // Si el primer callback existe, ejecutarlo con la información dada
            if (Callback != null)
                Callback.Invoke(this, response);
        }
        private void triggerErrorCallback(AsyncTaskResponse response)
        {
            // Si el primer callback existe, ejecutarlo con la información dada
            if (ErrorCallback != null)
                ErrorCallback.Invoke(this, response);
        }

        public Updater(cUpdateList pElementsToUpdate, int pMaxTasks = 4)
        {
            SyncContext = AsyncOperationManager.SynchronizationContext;
            ElementsToUpdate = pElementsToUpdate;
            MaxTasks = pMaxTasks;
        }

        private cUpdateListItem stealOne()
        {
            //semaforo
            lock (myLock.Lock)
            {
                cUpdateListItem _item;
                try
                {
                    _item = ElementsToUpdate.OrderBy(x => x.AppBotCode).FirstOrDefault(x => x.Status == LogonItemUpdateStatus.PENDING);
                    if (_item != null)
                    {
                        _item.Status = LogonItemUpdateStatus.UPDATING;
                        SendMessage(string.Format("Updating {0}\n", _item.LocalPath), true, _item.AppBotCode);
                    }
                }
                catch (Exception ex)
                {
                    SendError(ex.Message, true, "");
                    return null;
                    //fin semaforo
                }
                //fin semaforo
                return _item;
            }
        }

        public async Task Start()
        {
            await Task.Run(() =>
            {
                MaxTasks = MaxTasks > ElementsToUpdate.PendingCount ? ElementsToUpdate.PendingCount : MaxTasks;
                List<Task> TaskList = new List<Task>();
                for (var i = 0; i < MaxTasks; i++)
                {
                    var item = stealOne();
                    if (item == null)
                        break;
                    var UpdaterTask = new UpdaterTask(item, RunningTasks, this);
                    var laTask = Task.Run(async () => await UpdaterTask.Run());
                    TaskList.Add(laTask);
                }
                while (ElementsToUpdate.PendingCount > 0)
                {
                    Task.WaitAny(TaskList.ToArray());
                    var item = stealOne();
                    if (item == null)
                        break;
                    var UpdaterTask = new UpdaterTask(item, RunningTasks, this);
                    var laTask = Task.Run(async () => await UpdaterTask.Run());
                    TaskList.Add(laTask);
                }
                Task.WaitAll(TaskList.ToArray());
            });
        }
    }

    public class UpdaterTask
    {
        public Task Task { get; private set; }
        public int NumTask { get; }
        private cUpdateListItem UpdateItem;
        private Updater Updater;
        public UpdaterTask(cUpdateListItem pItem, int pNumTask, Updater pUpdater)
        {
            UpdateItem = pItem;
            NumTask = pNumTask;
            Updater = pUpdater;
        }
        public async Task Run()
        {
            Updater.RunningTasks++;
            try
            {
                using (var ftp = new cFTP(Values.ShareServerList[Values.COD3], ""))
                {
                    await ftp.DownloadItemAsync(UpdateItem.Item, UpdateItem.LocalPath.Replace("\\", "/"));
                }
                UpdateItem.Status = LogonItemUpdateStatus.UPDATED;
                Updater.SendMessage("PROGRESS", false, UpdateItem.AppBotCode);
                /*
                item.Parent.ChangeProgress(item.Parent.ProgressValue + 1);

                if (item.Parent.UpdatedItems.Count == item.Parent.Items.Count())
                {
                    item.Parent.SetStatus(AppBotStatus.UPDATED);
                }
                */
                if (UpdateItem.zipFile) //if its special unzip it
                {
                    try
                    {
                        var _localPath = Path.GetDirectoryName(UpdateItem.AppPath);
                        if (Directory.Exists(_localPath))
                            Directory.Delete(_localPath, true);
                        //await (Task.Run(() => ZipFile.ExtractToDirectory(item.LocalPath, Values.LOCAL_PATH)));
                        using (ZipArchive archive = ZipFile.OpenRead(UpdateItem.LocalPath))
                        {
                            foreach (ZipArchiveEntry entry in archive.Entries)
                            {
                                if (entry.FullName.Substring(entry.FullName.Length - 1, 1) == "/")
                                {
                                    Directory.CreateDirectory(Path.Combine(Values.LOCAL_PATH, entry.FullName));
                                }
                                else
                                {
                                    entry.ExtractToFile(Path.Combine(Values.LOCAL_PATH, entry.FullName));
                                }
                            }
                        }
                        File.Delete(UpdateItem.LocalPath);
                    }
                    catch (Exception ex)
                    {
                        Updater.SendError(string.Format("Error {0}\n", ex.Message), true, UpdateItem.AppBotCode);
                        UpdateItem.Status = LogonItemUpdateStatus.ERROR;
                    }
                }
                Updater.SendMessage("UPDATED", false, UpdateItem.AppBotCode);
            }
            catch (WebException ex)
            {
                Updater.SendError(string.Format("Error {0}\n", ex.InnerException.Message), true, UpdateItem.AppBotCode);
                UpdateItem.Status = LogonItemUpdateStatus.ERROR;
                /*
                CTWin.MsgError(ex.Message + "\n" + ex.InnerException.Message);
                if (null != item)
                {
                    item.Status = LogonItemUpdateStatus.ERROR;
                    item.Parent.SetStatus(AppBotStatus.ERROR);
                }
                */

            }
            catch (InvalidOperationException ex)
            {
                Updater.SendError(string.Format("Error {0}\n", ex.InnerException.Message ?? ex.Message), true, UpdateItem.AppBotCode);
                UpdateItem.Status = LogonItemUpdateStatus.ERROR;
                /*
                CTWin.MsgError(ex.InnerException.Message ?? ex.Message);
                if (debug != null)
                {
                    AppendDebugText(string.Format("Thread {0} Done.\n", NumThread));
                    Values.ActiveThreads--;
                    if (Values.ActiveThreads == 1)
                        break;
                    this.Dispose();
                }
                */
                System.Threading.Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                Updater.SendError(string.Format("Error {0}\n", ex.InnerException.Message ?? ex.Message), true, UpdateItem.AppBotCode);
                UpdateItem.Status = LogonItemUpdateStatus.ERROR;
                /*
                CTWin.MsgError(ex.InnerException.Message ?? ex.Message);
                if (debug != null)
                {
                    AppendDebugText(string.Format("Thread {0} Waiting {1}\n", NumThread, ex.Message));
                }
                */
                System.Threading.Thread.Sleep(500);
            }
            Updater.RunningTasks--;
        }
    }
}
