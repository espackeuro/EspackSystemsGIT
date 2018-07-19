namespace Sistemas
{
    partial class fTasks
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
            this.cboMatterDef = new EspackFormControlsNS.EspackComboBox();
            this.cboServiceDef = new EspackFormControlsNS.EspackComboBox();
            this.cboPlaceAffectedDef = new EspackFormControlsNS.EspackComboBox();
            this.cboPlaceAdviseDef = new EspackFormControlsNS.EspackComboBox();
            this.CalDateDef = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.txtIT = new EspackFormControlsNS.EspackTextBox();
            this.chkFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtNotes = new EspackFormControlsNS.EspackTextBox();
            this.txtKm = new EspackFormControlsNS.EspackNumericTextBox();
            this.dateEnd = new EspackFormControlsNS.EspackDateTimePicker();
            this.dateStart = new EspackFormControlsNS.EspackDateTimePicker();
            this.cboMatter = new EspackFormControlsNS.EspackComboBox();
            this.cboService = new EspackFormControlsNS.EspackComboBox();
            this.txtPlaceAffected = new EspackFormControlsNS.EspackTextBox();
            this.cboPlaceAffected = new EspackFormControlsNS.EspackComboBox();
            this.txtPlaceAdvise = new EspackFormControlsNS.EspackTextBox();
            this.cboPlaceAdvise = new EspackFormControlsNS.EspackComboBox();
            this.txtPerson = new EspackFormControlsNS.EspackTextBox();
            this.txtIdTarea = new EspackFormControlsNS.EspackTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboMatterDef);
            this.groupBox1.Controls.Add(this.cboServiceDef);
            this.groupBox1.Controls.Add(this.cboPlaceAffectedDef);
            this.groupBox1.Controls.Add(this.cboPlaceAdviseDef);
            this.groupBox1.Controls.Add(this.CalDateDef);
            this.groupBox1.Location = new System.Drawing.Point(13, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(387, 207);
            this.groupBox1.TabIndex = 112;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Defaults";
            // 
            // cboMatterDef
            // 
            this.cboMatterDef.Add = true;
            this.cboMatterDef.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMatterDef.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMatterDef.Caption = "Matter";
            this.cboMatterDef.DataSource = null;
            this.cboMatterDef.DBField = null;
            this.cboMatterDef.DBFieldType = null;
            this.cboMatterDef.DefaultValue = null;
            this.cboMatterDef.Del = false;
            this.cboMatterDef.DependingRS = null;
            this.cboMatterDef.DisplayMember = "";
            this.cboMatterDef.ExtraDataLink = null;
            this.cboMatterDef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMatterDef.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboMatterDef.ForeColor = System.Drawing.Color.Black;
            this.cboMatterDef.FormattingEnabled = true;
            this.cboMatterDef.IsCTLMOwned = false;
            this.cboMatterDef.Location = new System.Drawing.Point(216, 157);
            this.cboMatterDef.Margin = new System.Windows.Forms.Padding(3, 163, 3, 3);
            this.cboMatterDef.Name = "cboMatterDef";
            this.cboMatterDef.Order = 0;
            this.cboMatterDef.ParentConn = null;
            this.cboMatterDef.ParentDA = null;
            this.cboMatterDef.PK = false;
            this.cboMatterDef.Protected = false;
            this.cboMatterDef.ReadOnly = false;
            this.cboMatterDef.Search = false;
            this.cboMatterDef.SelectedItem = null;
            this.cboMatterDef.SelectedValue = null;
            this.cboMatterDef.Size = new System.Drawing.Size(130, 40);
            this.cboMatterDef.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboMatterDef.TabIndex = 120;
            this.cboMatterDef.TBDescription = null;
            this.cboMatterDef.Upp = false;
            this.cboMatterDef.Value = "";
            this.cboMatterDef.ValueMember = "";
            // 
            // cboServiceDef
            // 
            this.cboServiceDef.Add = true;
            this.cboServiceDef.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboServiceDef.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboServiceDef.Caption = "Service";
            this.cboServiceDef.DataSource = null;
            this.cboServiceDef.DBField = null;
            this.cboServiceDef.DBFieldType = null;
            this.cboServiceDef.DefaultValue = null;
            this.cboServiceDef.Del = false;
            this.cboServiceDef.DependingRS = null;
            this.cboServiceDef.DisplayMember = "";
            this.cboServiceDef.ExtraDataLink = null;
            this.cboServiceDef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboServiceDef.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboServiceDef.ForeColor = System.Drawing.Color.Black;
            this.cboServiceDef.FormattingEnabled = true;
            this.cboServiceDef.IsCTLMOwned = false;
            this.cboServiceDef.Location = new System.Drawing.Point(216, 116);
            this.cboServiceDef.Margin = new System.Windows.Forms.Padding(3, 163, 3, 3);
            this.cboServiceDef.Name = "cboServiceDef";
            this.cboServiceDef.Order = 0;
            this.cboServiceDef.ParentConn = null;
            this.cboServiceDef.ParentDA = null;
            this.cboServiceDef.PK = false;
            this.cboServiceDef.Protected = false;
            this.cboServiceDef.ReadOnly = false;
            this.cboServiceDef.Search = false;
            this.cboServiceDef.SelectedItem = null;
            this.cboServiceDef.SelectedValue = null;
            this.cboServiceDef.Size = new System.Drawing.Size(130, 40);
            this.cboServiceDef.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboServiceDef.TabIndex = 119;
            this.cboServiceDef.TBDescription = null;
            this.cboServiceDef.Upp = false;
            this.cboServiceDef.Value = "";
            this.cboServiceDef.ValueMember = "";
            // 
            // cboPlaceAffectedDef
            // 
            this.cboPlaceAffectedDef.Add = true;
            this.cboPlaceAffectedDef.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPlaceAffectedDef.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlaceAffectedDef.Caption = "Place Affected";
            this.cboPlaceAffectedDef.DataSource = null;
            this.cboPlaceAffectedDef.DBField = null;
            this.cboPlaceAffectedDef.DBFieldType = null;
            this.cboPlaceAffectedDef.DefaultValue = null;
            this.cboPlaceAffectedDef.Del = false;
            this.cboPlaceAffectedDef.DependingRS = null;
            this.cboPlaceAffectedDef.DisplayMember = "";
            this.cboPlaceAffectedDef.ExtraDataLink = null;
            this.cboPlaceAffectedDef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPlaceAffectedDef.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboPlaceAffectedDef.ForeColor = System.Drawing.Color.Black;
            this.cboPlaceAffectedDef.FormattingEnabled = true;
            this.cboPlaceAffectedDef.IsCTLMOwned = false;
            this.cboPlaceAffectedDef.Location = new System.Drawing.Point(216, 75);
            this.cboPlaceAffectedDef.Margin = new System.Windows.Forms.Padding(3, 163, 3, 3);
            this.cboPlaceAffectedDef.Name = "cboPlaceAffectedDef";
            this.cboPlaceAffectedDef.Order = 0;
            this.cboPlaceAffectedDef.ParentConn = null;
            this.cboPlaceAffectedDef.ParentDA = null;
            this.cboPlaceAffectedDef.PK = false;
            this.cboPlaceAffectedDef.Protected = false;
            this.cboPlaceAffectedDef.ReadOnly = false;
            this.cboPlaceAffectedDef.Search = false;
            this.cboPlaceAffectedDef.SelectedItem = null;
            this.cboPlaceAffectedDef.SelectedValue = null;
            this.cboPlaceAffectedDef.Size = new System.Drawing.Size(130, 40);
            this.cboPlaceAffectedDef.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboPlaceAffectedDef.TabIndex = 116;
            this.cboPlaceAffectedDef.TBDescription = null;
            this.cboPlaceAffectedDef.Upp = false;
            this.cboPlaceAffectedDef.Value = "";
            this.cboPlaceAffectedDef.ValueMember = "";
            // 
            // cboPlaceAdviseDef
            // 
            this.cboPlaceAdviseDef.Add = true;
            this.cboPlaceAdviseDef.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPlaceAdviseDef.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlaceAdviseDef.Caption = "Place Advise";
            this.cboPlaceAdviseDef.DataSource = null;
            this.cboPlaceAdviseDef.DBField = null;
            this.cboPlaceAdviseDef.DBFieldType = null;
            this.cboPlaceAdviseDef.DefaultValue = null;
            this.cboPlaceAdviseDef.Del = false;
            this.cboPlaceAdviseDef.DependingRS = null;
            this.cboPlaceAdviseDef.DisplayMember = "";
            this.cboPlaceAdviseDef.ExtraDataLink = null;
            this.cboPlaceAdviseDef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPlaceAdviseDef.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboPlaceAdviseDef.ForeColor = System.Drawing.Color.Black;
            this.cboPlaceAdviseDef.FormattingEnabled = true;
            this.cboPlaceAdviseDef.IsCTLMOwned = false;
            this.cboPlaceAdviseDef.Location = new System.Drawing.Point(216, 38);
            this.cboPlaceAdviseDef.Margin = new System.Windows.Forms.Padding(3, 163, 3, 3);
            this.cboPlaceAdviseDef.Name = "cboPlaceAdviseDef";
            this.cboPlaceAdviseDef.Order = 0;
            this.cboPlaceAdviseDef.ParentConn = null;
            this.cboPlaceAdviseDef.ParentDA = null;
            this.cboPlaceAdviseDef.PK = false;
            this.cboPlaceAdviseDef.Protected = false;
            this.cboPlaceAdviseDef.ReadOnly = false;
            this.cboPlaceAdviseDef.Search = false;
            this.cboPlaceAdviseDef.SelectedItem = null;
            this.cboPlaceAdviseDef.SelectedValue = null;
            this.cboPlaceAdviseDef.Size = new System.Drawing.Size(130, 40);
            this.cboPlaceAdviseDef.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboPlaceAdviseDef.TabIndex = 115;
            this.cboPlaceAdviseDef.TBDescription = null;
            this.cboPlaceAdviseDef.Upp = false;
            this.cboPlaceAdviseDef.Value = "";
            this.cboPlaceAdviseDef.ValueMember = "";
            // 
            // CalDateDef
            // 
            this.CalDateDef.Location = new System.Drawing.Point(12, 25);
            this.CalDateDef.Name = "CalDateDef";
            this.CalDateDef.TabIndex = 112;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(954, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 115;
            this.label1.Text = "IT:";
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
            // txtIT
            // 
            this.txtIT.Add = false;
            this.txtIT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtIT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtIT.Caption = "";
            this.txtIT.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtIT.DBField = null;
            this.txtIT.DBFieldType = null;
            this.txtIT.DefaultValue = null;
            this.txtIT.Del = false;
            this.txtIT.DependingRS = null;
            this.txtIT.ExtraDataLink = null;
            this.txtIT.ForeColor = System.Drawing.Color.Gray;
            this.txtIT.IsCTLMOwned = false;
            this.txtIT.Location = new System.Drawing.Point(980, 13);
            this.txtIT.Margin = new System.Windows.Forms.Padding(3, 46, 3, 3);
            this.txtIT.Multiline = true;
            this.txtIT.Name = "txtIT";
            this.txtIT.Order = 0;
            this.txtIT.ParentConn = null;
            this.txtIT.ParentDA = null;
            
            this.txtIT.PK = false;
            this.txtIT.Protected = false;
            this.txtIT.ReadOnly = true;
            this.txtIT.Search = false;
            this.txtIT.Size = new System.Drawing.Size(100, 30);
            this.txtIT.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtIT.TabIndex = 113;
            this.txtIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIT.Upp = false;
            
            this.txtIT.Value = "";
            // 
            // chkFlags
            // 
            this.chkFlags.Add = false;
            this.chkFlags.Caption = "Flags";
            this.chkFlags.CheckOnClick = true;
            this.chkFlags.ColumnWidth = 0;
            this.chkFlags.DataSource = null;
            this.chkFlags.DBField = null;
            this.chkFlags.DBFieldType = null;
            this.chkFlags.DefaultValue = null;
            this.chkFlags.Del = false;
            this.chkFlags.DependingRS = null;
            this.chkFlags.DisplayMember = "";
            this.chkFlags.ExtraDataLink = null;
            this.chkFlags.ForeColor = System.Drawing.Color.Black;
            this.chkFlags.FormattingEnabled = true;
            this.chkFlags.IsCTLMOwned = false;
            this.chkFlags.Location = new System.Drawing.Point(839, 192);
            this.chkFlags.Margin = new System.Windows.Forms.Padding(3, 136, 3, 3);
            this.chkFlags.MultiColumn = false;
            this.chkFlags.Name = "chkFlags";
            this.chkFlags.Order = 0;
            this.chkFlags.ParentConn = null;
            this.chkFlags.ParentDA = null;
            this.chkFlags.PK = false;
            this.chkFlags.Protected = false;
            this.chkFlags.ReadOnly = false;
            this.chkFlags.Search = false;
            this.chkFlags.SelectedItem = null;
            this.chkFlags.SelectedValue = null;
            this.chkFlags.Size = new System.Drawing.Size(241, 73);
            this.chkFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.chkFlags.TabIndex = 109;
            this.chkFlags.TBDescription = null;
            this.chkFlags.Upp = false;
            this.chkFlags.Value = "";
            this.chkFlags.ValueMember = "";
            // 
            // txtNotes
            // 
            this.txtNotes.Add = false;
            this.txtNotes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtNotes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtNotes.Caption = "Notes";
            this.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNotes.DBField = null;
            this.txtNotes.DBFieldType = null;
            this.txtNotes.DefaultValue = null;
            this.txtNotes.Del = false;
            this.txtNotes.DependingRS = null;
            this.txtNotes.ExtraDataLink = null;
            this.txtNotes.ForeColor = System.Drawing.Color.Gray;
            this.txtNotes.IsCTLMOwned = false;
            this.txtNotes.Location = new System.Drawing.Point(839, 146);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 46, 3, 3);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Order = 0;
            this.txtNotes.ParentConn = null;
            this.txtNotes.ParentDA = null;
            
            this.txtNotes.PK = false;
            this.txtNotes.Protected = false;
            this.txtNotes.ReadOnly = true;
            this.txtNotes.Search = false;
            this.txtNotes.Size = new System.Drawing.Size(241, 38);
            this.txtNotes.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtNotes.TabIndex = 107;
            this.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNotes.Upp = false;
            
            this.txtNotes.Value = "";
            // 
            // txtKm
            // 
            this.txtKm.Add = false;
            this.txtKm.AllowSpace = false;
            this.txtKm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtKm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtKm.Caption = "Km";
            this.txtKm.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtKm.DBField = null;
            this.txtKm.DBFieldType = null;
            this.txtKm.DefaultValue = null;
            this.txtKm.Del = false;
            this.txtKm.DependingRS = null;
            this.txtKm.ExtraDataLink = null;
            this.txtKm.ForeColor = System.Drawing.Color.Gray;
            this.txtKm.IsCTLMOwned = false;
            this.txtKm.Length = 0;
            this.txtKm.Location = new System.Drawing.Point(839, 108);
            this.txtKm.Margin = new System.Windows.Forms.Padding(3, 46, 3, 3);
            this.txtKm.Mask = false;
            this.txtKm.Multiline = true;
            this.txtKm.Name = "txtKm";
            this.txtKm.Order = 0;
            this.txtKm.ParentConn = null;
            this.txtKm.ParentDA = null;
            
            this.txtKm.PK = false;
            this.txtKm.Precision = 0;
            this.txtKm.Protected = false;
            this.txtKm.ReadOnly = true;
            this.txtKm.Search = false;
            this.txtKm.Size = new System.Drawing.Size(241, 38);
            this.txtKm.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtKm.TabIndex = 105;
            this.txtKm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKm.ThousandsGroup = false;
            this.txtKm.Upp = false;
            
            this.txtKm.Value = null;
            // 
            // dateEnd
            // 
            this.dateEnd.Add = false;
            this.dateEnd.BorderColor = System.Drawing.Color.Black;
            this.dateEnd.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.dateEnd.Caption = "End Date";
            this.dateEnd.Checked = true;
            this.dateEnd.CustomFormat = "dd/MM/yyyy H:mm";
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
            this.dateEnd.Location = new System.Drawing.Point(688, 226);
            this.dateEnd.Margin = new System.Windows.Forms.Padding(3, 136, 3, 3);
            this.dateEnd.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Nullable = false;
            this.dateEnd.Order = 0;
            this.dateEnd.ParentConn = null;
            this.dateEnd.ParentDA = null;
            this.dateEnd.PK = false;
            this.dateEnd.Protected = false;
            this.dateEnd.ReadOnly = false;
            this.dateEnd.Search = false;
            this.dateEnd.ShowCheckBox = false;
            this.dateEnd.Size = new System.Drawing.Size(130, 39);
            this.dateEnd.Status = CommonTools.EnumStatus.ADDNEW;
            this.dateEnd.TabIndex = 94;
            this.dateEnd.Text = "15/12/2015 15:19";
            this.dateEnd.Upp = false;
            this.dateEnd.Value = new System.DateTime(2015, 12, 15, 15, 19, 34, 571);
            // 
            // dateStart
            // 
            this.dateStart.Add = false;
            this.dateStart.BorderColor = System.Drawing.Color.Black;
            this.dateStart.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.dateStart.Caption = "Start Date";
            this.dateStart.Checked = true;
            this.dateStart.CustomFormat = "dd/MM/yyyy H:mm";
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
            this.dateStart.Location = new System.Drawing.Point(688, 186);
            this.dateStart.Margin = new System.Windows.Forms.Padding(3, 136, 3, 3);
            this.dateStart.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateStart.Name = "dateStart";
            this.dateStart.Nullable = false;
            this.dateStart.Order = 0;
            this.dateStart.ParentConn = null;
            this.dateStart.ParentDA = null;
            this.dateStart.PK = false;
            this.dateStart.Protected = false;
            this.dateStart.ReadOnly = false;
            this.dateStart.Search = false;
            this.dateStart.ShowCheckBox = false;
            this.dateStart.Size = new System.Drawing.Size(130, 39);
            this.dateStart.Status = CommonTools.EnumStatus.ADDNEW;
            this.dateStart.TabIndex = 92;
            this.dateStart.Text = "15/12/2015 15:19";
            this.dateStart.Upp = false;
            this.dateStart.Value = new System.DateTime(2015, 12, 15, 15, 19, 8, 165);
            // 
            // cboMatter
            // 
            this.cboMatter.Add = false;
            this.cboMatter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMatter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMatter.Caption = "Matter";
            this.cboMatter.DataSource = null;
            this.cboMatter.DBField = null;
            this.cboMatter.DBFieldType = null;
            this.cboMatter.DefaultValue = null;
            this.cboMatter.Del = false;
            this.cboMatter.DependingRS = null;
            this.cboMatter.DisplayMember = "";
            this.cboMatter.ExtraDataLink = null;
            this.cboMatter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMatter.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboMatter.ForeColor = System.Drawing.Color.Black;
            this.cboMatter.FormattingEnabled = true;
            this.cboMatter.IsCTLMOwned = false;
            this.cboMatter.Location = new System.Drawing.Point(688, 145);
            this.cboMatter.Margin = new System.Windows.Forms.Padding(3, 136, 3, 3);
            this.cboMatter.Name = "cboMatter";
            this.cboMatter.Order = 0;
            this.cboMatter.ParentConn = null;
            this.cboMatter.ParentDA = null;
            this.cboMatter.PK = false;
            this.cboMatter.Protected = false;
            this.cboMatter.ReadOnly = false;
            this.cboMatter.Search = false;
            this.cboMatter.SelectedItem = null;
            this.cboMatter.SelectedValue = null;
            this.cboMatter.Size = new System.Drawing.Size(130, 40);
            this.cboMatter.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboMatter.TabIndex = 90;
            this.cboMatter.TBDescription = null;
            this.cboMatter.Upp = false;
            this.cboMatter.Value = "";
            this.cboMatter.ValueMember = "";
            // 
            // cboService
            // 
            this.cboService.Add = false;
            this.cboService.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboService.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboService.Caption = "Service";
            this.cboService.DataSource = null;
            this.cboService.DBField = null;
            this.cboService.DBFieldType = null;
            this.cboService.DefaultValue = null;
            this.cboService.Del = false;
            this.cboService.DependingRS = null;
            this.cboService.DisplayMember = "";
            this.cboService.ExtraDataLink = null;
            this.cboService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboService.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboService.ForeColor = System.Drawing.Color.Black;
            this.cboService.FormattingEnabled = true;
            this.cboService.IsCTLMOwned = false;
            this.cboService.Location = new System.Drawing.Point(688, 107);
            this.cboService.Margin = new System.Windows.Forms.Padding(3, 136, 3, 3);
            this.cboService.Name = "cboService";
            this.cboService.Order = 0;
            this.cboService.ParentConn = null;
            this.cboService.ParentDA = null;
            this.cboService.PK = false;
            this.cboService.Protected = false;
            this.cboService.ReadOnly = false;
            this.cboService.Search = false;
            this.cboService.SelectedItem = null;
            this.cboService.SelectedValue = null;
            this.cboService.Size = new System.Drawing.Size(130, 40);
            this.cboService.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboService.TabIndex = 88;
            this.cboService.TBDescription = null;
            this.cboService.Upp = false;
            this.cboService.Value = "";
            this.cboService.ValueMember = "";
            // 
            // txtPlaceAffected
            // 
            this.txtPlaceAffected.Add = false;
            this.txtPlaceAffected.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPlaceAffected.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPlaceAffected.Caption = "";
            this.txtPlaceAffected.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPlaceAffected.DBField = null;
            this.txtPlaceAffected.DBFieldType = null;
            this.txtPlaceAffected.DefaultValue = null;
            this.txtPlaceAffected.Del = false;
            this.txtPlaceAffected.DependingRS = null;
            this.txtPlaceAffected.ExtraDataLink = null;
            this.txtPlaceAffected.ForeColor = System.Drawing.Color.Gray;
            this.txtPlaceAffected.IsCTLMOwned = false;
            this.txtPlaceAffected.Location = new System.Drawing.Point(561, 241);
            this.txtPlaceAffected.Margin = new System.Windows.Forms.Padding(3, 46, 3, 3);
            this.txtPlaceAffected.Multiline = true;
            this.txtPlaceAffected.Name = "txtPlaceAffected";
            this.txtPlaceAffected.Order = 0;
            this.txtPlaceAffected.ParentConn = null;
            this.txtPlaceAffected.ParentDA = null;
            
            this.txtPlaceAffected.PK = false;
            this.txtPlaceAffected.Protected = false;
            this.txtPlaceAffected.ReadOnly = true;
            this.txtPlaceAffected.Search = false;
            this.txtPlaceAffected.Size = new System.Drawing.Size(100, 24);
            this.txtPlaceAffected.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPlaceAffected.TabIndex = 84;
            this.txtPlaceAffected.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPlaceAffected.Upp = false;
            
            this.txtPlaceAffected.Value = "";
            // 
            // cboPlaceAffected
            // 
            this.cboPlaceAffected.Add = false;
            this.cboPlaceAffected.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPlaceAffected.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlaceAffected.Caption = "Place Affected";
            this.cboPlaceAffected.DataSource = null;
            this.cboPlaceAffected.DBField = null;
            this.cboPlaceAffected.DBFieldType = null;
            this.cboPlaceAffected.DefaultValue = null;
            this.cboPlaceAffected.Del = false;
            this.cboPlaceAffected.DependingRS = null;
            this.cboPlaceAffected.DisplayMember = "";
            this.cboPlaceAffected.ExtraDataLink = null;
            this.cboPlaceAffected.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPlaceAffected.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboPlaceAffected.ForeColor = System.Drawing.Color.Black;
            this.cboPlaceAffected.FormattingEnabled = true;
            this.cboPlaceAffected.IsCTLMOwned = false;
            this.cboPlaceAffected.Location = new System.Drawing.Point(425, 225);
            this.cboPlaceAffected.Margin = new System.Windows.Forms.Padding(3, 136, 3, 3);
            this.cboPlaceAffected.Name = "cboPlaceAffected";
            this.cboPlaceAffected.Order = 0;
            this.cboPlaceAffected.ParentConn = null;
            this.cboPlaceAffected.ParentDA = null;
            this.cboPlaceAffected.PK = false;
            this.cboPlaceAffected.Protected = false;
            this.cboPlaceAffected.ReadOnly = false;
            this.cboPlaceAffected.Search = false;
            this.cboPlaceAffected.SelectedItem = null;
            this.cboPlaceAffected.SelectedValue = null;
            this.cboPlaceAffected.Size = new System.Drawing.Size(130, 40);
            this.cboPlaceAffected.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboPlaceAffected.TabIndex = 82;
            this.cboPlaceAffected.TBDescription = null;
            this.cboPlaceAffected.Upp = false;
            this.cboPlaceAffected.Value = "";
            this.cboPlaceAffected.ValueMember = "";
            // 
            // txtPlaceAdvise
            // 
            this.txtPlaceAdvise.Add = false;
            this.txtPlaceAdvise.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPlaceAdvise.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPlaceAdvise.Caption = "";
            this.txtPlaceAdvise.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPlaceAdvise.DBField = null;
            this.txtPlaceAdvise.DBFieldType = null;
            this.txtPlaceAdvise.DefaultValue = null;
            this.txtPlaceAdvise.Del = false;
            this.txtPlaceAdvise.DependingRS = null;
            this.txtPlaceAdvise.ExtraDataLink = null;
            this.txtPlaceAdvise.ForeColor = System.Drawing.Color.Gray;
            this.txtPlaceAdvise.IsCTLMOwned = false;
            this.txtPlaceAdvise.Location = new System.Drawing.Point(561, 201);
            this.txtPlaceAdvise.Margin = new System.Windows.Forms.Padding(3, 46, 3, 3);
            this.txtPlaceAdvise.Multiline = true;
            this.txtPlaceAdvise.Name = "txtPlaceAdvise";
            this.txtPlaceAdvise.Order = 0;
            this.txtPlaceAdvise.ParentConn = null;
            this.txtPlaceAdvise.ParentDA = null;
            
            this.txtPlaceAdvise.PK = false;
            this.txtPlaceAdvise.Protected = false;
            this.txtPlaceAdvise.ReadOnly = true;
            this.txtPlaceAdvise.Search = false;
            this.txtPlaceAdvise.Size = new System.Drawing.Size(100, 24);
            this.txtPlaceAdvise.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPlaceAdvise.TabIndex = 73;
            this.txtPlaceAdvise.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPlaceAdvise.Upp = false;
            
            this.txtPlaceAdvise.Value = "";
            // 
            // cboPlaceAdvise
            // 
            this.cboPlaceAdvise.Add = false;
            this.cboPlaceAdvise.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPlaceAdvise.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPlaceAdvise.Caption = "Place Advise";
            this.cboPlaceAdvise.DataSource = null;
            this.cboPlaceAdvise.DBField = null;
            this.cboPlaceAdvise.DBFieldType = null;
            this.cboPlaceAdvise.DefaultValue = null;
            this.cboPlaceAdvise.Del = false;
            this.cboPlaceAdvise.DependingRS = null;
            this.cboPlaceAdvise.DisplayMember = "";
            this.cboPlaceAdvise.ExtraDataLink = null;
            this.cboPlaceAdvise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPlaceAdvise.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboPlaceAdvise.ForeColor = System.Drawing.Color.Black;
            this.cboPlaceAdvise.FormattingEnabled = true;
            this.cboPlaceAdvise.IsCTLMOwned = false;
            this.cboPlaceAdvise.Location = new System.Drawing.Point(425, 185);
            this.cboPlaceAdvise.Margin = new System.Windows.Forms.Padding(3, 136, 3, 3);
            this.cboPlaceAdvise.Name = "cboPlaceAdvise";
            this.cboPlaceAdvise.Order = 0;
            this.cboPlaceAdvise.ParentConn = null;
            this.cboPlaceAdvise.ParentDA = null;
            this.cboPlaceAdvise.PK = false;
            this.cboPlaceAdvise.Protected = false;
            this.cboPlaceAdvise.ReadOnly = false;
            this.cboPlaceAdvise.Search = false;
            this.cboPlaceAdvise.SelectedItem = null;
            this.cboPlaceAdvise.SelectedValue = null;
            this.cboPlaceAdvise.Size = new System.Drawing.Size(130, 40);
            this.cboPlaceAdvise.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboPlaceAdvise.TabIndex = 71;
            this.cboPlaceAdvise.TBDescription = null;
            this.cboPlaceAdvise.Upp = false;
            this.cboPlaceAdvise.Value = "";
            this.cboPlaceAdvise.ValueMember = "";
            // 
            // txtPerson
            // 
            this.txtPerson.Add = false;
            this.txtPerson.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPerson.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPerson.Caption = "Person Name";
            this.txtPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPerson.DBField = null;
            this.txtPerson.DBFieldType = null;
            this.txtPerson.DefaultValue = null;
            this.txtPerson.Del = false;
            this.txtPerson.DependingRS = null;
            this.txtPerson.ExtraDataLink = null;
            this.txtPerson.ForeColor = System.Drawing.Color.Gray;
            this.txtPerson.IsCTLMOwned = false;
            this.txtPerson.Location = new System.Drawing.Point(425, 146);
            this.txtPerson.Margin = new System.Windows.Forms.Padding(3, 46, 3, 3);
            this.txtPerson.Multiline = true;
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Order = 0;
            this.txtPerson.ParentConn = null;
            this.txtPerson.ParentDA = null;
            
            this.txtPerson.PK = false;
            this.txtPerson.Protected = false;
            this.txtPerson.ReadOnly = true;
            this.txtPerson.Search = false;
            this.txtPerson.Size = new System.Drawing.Size(241, 38);
            this.txtPerson.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPerson.TabIndex = 65;
            this.txtPerson.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPerson.Upp = false;
            
            this.txtPerson.Value = "";
            // 
            // txtIdTarea
            // 
            this.txtIdTarea.Add = false;
            this.txtIdTarea.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtIdTarea.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtIdTarea.Caption = "Task #";
            this.txtIdTarea.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtIdTarea.DBField = null;
            this.txtIdTarea.DBFieldType = null;
            this.txtIdTarea.DefaultValue = null;
            this.txtIdTarea.Del = false;
            this.txtIdTarea.DependingRS = null;
            this.txtIdTarea.ExtraDataLink = null;
            this.txtIdTarea.ForeColor = System.Drawing.Color.Gray;
            this.txtIdTarea.IsCTLMOwned = false;
            this.txtIdTarea.Location = new System.Drawing.Point(425, 107);
            this.txtIdTarea.Margin = new System.Windows.Forms.Padding(3, 46, 3, 3);
            this.txtIdTarea.Multiline = true;
            this.txtIdTarea.Name = "txtIdTarea";
            this.txtIdTarea.Order = 0;
            this.txtIdTarea.ParentConn = null;
            this.txtIdTarea.ParentDA = null;
            
            this.txtIdTarea.PK = false;
            this.txtIdTarea.Protected = false;
            this.txtIdTarea.ReadOnly = true;
            this.txtIdTarea.Search = false;
            this.txtIdTarea.Size = new System.Drawing.Size(241, 38);
            this.txtIdTarea.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtIdTarea.TabIndex = 63;
            this.txtIdTarea.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIdTarea.Upp = false;
            
            this.txtIdTarea.Value = "";
            // 
            // fTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 504);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIT);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkFlags);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtKm);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.cboMatter);
            this.Controls.Add(this.cboService);
            this.Controls.Add(this.txtPlaceAffected);
            this.Controls.Add(this.cboPlaceAffected);
            this.Controls.Add(this.txtPlaceAdvise);
            this.Controls.Add(this.cboPlaceAdvise);
            this.Controls.Add(this.txtPerson);
            this.Controls.Add(this.txtIdTarea);
            this.Controls.Add(this.CTLM);
            this.KeyPreview = true;
            this.Name = "fTasks";
            this.ShowIcon = false;
            this.Text = "Tasks";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackTextBox txtIdTarea;
        private EspackFormControlsNS.EspackTextBox txtPerson;
        private EspackFormControlsNS.EspackComboBox cboPlaceAdvise;
        private EspackFormControlsNS.EspackTextBox txtPlaceAdvise;
        private EspackFormControlsNS.EspackComboBox cboPlaceAffected;
        private EspackFormControlsNS.EspackTextBox txtPlaceAffected;
        private EspackFormControlsNS.EspackComboBox cboService;
        private EspackFormControlsNS.EspackComboBox cboMatter;
        private EspackFormControlsNS.EspackDateTimePicker dateStart;
        private EspackFormControlsNS.EspackDateTimePicker dateEnd;
        private EspackFormControlsNS.EspackNumericTextBox txtKm;
        private EspackFormControlsNS.EspackTextBox txtNotes;
        private EspackFormControlsNS.EspackCheckedListBox chkFlags;
        private System.Windows.Forms.GroupBox groupBox1;
        private EspackFormControlsNS.EspackComboBox cboMatterDef;
        private EspackFormControlsNS.EspackComboBox cboServiceDef;
        private EspackFormControlsNS.EspackComboBox cboPlaceAffectedDef;
        private EspackFormControlsNS.EspackComboBox cboPlaceAdviseDef;
        private System.Windows.Forms.MonthCalendar CalDateDef;
        private EspackFormControlsNS.EspackTextBox txtIT;
        private System.Windows.Forms.Label label1;
    }
}