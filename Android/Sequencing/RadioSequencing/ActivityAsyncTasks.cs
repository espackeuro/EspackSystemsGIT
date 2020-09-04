//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using AccesoDatosXML;

//namespace Sistemas
//{
//    public class AsyncTaskResponse
//    {

//        public AsyncTaskResponse(string msg, string serverName)
//        {
//            Message = msg;
//            ServerName = serverName;
//        }

//        public string Message { get; }
//        public string ServerName { get; }
//    }

//    public class SPXML_EXT :SPXML
//    {
//        public bool CommandStopped;
//        private readonly SynchronizationContext SyncContext;

//        // Crear los 2 contenedores de callbacks
//        public event EventHandler<AsyncTaskResponse> Callback;
//        public event EventHandler<AsyncTaskResponse> ErrorCallback;


//        public override async Task ExecuteAsync()
//        {
//            SendMessage($"Procedure {SPName} Launching.","");


//        } 

//        private void SendMessage(string Text, string serverName)
//        {
//            SyncContext.Post(e => triggerCallback(new AsyncTaskResponse(Text, serverName)), null);
//        }
//        private void SendError(string Text, string serverName)
//        {
//            SyncContext.Post(e => triggerErrorCallback(new AsyncTaskResponse(Text, serverName)), null);
//        }


//        public 


//        public async Task Start()
//        {
//            await Task.Run(async () =>
//            {
//                List<Task> ServerTaskList = new List<Task>();
//                foreach (var server in ServerList)
//                {
//                    //create the task for each server
//                    var ServerTask = Task.Run(() =>
//                    {
//                        //restart the dhcp service
//                        //item.Value.Label.Text = "Command started.";
//                        SendMessage("Command started", server.ServerName);
//                        var serverName = string.Format("{0}.local", server.ServerName);
//                        //var serverLabel = item.Value.Label;
//                        // check if FileName
//                        if (server.FileName != "")
//                        {
//                            try
//                            {
//                                string _tmpFile = System.IO.Path.GetTempPath() + Path.GetFileName(server.FileName);
//                                File.WriteAllText(_tmpFile, server.FileContent);
//                                SendMessage("File created correctly.", server.ServerName);

//                                using (var client = new SftpClient(serverName, User, Password))
//                                {
//                                    client.Connect();
//                                    using (var fileStream = new FileStream(_tmpFile, FileMode.Open))
//                                    {
//                                        client.BufferSize = 4 * 1024; // bypass Payload error large files
//                                        client.UploadFile(fileStream, server.FileName);
//                                    }
//                                    SendMessage("File uploaded.", server.ServerName);
//                                    client.Disconnect();
//                                }
//                            }
//                            catch (Exception ex)
//                            {
//                                SendError(string.Format("ERROR: {0}", ex.Message), server.ServerName);
//                            }
//                        }
//                        try
//                        {
//                            using (var client = new SshClient(serverName, User, Password))
//                            {
//                                client.Connect();
//                                var result = client.RunCommand(Command);
//                                if (result.ExitStatus != 0)
//                                {
//                                    SendError(string.Format("ERROR: {0}", result.Error), server.ServerName);
//                                }
//                                else
//                                {
//                                    SendMessage(string.Format("Command completed."), server.ServerName);
//                                }
//                                client.Disconnect();
//                            }
//                        }
//                        catch (Exception ex)
//                        {
//                            SendError("Error: " + ex.Message, "");
//                            return;
//                        }
//                    });
//                    ServerTaskList.Add(ServerTask);
//                }
//                await Task.WhenAll(ServerTaskList);
//            });
//        }
//        // Métodos que ejecutan los callback si y solo si fueron declarados durante la instanciación de la clase HeavyTask
//        private void triggerCallback(AsyncTaskResponse response)
//        {
//            // Si el primer callback existe, ejecutarlo con la información dada
//            Callback.Invoke(this, response);
//        }
//        private void triggerErrorCallback(AsyncTaskResponse response)
//        {
//            // Si el primer callback existe, ejecutarlo con la información dada
//            ErrorCallback.Invoke(this, response);
//        }

//    }
//}
