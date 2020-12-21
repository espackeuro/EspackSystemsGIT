
namespace DealisPickPack
{
    partial class fPendingWork
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewRow dataGridViewRow1 = new System.Windows.Forms.DataGridViewRow();
            this.cboRoute = new EspackFormControlsNS.EspackComboBox();
            this.txtRouteDescription = new EspackFormControlsNS.EspackTextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.VS = new EspackDataGridView.EspackDataGridViewControl();
            this.SuspendLayout();
            // 
            // cboRoute
            // 
            this.cboRoute.Add = false;
            this.cboRoute.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRoute.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRoute.Caption = "Route";
            this.cboRoute.DataSource = null;
            this.cboRoute.DBField = null;
            this.cboRoute.DBFieldType = null;
            this.cboRoute.DefaultValue = null;
            this.cboRoute.Del = false;
            this.cboRoute.DependingRS = null;
            this.cboRoute.DisplayMember = "";
            this.cboRoute.ExtraDataLink = null;
            this.cboRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRoute.FormattingEnabled = false;
            this.cboRoute.IsCTLMOwned = false;
            this.cboRoute.Location = new System.Drawing.Point(12, 37);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Order = 0;
            this.cboRoute.ParentConn = null;
            this.cboRoute.ParentDA = null;
            this.cboRoute.PK = false;
            this.cboRoute.Protected = false;
            this.cboRoute.ReadOnly = false;
            this.cboRoute.Search = false;
            this.cboRoute.SelectedItem = null;
            this.cboRoute.SelectedValue = null;
            this.cboRoute.Size = new System.Drawing.Size(130, 40);
            this.cboRoute.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboRoute.TabIndex = 0;
            this.cboRoute.TBDescription = null;
            this.cboRoute.Upp = false;
            this.cboRoute.Value = "";
            this.cboRoute.ValueMember = "";
            // 
            // txtRouteDescription
            // 
            this.txtRouteDescription.Add = false;
            this.txtRouteDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtRouteDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtRouteDescription.Caption = "Description";
            this.txtRouteDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRouteDescription.DBField = null;
            this.txtRouteDescription.DBFieldType = null;
            this.txtRouteDescription.DefaultValue = null;
            this.txtRouteDescription.Del = false;
            this.txtRouteDescription.DependingRS = null;
            this.txtRouteDescription.ExtraDataLink = null;
            this.txtRouteDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtRouteDescription.IsCTLMOwned = false;
            this.txtRouteDescription.IsPassword = false;
            this.txtRouteDescription.Location = new System.Drawing.Point(148, 39);
            this.txtRouteDescription.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtRouteDescription.Multiline = true;
            this.txtRouteDescription.Name = "txtRouteDescription";
            this.txtRouteDescription.Order = 0;
            this.txtRouteDescription.ParentConn = null;
            this.txtRouteDescription.ParentDA = null;
            this.txtRouteDescription.PK = false;
            this.txtRouteDescription.Protected = false;
            this.txtRouteDescription.ReadOnly = true;
            this.txtRouteDescription.Search = false;
            this.txtRouteDescription.Size = new System.Drawing.Size(322, 38);
            this.txtRouteDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtRouteDescription.TabIndex = 13;
            this.txtRouteDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRouteDescription.Upp = false;
            this.txtRouteDescription.Value = "";
            this.txtRouteDescription.WordWrap = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::DealerPickPack.Properties.Resources.reload_24;
            this.btnRefresh.Location = new System.Drawing.Point(477, 53);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(39, 24);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // VS
            // 
            this.VS.Add = false;
            this.VS.AllowDelete = false;
            this.VS.AllowInsert = false;
            this.VS.AllowUpdate = false;
            this.VS.AllowUserToAddRows = false;
            this.VS.AllowUserToResizeColumns = true;
            this.VS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.VS.Caption = "";
            this.VS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VS.ColumnHeadersVisible = true;
            this.VS.Conn = null;
            this.VS.CurrentCell = null;
            this.VS.DataSource = null;
            this.VS.DBField = null;
            this.VS.DBFieldType = null;
            this.VS.DBTable = null;
            this.VS.DefaultValue = null;
            this.VS.Del = false;
            this.VS.DependingRS = null;
            this.VS.DGFocused = false;
            this.VS.Dirty = false;
            this.VS.EspackControlParent = null;
            this.VS.ExtraDataLink = null;
            this.VS.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.VS.HorizontalScrollingOffset = 0;
            this.VS.IsCTLMOwned = false;
            this.VS.Location = new System.Drawing.Point(12, 83);
            this.VS.MsgStatusLabel = null;
            this.VS.Name = "VS";
            this.VS.NumPages = 0;
            this.VS.Order = 0;
            this.VS.Page = 0;
            this.VS.Paginate = false;
            this.VS.ParentConn = null;
            this.VS.ParentDA = null;
            this.VS.PK = false;
            this.VS.Protected = false;
            this.VS.RowCount = 0;
            this.VS.RowHeadersVisible = false;
            this.VS.RowTemplate = dataGridViewRow1;
            this.VS.Search = false;
            this.VS.Size = new System.Drawing.Size(656, 308);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.Status = CommonTools.EnumStatus.SEARCH;
            this.VS.TabIndex = 155;
            this.VS.Upp = false;
            this.VS.Value = null;
            // 
            // fPendingWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtRouteDescription);
            this.Controls.Add(this.cboRoute);
            this.Name = "fPendingWork";
            this.Text = "fPendingWork";
            this.ResumeLayout(false);

        }

        private EspackFormControlsNS.EspackComboBox cboRoute;
        private EspackFormControlsNS.EspackTextBox txtRouteDescription;
        private System.Windows.Forms.Button btnRefresh;
        private EspackDataGridView.EspackDataGridViewControl VS;
    }
}