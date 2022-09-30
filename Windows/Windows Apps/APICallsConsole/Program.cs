using System;
using System.Reflection;
using System.Windows.Forms;
using CommonTools;
using CommonToolsWin;
using AccesoDatosNet;

namespace APICallsConsole
{
    class Program
    {
        public static fMain fMain { get; set; }

        public static string VersionNumber
        {
            get
            {
                return string.Format("{0} Build {1} - ({2:yyyyMMdd})*", Values.ProjectName, Assembly.GetExecutingAssembly().GetName().Version.ToString(), CT.GetBuildDateTime(Assembly.GetExecutingAssembly()));
            }
        }

        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new frmSplash(args).ShowDialog();

            fMain = new fMain(args);
            Application.Run(fMain);
        }


    }

    public static class Values
    {
        public static cAccesoDatosNet gDatos = new cAccesoDatosNet();
        public static string LabelPrinterAddress = "";
        public static string COD3 = "NIT";
        public static string ProjectName = "Web API Communications";
    }
}
