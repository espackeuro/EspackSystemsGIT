using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using CommonTools;
using MasterClass;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using ConsoleTools;

namespace EspackSyncService
{
    public static class Values
    {
        public static string User { get => "procesos"; }
        public static string Password { get => "*seso69*"; }
        public static string DataBase { get => "SISTEMAS"; }
        public static string DBServer { get; set; } = "";
        public static SqlConnection conn { get; set; } = new SqlConnection();
        public static byte[] MasterPassword = MasterClass.MasterPassword.MasterBytes;
        public static Dictionary<string, string> Servers = new Dictionary<string, string>();
#if DEBUG
        public static int PollingTime { get; set; } = 5;
#else
        public static int PollingTime { get; set; } = 60;

#endif

        public static List<string> DomainList { get; set; }
        public static Dictionary<string, string> FlagsDefs { get; set; } = new Dictionary<string, string>();
    }
    static class Program
    {
#if DEBUG
        public static bool Debug = true;
#else
        public static bool Debug = false;
#endif
        static void Main(string[] args)
        {

            string _stage = "Unknown Error";
            string _myName = System.Reflection.Assembly.GetCallingAssembly().GetName().Name;

            try
            {
                Console.WriteLine($"----==== Starting [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");

                // If the settings file exists, the params will be loaded from it
                _stage = "Loading settings file";
                Console.Write("> Loading settings file... ");
                string[] _lines = File.ReadAllLines((cMiscTools.RunningOS == "Windows" ? Directory.GetCurrentDirectory().Substring(0, 3) : $"/media/bin/{_myName}/") + $"C# Apps Settings\\{_myName}.settings", (Debug)?Encoding.Unicode:Encoding.Default);

                //
                _stage = "Creating Parameters object";
                cParameters _params = new cParameters();

                //
                _stage = "Getting settings from file";
                _params.LoadParameters(_lines);

                // Just in case there are no data for some or all the mandatory parameters
                _stage = "Processing parameters";
                _params.DBServer = String.IsNullOrEmpty(_params.DBServer) ? "DB01B" : _params.DBServer;
                _params.DBUser = String.IsNullOrEmpty(_params.DBUser) ? "procesos" : _params.DBUser;
                _params.DBPassword = String.IsNullOrEmpty(_params.DBPassword) ? "*seso69*" : _params.DBPassword;
                _params.DBDataBase = String.IsNullOrEmpty(_params.DBDataBase) ? "SISTEMAS" : _params.DBDataBase;
                _params.DBTimeOut = _params.DBTimeOut == null ? 300 : _params.DBTimeOut;
                _params.DomainServer = String.IsNullOrEmpty(_params.DomainServer) ? "sauron.systems.espackeuro.com" : _params.DomainServer;
                _params.ExchangeServer = String.IsNullOrEmpty(_params.ExchangeServer) ? "exchange01.systems.espackeuro.com" : _params.ExchangeServer;

                // Create the tuple which contains each server type and its value
                //args = new string[] { /*"NEXTCLOUD=nextcloud.espackeuro.com", */"DOMAIN=sauron.systems.espackeuro.com", "DATABASE=DB01B.local", "EXCHANGE=exchange01.systems.espackeuro.com" };
                args = new string[] { $"DOMAIN={_params.DomainServer}", $"DATABASE={_params.DBServer}.local", $"EXCHANGE={_params.ExchangeServer}" };
                _stage = "Creating servers tuple";
                args.ToList().ForEach(server =>
                {
                    var tupla = server.Split('=');
                    Values.Servers.Add(tupla[0], tupla[1]);
                });
                Values.DBServer = Values.Servers["DATABASE"];

                //Values.gDatos.Server = Values.Servers["DATABASE"];
                //Values.gDatos.context_info = MasterPassword.MasterBytes;
                //Values.gDatos.TimeOut = 300;
                //Values.gDatos.Connect();
                _stage = "Defining SQL Connection string";
                Values.conn.ConnectionString = new SqlConnectionStringBuilder()
                {
                    InitialCatalog = Values.DataBase,
                    UserID = Values.User,
                    Password = Values.Password,
                    DataSource = Values.DBServer
                }.ConnectionString;

                //
                _stage = "Getting mail domains";
                using (var _domains = new SqlDataAdapter("select domain from MAIL..domain where dbo.CheckFlag(flags,'FORWARD')=1 ", Values.conn))
                {
                    DataTable T = new DataTable();
                    _domains.Fill(T);
                    Values.DomainList = T.Rows.OfType<DataRow>().Select(r => r["domain"].ToString()).ToList();
                    //_domains.Close();
                }

                //
                _stage = "Getting sync flags";
                using (var _frs = new SqlDataAdapter("Select Codigo, DescFlagEng from flags where Servicio='SYNC' and Tabla='Users'", Values.conn))
                {
                    DataTable T = new DataTable();
                    _frs.Fill(T);
                    Values.FlagsDefs = T.Rows.OfType<DataRow>().ToDictionary(dr => dr["Codigo"].ToString(), dr => dr["DescFlagEng"].ToString());//.ToList().Select(fr => new KeyValuePair<string,string>(fr["Codigo"].ToString(), fr["DescFlagEng"].ToString())).ToDictionary<string,string>;
                }

                //
                _stage = "Creating service object";
                if (Environment.UserInteractive)
                {
                    SyncServiceClass service1 = new SyncServiceClass(args);
                    service1.TestStartupAndStop(args);
                }
                else
                {
                    // Put the body of your old Main method here.  

                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[]
                    {
                        new SyncServiceClass(args)
                    };
                    ServiceBase.Run(ServicesToRun);
                }

            } catch(Exception ex)
            {
                Console.WriteLine($"[Main#{_stage}] {ex.Message}");
                return;
            }
        }
    }
}
