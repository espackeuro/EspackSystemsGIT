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

namespace DealerPickPack
{
    public partial class fDeliveries : Form
    {
        public fDeliveries()
        {
            InitializeComponent();

            // Fill the routes combo
            cboRoute.ParentConn = Values.gDatos;
            cboRoute.Source($"select RouteCode from MasterRoutes where cod3='{Values.COD3}' order by RouteCode");

            // Fill the carriers combo
            cboCarrier.ParentConn = Values.gDatos;
            cboCarrier.Source($"select Codigo,Descripcion from GENERAL..transportistas where CarrierId is not null order by Codigo",txtCarrierDescription);

            //CTLM Definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "pDeliveriesCabAdd";
            CTLM.sSPUpp = "pDeliveriesCabUpp";
            CTLM.sSPDel = "pDeliveriesCabDel";
            CTLM.DBTable = "(Select * from DeliveriesCab where cod3='" + Values.COD3 + "') a";

            //Header
            CTLM.AddItem(txtDelivery, "DeliveryCode", false, true, true, 0, true, true);
            CTLM.AddItem(txtPlate, "Plate", true, true, false, 0, false, true);
            CTLM.AddItem(cboRoute, "Route", true, true, false, 0, false, true);
            CTLM.AddItem(txtDate, "xfec", false, false, false, 1, false, true);
            CTLM.AddItem(txtClosedDate, "ClosedDate", false, false, false, 0, false, false);
            CTLM.AddItem(cboCarrier, "CarrierCode", true, true, false, 0, false, false);
            CTLM.AddItem(txtCarrierDescription, "CarrierDesc", false, false, false, 0, false, false);
            CTLM.AddItem(Values.COD3, "cod3", true, true, true, 0, false, true);
            
            //VS Definitions
            VS.Conn = Values.gDatos;
            VS.sSPAdd = "";
            VS.sSPUpp = "";
            VS.sSPDel = "pDeliveriesDetDel";
            VS.DBTable = "vDeliveriesCabDet";

            //VS Details
            VS.AddColumn("DeliveryCode", txtDelivery,pSPDel:"@DeliveryCode", pVisible: false);
            //VS.AddColumn("DeliveryCode", txtDelivery, "@DeliveryCode", "", "@DeliveryCode", pVisible: false);
            
            VS.AddColumn("HU", "HU", pSPDel: "@HU");
            VS.AddColumn("Type", "HUType", pSPDel: "@HU");
            VS.AddColumn("Finis", "Finis");
            VS.AddColumn("Qty", "Qty");
            VS.AddColumn("Dealer", "Dealer");
            VS.AddColumn("InContainer", "InContainer");
            VS.AddColumn("cod3", "cod3", pSPDel: "@cod3",pVisible: false);

            //Various
            CTLM.AddDefaultStatusStrip();
            CTLM.AddItem(VS);
            CTLM.Start();
            CTLM.AfterButtonClick += CTLM_AfterButtonClick; ;

        }

        private void CTLM_AfterButtonClick(object sender, EspackFormControlsNS.CTLMEventArgs e)
        {
            VS.Size = new Size(491, 240);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (txtDelivery.Text != "")
            {
                if (txtClosedDate.Text.Trim()!="")
                {
                    CTWin.MsgError("The delivery is already closed.");
                    return;
                }
                if (MessageBox.Show("This action can't be undone. Are you sure?", "Close Delivery", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (var _sp = new SP(Values.gDatos, "pDeliveryClose"))
                    {
                        _sp.AddParameterValue("@DeliveryCode", txtDelivery.Value.ToString());
                        _sp.AddParameterValue("@cod3", Values.COD3);
                        try
                        {
                            _sp.Execute();
                        }
                        catch (Exception ex)
                        {
                            CTWin.MsgError(ex.Message);
                            return;
                        }
                        if (_sp.LastMsg.Substring(0, 2) != "OK")
                        {
                            CTWin.MsgError(_sp.LastMsg);
                            return;
                        }
                    }
                    using (var _rs = new StaticRS(string.Format("select ClosedDate from DeliveriesCab where DeliveryCode='{0}' and cod3='{1}'", txtDelivery.Text,Values.COD3), Values.gDatos))
                    {
                        _rs.Open();
                        if (_rs.RecordCount != 0)
                        {
                            txtClosedDate.Text = _rs["ClosedDate"].ToString();
                        }
                    }
                    MessageBox.Show("Delivery closed correctly.", "Close Delivery", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
