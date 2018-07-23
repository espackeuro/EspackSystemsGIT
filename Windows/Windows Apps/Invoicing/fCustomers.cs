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
    public partial class fCustomers : Form
    {
        public fCustomers()
        {
            InitializeComponent();

            //CTLM definitions
            CTLM.Conn = gDatos;
            CTLM.sSPAdd = "PAdd_Clientes";
            CTLM.sSPUpp = "PUpp_Clientes";
            CTLM.sSPDel = "PDel_Clientes";
            CTLM.AddItem(txtCode, "Codigo", CTLMControlTypes.PK);
            CTLM.AddItem(txtName, "Nombre", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtAddress, "Direccion", CTLMControlTypes.AddUppNoSearch);
            CTLM.AddItem(txtTown, "Poblacion", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtPostalCode, "Codigo_Postal", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtCounty, "Provincia", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtVATNumber, "Cif", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtPaymentCode, "CPago", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtDueDays, "Dias_Vto", CTLMControlTypes.AddUppNoSearch);
            CTLM.AddItem(cboSupplierCode, "SupCod", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtVAT, "IVA", CTLMControlTypes.AddUppNoSearch);
            CTLM.AddItem(cboCurrencyCode, "Cod_Divisa", CTLMControlTypes.AddUppSearch);
         
            CTLM.AddDefaultStatusStrip();
            CTLM.DBTable = "vClientes";
            CTLM.ReQuery = true;

            cboSupplierCode.Source("select SupplierCode,Description from Suppliers order by SupplierCode", txtSupplierDescription);
            cboCurrencyCode.Source("select Codigo,Descripcion from Divisas order by Codigo", txtCurrencyDescription);
            CTLM.Start();

        }
    }
}
