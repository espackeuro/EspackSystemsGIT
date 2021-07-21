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

            // Fill the routes and HU types combo
            cboRoute.ParentConn = Values.gDatos;
            cboRoute.Source($"select RouteCode='' union all Select RouteCode from MasterRoutes where cod3='{Values.COD3}' order by RouteCode");
            cboHUType.ParentConn = Values.gDatos;
            cboHUType.Source($"select distinct DealisPackCode,descripcion from SELECCION..bultoscm where dealispackcode is not null and len(codigo)<7 order by DealisPackCode", txtHUTypeDescription);
            cboHUType.Validated += CboHUType_Validated; 

            //CTLM Definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "pHUCabAdd";
            CTLM.sSPUpp = "";
            CTLM.sSPDel = "pHUCabDel";
            CTLM.DBTable = "(Select *,Type=HUType from HUCab where cod3='" + Values.COD3 + "') a";

            //Header
            CTLM.AddItem(txtHU, "HU", false, false, true, 1, true, true);
            CTLM.AddItem(Values.COD3, "cod3", true, false, true, 0, false, true);
            CTLM.AddItem(txtDate, "Date", false, false, false, 0, false, false);
            CTLM.AddItem(txtDealer, "Dealer", true, false, false, 0, false, true);
            CTLM.AddItem(cboRoute, "Route", true,false, false, 0, false, true);
            CTLM.AddItem(cboHUType, "Type", true, false, false, 0, false,false);

            //VS Definitions
            VS.Conn = Values.gDatos;
            VS.sSPAdd = "";
            VS.sSPUpp = "";
            VS.sSPDel = "pHUDetDel";
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


        private void CboHUType_Validated(object sender, EventArgs e)
        {
            if (cboHUType.ComboBox.FindStringExact(cboHUType.Text) == -1)
            {
                txtHUTypeDescription.Text = "";
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtHU.Text!="")
            {

                string _printerAddress = Values.LabelPrinterAddress.ToString();
                int _printerResolution;

                // Get settings for the printer
                using (var _RS = new DynamicRS($"select ValueString,ValueInteger from MiscData where Code='{Values.LabelPrinterAddress}' and cod3='{Values.COD3}'", Values.gDatos))
                {
                    _RS.Open();
                    _printerAddress = _RS["ValueString"].ToString(); // "\\\\valsrv02\\VALLBLPRN003"; 
                    _printerResolution = Convert.ToInt32(_RS["ValueInteger"]);
                }

                // Create and configurate label
                var _HULabel = new DealerPickPackHULabel(new ZPLLabel(70, 32, 3, _printerResolution));
                using (var _printer = new cRawPrinterHelper(_printerAddress))
                {
                    _HULabel.Parameters["HU"] = txtHU.Text;
                    _HULabel.Parameters["ROUTE"] =cboRoute.Text;
                    _HULabel.Parameters["DEALER"] = txtDealer.Text;
                    _HULabel.Parameters["TYPE"] = cboHUType.Text;
                    _HULabel.Parameters["DATE"] = txtDate.Text.Substring(0, 10);
                    _printer.SendUTF8StringToPrinter(_HULabel.ToString(), 1);
                }
            }
        }
    }
}
