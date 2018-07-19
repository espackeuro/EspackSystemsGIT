namespace Sistemas
{
    partial class fUsers
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUserNumber = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtSurname2 = new EspackFormControlsNS.EspackTextBox();
            this.txtSurname1 = new EspackFormControlsNS.EspackTextBox();
            this.txtName = new EspackFormControlsNS.EspackTextBox();
            this.txtUserCode = new EspackFormControlsNS.EspackTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboArea = new EspackFormControlsNS.EspackComboBox();
            this.cboPositionLevel = new EspackFormControlsNS.EspackComboBox();
            this.txtPosition = new EspackFormControlsNS.EspackTextBox();
            this.cboSecurityLevel = new EspackFormControlsNS.EspackComboBox();
            this.txtDesCod3 = new EspackFormControlsNS.EspackTextBox();
            this.cboCOD3 = new EspackFormControlsNS.EspackComboBox();
            this.listCOD3 = new EspackFormControlsNS.EspackCheckedListBox();
            this.cboPosition = new EspackFormControlsNS.EspackComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtTicketExp = new EspackFormControlsNS.EspackDateTimePicker();
            this.txtTicket = new EspackFormControlsNS.EspackTextBox();
            this.txtEmail = new EspackFormControlsNS.EspackTextBox();
            this.txtPIN = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtQuota = new EspackFormControlsNS.EspackNumericTextBox();
            this.cboDomain = new EspackFormControlsNS.EspackComboBox();
            this.txtPasswordEXP = new EspackFormControlsNS.EspackDateTimePicker();
            this.lstFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtPWD = new EspackFormControlsNS.EspackTextBox();
            this.lstEmailAliases = new EspackFormControlsNS.EspackCheckedListBox();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.txtUserNumber);
            this.groupBox1.Controls.Add(this.txtSurname2);
            this.groupBox1.Controls.Add(this.txtSurname1);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtUserCode);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(16, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(528, 110);
            this.groupBox1.TabIndex = 137;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Who is";
            // 
            // txtUserNumber
            // 
            this.txtUserNumber.Add = false;
            this.txtUserNumber.AllowSpace = false;
            this.txtUserNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUserNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUserNumber.Caption = "UserNumber";
            this.txtUserNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUserNumber.DBField = null;
            this.txtUserNumber.DBFieldType = null;
            this.txtUserNumber.DefaultValue = null;
            this.txtUserNumber.Del = false;
            this.txtUserNumber.DependingRS = null;
            this.txtUserNumber.ExtraDataLink = null;
            this.txtUserNumber.ForeColor = System.Drawing.Color.Gray;
            this.txtUserNumber.IsCTLMOwned = false;
            this.txtUserNumber.Length = 0;
            this.txtUserNumber.Location = new System.Drawing.Point(351, 29);
            this.txtUserNumber.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtUserNumber.Mask = false;
            this.txtUserNumber.Multiline = true;
            this.txtUserNumber.Name = "txtUserNumber";
            this.txtUserNumber.Order = 0;
            this.txtUserNumber.ParentConn = null;
            this.txtUserNumber.ParentDA = null;
            
            this.txtUserNumber.PK = false;
            this.txtUserNumber.Precision = 0;
            this.txtUserNumber.Protected = false;
            this.txtUserNumber.ReadOnly = true;
            this.txtUserNumber.Search = false;
            this.txtUserNumber.Size = new System.Drawing.Size(154, 38);
            this.txtUserNumber.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtUserNumber.TabIndex = 2;
            this.txtUserNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUserNumber.ThousandsGroup = false;
            this.txtUserNumber.Upp = false;
            
            this.txtUserNumber.Value = null;
            // 
            // txtSurname2
            // 
            this.txtSurname2.Add = false;
            this.txtSurname2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSurname2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSurname2.Caption = "Surname 2";
            this.txtSurname2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSurname2.DBField = null;
            this.txtSurname2.DBFieldType = null;
            this.txtSurname2.DefaultValue = null;
            this.txtSurname2.Del = false;
            this.txtSurname2.DependingRS = null;
            this.txtSurname2.ExtraDataLink = null;
            this.txtSurname2.ForeColor = System.Drawing.Color.Gray;
            this.txtSurname2.IsCTLMOwned = false;
            this.txtSurname2.Location = new System.Drawing.Point(351, 74);
            this.txtSurname2.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtSurname2.Multiline = true;
            this.txtSurname2.Name = "txtSurname2";
            this.txtSurname2.Order = 0;
            this.txtSurname2.ParentConn = null;
            this.txtSurname2.ParentDA = null;
            
            this.txtSurname2.PK = false;
            this.txtSurname2.Protected = false;
            this.txtSurname2.ReadOnly = true;
            this.txtSurname2.Search = false;
            this.txtSurname2.Size = new System.Drawing.Size(154, 38);
            this.txtSurname2.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtSurname2.TabIndex = 5;
            this.txtSurname2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSurname2.Upp = false;
            
            this.txtSurname2.Value = "";
            // 
            // txtSurname1
            // 
            this.txtSurname1.Add = false;
            this.txtSurname1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSurname1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSurname1.Caption = "Surname 1";
            this.txtSurname1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtSurname1.DBField = null;
            this.txtSurname1.DBFieldType = null;
            this.txtSurname1.DefaultValue = null;
            this.txtSurname1.Del = false;
            this.txtSurname1.DependingRS = null;
            this.txtSurname1.ExtraDataLink = null;
            this.txtSurname1.ForeColor = System.Drawing.Color.Gray;
            this.txtSurname1.IsCTLMOwned = false;
            this.txtSurname1.Location = new System.Drawing.Point(188, 74);
            this.txtSurname1.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtSurname1.Multiline = true;
            this.txtSurname1.Name = "txtSurname1";
            this.txtSurname1.Order = 0;
            this.txtSurname1.ParentConn = null;
            this.txtSurname1.ParentDA = null;
            
            this.txtSurname1.PK = false;
            this.txtSurname1.Protected = false;
            this.txtSurname1.ReadOnly = true;
            this.txtSurname1.Search = false;
            this.txtSurname1.Size = new System.Drawing.Size(154, 38);
            this.txtSurname1.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtSurname1.TabIndex = 4;
            this.txtSurname1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSurname1.Upp = false;
            
            this.txtSurname1.Value = "";
            // 
            // txtName
            // 
            this.txtName.Add = false;
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtName.Caption = "Name";
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtName.DBField = null;
            this.txtName.DBFieldType = null;
            this.txtName.DefaultValue = null;
            this.txtName.Del = false;
            this.txtName.DependingRS = null;
            this.txtName.ExtraDataLink = null;
            this.txtName.ForeColor = System.Drawing.Color.Gray;
            this.txtName.IsCTLMOwned = false;
            this.txtName.Location = new System.Drawing.Point(23, 74);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Order = 0;
            this.txtName.ParentConn = null;
            this.txtName.ParentDA = null;
            
            this.txtName.PK = false;
            this.txtName.Protected = false;
            this.txtName.ReadOnly = true;
            this.txtName.Search = false;
            this.txtName.Size = new System.Drawing.Size(154, 38);
            this.txtName.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtName.TabIndex = 3;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.Upp = false;
            
            this.txtName.Value = "";
            // 
            // txtUserCode
            // 
            this.txtUserCode.Add = false;
            this.txtUserCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUserCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUserCode.Caption = "UserCode";
            this.txtUserCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtUserCode.DBField = null;
            this.txtUserCode.DBFieldType = null;
            this.txtUserCode.DefaultValue = null;
            this.txtUserCode.Del = false;
            this.txtUserCode.DependingRS = null;
            this.txtUserCode.ExtraDataLink = null;
            this.txtUserCode.ForeColor = System.Drawing.Color.Gray;
            this.txtUserCode.IsCTLMOwned = false;
            this.txtUserCode.Location = new System.Drawing.Point(23, 29);
            this.txtUserCode.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtUserCode.Multiline = true;
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Order = 0;
            this.txtUserCode.ParentConn = null;
            this.txtUserCode.ParentDA = null;
            
            this.txtUserCode.PK = false;
            this.txtUserCode.Protected = false;
            this.txtUserCode.ReadOnly = true;
            this.txtUserCode.Search = false;
            this.txtUserCode.Size = new System.Drawing.Size(154, 38);
            this.txtUserCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtUserCode.TabIndex = 1;
            this.txtUserCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUserCode.Upp = false;
            
            this.txtUserCode.Value = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboArea);
            this.groupBox2.Controls.Add(this.cboPositionLevel);
            this.groupBox2.Controls.Add(this.txtPosition);
            this.groupBox2.Controls.Add(this.cboSecurityLevel);
            this.groupBox2.Controls.Add(this.txtDesCod3);
            this.groupBox2.Controls.Add(this.cboCOD3);
            this.groupBox2.Controls.Add(this.listCOD3);
            this.groupBox2.Controls.Add(this.cboPosition);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(16, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(528, 316);
            this.groupBox2.TabIndex = 147;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Where";
            // 
            // cboArea
            // 
            this.cboArea.Add = false;
            this.cboArea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboArea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboArea.Caption = "Area";
            this.cboArea.DataSource = null;
            this.cboArea.DBField = null;
            this.cboArea.DBFieldType = null;
            this.cboArea.DefaultValue = null;
            this.cboArea.Del = false;
            this.cboArea.DependingRS = null;
            this.cboArea.DisplayMember = "";
            this.cboArea.ExtraDataLink = null;
            this.cboArea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboArea.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboArea.ForeColor = System.Drawing.Color.Black;
            this.cboArea.FormattingEnabled = true;
            this.cboArea.IsCTLMOwned = false;
            this.cboArea.Location = new System.Drawing.Point(351, 275);
            this.cboArea.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboArea.Name = "cboArea";
            this.cboArea.Order = 0;
            this.cboArea.ParentConn = null;
            this.cboArea.ParentDA = null;
            this.cboArea.PK = false;
            this.cboArea.Protected = false;
            this.cboArea.ReadOnly = false;
            this.cboArea.Search = false;
            this.cboArea.SelectedItem = null;
            this.cboArea.SelectedValue = null;
            this.cboArea.Size = new System.Drawing.Size(154, 40);
            this.cboArea.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboArea.TabIndex = 134;
            this.cboArea.TBDescription = null;
            this.cboArea.Upp = false;
            this.cboArea.Value = "";
            this.cboArea.ValueMember = "";
            // 
            // cboPositionLevel
            // 
            this.cboPositionLevel.Add = false;
            this.cboPositionLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPositionLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPositionLevel.Caption = "Position Level";
            this.cboPositionLevel.DataSource = null;
            this.cboPositionLevel.DBField = null;
            this.cboPositionLevel.DBFieldType = null;
            this.cboPositionLevel.DefaultValue = null;
            this.cboPositionLevel.Del = false;
            this.cboPositionLevel.DependingRS = null;
            this.cboPositionLevel.DisplayMember = "";
            this.cboPositionLevel.ExtraDataLink = null;
            this.cboPositionLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPositionLevel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboPositionLevel.ForeColor = System.Drawing.Color.Black;
            this.cboPositionLevel.FormattingEnabled = true;
            this.cboPositionLevel.IsCTLMOwned = false;
            this.cboPositionLevel.Location = new System.Drawing.Point(23, 275);
            this.cboPositionLevel.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboPositionLevel.Name = "cboPositionLevel";
            this.cboPositionLevel.Order = 0;
            this.cboPositionLevel.ParentConn = null;
            this.cboPositionLevel.ParentDA = null;
            this.cboPositionLevel.PK = false;
            this.cboPositionLevel.Protected = false;
            this.cboPositionLevel.ReadOnly = false;
            this.cboPositionLevel.Search = false;
            this.cboPositionLevel.SelectedItem = null;
            this.cboPositionLevel.SelectedValue = null;
            this.cboPositionLevel.Size = new System.Drawing.Size(154, 40);
            this.cboPositionLevel.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboPositionLevel.TabIndex = 126;
            this.cboPositionLevel.TBDescription = null;
            this.cboPositionLevel.Upp = false;
            this.cboPositionLevel.Value = "";
            this.cboPositionLevel.ValueMember = "";
            // 
            // txtPosition
            // 
            this.txtPosition.Add = false;
            this.txtPosition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPosition.Caption = "";
            this.txtPosition.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPosition.DBField = null;
            this.txtPosition.DBFieldType = null;
            this.txtPosition.DefaultValue = null;
            this.txtPosition.Del = false;
            this.txtPosition.DependingRS = null;
            this.txtPosition.ExtraDataLink = null;
            this.txtPosition.ForeColor = System.Drawing.Color.Gray;
            this.txtPosition.IsCTLMOwned = false;
            this.txtPosition.Location = new System.Drawing.Point(183, 247);
            this.txtPosition.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtPosition.Multiline = true;
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Order = 0;
            this.txtPosition.ParentConn = null;
            this.txtPosition.ParentDA = null;
            
            this.txtPosition.PK = false;
            this.txtPosition.Protected = false;
            this.txtPosition.ReadOnly = true;
            this.txtPosition.Search = false;
            this.txtPosition.Size = new System.Drawing.Size(322, 25);
            this.txtPosition.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPosition.TabIndex = 124;
            this.txtPosition.TabStop = false;
            this.txtPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPosition.Upp = false;
            
            this.txtPosition.Value = "";
            // 
            // cboSecurityLevel
            // 
            this.cboSecurityLevel.Add = false;
            this.cboSecurityLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSecurityLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSecurityLevel.Caption = "Security Level";
            this.cboSecurityLevel.DataSource = null;
            this.cboSecurityLevel.DBField = null;
            this.cboSecurityLevel.DBFieldType = null;
            this.cboSecurityLevel.DefaultValue = null;
            this.cboSecurityLevel.Del = false;
            this.cboSecurityLevel.DependingRS = null;
            this.cboSecurityLevel.DisplayMember = "";
            this.cboSecurityLevel.ExtraDataLink = null;
            this.cboSecurityLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSecurityLevel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboSecurityLevel.ForeColor = System.Drawing.Color.Black;
            this.cboSecurityLevel.FormattingEnabled = true;
            this.cboSecurityLevel.IsCTLMOwned = false;
            this.cboSecurityLevel.Location = new System.Drawing.Point(188, 275);
            this.cboSecurityLevel.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboSecurityLevel.Name = "cboSecurityLevel";
            this.cboSecurityLevel.Order = 0;
            this.cboSecurityLevel.ParentConn = null;
            this.cboSecurityLevel.ParentDA = null;
            this.cboSecurityLevel.PK = false;
            this.cboSecurityLevel.Protected = false;
            this.cboSecurityLevel.ReadOnly = false;
            this.cboSecurityLevel.Search = false;
            this.cboSecurityLevel.SelectedItem = null;
            this.cboSecurityLevel.SelectedValue = null;
            this.cboSecurityLevel.Size = new System.Drawing.Size(154, 40);
            this.cboSecurityLevel.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboSecurityLevel.TabIndex = 122;
            this.cboSecurityLevel.TBDescription = null;
            this.cboSecurityLevel.Upp = false;
            this.cboSecurityLevel.Value = "";
            this.cboSecurityLevel.ValueMember = "";
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
            this.txtDesCod3.ForeColor = System.Drawing.Color.Gray;
            this.txtDesCod3.IsCTLMOwned = false;
            this.txtDesCod3.Location = new System.Drawing.Point(183, 52);
            this.txtDesCod3.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDesCod3.Multiline = true;
            this.txtDesCod3.Name = "txtDesCod3";
            this.txtDesCod3.Order = 0;
            this.txtDesCod3.ParentConn = null;
            this.txtDesCod3.ParentDA = null;
            
            this.txtDesCod3.PK = false;
            this.txtDesCod3.Protected = false;
            this.txtDesCod3.ReadOnly = true;
            this.txtDesCod3.Search = false;
            this.txtDesCod3.Size = new System.Drawing.Size(322, 25);
            this.txtDesCod3.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDesCod3.TabIndex = 116;
            this.txtDesCod3.TabStop = false;
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
            this.cboCOD3.Location = new System.Drawing.Point(23, 37);
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
            this.cboCOD3.TabIndex = 6;
            this.cboCOD3.TBDescription = null;
            this.cboCOD3.Upp = true;
            this.cboCOD3.Value = "";
            this.cboCOD3.ValueMember = "";
            // 
            // listCOD3
            // 
            this.listCOD3.Add = false;
            this.listCOD3.Caption = "COD3";
            this.listCOD3.CheckOnClick = true;
            this.listCOD3.ColumnWidth = 165;
            this.listCOD3.DataSource = null;
            this.listCOD3.DBField = null;
            this.listCOD3.DBFieldType = null;
            this.listCOD3.DefaultValue = null;
            this.listCOD3.Del = false;
            this.listCOD3.DependingRS = null;
            this.listCOD3.DisplayMember = "";
            this.listCOD3.ExtraDataLink = null;
            this.listCOD3.ForeColor = System.Drawing.Color.Black;
            this.listCOD3.FormattingEnabled = true;
            this.listCOD3.IsCTLMOwned = false;
            this.listCOD3.Location = new System.Drawing.Point(23, 80);
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
            this.listCOD3.Size = new System.Drawing.Size(482, 130);
            this.listCOD3.Status = CommonTools.EnumStatus.ADDNEW;
            this.listCOD3.TabIndex = 7;
            this.listCOD3.TBDescription = null;
            this.listCOD3.Upp = false;
            this.listCOD3.Value = "";
            this.listCOD3.ValueMember = "";
            // 
            // cboPosition
            // 
            this.cboPosition.Add = false;
            this.cboPosition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPosition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPosition.Caption = "Position";
            this.cboPosition.DataSource = null;
            this.cboPosition.DBField = null;
            this.cboPosition.DBFieldType = null;
            this.cboPosition.DefaultValue = null;
            this.cboPosition.Del = false;
            this.cboPosition.DependingRS = null;
            this.cboPosition.DisplayMember = "";
            this.cboPosition.ExtraDataLink = null;
            this.cboPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPosition.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboPosition.ForeColor = System.Drawing.Color.Black;
            this.cboPosition.FormattingEnabled = true;
            this.cboPosition.IsCTLMOwned = false;
            this.cboPosition.Location = new System.Drawing.Point(23, 232);
            this.cboPosition.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Order = 0;
            this.cboPosition.ParentConn = null;
            this.cboPosition.ParentDA = null;
            this.cboPosition.PK = false;
            this.cboPosition.Protected = false;
            this.cboPosition.ReadOnly = false;
            this.cboPosition.Search = false;
            this.cboPosition.SelectedItem = null;
            this.cboPosition.SelectedValue = null;
            this.cboPosition.Size = new System.Drawing.Size(154, 40);
            this.cboPosition.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboPosition.TabIndex = 8;
            this.cboPosition.TBDescription = null;
            this.cboPosition.Upp = false;
            this.cboPosition.Value = "";
            this.cboPosition.ValueMember = "";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtTicketExp);
            this.groupBox3.Controls.Add(this.txtTicket);
            this.groupBox3.Controls.Add(this.txtEmail);
            this.groupBox3.Controls.Add(this.txtPIN);
            this.groupBox3.Controls.Add(this.txtQuota);
            this.groupBox3.Controls.Add(this.cboDomain);
            this.groupBox3.Controls.Add(this.txtPasswordEXP);
            this.groupBox3.Controls.Add(this.lstFlags);
            this.groupBox3.Controls.Add(this.txtPWD);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(16, 493);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(528, 296);
            this.groupBox3.TabIndex = 153;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Systems data";
            // 
            // txtTicketExp
            // 
            this.txtTicketExp.Add = false;
            this.txtTicketExp.BorderColor = System.Drawing.Color.White;
            this.txtTicketExp.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.txtTicketExp.Caption = "Ticket Expiration";
            this.txtTicketExp.Checked = false;
            this.txtTicketExp.CustomFormat = " ";
            this.txtTicketExp.DBField = null;
            this.txtTicketExp.DBFieldType = null;
            this.txtTicketExp.DefaultValue = null;
            this.txtTicketExp.Del = false;
            this.txtTicketExp.DependingRS = null;
            this.txtTicketExp.ExtraDataLink = null;
            this.txtTicketExp.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTicketExp.ForeColor = System.Drawing.Color.Black;
            this.txtTicketExp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtTicketExp.IsCTLMOwned = false;
            this.txtTicketExp.Location = new System.Drawing.Point(188, 254);
            this.txtTicketExp.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtTicketExp.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtTicketExp.Name = "txtTicketExp";
            this.txtTicketExp.Nullable = false;
            this.txtTicketExp.Order = 0;
            this.txtTicketExp.ParentConn = null;
            this.txtTicketExp.ParentDA = null;
            this.txtTicketExp.PK = false;
            this.txtTicketExp.Protected = false;
            this.txtTicketExp.ReadOnly = false;
            this.txtTicketExp.Search = false;
            this.txtTicketExp.ShowCheckBox = false;
            this.txtTicketExp.Size = new System.Drawing.Size(154, 39);
            this.txtTicketExp.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtTicketExp.TabIndex = 32;
            this.txtTicketExp.Text = " ";
            this.txtTicketExp.Upp = false;
            this.txtTicketExp.Value = null;
            // 
            // txtTicket
            // 
            this.txtTicket.Add = false;
            this.txtTicket.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTicket.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTicket.Caption = "Ticket";
            this.txtTicket.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTicket.DBField = null;
            this.txtTicket.DBFieldType = null;
            this.txtTicket.DefaultValue = null;
            this.txtTicket.Del = false;
            this.txtTicket.DependingRS = null;
            this.txtTicket.ExtraDataLink = null;
            this.txtTicket.ForeColor = System.Drawing.Color.Gray;
            this.txtTicket.IsCTLMOwned = false;
            this.txtTicket.Location = new System.Drawing.Point(23, 254);
            this.txtTicket.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtTicket.Multiline = true;
            this.txtTicket.Name = "txtTicket";
            this.txtTicket.Order = 0;
            this.txtTicket.ParentConn = null;
            this.txtTicket.ParentDA = null;
            
            this.txtTicket.PK = false;
            this.txtTicket.Protected = false;
            this.txtTicket.ReadOnly = true;
            this.txtTicket.Search = false;
            this.txtTicket.Size = new System.Drawing.Size(154, 38);
            this.txtTicket.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtTicket.TabIndex = 23;
            this.txtTicket.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTicket.Upp = false;
            
            this.txtTicket.Value = "";
            // 
            // txtEmail
            // 
            this.txtEmail.Add = false;
            this.txtEmail.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtEmail.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtEmail.Caption = "Email Address";
            this.txtEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEmail.DBField = null;
            this.txtEmail.DBFieldType = null;
            this.txtEmail.DefaultValue = null;
            this.txtEmail.Del = false;
            this.txtEmail.DependingRS = null;
            this.txtEmail.ExtraDataLink = null;
            this.txtEmail.ForeColor = System.Drawing.Color.Gray;
            this.txtEmail.IsCTLMOwned = false;
            this.txtEmail.Location = new System.Drawing.Point(183, 72);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtEmail.Multiline = true;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Order = 0;
            this.txtEmail.ParentConn = null;
            this.txtEmail.ParentDA = null;
            
            this.txtEmail.PK = false;
            this.txtEmail.Protected = false;
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Search = false;
            this.txtEmail.Size = new System.Drawing.Size(322, 38);
            this.txtEmail.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtEmail.TabIndex = 12;
            this.txtEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmail.Upp = false;
            
            this.txtEmail.Value = "";
            // 
            // txtPIN
            // 
            this.txtPIN.Add = false;
            this.txtPIN.AllowSpace = false;
            this.txtPIN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPIN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPIN.Caption = "PIN";
            this.txtPIN.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPIN.DBField = null;
            this.txtPIN.DBFieldType = null;
            this.txtPIN.DefaultValue = null;
            this.txtPIN.Del = false;
            this.txtPIN.DependingRS = null;
            this.txtPIN.ExtraDataLink = null;
            this.txtPIN.ForeColor = System.Drawing.Color.Gray;
            this.txtPIN.IsCTLMOwned = false;
            this.txtPIN.Length = 0;
            this.txtPIN.Location = new System.Drawing.Point(343, 32);
            this.txtPIN.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtPIN.Mask = false;
            this.txtPIN.Multiline = true;
            this.txtPIN.Name = "txtPIN";
            this.txtPIN.Order = 0;
            this.txtPIN.ParentConn = null;
            this.txtPIN.ParentDA = null;
            
            this.txtPIN.PK = false;
            this.txtPIN.Precision = 0;
            this.txtPIN.Protected = false;
            this.txtPIN.ReadOnly = true;
            this.txtPIN.Search = false;
            this.txtPIN.Size = new System.Drawing.Size(51, 38);
            this.txtPIN.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPIN.TabIndex = 10;
            this.txtPIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPIN.ThousandsGroup = false;
            this.txtPIN.Upp = false;
            
            this.txtPIN.Value = null;
            // 
            // txtQuota
            // 
            this.txtQuota.Add = false;
            this.txtQuota.AllowSpace = false;
            this.txtQuota.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtQuota.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtQuota.Caption = "Email Quota";
            this.txtQuota.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtQuota.DBField = null;
            this.txtQuota.DBFieldType = null;
            this.txtQuota.DefaultValue = null;
            this.txtQuota.Del = false;
            this.txtQuota.DependingRS = null;
            this.txtQuota.ExtraDataLink = null;
            this.txtQuota.ForeColor = System.Drawing.Color.Gray;
            this.txtQuota.IsCTLMOwned = false;
            this.txtQuota.Length = 0;
            this.txtQuota.Location = new System.Drawing.Point(400, 32);
            this.txtQuota.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtQuota.Mask = false;
            this.txtQuota.Multiline = true;
            this.txtQuota.Name = "txtQuota";
            this.txtQuota.Order = 0;
            this.txtQuota.ParentConn = null;
            this.txtQuota.ParentDA = null;
            
            this.txtQuota.PK = false;
            this.txtQuota.Precision = 0;
            this.txtQuota.Protected = false;
            this.txtQuota.ReadOnly = true;
            this.txtQuota.Search = false;
            this.txtQuota.Size = new System.Drawing.Size(105, 38);
            this.txtQuota.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtQuota.TabIndex = 13;
            this.txtQuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQuota.ThousandsGroup = false;
            this.txtQuota.Upp = false;
            
            this.txtQuota.Value = null;
            // 
            // cboDomain
            // 
            this.cboDomain.Add = false;
            this.cboDomain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDomain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDomain.Caption = "Domain";
            this.cboDomain.DataSource = null;
            this.cboDomain.DBField = null;
            this.cboDomain.DBFieldType = null;
            this.cboDomain.DefaultValue = null;
            this.cboDomain.Del = false;
            this.cboDomain.DependingRS = null;
            this.cboDomain.DisplayMember = "";
            this.cboDomain.ExtraDataLink = null;
            this.cboDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDomain.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboDomain.ForeColor = System.Drawing.Color.Black;
            this.cboDomain.FormattingEnabled = true;
            this.cboDomain.IsCTLMOwned = false;
            this.cboDomain.Location = new System.Drawing.Point(23, 72);
            this.cboDomain.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboDomain.Name = "cboDomain";
            this.cboDomain.Order = 0;
            this.cboDomain.ParentConn = null;
            this.cboDomain.ParentDA = null;
            this.cboDomain.PK = false;
            this.cboDomain.Protected = false;
            this.cboDomain.ReadOnly = false;
            this.cboDomain.Search = false;
            this.cboDomain.SelectedItem = null;
            this.cboDomain.SelectedValue = null;
            this.cboDomain.Size = new System.Drawing.Size(154, 40);
            this.cboDomain.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboDomain.TabIndex = 11;
            this.cboDomain.TBDescription = null;
            this.cboDomain.Upp = false;
            this.cboDomain.Value = "";
            this.cboDomain.ValueMember = "";
            // 
            // txtPasswordEXP
            // 
            this.txtPasswordEXP.Add = false;
            this.txtPasswordEXP.BorderColor = System.Drawing.Color.White;
            this.txtPasswordEXP.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.txtPasswordEXP.Caption = "Password Expiration";
            this.txtPasswordEXP.Checked = false;
            this.txtPasswordEXP.CustomFormat = " ";
            this.txtPasswordEXP.DBField = null;
            this.txtPasswordEXP.DBFieldType = null;
            this.txtPasswordEXP.DefaultValue = null;
            this.txtPasswordEXP.Del = false;
            this.txtPasswordEXP.DependingRS = null;
            this.txtPasswordEXP.ExtraDataLink = null;
            this.txtPasswordEXP.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPasswordEXP.ForeColor = System.Drawing.Color.Black;
            this.txtPasswordEXP.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtPasswordEXP.IsCTLMOwned = false;
            this.txtPasswordEXP.Location = new System.Drawing.Point(183, 31);
            this.txtPasswordEXP.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtPasswordEXP.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtPasswordEXP.Name = "txtPasswordEXP";
            this.txtPasswordEXP.Nullable = true;
            this.txtPasswordEXP.Order = 0;
            this.txtPasswordEXP.ParentConn = null;
            this.txtPasswordEXP.ParentDA = null;
            this.txtPasswordEXP.PK = false;
            this.txtPasswordEXP.Protected = false;
            this.txtPasswordEXP.ReadOnly = false;
            this.txtPasswordEXP.Search = false;
            this.txtPasswordEXP.ShowCheckBox = true;
            this.txtPasswordEXP.Size = new System.Drawing.Size(154, 39);
            this.txtPasswordEXP.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPasswordEXP.TabIndex = 19;
            this.txtPasswordEXP.Text = " ";
            this.txtPasswordEXP.Upp = false;
            this.txtPasswordEXP.Value = null;
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
            this.lstFlags.ForeColor = System.Drawing.Color.Black;
            this.lstFlags.FormattingEnabled = true;
            this.lstFlags.IsCTLMOwned = false;
            this.lstFlags.Location = new System.Drawing.Point(23, 120);
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
            this.lstFlags.Size = new System.Drawing.Size(482, 111);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 14;
            this.lstFlags.TBDescription = null;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            this.lstFlags.ValueMember = "";
            // 
            // txtPWD
            // 
            this.txtPWD.Add = false;
            this.txtPWD.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPWD.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPWD.Caption = "Password";
            this.txtPWD.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPWD.DBField = null;
            this.txtPWD.DBFieldType = null;
            this.txtPWD.DefaultValue = null;
            this.txtPWD.Del = false;
            this.txtPWD.DependingRS = null;
            this.txtPWD.ExtraDataLink = null;
            this.txtPWD.ForeColor = System.Drawing.Color.Gray;
            this.txtPWD.IsCTLMOwned = false;
            this.txtPWD.Location = new System.Drawing.Point(23, 32);
            this.txtPWD.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.txtPWD.Multiline = true;
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.Order = 0;
            this.txtPWD.ParentConn = null;
            this.txtPWD.ParentDA = null;
            
            this.txtPWD.PK = false;
            this.txtPWD.Protected = false;
            this.txtPWD.ReadOnly = true;
            this.txtPWD.Search = false;
            this.txtPWD.Size = new System.Drawing.Size(154, 38);
            this.txtPWD.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPWD.TabIndex = 9;
            this.txtPWD.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPWD.Upp = false;
            
            this.txtPWD.Value = "";
            // 
            // lstEmailAliases
            // 
            this.lstEmailAliases.Add = false;
            this.lstEmailAliases.Caption = "";
            this.lstEmailAliases.CheckOnClick = true;
            this.lstEmailAliases.ColumnWidth = 0;
            this.lstEmailAliases.DataSource = null;
            this.lstEmailAliases.DBField = null;
            this.lstEmailAliases.DBFieldType = null;
            this.lstEmailAliases.DefaultValue = null;
            this.lstEmailAliases.Del = false;
            this.lstEmailAliases.DependingRS = null;
            this.lstEmailAliases.DisplayMember = "";
            this.lstEmailAliases.ExtraDataLink = null;
            this.lstEmailAliases.ForeColor = System.Drawing.Color.Black;
            this.lstEmailAliases.FormattingEnabled = true;
            this.lstEmailAliases.IsCTLMOwned = false;
            this.lstEmailAliases.Location = new System.Drawing.Point(550, 48);
            this.lstEmailAliases.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstEmailAliases.MultiColumn = false;
            this.lstEmailAliases.Name = "lstEmailAliases";
            this.lstEmailAliases.Order = 0;
            this.lstEmailAliases.ParentConn = null;
            this.lstEmailAliases.ParentDA = null;
            this.lstEmailAliases.PK = false;
            this.lstEmailAliases.Protected = false;
            this.lstEmailAliases.ReadOnly = false;
            this.lstEmailAliases.Search = false;
            this.lstEmailAliases.SelectedItem = null;
            this.lstEmailAliases.SelectedValue = null;
            this.lstEmailAliases.Size = new System.Drawing.Size(292, 741);
            this.lstEmailAliases.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstEmailAliases.TabIndex = 15;
            this.lstEmailAliases.TBDescription = null;
            this.lstEmailAliases.Upp = false;
            this.lstEmailAliases.Value = "";
            this.lstEmailAliases.ValueMember = "";
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
            // fUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1264, 839);
            this.Controls.Add(this.lstEmailAliases);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CTLM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "fUsers";
            this.ShowIcon = false;
            this.Text = "Users";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private System.Windows.Forms.GroupBox groupBox1;
        private EspackFormControlsNS.EspackTextBox txtName;
        private EspackFormControlsNS.EspackTextBox txtUserCode;
        private System.Windows.Forms.GroupBox groupBox2;
        private EspackFormControlsNS.EspackTextBox txtDesCod3;
        private EspackFormControlsNS.EspackComboBox cboCOD3;
        private EspackFormControlsNS.EspackCheckedListBox listCOD3;
        private EspackFormControlsNS.EspackComboBox cboPosition;
        private System.Windows.Forms.GroupBox groupBox3;
        private EspackFormControlsNS.EspackCheckedListBox lstFlags;
        private EspackFormControlsNS.EspackTextBox txtPWD;
        private EspackFormControlsNS.EspackTextBox txtSurname2;
        private EspackFormControlsNS.EspackTextBox txtSurname1;
        private EspackFormControlsNS.EspackDateTimePicker txtPasswordEXP;
        private EspackFormControlsNS.EspackNumericTextBox txtUserNumber;
        private EspackFormControlsNS.EspackNumericTextBox txtPIN;
        private EspackFormControlsNS.EspackNumericTextBox txtQuota;
        private EspackFormControlsNS.EspackComboBox cboDomain;
        private EspackFormControlsNS.EspackTextBox txtEmail;
        private EspackFormControlsNS.EspackCheckedListBox lstEmailAliases;
        private EspackFormControlsNS.EspackComboBox cboSecurityLevel;
        private EspackFormControlsNS.EspackTextBox txtPosition;
        private EspackFormControlsNS.EspackComboBox cboPositionLevel;
        private EspackFormControlsNS.EspackComboBox cboArea;
        private EspackFormControlsNS.EspackTextBox txtTicket;
        private EspackFormControlsNS.EspackDateTimePicker txtTicketExp;
    }
}