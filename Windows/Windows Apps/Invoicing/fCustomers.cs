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
            CTLM.sSPAdd = "pMasterCustomersAdd";
            CTLM.sSPUpp = "pMasterCustomersUpp";
            CTLM.sSPDel = "pMasterCustomersDel";
            CTLM.AddItem(txtCode, "CustomerCode", CTLMControlTypes.NoAddPK);
            CTLM.AddItem(txtName, "Name", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtAddress, "Address", CTLMControlTypes.AddUppNoSearch);
            CTLM.AddItem(txtPostalCode, "PostalCode", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtTown, "Town", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtCountyProv, "CountyProv", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(cboCountryCode, "CountryCode", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtVATNumber, "VATNumber", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(cboPaymentCode, "PaymentCode", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtDueDays, "DueDays", CTLMControlTypes.AddUppNoSearch);
            CTLM.AddItem(cboSupplierCode, "SupplierCode", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtVAT, "VAT", CTLMControlTypes.AddUppNoSearch);
            CTLM.AddItem(cboCurrency, "Currency", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtIBAN, "IBAN", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtShipHolder, "ShipHolder", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtShipAddress, "ShipAddress", CTLMControlTypes.AddUppNoSearch);
            CTLM.AddItem(txtShipPostalCode, "ShipPostalCode", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtShipTown, "ShipTown", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtShipCountyProv, "ShipCountyProv", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(cboShipCountryCode, "ShipCountryCode", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtShipVATNumber, "ShipVATNumber", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(lstFlags, "Flags", CTLMControlTypes.AddUppNoSearch);
            //CTLM.AddItem("", "ExtraData", CTLMControlTypes.AddUppNoSearch);

            CTLM.AddDefaultStatusStrip();
            CTLM.DBTable = "MasterCustomers";
            CTLM.ReQuery = true;

            lstFlags.Source("Select codigo,DescFlagEng from flags where Tabla='MasterCustomers'");
            cboCountryCode.Source("select Codigo_Alfa3,Pais_EN from general..paises where codigo_alfa3 is not null order by Pais_EN", txtCountryCodeDescription);
            cboShipCountryCode.Source("select Codigo_Alfa3,Pais_EN from general..paises where codigo_alfa3 is not null order by Pais_EN", txtShipCountryCodeDescription);
            cboSupplierCode.Source("select SupplierCode,Description from MasterSuppliers order by SupplierCode", txtSupplierCodeDescription);
            cboPaymentCode.Source("select PaymentCode,Description from MasterPaymentCodes order by PaymentCode", txtPaymentCodeDescription);
            cboCurrency.Source("select Currency,CurrencyName from MasterCurrencyCodes order by Currency", txtCurrencyDescription);

            CTLM.Start();

        }
    }
}
