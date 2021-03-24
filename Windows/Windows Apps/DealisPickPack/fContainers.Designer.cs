
namespace DealerPickPack
{
    partial class fContainers
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
            System.Windows.Forms.DataGridViewRow dataGridViewRow2 = new System.Windows.Forms.DataGridViewRow();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.VS = new EspackDataGridView.EspackDataGridViewControl();
            this.cboRoute = new EspackFormControlsNS.EspackComboBox();
            this.txtContainer = new EspackFormControlsNS.EspackTextBox();
            this.txtInDelivery = new EspackFormControlsNS.EspackTextBox();
            this.txtInDeliveryDate = new EspackFormControlsNS.EspackDateTimePicker();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.txtDate = new EspackFormControlsNS.EspackDateTimePicker();
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
            this.CTLM.Location = new System.Drawing.Point(12, 11);
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
            this.VS.Location = new System.Drawing.Point(10, 141);
            this.VS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            dataGridViewRow2.Height = 24;
            this.VS.RowTemplate = dataGridViewRow2;
            this.VS.Search = false;
            this.VS.Size = new System.Drawing.Size(392, 168);
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
            this.cboRoute.Location = new System.Drawing.Point(138, 47);
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
            this.cboRoute.Size = new System.Drawing.Size(126, 40);
            this.cboRoute.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboRoute.TabIndex = 44;
            this.cboRoute.TBDescription = null;
            this.cboRoute.Upp = false;
            this.cboRoute.Value = "";
            this.cboRoute.ValueMember = "";
            // 
            // txtContainer
            // 
            this.txtContainer.Add = false;
            this.txtContainer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtContainer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtContainer.Caption = "Container";
            this.txtContainer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtContainer.DBField = null;
            this.txtContainer.DBFieldType = null;
            this.txtContainer.DefaultValue = null;
            this.txtContainer.Del = false;
            this.txtContainer.DependingRS = null;
            this.txtContainer.ExtraDataLink = null;
            this.txtContainer.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtContainer.IsCTLMOwned = false;
            this.txtContainer.IsPassword = false;
            this.txtContainer.Location = new System.Drawing.Point(12, 47);
            this.txtContainer.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtContainer.Multiline = true;
            this.txtContainer.Name = "txtContainer";
            this.txtContainer.Order = 0;
            this.txtContainer.ParentConn = null;
            this.txtContainer.ParentDA = null;
            this.txtContainer.PK = false;
            this.txtContainer.Protected = false;
            this.txtContainer.ReadOnly = false;
            this.txtContainer.Search = false;
            this.txtContainer.Size = new System.Drawing.Size(120, 38);
            this.txtContainer.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtContainer.TabIndex = 46;
            this.txtContainer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtContainer.Upp = false;
            this.txtContainer.Value = "";
            this.txtContainer.WordWrap = true;
            // 
            // txtInDelivery
            // 
            this.txtInDelivery.Add = false;
            this.txtInDelivery.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtInDelivery.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtInDelivery.Caption = "In Delivery";
            this.txtInDelivery.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtInDelivery.DBField = null;
            this.txtInDelivery.DBFieldType = null;
            this.txtInDelivery.DefaultValue = null;
            this.txtInDelivery.Del = false;
            this.txtInDelivery.DependingRS = null;
            this.txtInDelivery.ExtraDataLink = null;
            this.txtInDelivery.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtInDelivery.IsCTLMOwned = false;
            this.txtInDelivery.IsPassword = false;
            this.txtInDelivery.Location = new System.Drawing.Point(10, 95);
            this.txtInDelivery.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtInDelivery.Multiline = true;
            this.txtInDelivery.Name = "txtInDelivery";
            this.txtInDelivery.Order = 0;
            this.txtInDelivery.ParentConn = null;
            this.txtInDelivery.ParentDA = null;
            this.txtInDelivery.PK = false;
            this.txtInDelivery.Protected = false;
            this.txtInDelivery.ReadOnly = false;
            this.txtInDelivery.Search = false;
            this.txtInDelivery.Size = new System.Drawing.Size(122, 38);
            this.txtInDelivery.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtInDelivery.TabIndex = 47;
            this.txtInDelivery.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtInDelivery.Upp = false;
            this.txtInDelivery.Value = "";
            this.txtInDelivery.WordWrap = true;
            // 
            // txtInDeliveryDate
            // 
            this.txtInDeliveryDate.Add = false;
            this.txtInDeliveryDate.BorderColor = System.Drawing.Color.White;
            this.txtInDeliveryDate.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.txtInDeliveryDate.Caption = "In Delivery Date";
            this.txtInDeliveryDate.Checked = false;
            this.txtInDeliveryDate.CustomFormat = " ";
            this.txtInDeliveryDate.DBField = null;
            this.txtInDeliveryDate.DBFieldType = null;
            this.txtInDeliveryDate.DefaultValue = null;
            this.txtInDeliveryDate.Del = false;
            this.txtInDeliveryDate.DependingRS = null;
            this.txtInDeliveryDate.ExtraDataLink = null;
            this.txtInDeliveryDate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtInDeliveryDate.ForeColor = System.Drawing.Color.Black;
            this.txtInDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtInDeliveryDate.IsCTLMOwned = false;
            this.txtInDeliveryDate.Location = new System.Drawing.Point(138, 96);
            this.txtInDeliveryDate.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtInDeliveryDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtInDeliveryDate.Name = "txtInDeliveryDate";
            this.txtInDeliveryDate.Nullable = true;
            this.txtInDeliveryDate.Order = 0;
            this.txtInDeliveryDate.ParentConn = null;
            this.txtInDeliveryDate.ParentDA = null;
            this.txtInDeliveryDate.PK = false;
            this.txtInDeliveryDate.Protected = false;
            this.txtInDeliveryDate.ReadOnly = false;
            this.txtInDeliveryDate.Search = false;
            this.txtInDeliveryDate.ShowCheckBox = true;
            this.txtInDeliveryDate.Size = new System.Drawing.Size(126, 39);
            this.txtInDeliveryDate.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtInDeliveryDate.TabIndex = 53;
            this.txtInDeliveryDate.Text = " ";
            this.txtInDeliveryDate.Upp = false;
            this.txtInDeliveryDate.Value = null;
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint});
            this.toolStrip.Location = new System.Drawing.Point(336, 15);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(68, 27);
            this.toolStrip.TabIndex = 60;
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
            this.txtDate.Location = new System.Drawing.Point(270, 47);
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
            this.txtDate.Size = new System.Drawing.Size(132, 39);
            this.txtDate.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDate.TabIndex = 61;
            this.txtDate.Text = " ";
            this.txtDate.Upp = false;
            this.txtDate.Value = null;
            // 
            // fContainers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 346);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.txtInDeliveryDate);
            this.Controls.Add(this.txtInDelivery);
            this.Controls.Add(this.txtContainer);
            this.Controls.Add(this.cboRoute);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.CTLM);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "fContainers";
            this.Tag = "fHUs";
            this.Text = "Containers";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackDataGridView.EspackDataGridViewControl VS;
        private EspackFormControlsNS.EspackComboBox cboRoute;
        private EspackFormControlsNS.EspackTextBox txtContainer;
        private EspackFormControlsNS.EspackTextBox txtInDelivery;
        private EspackFormControlsNS.EspackDateTimePicker txtInDeliveryDate;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private EspackFormControlsNS.EspackDateTimePicker txtDate;
    }
}