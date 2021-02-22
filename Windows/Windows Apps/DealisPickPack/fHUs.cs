using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatosNet;
using CommonToolsWin;
using EspackDataGridView;
using EspackClasses;
using RawPrinterHelper;
using System.Threading;
using System.Data.SqlClient;

namespace DealerPickPack
{
    public partial class fHUs : Form
    {
        public fHUs()
        {
            InitializeComponent();

            // Fill the routes combo
            cboRoute.ParentConn = Values.gDatos;
            cboRoute.Source($"select RouteCode='' union all Select RouteCode from MasterRoutes where cod3='{Values.COD3}' order by RouteCode");

            //CTLM Definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "";
            CTLM.sSPUpp = "";
            CTLM.sSPDel = "pHUCabDel";
            CTLM.DBTable = "(Select * from HUCab where cod3='" + Values.COD3 + "') a";

            //Header
            CTLM.AddItem(txtHU, "HU", false, false, true, 1, true, true);
            CTLM.AddItem(Values.COD3, "cod3", false, false, true, 0, false, true);
            CTLM.AddItem(txtDate, "Date", false, false, false, 0, false, false);
            CTLM.AddItem(txtDealer, "Dealer", false, false, false, 0, false, true);
            CTLM.AddItem(cboRoute, "Route", false,false, false, 0, false, true);

            //VS Definitions
            VS.Conn = Values.gDatos;
            VS.sSPAdd = "";
            VS.sSPUpp = "";
            VS.sSPDel = "";
            VS.DBTable = "HUDet";

            //VS Details
            VS.AddColumn("HU", txtHU, pVisible: false);
            VS.AddColumn("cod3", "cod3", pVisible: false);
            VS.AddColumn("FINIS", "Finis");
            VS.AddColumn("QTY", "qty");

            //Various
            CTLM.AddDefaultStatusStrip();
            CTLM.AddItem(VS);
            CTLM.Start();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtHU.Text!="")
            {

                string _printerAddress = Values.LabelPrinterAddress.ToString();
                int _printerResolution;

                // Get settings for the printer
                using (var _RS = new DynamicRS(string.Format("select descripcion,cmp_varchar,cmp_integer from ETIQUETAS..datosEmpresa where codigo='{0}'", Values.LabelPrinterAddress), Values.gDatos))
                {
                    _RS.Open();
                    _printerAddress = _RS["cmp_varchar"].ToString(); // "\\\\valsrv02\\VALLBLPRN003"; 
                    _printerResolution = Convert.ToInt32(_RS["cmp_integer"]);
                }

                // Create and configurate label
                var _HULabel = new DealerPickPackHULabel(new ZPLLabel(70, 32, 3, _printerResolution));
                using (var _printer = new cRawPrinterHelper(_printerAddress))
                {
                    _HULabel.Parameters["HU"] = txtHU.Text;
                    _HULabel.Parameters["ROUTE"] =cboRoute.Text;
                    _HULabel.Parameters["DEALER"] = txtDealer.Text;
                    _printer.SendUTF8StringToPrinter(_HULabel.ToString(), 1);
                }
            }
        }
    }
}
