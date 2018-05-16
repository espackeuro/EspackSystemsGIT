namespace Simplistica
{
    partial class fSimpleDeliveriesEPC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSimpleDeliveriesEPC));
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.cboService = new EspackFormControls.EspackComboBox();
            this.lstFlags = new EspackFormControls.EspackCheckedListBox();
            this.dateEnd = new EspackFormControls.EspackDateTimePicker();
            this.dateStart = new EspackFormControls.EspackDateTimePicker();
            this.dateEPC = new EspackFormControls.EspackDateTimePicker();
            this.dateCheckPoint = new EspackFormControls.EspackDateTimePicker();
            this.txtTruckPlate = new EspackFormControls.EspackTextBox();
            this.cboDock = new EspackFormControls.EspackComboBox();
            this.txtResponsible = new EspackFormControls.EspackTextBox();
            this.cboShift = new EspackFormControls.EspackComboBox();
            this.txtDeliveryN = new EspackFormControls.EspackTextBox();
            this.VS = new EspackDataGrid.EspackDataGridView();
            this.CTLM = new CTLMantenimientoNet.CTLMantenimientoNet();
            this.txtTrailerPlate = new EspackFormControls.EspackTextBox();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VS)).BeginInit();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(809, 652);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.toolStripButton2,
            this.btnPrint});
            this.toolStrip.Location = new System.Drawing.Point(565, 9);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(142, 31);
            this.toolStrip.TabIndex = 57;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 28);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(6, 31);
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
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
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
            this.cboService.IsCTLMOwned = false;
            this.cboService.Location = new System.Drawing.Point(145, 53);
            this.cboService.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboService.Name = "cboService";
            this.cboService.Order = 0;
            this.cboService.ParentConn = null;
            this.cboService.ParentDA = null;
            this.cboService.PK = false;
            this.cboService.Protected = false;
            this.cboService.Search = false;
            this.cboService.Size = new System.Drawing.Size(130, 24);
            this.cboService.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.cboService.TabIndex = 1;
            this.cboService.TBDescription = null;
            this.cboService.Upp = false;
            this.cboService.Value = "";
            // 
            // lstFlags
            // 
            this.lstFlags.Add = false;
            this.lstFlags.BackColor = System.Drawing.Color.White;
            this.lstFlags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFlags.Caption = "Flags";
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
            this.lstFlags.IsCTLMOwned = false;
            this.lstFlags.Location = new System.Drawing.Point(12, 133);
            this.lstFlags.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstFlags.Name = "lstFlags";
            this.lstFlags.Order = 0;
            this.lstFlags.ParentConn = null;
            this.lstFlags.ParentDA = null;
            this.lstFlags.PK = false;
            this.lstFlags.Protected = false;
            this.lstFlags.Search = false;
            this.lstFlags.Size = new System.Drawing.Size(535, 76);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 12;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            // 
            // dateEnd
            // 
            this.dateEnd.Add = false;
            this.dateEnd.BackColor = System.Drawing.Color.White;
            this.dateEnd.BorderColor = System.Drawing.Color.White;
            this.dateEnd.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.dateEnd.Caption = "Load End";
            this.dateEnd.Checked = false;
            this.dateEnd.CustomFormat = " ";
            this.dateEnd.DBField = null;
            this.dateEnd.DBFieldType = null;
            this.dateEnd.DefaultValue = null;
            this.dateEnd.Del = false;
            this.dateEnd.DependingRS = null;
            this.dateEnd.ExtraDataLink = null;
            this.dateEnd.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateEnd.ForeColor = System.Drawing.Color.Black;
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.IsCTLMOwned = false;
            this.dateEnd.Location = new System.Drawing.Point(553, 183);
            this.dateEnd.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Nullable = true;
            this.dateEnd.Order = 0;
            this.dateEnd.ParentConn = null;
            this.dateEnd.ParentDA = null;
            this.dateEnd.PK = false;
            this.dateEnd.Protected = false;
            this.dateEnd.Search = false;
            this.dateEnd.ShowCheckBox = true;
            this.dateEnd.Size = new System.Drawing.Size(152, 24);
            this.dateEnd.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.dateEnd.TabIndex = 11;
            this.dateEnd.Upp = false;
            this.dateEnd.Value = null;
            // 
            // dateStart
            // 
            this.dateStart.Add = false;
            this.dateStart.BackColor = System.Drawing.Color.White;
            this.dateStart.BorderColor = System.Drawing.Color.White;
            this.dateStart.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.dateStart.Caption = "Load Start";
            this.dateStart.Checked = false;
            this.dateStart.CustomFormat = " ";
            this.dateStart.DBField = null;
            this.dateStart.DBFieldType = null;
            this.dateStart.DefaultValue = null;
            this.dateStart.Del = false;
            this.dateStart.DependingRS = null;
            this.dateStart.ExtraDataLink = null;
            this.dateStart.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateStart.ForeColor = System.Drawing.Color.Black;
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart.IsCTLMOwned = false;
            this.dateStart.Location = new System.Drawing.Point(553, 140);
            this.dateStart.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.dateStart.Name = "dateStart";
            this.dateStart.Nullable = true;
            this.dateStart.Order = 0;
            this.dateStart.ParentConn = null;
            this.dateStart.ParentDA = null;
            this.dateStart.PK = false;
            this.dateStart.Protected = false;
            this.dateStart.Search = false;
            this.dateStart.ShowCheckBox = true;
            this.dateStart.Size = new System.Drawing.Size(152, 24);
            this.dateStart.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.dateStart.TabIndex = 10;
            this.dateStart.Upp = false;
            this.dateStart.Value = null;
            // 
            // dateEPC
            // 
            this.dateEPC.Add = false;
            this.dateEPC.BackColor = System.Drawing.Color.White;
            this.dateEPC.BorderColor = System.Drawing.Color.White;
            this.dateEPC.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.dateEPC.Caption = "EPC Entry Date";
            this.dateEPC.Checked = false;
            this.dateEPC.CustomFormat = " ";
            this.dateEPC.DBField = null;
            this.dateEPC.DBFieldType = null;
            this.dateEPC.DefaultValue = null;
            this.dateEPC.Del = false;
            this.dateEPC.DependingRS = null;
            this.dateEPC.Enabled = false;
            this.dateEPC.ExtraDataLink = null;
            this.dateEPC.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateEPC.ForeColor = System.Drawing.Color.Black;
            this.dateEPC.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEPC.IsCTLMOwned = false;
            this.dateEPC.Location = new System.Drawing.Point(553, 97);
            this.dateEPC.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.dateEPC.Name = "dateEPC";
            this.dateEPC.Nullable = true;
            this.dateEPC.Order = 0;
            this.dateEPC.ParentConn = null;
            this.dateEPC.ParentDA = null;
            this.dateEPC.PK = false;
            this.dateEPC.Protected = false;
            this.dateEPC.Search = false;
            this.dateEPC.ShowCheckBox = true;
            this.dateEPC.Size = new System.Drawing.Size(152, 24);
            this.dateEPC.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.dateEPC.TabIndex = 9;
            this.dateEPC.Upp = false;
            this.dateEPC.Value = null;
            // 
            // dateCheckPoint
            // 
            this.dateCheckPoint.Add = false;
            this.dateCheckPoint.BackColor = System.Drawing.Color.White;
            this.dateCheckPoint.BorderColor = System.Drawing.Color.White;
            this.dateCheckPoint.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.dateCheckPoint.Caption = "CheckPoint Date";
            this.dateCheckPoint.Checked = false;
            this.dateCheckPoint.CustomFormat = " ";
            this.dateCheckPoint.DBField = null;
            this.dateCheckPoint.DBFieldType = null;
            this.dateCheckPoint.DefaultValue = null;
            this.dateCheckPoint.Del = false;
            this.dateCheckPoint.DependingRS = null;
            this.dateCheckPoint.ExtraDataLink = null;
            this.dateCheckPoint.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateCheckPoint.ForeColor = System.Drawing.Color.Black;
            this.dateCheckPoint.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCheckPoint.IsCTLMOwned = false;
            this.dateCheckPoint.Location = new System.Drawing.Point(553, 54);
            this.dateCheckPoint.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.dateCheckPoint.Name = "dateCheckPoint";
            this.dateCheckPoint.Nullable = true;
            this.dateCheckPoint.Order = 0;
            this.dateCheckPoint.ParentConn = null;
            this.dateCheckPoint.ParentDA = null;
            this.dateCheckPoint.PK = false;
            this.dateCheckPoint.Protected = false;
            this.dateCheckPoint.Search = false;
            this.dateCheckPoint.ShowCheckBox = true;
            this.dateCheckPoint.Size = new System.Drawing.Size(152, 24);
            this.dateCheckPoint.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.dateCheckPoint.TabIndex = 8;
            this.dateCheckPoint.Upp = false;
            this.dateCheckPoint.Value = null;
            // 
            // txtTruckPlate
            // 
            this.txtTruckPlate.Add = false;
            this.txtTruckPlate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTruckPlate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTruckPlate.Caption = "Truck Plate";
            this.txtTruckPlate.DBField = null;
            this.txtTruckPlate.DBFieldType = null;
            this.txtTruckPlate.DefaultValue = null;
            this.txtTruckPlate.Del = false;
            this.txtTruckPlate.DependingRS = null;
            this.txtTruckPlate.ExtraDataLink = null;
            this.txtTruckPlate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTruckPlate.ForeColor = System.Drawing.Color.Gray;
            this.txtTruckPlate.IsCTLMOwned = false;
            this.txtTruckPlate.Location = new System.Drawing.Point(281, 54);
            this.txtTruckPlate.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtTruckPlate.Name = "txtTruckPlate";
            this.txtTruckPlate.Order = 0;
            this.txtTruckPlate.ParentConn = null;
            this.txtTruckPlate.ParentDA = null;
            this.txtTruckPlate.PK = false;
            this.txtTruckPlate.Protected = false;
            this.txtTruckPlate.ReadOnly = true;
            this.txtTruckPlate.Search = false;
            this.txtTruckPlate.Size = new System.Drawing.Size(130, 17);
            this.txtTruckPlate.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.txtTruckPlate.TabIndex = 2;
            this.txtTruckPlate.Upp = false;
            this.txtTruckPlate.Value = "";
            // 
            // cboDock
            // 
            this.cboDock.Add = false;
            this.cboDock.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDock.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDock.BackColor = System.Drawing.Color.White;
            this.cboDock.Caption = "Dock";
            this.cboDock.DBField = null;
            this.cboDock.DBFieldType = null;
            this.cboDock.DefaultValue = null;
            this.cboDock.Del = false;
            this.cboDock.DependingRS = null;
            this.cboDock.ExtraDataLink = null;
            this.cboDock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDock.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboDock.ForeColor = System.Drawing.Color.Black;
            this.cboDock.FormattingEnabled = true;
            this.cboDock.IsCTLMOwned = false;
            this.cboDock.Location = new System.Drawing.Point(12, 97);
            this.cboDock.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboDock.Name = "cboDock";
            this.cboDock.Order = 0;
            this.cboDock.ParentConn = null;
            this.cboDock.ParentDA = null;
            this.cboDock.PK = false;
            this.cboDock.Protected = false;
            this.cboDock.Search = false;
            this.cboDock.Size = new System.Drawing.Size(127, 24);
            this.cboDock.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboDock.TabIndex = 5;
            this.cboDock.TBDescription = null;
            this.cboDock.Upp = false;
            this.cboDock.Value = "";
            // 
            // txtResponsible
            // 
            this.txtResponsible.Add = false;
            this.txtResponsible.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtResponsible.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResponsible.Caption = "Load Responsible";
            this.txtResponsible.DBField = null;
            this.txtResponsible.DBFieldType = null;
            this.txtResponsible.DefaultValue = null;
            this.txtResponsible.Del = false;
            this.txtResponsible.DependingRS = null;
            this.txtResponsible.ExtraDataLink = null;
            this.txtResponsible.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtResponsible.ForeColor = System.Drawing.Color.Gray;
            this.txtResponsible.IsCTLMOwned = false;
            this.txtResponsible.Location = new System.Drawing.Point(281, 97);
            this.txtResponsible.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtResponsible.Name = "txtResponsible";
            this.txtResponsible.Order = 0;
            this.txtResponsible.ParentConn = null;
            this.txtResponsible.ParentDA = null;
            this.txtResponsible.PK = false;
            this.txtResponsible.Protected = false;
            this.txtResponsible.ReadOnly = true;
            this.txtResponsible.Search = false;
            this.txtResponsible.Size = new System.Drawing.Size(266, 17);
            this.txtResponsible.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtResponsible.TabIndex = 7;
            this.txtResponsible.Upp = false;
            this.txtResponsible.Value = "";
            // 
            // cboShift
            // 
            this.cboShift.Add = false;
            this.cboShift.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboShift.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboShift.BackColor = System.Drawing.Color.White;
            this.cboShift.Caption = "Shift";
            this.cboShift.DBField = null;
            this.cboShift.DBFieldType = null;
            this.cboShift.DefaultValue = null;
            this.cboShift.Del = false;
            this.cboShift.DependingRS = null;
            this.cboShift.ExtraDataLink = null;
            this.cboShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboShift.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboShift.ForeColor = System.Drawing.Color.Black;
            this.cboShift.FormattingEnabled = true;
            this.cboShift.IsCTLMOwned = false;
            this.cboShift.Items.AddRange(new object[] {
            "Morning",
            "Afternoon",
            "Night"});
            this.cboShift.Location = new System.Drawing.Point(145, 97);
            this.cboShift.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboShift.Name = "cboShift";
            this.cboShift.Order = 0;
            this.cboShift.ParentConn = null;
            this.cboShift.ParentDA = null;
            this.cboShift.PK = false;
            this.cboShift.Protected = false;
            this.cboShift.Search = false;
            this.cboShift.Size = new System.Drawing.Size(130, 24);
            this.cboShift.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.cboShift.TabIndex = 4;
            this.cboShift.TBDescription = null;
            this.cboShift.Upp = false;
            this.cboShift.Value = "";
            // 
            // txtDeliveryN
            // 
            this.txtDeliveryN.Add = false;
            this.txtDeliveryN.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtDeliveryN.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDeliveryN.Caption = "Delivery Number";
            this.txtDeliveryN.DBField = null;
            this.txtDeliveryN.DBFieldType = null;
            this.txtDeliveryN.DefaultValue = null;
            this.txtDeliveryN.Del = false;
            this.txtDeliveryN.DependingRS = null;
            this.txtDeliveryN.ExtraDataLink = null;
            this.txtDeliveryN.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDeliveryN.ForeColor = System.Drawing.Color.Gray;
            this.txtDeliveryN.IsCTLMOwned = false;
            this.txtDeliveryN.Location = new System.Drawing.Point(9, 54);
            this.txtDeliveryN.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDeliveryN.Name = "txtDeliveryN";
            this.txtDeliveryN.Order = 0;
            this.txtDeliveryN.ParentConn = null;
            this.txtDeliveryN.ParentDA = null;
            this.txtDeliveryN.PK = false;
            this.txtDeliveryN.Protected = false;
            this.txtDeliveryN.ReadOnly = true;
            this.txtDeliveryN.Search = false;
            this.txtDeliveryN.Size = new System.Drawing.Size(130, 17);
            this.txtDeliveryN.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.txtDeliveryN.TabIndex = 0;
            this.txtDeliveryN.Upp = false;
            this.txtDeliveryN.Value = "";
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
            this.VS.IsCTLMOwned = false;
            this.VS.Location = new System.Drawing.Point(9, 229);
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
            this.VS.Size = new System.Drawing.Size(698, 308);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.SetStatus(CommonTools.EnumStatus.SEARCH);
            this.VS.TabIndex = 13;
            this.VS.Upp = false;
            this.VS.Value = null;
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
            this.CTLM.TabIndex = 56;
            this.CTLM.Text = "ctlMantenimientoNet1";
            // 
            // txtTrailerPlate
            // 
            this.txtTrailerPlate.Add = false;
            this.txtTrailerPlate.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtTrailerPlate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTrailerPlate.Caption = "Trailer Plate";
            this.txtTrailerPlate.DBField = null;
            this.txtTrailerPlate.DBFieldType = null;
            this.txtTrailerPlate.DefaultValue = null;
            this.txtTrailerPlate.Del = false;
            this.txtTrailerPlate.DependingRS = null;
            this.txtTrailerPlate.ExtraDataLink = null;
            this.txtTrailerPlate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTrailerPlate.ForeColor = System.Drawing.Color.Gray;
            this.txtTrailerPlate.IsCTLMOwned = false;
            this.txtTrailerPlate.Location = new System.Drawing.Point(417, 54);
            this.txtTrailerPlate.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtTrailerPlate.Name = "txtTrailerPlate";
            this.txtTrailerPlate.Order = 0;
            this.txtTrailerPlate.ParentConn = null;
            this.txtTrailerPlate.ParentDA = null;
            this.txtTrailerPlate.PK = false;
            this.txtTrailerPlate.Protected = false;
            this.txtTrailerPlate.ReadOnly = true;
            this.txtTrailerPlate.Search = false;
            this.txtTrailerPlate.Size = new System.Drawing.Size(130, 17);
            this.txtTrailerPlate.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.txtTrailerPlate.TabIndex = 3;
            this.txtTrailerPlate.Upp = false;
            this.txtTrailerPlate.Value = "";
            // 
            // fSimpleDeliveriesEPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(719, 552);
            this.Controls.Add(this.txtTrailerPlate);
            this.Controls.Add(this.cboService);
            this.Controls.Add(this.lstFlags);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.dateEPC);
            this.Controls.Add(this.dateCheckPoint);
            this.Controls.Add(this.txtTruckPlate);
            this.Controls.Add(this.cboDock);
            this.Controls.Add(this.txtResponsible);
            this.Controls.Add(this.cboShift);
            this.Controls.Add(this.txtDeliveryN);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.CTLM);
            this.Name = "fSimpleDeliveriesEPC";
            this.Text = "Simple Deliveries EPC";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnClose;
        private CTLMantenimientoNet.CTLMantenimientoNet CTLM;
        private EspackDataGrid.EspackDataGridView VS;
        private EspackFormControls.EspackTextBox txtDeliveryN;
        private EspackFormControls.EspackComboBox cboShift;
        private EspackFormControls.EspackTextBox txtResponsible;
        private EspackFormControls.EspackComboBox cboDock;
        private EspackFormControls.EspackTextBox txtTruckPlate;
        private EspackFormControls.EspackDateTimePicker dateCheckPoint;
        private EspackFormControls.EspackDateTimePicker dateEPC;
        private EspackFormControls.EspackDateTimePicker dateStart;
        private EspackFormControls.EspackDateTimePicker dateEnd;
        private EspackFormControls.EspackCheckedListBox lstFlags;
        private EspackFormControls.EspackComboBox cboService;
        private System.Windows.Forms.ToolStripSeparator toolStripButton2;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private EspackFormControls.EspackTextBox txtTrailerPlate;
    }
}