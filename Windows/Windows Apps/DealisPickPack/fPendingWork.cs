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

        }


        private void CboRoute_SelectedValueChanged(object sender, EventArgs e)
        {
            btnRefresh_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            VS_Show();

        }

        private void VS_Show()
        {
            VS.Rows.Clear();

            using (var _rs = new StaticRS("select Route,Finis,Qty,QtyPending,Dealer,DealerDesc,OrderNumber,OrderItemNumber from vPendingLines " + (cboRoute.Text != "" ? "where Route='" + cboRoute.Text + "' " : "") + "order by Route,Dealer,OrderNumber,OrderItemNumber,Finis", Values.gDatos))
            {
                _rs.Open();
                while (!_rs.EOF)
                {
                    VS.Rows.Add(_rs.ToString());
                    _rs.MoveNext();
                }
            }

            VS.Refresh();


        }

    }

}
