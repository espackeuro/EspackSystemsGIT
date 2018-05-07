//using AccesoDatosNet;
//using CommonTools;
//using CommonToolsWin;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Diagnostics;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Security;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Xml.Linq;
//using SharpSvn;
//using SharpSvn.UI;
//using static Sistemas.Values;
//using Renci.SshNet;
//using System.Threading;

//namespace Sistemas
//{
//    public partial class fSystemsMaster : Form
//    {

//        public class AsyncTaskResponse
//        {

//            public AsyncTaskResponse(string msg, string serverName)
//            {
//                Message = msg;
//                ServerName = serverName;
//            }

//            public string Message { get; }
//            public string ServerName { get; }
//        }

//        public class ServerCheckout
//        {
//            public bool CheckoutStopped;
//            private readonly SynchronizationContext SyncContext;
//            private List<string> ServerList = new List<string>();
//            private string User;
//            private string Password;

//            // Crear los 2 contenedores de callbacks
//            public event EventHandler<AsyncTaskResponse> Callback;
//            public event EventHandler<AsyncTaskResponse> ErrorCallback;

//            public ServerCheckout(List<string> pServerList, string pUser, string pPassword)
//            {
//                SyncContext = AsyncOperationManager.SynchronizationContext;
//                ServerList = pServerList;
//                User = pUser;
//                Password = pPassword;
//            }

//            private void SendMessage(string Text, string serverName)
//            {
//                SyncContext.Post(e => triggerCallback(new AsyncTaskResponse(Text, serverName)), null);
//            }
//            private void SendError(string Text, string serverName)
//            {
//                SyncContext.Post(e => triggerErrorCallback(new AsyncTaskResponse(Text, serverName)), null);
//            }

//            public async Task Start()
//            {
//                await Task.Run(async () =>
//                {
//                    List<Task> ServerTaskList = new List<Task>();
//                    foreach (var server in ServerList)
//                    {
//                        //create the task for each server
//                        var ServerTask = Task.Run(() =>
//                         {
//                            //restart the dhcp service
//                            //item.Value.Label.Text = "Checkout started.";
//                            SendMessage("Checkout started", server);
//                             var serverName = string.Format("{0}.local", server);
//                            //var serverLabel = item.Value.Label;
//                            try
//                             {
//                                 using (var client = new SshClient(serverName, User, Password))
//                                 {
//                                     client.Connect();
//                                     var result = client.RunCommand("~/checkout.sh");
//                                     if (result.ExitStatus != 0)
//                                     {
//                                         SendError(string.Format("ERROR: {0}", result.Error), server);
//                                     }
//                                     else
//                                     {
//                                         SendMessage(string.Format("Checkout completed."), server);
//                                     }
//                                     client.Disconnect();
//                                 }
//                             }
//                             catch (Exception ex)
//                             {
//                                 SendError("Error: " + ex.Message, "");
//                                 return;
//                             }
//                         });
//                        ServerTaskList.Add(ServerTask);
//                    }
//                    await Task.WhenAll(ServerTaskList);
//                });
//            }
//            // Métodos que ejecutan los callback si y solo si fueron declarados durante la instanciación de la clase HeavyTask
//            private void triggerCallback(AsyncTaskResponse response)
//            {
//                // Si el primer callback existe, ejecutarlo con la información dada
//                Callback.Invoke(this, response);
//            }
//            private void triggerErrorCallback(AsyncTaskResponse response)
//            {
//                // Si el primer callback existe, ejecutarlo con la información dada
//                ErrorCallback.Invoke(this, response);
//            }

//        }
//    }
//}