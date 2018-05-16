namespace Repairs
{
    partial class fReceivals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fReceivals));
            this.VS = new VSGrid.CtlVSGrid();
            this.lstFlags = new EspackFormControls.EspackCheckedListBox();
            this.cboService = new EspackFormControls.EspackComboBox();
            this.txtNotes = new EspackFormControls.EspackTextBox();
            this.CTLM = new CTLMantenimientoNet.CTLMantenimientoNet();
            this.txtDescService = new EspackFormControls.EspackTextBox();
            this.txtDate = new EspackFormControls.EspackDateTimePicker();
            this.txtReceivalNumber = new EspackFormControls.EspackTextBox();
            this.txtSupplierDoc = new EspackFormControls.EspackTextBox();
            this.txtUser = new EspackFormControls.EspackTextBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.VS)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // VS
            // 
            this.VS.Add = false;
            this.VS.AllowDelete = false;
            this.VS.AllowInsert = false;
            this.VS.AllowUpdate = false;
            this.VS.AllowUserToAddRows = false;
            this.VS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.VS.Caption = "";
            this.VS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VS.Conn = null;
            this.VS.DBField = null;
            this.VS.DBFieldType = null;
            this.VS.DBTable = null;
            this.VS.DefaultValue = null;
            this.VS.Del = false;
            this.VS.DependingRS = null;
            this.VS.EspackControlParent = null;
            this.VS.ExtraDataLink = null;
            this.VS.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.VS.Location = new System.Drawing.Point(9, 222);
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
            this.VS.RowHeadersVisible = false;
            this.VS.Search = false;
            this.VS.Size = new System.Drawing.Size(690, 286);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.SetStatus(CommonTools.EnumStatus.SEARCH);
            this.VS.TabIndex = 55;
            this.VS.Upp = false;
            this.VS.Value = null;
            // 
            // lstFlags
            // 
            this.lstFlags.Add = false;
            this.lstFlags.BackColor = System.Drawing.Color.White;
            this.lstFlags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFlags.Caption = "";
            this.lstFlags.CheckOnClick = true;
            this.lstFlags.DBField = null;
            this.lstFlags.DBFieldType = null;
            this.lstFlags.DefaultValue = null;
            this.lstFlags.Del = false;
            this.lstFlags.DependingRS = null;
            this.lstFlags.ExtraDataLink = null;
            this.lstFlags.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lstFlags.ForeColor = System.Drawing.Color.Black;
            this.lstFlags.FormattingEnabled = true;
            this.lstFlags.Location = new System.Drawing.Point(9, 159);
            this.lstFlags.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstFlags.Name = "lstFlags";
            this.lstFlags.Order = 0;
            this.lstFlags.ParentConn = null;
            this.lstFlags.ParentDA = null;
            this.lstFlags.PK = false;
            this.lstFlags.Protected = false;
            this.lstFlags.Search = false;
            this.lstFlags.Size = new System.Drawing.Size(690, 57);
            this.lstFlags.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.lstFlags.TabIndex = 54;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            // 
            // cboService
            // 
            this.cboService.Add = false;
            this.cboService.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboService.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboService.BackColor = System.Drawing.Color.White;
            this.cboService.Caption = "Service";
            this.cboService.DBField = null;
            this.cboService.DBFieldType = null;
            this.cboService.DefaultValue = null;
            this.cboService.Del = false;
            this.cboService.DependingRS = null;
            this.cboService.ExtraDataLink = null;
            this.cboService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboService.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboService.ForeColor = System.Drawing.Color.Black;
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(128, 54);
            this.cboService.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboService.Name = "cboService";
            this.cboService.Order = 0;
            this.cboService.ParentConn = null;
            this.cboService.ParentDA = null;
            this.cboService.PK = false;
            this.cboService.Protected = false;
            this.cboService.Search = false;
            this.cboService.Size = new System.Drawing.Size(110, 24);
            this.cboService.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.cboService.TabIndex = 53;
            this.cboService.TBDescription = null;
            this.cboService.Upp = false;
            this.cboService.Value = "";
            // 
            // txtNotes
            // 
            this.txtNotes.Add = false;
            this.txtNotes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotes.Caption = "Notes";
            this.txtNotes.DBField = null;
            this.txtNotes.DBFieldType = null;
            this.txtNotes.DefaultValue = null;
            this.txtNotes.Del = false;
            this.txtNotes.DependingRS = null;
            this.txtNotes.ExtraDataLink = null;
            this.txtNotes.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNotes.ForeColor = System.Drawing.Color.Gray;
            this.txtNotes.Location = new System.Drawing.Point(12, 126);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Order = 0;
            this.txtNotes.ParentConn = null;
            this.txtNotes.ParentDA = null;
            this.txtNotes.PK = false;
            this.txtNotes.Protected = false;
            this.txtNotes.ReadOnly = true;
            this.txtNotes.Search = false;
            this.txtNotes.Size = new System.Drawing.Size(689, 17);
            this.txtNotes.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.txtNotes.TabIndex = 52;
            this.txtNotes.Upp = false;
            this.txtNotes.Value = "";
            // 
            // CTLM
            // 
            this.CTLM.Clear = false;
            this.CTLM.Conn = null;
            this.CTLM.DBTable = null;
            this.CTLM.Dock = System.Windows.Forms.DockStyle.None;
            this.CTLM.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.CTLM.Location = new System.Drawing.Point(9, 9);
            this.CTLM.MsgStatusInfoLabel = null;
            this.CTLM.MsgStatusLabel = null;
            this.CTLM.Name = "CTLM";
            this.CTLM.ReQuery = false;
            this.CTLM.Size = new System.Drawing.Size(290, 29);
            this.CTLM.sSPAdd = "";
            this.CTLM.sSPDel = "";
            this.CTLM.sSPUpp = "";
            this.CTLM.StatusBarProgress = null;
            this.CTLM.TabIndex = 51;
            this.CTLM.Text = "ctlMantenimientoNet1";
            // 
            // txtDescService
            // 
            this.txtDescService.Add = false;
            this.txtDescService.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtDescService.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescService.Caption = "";
            this.txtDescService.DBField = null;
            this.txtDescService.DBFieldType = null;
            this.txtDescService.DefaultValue = null;
            this.txtDescService.Del = false;
            this.txtDescService.DependingRS = null;
            this.txtDescService.ExtraDataLink = null;
            this.txtDescService.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDescService.ForeColor = System.Drawing.Color.Gray;
            this.txtDescService.Location = new System.Drawing.Point(244, 57);
            this.txtDescService.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDescService.Name = "txtDescService";
            this.txtDescService.Order = 0;
            this.txtDescService.ParentConn = null;
            this.txtDescService.ParentDA = null;
            this.txtDescService.PK = false;
            this.txtDescService.Protected = false;
            this.txtDescService.ReadOnly = true;
            this.txtDescService.Search = false;
            this.txtDescService.Size = new System.Drawing.Size(316, 17);
            this.txtDescService.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.txtDescService.TabIndex = 57;
            this.txtDescService.Upp = false;
            this.txtDescService.Value = "";
            // 
            // txtDate
            // 
            this.txtDate.Add = false;
            this.txtDate.BackColor = System.Drawing.Color.White;
            this.txtDate.BorderColor = System.Drawing.Color.White;
            this.txtDate.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.txtDate.Caption = "Date";
            this.txtDate.CustomFormat = "dd/MM/yyyy H:mm";
            this.txtDate.DBField = null;
            this.txtDate.DBFieldType = null;
            this.txtDate.DefaultValue = null;
            this.txtDate.Del = false;
            this.txtDate.DependingRS = null;
            this.txtDate.ExtraDataLink = null;
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDate.ForeColor = System.Drawing.Color.Black;
            this.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDate.Location = new System.Drawing.Point(566, 54);
            this.txtDate.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDate.Name = "txtDate";
            this.txtDate.Nullable = true;
            this.txtDate.Order = 0;
            this.txtDate.ParentConn = null;
            this.txtDate.ParentDA = null;
            this.txtDate.PK = false;
            this.txtDate.Protected = false;
            this.txtDate.Search = false;
            this.txtDate.ShowCheckBox = true;
            this.txtDate.Size = new System.Drawing.Size(135, 24);
            this.txtDate.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.txtDate.TabIndex = 63;
            this.txtDate.Upp = false;
            this.txtDate.Value = new System.DateTime(2016, 6, 22, 13, 36, 41, 91);
            // 
            // txtReceivalNumber
            // 
            this.txtReceivalNumber.Add = false;
            this.txtReceivalNumber.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtReceivalNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReceivalNumber.Caption = "Receival Number";
            this.txtReceivalNumber.DBField = null;
            this.txtReceivalNumber.DBFieldType = null;
            this.txtReceivalNumber.DefaultValue = null;
            this.txtReceivalNumber.Del = false;
            this.txtReceivalNumber.DependingRS = null;
            this.txtReceivalNumber.ExtraDataLink = null;
            this.txtReceivalNumber.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtReceivalNumber.ForeColor = System.Drawing.Color.Gray;
            this.txtReceivalNumber.Location = new System.Drawing.Point(12, 54);
            this.txtReceivalNumber.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtReceivalNumber.Name = "txtReceivalNumber";
            this.txtReceivalNumber.Order = 0;
            this.txtReceivalNumber.ParentConn = null;
            this.txtReceivalNumber.ParentDA = null;
            this.txtReceivalNumber.PK = false;
            this.txtReceivalNumber.Protected = false;
            this.txtReceivalNumber.ReadOnly = true;
            this.txtReceivalNumber.Search = false;
            this.txtReceivalNumber.Size = new System.Drawing.Size(110, 17);
            this.txtReceivalNumber.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.txtReceivalNumber.TabIndex = 62;
            this.txtReceivalNumber.Upp = false;
            this.txtReceivalNumber.Value = "";
            // 
            // txtSupplierDoc
            // 
            this.txtSupplierDoc.Add = false;
            this.txtSupplierDoc.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSupplierDoc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupplierDoc.Caption = "Supplier Document";
            this.txtSupplierDoc.DBField = null;
            this.txtSupplierDoc.DBFieldType = null;
            this.txtSupplierDoc.DefaultValue = null;
            this.txtSupplierDoc.Del = false;
            this.txtSupplierDoc.DependingRS = null;
            this.txtSupplierDoc.ExtraDataLink = null;
            this.txtSupplierDoc.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSupplierDoc.ForeColor = System.Drawing.Color.Gray;
            this.txtSupplierDoc.Location = new System.Drawing.Point(11, 90);
            this.txtSupplierDoc.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtSupplierDoc.Name = "txtSupplierDoc";
            this.txtSupplierDoc.Order = 0;
            this.txtSupplierDoc.ParentConn = null;
            this.txtSupplierDoc.ParentDA = null;
            this.txtSupplierDoc.PK = false;
            this.txtSupplierDoc.Protected = false;
            this.txtSupplierDoc.ReadOnly = true;
            this.txtSupplierDoc.Search = false;
            this.txtSupplierDoc.Size = new System.Drawing.Size(227, 17);
            this.txtSupplierDoc.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.txtSupplierDoc.TabIndex = 65;
            this.txtSupplierDoc.Upp = false;
            this.txtSupplierDoc.Value = "";
            // 
            // txtUser
            // 
            this.txtUser.Add = false;
            this.txtUser.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Caption = "User";
            this.txtUser.DBField = null;
            this.txtUser.DBFieldType = null;
            this.txtUser.DefaultValue = null;
            this.txtUser.Del = false;
            this.txtUser.DependingRS = null;
            this.txtUser.ExtraDataLink = null;
            this.txtUser.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtUser.ForeColor = System.Drawing.Color.Gray;
            this.txtUser.Location = new System.Drawing.Point(244, 90);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtUser.Name = "txtUser";
            this.txtUser.Order = 0;
            this.txtUser.ParentConn = null;
            this.txtUser.ParentDA = null;
            this.txtUser.PK = false;
            this.txtUser.Protected = false;
            this.txtUser.ReadOnly = true;
            this.txtUser.Search = false;
            this.txtUser.Size = new System.Drawing.Size(145, 17);
            this.txtUser.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.txtUser.TabIndex = 67;
            this.txtUser.Upp = false;
            this.txtUser.Value = "";
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint});
            this.toolStrip.Location = new System.Drawing.Point(630, 7);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(103, 31);
            this.toolStrip.TabIndex = 76;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip_ItemClicked);
            // 
            // btnPrint
            // 
            this.btnPrint.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPrint.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.Image")));
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(60, 28);
            this.btnPrint.Text = "Print";
            // 
            // fReceivals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 532);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtSupplierDoc);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtReceivalNumber);
            this.Controls.Add(this.txtDescService);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.lstFlags);
            this.Controls.Add(this.cboService);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.CTLM);
            this.Name = "fReceivals";
            this.ShowIcon = false;
            this.Text = "Receivals";
            ((System.ComponentModel.ISupportInitialize)(this.VS)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private VSGrid.CtlVSGrid VS;
        private EspackFormControls.EspackCheckedListBox lstFlags;
        private EspackFormControls.EspackComboBox cboService;
        private EspackFormControls.EspackTextBox txtNotes;
        private CTLMantenimientoNet.CTLMantenimientoNet CTLM;
        private EspackFormControls.EspackTextBox txtDescService;
        private EspackFormControls.EspackDateTimePicker txtDate;
        private EspackFormControls.EspackTextBox txtReceivalNumber;
        private EspackFormControls.EspackTextBox txtSupplierDoc;
        private EspackFormControls.EspackTextBox txtUser;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnPrint;
    }
}