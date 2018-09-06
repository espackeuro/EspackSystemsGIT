using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EspackFormControlsNS;
using static Invoicing.Values;


namespace Invoicing
{
    public partial class fSuppliers : Form
    {
        public fSuppliers()
        {
            InitializeComponent();

            //CTLM definitions
            CTLM.Conn = gDatos;
            CTLM.sSPAdd = "pMasterSuppliersAdd";
            CTLM.sSPUpp = "pMasterSuppliersUpp";
            CTLM.sSPDel = "pMasterSuppliersDel";
            CTLM.AddItem(txtCode, "SupplierCode", CTLMControlTypes.PK);
            CTLM.AddItem(txtDescription, "Description", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(cboInternalCompanyCode, "InternalCompanyCode", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(cboCOD3, "Cod3", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(lstFlags, "Flags", CTLMControlTypes.AddUppNoSearch);

            CTLM.AddDefaultStatusStrip();
            CTLM.DBTable = "MasterSuppliers";
            CTLM.ReQuery = true;

            lstFlags.Source("Select codigo,DescFlagEng from flags where Tabla='MasterCustomers'");
            cboInternalCompanyCode.Source("select InternalCompanyCode,Name from InternalCompanies order by InternalCompanyCode", txtInternalCompanyDescription);
            cboInternalCompanyCode.ValueChanged += CboInternalCompanyCode_ValueChanged;
            cboCOD3.Source(string.Format("select distinct MainCod3,BranchName from InternalCompanyBranches where InternalCompanyCode='{0}' order by MainCod3",cboInternalCompanyCode.Value), txtCOD3Description);

            CTLM.Start();
        }

        private void CboInternalCompanyCode_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            cboCOD3.Text = "";
            txtCOD3Description.Text = "";
            cboCOD3.Source(string.Format("select distinct MainCod3,BranchName from InternalCompanyBranches where InternalCompanyCode='{0}' order by MainCod3", cboInternalCompanyCode.Value), txtCOD3Description);
        }

    }
}
