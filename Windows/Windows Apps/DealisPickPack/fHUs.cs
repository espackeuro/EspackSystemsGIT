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
            CTLM.AddItem(cboRoute, "Route", true, true, true, 0, false, true);

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
            CTLM.btnUpp.Enabled = false;
            CTLM.AddItem(VS);
            CTLM.Start();
        }

    }
}
