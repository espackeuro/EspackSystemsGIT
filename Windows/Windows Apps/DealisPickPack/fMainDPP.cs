using AccesoDatosNet;
using CommonTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DealerPickPack
{
    public partial class fMainDPP : Form
    {
        public fMainDPP(string[] args)
        {
            InitializeComponent();

            var espackArgs = CT.LoadVars(args);
            Values.ProjectName = "DealerPickPack";
            Values.gDatos.DataBase = espackArgs.DataBase;
            Values.gDatos.Server = espackArgs.Server;
            Values.gDatos.User = espackArgs.User;
            Values.gDatos.Password = espackArgs.Password;

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
        
        private static Dictionary<string, Form> InstancedForms = new Dictionary<string, Form>();

        private object GetChildInstance(String pFormName)
        {
            Form _Form;
            if (!InstancedForms.TryGetValue(pFormName, out _Form))
            {
                _Form = (Form)Activator.CreateInstance(Type.GetType(Values.ProjectName + "." + pFormName));
                _Form.MdiParent = this;
                InstancedForms.Add(pFormName, _Form);
            }
            InstancedForms[pFormName].Show();
            InstancedForms[pFormName].WindowState = FormWindowState.Normal;
            InstancedForms[pFormName].FormClosed += delegate (object source, FormClosedEventArgs e)
            {
                InstancedForms.Remove(pFormName);
                //base.FormClosed(source, e);
            };
            return InstancedForms[pFormName];  //just created or created earlier.Return it+69
        }

        private void openForm(object menuOption)
        {
            var formName = ((ToolStripMenuItem)menuOption).Tag.ToString();
            var form = (Form)GetChildInstance(formName);
            form.WindowState = FormWindowState.Maximized;
        }

        private void pendingWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(sender);
        }

        private void husToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(sender);
        }

    }
    public static class Values
    {
        public static cAccesoDatosNet gDatos = new cAccesoDatosNet();
        public static string LabelPrinterAddress = "";
        public static string COD3 = "VAL";
        public static string ProjectName = "";
    }
}
