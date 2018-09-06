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
    public partial class fCurrencies : Form
    {
        public fCurrencies()
        {
            InitializeComponent();

            //CTLM definitions
            CTLM.Conn = gDatos;
            CTLM.sSPAdd = "pMasterCurrenciesAdd";
            CTLM.sSPUpp = "pMasterCurrenciesUpp";
            CTLM.sSPDel = "pMasterCurrenciesDel";
            CTLM.AddItem(txtCurrency, "Currency", CTLMControlTypes.PK);
            CTLM.AddItem(txtName, "CurrencyName", CTLMControlTypes.AddUppSearch);

            CTLM.AddItem(txtExchangeRate, "ExchangeRate", CTLMControlTypes.AddUppNoSearch);
            CTLM.AddItem(txtSymbol, "Symbol", CTLMControlTypes.AddUppSearch);

            CTLM.AddItem(txtUpdateDate, "UpdateDate");


            CTLM.AddDefaultStatusStrip();
            CTLM.DBTable = "MasterCurrencies";
            CTLM.ReQuery = true;
            CTLM.Start();
        }
    }
}
