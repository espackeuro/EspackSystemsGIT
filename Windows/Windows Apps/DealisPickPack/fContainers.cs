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
using CommonToolsWin;
using DiverseControls;
using EspackDataGridView;
using EspackClasses;
using RawPrinterHelper;
using System.Threading;
using System.Data.SqlClient;
using Zen.Barcode;

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
            CTLM.AddItem(txtInDeliveryDate, "InDeliveryDate", false, false, false, 0, false, false);
            CTLM.AddItem(txtDate, "Date", false, false, false, 0, false, false);

            //VS Definitions
            VS.Conn = Values.gDatos;
            VS.sSPAdd = "pContainersDetAdd";
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            using (var _rs = new StaticRS($"select Route,Date=convert(varchar(10),Date,103) from ContainersCab where ContainerCode='{txtContainer.Text}' and cod3='{Values.COD3}'", Values.gDatos))
            {
                _rs.Open();
                if (_rs.RecordCount == 0) return;
                
                // Refresh the form data from DB values
                cboRoute.Text = _rs["Route"].ToString();
                txtDate.Text = _rs["Date"].ToString();
            }

            SetFormEnabled(false);
            using (var pd = new PrintDialog())
            {
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    using (var _printIt = new PrintContainer())
                    {
                        // Copy values into the object properties & print
                        _printIt.ContainerCode = txtContainer.Text;
                        _printIt.Route = cboRoute.Text;
                        _printIt.Date= txtDate.Text.Substring(0,10);
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
    public class PrintContainer : EspackPrinting
    {
        public string ContainerCode { get; set; }
        public string Route { get; set; }
        public string Date { get; set; }

        // On each printed page...
        protected override void OnPrintPage(PrintPageEventArgs e)
        {

            Graphics graphics = e.Graphics;

            // For the barcode printing
            BarcodeDraw bdraw = BarcodeDrawFactory.GetSymbology(BarcodeSymbology.Code128);
            Image barcodeImage = bdraw.Draw(ContainerCode, 40);

            Pen _pen = new Pen(Brushes.Black);
            _pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };

            Pager.Active = false;
            AddArea(EnumDocumentZones.BODY);

            // Set font 
            //this.CurrentFont = new Font("Courier New", 15, FontStyle.Bold);
            for (var i = 0; i < 2; i++)
            {
                AddText("DEALER PICK PACK CONTAINER", new EspackFont("Courier New", 11, FontStyle.Bold | FontStyle.Underline), pEOL: true);
                AddText($"{ContainerCode,-10}", new EspackFont("Courier New", 26, FontStyle.Bold), pEOL: true);
                AddImage(barcodeImage, pWidth:600, pEOL: true);
                AddText($"ROUTE: {Route,-8}", new EspackFont("Courier New", 12, FontStyle.Bold),pEOL:true);
                AddText($"DATE : {Date,-10}", new EspackFont("Courier New", 12, FontStyle.Bold), pEOL: true);
                AddText("", pEOL: true);
            }
            
            AddDrawing(0, 140, 400, 140, EnumDrawingType.LINE, _pen);
            // Base code
            base.OnPrintPage(e);
        }
    }
    //EspackPrintingDrawing
    /*
    public class PrintContainer : EspackPrintDocument
    {
        public string ContainerCode { get; set; }
        public string Route { get; set; }
        public string Date { get; set; }

        // On each printed page...
        protected override void OnPrintPage(PrintPageEventArgs e)
        {

            Graphics graphics = e.Graphics;

            // Set font 
            //this.CurrentFont = new Font("Courier New", 15, FontStyle.Bold);
            for (var i = 0; i < 2; i++)
            {
                NewLine(false, EnumDocumentParts.HEADER);
                Add($"{ContainerCode,-10}", new Font("Courier New", 36, FontStyle.Bold));
                Add($"{Route,-8}", new Font("Courier New", 36, FontStyle.Bold));
                Add($"{Date,-10}", new Font("Courier New", 36, FontStyle.Bold));
                //AddImage();
            }

            // Base code
            base.OnPrintPage(e);
        }
    }
     */
}
