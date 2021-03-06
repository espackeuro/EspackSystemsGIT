﻿using System;
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
using static CommonToolsWin.CTWin;
using EspackDataGridView;
//using CTLMantenimientoNet;
using EspackFormControlsNS;
using static CommonTools.CT;
using CommonTools;
using DiverseControls;
using Simplistica.Properties;

namespace Simplistica
{

    public partial class fSimpleDeliveriesEPC : Form
    {
        private EspackExtraData ExtraData { get; set; } = new EspackExtraData();

        public fSimpleDeliveriesEPC()
        {

            InitializeComponent();

            //CTLM Definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "pSimpleDeliveriesCabAdd";
            CTLM.sSPUpp = "pSimpleDeliveriesCabUpp";
            CTLM.sSPDel = "pSimpleDeliveriesCabDel";
            CTLM.DBTable = "(Select v.* from vSimpleDeliveriesCab v inner join Servicios s on s.codigo=v.service where s.cod3='" + Values.COD3 + "' and dbo.CheckFlag(s.flags,'SIMPLE')=1) a";

            //Header
            CTLM.AddItem(ExtraData, "ExtraData", true, true, false, 0, false, false);
            CTLM.AddItem(txtDeliveryN, "DeliveryNumber", false, true, true, 1, true, true);
            CTLM.AddItem(cboService, "Service", true, true, true, 0, false, true);
            CTLM.AddItem(txtTruckPlate, "TruckPlate", true, true, false, 0, false, true);
            CTLM.AddItem(txtTrailerPlate, "TrailerPlate", true, true, false, 0, false, true);
            CTLM.AddItem(cboDock, "Dock", true, true, false, 0, false, true);
            CTLM.AddItem(cboShift, "Shift", true, true, false, 0, false, true);
            CTLM.AddItem(txtResponsible, "UserProc", true, true, false, 0, false, true);
            CTLM.AddItem(dateParking, "ParkingDate", true, true, false, 0, false, true, pExtraDataLink: ExtraData);
            CTLM.AddItem(dateGate2, "Gate2Date", true, true, false, 0, false, true, pExtraDataLink: ExtraData);
            CTLM.AddItem(dateDriverShiftLeader, "Driver2ShiftLeaderDate", true, true, false, 0, false, true, pExtraDataLink: ExtraData);
            CTLM.AddItem(dateStart, "StartDate", false, false, false, 0, false, false);
            CTLM.AddItem(dateEnd, "EndDate", false, false, false, 0, false, false);
            CTLM.AddItem(lstFlags, "flags", false, false, false, 0, false, false);

            dateDriverShiftLeader.Protected = true;

            //fields
            cboService.Source("Select Codigo from Servicios where dbo.CheckFlag(flags,'SIMPLE')=1 and cod3='" + Values.COD3 + "' order by codigo");
            cboService.SelectedValueChanged += CboService_SelectedValueChanged;
            cboDock.Source("Select DockCode from SedesDocks where cod3='" + Values.COD3 + "' order by DockCode");
            lstFlags.Source("Select codigo,DescFlagEng from flags where Tabla='SimpleDeliveriesCab'");

            //VS Definitions>
            VS.Conn = Values.gDatos;
            VS.sSPAdd = "pSimpleDeliveriesDetAdd";
            VS.sSPUpp = "pSimpleDeliveriesDetUpp";
            VS.sSPDel = "pSimpleDeliveriesDetDel";
            VS.DBTable = "vSimpleDeliveriesDet";

            //VS Details
            VS.AddColumn("DeliveryNumber", txtDeliveryN, "@DeliveryNumber", "@DeliveryNumber", "@DeliveryNumber", pVisible: false);
            VS.AddColumn("Service", cboService, "@Service", "@Service", "@Service", pVisible: false);
            VS.AddColumn("Line", "Line", "", "@Line", "@Line", pSortable: true, pLocked: true, pPK: true);
            VS.AddColumn("PartNumber", "partnumber", "@partnumber", pSortable: true, pWidth: 100, aMode: AutoCompleteMode.SuggestAppend, aSource: AutoCompleteSource.CustomSource, aQuery: string.Format("select partnumber from referencias where servicio='{0}' order by partnumber", cboService.Value));
            VS.AddColumn("Description", "Description", pWidth: 160);
            VS.AddColumn("Destination", "Destination", "@Destination", "@Destination", pWidth: 200, pQuery: string.Format("select Destination=planta+' ('+Descripcion2+') '+Descripcion1 from servicios_destinos where servicio='{0}'", cboService.Value), pSortable: true); //, aMode: AutoCompleteMode.SuggestAppend, aSource: AutoCompleteSource.CustomSource, aQuery: string.Format("select partnumber from servicio_destinos where servicio='{0}'", cboService.Value));
            VS.AddColumn("OrderedQty", "OrderedQty", "@OrderedQty", "@OrderedQty", pWidth: 90);
            VS.AddColumn("SentQty", "SentQty", "@SentQty", "@SentQty", pWidth: 90);

            VS.CellBeginEdit += VS_CellBeginEdit;
            VS.CellEndEdit += VS_CellEndEdit; //VS_CellValidating; ; ;
            VS.DataError += VS_DataError;
            //Various
            CTLM.ReQuery = true;
            CTLM.AddDefaultStatusStrip();
            CTLM.AddItem(VS);
            CTLM.Start();
            CTLM.AfterButtonClick += CTLM_AfterButtonClick;
            toolStrip.Enabled = false;
        }

