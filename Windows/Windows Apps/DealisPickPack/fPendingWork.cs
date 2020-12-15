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

namespace DealisPickPack
{
    public partial class fPendingWork : Form
    {
        public fPendingWork()
        {
            InitializeComponent();
         
            // Fill the routes combo
            //cboRoute.Source("Select RouteCode,Description from MasterRoutes where cod3='" + Values.COD3 + "' order by RouteCode", txtDesRoute);
            //cboRoute.SelectedValueChanged += CboRoute_SelectedValueChanged;
        }

        private void CboRoute_SelectedValueChanged(object sender, EventArgs e)
        {
            //if (cboRoute.Value.ToString() != "")
            //    using (var _RS = new StaticRS(string.Format("Select Route from MasterRoutes where RouteCode='{0}'", cboRoute.Value), Values.gDatos))
            //    {
            //        _RS.Open();
            //        if (_RS.RecordCount != 0)
            //        {
                        //((EspackDataGridViewColumn)VS.Columns["PartNumber"]).AutoCompleteQuery = string.Format("select partnumber from referencias where servicio='{0}' order by partnumber", cboRoute.Value);
                        //((EspackDataGridViewColumn)VS.Columns["PartNumber"]).ReQuery();
            //        }
            //    }
            //else
            //    btnRefresh.Enabled = false;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // fPendingWork
            // 
            this.ClientSize = new System.Drawing.Size(1144, 633);
            this.Name = "fPendingWork";
            this.ResumeLayout(false);

        }
    }
}
