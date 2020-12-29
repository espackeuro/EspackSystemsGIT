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

            //CTLM Definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "";
            CTLM.sSPUpp = "";
            CTLM.sSPDel = "pHUCabDel";
            CTLM.DBTable = "(Select * from HUCab where cod3='" + Values.COD3 + "') a";

            //Header
            CTLM.AddItem(txtHU, "HU", false, false, true, 1, true, true);
            CTLM.AddItem(txtDealer, "Dealer", false, false, false, 0, false, true);
            CTLM.AddItem(cboRoute, "Route", false, false, false, 0, false, true);

            //empty header values
            //CTLM.AddItem("", "transportista", true, true, false, 0, false, false);
            //CTLM.AddItem("", "matricula", true, true, false, 0, false, false);
            //CTLM.AddItem("@@@", "conductor", true, true, false, 0, false, false);
            //CTLM.AddItem("", "documento_aduana", true, true, false, 0, false, false);
            //CTLM.AddItem("01/01/2001 00:00", "fecha_doc_proveedor", true, true, false, 0, false, false);

            //fields
            //cboServicio.Source("Select Codigo,Nombre from Servicios where dbo.CheckFlag(flags,'SIMPLE')=1 and cod3='" + Values.COD3 + "' order by codigo", txtDesServicio);
            //cboServicio.SelectedValueChanged += CboServicio_SelectedValueChanged;
            //lstFlags.Source("Select codigo,DescFlagEng from flags where Tabla='Cab_Recepcion'");



            //VS Definitions
            VS.Conn = Values.gDatos;
            VS.sSPAdd = "";
            VS.sSPUpp = "";
            VS.sSPDel = "pHUDetDel";
            VS.DBTable = "HUDet";

            //VS Details
            VS.AddColumn("HU", txtHU, "", "", "@HU", pVisible: false);
            VS.AddColumn("cod3", "cod3", "", "", "@cod3", pVisible: false);
            VS.AddColumn("FINIS", "Finis", "", "", "");
            VS.AddColumn("Qty", "qty", "","","");

            //Various
            CTLM.AddDefaultStatusStrip();
            CTLM.AddItem(VS);
            CTLM.Start();
            CTLM.AfterButtonClick += CTLM_AfterButtonClick; ;

        }

        private void CTLM_AfterButtonClick(object sender, EspackFormControlsNS.CTLMEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
