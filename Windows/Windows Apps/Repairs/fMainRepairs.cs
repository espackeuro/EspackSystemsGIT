using System.Windows.Forms;
using System.Reflection;
using System;
using AccesoDatosNet;
using CommonTools;
using CommonToolsWin;

namespace Repairs
{
    public partial class fMainRepairs : Form
    {
        public fMainRepairs(string[] args)
        {
            InitializeComponent();
            
            var espackArgs = CT.LoadVars(args);
            //Values.gDatos.DataBase = "Sistemas";//espackArgs.DataBase;
            //Values.gDatos.Server = "192.168.200.7";//espackArgs.Server;
            //Values.gDatos.User = "sa";//espackArgs.User;
            //Values.gDatos.Password = "5380"; //espackArgs.Password;
            Values.ProjectName = "Repairs";//Assembly.GetCallingAssembly().GetName().Name;
            Values.gDatos.DataBase = espackArgs.DataBase;
            Values.gDatos.Server = espackArgs.Server;
            Values.gDatos.User = espackArgs.User;
            Values.gDatos.Password = espackArgs.Password;

            this.Text = string.Format("{0} Build {1} - ({2:yyyyMMdd})*", Values.ProjectName, Assembly.GetExecutingAssembly().GetName().Version.ToString(), CT.GetBuildDateTime(Assembly.GetExecutingAssembly()));
            try
            {
                Values.gDatos.Connect();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error connecting to database: " + e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            Values.gDatos.Close();
            // check settings file
            if (!cSettings.SettingFileNameExists)
            {
                fSettings fSettings = new fSettings();
                fSettings.ShowDialog();
            }
            Values.LabelPrinterAddress = cSettings.readSetting("labelPrinter");
            Values.COD3 = cSettings.readSetting("COD3");
            Text = string.Format("{0} - {1} Warehouse", Program.VersionNumber, Values.COD3);

        }

    }

    public static class Values
    {
        public static cAccesoDatosNet gDatos = new cAccesoDatosNet();
        public static string LabelPrinterAddress = "";
        public static string COD3 = "";
        public static string ProjectName = "";
    }
}
