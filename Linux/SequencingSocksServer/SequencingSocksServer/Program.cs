using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;

namespace AsyncEchoServer
{
    public class AsyncEchoServer
    {
        private int _listeningPort;
        private int _dayCount=0;
        private string _day = "";
        public AsyncEchoServer(int port)
        {
            _listeningPort = port;
        }
        ///<summary>
        /// Start listening for connection
        /// </summary>
        public async void Start()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList.FirstOrDefault(x => x.GetAddressBytes()[0] == 192);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, _listeningPort);
            TcpListener listener = new TcpListener(IPAddress.Any, _listeningPort);
            listener.Start();
            LogMessage("Server is running");
            LogMessage("Listening on port " + _listeningPort);

            while (true)
            {
                LogMessage("Waiting for connections...");
                try
                {
                    var tcpClient = await listener.AcceptTcpClientAsync();
                    HandleConnectionAsync(tcpClient);
                }
                catch (Exception exp)
                {
                    LogMessage(exp.ToString());
                }

            }

        }
        ///<summary>
        /// Process Individual client
        /// </summary>
        ///
        ///
        private async void HandleConnectionAsync(TcpClient tcpClient)
        {
            string clientInfo = tcpClient.Client.RemoteEndPoint.ToString();
            LogMessage(string.Format("Got connection request from {0}", clientInfo));
           
            try
            {
                using (var networkStream = tcpClient.GetStream())
                using (var reader = new StreamReader(networkStream))
                using (var writer = new StreamWriter(networkStream))
                {
                    writer.AutoFlush = true;
                    while (true)
                    {
                        string day = DateTime.Now.ToString("dd");
                        if (day != _day)
                        {
                            _day = day;
                            _dayCount = 1;
                            LogMessage("Starting day");
                        }
                        else
                            _dayCount++;
                        var dataFromServer = await reader.ReadLineAsync();
                        if (string.IsNullOrEmpty(dataFromServer))
                        {
                            break;
                        }
                        LogMessage("RECEIVED:" + dataFromServer);
                        await File.AppendAllTextAsync($"/media/seqFiles/{DateTime.Now.ToString("yyyyMMdd-HHmmss")} - {_dayCount.ToString("D2")}.txt", dataFromServer);
                        LogMessage("End Reception");
                    }
                }
            }
            catch (Exception exp)
            {
                LogMessage(exp.Message);
            }
            finally
            {
                LogMessage(string.Format("Closing the client connection - {0}",
                            clientInfo));
                tcpClient.Close();
            }

        }
        private void LogMessage(string message,
                                [CallerMemberName]string callername = "")
        {
            //File.WriteAllText("/root/bin/test.txt", string.Format("[{0}] - Thread-{1}- {2}", callername, Thread.CurrentThread.ManagedThreadId, message));
            System.Console.WriteLine("[{0}] - Thread-{1}- {2}",
                    callername, Thread.CurrentThread.ManagedThreadId, message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Values.ProjectName = Assembly.GetCallingAssembly().GetName().Name;
            Console.WriteLine(string.Join('-', args));
            int _listenerPort = Convert.ToInt32(args[0]);
            AsyncEchoServer async = new AsyncEchoServer(_listenerPort);
            async.Start();
            Thread.Sleep(Timeout.Infinite);
        }
    }
    public static class Values
    {
        public static string LabelPrinterAddress = "";
        public static string COD3 = "";
        public static string ProjectName = "";
    }
}
