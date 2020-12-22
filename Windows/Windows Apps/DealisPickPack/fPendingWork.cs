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
using RawPrinterHelper;
using System.Threading;

namespace DealisPickPack
{
    public partial class fPendingWork : Form
    {
        public fPendingWork()
        {
            InitializeComponent();

            // Fill the routes combo
            cboRoute.ParentConn = Values.gDatos;
            cboRoute.Source("Select RouteCode,Description from MasterRoutes where cod3='" + Values.COD3 + "' order by RouteCode", txtRouteDescription);
            cboRoute.SelectedValueChanged += CboRoute_SelectedValueChanged;

            VS.CellContentDoubleClick += VS_CellContentDoubleClick;
            VSHUDet.CellContentDoubleClick += VSHUDet_CellContentDoubleClick;
        }


        private void CboRoute_SelectedValueChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            VS_Show();
            VSHUCab_Show();

        }

        private void VS_Show()
        {
            VS.Rows.Clear();

            // Add the results of the query to the DataGrid            
            using (var _rs = new StaticRS("select Route,Finis,Qty,QtyPending,Dealer,DealerDesc,OrderNumber,OrderItemNumber from vPendingLines where cod3='" + Values.COD3 + "' " + (cboRoute.Text != "" ? "and Route='" + cboRoute.Text + "' " : "") + "order by Route,Dealer,OrderNumber,OrderItemNumber,Finis", Values.gDatos))
            {
                _rs.Open();
                while (!_rs.EOF)
                {
                    VS.Rows.Add(_rs["Route"], _rs["Finis"], _rs["Qty"], _rs["QtyPending"], _rs["Dealer"], _rs["DealerDesc"], _rs["OrderNumber"], _rs["OrderItemNumber"]);
                    _rs.MoveNext();
                }
            }
            VS.Refresh();
        }

        private void VSHUCab_Show()
        {
            VSHUCab.Rows.Clear();
            // Add the results of the query to the DataGrid            
            using (var _rs = new StaticRS("select HU,Route,Dealer,Date from HUCab where InDelivery is null and cod3='" + Values.COD3 + "' " + (cboRoute.Text != "" ? "and Route='" + cboRoute.Text + "' " : "") + "order by HU,Route,Dealer", Values.gDatos))
            {
                _rs.Open();
                while (!_rs.EOF)
                {
                    VSHUCab.Rows.Add(_rs["HU"], _rs["Route"], _rs["Dealer"], _rs["Date"]);
                    _rs.MoveNext();
                }
            }
            VSHUCab.Refresh();
            if (VSHUCab.Rows.Count > 0) VSHUDet_Show();

        }

        private void VSHUDet_Show()
        {
            VSHUDet.Rows.Clear();
            // Add the results of the query to the DataGrid            
            using (var _rs = new StaticRS("select HU,Finis,Qty,ReceivalCode,Receival from HUDet where cod3='" + Values.COD3 + "' " + (cboRoute.Text != "" ? "and HU='" + VSHUCab["HU", VSHUCab.CurrentRow.Index].Value + "' " : "") + "order Finis,Qty,ReceivalCode,Receival", Values.gDatos))
            {
                _rs.Open();
                while (!_rs.EOF)
                {
                    VSHUDet.Rows.Add(_rs["HU"], _rs["Finis"], _rs["Qty"], _rs["ReceivalCode"], _rs["Receival"]);
                    _rs.MoveNext();
                }
            }
            VSHUDet.Refresh();
        }

        private void VS_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pHUDetAdd(Convert.ToInt32(VSHUCab["QtyPending", VSHUCab.CurrentRow.Index].Value));
        }

        private void VSHUDet_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pHUDetDel();
        }

        private void pHUDetAdd(int qty)
        {
            using (var _sp = new SP(Values.gDatos, "pHUDetAdd"))
            {
                _sp.AddParameterValue("@HU", VSHUCab["HU", VSHUCab.CurrentRow.Index].Value);
                _sp.AddParameterValue("@Receival", VSHUCab["ReceivalCode", VSHUCab.CurrentRow.Index].Value);
                _sp.AddParameterValue("@Line", VSHUCab["Line", VSHUCab.CurrentRow.Index].Value);
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
        private void pHUDetDel()
        {
            using (var _sp = new SP(Values.gDatos, "pHUDetDel"))
            {
                _sp.AddParameterValue("@HU", VSHUDet["HU", VSHUDet.CurrentRow.Index].Value);
                _sp.AddParameterValue("@Receival", VSHUDet["ReceivalCode", VSHUDet.CurrentRow.Index].Value);
                _sp.AddParameterValue("@Line", VSHUCab["Line", VSHUDet.CurrentRow.Index].Value);
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

}
