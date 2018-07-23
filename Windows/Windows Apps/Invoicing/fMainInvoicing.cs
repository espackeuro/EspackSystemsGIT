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

namespace Invoicing
{
    public partial class fMainInvoicing : Form
    {
        public fMainInvoicing(string[] args)
        {
            InitializeComponent();
            this.Text = string.Format("Invoicing Build {0} - ({1:yyyyMMdd})*", Assembly.GetExecutingAssembly().GetName().Version.ToString(), CT.GetBuildDateTime(Assembly.GetExecutingAssembly()));
            var espackArgs = CT.LoadVars(args);
            Values.ProjectName = Assembly.GetCallingAssembly().GetName().Name;
            Values.gDatos.DataBase = espackArgs.DataBase;
            Values.gDatos.Server = espackArgs.Server;
            Values.gDatos.User = espackArgs.User;
            Values.gDatos.Password = espackArgs.Password;
        }

        private void kkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var p = new fCustomers();
            p.Show();
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
