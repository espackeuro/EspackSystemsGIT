namespace Invoicing
{
    partial class fPurchaseOrders
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
            System.Windows.Forms.DataGridViewRow dataGridViewRow2 = new System.Windows.Forms.DataGridViewRow();
            this.txtPONumber = new EspackFormControlsNS.EspackTextBox();
            this.txtPOCode = new EspackFormControlsNS.EspackTextBox();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.fsPODocument = new EspackFormControlsNS.EspackFileStreamControl();
            this.FdcPDFData = new EspackFormControlsNS.EspackFileDataContainerPreview();
            this.txtDescription = new EspackFormControlsNS.EspackTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSuppliers = new EspackFormControlsNS.EspackComboBox();
            this.txtDesCod3 = new EspackFormControlsNS.EspackTextBox();
            this.cboCOD3 = new EspackFormControlsNS.EspackComboBox();
            this.txtCompany = new EspackFormControlsNS.EspackTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboCurrency = new EspackFormControlsNS.EspackComboBox();
            this.txtTotalQty = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtBalance = new EspackFormControlsNS.EspackNumericTextBox();
            this.espackDataGridViewControl1 = new EspackDataGridView.EspackDataGridViewControl();
            this.lstFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.espackDataGridViewControl2 = new EspackDataGridView.EspackDataGridViewControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPONumber
            // 
            this.txtPONumber.Add = false;
            this.txtPONumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPONumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPONumber.Caption = "Purchase Order Number";
            this.txtPONumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPONumber.DBField = null;
            this.txtPONumber.DBFieldType = null;
            this.txtPONumber.DefaultValue = null;
            this.txtPONumber.Del = false;
            this.txtPONumber.DependingRS = null;
            this.txtPONumber.ExtraDataLink = null;
            this.txtPONumber.IsCTLMOwned = false;
            this.txtPONumber.IsPassword = false;
            this.txtPONumber.Location = new System.Drawing.Point(173, 83);
            this.txtPONumber.Multiline = false;
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.Order = 0;
            this.txtPONumber.ParentConn = null;
            this.txtPONumber.ParentDA = null;
            this.txtPONumber.PK = false;
            this.txtPONumber.Protected = false;
            this.txtPONumber.ReadOnly = false;
            this.txtPONumber.Search = false;
            this.txtPONumber.Size = new System.Drawing.Size(154, 40);
            this.txtPONumber.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPONumber.TabIndex = 2;
            this.txtPONumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPONumber.Upp = false;
            this.txtPONumber.Value = "";
            // 
            // txtPOCode
            // 
            this.txtPOCode.Add = false;
            this.txtPOCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPOCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPOCode.Caption = "Purchase Order Code";
            this.txtPOCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPOCode.DBField = null;
            this.txtPOCode.DBFieldType = null;
            this.txtPOCode.DefaultValue = null;
            this.txtPOCode.Del = false;
            this.txtPOCode.DependingRS = null;
            this.txtPOCode.ExtraDataLink = null;
            this.txtPOCode.IsCTLMOwned = false;
            this.txtPOCode.IsPassword = false;
            this.txtPOCode.Location = new System.Drawing.Point(13, 83);
            this.txtPOCode.Multiline = false;
            this.txtPOCode.Name = "txtPOCode";
            this.txtPOCode.Order = 0;
            this.txtPOCode.ParentConn = null;
            this.txtPOCode.ParentDA = null;
            this.txtPOCode.PK = false;
            this.txtPOCode.Protected = false;
            this.txtPOCode.ReadOnly = false;
            this.txtPOCode.Search = false;
            this.txtPOCode.Size = new System.Drawing.Size(154, 40);
            this.txtPOCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPOCode.TabIndex = 1;
            this.txtPOCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPOCode.Upp = false;
            this.txtPOCode.Value = "";
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
            this.CTLM.Location = new System.Drawing.Point(13, 13);
            this.CTLM.MsgStatusInfoLabel = null;
            this.CTLM.MsgStatusLabel = null;
            this.CTLM.Name = "CTLM";
            this.CTLM.ReQuery = false;
            this.CTLM.Size = new System.Drawing.Size(300, 31);
            this.CTLM.sSPAdd = "";
            this.CTLM.sSPDel = "";
            this.CTLM.sSPUpp = "";
            this.CTLM.StatusBarProgress = null;
            this.CTLM.TabIndex = 0;
            // 
            // fsPODocument
            // 
            this.fsPODocument.Add = false;
            this.fsPODocument.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.fsPODocument.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.fsPODocument.BackColor = System.Drawing.Color.Transparent;
            this.fsPODocument.Caption = "Document";
            this.fsPODocument.DBField = null;
            this.fsPODocument.DBFieldType = null;
            this.fsPODocument.DefaultValue = null;
            this.fsPODocument.Del = false;
            this.fsPODocument.DependingRS = null;
            this.fsPODocument.ExtraDataLink = null;
            this.fsPODocument.FileData = null;
            this.fsPODocument.FileName = "";
            this.fsPODocument.IsCTLMOwned = false;
            this.fsPODocument.Location = new System.Drawing.Point(965, 18);
            this.fsPODocument.Multiline = true;
            this.fsPODocument.Name = "fsPODocument";
            this.fsPODocument.Order = 0;
            this.fsPODocument.ParentConn = null;
            this.fsPODocument.ParentDA = null;
            this.fsPODocument.PDFFileData = null;
            this.fsPODocument.PK = false;
            this.fsPODocument.Protected = false;
            this.fsPODocument.ReadOnly = false;
            this.fsPODocument.Search = false;
            this.fsPODocument.Size = new System.Drawing.Size(600, 41);
            this.fsPODocument.Status = CommonTools.EnumStatus.ADDNEW;
            this.fsPODocument.TabIndex = 120;
            this.fsPODocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.fsPODocument.Upp = false;
            this.fsPODocument.Value = "";
            // 
            // FdcPDFData
            // 
            this.FdcPDFData.Add = false;
            this.FdcPDFData.DBField = null;
            this.FdcPDFData.DBFieldType = null;
            this.FdcPDFData.DefaultValue = null;
            this.FdcPDFData.Del = false;
            this.FdcPDFData.DependingRS = null;
            this.FdcPDFData.ExtraDataLink = null;
            this.FdcPDFData.FileName = "";
            this.FdcPDFData.IsCTLMOwned = false;
            this.FdcPDFData.Location = new System.Drawing.Point(965, 65);
            this.FdcPDFData.Name = "FdcPDFData";
            this.FdcPDFData.Order = 0;
            this.FdcPDFData.ParentConn = null;
            this.FdcPDFData.ParentDA = null;
            this.FdcPDFData.PK = false;
            this.FdcPDFData.Protected = false;
            this.FdcPDFData.ReadOnly = false;
            this.FdcPDFData.Search = false;
            this.FdcPDFData.Size = new System.Drawing.Size(600, 832);
            this.FdcPDFData.Status = CommonTools.EnumStatus.ADDNEW;
            this.FdcPDFData.TabIndex = 121;
            this.FdcPDFData.Upp = false;
            this.FdcPDFData.Value = null;
            // 
            // txtDescription
            // 
            this.txtDescription.Add = false;
            this.txtDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDescription.Caption = "Description";
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDescription.DBField = null;
            this.txtDescription.DBFieldType = null;
            this.txtDescription.DefaultValue = null;
            this.txtDescription.Del = false;
            this.txtDescription.DependingRS = null;
            this.txtDescription.ExtraDataLink = null;
            this.txtDescription.IsCTLMOwned = false;
            this.txtDescription.IsPassword = false;
            this.txtDescription.Location = new System.Drawing.Point(12, 129);
            this.txtDescription.Multiline = false;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Order = 0;
            this.txtDescription.ParentConn = null;
            this.txtDescription.ParentDA = null;
            this.txtDescription.PK = false;
            this.txtDescription.Protected = false;
            this.txtDescription.ReadOnly = false;
            this.txtDescription.Search = false;
            this.txtDescription.Size = new System.Drawing.Size(868, 84);
            this.txtDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDescription.TabIndex = 122;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.Upp = false;
            this.txtDescription.Value = "";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.txtCompany);
            this.groupBox1.Controls.Add(this.cboSuppliers);
            this.groupBox1.Controls.Add(this.txtDesCod3);
            this.groupBox1.Controls.Add(this.cboCOD3);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(868, 74);
            this.groupBox1.TabIndex = 123;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Company Data";
            // 
            // cboSuppliers
            // 
            this.cboSuppliers.Add = false;
            this.cboSuppliers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSuppliers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cboSuppliers.Caption = "Supplier Code";
            this.cboSuppliers.DataSource = null;
            this.cboSuppliers.DBField = null;
            this.cboSuppliers.DBFieldType = null;
            this.cboSuppliers.DefaultValue = null;
            this.cboSuppliers.Del = false;
            this.cboSuppliers.DependingRS = null;
            this.cboSuppliers.DisplayMember = "";
            this.cboSuppliers.ExtraDataLink = null;
            this.cboSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSuppliers.FormattingEnabled = false;
            this.cboSuppliers.IsCTLMOwned = false;
            this.cboSuppliers.Location = new System.Drawing.Point(6, 19);
            this.cboSuppliers.Name = "cboSuppliers";
            this.cboSuppliers.Order = 0;
            this.cboSuppliers.ParentConn = null;
            this.cboSuppliers.ParentDA = null;
            this.cboSuppliers.PK = false;
            this.cboSuppliers.Protected = false;
            this.cboSuppliers.ReadOnly = false;
            this.cboSuppliers.Search = false;
            this.cboSuppliers.SelectedItem = null;
            this.cboSuppliers.SelectedValue = null;
            this.cboSuppliers.Size = new System.Drawing.Size(154, 40);
            this.cboSuppliers.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboSuppliers.TabIndex = 122;
            this.cboSuppliers.TBDescription = null;
            this.cboSuppliers.Upp = false;
            this.cboSuppliers.Value = "";
            this.cboSuppliers.ValueMember = "";
            // 
            // txtDesCod3
            // 
            this.txtDesCod3.Add = false;
            this.txtDesCod3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDesCod3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDesCod3.Caption = "";
            this.txtDesCod3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDesCod3.DBField = null;
            this.txtDesCod3.DBFieldType = null;
            this.txtDesCod3.DefaultValue = null;
            this.txtDesCod3.Del = false;
            this.txtDesCod3.DependingRS = null;
            this.txtDesCod3.ExtraDataLink = null;
            this.txtDesCod3.IsCTLMOwned = false;
            this.txtDesCod3.IsPassword = false;
            this.txtDesCod3.Location = new System.Drawing.Point(567, 34);
            this.txtDesCod3.Multiline = false;
            this.txtDesCod3.Name = "txtDesCod3";
            this.txtDesCod3.Order = 0;
            this.txtDesCod3.ParentConn = null;
            this.txtDesCod3.ParentDA = null;
            this.txtDesCod3.PK = false;
            this.txtDesCod3.Protected = false;
            this.txtDesCod3.ReadOnly = false;
            this.txtDesCod3.Search = false;
            this.txtDesCod3.Size = new System.Drawing.Size(295, 25);
            this.txtDesCod3.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDesCod3.TabIndex = 121;
            this.txtDesCod3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDesCod3.Upp = false;
            this.txtDesCod3.Value = "";
            // 
            // cboCOD3
            // 
            this.cboCOD3.Add = false;
            this.cboCOD3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCOD3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCOD3.Caption = "Main COD3";
            this.cboCOD3.DataSource = null;
            this.cboCOD3.DBField = null;
            this.cboCOD3.DBFieldType = null;
            this.cboCOD3.DefaultValue = null;
            this.cboCOD3.Del = false;
            this.cboCOD3.DependingRS = null;
            this.cboCOD3.DisplayMember = "";
            this.cboCOD3.ExtraDataLink = null;
            this.cboCOD3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCOD3.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboCOD3.ForeColor = System.Drawing.Color.Black;
            this.cboCOD3.FormattingEnabled = true;
            this.cboCOD3.IsCTLMOwned = false;
            this.cboCOD3.Location = new System.Drawing.Point(407, 19);
            this.cboCOD3.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboCOD3.Name = "cboCOD3";
            this.cboCOD3.Order = 0;
            this.cboCOD3.ParentConn = null;
            this.cboCOD3.ParentDA = null;
            this.cboCOD3.PK = false;
            this.cboCOD3.Protected = false;
            this.cboCOD3.ReadOnly = false;
            this.cboCOD3.Search = true;
            this.cboCOD3.SelectedItem = null;
            this.cboCOD3.SelectedValue = null;
            this.cboCOD3.Size = new System.Drawing.Size(154, 40);
            this.cboCOD3.Status = CommonTools.EnumStatus.SEARCH;
            this.cboCOD3.TabIndex = 120;
            this.cboCOD3.TBDescription = null;
            this.cboCOD3.Upp = true;
            this.cboCOD3.Value = "";
            this.cboCOD3.ValueMember = "";
            // 
            // txtCompany
            // 
            this.txtCompany.Add = false;
            this.txtCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCompany.Caption = "Company";
            this.txtCompany.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCompany.DBField = null;
            this.txtCompany.DBFieldType = null;
            this.txtCompany.DefaultValue = null;
            this.txtCompany.Del = false;
            this.txtCompany.DependingRS = null;
            this.txtCompany.ExtraDataLink = null;
            this.txtCompany.IsCTLMOwned = false;
            this.txtCompany.IsPassword = false;
            this.txtCompany.Location = new System.Drawing.Point(166, 18);
            this.txtCompany.Multiline = false;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Order = 0;
            this.txtCompany.ParentConn = null;
            this.txtCompany.ParentDA = null;
            this.txtCompany.PK = false;
            this.txtCompany.Protected = false;
            this.txtCompany.ReadOnly = false;
            this.txtCompany.Search = false;
            this.txtCompany.Size = new System.Drawing.Size(234, 41);
            this.txtCompany.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtCompany.TabIndex = 123;
            this.txtCompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCompany.Upp = false;
            this.txtCompany.Value = "";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.espackDataGridViewControl1);
            this.groupBox2.Controls.Add(this.txtBalance);
            this.groupBox2.Controls.Add(this.txtTotalQty);
            this.groupBox2.Controls.Add(this.cboCurrency);
            this.groupBox2.Location = new System.Drawing.Point(12, 329);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(868, 174);
            this.groupBox2.TabIndex = 124;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Billing Data";
            // 
            // cboCurrency
            // 
            this.cboCurrency.Add = false;
            this.cboCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCurrency.Caption = "Currency";
            this.cboCurrency.DataSource = null;
            this.cboCurrency.DBField = null;
            this.cboCurrency.DBFieldType = null;
            this.cboCurrency.DefaultValue = null;
            this.cboCurrency.Del = false;
            this.cboCurrency.DependingRS = null;
            this.cboCurrency.DisplayMember = "";
            this.cboCurrency.ExtraDataLink = null;
            this.cboCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCurrency.FormattingEnabled = false;
            this.cboCurrency.IsCTLMOwned = false;
            this.cboCurrency.Location = new System.Drawing.Point(6, 19);
            this.cboCurrency.Name = "cboCurrency";
            this.cboCurrency.Order = 0;
            this.cboCurrency.ParentConn = null;
            this.cboCurrency.ParentDA = null;
            this.cboCurrency.PK = false;
            this.cboCurrency.Protected = false;
            this.cboCurrency.ReadOnly = false;
            this.cboCurrency.Search = false;
            this.cboCurrency.SelectedItem = null;
            this.cboCurrency.SelectedValue = null;
            this.cboCurrency.Size = new System.Drawing.Size(68, 40);
            this.cboCurrency.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboCurrency.TabIndex = 1;
            this.cboCurrency.TBDescription = null;
            this.cboCurrency.Upp = false;
            this.cboCurrency.Value = "";
            this.cboCurrency.ValueMember = "";
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Add = false;
            this.txtTotalQty.AllowSpace = false;
            this.txtTotalQty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTotalQty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTotalQty.Caption = "Total Qty";
            this.txtTotalQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTotalQty.DBField = null;
            this.txtTotalQty.DBFieldType = null;
            this.txtTotalQty.DefaultValue = null;
            this.txtTotalQty.Del = false;
            this.txtTotalQty.DependingRS = null;
            this.txtTotalQty.ExtraDataLink = null;
            this.txtTotalQty.IsCTLMOwned = false;
            this.txtTotalQty.IsPassword = false;
            this.txtTotalQty.Length = 0;
            this.txtTotalQty.Location = new System.Drawing.Point(6, 65);
            this.txtTotalQty.Mask = false;
            this.txtTotalQty.Multiline = false;
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.Order = 0;
            this.txtTotalQty.ParentConn = null;
            this.txtTotalQty.ParentDA = null;
            this.txtTotalQty.PK = false;
            this.txtTotalQty.Precision = 2;
            this.txtTotalQty.Protected = false;
            this.txtTotalQty.ReadOnly = false;
            this.txtTotalQty.Search = false;
            this.txtTotalQty.Size = new System.Drawing.Size(154, 41);
            this.txtTotalQty.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtTotalQty.TabIndex = 2;
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotalQty.ThousandsGroup = false;
            this.txtTotalQty.Upp = false;
            this.txtTotalQty.Value = null;
            // 
            // txtBalance
            // 
            this.txtBalance.Add = false;
            this.txtBalance.AllowSpace = false;
            this.txtBalance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtBalance.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtBalance.Caption = "Balance";
            this.txtBalance.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBalance.DBField = null;
            this.txtBalance.DBFieldType = null;
            this.txtBalance.DefaultValue = null;
            this.txtBalance.Del = false;
            this.txtBalance.DependingRS = null;
            this.txtBalance.ExtraDataLink = null;
            this.txtBalance.IsCTLMOwned = false;
            this.txtBalance.IsPassword = false;
            this.txtBalance.Length = 0;
            this.txtBalance.Location = new System.Drawing.Point(6, 112);
            this.txtBalance.Mask = false;
            this.txtBalance.Multiline = false;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Order = 0;
            this.txtBalance.ParentConn = null;
            this.txtBalance.ParentDA = null;
            this.txtBalance.PK = false;
            this.txtBalance.Precision = 2;
            this.txtBalance.Protected = false;
            this.txtBalance.ReadOnly = false;
            this.txtBalance.Search = false;
            this.txtBalance.Size = new System.Drawing.Size(154, 41);
            this.txtBalance.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtBalance.TabIndex = 3;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalance.ThousandsGroup = false;
            this.txtBalance.Upp = false;
            this.txtBalance.Value = null;
            // 
            // espackDataGridViewControl1
            // 
            this.espackDataGridViewControl1.Add = false;
            this.espackDataGridViewControl1.AllowDelete = false;
            this.espackDataGridViewControl1.AllowInsert = false;
            this.espackDataGridViewControl1.AllowUpdate = false;
            this.espackDataGridViewControl1.AllowUserToAddRows = false;
            this.espackDataGridViewControl1.AllowUserToResizeColumns = true;
            this.espackDataGridViewControl1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.espackDataGridViewControl1.Caption = "Invoices";
            this.espackDataGridViewControl1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.espackDataGridViewControl1.ColumnHeadersVisible = true;
            this.espackDataGridViewControl1.Conn = null;
            this.espackDataGridViewControl1.CurrentCell = null;
            this.espackDataGridViewControl1.DataSource = null;
            this.espackDataGridViewControl1.DBField = null;
            this.espackDataGridViewControl1.DBFieldType = null;
            this.espackDataGridViewControl1.DBTable = null;
            this.espackDataGridViewControl1.DefaultValue = null;
            this.espackDataGridViewControl1.Del = false;
            this.espackDataGridViewControl1.DependingRS = null;
            this.espackDataGridViewControl1.DGFocused = false;
            this.espackDataGridViewControl1.Dirty = false;
            this.espackDataGridViewControl1.EspackControlParent = null;
            this.espackDataGridViewControl1.ExtraDataLink = null;
            this.espackDataGridViewControl1.FGFocused = false;
            this.espackDataGridViewControl1.FilterRow = null;
            this.espackDataGridViewControl1.FilterRowEnabled = false;
            this.espackDataGridViewControl1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.espackDataGridViewControl1.HorizontalScrollingOffset = 0;
            this.espackDataGridViewControl1.IsCTLMOwned = false;
            this.espackDataGridViewControl1.IsFilterFocused = false;
            this.espackDataGridViewControl1.Location = new System.Drawing.Point(183, 19);
            this.espackDataGridViewControl1.MsgStatusLabel = null;
            this.espackDataGridViewControl1.Name = "espackDataGridViewControl1";
            this.espackDataGridViewControl1.NumPages = 0;
            this.espackDataGridViewControl1.Order = 0;
            this.espackDataGridViewControl1.Page = 0;
            this.espackDataGridViewControl1.Paginate = false;
            this.espackDataGridViewControl1.ParentConn = null;
            this.espackDataGridViewControl1.ParentDA = null;
            this.espackDataGridViewControl1.PK = false;
            this.espackDataGridViewControl1.Protected = false;
            this.espackDataGridViewControl1.ReadOnly = false;
            this.espackDataGridViewControl1.RowCount = 0;
            this.espackDataGridViewControl1.RowHeadersVisible = false;
            this.espackDataGridViewControl1.RowTemplate = dataGridViewRow1;
            this.espackDataGridViewControl1.Search = false;
            this.espackDataGridViewControl1.Size = new System.Drawing.Size(664, 132);
            this.espackDataGridViewControl1.SQL = null;
            this.espackDataGridViewControl1.sSPAdd = "";
            this.espackDataGridViewControl1.sSPDel = "";
            this.espackDataGridViewControl1.sSPUpp = "";
            this.espackDataGridViewControl1.Status = CommonTools.EnumStatus.SEARCH;
            this.espackDataGridViewControl1.TabIndex = 4;
            this.espackDataGridViewControl1.Upp = false;
            this.espackDataGridViewControl1.Value = null;
            // 
            // lstFlags
            // 
            this.lstFlags.Add = false;
            this.lstFlags.Caption = "Flags";
            this.lstFlags.CheckOnClick = true;
            this.lstFlags.ColumnWidth = 0;
            this.lstFlags.DataSource = null;
            this.lstFlags.DBField = null;
            this.lstFlags.DBFieldType = null;
            this.lstFlags.DefaultValue = null;
            this.lstFlags.Del = false;
            this.lstFlags.DependingRS = null;
            this.lstFlags.DisplayMember = "";
            this.lstFlags.ExtraDataLink = null;
            this.lstFlags.FormattingEnabled = false;
            this.lstFlags.IsCTLMOwned = false;
            this.lstFlags.Location = new System.Drawing.Point(12, 522);
            this.lstFlags.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstFlags.MultiColumn = false;
            this.lstFlags.Name = "lstFlags";
            this.lstFlags.Order = 0;
            this.lstFlags.ParentConn = null;
            this.lstFlags.ParentDA = null;
            this.lstFlags.PK = false;
            this.lstFlags.Protected = false;
            this.lstFlags.ReadOnly = false;
            this.lstFlags.Search = false;
            this.lstFlags.SelectedItem = null;
            this.lstFlags.SelectedValue = null;
            this.lstFlags.Size = new System.Drawing.Size(868, 52);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 125;
            this.lstFlags.TBDescription = null;
            this.lstFlags.Text = "espackCheckedListBox1";
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            this.lstFlags.ValueMember = "";
            // 
            // espackDataGridViewControl2
            // 
            this.espackDataGridViewControl2.Add = false;
            this.espackDataGridViewControl2.AllowDelete = false;
            this.espackDataGridViewControl2.AllowInsert = false;
            this.espackDataGridViewControl2.AllowUpdate = false;
            this.espackDataGridViewControl2.AllowUserToAddRows = false;
            this.espackDataGridViewControl2.AllowUserToResizeColumns = true;
            this.espackDataGridViewControl2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.espackDataGridViewControl2.Caption = "Concepts";
            this.espackDataGridViewControl2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.espackDataGridViewControl2.ColumnHeadersVisible = true;
            this.espackDataGridViewControl2.Conn = null;
            this.espackDataGridViewControl2.CurrentCell = null;
            this.espackDataGridViewControl2.DataSource = null;
            this.espackDataGridViewControl2.DBField = null;
            this.espackDataGridViewControl2.DBFieldType = null;
            this.espackDataGridViewControl2.DBTable = null;
            this.espackDataGridViewControl2.DefaultValue = null;
            this.espackDataGridViewControl2.Del = false;
            this.espackDataGridViewControl2.DependingRS = null;
            this.espackDataGridViewControl2.DGFocused = false;
            this.espackDataGridViewControl2.Dirty = false;
            this.espackDataGridViewControl2.EspackControlParent = null;
            this.espackDataGridViewControl2.ExtraDataLink = null;
            this.espackDataGridViewControl2.FGFocused = false;
            this.espackDataGridViewControl2.FilterRow = null;
            this.espackDataGridViewControl2.FilterRowEnabled = false;
            this.espackDataGridViewControl2.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.espackDataGridViewControl2.HorizontalScrollingOffset = 0;
            this.espackDataGridViewControl2.IsCTLMOwned = false;
            this.espackDataGridViewControl2.IsFilterFocused = false;
            this.espackDataGridViewControl2.Location = new System.Drawing.Point(12, 613);
            this.espackDataGridViewControl2.MsgStatusLabel = null;
            this.espackDataGridViewControl2.Name = "espackDataGridViewControl2";
            this.espackDataGridViewControl2.NumPages = 0;
            this.espackDataGridViewControl2.Order = 0;
            this.espackDataGridViewControl2.Page = 0;
            this.espackDataGridViewControl2.Paginate = false;
            this.espackDataGridViewControl2.ParentConn = null;
            this.espackDataGridViewControl2.ParentDA = null;
            this.espackDataGridViewControl2.PK = false;
            this.espackDataGridViewControl2.Protected = false;
            this.espackDataGridViewControl2.ReadOnly = false;
            this.espackDataGridViewControl2.RowCount = 0;
            this.espackDataGridViewControl2.RowHeadersVisible = false;
            this.espackDataGridViewControl2.RowTemplate = dataGridViewRow2;
            this.espackDataGridViewControl2.Search = false;
            this.espackDataGridViewControl2.Size = new System.Drawing.Size(868, 286);
            this.espackDataGridViewControl2.SQL = null;
            this.espackDataGridViewControl2.sSPAdd = "";
            this.espackDataGridViewControl2.sSPDel = "";
            this.espackDataGridViewControl2.sSPUpp = "";
            this.espackDataGridViewControl2.Status = CommonTools.EnumStatus.SEARCH;
            this.espackDataGridViewControl2.TabIndex = 126;
            this.espackDataGridViewControl2.Upp = false;
            this.espackDataGridViewControl2.Value = null;
            // 
            // fPurchaseOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1683, 909);
            this.Controls.Add(this.espackDataGridViewControl2);
            this.Controls.Add(this.lstFlags);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.FdcPDFData);
            this.Controls.Add(this.fsPODocument);
            this.Controls.Add(this.txtPONumber);
            this.Controls.Add(this.txtPOCode);
            this.Controls.Add(this.CTLM);
            this.Name = "fPurchaseOrders";
            this.Text = "fPurchaseOrders";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackTextBox txtPOCode;
        private EspackFormControlsNS.EspackTextBox txtPONumber;
        private EspackFormControlsNS.EspackFileStreamControl fsPODocument;
        private EspackFormControlsNS.EspackFileDataContainerPreview FdcPDFData;
        private EspackFormControlsNS.EspackTextBox txtDescription;
        private System.Windows.Forms.GroupBox groupBox1;
        private EspackFormControlsNS.EspackTextBox txtCompany;
        private EspackFormControlsNS.EspackComboBox cboSuppliers;
        private EspackFormControlsNS.EspackTextBox txtDesCod3;
        private EspackFormControlsNS.EspackComboBox cboCOD3;
        private System.Windows.Forms.GroupBox groupBox2;
        private EspackDataGridView.EspackDataGridViewControl espackDataGridViewControl1;
        private EspackFormControlsNS.EspackNumericTextBox txtBalance;
        private EspackFormControlsNS.EspackNumericTextBox txtTotalQty;
        private EspackFormControlsNS.EspackComboBox cboCurrency;
        private EspackFormControlsNS.EspackCheckedListBox lstFlags;
        private EspackDataGridView.EspackDataGridViewControl espackDataGridViewControl2;
    }
}