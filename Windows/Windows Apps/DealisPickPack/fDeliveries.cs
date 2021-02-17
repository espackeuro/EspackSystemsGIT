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
            SetFormEnabled(false);
            using (var pd = new PrintDialog())
            {
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    using (var _printIt = new PrintPage())
                    {
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
    public class PrintPage : EspackPrintDocument
    {

        public string SQLParameterString { get; set; }
        public string SQLSelect { get; set; }
        private int PageNumber { get; set; } = 0;
        //public List<string> Groups { get; set; }
        public string group { get; set; }
        //PrintDocument pdoc  = null;

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            PageNumber++;
            Graphics graphics = e.Graphics;

            if (PageNumber == 1)
            {
                Header();
                this.CurrentFont = new Font("Courier New", 10);

                Body();

                //                Program.fMain.LabelsGrid.Print(this);
                Footer();
            }
            base.OnPrintPage(e);
        }

        private void Header()
        {

            this.CurrentFont = new Font("Courier New", 16, FontStyle.Bold);

            NewLine(false, EnumDocumentParts.HEADER);
            Add(string.Format("Parameters:"));
            NewLine(false, EnumDocumentParts.HEADER);
            //if (Program.fMain.ParametersGrid.RowCount == 0)
            //{
            //    Add(string.Format("{0}", Program.fMain.SQLParameterString.Replace(" WHERE ", "")));
            //    NewLine(false, EnumDocumentParts.HEADER);
            //}
            //else
            //{
            //    Program.fMain.ParametersGrid.ToList().ForEach(x =>
            //    {
            //        Add(string.Format("{0}={1}", x.Cells[0].Value, x.Cells[1].Value));
            //        NewLine(false, EnumDocumentParts.HEADER);
            //    });
            //}
            //if (Program.fMain.SQLGroup != "")
            //{
            //    Add(string.Format("{0}={1}", Program.fMain.GroupsGrid.Columns[0].HeaderCell.Value.ToString(), Program.fMain.GroupsGrid.CurrentCell.Value.ToString()));
            //    NewLine(false, EnumDocumentParts.HEADER);
            //}
        }

        private void Footer()
        {
            this.CurrentFont = new Font("Courier New", 12, FontStyle.Bold);
            NewLine(false, EnumDocumentParts.FOOTER);
            Add(string.Format("Page {0}", 1));
        }

        public void Body()
        {
            using (var _rs = new StaticRS(string.Format("select ClosedDate from DeliveriesCab where DeliveryCode='{0}' and cod3='{1}'", Program.fDeliveries.Delivery, Values.COD3), Values.gDatos))
            {
                _rs.Open();
                if (_rs.RecordCount != 0)
                {
                    /*
                                 p.NewLine(true);
                                List<int> _colWidths = new List<int>();
                                List<char> _colAligns = new List<char>();
                                // get the col max widths
                                Columns.Cast<CtlVSColumn>().ToList().ForEach(x =>
                                {
                                    _colWidths.Add(x.MaxWidth);
                                    _colAligns.Add(x.IsNumeric ? 'R' : 'L');

                                });
                                //headers
                                var _font = p.CurrentFont;
                                p.CurrentFont = new Font(_font, FontStyle.Bold);
                                Columns.OfType<DataGridViewColumn>().Where(x => ((CtlVSColumn)x).Print == true).ToList().ForEach(x =>
                                {
                                    if (_colAligns[x.Index] == 'L')
                                        p.Add(x.HeaderCell.Value.ToString().PadRight(_colWidths[x.Index]));
                                    else
                                        p.Add(x.HeaderCell.Value.ToString().PadLeft(_colWidths[x.Index]));
                                });

                                p.CurrentFont = _font;
                                p.NewLine(true);
                                Rows.OfType<DataGridViewRow>().ToList().ForEach(r =>
                                {
                                    r.Cells.OfType<DataGridViewCell>().Where(x => ((CtlVSColumn)x.OwningColumn).Print == true).ToList().ForEach(x =>
                                    {
                                        if (_colAligns[x.ColumnIndex] == 'L')
                                            p.Add(x.Value.ToString().PadRight(_colWidths[x.ColumnIndex]));
                                        else
                                            p.Add(x.Value.ToString().PadLeft(_colWidths[x.ColumnIndex]));
                                    });
                                    p.NewLine(true);
                                });
                                p.NewLine();
                                //aggregates
                                p.CurrentFont = new Font(_font, FontStyle.Bold);
                                var _aggregateList = new AggregateItemList();
                                //Columns.OfType<DataGridViewColumn>().Where(x => ((CtlVSColumn)x).Print == true).ToList().ForEach(x => {
                                //    string _value = ((CtlVSColumn)x).Aggregate != AggregateOperations.NONE ? ((CtlVSColumn)x).AggregateValue.ToString() : " ";
                                //    if (_colAligns[x.Index] == 'L')
                                //        p.Add(_value.PadRight(_colWidths[x.Index]));
                                //    else
                                //        p.Add(_value.PadLeft(_colWidths[x.Index]));
                                //});
                                Columns.OfType<CtlVSColumn>().Where(x => x.Aggregate != AggregateOperations.NONE).ToList().ForEach(x => _aggregateList.Items.Add(new AggregateItem() { Aggregate = x.Aggregate, FieldName = ((DataGridViewColumn)x).HeaderCell.Value.ToString(), Value = x.AggregateValue }));
                                //Columns.OfType<CtlVSColumn>().Where(x => x.Aggregate != AggregateOperations.NONE).ToList().ForEach(x => _aggregates[string.Format("{0}({1})", x.Aggregate.ToString(), ((DataGridViewColumn)x).HeaderCell.Value.ToString())] = x.AggregateValue.ToString());
                                //_aggregates.Select(x => )
                                //p.Add(string.Format("{0}({1}) = {2}", x.Aggregate.ToString(), ((DataGridViewColumn)x).HeaderCell.Value.ToString(), x.AggregateValue));
                                //    p.NewLine(true);
                                //});
                                _aggregateList.Items.ForEach(a => {
                                    p.Add(a.Title.PadLeft(_aggregateList.LenghtTitle));
                                    p.Add("=");
                                    p.Add(a.StringValue.PadLeft(_aggregateList.LenghtValue));
                                    p.NewLine();
                                });
                                p.CurrentFont = _font;
                     */
                }
            }
        }
    }


}
