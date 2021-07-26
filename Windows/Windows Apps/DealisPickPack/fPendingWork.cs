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
using Windows.UI.Xaml.Controls;

namespace DealerPickPack
{
    public partial class fPendingWork : Form
    {
        public fPendingWork()
        {
            InitializeComponent();

            // Fill the routes & HU types combos
            cboRoute.ParentConn = Values.gDatos;
            cboRoute.Source($"select RouteCode='',Description='' union all Select RouteCode,Description from MasterRoutes where cod3='{Values.COD3}' order by RouteCode", txtRouteDescription);
            cboRoute.SelectedValueChanged += CboRoute_SelectedValueChanged;
            cboRoute.Validated += CboRoute_Validated;
            cboHUType.ParentConn = Values.gDatos;
            cboHUType.Source($"select distinct DealisPackCode,descripcion from SELECCION..bultoscm where dealispackcode is not null and len(codigo)<7 order by DealisPackCode", txtHUTypeDescription);
            cboHUType.Validated += CboHUType_Validated;
            // VS
            VS_Show();
            VS.CellDoubleClick += VS_CellDoubleClick;
            VS.KeyDown += VS_KeyDown;

            // VSHUCab
            VSHUCab_Show();
            VSHUCab.SelectionChanged += VSHUCab_SelectionChanged;
            VSHUCab.KeyDown += VSHUCab_KeyDown; 

            // VSHUDet
            VSHUDet.KeyDown += VSHUDet_KeyDown;

            // Tooltips
            System.Windows.Forms.ToolTip _toolTip1 = new System.Windows.Forms.ToolTip();

            // Set up the delays for the ToolTip.
            _toolTip1.AutoPopDelay = 5000;
            _toolTip1.InitialDelay = 1000;
            _toolTip1.ReshowDelay = 500;

            // Button tooltips
            _toolTip1.SetToolTip(btnRefresh, "Refresh");
            _toolTip1.SetToolTip(btnHUCabAdd, "Add HU");
            _toolTip1.SetToolTip(btnHUCabDel, "Delete HU");
            _toolTip1.SetToolTip(btnPrintHULabel, "Print HU");
            _toolTip1.SetToolTip(btnHUDetDel, "Delete line from HU");
            _toolTip1.SetToolTip(btnHUDetDel, "Print Pending HUs");

        }

