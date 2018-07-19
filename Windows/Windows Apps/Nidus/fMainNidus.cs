using AccesoDatosNet;
using CommonTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nidus
{
    public partial class fMainNidus : Form
    {
        public fMainNidus(string[] args)
        {
            InitializeComponent();
            var espackArgs = CT.LoadVars(args);
            //Values.gDatos.DataBase = "Sistemas";//espackArgs.DataBase;
            //Values.gDatos.Server = "192.168.200.7";//espackArgs.Server;
            //Values.gDatos.User = "sa";//espackArgs.User;
            //Values.gDatos.Password = "5380"; //espackArgs.Password;
            Values.ProjectName = Assembly.GetCallingAssembly().GetName().Name;
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

        }

        private void docsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDocumentControl fdoc = new fDocumentControl();
            fdoc.Show();
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
