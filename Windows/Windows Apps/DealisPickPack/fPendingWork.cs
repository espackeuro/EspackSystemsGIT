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

            // VS
            VS.Conn = Values.gDatos;
            VS.AddColumn("Code", txtCode, "@Code", "@Code", "@Code");
            VS.AddColumn("Line", "Line", "@Line", "@Line", "@Line", true, false, true, pWidth: 100);
            VS.AddColumn("Type", "Type", "@Type", "", "", true, false, false, "Select Code from ItemTypes order by Code", pWidth: 200);
            VS.AddColumn("Description", "Description", "@Description", "@Description", pWidth: 100);
            VS.AddColumn("Value1", "Value1", "@Value1", "@Value1", "", pWidth: 100);
            VS.AddColumn("Value2", "Value2", "@Value2", "@Value2", "", pAutoSizeMode: DataGridViewAutoSizeColumnMode.Fill);
            VS.DBTable = "ItemsDet";
        }


        private void CboRoute_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboRoute.Text != "")
            {
                btnRefresh_Click(sender, e);
            } 
            else
            {
                VS.ClearEspackControl();
            }   
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
        }

        
    }

}
