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

namespace DealisPickPack
{
    public partial class fMainDPP : Form
    {
        public fMainDPP(string[] args)
        {
            InitializeComponent();

            var espackArgs = CT.LoadVars(args);
            Values.ProjectName = "DealisPickPack";
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
            //check settings file
            //if (!cSettings.SettingFileNameExists)
            //{
            //    fSettings fSettings = new fSettings();
            //    fSettings.ShowDialog();
            //}
            //Values.LabelPrinterAddress = cSettings.readSetting("labelPrinter");
            //Values.COD3 = cSettings.readSetting("COD3");
            //Text = string.Format("{0} - {1} Warehouse", Program.VersionNumber, Values.COD3);
        }
        /*
        private void simpleReceivalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fSimpleReceivals fSimpleReceivals = new fSimpleReceivals();
            //fSimpleReceivals.MdiParent = this;
            //fSimpleReceivals.Show();
            openForm(sender);
            //fSimpleReceivals fSimpleReceivals = (fSimpleReceivals)GetChildInstance("fSimpleReceivals");
        }

        private void printRepairsUnitLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fPrintUnitLabels fPrintUnitLabels = new fPrintUnitLabels();
            //fPrintUnitLabels.Show();
            openForm(sender);
            //fPrintUnitLabels fPrintUnitLabels = (fPrintUnitLabels)GetChildInstance("fPrintUnitLabels");
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fSettings fSettings = new fSettings();
            //fSettings.ShowDialog();
            openForm(sender);
            //fSettings fSettings = (fSettings)GetChildInstance("fSettings");
        }

        private void printRackLabelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openForm(sender);
            //fRackLabels fRackLabels = (fRackLabels)GetChildInstance("fRackLabels");
            //fRackLabels fRackLabels = new fRackLabels();
            //fRackLabels.MdiParent = this;
            //fRackLabels.Show();
        }

        */
        //form opening control
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

        private void referencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fSimpleReferences fSimpleReferences = (fSimpleReferences)GetChildInstance("fSimpleReferences");
            openForm(sender);
        }
        /*
        private void simpleProductionOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fProductionOrders fProductionOrders = (fProductionOrders)GetChildInstance("fProductionOrders");
            openForm(sender);
        }

        private void simpleExpeditionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fSimpleDeliveriesEPC fSimpleExpeditions = (fSimpleDeliveriesEPC)GetChildInstance("fSimpleDeliveriesEPC");
            openForm(sender);
        }
        private void hSAReceivalsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //fHSAReceivals fHSAReceivals = (fHSAReceivals)GetChildInstance("fHSAReceivals");
            openForm(sender);
        }
        */
    }
    public static class Values
    {
        public static cAccesoDatosNet gDatos = new cAccesoDatosNet();
        public static string LabelPrinterAddress = "";
        public static string COD3 = "";
        public static string ProjectName = "";
    }
}
