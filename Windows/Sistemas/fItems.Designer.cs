namespace Sistemas
{
    partial class fItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fItems));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstSectionFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtDesType = new EspackFormControlsNS.EspackTextBox();
            this.cboType = new EspackFormControlsNS.EspackComboBox();
            this.txtDescription = new EspackFormControlsNS.EspackTextBox();
            this.txtName = new EspackFormControlsNS.EspackTextBox();
            this.txtCode = new EspackFormControlsNS.EspackTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboZone = new EspackFormControlsNS.EspackComboBox();
            this.listCOD3 = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtDesCod3 = new EspackFormControlsNS.EspackTextBox();
            this.cboCOD3 = new EspackFormControlsNS.EspackComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtInvoiceDate = new EspackFormControlsNS.EspackDateTimePicker();
            this.txtInvoice = new EspackFormControlsNS.EspackTextBox();
            this.txtCM = new EspackFormControlsNS.EspackTextBox();
            this.txtSerial = new EspackFormControlsNS.EspackTextBox();
            this.VS = new EspackDataGridView.EspackDataGridViewControl();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.lstSectionFlags);
            this.groupBox1.Controls.Add(this.txtDesType);
            this.groupBox1.Controls.Add(this.cboType);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(16, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(528, 386);
            this.groupBox1.TabIndex = 137;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "What it is";
            // 
            // lstSectionFlags
            // 
            this.lstSectionFlags.Add = false;
            this.lstSectionFlags.Caption = "Type Flags";
            this.lstSectionFlags.CheckOnClick = true;
            this.lstSectionFlags.ColumnWidth = 150;
            this.lstSectionFlags.DataSource = null;
            this.lstSectionFlags.DBField = null;
            this.lstSectionFlags.DBFieldType = null;
            this.lstSectionFlags.DefaultValue = null;
            this.lstSectionFlags.Del = false;
            this.lstSectionFlags.DependingRS = null;
            this.lstSectionFlags.DisplayMember = "";
            this.lstSectionFlags.ExtraDataLink = null;
            this.lstSectionFlags.FormattingEnabled = false;
            this.lstSectionFlags.IsCTLMOwned = false;
            this.lstSectionFlags.Location = new System.Drawing.Point(22, 155);
            this.lstSectionFlags.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstSectionFlags.MultiColumn = true;
            this.lstSectionFlags.Name = "lstSectionFlags";
            this.lstSectionFlags.Order = 0;
            this.lstSectionFlags.ParentConn = null;
            this.lstSectionFlags.ParentDA = null;
            this.lstSectionFlags.PK = false;
            this.lstSectionFlags.Protected = false;
            this.lstSectionFlags.ReadOnly = false;
            this.lstSectionFlags.Search = false;
            this.lstSectionFlags.SelectedItem = null;
            this.lstSectionFlags.SelectedValue = null;
            this.lstSectionFlags.Size = new System.Drawing.Size(481, 196);
            this.lstSectionFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstSectionFlags.TabIndex = 20;
            this.lstSectionFlags.TBDescription = null;
            this.lstSectionFlags.Upp = false;
            this.lstSectionFlags.Value = "";
            this.lstSectionFlags.ValueMember = "";
            // 
            // txtDesType
            // 
            this.txtDesType.Add = false;
            this.txtDesType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDesType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDesType.Caption = "";
            this.txtDesType.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDesType.DBField = null;
            this.txtDesType.DBFieldType = null;
            this.txtDesType.DefaultValue = null;
            this.txtDesType.Del = false;
            this.txtDesType.DependingRS = null;
            this.txtDesType.ExtraDataLink = null;
            this.txtDesType.IsCTLMOwned = false;
            this.txtDesType.IsPassword = false;
            this.txtDesType.Location = new System.Drawing.Point(184, 120);
            this.txtDesType.Multiline = false;
            this.txtDesType.Name = "txtDesType";
            this.txtDesType.Order = 0;
            this.txtDesType.ParentConn = null;
            this.txtDesType.ParentDA = null;
            this.txtDesType.PK = false;
            this.txtDesType.Protected = false;
            this.txtDesType.ReadOnly = false;
            this.txtDesType.Search = false;
            this.txtDesType.Size = new System.Drawing.Size(322, 25);
            this.txtDesType.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDesType.TabIndex = 10;
            this.txtDesType.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDesType.Upp = false;
            this.txtDesType.Value = "";
            this.txtDesType.WordWrap = true;
            // 
            // cboType
            // 
            this.cboType.Add = false;
            this.cboType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboType.Caption = "Type";
            this.cboType.DataSource = null;
            this.cboType.DBField = null;
            this.cboType.DBFieldType = null;
            this.cboType.DefaultValue = null;
            this.cboType.Del = false;
            this.cboType.DependingRS = null;
            this.cboType.DisplayMember = "";
            this.cboType.ExtraDataLink = null;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboType.FormattingEnabled = false;
            this.cboType.IsCTLMOwned = false;
            this.cboType.Location = new System.Drawing.Point(22, 105);
            this.cboType.Name = "cboType";
            this.cboType.Order = 0;
            this.cboType.ParentConn = null;
            this.cboType.ParentDA = null;
            this.cboType.PK = false;
            this.cboType.Protected = false;
            this.cboType.ReadOnly = false;
            this.cboType.Search = false;
            this.cboType.SelectedItem = null;
            this.cboType.SelectedValue = null;
            this.cboType.Size = new System.Drawing.Size(154, 40);
            this.cboType.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboType.TabIndex = 9;
            this.cboType.TBDescription = null;
            this.cboType.Upp = false;
            this.cboType.Value = "";
            this.cboType.ValueMember = "";
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
            this.txtDescription.Location = new System.Drawing.Point(23, 59);
            this.txtDescription.Multiline = false;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Order = 0;
            this.txtDescription.ParentConn = null;
            this.txtDescription.ParentDA = null;
            this.txtDescription.PK = false;
            this.txtDescription.Protected = false;
            this.txtDescription.ReadOnly = false;
            this.txtDescription.Search = false;
            this.txtDescription.Size = new System.Drawing.Size(154, 38);
            this.txtDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDescription.TabIndex = 8;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.Upp = false;
            this.txtDescription.Value = "";
            this.txtDescription.WordWrap = true;
            // 
            // txtName
            // 
            this.txtName.Add = false;
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtName.Caption = "Name";
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtName.DBField = null;
            this.txtName.DBFieldType = null;
            this.txtName.DefaultValue = null;
            this.txtName.Del = false;
            this.txtName.DependingRS = null;
            this.txtName.ExtraDataLink = null;
            this.txtName.IsCTLMOwned = false;
            this.txtName.IsPassword = false;
            this.txtName.Location = new System.Drawing.Point(183, 19);
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Order = 0;
            this.txtName.ParentConn = null;
            this.txtName.ParentDA = null;
            this.txtName.PK = false;
            this.txtName.Protected = false;
            this.txtName.ReadOnly = false;
            this.txtName.Search = false;
            this.txtName.Size = new System.Drawing.Size(322, 38);
            this.txtName.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtName.TabIndex = 7;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.Upp = false;
            this.txtName.Value = "";
            this.txtName.WordWrap = true;
            // 
            // txtCode
            // 
            this.txtCode.Add = false;
            this.txtCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCode.Caption = "Code";
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCode.DBField = null;
            this.txtCode.DBFieldType = null;
            this.txtCode.DefaultValue = null;
            this.txtCode.Del = false;
            this.txtCode.DependingRS = null;
            this.txtCode.ExtraDataLink = null;
            this.txtCode.IsCTLMOwned = false;
            this.txtCode.IsPassword = false;
            this.txtCode.Location = new System.Drawing.Point(23, 19);
            this.txtCode.Multiline = false;
            this.txtCode.Name = "txtCode";
            this.txtCode.Order = 0;
            this.txtCode.ParentConn = null;
            this.txtCode.ParentDA = null;
            this.txtCode.PK = false;
            this.txtCode.Protected = false;
            this.txtCode.ReadOnly = false;
            this.txtCode.Search = false;
            this.txtCode.Size = new System.Drawing.Size(154, 38);
            this.txtCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtCode.TabIndex = 6;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCode.Upp = false;
            this.txtCode.Value = "";
            this.txtCode.WordWrap = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.cboZone);
            this.groupBox2.Controls.Add(this.listCOD3);
            this.groupBox2.Controls.Add(this.txtDesCod3);
            this.groupBox2.Controls.Add(this.cboCOD3);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(550, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(528, 386);
            this.groupBox2.TabIndex = 147;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Where is it";
            // 
            // cboZone
            // 
            this.cboZone.Add = false;
            this.cboZone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboZone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboZone.Caption = "Zone";
            this.cboZone.DataSource = null;
            this.cboZone.DBField = null;
            this.cboZone.DBFieldType = null;
            this.cboZone.DefaultValue = null;
            this.cboZone.Del = false;
            this.cboZone.DependingRS = null;
            this.cboZone.DisplayMember = "";
            this.cboZone.ExtraDataLink = null;
            this.cboZone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboZone.FormattingEnabled = false;
            this.cboZone.IsCTLMOwned = false;
            this.cboZone.Location = new System.Drawing.Point(24, 337);
            this.cboZone.Name = "cboZone";
            this.cboZone.Order = 0;
            this.cboZone.ParentConn = null;
            this.cboZone.ParentDA = null;
            this.cboZone.PK = false;
            this.cboZone.Protected = false;
            this.cboZone.ReadOnly = false;
            this.cboZone.Search = false;
            this.cboZone.SelectedItem = null;
            this.cboZone.SelectedValue = null;
            this.cboZone.Size = new System.Drawing.Size(140, 40);
            this.cboZone.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboZone.TabIndex = 120;
            this.cboZone.TBDescription = null;
            this.cboZone.Upp = false;
            this.cboZone.Value = "";
            this.cboZone.ValueMember = "";
            // 
            // listCOD3
            // 
            this.listCOD3.Add = false;
            this.listCOD3.Caption = "";
            this.listCOD3.CheckOnClick = true;
            this.listCOD3.ColumnWidth = 150;
            this.listCOD3.DataSource = null;
            this.listCOD3.DBField = null;
            this.listCOD3.DBFieldType = null;
            this.listCOD3.DefaultValue = null;
            this.listCOD3.Del = false;
            this.listCOD3.DependingRS = null;
            this.listCOD3.DisplayMember = "";
            this.listCOD3.ExtraDataLink = null;
            this.listCOD3.FormattingEnabled = false;
            this.listCOD3.IsCTLMOwned = false;
            this.listCOD3.Location = new System.Drawing.Point(24, 78);
            this.listCOD3.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.listCOD3.MultiColumn = true;
            this.listCOD3.Name = "listCOD3";
            this.listCOD3.Order = 0;
            this.listCOD3.ParentConn = null;
            this.listCOD3.ParentDA = null;
            this.listCOD3.PK = false;
            this.listCOD3.Protected = false;
            this.listCOD3.ReadOnly = false;
            this.listCOD3.Search = false;
            this.listCOD3.SelectedItem = null;
            this.listCOD3.SelectedValue = null;
            this.listCOD3.Size = new System.Drawing.Size(481, 252);
            this.listCOD3.Status = CommonTools.EnumStatus.ADDNEW;
            this.listCOD3.TabIndex = 119;
            this.listCOD3.TBDescription = null;
            this.listCOD3.Upp = false;
            this.listCOD3.Value = "";
            this.listCOD3.ValueMember = "";
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
            this.txtDesCod3.Location = new System.Drawing.Point(184, 34);
            this.txtDesCod3.Multiline = false;
            this.txtDesCod3.Name = "txtDesCod3";
            this.txtDesCod3.Order = 0;
            this.txtDesCod3.ParentConn = null;
            this.txtDesCod3.ParentDA = null;
            this.txtDesCod3.PK = false;
            this.txtDesCod3.Protected = false;
            this.txtDesCod3.ReadOnly = false;
            this.txtDesCod3.Search = false;
            this.txtDesCod3.Size = new System.Drawing.Size(322, 25);
            this.txtDesCod3.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDesCod3.TabIndex = 118;
            this.txtDesCod3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDesCod3.Upp = false;
            this.txtDesCod3.Value = "";
            this.txtDesCod3.WordWrap = true;
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
            this.cboCOD3.FormattingEnabled = false;
            this.cboCOD3.IsCTLMOwned = false;
            this.cboCOD3.Location = new System.Drawing.Point(23, 19);
            this.cboCOD3.Name = "cboCOD3";
            this.cboCOD3.Order = 0;
            this.cboCOD3.ParentConn = null;
            this.cboCOD3.ParentDA = null;
            this.cboCOD3.PK = false;
            this.cboCOD3.Protected = false;
            this.cboCOD3.ReadOnly = false;
            this.cboCOD3.Search = false;
            this.cboCOD3.SelectedItem = null;
            this.cboCOD3.SelectedValue = null;
            this.cboCOD3.Size = new System.Drawing.Size(154, 40);
            this.cboCOD3.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboCOD3.TabIndex = 117;
            this.cboCOD3.TBDescription = null;
            this.cboCOD3.Upp = false;
            this.cboCOD3.Value = "";
            this.cboCOD3.ValueMember = "";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Controls.Add(this.lstFlags);
            this.groupBox3.Controls.Add(this.txtInvoiceDate);
            this.groupBox3.Controls.Add(this.txtInvoice);
            this.groupBox3.Controls.Add(this.txtCM);
            this.groupBox3.Controls.Add(this.txtSerial);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(1084, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(528, 386);
            this.groupBox3.TabIndex = 153;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Bureaucracy";
            // 
            // lstFlags
            // 
            this.lstFlags.Add = false;
            this.lstFlags.Caption = "Flags";
            this.lstFlags.CheckOnClick = true;
            this.lstFlags.ColumnWidth = 150;
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
            this.lstFlags.Location = new System.Drawing.Point(24, 127);
            this.lstFlags.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstFlags.MultiColumn = true;
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
            this.lstFlags.Size = new System.Drawing.Size(481, 232);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 18;
            this.lstFlags.TBDescription = null;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            this.lstFlags.ValueMember = "";
            // 
            // txtInvoiceDate
            // 
            this.txtInvoiceDate.Add = false;
            this.txtInvoiceDate.BorderColor = System.Drawing.Color.Black;
            this.txtInvoiceDate.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.txtInvoiceDate.Caption = "Invoice Date";
            this.txtInvoiceDate.Checked = false;
            this.txtInvoiceDate.CustomFormat = " ";
            this.txtInvoiceDate.DBField = null;
            this.txtInvoiceDate.DBFieldType = null;
            this.txtInvoiceDate.DefaultValue = null;
            this.txtInvoiceDate.Del = false;
            this.txtInvoiceDate.DependingRS = null;
            this.txtInvoiceDate.ExtraDataLink = null;
            this.txtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtInvoiceDate.IsCTLMOwned = false;
            this.txtInvoiceDate.Location = new System.Drawing.Point(184, 65);
            this.txtInvoiceDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtInvoiceDate.Name = "txtInvoiceDate";
            this.txtInvoiceDate.Nullable = true;
            this.txtInvoiceDate.Order = 0;
            this.txtInvoiceDate.ParentConn = null;
            this.txtInvoiceDate.ParentDA = null;
            this.txtInvoiceDate.PK = false;
            this.txtInvoiceDate.Protected = false;
            this.txtInvoiceDate.ReadOnly = false;
            this.txtInvoiceDate.Search = false;
            this.txtInvoiceDate.ShowCheckBox = true;
            this.txtInvoiceDate.Size = new System.Drawing.Size(322, 39);
            this.txtInvoiceDate.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtInvoiceDate.TabIndex = 17;
            this.txtInvoiceDate.Text = " ";
            this.txtInvoiceDate.Upp = false;
            this.txtInvoiceDate.Value = null;
            // 
            // txtInvoice
            // 
            this.txtInvoice.Add = false;
            this.txtInvoice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtInvoice.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtInvoice.Caption = "Invoice";
            this.txtInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtInvoice.DBField = null;
            this.txtInvoice.DBFieldType = null;
            this.txtInvoice.DefaultValue = null;
            this.txtInvoice.Del = false;
            this.txtInvoice.DependingRS = null;
            this.txtInvoice.ExtraDataLink = null;
            this.txtInvoice.IsCTLMOwned = false;
            this.txtInvoice.IsPassword = false;
            this.txtInvoice.Location = new System.Drawing.Point(23, 65);
            this.txtInvoice.Multiline = false;
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Order = 0;
            this.txtInvoice.ParentConn = null;
            this.txtInvoice.ParentDA = null;
            this.txtInvoice.PK = false;
            this.txtInvoice.Protected = false;
            this.txtInvoice.ReadOnly = false;
            this.txtInvoice.Search = false;
            this.txtInvoice.Size = new System.Drawing.Size(154, 38);
            this.txtInvoice.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtInvoice.TabIndex = 16;
            this.txtInvoice.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtInvoice.Upp = false;
            this.txtInvoice.Value = "";
            this.txtInvoice.WordWrap = true;
            // 
            // txtCM
            // 
            this.txtCM.Add = false;
            this.txtCM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCM.Caption = "CM";
            this.txtCM.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCM.DBField = null;
            this.txtCM.DBFieldType = null;
            this.txtCM.DefaultValue = null;
            this.txtCM.Del = false;
            this.txtCM.DependingRS = null;
            this.txtCM.ExtraDataLink = null;
            this.txtCM.IsCTLMOwned = false;
            this.txtCM.IsPassword = false;
            this.txtCM.Location = new System.Drawing.Point(184, 19);
            this.txtCM.Multiline = false;
            this.txtCM.Name = "txtCM";
            this.txtCM.Order = 0;
            this.txtCM.ParentConn = null;
            this.txtCM.ParentDA = null;
            this.txtCM.PK = false;
            this.txtCM.Protected = false;
            this.txtCM.ReadOnly = false;
            this.txtCM.Search = false;
            this.txtCM.Size = new System.Drawing.Size(322, 38);
            this.txtCM.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtCM.TabIndex = 15;
            this.txtCM.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCM.Upp = false;
            this.txtCM.Value = "";
            this.txtCM.WordWrap = true;
            // 
            // txtSerial
            // 
            this.txtSerial.Add = false;
            this.txtSerial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSerial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSerial.Caption = "Serial";
            this.txtSerial.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSerial.DBField = null;
            this.txtSerial.DBFieldType = null;
            this.txtSerial.DefaultValue = null;
            this.txtSerial.Del = false;
            this.txtSerial.DependingRS = null;
            this.txtSerial.ExtraDataLink = null;
            this.txtSerial.IsCTLMOwned = false;
            this.txtSerial.IsPassword = false;
            this.txtSerial.Location = new System.Drawing.Point(24, 19);
            this.txtSerial.Multiline = false;
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Order = 0;
            this.txtSerial.ParentConn = null;
            this.txtSerial.ParentDA = null;
            this.txtSerial.PK = false;
            this.txtSerial.Protected = false;
            this.txtSerial.ReadOnly = false;
            this.txtSerial.Search = false;
            this.txtSerial.Size = new System.Drawing.Size(154, 38);
            this.txtSerial.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtSerial.TabIndex = 14;
            this.txtSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSerial.Upp = false;
            this.txtSerial.Value = "";
            this.txtSerial.WordWrap = true;
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
            this.VS.Location = new System.Drawing.Point(38, 437);
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
            this.VS.Size = new System.Drawing.Size(1552, 462);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.Status = CommonTools.EnumStatus.SEARCH;
            this.VS.TabIndex = 154;
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
            this.CTLM.Location = new System.Drawing.Point(16, 13);
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
            // fItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1997, 996);
            this.ControlBox = false;
            this.Controls.Add(this.VS);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CTLM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fItems";
            this.ShowIcon = false;
            this.Text = "Inventory Items";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private EspackDataGridView.EspackDataGridViewControl VS;
        private EspackFormControlsNS.EspackTextBox txtCode;
        private EspackFormControlsNS.EspackTextBox txtName;
        private EspackFormControlsNS.EspackTextBox txtDesType;
        private EspackFormControlsNS.EspackComboBox cboType;
        private EspackFormControlsNS.EspackTextBox txtDescription;
        private EspackFormControlsNS.EspackComboBox cboZone;
        private EspackFormControlsNS.EspackCheckedListBox listCOD3;
        private EspackFormControlsNS.EspackTextBox txtDesCod3;
        private EspackFormControlsNS.EspackComboBox cboCOD3;
        private EspackFormControlsNS.EspackTextBox txtInvoice;
        private EspackFormControlsNS.EspackTextBox txtCM;
        private EspackFormControlsNS.EspackTextBox txtSerial;
        private EspackFormControlsNS.EspackDateTimePicker txtInvoiceDate;
        private EspackFormControlsNS.EspackCheckedListBox lstFlags;
        private EspackFormControlsNS.EspackCheckedListBox lstSectionFlags;
    }
}