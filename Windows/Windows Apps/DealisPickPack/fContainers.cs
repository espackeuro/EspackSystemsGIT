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
using System.Threading;
using System.Data.SqlClient;

namespace DealerPickPack
{
    public partial class fContainers : Form
    {
        public fContainers()
        {
            InitializeComponent();

            // Fill the routes combo
            cboRoute.ParentConn = Values.gDatos;
            cboRoute.Source($"select RouteCode='' union all Select RouteCode from MasterRoutes where cod3='{Values.COD3}' order by RouteCode");

            //CTLM Definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "pContainersCabAdd";
            CTLM.sSPUpp = "pContainersCabUpp";
            CTLM.sSPDel = "pContainersCabDel";
            CTLM.DBTable = "(Select * from ContainersCab where cod3='" + Values.COD3 + "') a";

            //Header
            CTLM.AddItem(txtContainer, "ContainerCode", false, false, true, 1, true, true);
            CTLM.AddItem(Values.COD3, "cod3", false, false, true, 0, false, true);
            CTLM.AddItem(cboRoute, "Route", false,false, false, 0, false, true);
            CTLM.AddItem(txtInDelivery, "InDelivery", false, false, false, 0, false, false);
            CTLM.AddItem(txtInDeliveryDate, "InDeliveryDate", false, false, false, 0, false, true);

            //VS Definitions
            VS.Conn = Values.gDatos;
            VS.sSPAdd = "";
            VS.sSPUpp = "";
            VS.sSPDel = "pContainersDetDel";
            VS.DBTable = "ContainersDet";

            //VS Details
            VS.AddColumn("ContainerCode", txtContainer, pVisible: false);
            VS.AddColumn("HU", "HU");
            VS.AddColumn("cod3", "cod3", pVisible: false);

            //Various
            CTLM.AddDefaultStatusStrip();
            CTLM.AddItem(VS);
            CTLM.Start();
        }
    }
}
