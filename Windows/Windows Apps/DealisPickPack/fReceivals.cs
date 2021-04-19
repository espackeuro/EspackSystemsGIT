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
using DiverseControls;

namespace DealerPickPack
{
    public partial class fReceivals : Form
    {
        public fReceivals()
        {
            
            InitializeComponent();

            //CTLM Definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "";
            CTLM.sSPUpp = "";
            CTLM.sSPDel = "";
            CTLM.DBTable = "(Select * from ReceivalsCab where cod3='" + Values.COD3 + "') a";

            //Header
            CTLM.AddItem(txtReceival, "ReceivalCode", false, false, false, 1, false, true);
            CTLM.AddItem(txtDate, "Date", false,false,false, 1,false,false);
            CTLM.AddItem(Values.COD3, "cod3", false, false, false, 1, false, true);

            //VS Definitions
            VS.Conn = Values.gDatos;
            VS.sSPAdd = "";
            VS.sSPUpp = "";
            VS.sSPDel = "";
            VS.DBTable = "ReceivalsDet";

            //VS Details
            VS.AddColumn("ReceivalCode", txtReceival, pVisible: false);
            VS.AddColumn("cod3", "cod3", pVisible: false);
            VS.AddColumn("Line", "Line");
            VS.AddColumn("Dealer", "Dealer");
            VS.AddColumn("Description", "DealerDesc");
            VS.AddColumn("OrderNumber", "OrderNumber");
            VS.AddColumn("OrderItemNumber", "OrderItemNumber");
            VS.AddColumn("Finis", "Finis");
            VS.AddColumn("Qty", "Qty");
            VS.AddColumn("QtyPending", "QtyPending");
            VS.AddColumn("Route", "Route");
            VS.AddColumn("TrafficArea", "TrafficArea");

            //Various
            CTLM.AddDefaultStatusStrip();
            CTLM.AddItem(VS);
            CTLM.Start();

        }
    }
}
