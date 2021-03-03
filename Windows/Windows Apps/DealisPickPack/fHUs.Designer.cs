
namespace DealerPickPack
{
    partial class fHUs
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewRow dataGridViewRow1 = new System.Windows.Forms.DataGridViewRow();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.VS = new EspackDataGridView.EspackDataGridViewControl();
            this.cboRoute = new EspackFormControlsNS.EspackComboBox();
            this.txtHU = new EspackFormControlsNS.EspackTextBox();
            this.txtDealer = new EspackFormControlsNS.EspackTextBox();
            this.txtDate = new EspackFormControlsNS.EspackDateTimePicker();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.txtHUTypeDescription = new EspackFormControlsNS.EspackTextBox();
            this.cboHUType = new EspackFormControlsNS.EspackComboBox();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // CTLM
            // 
            this.CTLM.AutoSize = true;
            this.CTLM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CTLM.BackColor = System.Drawing.Color.Transparent;
            this.CTLM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CTLM.Clear = false;
            this.CTLM.Conn = null;
            this.CTLM.DBTable = null;
            this.CTLM.Location = new System.Drawing.Point(10, 11);
            this.CTLM.MsgStatusInfoLabel = null;
            this.CTLM.MsgStatusLabel = null;
            this.CTLM.Name = "CTLM";
            this.CTLM.ReQuery = false;
            this.CTLM.Size = new System.Drawing.Size(300, 31);
            this.CTLM.sSPAdd = "";
            this.CTLM.sSPDel = "";
            this.CTLM.sSPUpp = "";
            this.CTLM.StatusBarProgress = null;
            this.CTLM.TabIndex = 1;
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
            this.VS.Location = new System.Drawing.Point(10, 150);
            this.VS.Margin = new System.Windows.Forms.Padding(4);
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
            dataGridViewRow1.Height = 24;
            this.VS.RowTemplate = dataGridViewRow1;
            this.VS.Search = false;
            this.VS.Size = new System.Drawing.Size(443, 192);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.Status = CommonTools.EnumStatus.SEARCH;
            this.VS.TabIndex = 43;
            this.VS.Upp = false;
            this.VS.Value = null;
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
            this.cboRoute.Location = new System.Drawing.Point(226, 48);
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
            this.cboRoute.Size = new System.Drawing.Size(99, 40);
            this.cboRoute.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboRoute.TabIndex = 44;
            this.cboRoute.TBDescription = null;
            this.cboRoute.Upp = false;
            this.cboRoute.Value = "";
            this.cboRoute.ValueMember = "";
            // 
            // txtHU
            // 
            this.txtHU.Add = false;
            this.txtHU.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtHU.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtHU.Caption = "HU";
            this.txtHU.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtHU.DBField = null;
            this.txtHU.DBFieldType = null;
            this.txtHU.DefaultValue = null;
            this.txtHU.Del = false;
            this.txtHU.DependingRS = null;
            this.txtHU.ExtraDataLink = null;
            this.txtHU.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtHU.IsCTLMOwned = false;
            this.txtHU.IsPassword = false;
            this.txtHU.Location = new System.Drawing.Point(12, 47);
            this.txtHU.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtHU.Multiline = true;
            this.txtHU.Name = "txtHU";
            this.txtHU.Order = 0;
            this.txtHU.ParentConn = null;
            this.txtHU.ParentDA = null;
            this.txtHU.PK = false;
            this.txtHU.Protected = false;
            this.txtHU.ReadOnly = false;
            this.txtHU.Search = false;
            this.txtHU.Size = new System.Drawing.Size(108, 38);
            this.txtHU.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtHU.TabIndex = 46;
            this.txtHU.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtHU.Upp = false;
            this.txtHU.Value = "";
            this.txtHU.WordWrap = true;
            // 
            // txtDealer
            // 
            this.txtDealer.Add = false;
            this.txtDealer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDealer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDealer.Caption = "Dealer";
            this.txtDealer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDealer.DBField = null;
            this.txtDealer.DBFieldType = null;
            this.txtDealer.DefaultValue = null;
            this.txtDealer.Del = false;
            this.txtDealer.DependingRS = null;
            this.txtDealer.ExtraDataLink = null;
            this.txtDealer.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtDealer.IsCTLMOwned = false;
            this.txtDealer.IsPassword = false;
            this.txtDealer.Location = new System.Drawing.Point(126, 48);
            this.txtDealer.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDealer.Multiline = true;
            this.txtDealer.Name = "txtDealer";
            this.txtDealer.Order = 0;
            this.txtDealer.ParentConn = null;
            this.txtDealer.ParentDA = null;
            this.txtDealer.PK = false;
            this.txtDealer.Protected = false;
            this.txtDealer.ReadOnly = false;
            this.txtDealer.Search = false;
            this.txtDealer.Size = new System.Drawing.Size(94, 38);
            this.txtDealer.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDealer.TabIndex = 47;
            this.txtDealer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDealer.Upp = false;
            this.txtDealer.Value = "";
            this.txtDealer.WordWrap = true;
            // 
            // txtDate
            // 
            this.txtDate.Add = false;
            this.txtDate.BorderColor = System.Drawing.Color.White;
            this.txtDate.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.txtDate.Caption = "Date";
            this.txtDate.Checked = false;
            this.txtDate.CustomFormat = " ";
            this.txtDate.DBField = null;
            this.txtDate.DBFieldType = null;
            this.txtDate.DefaultValue = null;
            this.txtDate.Del = false;
            this.txtDate.DependingRS = null;
            this.txtDate.ExtraDataLink = null;
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDate.ForeColor = System.Drawing.Color.Black;
            this.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDate.IsCTLMOwned = false;
            this.txtDate.Location = new System.Drawing.Point(331, 49);
            this.txtDate.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.Nullable = true;
            this.txtDate.Order = 0;
            this.txtDate.ParentConn = null;
            this.txtDate.ParentDA = null;
            this.txtDate.PK = false;
            this.txtDate.Protected = false;
            this.txtDate.ReadOnly = false;
            this.txtDate.Search = false;
            this.txtDate.ShowCheckBox = true;
            this.txtDate.Size = new System.Drawing.Size(122, 39);
            this.txtDate.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDate.TabIndex = 53;
            this.txtDate.Text = " ";
            this.txtDate.Upp = false;
            this.txtDate.Value = null;
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint});
            this.toolStrip.Location = new System.Drawing.Point(384, 15);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(68, 27);
            this.toolStrip.TabIndex = 59;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::DealerPickPack.Properties.Resources.printer_16x16;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(56, 24);
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtHUTypeDescription
            // 
            this.txtHUTypeDescription.Add = false;
            this.txtHUTypeDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtHUTypeDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtHUTypeDescription.Caption = "Description";
            this.txtHUTypeDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtHUTypeDescription.DBField = null;
            this.txtHUTypeDescription.DBFieldType = null;
            this.txtHUTypeDescription.DefaultValue = null;
            this.txtHUTypeDescription.Del = false;
            this.txtHUTypeDescription.DependingRS = null;
            this.txtHUTypeDescription.ExtraDataLink = null;
            this.txtHUTypeDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtHUTypeDescription.IsCTLMOwned = false;
            this.txtHUTypeDescription.IsPassword = false;
            this.txtHUTypeDescription.Location = new System.Drawing.Point(126, 94);
            this.txtHUTypeDescription.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtHUTypeDescription.Multiline = true;
            this.txtHUTypeDescription.Name = "txtHUTypeDescription";
            this.txtHUTypeDescription.Order = 0;
            this.txtHUTypeDescription.ParentConn = null;
            this.txtHUTypeDescription.ParentDA = null;
            this.txtHUTypeDescription.PK = false;
            this.txtHUTypeDescription.Protected = false;
            this.txtHUTypeDescription.ReadOnly = true;
            this.txtHUTypeDescription.Search = false;
            this.txtHUTypeDescription.Size = new System.Drawing.Size(327, 40);
            this.txtHUTypeDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtHUTypeDescription.TabIndex = 61;
            this.txtHUTypeDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtHUTypeDescription.Upp = false;
            this.txtHUTypeDescription.Value = "";
            this.txtHUTypeDescription.WordWrap = true;
            // 
            // cboHUType
            // 
            this.cboHUType.Add = false;
            this.cboHUType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboHUType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboHUType.Caption = "HU Type";
            this.cboHUType.DataSource = null;
            this.cboHUType.DBField = null;
            this.cboHUType.DBFieldType = null;
            this.cboHUType.DefaultValue = null;
            this.cboHUType.Del = false;
            this.cboHUType.DependingRS = null;
            this.cboHUType.DisplayMember = "";
            this.cboHUType.ExtraDataLink = null;
            this.cboHUType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboHUType.FormattingEnabled = false;
            this.cboHUType.IsCTLMOwned = false;
            this.cboHUType.Location = new System.Drawing.Point(12, 94);
            this.cboHUType.Name = "cboHUType";
            this.cboHUType.Order = 0;
            this.cboHUType.ParentConn = null;
            this.cboHUType.ParentDA = null;
            this.cboHUType.PK = false;
            this.cboHUType.Protected = false;
            this.cboHUType.ReadOnly = false;
            this.cboHUType.Search = false;
            this.cboHUType.SelectedItem = null;
            this.cboHUType.SelectedValue = null;
            this.cboHUType.Size = new System.Drawing.Size(108, 40);
            this.cboHUType.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboHUType.TabIndex = 60;
            this.cboHUType.TBDescription = null;
            this.cboHUType.Upp = false;
            this.cboHUType.Value = "";
            this.cboHUType.ValueMember = "";
            // 
            // fHUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(467, 359);
            this.Controls.Add(this.txtHUTypeDescription);
            this.Controls.Add(this.cboHUType);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtDealer);
            this.Controls.Add(this.txtHU);
            this.Controls.Add(this.cboRoute);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.CTLM);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fHUs";
            this.Tag = "fHUs";
            this.Text = "HUs";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackDataGridView.EspackDataGridViewControl VS;
        private EspackFormControlsNS.EspackComboBox cboRoute;
        private EspackFormControlsNS.EspackTextBox txtHU;
        private EspackFormControlsNS.EspackTextBox txtDealer;
        private EspackFormControlsNS.EspackDateTimePicker txtDate;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private EspackFormControlsNS.EspackTextBox txtHUTypeDescription;
        private EspackFormControlsNS.EspackComboBox cboHUType;
    }
}