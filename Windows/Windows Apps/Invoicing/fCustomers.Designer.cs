namespace Invoicing
{
    partial class fCustomers
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
            this.txtName = new EspackFormControlsNS.EspackTextBox();
            this.txtAddress = new EspackFormControlsNS.EspackTextBox();
            this.txtTown = new EspackFormControlsNS.EspackTextBox();
            this.txtPostalCode = new EspackFormControlsNS.EspackTextBox();
            this.txtCountyProv = new EspackFormControlsNS.EspackTextBox();
            this.txtVATNumber = new EspackFormControlsNS.EspackTextBox();
            this.txtCurrencyDescription = new EspackFormControlsNS.EspackTextBox();
            this.txtSupplierCodeDescription = new EspackFormControlsNS.EspackTextBox();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.cboCurrency = new EspackFormControlsNS.EspackComboBox();
            this.cboSupplierCode = new EspackFormControlsNS.EspackComboBox();
            this.txtCode = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtDueDays = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtVAT = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtShipVATNumber = new EspackFormControlsNS.EspackTextBox();
            this.txtShipCountyProv = new EspackFormControlsNS.EspackTextBox();
            this.txtShipPostalCode = new EspackFormControlsNS.EspackTextBox();
            this.txtShipTown = new EspackFormControlsNS.EspackTextBox();
            this.txtShipAddress = new EspackFormControlsNS.EspackTextBox();
            this.txtShipHolder = new EspackFormControlsNS.EspackTextBox();
            this.lstFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.cboPaymentCode = new EspackFormControlsNS.EspackComboBox();
            this.txtPaymentCodeDescription = new EspackFormControlsNS.EspackTextBox();
            this.cboCountryCode = new EspackFormControlsNS.EspackComboBox();
            this.txtCountryCodeDescription = new EspackFormControlsNS.EspackTextBox();
            this.txtIBAN = new EspackFormControlsNS.EspackTextBox();
            this.txtShipCountryCodeDescription = new EspackFormControlsNS.EspackTextBox();
            this.cboShipCountryCode = new EspackFormControlsNS.EspackComboBox();
            this.SuspendLayout();
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
            this.txtName.Location = new System.Drawing.Point(172, 49);
            this.txtName.Multiline = false;
            this.txtName.Name = "txtName";
            this.txtName.Order = 0;
            this.txtName.ParentConn = null;
            this.txtName.ParentDA = null;
            this.txtName.PK = false;
            this.txtName.Protected = false;
            this.txtName.ReadOnly = false;
            this.txtName.Search = false;
            this.txtName.Size = new System.Drawing.Size(314, 40);
            this.txtName.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtName.TabIndex = 2;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.Upp = false;
            this.txtName.Value = "";
            // 
            // txtAddress
            // 
            this.txtAddress.Add = false;
            this.txtAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtAddress.Caption = "Address";
            this.txtAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtAddress.DBField = null;
            this.txtAddress.DBFieldType = null;
            this.txtAddress.DefaultValue = null;
            this.txtAddress.Del = false;
            this.txtAddress.DependingRS = null;
            this.txtAddress.ExtraDataLink = null;
            this.txtAddress.IsCTLMOwned = false;
            this.txtAddress.IsPassword = false;
            this.txtAddress.Location = new System.Drawing.Point(12, 95);
            this.txtAddress.Multiline = false;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Order = 0;
            this.txtAddress.ParentConn = null;
            this.txtAddress.ParentDA = null;
            this.txtAddress.PK = false;
            this.txtAddress.Protected = false;
            this.txtAddress.ReadOnly = false;
            this.txtAddress.Search = false;
            this.txtAddress.Size = new System.Drawing.Size(474, 40);
            this.txtAddress.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtAddress.TabIndex = 3;
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAddress.Upp = false;
            this.txtAddress.Value = "";
            // 
            // txtTown
            // 
            this.txtTown.Add = false;
            this.txtTown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTown.Caption = "Town";
            this.txtTown.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTown.DBField = null;
            this.txtTown.DBFieldType = null;
            this.txtTown.DefaultValue = null;
            this.txtTown.Del = false;
            this.txtTown.DependingRS = null;
            this.txtTown.ExtraDataLink = null;
            this.txtTown.IsCTLMOwned = false;
            this.txtTown.IsPassword = false;
            this.txtTown.Location = new System.Drawing.Point(172, 141);
            this.txtTown.Multiline = false;
            this.txtTown.Name = "txtTown";
            this.txtTown.Order = 0;
            this.txtTown.ParentConn = null;
            this.txtTown.ParentDA = null;
            this.txtTown.PK = false;
            this.txtTown.Protected = false;
            this.txtTown.ReadOnly = false;
            this.txtTown.Search = false;
            this.txtTown.Size = new System.Drawing.Size(154, 40);
            this.txtTown.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtTown.TabIndex = 4;
            this.txtTown.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTown.Upp = false;
            this.txtTown.Value = "";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Add = false;
            this.txtPostalCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPostalCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPostalCode.Caption = "Postal Code";
            this.txtPostalCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPostalCode.DBField = null;
            this.txtPostalCode.DBFieldType = null;
            this.txtPostalCode.DefaultValue = null;
            this.txtPostalCode.Del = false;
            this.txtPostalCode.DependingRS = null;
            this.txtPostalCode.ExtraDataLink = null;
            this.txtPostalCode.IsCTLMOwned = false;
            this.txtPostalCode.IsPassword = false;
            this.txtPostalCode.Location = new System.Drawing.Point(12, 141);
            this.txtPostalCode.Multiline = false;
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Order = 0;
            this.txtPostalCode.ParentConn = null;
            this.txtPostalCode.ParentDA = null;
            this.txtPostalCode.PK = false;
            this.txtPostalCode.Protected = false;
            this.txtPostalCode.ReadOnly = false;
            this.txtPostalCode.Search = false;
            this.txtPostalCode.Size = new System.Drawing.Size(154, 40);
            this.txtPostalCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPostalCode.TabIndex = 5;
            this.txtPostalCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPostalCode.Upp = false;
            this.txtPostalCode.Value = "";
            // 
            // txtCountyProv
            // 
            this.txtCountyProv.Add = false;
            this.txtCountyProv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCountyProv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCountyProv.Caption = "County / Province";
            this.txtCountyProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCountyProv.DBField = null;
            this.txtCountyProv.DBFieldType = null;
            this.txtCountyProv.DefaultValue = null;
            this.txtCountyProv.Del = false;
            this.txtCountyProv.DependingRS = null;
            this.txtCountyProv.ExtraDataLink = null;
            this.txtCountyProv.IsCTLMOwned = false;
            this.txtCountyProv.IsPassword = false;
            this.txtCountyProv.Location = new System.Drawing.Point(332, 141);
            this.txtCountyProv.Multiline = false;
            this.txtCountyProv.Name = "txtCountyProv";
            this.txtCountyProv.Order = 0;
            this.txtCountyProv.ParentConn = null;
            this.txtCountyProv.ParentDA = null;
            this.txtCountyProv.PK = false;
            this.txtCountyProv.Protected = false;
            this.txtCountyProv.ReadOnly = false;
            this.txtCountyProv.Search = false;
            this.txtCountyProv.Size = new System.Drawing.Size(154, 40);
            this.txtCountyProv.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtCountyProv.TabIndex = 6;
            this.txtCountyProv.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCountyProv.Upp = false;
            this.txtCountyProv.Value = "";
            // 
            // txtVATNumber
            // 
            this.txtVATNumber.Add = false;
            this.txtVATNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtVATNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtVATNumber.Caption = "VAT Number";
            this.txtVATNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtVATNumber.DBField = null;
            this.txtVATNumber.DBFieldType = null;
            this.txtVATNumber.DefaultValue = null;
            this.txtVATNumber.Del = false;
            this.txtVATNumber.DependingRS = null;
            this.txtVATNumber.ExtraDataLink = null;
            this.txtVATNumber.IsCTLMOwned = false;
            this.txtVATNumber.IsPassword = false;
            this.txtVATNumber.Location = new System.Drawing.Point(12, 234);
            this.txtVATNumber.Multiline = false;
            this.txtVATNumber.Name = "txtVATNumber";
            this.txtVATNumber.Order = 0;
            this.txtVATNumber.ParentConn = null;
            this.txtVATNumber.ParentDA = null;
            this.txtVATNumber.PK = false;
            this.txtVATNumber.Protected = false;
            this.txtVATNumber.ReadOnly = false;
            this.txtVATNumber.Search = false;
            this.txtVATNumber.Size = new System.Drawing.Size(154, 41);
            this.txtVATNumber.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtVATNumber.TabIndex = 7;
            this.txtVATNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVATNumber.Upp = false;
            this.txtVATNumber.Value = "";
            // 
            // txtCurrencyDescription
            // 
            this.txtCurrencyDescription.Add = false;
            this.txtCurrencyDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCurrencyDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCurrencyDescription.Caption = "";
            this.txtCurrencyDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCurrencyDescription.DBField = null;
            this.txtCurrencyDescription.DBFieldType = null;
            this.txtCurrencyDescription.DefaultValue = null;
            this.txtCurrencyDescription.Del = false;
            this.txtCurrencyDescription.DependingRS = null;
            this.txtCurrencyDescription.ExtraDataLink = null;
            this.txtCurrencyDescription.IsCTLMOwned = false;
            this.txtCurrencyDescription.IsPassword = false;
            this.txtCurrencyDescription.Location = new System.Drawing.Point(172, 389);
            this.txtCurrencyDescription.Multiline = false;
            this.txtCurrencyDescription.Name = "txtCurrencyDescription";
            this.txtCurrencyDescription.Order = 0;
            this.txtCurrencyDescription.ParentConn = null;
            this.txtCurrencyDescription.ParentDA = null;
            this.txtCurrencyDescription.PK = false;
            this.txtCurrencyDescription.Protected = false;
            this.txtCurrencyDescription.ReadOnly = true;
            this.txtCurrencyDescription.Search = false;
            this.txtCurrencyDescription.Size = new System.Drawing.Size(314, 24);
            this.txtCurrencyDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtCurrencyDescription.TabIndex = 14;
            this.txtCurrencyDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCurrencyDescription.Upp = false;
            this.txtCurrencyDescription.Value = "";
            // 
            // txtSupplierCodeDescription
            // 
            this.txtSupplierCodeDescription.Add = false;
            this.txtSupplierCodeDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSupplierCodeDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSupplierCodeDescription.Caption = "";
            this.txtSupplierCodeDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSupplierCodeDescription.DBField = null;
            this.txtSupplierCodeDescription.DBFieldType = null;
            this.txtSupplierCodeDescription.DefaultValue = null;
            this.txtSupplierCodeDescription.Del = false;
            this.txtSupplierCodeDescription.DependingRS = null;
            this.txtSupplierCodeDescription.ExtraDataLink = null;
            this.txtSupplierCodeDescription.IsCTLMOwned = false;
            this.txtSupplierCodeDescription.IsPassword = false;
            this.txtSupplierCodeDescription.Location = new System.Drawing.Point(172, 435);
            this.txtSupplierCodeDescription.Multiline = false;
            this.txtSupplierCodeDescription.Name = "txtSupplierCodeDescription";
            this.txtSupplierCodeDescription.Order = 0;
            this.txtSupplierCodeDescription.ParentConn = null;
            this.txtSupplierCodeDescription.ParentDA = null;
            this.txtSupplierCodeDescription.PK = false;
            this.txtSupplierCodeDescription.Protected = false;
            this.txtSupplierCodeDescription.ReadOnly = true;
            this.txtSupplierCodeDescription.Search = false;
            this.txtSupplierCodeDescription.Size = new System.Drawing.Size(314, 24);
            this.txtSupplierCodeDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtSupplierCodeDescription.TabIndex = 15;
            this.txtSupplierCodeDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSupplierCodeDescription.Upp = false;
            this.txtSupplierCodeDescription.Value = "";
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
            this.CTLM.Location = new System.Drawing.Point(12, 12);
            this.CTLM.MsgStatusInfoLabel = null;
            this.CTLM.MsgStatusLabel = null;
            this.CTLM.Name = "CTLM";
            this.CTLM.ReQuery = false;
            this.CTLM.Size = new System.Drawing.Size(300, 31);
            this.CTLM.sSPAdd = "";
            this.CTLM.sSPDel = "";
            this.CTLM.sSPUpp = "";
            this.CTLM.StatusBarProgress = null;
            this.CTLM.TabIndex = 16;
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
            this.cboCurrency.Location = new System.Drawing.Point(12, 373);
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
            this.cboCurrency.Size = new System.Drawing.Size(154, 40);
            this.cboCurrency.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboCurrency.TabIndex = 17;
            this.cboCurrency.TBDescription = null;
            this.cboCurrency.Upp = false;
            this.cboCurrency.Value = "";
            this.cboCurrency.ValueMember = "";
            // 
            // cboSupplierCode
            // 
            this.cboSupplierCode.Add = false;
            this.cboSupplierCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSupplierCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSupplierCode.Caption = "Supplier Code";
            this.cboSupplierCode.DataSource = null;
            this.cboSupplierCode.DBField = null;
            this.cboSupplierCode.DBFieldType = null;
            this.cboSupplierCode.DefaultValue = null;
            this.cboSupplierCode.Del = false;
            this.cboSupplierCode.DependingRS = null;
            this.cboSupplierCode.DisplayMember = "";
            this.cboSupplierCode.ExtraDataLink = null;
            this.cboSupplierCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSupplierCode.FormattingEnabled = false;
            this.cboSupplierCode.IsCTLMOwned = false;
            this.cboSupplierCode.Location = new System.Drawing.Point(12, 419);
            this.cboSupplierCode.Name = "cboSupplierCode";
            this.cboSupplierCode.Order = 0;
            this.cboSupplierCode.ParentConn = null;
            this.cboSupplierCode.ParentDA = null;
            this.cboSupplierCode.PK = false;
            this.cboSupplierCode.Protected = false;
            this.cboSupplierCode.ReadOnly = false;
            this.cboSupplierCode.Search = false;
            this.cboSupplierCode.SelectedItem = null;
            this.cboSupplierCode.SelectedValue = null;
            this.cboSupplierCode.Size = new System.Drawing.Size(154, 40);
            this.cboSupplierCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboSupplierCode.TabIndex = 18;
            this.cboSupplierCode.TBDescription = null;
            this.cboSupplierCode.Upp = false;
            this.cboSupplierCode.Value = "";
            this.cboSupplierCode.ValueMember = "";
            // 
            // txtCode
            // 
            this.txtCode.Add = false;
            this.txtCode.AllowSpace = false;
            this.txtCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCode.Caption = "Code";
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCode.DBField = null;
            this.txtCode.DBFieldType = null;
            this.txtCode.DefaultValue = null;
            this.txtCode.Del = false;
            this.txtCode.DependingRS = null;
            this.txtCode.Enabled = false;
            this.txtCode.ExtraDataLink = null;
            this.txtCode.IsCTLMOwned = false;
            this.txtCode.IsPassword = false;
            this.txtCode.Length = 0;
            this.txtCode.Location = new System.Drawing.Point(12, 49);
            this.txtCode.Mask = false;
            this.txtCode.Multiline = false;
            this.txtCode.Name = "txtCode";
            this.txtCode.Order = 0;
            this.txtCode.ParentConn = null;
            this.txtCode.ParentDA = null;
            this.txtCode.PK = false;
            this.txtCode.Precision = 0;
            this.txtCode.Protected = false;
            this.txtCode.ReadOnly = false;
            this.txtCode.Search = false;
            this.txtCode.Size = new System.Drawing.Size(154, 40);
            this.txtCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtCode.TabIndex = 19;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCode.ThousandsGroup = false;
            this.txtCode.Upp = false;
            this.txtCode.Value = null;
            // 
            // txtDueDays
            // 
            this.txtDueDays.Add = false;
            this.txtDueDays.AllowSpace = false;
            this.txtDueDays.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDueDays.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDueDays.Caption = "Due Days";
            this.txtDueDays.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDueDays.DBField = null;
            this.txtDueDays.DBFieldType = null;
            this.txtDueDays.DefaultValue = null;
            this.txtDueDays.Del = false;
            this.txtDueDays.DependingRS = null;
            this.txtDueDays.Enabled = false;
            this.txtDueDays.ExtraDataLink = null;
            this.txtDueDays.IsCTLMOwned = false;
            this.txtDueDays.IsPassword = false;
            this.txtDueDays.Length = 0;
            this.txtDueDays.Location = new System.Drawing.Point(332, 235);
            this.txtDueDays.Mask = false;
            this.txtDueDays.Multiline = false;
            this.txtDueDays.Name = "txtDueDays";
            this.txtDueDays.Order = 0;
            this.txtDueDays.ParentConn = null;
            this.txtDueDays.ParentDA = null;
            this.txtDueDays.PK = false;
            this.txtDueDays.Precision = 0;
            this.txtDueDays.Protected = false;
            this.txtDueDays.ReadOnly = false;
            this.txtDueDays.Search = false;
            this.txtDueDays.Size = new System.Drawing.Size(154, 40);
            this.txtDueDays.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDueDays.TabIndex = 20;
            this.txtDueDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDueDays.ThousandsGroup = false;
            this.txtDueDays.Upp = false;
            this.txtDueDays.Value = null;
            // 
            // txtVAT
            // 
            this.txtVAT.Add = false;
            this.txtVAT.AllowSpace = false;
            this.txtVAT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtVAT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtVAT.Caption = "VAT";
            this.txtVAT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtVAT.DBField = null;
            this.txtVAT.DBFieldType = null;
            this.txtVAT.DefaultValue = null;
            this.txtVAT.Del = false;
            this.txtVAT.DependingRS = null;
            this.txtVAT.Enabled = false;
            this.txtVAT.ExtraDataLink = null;
            this.txtVAT.IsCTLMOwned = false;
            this.txtVAT.IsPassword = false;
            this.txtVAT.Length = 0;
            this.txtVAT.Location = new System.Drawing.Point(172, 235);
            this.txtVAT.Mask = false;
            this.txtVAT.Multiline = false;
            this.txtVAT.Name = "txtVAT";
            this.txtVAT.Order = 0;
            this.txtVAT.ParentConn = null;
            this.txtVAT.ParentDA = null;
            this.txtVAT.PK = false;
            this.txtVAT.Precision = 0;
            this.txtVAT.Protected = false;
            this.txtVAT.ReadOnly = false;
            this.txtVAT.Search = false;
            this.txtVAT.Size = new System.Drawing.Size(154, 40);
            this.txtVAT.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtVAT.TabIndex = 21;
            this.txtVAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtVAT.ThousandsGroup = false;
            this.txtVAT.Upp = false;
            this.txtVAT.Value = null;
            // 
            // txtShipVATNumber
            // 
            this.txtShipVATNumber.Add = false;
            this.txtShipVATNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtShipVATNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtShipVATNumber.Caption = "Shipping VAT Number";
            this.txtShipVATNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtShipVATNumber.DBField = null;
            this.txtShipVATNumber.DBFieldType = null;
            this.txtShipVATNumber.DefaultValue = null;
            this.txtShipVATNumber.Del = false;
            this.txtShipVATNumber.DependingRS = null;
            this.txtShipVATNumber.ExtraDataLink = null;
            this.txtShipVATNumber.IsCTLMOwned = false;
            this.txtShipVATNumber.IsPassword = false;
            this.txtShipVATNumber.Location = new System.Drawing.Point(509, 235);
            this.txtShipVATNumber.Multiline = false;
            this.txtShipVATNumber.Name = "txtShipVATNumber";
            this.txtShipVATNumber.Order = 0;
            this.txtShipVATNumber.ParentConn = null;
            this.txtShipVATNumber.ParentDA = null;
            this.txtShipVATNumber.PK = false;
            this.txtShipVATNumber.Protected = false;
            this.txtShipVATNumber.ReadOnly = false;
            this.txtShipVATNumber.Search = false;
            this.txtShipVATNumber.Size = new System.Drawing.Size(154, 41);
            this.txtShipVATNumber.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtShipVATNumber.TabIndex = 27;
            this.txtShipVATNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtShipVATNumber.Upp = false;
            this.txtShipVATNumber.Value = "";
            // 
            // txtShipCountyProv
            // 
            this.txtShipCountyProv.Add = false;
            this.txtShipCountyProv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtShipCountyProv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtShipCountyProv.Caption = "Shipping County / Province";
            this.txtShipCountyProv.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtShipCountyProv.DBField = null;
            this.txtShipCountyProv.DBFieldType = null;
            this.txtShipCountyProv.DefaultValue = null;
            this.txtShipCountyProv.Del = false;
            this.txtShipCountyProv.DependingRS = null;
            this.txtShipCountyProv.ExtraDataLink = null;
            this.txtShipCountyProv.IsCTLMOwned = false;
            this.txtShipCountyProv.IsPassword = false;
            this.txtShipCountyProv.Location = new System.Drawing.Point(829, 141);
            this.txtShipCountyProv.Multiline = false;
            this.txtShipCountyProv.Name = "txtShipCountyProv";
            this.txtShipCountyProv.Order = 0;
            this.txtShipCountyProv.ParentConn = null;
            this.txtShipCountyProv.ParentDA = null;
            this.txtShipCountyProv.PK = false;
            this.txtShipCountyProv.Protected = false;
            this.txtShipCountyProv.ReadOnly = false;
            this.txtShipCountyProv.Search = false;
            this.txtShipCountyProv.Size = new System.Drawing.Size(154, 40);
            this.txtShipCountyProv.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtShipCountyProv.TabIndex = 26;
            this.txtShipCountyProv.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtShipCountyProv.Upp = false;
            this.txtShipCountyProv.Value = "";
            // 
            // txtShipPostalCode
            // 
            this.txtShipPostalCode.Add = false;
            this.txtShipPostalCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtShipPostalCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtShipPostalCode.Caption = "Shipping Postal Code";
            this.txtShipPostalCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtShipPostalCode.DBField = null;
            this.txtShipPostalCode.DBFieldType = null;
            this.txtShipPostalCode.DefaultValue = null;
            this.txtShipPostalCode.Del = false;
            this.txtShipPostalCode.DependingRS = null;
            this.txtShipPostalCode.ExtraDataLink = null;
            this.txtShipPostalCode.IsCTLMOwned = false;
            this.txtShipPostalCode.IsPassword = false;
            this.txtShipPostalCode.Location = new System.Drawing.Point(509, 141);
            this.txtShipPostalCode.Multiline = false;
            this.txtShipPostalCode.Name = "txtShipPostalCode";
            this.txtShipPostalCode.Order = 0;
            this.txtShipPostalCode.ParentConn = null;
            this.txtShipPostalCode.ParentDA = null;
            this.txtShipPostalCode.PK = false;
            this.txtShipPostalCode.Protected = false;
            this.txtShipPostalCode.ReadOnly = false;
            this.txtShipPostalCode.Search = false;
            this.txtShipPostalCode.Size = new System.Drawing.Size(154, 40);
            this.txtShipPostalCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtShipPostalCode.TabIndex = 25;
            this.txtShipPostalCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtShipPostalCode.Upp = false;
            this.txtShipPostalCode.Value = "";
            // 
            // txtShipTown
            // 
            this.txtShipTown.Add = false;
            this.txtShipTown.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtShipTown.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtShipTown.Caption = "Shipping Town";
            this.txtShipTown.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtShipTown.DBField = null;
            this.txtShipTown.DBFieldType = null;
            this.txtShipTown.DefaultValue = null;
            this.txtShipTown.Del = false;
            this.txtShipTown.DependingRS = null;
            this.txtShipTown.ExtraDataLink = null;
            this.txtShipTown.IsCTLMOwned = false;
            this.txtShipTown.IsPassword = false;
            this.txtShipTown.Location = new System.Drawing.Point(669, 141);
            this.txtShipTown.Multiline = false;
            this.txtShipTown.Name = "txtShipTown";
            this.txtShipTown.Order = 0;
            this.txtShipTown.ParentConn = null;
            this.txtShipTown.ParentDA = null;
            this.txtShipTown.PK = false;
            this.txtShipTown.Protected = false;
            this.txtShipTown.ReadOnly = false;
            this.txtShipTown.Search = false;
            this.txtShipTown.Size = new System.Drawing.Size(154, 40);
            this.txtShipTown.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtShipTown.TabIndex = 24;
            this.txtShipTown.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtShipTown.Upp = false;
            this.txtShipTown.Value = "";
            // 
            // txtShipAddress
            // 
            this.txtShipAddress.Add = false;
            this.txtShipAddress.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtShipAddress.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtShipAddress.Caption = "Shipping Address";
            this.txtShipAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtShipAddress.DBField = null;
            this.txtShipAddress.DBFieldType = null;
            this.txtShipAddress.DefaultValue = null;
            this.txtShipAddress.Del = false;
            this.txtShipAddress.DependingRS = null;
            this.txtShipAddress.ExtraDataLink = null;
            this.txtShipAddress.IsCTLMOwned = false;
            this.txtShipAddress.IsPassword = false;
            this.txtShipAddress.Location = new System.Drawing.Point(509, 95);
            this.txtShipAddress.Multiline = false;
            this.txtShipAddress.Name = "txtShipAddress";
            this.txtShipAddress.Order = 0;
            this.txtShipAddress.ParentConn = null;
            this.txtShipAddress.ParentDA = null;
            this.txtShipAddress.PK = false;
            this.txtShipAddress.Protected = false;
            this.txtShipAddress.ReadOnly = false;
            this.txtShipAddress.Search = false;
            this.txtShipAddress.Size = new System.Drawing.Size(474, 40);
            this.txtShipAddress.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtShipAddress.TabIndex = 23;
            this.txtShipAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtShipAddress.Upp = false;
            this.txtShipAddress.Value = "";
            // 
            // txtShipHolder
            // 
            this.txtShipHolder.Add = false;
            this.txtShipHolder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtShipHolder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtShipHolder.Caption = "Shipping Holder";
            this.txtShipHolder.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtShipHolder.DBField = null;
            this.txtShipHolder.DBFieldType = null;
            this.txtShipHolder.DefaultValue = null;
            this.txtShipHolder.Del = false;
            this.txtShipHolder.DependingRS = null;
            this.txtShipHolder.ExtraDataLink = null;
            this.txtShipHolder.IsCTLMOwned = false;
            this.txtShipHolder.IsPassword = false;
            this.txtShipHolder.Location = new System.Drawing.Point(509, 49);
            this.txtShipHolder.Multiline = false;
            this.txtShipHolder.Name = "txtShipHolder";
            this.txtShipHolder.Order = 0;
            this.txtShipHolder.ParentConn = null;
            this.txtShipHolder.ParentDA = null;
            this.txtShipHolder.PK = false;
            this.txtShipHolder.Protected = false;
            this.txtShipHolder.ReadOnly = false;
            this.txtShipHolder.Search = false;
            this.txtShipHolder.Size = new System.Drawing.Size(474, 40);
            this.txtShipHolder.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtShipHolder.TabIndex = 22;
            this.txtShipHolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtShipHolder.Upp = false;
            this.txtShipHolder.Value = "";
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
            this.lstFlags.Location = new System.Drawing.Point(12, 478);
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
            this.lstFlags.Size = new System.Drawing.Size(971, 70);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 126;
            this.lstFlags.TBDescription = null;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            this.lstFlags.ValueMember = "";
            // 
            // cboPaymentCode
            // 
            this.cboPaymentCode.Add = false;
            this.cboPaymentCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPaymentCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPaymentCode.Caption = "Payment Code";
            this.cboPaymentCode.DataSource = null;
            this.cboPaymentCode.DBField = null;
            this.cboPaymentCode.DBFieldType = null;
            this.cboPaymentCode.DefaultValue = null;
            this.cboPaymentCode.Del = false;
            this.cboPaymentCode.DependingRS = null;
            this.cboPaymentCode.DisplayMember = "";
            this.cboPaymentCode.ExtraDataLink = null;
            this.cboPaymentCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPaymentCode.FormattingEnabled = false;
            this.cboPaymentCode.IsCTLMOwned = false;
            this.cboPaymentCode.Location = new System.Drawing.Point(12, 327);
            this.cboPaymentCode.Name = "cboPaymentCode";
            this.cboPaymentCode.Order = 0;
            this.cboPaymentCode.ParentConn = null;
            this.cboPaymentCode.ParentDA = null;
            this.cboPaymentCode.PK = false;
            this.cboPaymentCode.Protected = false;
            this.cboPaymentCode.ReadOnly = false;
            this.cboPaymentCode.Search = false;
            this.cboPaymentCode.SelectedItem = null;
            this.cboPaymentCode.SelectedValue = null;
            this.cboPaymentCode.Size = new System.Drawing.Size(154, 40);
            this.cboPaymentCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboPaymentCode.TabIndex = 128;
            this.cboPaymentCode.TBDescription = null;
            this.cboPaymentCode.Upp = false;
            this.cboPaymentCode.Value = "";
            this.cboPaymentCode.ValueMember = "";
            // 
            // txtPaymentCodeDescription
            // 
            this.txtPaymentCodeDescription.Add = false;
            this.txtPaymentCodeDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPaymentCodeDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPaymentCodeDescription.Caption = "";
            this.txtPaymentCodeDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPaymentCodeDescription.DBField = null;
            this.txtPaymentCodeDescription.DBFieldType = null;
            this.txtPaymentCodeDescription.DefaultValue = null;
            this.txtPaymentCodeDescription.Del = false;
            this.txtPaymentCodeDescription.DependingRS = null;
            this.txtPaymentCodeDescription.ExtraDataLink = null;
            this.txtPaymentCodeDescription.IsCTLMOwned = false;
            this.txtPaymentCodeDescription.IsPassword = false;
            this.txtPaymentCodeDescription.Location = new System.Drawing.Point(172, 343);
            this.txtPaymentCodeDescription.Multiline = false;
            this.txtPaymentCodeDescription.Name = "txtPaymentCodeDescription";
            this.txtPaymentCodeDescription.Order = 0;
            this.txtPaymentCodeDescription.ParentConn = null;
            this.txtPaymentCodeDescription.ParentDA = null;
            this.txtPaymentCodeDescription.PK = false;
            this.txtPaymentCodeDescription.Protected = false;
            this.txtPaymentCodeDescription.ReadOnly = true;
            this.txtPaymentCodeDescription.Search = false;
            this.txtPaymentCodeDescription.Size = new System.Drawing.Size(314, 24);
            this.txtPaymentCodeDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPaymentCodeDescription.TabIndex = 127;
            this.txtPaymentCodeDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPaymentCodeDescription.Upp = false;
            this.txtPaymentCodeDescription.Value = "";
            // 
            // cboCountryCode
            // 
            this.cboCountryCode.Add = false;
            this.cboCountryCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCountryCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCountryCode.Caption = "Country Code";
            this.cboCountryCode.DataSource = null;
            this.cboCountryCode.DBField = null;
            this.cboCountryCode.DBFieldType = null;
            this.cboCountryCode.DefaultValue = null;
            this.cboCountryCode.Del = false;
            this.cboCountryCode.DependingRS = null;
            this.cboCountryCode.DisplayMember = "";
            this.cboCountryCode.ExtraDataLink = null;
            this.cboCountryCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCountryCode.FormattingEnabled = false;
            this.cboCountryCode.IsCTLMOwned = false;
            this.cboCountryCode.Location = new System.Drawing.Point(12, 188);
            this.cboCountryCode.Name = "cboCountryCode";
            this.cboCountryCode.Order = 0;
            this.cboCountryCode.ParentConn = null;
            this.cboCountryCode.ParentDA = null;
            this.cboCountryCode.PK = false;
            this.cboCountryCode.Protected = false;
            this.cboCountryCode.ReadOnly = false;
            this.cboCountryCode.Search = false;
            this.cboCountryCode.SelectedItem = null;
            this.cboCountryCode.SelectedValue = null;
            this.cboCountryCode.Size = new System.Drawing.Size(154, 40);
            this.cboCountryCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboCountryCode.TabIndex = 129;
            this.cboCountryCode.TBDescription = null;
            this.cboCountryCode.Upp = false;
            this.cboCountryCode.Value = "";
            this.cboCountryCode.ValueMember = "";
            // 
            // txtCountryCodeDescription
            // 
            this.txtCountryCodeDescription.Add = false;
            this.txtCountryCodeDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCountryCodeDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCountryCodeDescription.Caption = "";
            this.txtCountryCodeDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCountryCodeDescription.DBField = null;
            this.txtCountryCodeDescription.DBFieldType = null;
            this.txtCountryCodeDescription.DefaultValue = null;
            this.txtCountryCodeDescription.Del = false;
            this.txtCountryCodeDescription.DependingRS = null;
            this.txtCountryCodeDescription.ExtraDataLink = null;
            this.txtCountryCodeDescription.IsCTLMOwned = false;
            this.txtCountryCodeDescription.IsPassword = false;
            this.txtCountryCodeDescription.Location = new System.Drawing.Point(172, 204);
            this.txtCountryCodeDescription.Multiline = false;
            this.txtCountryCodeDescription.Name = "txtCountryCodeDescription";
            this.txtCountryCodeDescription.Order = 0;
            this.txtCountryCodeDescription.ParentConn = null;
            this.txtCountryCodeDescription.ParentDA = null;
            this.txtCountryCodeDescription.PK = false;
            this.txtCountryCodeDescription.Protected = false;
            this.txtCountryCodeDescription.ReadOnly = true;
            this.txtCountryCodeDescription.Search = false;
            this.txtCountryCodeDescription.Size = new System.Drawing.Size(314, 24);
            this.txtCountryCodeDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtCountryCodeDescription.TabIndex = 130;
            this.txtCountryCodeDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCountryCodeDescription.Upp = false;
            this.txtCountryCodeDescription.Value = "";
            // 
            // txtIBAN
            // 
            this.txtIBAN.Add = false;
            this.txtIBAN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtIBAN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtIBAN.Caption = "IBAN";
            this.txtIBAN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtIBAN.DBField = null;
            this.txtIBAN.DBFieldType = null;
            this.txtIBAN.DefaultValue = null;
            this.txtIBAN.Del = false;
            this.txtIBAN.DependingRS = null;
            this.txtIBAN.ExtraDataLink = null;
            this.txtIBAN.IsCTLMOwned = false;
            this.txtIBAN.IsPassword = false;
            this.txtIBAN.Location = new System.Drawing.Point(12, 281);
            this.txtIBAN.Multiline = false;
            this.txtIBAN.Name = "txtIBAN";
            this.txtIBAN.Order = 0;
            this.txtIBAN.ParentConn = null;
            this.txtIBAN.ParentDA = null;
            this.txtIBAN.PK = false;
            this.txtIBAN.Protected = false;
            this.txtIBAN.ReadOnly = false;
            this.txtIBAN.Search = false;
            this.txtIBAN.Size = new System.Drawing.Size(474, 40);
            this.txtIBAN.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtIBAN.TabIndex = 131;
            this.txtIBAN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIBAN.Upp = false;
            this.txtIBAN.Value = "";
            // 
            // txtShipCountryCodeDescription
            // 
            this.txtShipCountryCodeDescription.Add = false;
            this.txtShipCountryCodeDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtShipCountryCodeDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtShipCountryCodeDescription.Caption = "";
            this.txtShipCountryCodeDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtShipCountryCodeDescription.DBField = null;
            this.txtShipCountryCodeDescription.DBFieldType = null;
            this.txtShipCountryCodeDescription.DefaultValue = null;
            this.txtShipCountryCodeDescription.Del = false;
            this.txtShipCountryCodeDescription.DependingRS = null;
            this.txtShipCountryCodeDescription.ExtraDataLink = null;
            this.txtShipCountryCodeDescription.IsCTLMOwned = false;
            this.txtShipCountryCodeDescription.IsPassword = false;
            this.txtShipCountryCodeDescription.Location = new System.Drawing.Point(669, 204);
            this.txtShipCountryCodeDescription.Multiline = false;
            this.txtShipCountryCodeDescription.Name = "txtShipCountryCodeDescription";
            this.txtShipCountryCodeDescription.Order = 0;
            this.txtShipCountryCodeDescription.ParentConn = null;
            this.txtShipCountryCodeDescription.ParentDA = null;
            this.txtShipCountryCodeDescription.PK = false;
            this.txtShipCountryCodeDescription.Protected = false;
            this.txtShipCountryCodeDescription.ReadOnly = true;
            this.txtShipCountryCodeDescription.Search = false;
            this.txtShipCountryCodeDescription.Size = new System.Drawing.Size(314, 24);
            this.txtShipCountryCodeDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtShipCountryCodeDescription.TabIndex = 133;
            this.txtShipCountryCodeDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtShipCountryCodeDescription.Upp = false;
            this.txtShipCountryCodeDescription.Value = "";
            // 
            // cboShipCountryCode
            // 
            this.cboShipCountryCode.Add = false;
            this.cboShipCountryCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboShipCountryCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboShipCountryCode.Caption = "Shipping Country Code";
            this.cboShipCountryCode.DataSource = null;
            this.cboShipCountryCode.DBField = null;
            this.cboShipCountryCode.DBFieldType = null;
            this.cboShipCountryCode.DefaultValue = null;
            this.cboShipCountryCode.Del = false;
            this.cboShipCountryCode.DependingRS = null;
            this.cboShipCountryCode.DisplayMember = "";
            this.cboShipCountryCode.ExtraDataLink = null;
            this.cboShipCountryCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboShipCountryCode.FormattingEnabled = false;
            this.cboShipCountryCode.IsCTLMOwned = false;
            this.cboShipCountryCode.Location = new System.Drawing.Point(509, 188);
            this.cboShipCountryCode.Name = "cboShipCountryCode";
            this.cboShipCountryCode.Order = 0;
            this.cboShipCountryCode.ParentConn = null;
            this.cboShipCountryCode.ParentDA = null;
            this.cboShipCountryCode.PK = false;
            this.cboShipCountryCode.Protected = false;
            this.cboShipCountryCode.ReadOnly = false;
            this.cboShipCountryCode.Search = false;
            this.cboShipCountryCode.SelectedItem = null;
            this.cboShipCountryCode.SelectedValue = null;
            this.cboShipCountryCode.Size = new System.Drawing.Size(154, 40);
            this.cboShipCountryCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboShipCountryCode.TabIndex = 132;
            this.cboShipCountryCode.TBDescription = null;
            this.cboShipCountryCode.Upp = false;
            this.cboShipCountryCode.Value = "";
            this.cboShipCountryCode.ValueMember = "";
            // 
            // fCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 587);
            this.Controls.Add(this.txtShipCountryCodeDescription);
            this.Controls.Add(this.cboShipCountryCode);
            this.Controls.Add(this.txtIBAN);
            this.Controls.Add(this.txtCountryCodeDescription);
            this.Controls.Add(this.cboCountryCode);
            this.Controls.Add(this.cboPaymentCode);
            this.Controls.Add(this.txtPaymentCodeDescription);
            this.Controls.Add(this.lstFlags);
            this.Controls.Add(this.txtShipVATNumber);
            this.Controls.Add(this.txtShipCountyProv);
            this.Controls.Add(this.txtShipPostalCode);
            this.Controls.Add(this.txtShipTown);
            this.Controls.Add(this.txtShipAddress);
            this.Controls.Add(this.txtShipHolder);
            this.Controls.Add(this.txtVAT);
            this.Controls.Add(this.txtDueDays);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.cboSupplierCode);
            this.Controls.Add(this.cboCurrency);
            this.Controls.Add(this.CTLM);
            this.Controls.Add(this.txtSupplierCodeDescription);
            this.Controls.Add(this.txtCurrencyDescription);
            this.Controls.Add(this.txtVATNumber);
            this.Controls.Add(this.txtCountyProv);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.txtTown);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "fCustomers";
            this.ShowIcon = false;
            this.Text = "Customers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private EspackFormControlsNS.EspackTextBox txtName;
        private EspackFormControlsNS.EspackTextBox txtAddress;
        private EspackFormControlsNS.EspackTextBox txtTown;
        private EspackFormControlsNS.EspackTextBox txtPostalCode;
        private EspackFormControlsNS.EspackTextBox txtCountyProv;
        private EspackFormControlsNS.EspackTextBox txtVATNumber;
        private EspackFormControlsNS.EspackTextBox txtCurrencyDescription;
        private EspackFormControlsNS.EspackTextBox txtSupplierCodeDescription;
        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackComboBox cboCurrency;
        private EspackFormControlsNS.EspackComboBox cboSupplierCode;
        private EspackFormControlsNS.EspackNumericTextBox txtCode;
        private EspackFormControlsNS.EspackNumericTextBox txtDueDays;
        private EspackFormControlsNS.EspackNumericTextBox txtVAT;
        private EspackFormControlsNS.EspackTextBox txtShipVATNumber;
        private EspackFormControlsNS.EspackTextBox txtShipCountyProv;
        private EspackFormControlsNS.EspackTextBox txtShipPostalCode;
        private EspackFormControlsNS.EspackTextBox txtShipTown;
        private EspackFormControlsNS.EspackTextBox txtShipAddress;
        private EspackFormControlsNS.EspackTextBox txtShipHolder;
        private EspackFormControlsNS.EspackCheckedListBox lstFlags;
        private EspackFormControlsNS.EspackComboBox cboPaymentCode;
        private EspackFormControlsNS.EspackTextBox txtPaymentCodeDescription;
        private EspackFormControlsNS.EspackComboBox cboCountryCode;
        private EspackFormControlsNS.EspackTextBox txtCountryCodeDescription;
        private EspackFormControlsNS.EspackTextBox txtIBAN;
        private EspackFormControlsNS.EspackTextBox txtShipCountryCodeDescription;
        private EspackFormControlsNS.EspackComboBox cboShipCountryCode;
    }
}