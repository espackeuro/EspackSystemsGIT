using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatosNet;
using CommonToolsWin;
using DiverseControls;
using RawPrinterHelper;


namespace DealerPickPack
{
    public partial class fDeliveries : Form
    {

        public string Delivery
        {
            get
            {
                return txtDelivery.Text;
            }
        }

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
            Program.fDeliveries = this;
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
        private void btnPrint_Click(object sender, EventArgs e)
        {

            using (var _rs = new StaticRS(string.Format("select dc.Route,ClosedDate=convert(varchar(10),dc.ClosedDate,103),dc.Plate,dc.CarrierDesc from DeliveriesCab dc inner join DeliveriesDet dd on dd.DeliveryCode=dc.DeliveryCode and dd.cod3=dc.cod3 where dc.DeliveryCode='{0}' and dc.cod3='{1}'", txtDelivery.Text, Values.COD3), Values.gDatos))
            {
                _rs.Open();
                if (_rs.RecordCount == 0) return;

                // Refresh the form data from DB values
                cboRoute.Text = _rs["Route"].ToString();
                txtClosedDate.Text = _rs["ClosedDate"].ToString();
                txtPlate.Text = _rs["Plate"].ToString();
                txtCarrierDescription.Text = _rs["CarrierDesc"].ToString();
            }

            SetFormEnabled(false);
            using (var pd = new PrintDialog())
            {
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    using (var _printIt = new PrintDelivery())
                    {
                        // Copy values into the object properties & print
                        _printIt.DeliveryCode = txtDelivery.Text;
                        _printIt.Route = cboRoute.Text;
                        _printIt.ClosedDate = txtClosedDate.Text.Substring(0,10);
                        _printIt.Plate = txtPlate.Text;
                        _printIt.CarrierDesc = txtCarrierDescription.Text;
                        _printIt.PrinterSettings = pd.PrinterSettings;
                        pd.Document = _printIt;
                        _printIt.Print();
                    }
                }
            }
            SetFormEnabled(true);
        }
        private void SetFormEnabled(bool pValue)
        {
            Cursor.Current = pValue ? Cursors.Default : Cursors.WaitCursor;
            //(from Control control in this.Controls select control).ToList().ForEach(x => x.Enabled = pValue);
            this.Controls.Cast<Control>().ToList().ForEach(x => x.Enabled = pValue);
        }
    }
    public class PrintDelivery : EspackPrintDocument
    {
        private bool FirstPage { get; set; } = true;
        public string DeliveryCode { get; set; }
        public string Route { get; set; }
        public string ClosedDate { get; set; }
        public string Plate { get; set; }
        public string CarrierDesc { get; set; }

        // On each printed page...
        protected override void OnPrintPage(PrintPageEventArgs e)
        {

            Graphics graphics = e.Graphics;

            // Only on first page
            if (FirstPage)
            {
                Header();
                BodyXOffset = 20;
                Body();
                Footer();
                PageCounter = 1;
                FirstPage = false;
            }
            
            // Base code
            base.OnPrintPage(e);
        }

        // Each area of the document

        // Header
        private void Header()
        {
            // Set font 
            this.CurrentFont = new Font("Courier New", 22, FontStyle.Bold);

            // Add header lines
            NewLine(false, EnumDocumentParts.HEADER);
            Add(string.Format("DEALER PICK PACK LIST"));

            // Set font 
            //this.CurrentFont = new Font("Courier New", 15, FontStyle.Bold);
            NewLine(false, EnumDocumentParts.HEADER);
            //Add(string.Format("DELIVERY: {0,-12} ROUTE: {1,-8} DATE: {2,-10}", Program.fDeliveries.Delivery, _rs["Route"], _rs["ClosedDate"]));
            Add("DELIVERY:", new Font("Courier New", 15, FontStyle.Bold));
            Add($"{DeliveryCode,-10}", new Font("Courier New", 15, FontStyle.Regular));
            Add("ROUTE:", new Font("Courier New", 15, FontStyle.Bold));
            Add($"{Route,-8}", new Font("Courier New", 15, FontStyle.Regular));
            Add("DATE:", new Font("Courier New", 15, FontStyle.Bold));
            Add($"{(ClosedDate==""?"NOT CLOSED":ClosedDate),-10}", new Font("Courier New", 15, FontStyle.Regular));

            NewLine(false, EnumDocumentParts.HEADER);
            //                    Add(string.Format("   PLATE: {0,-10} CARRIER: {1}", _rs["Plate"], _rs["CarrierDesc"]));
            Add("   PLATE:", new Font("Courier New", 15, FontStyle.Bold));
            Add($"{Plate,-10}", new Font("Courier New", 15, FontStyle.Regular));
            Add("CARRIER:", new Font("Courier New", 15, FontStyle.Bold));
            Add($"{CarrierDesc}", new Font("Courier New", 15, FontStyle.Regular));

            // Separator
            this.CurrentFont = new Font("Courier New", 12, FontStyle.Regular);
            NewLine(false, EnumDocumentParts.HEADER);
        }

        // Footer
        private void Footer()
        {
            // Set font
            this.CurrentFont = new Font("Courier New", 12, FontStyle.Bold);

            // Add footer lines
            NewLine(false, EnumDocumentParts.FOOTER);
        }

        // Body
        public void Body()
        {
            // Loop through each row of the recordset
            using (var _rs = new StaticRS(string.Format("select dd.HU,dd.InContainer,hd.Finis,hd.qty from DeliveriesDet dd inner join HUDet hd on hd.HU=dd.HU and hd.cod3=dd.cod3 where dd.DeliveryCode='{0}' and dd.cod3='{1}' order by dd.InContainer,dd.HU,hd.finis", Program.fDeliveries.Delivery, Values.COD3), Values.gDatos))
            {
                _rs.Open();
                if (_rs.RecordCount != 0)
                {
                    // Set font & add column names
                    this.CurrentFont = new Font("Courier New", 12, FontStyle.Bold);
                    NewLine(true);
                    Add(string.Format(" {0,-12} {1,-10} {2,-7} {3,5} ", "HU", "CONTAINER", "FINIS", "QTY"));

                    // Set font & add data lines
                    this.CurrentFont = new Font("Courier New", 12, FontStyle.Regular);
                    while (!_rs.EOF)
                    {
                        NewLine(true);
                        Add(string.Format(" {0,-12} {1,-10} {2,-7} {3,5:G} ", _rs["HU"], _rs["INCONTAINER"], _rs["FINIS"], _rs["QTY"]));
                        _rs.MoveNext();
                    }
                }
            }
        }
    }


}
