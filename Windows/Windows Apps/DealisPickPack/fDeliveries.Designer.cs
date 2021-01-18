
namespace DealerPickPack
{
    partial class fDeliveries
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
            this.txtDelivery = new EspackFormControlsNS.EspackTextBox();
            this.cboRoute = new EspackFormControlsNS.EspackComboBox();
            this.VS = new EspackDataGridView.EspackDataGridViewControl();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.txtClosedDate = new EspackFormControlsNS.EspackDateTimePicker();
            this.cboCarrier = new EspackFormControlsNS.EspackComboBox();
            this.txtCarrierDescription = new EspackFormControlsNS.EspackTextBox();
            this.txtPlate = new EspackFormControlsNS.EspackTextBox();
            this.txtDate = new EspackFormControlsNS.EspackTextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDelivery
            // 
            this.txtDelivery.Add = false;
            this.txtDelivery.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDelivery.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDelivery.Caption = "Delivery";
            this.txtDelivery.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDelivery.DBField = null;
            this.txtDelivery.DBFieldType = null;
            this.txtDelivery.DefaultValue = null;
            this.txtDelivery.Del = false;
            this.txtDelivery.DependingRS = null;
            this.txtDelivery.ExtraDataLink = null;
            this.txtDelivery.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtDelivery.IsCTLMOwned = false;
            this.txtDelivery.IsPassword = false;
            this.txtDelivery.Location = new System.Drawing.Point(12, 48);
            this.txtDelivery.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDelivery.Multiline = true;
            this.txtDelivery.Name = "txtDelivery";
            this.txtDelivery.Order = 0;
            this.txtDelivery.ParentConn = null;
            this.txtDelivery.ParentDA = null;
            this.txtDelivery.PK = false;
            this.txtDelivery.Protected = false;
            this.txtDelivery.ReadOnly = false;
            this.txtDelivery.Search = false;
            this.txtDelivery.Size = new System.Drawing.Size(114, 41);
            this.txtDelivery.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDelivery.TabIndex = 51;
            this.txtDelivery.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDelivery.Upp = false;
            this.txtDelivery.Value = "";
            this.txtDelivery.WordWrap = true;
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
            this.cboRoute.Location = new System.Drawing.Point(130, 48);
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
            this.cboRoute.Size = new System.Drawing.Size(112, 40);
            this.cboRoute.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboRoute.TabIndex = 50;
            this.cboRoute.TBDescription = null;
            this.cboRoute.Upp = false;
            this.cboRoute.Value = "";
            this.cboRoute.ValueMember = "";
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
            this.VS.Location = new System.Drawing.Point(10, 149);
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
            this.VS.Size = new System.Drawing.Size(491, 240);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.Status = CommonTools.EnumStatus.SEARCH;
            this.VS.TabIndex = 49;
            this.VS.Upp = false;
            this.VS.Value = null;
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
            this.CTLM.TabIndex = 48;
            // 
            // txtClosedDate
            // 
            this.txtClosedDate.Add = false;
            this.txtClosedDate.BorderColor = System.Drawing.Color.White;
            this.txtClosedDate.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.txtClosedDate.Caption = "Closed Date";
            this.txtClosedDate.Checked = false;
            this.txtClosedDate.CustomFormat = " ";
            this.txtClosedDate.DBField = null;
            this.txtClosedDate.DBFieldType = null;
            this.txtClosedDate.DefaultValue = null;
            this.txtClosedDate.Del = false;
            this.txtClosedDate.DependingRS = null;
            this.txtClosedDate.ExtraDataLink = null;
            this.txtClosedDate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtClosedDate.ForeColor = System.Drawing.Color.Black;
            this.txtClosedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtClosedDate.IsCTLMOwned = false;
            this.txtClosedDate.Location = new System.Drawing.Point(368, 96);
            this.txtClosedDate.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtClosedDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtClosedDate.Name = "txtClosedDate";
            this.txtClosedDate.Nullable = true;
            this.txtClosedDate.Order = 0;
            this.txtClosedDate.ParentConn = null;
            this.txtClosedDate.ParentDA = null;
            this.txtClosedDate.PK = false;
            this.txtClosedDate.Protected = false;
            this.txtClosedDate.ReadOnly = false;
            this.txtClosedDate.Search = false;
            this.txtClosedDate.ShowCheckBox = true;
            this.txtClosedDate.Size = new System.Drawing.Size(135, 39);
            this.txtClosedDate.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtClosedDate.TabIndex = 52;
            this.txtClosedDate.Text = " ";
            this.txtClosedDate.Upp = false;
            this.txtClosedDate.Value = null;
            // 
            // cboCarrier
            // 
            this.cboCarrier.Add = false;
            this.cboCarrier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCarrier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCarrier.Caption = "Carrier";
            this.cboCarrier.DataSource = null;
            this.cboCarrier.DBField = null;
            this.cboCarrier.DBFieldType = null;
            this.cboCarrier.DefaultValue = null;
            this.cboCarrier.Del = false;
            this.cboCarrier.DependingRS = null;
            this.cboCarrier.DisplayMember = "";
            this.cboCarrier.ExtraDataLink = null;
            this.cboCarrier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCarrier.FormattingEnabled = false;
            this.cboCarrier.IsCTLMOwned = false;
            this.cboCarrier.Location = new System.Drawing.Point(12, 95);
            this.cboCarrier.Name = "cboCarrier";
            this.cboCarrier.Order = 0;
            this.cboCarrier.ParentConn = null;
            this.cboCarrier.ParentDA = null;
            this.cboCarrier.PK = false;
            this.cboCarrier.Protected = false;
            this.cboCarrier.ReadOnly = false;
            this.cboCarrier.Search = false;
            this.cboCarrier.SelectedItem = null;
            this.cboCarrier.SelectedValue = null;
            this.cboCarrier.Size = new System.Drawing.Size(114, 40);
            this.cboCarrier.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboCarrier.TabIndex = 53;
            this.cboCarrier.TBDescription = null;
            this.cboCarrier.Upp = false;
            this.cboCarrier.Value = "";
            this.cboCarrier.ValueMember = "";
            // 
            // txtCarrierDescription
            // 
            this.txtCarrierDescription.Add = false;
            this.txtCarrierDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCarrierDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCarrierDescription.Caption = "Description";
            this.txtCarrierDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCarrierDescription.DBField = null;
            this.txtCarrierDescription.DBFieldType = null;
            this.txtCarrierDescription.DefaultValue = null;
            this.txtCarrierDescription.Del = false;
            this.txtCarrierDescription.DependingRS = null;
            this.txtCarrierDescription.ExtraDataLink = null;
            this.txtCarrierDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtCarrierDescription.IsCTLMOwned = false;
            this.txtCarrierDescription.IsPassword = false;
            this.txtCarrierDescription.Location = new System.Drawing.Point(130, 96);
            this.txtCarrierDescription.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtCarrierDescription.Multiline = true;
            this.txtCarrierDescription.Name = "txtCarrierDescription";
            this.txtCarrierDescription.Order = 0;
            this.txtCarrierDescription.ParentConn = null;
            this.txtCarrierDescription.ParentDA = null;
            this.txtCarrierDescription.PK = false;
            this.txtCarrierDescription.Protected = false;
            this.txtCarrierDescription.ReadOnly = true;
            this.txtCarrierDescription.Search = false;
            this.txtCarrierDescription.Size = new System.Drawing.Size(232, 39);
            this.txtCarrierDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtCarrierDescription.TabIndex = 54;
            this.txtCarrierDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCarrierDescription.Upp = false;
            this.txtCarrierDescription.Value = "";
            this.txtCarrierDescription.WordWrap = true;
            // 
            // txtPlate
            // 
            this.txtPlate.Add = false;
            this.txtPlate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPlate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPlate.Caption = "Plate";
            this.txtPlate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPlate.DBField = null;
            this.txtPlate.DBFieldType = null;
            this.txtPlate.DefaultValue = null;
            this.txtPlate.Del = false;
            this.txtPlate.DependingRS = null;
            this.txtPlate.ExtraDataLink = null;
            this.txtPlate.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtPlate.IsCTLMOwned = false;
            this.txtPlate.IsPassword = false;
            this.txtPlate.Location = new System.Drawing.Point(248, 48);
            this.txtPlate.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtPlate.Multiline = true;
            this.txtPlate.Name = "txtPlate";
            this.txtPlate.Order = 0;
            this.txtPlate.ParentConn = null;
            this.txtPlate.ParentDA = null;
            this.txtPlate.PK = false;
            this.txtPlate.Protected = false;
            this.txtPlate.ReadOnly = false;
            this.txtPlate.Search = false;
            this.txtPlate.Size = new System.Drawing.Size(114, 41);
            this.txtPlate.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPlate.TabIndex = 55;
            this.txtPlate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPlate.Upp = false;
            this.txtPlate.Value = "";
            this.txtPlate.WordWrap = true;
            // 
            // txtDate
            // 
            this.txtDate.Add = false;
            this.txtDate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDate.Caption = "Date";
            this.txtDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDate.DBField = null;
            this.txtDate.DBFieldType = null;
            this.txtDate.DefaultValue = null;
            this.txtDate.Del = false;
            this.txtDate.DependingRS = null;
            this.txtDate.ExtraDataLink = null;
            this.txtDate.ForeColor = System.Drawing.Color.Gray;
            this.txtDate.IsCTLMOwned = false;
            this.txtDate.IsPassword = false;
            this.txtDate.Location = new System.Drawing.Point(368, 50);
            this.txtDate.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDate.Multiline = true;
            this.txtDate.Name = "txtDate";
            this.txtDate.Order = 0;
            this.txtDate.ParentConn = null;
            this.txtDate.ParentDA = null;
            this.txtDate.PK = false;
            this.txtDate.Protected = false;
            this.txtDate.ReadOnly = true;
            this.txtDate.Search = false;
            this.txtDate.Size = new System.Drawing.Size(133, 39);
            this.txtDate.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDate.TabIndex = 56;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDate.Upp = false;
            this.txtDate.Value = "";
            this.txtDate.WordWrap = true;
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose});
            this.toolStrip.Location = new System.Drawing.Point(429, 15);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(103, 27);
            this.toolStrip.TabIndex = 58;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.Image = global::DealerPickPack.Properties.Resources.close_36x36;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(60, 24);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // fDeliveries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 402);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtPlate);
            this.Controls.Add(this.txtCarrierDescription);
            this.Controls.Add(this.cboCarrier);
            this.Controls.Add(this.txtClosedDate);
            this.Controls.Add(this.txtDelivery);
            this.Controls.Add(this.cboRoute);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.CTLM);
            this.Name = "fDeliveries";
            this.Text = "Deliveries";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.EspackTextBox txtDelivery;
        private EspackFormControlsNS.EspackComboBox cboRoute;
        private EspackDataGridView.EspackDataGridViewControl VS;
        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackDateTimePicker txtClosedDate;
        private EspackFormControlsNS.EspackComboBox cboCarrier;
        private EspackFormControlsNS.EspackTextBox txtCarrierDescription;
        private EspackFormControlsNS.EspackTextBox txtPlate;
        private EspackFormControlsNS.EspackTextBox txtDate;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnClose;
    }
}