        private void VS_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex == (VS.Columns["Destination"].Index))
            {
                ((EspackDataGridViewCell)VS[VS.Columns["Destination"].Index, e.RowIndex]).SqlSource = string.Format("select Destination=s.planta+' ('+s.Descripcion2+') '+s.Descripcion1 from servicios_destinos s inner join referencias_destinos r on r.servicio=s.servicio and r.ruta=s.ruta where s.servicio='{0}' and r.partnumber='{1}' order by s.planta", cboService.Value, VS[VS.Columns["Partnumber"].Index, e.RowIndex].Value);
            }
        }

        private void CTLM_AfterButtonClick(object sender, CTLMEventArgs e)
        {

            Application.DoEvents();

            ChangeButtonsStatus();

            toolStrip.Enabled = (CTLM.Status == CommonTools.EnumStatus.NAVIGATE || CTLM.Status == CommonTools.EnumStatus.SEARCH) && ("btnUpp|btnCancel|btnAdd|".IndexOf(e.ButtonClick + "|") == -1);
            //toolStrip.Enabled = true; // The event that changes the status happens after this AfterButtonClick, so we left this enabled until I decide what to do.
        }

        private void ChangeButtonsStatus()
        {

            if (!lstFlags.CheckedValues.Contains("CLOSED"))
            {
                toolStrip.Items["btnClose"].Text = "Close";
                toolStrip.Items["btnClose"].Image = Resources.truck_24;
            }
            else
            {
                toolStrip.Items["btnClose"].Text = "Open";
                toolStrip.Items["btnClose"].Image = Resources.truck_undo_24;
            }

            CTLM.Items["btnUpp"].Enabled = toolStrip.Items["btnClose"].Text != "Open";
            CTLM.Items["btnDel"].Enabled = toolStrip.Items["btnClose"].Text != "Open";
        }

        private void VS_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {

            if (anError.Context == DataGridViewDataErrorContexts.Parsing || anError.Context.ToString().IndexOf("Parsing")!=-1)
            {
                if (anError.ColumnIndex == VS.Columns["SentQty"].Index)
                {
                    MessageBox.Show("Wrong value for Sent Qty. Only numeric values allowed.");
                    anError.ThrowException = false;
                    return;
                }

            }
            
            /*
                        MessageBox.Show("Error happened " + anError.Context.ToString());

                        if (anError.Context == DataGridViewDataErrorContexts.Commit)
                        {
                            MessageBox.Show("Commit error");
                        }
                        if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
                        {
                            MessageBox.Show("Cell change");
                        }
                        if (anError.Context == DataGridViewDataErrorContexts.Parsing)
                        {
                            MessageBox.Show("parsing error");
                        }
                        if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
                        {
                            MessageBox.Show("leave control error");
                        }
                        */
            if ((anError.Exception) is ConstraintException)
            {
                DataGridView view = (DataGridView)sender;
                view.Rows[anError.RowIndex].ErrorText = "an error";
                view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                anError.ThrowException = false;
            }
        }

        private void CboService_SelectedValueChanged(object sender, EventArgs e)
        {
            ((EspackDataGridViewColumn)VS.Columns["Partnumber"]).AutoCompleteQuery = string.Format("select partnumber from referencias where servicio='{0}' order by partnumber", cboService.Value);
        }

        private void VS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == (VS.Columns["PartNumber"].Index))
            {
                if (VS[e.ColumnIndex, e.RowIndex].Value.ToString() != "")
                {
                    using (var _rs = new StaticRS(string.Format("Select Descripcion,Destination=isnull((select top 1 s.planta+' ('+s.Descripcion2+') '+s.Descripcion1 from servicios_destinos s inner join referencias_destinos rd on rd.servicio=s.servicio and rd.ruta=s.ruta where rd.servicio=r.servicio and rd.partnumber=r.partnumber order by s.planta),'') from Referencias r where partnumber='{0}' and Servicio='{1}'", VS[e.ColumnIndex, e.RowIndex].Value, cboService.Value), Values.gDatos))
                    //select s.planta+' ('+s.Descripcion2+') '+s.Descripcion1 from servicios_destinos s inner join referencias_destinos r on r.servicio=s.servicio and r.ruta=s.ruta where s.servicio='{0}' and r.partnumber='{1}' order by s.planta
                    {
                        _rs.Open();
                        if (_rs.RecordCount == 0)
                        {
                            MsgError("Wrong partnumber");
                            VS[e.ColumnIndex, e.RowIndex].Value = "";
                        }
                        else
                        {
                            VS[VS.Columns["Description"].Index, e.RowIndex].Value = _rs["Descripcion"].ToString();
                            //VS.CurrentCell = VS[VS.Columns["Description"].Index, e.RowIndex];
                            VS[VS.Columns["Destination"].Index, e.RowIndex].Value = _rs["Destination"].ToString(); ;
                        }
                    }
                }

                if(VS[e.ColumnIndex, e.RowIndex].Value.ToString() == "")
                    VS[VS.Columns["Description"].Index, e.RowIndex].Value = "";



            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            // Launch the robot process.
            using (var _sp = new SP(Values.gDatos, "pSimpleDeliveriesChangeStatus"))
            {
                bool _closed = lstFlags.itemStatus("CLOSED");

                _sp.AddParameterValue("@DeliveryNumber", txtDeliveryN.Text);
                _sp.AddParameterValue("@Service", cboService.Value.ToString());
                _sp.AddParameterValue("@Action", _closed ? "OPEN" : "CLOSE");
                try
                {
                    _sp.Execute();
                }
                catch (Exception ex)
                {
                    MsgError("Error launching process: " + ex.Message);
                    return;
                }
                if (_sp.LastMsg.Substring(0, 2) != "OK")
                {
                    MsgError(_sp.LastMsg);
                    return;
                }

                CTLM.Button_Click("btnCancel");
                ChangeButtonsStatus();
                MessageBox.Show(string.Format("Delivery {0} OK.", _closed ? "opened" : "closed"), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (var _pd = new PrintDialog())
            {
                if (_pd.ShowDialog() == DialogResult.OK)
                {
                    using (var _printIt = new PrintPage())
                    {
                        _printIt.PrinterSettings = _pd.PrinterSettings;
                        _printIt.DeliveryNumber = txtDeliveryN.Text;
                        _printIt.Service = cboService.Value.ToString();
                        _printIt.TruckPlate = txtTruckPlate.Text;
                        _printIt.TrailerPlate = txtTrailerPlate.Text;
                        _printIt.Dock = cboDock.Text;
                        _printIt.EndDate = (dateEnd.Value == null ? "< NONE >" : dateEnd.Text.Substring(0, 10));
                        _pd.Document = _printIt;
                        _printIt.Print();
                    }
                }
            }
        }

        public class PrintPage : EspackPrintDocument
        {
            public string DeliveryNumber { get; set; }
            public string Service { get; set; }
            public string EndDate { get; set; }
            public string TruckPlate { get; set; }
            public string TrailerPlate { get; set; }
            public string Destination { get; set; }
            public string Dock { get; set; }
            private bool _dontPrintSignature = false;
            private int PageNumber { get; set; } = 0;

            // Definition for the document. It will be called on any new page, so we just define the Header and the query for the Body once. The Footer is cleared and created on each call, as the 
            // page number has to change.
            protected override void OnPrintPage(PrintPageEventArgs e)
            {
                Graphics _g = e.Graphics;

                // Page counter
                PageNumber++;

                // Just for the first time
                if (PageNumber == 1)
                {

                    // Define the Header
                    Header();

                    // Define the Body columns
                    NewLine(false, EnumDocumentParts.BODY);
                    Add($"{"LN",2} {"PARTNUMBER",-18} {"DESCRIPTION",-30} {"DESTINATION",-30} {"ORD.",5} {"SENT",5}", new Font("Courier New", 8, FontStyle.Bold));


                    // Change the font and run the query for the Body data
                    this.CurrentFont = new Font("Courier New", 8);
                    using (var _rs = new StaticRS(string.Format("Select Line,Partnumber,Description,Destination=isnull((select top 1 s.planta+' ('+s.Descripcion2+') '+s.Descripcion1 from servicios_destinos s inner join referencias_destinos rd on rd.servicio=s.servicio and rd.ruta=s.ruta where rd.servicio=v.service and rd.partnumber=v.partnumber order by s.planta),''),OrderedQty,SentQty from vSimpleDeliveriesDet v where DeliveryNumber='{0}' and Service='{1}'", DeliveryNumber, Service), Values.gDatos))
                    {
                        _rs.Open();

                        _dontPrintSignature = (_rs.RecordCount > 48);

                        if (_rs.RecordCount != 0)
                        {

                            // Loop through the recordset results
                            while (!_rs.EOF)
                            {
                                //for (int i = 1; i < 25; i++)
                                //{
                                NewLine(true);
                                Add(string.Format("{0,2} {1,-18} {2,-30} {3,-30} {4,5} {5,5}", _rs["Line"], _rs["Partnumber"], _rs["Description"].ToString().Length > 30 ? _rs["Description"].ToString().Substring(0, 30) : _rs["Description"], _rs["Destination"].ToString().Length > 30 ? _rs["Destination"].ToString().Substring(0, 30) : _rs["Destination"], _rs["OrderedQty"], _rs["SentQty"]));
                                //    Add(string.Format("{0,5} {1,-20} {2,-30} {3,7} {4,6}", i, _rs["Partnumber"], _rs["Description"].ToString().Length > 30 ? _rs["Description"].ToString().Substring(0, 30) : _rs["Description"], _rs["OrderedQty"], _rs["SentQty"]));
                                //}
                                _rs.MoveNext();
                            }
                            //NewLine(true);
                            //Add(string.Format("{0,5} {1,-20} {2,-30} {3,7} {4,6}", "xx", "Partnumber", "Description","OrderedQty", "SentQty"));
                        }
                        else
                        {
                            NewLine(true);
                            Add("--- NO DATA FOUND ---");
                        }
                    }
                }
                else
                {
                    _dontPrintSignature = !((BodyList.Lines.Count() - BodyList.LastPrintedLine - 50) < 1);
                }

                // Print the footer (changes on each new page)
                Footer();

                // Draw graphics
                _g.DrawRectangle(new Pen(Color.Black, 0.5F), 25F, 65F, 725F, 75F); // Header box
                _g.DrawImage(Resources.Logo_Espack_transparente, 27F, 67F, 140F, 55F);
                _g.DrawLine(new Pen(Color.Black, 0.5F), 50F, 1010F, 750F, 1010F); // Footer separator

                // Signature boxes when last page is reached
                if (!_dontPrintSignature) //BodyList.LastPrintedLine+)
                {
                    _g.DrawRectangle(new Pen(Color.Black, 0.5F), 250F, 1020F, 235F, 100F);
                    _g.DrawRectangle(new Pen(Color.Black, 0.5F), 485F, 1020F, 235F, 100F);
                    _g.DrawString("Carrier Signature", new Font("Courier New", 6), new SolidBrush(Color.Black), new PointF(255F, 1022F));
                    _g.DrawString("Forklift Driver Signature", new Font("Courier New", 6), new SolidBrush(Color.Black), new PointF(490F, 1022F));

                }

                // Base object: it has to be the last to be called as it prints the results
                base.OnPrintPage(e);

            }

            private void Header()
            {
                string _plates = TruckPlate + (TrailerPlate != "" ? "/" + TrailerPlate : "");
                string _destination = Destination + " / " + Dock;

                this.CurrentFont = new Font("Courier New", 12, FontStyle.Bold);
                NewLine(false, EnumDocumentParts.HEADER);
                Add(string.Format("{0,12}DELIVERY : {1,-22} SERVICE: {2,-10}", "", DeliveryNumber, Service));
                NewLine(false, EnumDocumentParts.HEADER);
                Add(string.Format("{0,12}PLATE    : {1,-22}", "", _plates.Length > 22 ? _plates.Substring(0, 22) : _plates));
                NewLine(false, EnumDocumentParts.HEADER);
                Add(string.Format("{0,12}LOAD DATE: {1}", "", EndDate));
                NewLine(false, EnumDocumentParts.HEADER);
            }

            private void Footer()
            {
                ClearFooter();
                this.CurrentFont = new Font("Courier New", 10, FontStyle.Bold);
                NewLine(false, EnumDocumentParts.FOOTER);
                Add(string.Format("Page {0}", PageNumber));
                //NewLine(false, EnumDocumentParts.FOOTER);
                //NewLine(false, EnumDocumentParts.FOOTER);
                //NewLine(false, EnumDocumentParts.FOOTER);
                //NewLine(false, EnumDocumentParts.FOOTER);
            }
        }


    }
}
