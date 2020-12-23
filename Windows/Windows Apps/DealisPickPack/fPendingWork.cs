﻿using System;
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
using System.Data.SqlClient;

namespace DealisPickPack
{
    public partial class fPendingWork : Form
    {
        public fPendingWork()
        {
            InitializeComponent();

            // Fill the routes combo
            cboRoute.ParentConn = Values.gDatos;
            cboRoute.Source($"Select RouteCode,Description from MasterRoutes where cod3='{Values.COD3}' order by RouteCode", txtRouteDescription);
            cboRoute.SelectedValueChanged += CboRoute_SelectedValueChanged;

            // VS
            VS_Show();
            VS.SelectionChanged += VS_SelectionChanged;
            VS.CellContentDoubleClick += VS_CellContentDoubleClick;

            // VSHUCab
            VSHUCab_Show();
            VSHUCab.SelectionChanged += VSHUCab_SelectionChanged;

            // VSHUDet
            VSHUDet.CellContentDoubleClick += VSHUDet_CellContentDoubleClick;

            // Tooltips
            ToolTip _toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            _toolTip1.AutoPopDelay = 5000;
            _toolTip1.InitialDelay = 1000;
            _toolTip1.ReshowDelay = 500;

            // btnRefresh
            _toolTip1.SetToolTip(btnRefresh, "Refresh");

            // btnNewHU
            _toolTip1.SetToolTip(btnNewHU, "New HU");


        }

        ////////// EVENTS //////////
        private void VS_SelectionChanged(object sender, EventArgs e)
        {
            string _route = VS["ROUTE", VS.CurrentRow.Index].Value.ToString();
            if (_route!=VS.Tag?.ToString())
            {
                VS.Tag = _route;
                VSHUCab_Show();
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

        private void VS_Show()
        {
            // Add the results of the query to the DataGrid            
            using (var _rs = new StaticRS($"select ROUTE,FINIS,QTY,[PENDING QTY]=QtyPending,DEALER,[DESCRIPTION]=DealerDesc,[ORDER NUMBER]=OrderNumber,[ORDER LINE]=OrderItemNumber,[RECEIVAL CODE]=ReceivalCode,[RECEIVAL LINE]=Line from vPendingLines where cod3='{Values.COD3}' and (Route='{cboRoute.Text}' or '{cboRoute.Text}'='') order by Route,Dealer,OrderNumber,OrderItemNumber,Finis", Values.gDatos))
            {
                //await _rs.OpenAsync();
                _rs.Open();
                VS.DataSource = _rs.DataObject;
            }
            VS.Refresh();
            if (VS.Rows.Count == 0) VS.Tag = "";
        }

        private void VSHUCab_Show(string HU="")
        {
            // Get the selected route in VS Grid
            string _route = (VS.CurrentRow == null ? String.Empty : VS["ROUTE", VS.CurrentRow.Index].Value.ToString());

            // Add the results of the query to the DataGrid            
            using (var _rs = new StaticRS($"select HU,ROUTE,DEALER,DATE from HUCab where InDelivery is null and cod3='{Values.COD3}' and (Route='{_route}' or '{_route}'='') order by HU,Route,Dealer", Values.gDatos))
            {
                _rs.Open();
                VSHUCab.DataSource = _rs.DataObject;
            }
            VSHUCab.Refresh();

            // Select the given HU in the grid
            try
            {
                if (HU != "" && VSHUCab.Rows.Count != 0)
                {
                    //DataGridViewRow _row = VSHUCab.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["HU"].Value.ToString().Equals("HU"));
                    DataGridViewRow _row = VSHUCab.Rows.Cast<DataGridViewRow>().FirstOrDefault(r => r.Cells["HU"].Value.ToString().Equals(HU));
                    //VSHUCab.Rows[_row.Index].Selected = true;
                    VSHUCab.CurrentCell = VSHUCab.Rows[_row.Index].Cells["HU"];
                }
            }
            catch { }
            //// Show the details
            //VSHUDet_Show();
        }

        private void VSHUDet_Show()
        {
            // Add the results of the query to the DataGrid       
            using (var _rs = new StaticRS($"select HU,FINIS,QTY,[RECEIVAL CODE]=ReceivalCode,[RECEIVAL LINE]=ReceivalLine from HUDet where cod3='{Values.COD3}' and HU='{(VSHUCab.CurrentRow==null?String.Empty:VSHUCab[0, VSHUCab.CurrentRow.Index].Value)}' order by Finis,Qty,ReceivalCode,ReceivalLine", Values.gDatos))
            {
                _rs.Open();
                VSHUDet.DataSource = _rs.DataObject;
                VSHUDet.Columns["HU"].Visible = false;
            }
            VSHUDet.Refresh();
        }

        

        private void VS_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pHUDetAdd(Convert.ToInt32(VS["PENDING QTY", VS.CurrentRow.Index].Value));
        }

        private void VSHUDet_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pHUDetDel();
        }

        // Buttons
        private void btnNewHU_Click(object sender, EventArgs e)
        {
            pHUCabAdd();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            VS_Show();
            VSHUCab_Show();
        }

        ////////// SPs //////////
        private void pHUCabAdd()
        {
            using (var _sp = new SP(Values.gDatos, "pHUCabAdd"))
            {
                _sp.AddParameterValue("@Dealer", VS["DEALER", VS.CurrentRow.Index].Value);
                _sp.AddParameterValue("@Route", VS["ROUTE", VS.CurrentRow.Index].Value);
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

        private void pHUDetAdd(int qty)
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
        private void pHUDetDel()
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

}
