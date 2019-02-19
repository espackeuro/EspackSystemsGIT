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


        static void Main(string[] args)
        {
            if (args.Count() == 0)
                args = new string[] { /*"NEXTCLOUD=nextcloud.espackeuro.com", */"DOMAIN=sauron.systems.espackeuro.com", "DATABASE=DB01B.local", "EXCHANGE=exchange01.systems.espackeuro.com" };


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
            Values.conn.ConnectionString = new SqlConnectionStringBuilder()
            {
                InitialCatalog = Values.DataBase,
                UserID = Values.User,
                Password = Values.Password,
                DataSource = Values.DBServer
            }.ConnectionString;
            using (var _domains = new SqlDataAdapter("select domain from MAIL..domain where dbo.CheckFlag(flags,'FORWARD')=1 ", Values.conn))
            {
                DataTable T = new DataTable();
                _domains.Fill(T);
                Values.DomainList = T.Rows.OfType<DataRow>().Select(r => r["domain"].ToString()).ToList();
                //_domains.Close();
            }
            
            using (var _frs = new SqlDataAdapter("Select Codigo, DescFlagEng from flags where Servicio='SYNC' and Tabla='Users'", Values.conn))
            {
                DataTable T = new DataTable();
                _frs.Fill(T);
                Values.FlagsDefs = T.Rows.OfType<DataRow>().ToDictionary(dr => dr["Codigo"].ToString(), dr => dr["DescFlagEng"].ToString());//.ToList().Select(fr => new KeyValuePair<string,string>(fr["Codigo"].ToString(), fr["DescFlagEng"].ToString())).ToDictionary<string,string>;
            }
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
        }
    }
}