        ////////// EVENTS //////////
        ///        
        private void CboRoute_Validated(object sender, EventArgs e)
        {
            if (cboRoute.ComboBox.FindStringExact(cboRoute.Text) == -1)
            {
                txtRouteDescription.Text = "";
            }
        }
        private void CboHUType_Validated(object sender, EventArgs e)
        {
            if (cboHUType.ComboBox.FindStringExact(cboHUType.Text) == -1)
            {
                txtHUTypeDescription.Text = "";
            }
        }
        private void VSHUCab_SelectionChanged(object sender, EventArgs e)
        {
            VSHUDet_Show();
        }
        private void CboRoute_SelectedValueChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }
        private void VS_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // disabled (only allowed at scanner)
            //pHUDetAdd(Convert.ToInt32(VS["PENDING QTY", VS.CurrentRow.Index].Value));
        }
        private void VS_KeyDown(object sender, KeyEventArgs e)
        {
            // disabled (only allowed at scanner)
            /*
            if (e.KeyData == Keys.Space && VS.CurrentCell != null)
            {
                string _answer = Microsoft.VisualBasic.Interaction.InputBox("Enter quantity:", "Move to HU", VS["PENDING QTY", VS.CurrentRow.Index].Value.ToString());
                
                if (_answer!="")
                {
                    int _qty = 0;
                    if (int.TryParse(_answer, out _qty))
                    {
                        pHUDetAdd(Convert.ToInt32(_qty));
                    }
                    else
                    {
                        MessageBox.Show("Wrong quantity.", "Dealis Pick Pack", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            */
        }
        private void VSHUCab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete) btnHUCabDel_Click(sender, e);
        }
        private void VSHUDet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete) btnHUDetDel_Click(sender, e);
        }

        // Buttons
        private void btnHUCabAdd_Click(object sender, EventArgs e)
        {
            if (VS.CurrentRow != null)
            {
                pHUCabAdd(cboHUType.Text);
                PrintHULabel(sender, e);
            }
        }
        private void btnHUCabDel_Click(object sender, EventArgs e)
        {
            if (VSHUCab.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this HU?", "Delete HU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) pHUCabDel();
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            VS_Show();
            VSHUCab_Show();
        }
        private void btnHUDetDel_Click(object sender, EventArgs e)
        {
            if (VSHUDet.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to remove this line?", "Remove line from HU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) pHUDetDel();
            }
        }
        private void btnPrintHULabel_Click(object sender, EventArgs e)
        {
            PrintHULabel(sender, e);
        }

        ////////// FUNCTIONS //////////
        private void VS_Show()
        {
            // Add the results of the query to the DataGrid            
            using (var _rs = new StaticRS($"select ROUTE,FINIS,QTY,[PENDING QTY]=QtyPending,DEALER,[DESCRIPTION]=DealerDesc,[ORDER NUMBER]=OrderNumber,[ORDER LINE]=OrderItemNumber,[RECEIVAL CODE]=ReceivalCode,[RECEIVAL LINE]=Line from vPendingLines where cod3='{Values.COD3}' and (Route='{cboRoute.Text}' or '{cboRoute.Text}'='') order by Route,Dealer,OrderNumber,OrderItemNumber,Finis", Values.gDatos))
            {
                _rs.Open();
                VS.DataSource = _rs.DataObject;
                
            }
            VS.CurrentCell = null;
            VS.Refresh();
            if (VS.Rows.Count == 0) VS.Tag = "";
        }

        private void VSHUCab_Show(string HU = "")
        {
            //// Get the selected route in VS Grid
            //string _route = (VS.CurrentRow == null ? String.Empty : VS["ROUTE", VS.CurrentRow.Index].Value.ToString());

            // Add the results of the query to the DataGrid            
            using (var _rs = new StaticRS($"select HU,ROUTE,TYPE=HUTYPE,DEALER,DATE from HUCab where InDelivery is null and cod3='{Values.COD3}' and (Route='{cboRoute.Text}' or '{cboRoute.Text}'='') order by HU,Route,Dealer", Values.gDatos))
            {
                _rs.Open();
                VSHUCab.DataSource = _rs.DataObject;
            }
            VSHUCab.CurrentCell = null;
           
            // Select the given HU in the grid
            try
            {
                if (HU != "" && VSHUCab.Rows.Count != 0)
                {
                    DataGridViewRow _row = VSHUCab.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["HU"].Value.ToString().Equals(HU));
                    VSHUCab.CurrentCell = VSHUCab.Rows[_row.Index].Cells["HU"];
                }
            }
            catch { }
            VSHUCab.Refresh();
        }
        private void VSHUDet_Show()
        {
            // Add the results of the query to the DataGrid       
            using (var _rs = new StaticRS($"select HU,FINIS,QTY,[RECEIVAL CODE]=ReceivalCode,[RECEIVAL LINE]=ReceivalLine from HUDet where cod3='{Values.COD3}' and HU='{(VSHUCab.CurrentRow == null ? String.Empty : VSHUCab[0, VSHUCab.CurrentRow.Index].Value)}' order by Finis,Qty,ReceivalCode,ReceivalLine", Values.gDatos))
            {
                _rs.Open();
                VSHUDet.DataSource = _rs.DataObject;
                VSHUDet.Columns["HU"].Visible = false;
            }
            VSHUDet.CurrentCell = null;
            VSHUDet.Refresh();
        }
        private void PrintHULabel(object sender, EventArgs e)
        {
            if (VSHUCab.CurrentRow != null)
            {

                string _printerAddress = Values.LabelPrinterAddress.ToString();
                int _printerResolution=300;

                // Get settings for the printer
                using (var _RS = new DynamicRS($"select ValueString,ValueInteger from MiscData where Code='{Values.LabelPrinterAddress}' and cod3='{Values.COD3}'", Values.gDatos))
                {
                    _RS.Open();
                    if (!_RS.EOF)
                    {
                        _printerAddress = _RS["ValueString"].ToString(); // "\\\\valsrv02\\VALLBLPRN003"; 
                        _printerResolution = Convert.ToInt32(_RS["ValueInteger"]);
                    }
                    else
                    {
                        MessageBox.Show("Wrong selected printer.", "Print HU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                 // Create and configurate label
                var _HULabel = new DealerPickPackHULabel(new ZPLLabel(70, 32, 3, _printerResolution));
                using (var _printer = new cRawPrinterHelper(_printerAddress))
                {
                    _HULabel.Parameters["HU"] = VSHUCab["HU", VSHUCab.CurrentRow.Index].Value.ToString();
                    _HULabel.Parameters["ROUTE"] = VSHUCab["ROUTE", VSHUCab.CurrentRow.Index].Value.ToString();
                    _HULabel.Parameters["DEALER"] = VSHUCab["DEALER", VSHUCab.CurrentRow.Index].Value.ToString();
                    _HULabel.Parameters["TYPE"] = VSHUCab["TYPE", VSHUCab.CurrentRow.Index].Value.ToString();
                    _HULabel.Parameters["DATE"] = VSHUCab["DATE", VSHUCab.CurrentRow.Index].Value.ToString().Substring(0,10);
                    _printer.SendUTF8StringToPrinter(_HULabel.ToString(), 1);
                }
                MessageBox.Show("HU label sent to printer.", "Print HU", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        ////////// SPs //////////
        private void pHUCabAdd(string HUType)
        {
            using (var _sp = new SP(Values.gDatos, "pHUCabAdd"))
            {
                _sp.AddParameterValue("@Dealer", VS["DEALER", VS.CurrentRow.Index].Value);
                _sp.AddParameterValue("@Route", VS["ROUTE", VS.CurrentRow.Index].Value);
                _sp.AddParameterValue("@Type", HUType);
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
                VSHUCab_Show(_sp.LastMsg.Substring(3));
            }
        }
        private void pHUCabDel()
        {
            if (VSHUCab.CurrentRow != null)
            {
                using (var _sp = new SP(Values.gDatos, "pHUCabDel"))
                {
                    _sp.AddParameterValue("@HU", VSHUCab["HU", VSHUCab.CurrentRow.Index].Value);
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
                    VSHUCab_Show();
                }
            }
        }

        private void pHUDetAdd(int qty)
        {
            if (VSHUCab.CurrentRow != null)
            {
                using (var _sp = new SP(Values.gDatos, "pHUDetAdd"))
                {
                    _sp.AddParameterValue("@HU", VSHUCab["HU", VSHUCab.CurrentRow.Index].Value);
                    _sp.AddParameterValue("@Receival", VS["RECEIVAL CODE", VS.CurrentRow.Index].Value);
                    _sp.AddParameterValue("@Line", VS["RECEIVAL LINE", VS.CurrentRow.Index].Value);
                    _sp.AddParameterValue("@Qty", qty);
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
                    VS_Show();
                    VSHUDet_Show();
                }
            }
        }
        private void pHUDetDel()
        {
            if (VSHUDet.CurrentRow != null)
            {
                using (var _sp = new SP(Values.gDatos, "pHUDetDel"))
                {
                    _sp.AddParameterValue("@HU", VSHUDet["HU", VSHUDet.CurrentRow.Index].Value);
                    _sp.AddParameterValue("@Receival", VSHUDet["RECEIVAL CODE", VSHUDet.CurrentRow.Index].Value);
                    _sp.AddParameterValue("@Line", VSHUDet["RECEIVAL LINE", VSHUDet.CurrentRow.Index].Value);
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
                    VS_Show();
                    VSHUDet_Show();
                }
            }
        }

        // Print HU labels
        private void btnPrintPendingHUs_Click(object sender, EventArgs e)
        {
            using (var _RS = new DynamicRS($"select v.HU,v.OrderType,v.Address1,v.Address2,v.Address3,v.Address4,v.CustomerOrderDate,v.Dealer,v.TrafficArea,v.GridLoc,v.Route,v.CarrierInformation from vHULabels v inner join (select distinct ReceivalCode,Route,Dealer,OrderType=left(OrderNumber,1),cod3 from vPendingLines where cod3='{Values.COD3}' and (Route='{cboRoute.Text}' or '{cboRoute.Text}'='')) vp on vp.ReceivalCode=v.ReceivalCode and vp.Dealer=v.Dealer and vp.OrderType=v.OrderType and right(vp.Route,3)=v.Route and vp.cod3=v.cod3 where (vp.Route='{cboRoute.Text}' or '{cboRoute.Text}'='') and vp.cod3='{Values.COD3}' order by v.Route,v.Dealer,v.OrderType,v.HU", Values.gDatos))
            {
                _RS.Open();
                if (!_RS.EOF)
                {
                    ZPLPrintLabels(_RS, "REFERRALSLABEL");
                }
                else
                {
                    MessageBox.Show("HU not found.", "Print HU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        // Print HU labels
        public void ZPLPrintLabels(DynamicRS rs, string labelType)
        {
            string _printerAddress = Values.LabelPrinterAddress.ToString();
            int _printerResolution;
            string _zplTemplate = "", _zplCode = "";

            // Get settings for the printer
            using (var _RS = new StaticRS($"select ValueString,ValueInteger from MiscData where Code='{Values.LabelPrinterAddress} and cod3='{Values.COD3}'", Values.gDatos))
            {
                _RS.Open();
                if (!_RS.EOF)
                {
                    _printerAddress = _RS["ValueString"].ToString(); // "\\\\valsrv02\\VALLBLPRN003"; 
                    _printerResolution = Convert.ToInt32(_RS["ValueInteger"]);
                }
                else
                {
                    MessageBox.Show($"Printer {_printerAddress} not found.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Get the ZPL template code
            using (var _RS = new StaticRS($"select ValueString from MiscData where Code='{labelType}' and cod3='{Values.COD3}'", Values.gDatos))
            {
                _RS.Open();
                if (!_RS.EOF) _zplTemplate = _RS["ValueString"].ToString();
            }
            if (_zplTemplate == "")
            {
                MessageBox.Show("ZLP template not found.", "Print HU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var _printer = new cRawPrinterHelper(_printerAddress))
            {
                while (!rs.EOF)
                {
                    // Get the Template code
                    _zplCode = _zplTemplate;

                    // Replace values
                    for (int i = 0; i < rs.FieldCount; i++)
                    {
                        _zplCode = _zplCode.Replace("<" + rs.Fields[i] + ">", rs[rs.Fields[i]].ToString());
                    }

                    // Print the label
                    _printer.SendUTF8StringToPrinter(_zplCode, 1);
                    rs.MoveNext();

                }
            }

        }
    }

}
