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
            this.espackTextBox1 = new EspackFormControlsNS.EspackTextBox();
            this.ctlMantenimiento2 = new EspackFormControlsNS.CTLMantenimiento();
            this.SuspendLayout();
            // 
            // espackTextBox1
            // 
            this.espackTextBox1.Add = false;
            this.espackTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.espackTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.espackTextBox1.Caption = "";
            this.espackTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.espackTextBox1.DBField = null;
            this.espackTextBox1.DBFieldType = null;
            this.espackTextBox1.DefaultValue = null;
            this.espackTextBox1.Del = false;
            this.espackTextBox1.DependingRS = null;
            this.espackTextBox1.ExtraDataLink = null;
            this.espackTextBox1.IsCTLMOwned = false;
            this.espackTextBox1.IsPassword = false;
            this.espackTextBox1.Location = new System.Drawing.Point(18, 453);
            this.espackTextBox1.Multiline = false;
            this.espackTextBox1.Name = "espackTextBox1";
            this.espackTextBox1.Order = 0;
            this.espackTextBox1.ParentConn = null;
            this.espackTextBox1.ParentDA = null;
            this.espackTextBox1.PK = false;
            this.espackTextBox1.Protected = false;
            this.espackTextBox1.ReadOnly = false;
            this.espackTextBox1.Search = false;
            this.espackTextBox1.Size = new System.Drawing.Size(105, 54);
            this.espackTextBox1.Status = CommonTools.EnumStatus.ADDNEW;
            this.espackTextBox1.TabIndex = 0;
            this.espackTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.espackTextBox1.Upp = false;
            this.espackTextBox1.Value = "";
            this.espackTextBox1.WordWrap = true;
            // 
            // ctlMantenimiento2
            // 
            this.ctlMantenimiento2.AutoSize = true;
            this.ctlMantenimiento2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlMantenimiento2.BackColor = System.Drawing.Color.Transparent;
            this.ctlMantenimiento2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ctlMantenimiento2.Clear = false;
            this.ctlMantenimiento2.Conn = null;
            this.ctlMantenimiento2.DBTable = null;
            this.ctlMantenimiento2.Location = new System.Drawing.Point(18, 13);
            this.ctlMantenimiento2.MsgStatusInfoLabel = null;
            this.ctlMantenimiento2.MsgStatusLabel = null;
            this.ctlMantenimiento2.Name = "ctlMantenimiento2";
            this.ctlMantenimiento2.ReQuery = false;
            this.ctlMantenimiento2.Size = new System.Drawing.Size(310, 31);
            this.ctlMantenimiento2.sSPAdd = "";
            this.ctlMantenimiento2.sSPDel = "";
            this.ctlMantenimiento2.sSPUpp = "";
            this.ctlMantenimiento2.StatusBarProgress = null;
            this.ctlMantenimiento2.TabIndex = 1;
            // 
            // fPendingWork
            // 
            this.ClientSize = new System.Drawing.Size(794, 532);
            this.Controls.Add(this.ctlMantenimiento2);
            this.Controls.Add(this.espackTextBox1);
            this.Name = "fPendingWork";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
