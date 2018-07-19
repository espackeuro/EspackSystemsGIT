namespace FormsTest
{
    partial class Form1
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
            this.txtUserCode = new EspackFormControlsNS.EspackTextBox();
            this.txtDesCod3 = new EspackFormControlsNS.EspackTextBox();
            this.cboMainCOD3 = new EspackFormControlsNS.EspackComboBox();
            this.txtPwdExp = new EspackFormControlsNS.EspackDateTimePicker();
            this.lstCOD3 = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtUserNumber = new EspackFormControlsNS.EspackNumericTextBox();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.txtText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtUserCode
            // 
            this.txtUserCode.Add = false;
            this.txtUserCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUserCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUserCode.Caption = "UserCode";
            this.txtUserCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUserCode.DBField = null;
            this.txtUserCode.DBFieldType = null;
            this.txtUserCode.DefaultValue = null;
            this.txtUserCode.Del = false;
            this.txtUserCode.DependingRS = null;
            this.txtUserCode.ExtraDataLink = null;
            this.txtUserCode.IsCTLMOwned = false;
            this.txtUserCode.Location = new System.Drawing.Point(13, 51);
            this.txtUserCode.Multiline = false;
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Order = 0;
            this.txtUserCode.ParentConn = null;
            this.txtUserCode.ParentDA = null;
            this.txtUserCode.PK = false;
            this.txtUserCode.Protected = false;
            this.txtUserCode.ReadOnly = false;
            this.txtUserCode.Search = false;
            this.txtUserCode.Size = new System.Drawing.Size(154, 38);
            this.txtUserCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtUserCode.TabIndex = 11;
            this.txtUserCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUserCode.Upp = false;
            this.txtUserCode.Value = "";
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
            this.txtDesCod3.Location = new System.Drawing.Point(334, 274);
            this.txtDesCod3.Multiline = false;
            this.txtDesCod3.Name = "txtDesCod3";
            this.txtDesCod3.Order = 0;
            this.txtDesCod3.ParentConn = null;
            this.txtDesCod3.ParentDA = null;
            this.txtDesCod3.PK = false;
            this.txtDesCod3.Protected = false;
            this.txtDesCod3.ReadOnly = false;
            this.txtDesCod3.Search = false;
            this.txtDesCod3.Size = new System.Drawing.Size(154, 38);
            this.txtDesCod3.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDesCod3.TabIndex = 10;
            this.txtDesCod3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDesCod3.Upp = false;
            this.txtDesCod3.Value = "";
            // 
            // cboMainCOD3
            // 
            this.cboMainCOD3.Add = false;
            this.cboMainCOD3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboMainCOD3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboMainCOD3.Caption = "Caption";
            this.cboMainCOD3.DataSource = null;
            this.cboMainCOD3.DBField = null;
            this.cboMainCOD3.DBFieldType = null;
            this.cboMainCOD3.DefaultValue = null;
            this.cboMainCOD3.Del = false;
            this.cboMainCOD3.DependingRS = null;
            this.cboMainCOD3.DisplayMember = "";
            this.cboMainCOD3.ExtraDataLink = null;
            this.cboMainCOD3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboMainCOD3.FormattingEnabled = false;
            this.cboMainCOD3.IsCTLMOwned = false;
            this.cboMainCOD3.Location = new System.Drawing.Point(13, 273);
            this.cboMainCOD3.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboMainCOD3.Name = "cboMainCOD3";
            this.cboMainCOD3.Order = 0;
            this.cboMainCOD3.ParentConn = null;
            this.cboMainCOD3.ParentDA = null;
            this.cboMainCOD3.PK = false;
            this.cboMainCOD3.Protected = false;
            this.cboMainCOD3.ReadOnly = false;
            this.cboMainCOD3.Search = false;
            this.cboMainCOD3.SelectedItem = null;
            this.cboMainCOD3.SelectedValue = null;
            this.cboMainCOD3.Size = new System.Drawing.Size(314, 40);
            this.cboMainCOD3.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboMainCOD3.TabIndex = 9;
            this.cboMainCOD3.TBDescription = null;
            this.cboMainCOD3.Upp = false;
            this.cboMainCOD3.Value = "";
            this.cboMainCOD3.ValueMember = "";
            // 
            // txtPwdExp
            // 
            this.txtPwdExp.Add = false;
            this.txtPwdExp.BorderColor = System.Drawing.Color.Black;
            this.txtPwdExp.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.txtPwdExp.Caption = "PWD EXP";
            this.txtPwdExp.Checked = true;
            this.txtPwdExp.CustomFormat = "dd/MM/yyyy H:mm";
            this.txtPwdExp.DBField = null;
            this.txtPwdExp.DBFieldType = null;
            this.txtPwdExp.DefaultValue = null;
            this.txtPwdExp.Del = false;
            this.txtPwdExp.DependingRS = null;
            this.txtPwdExp.ExtraDataLink = null;
            this.txtPwdExp.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtPwdExp.IsCTLMOwned = false;
            this.txtPwdExp.Location = new System.Drawing.Point(13, 227);
            this.txtPwdExp.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtPwdExp.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtPwdExp.Name = "txtPwdExp";
            this.txtPwdExp.Nullable = true;
            this.txtPwdExp.Order = 0;
            this.txtPwdExp.ParentConn = null;
            this.txtPwdExp.ParentDA = null;
            this.txtPwdExp.PK = false;
            this.txtPwdExp.Protected = false;
            this.txtPwdExp.ReadOnly = false;
            this.txtPwdExp.Search = false;
            this.txtPwdExp.ShowCheckBox = true;
            this.txtPwdExp.Size = new System.Drawing.Size(314, 39);
            this.txtPwdExp.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPwdExp.TabIndex = 8;
            this.txtPwdExp.Text = "11/07/2018 15:24";
            this.txtPwdExp.Upp = false;
            this.txtPwdExp.Value = new System.DateTime(2018, 7, 11, 15, 24, 16, 882);
            // 
            // lstCOD3
            // 
            this.lstCOD3.Add = false;
            this.lstCOD3.Caption = "COD3";
            this.lstCOD3.CheckOnClick = true;
            this.lstCOD3.ColumnWidth = 100;
            this.lstCOD3.DataSource = null;
            this.lstCOD3.DBField = null;
            this.lstCOD3.DBFieldType = null;
            this.lstCOD3.DefaultValue = null;
            this.lstCOD3.Del = false;
            this.lstCOD3.DependingRS = null;
            this.lstCOD3.DisplayMember = "";
            this.lstCOD3.ExtraDataLink = null;
            this.lstCOD3.FormattingEnabled = false;
            this.lstCOD3.IsCTLMOwned = false;
            this.lstCOD3.Location = new System.Drawing.Point(13, 96);
            this.lstCOD3.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstCOD3.MultiColumn = true;
            this.lstCOD3.Name = "lstCOD3";
            this.lstCOD3.Order = 0;
            this.lstCOD3.ParentConn = null;
            this.lstCOD3.ParentDA = null;
            this.lstCOD3.PK = false;
            this.lstCOD3.Protected = false;
            this.lstCOD3.ReadOnly = false;
            this.lstCOD3.Search = false;
            this.lstCOD3.SelectedItem = null;
            this.lstCOD3.SelectedValue = null;
            this.lstCOD3.Size = new System.Drawing.Size(314, 124);
            this.lstCOD3.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstCOD3.TabIndex = 7;
            this.lstCOD3.TBDescription = null;
            this.lstCOD3.Upp = false;
            this.lstCOD3.Value = "";
            this.lstCOD3.ValueMember = "";
            // 
            // txtUserNumber
            // 
            this.txtUserNumber.Add = false;
            this.txtUserNumber.AllowSpace = false;
            this.txtUserNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUserNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUserNumber.Caption = "User Number";
            this.txtUserNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUserNumber.DBField = null;
            this.txtUserNumber.DBFieldType = null;
            this.txtUserNumber.DefaultValue = null;
            this.txtUserNumber.Del = false;
            this.txtUserNumber.DependingRS = null;
            this.txtUserNumber.ExtraDataLink = null;
            this.txtUserNumber.IsCTLMOwned = false;
            this.txtUserNumber.Length = 0;
            this.txtUserNumber.Location = new System.Drawing.Point(173, 51);
            this.txtUserNumber.Mask = false;
            this.txtUserNumber.Multiline = false;
            this.txtUserNumber.Name = "txtUserNumber";
            this.txtUserNumber.Order = 0;
            this.txtUserNumber.ParentConn = null;
            this.txtUserNumber.ParentDA = null;
            this.txtUserNumber.PK = false;
            this.txtUserNumber.Precision = 0;
            this.txtUserNumber.Protected = false;
            this.txtUserNumber.ReadOnly = false;
            this.txtUserNumber.Search = false;
            this.txtUserNumber.Size = new System.Drawing.Size(154, 38);
            this.txtUserNumber.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtUserNumber.TabIndex = 6;
            this.txtUserNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUserNumber.ThousandsGroup = true;
            this.txtUserNumber.Upp = false;
            this.txtUserNumber.Value = null;
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
            this.CTLM.TabIndex = 3;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(362, 68);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(100, 20);
            this.txtText.TabIndex = 12;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(584, 396);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtUserCode);
            this.Controls.Add(this.txtDesCod3);
            this.Controls.Add(this.cboMainCOD3);
            this.Controls.Add(this.txtPwdExp);
            this.Controls.Add(this.lstCOD3);
            this.Controls.Add(this.txtUserNumber);
            this.Controls.Add(this.CTLM);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.EspackTextBox espackTextBox1;
        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackNumericTextBox txtUserNumber;
        private EspackFormControlsNS.EspackCheckedListBox lstCOD3;
        private EspackFormControlsNS.EspackDateTimePicker txtPwdExp;
        private EspackFormControlsNS.EspackComboBox cboMainCOD3;
        private EspackFormControlsNS.EspackTextBox txtDesCod3;
        private EspackFormControlsNS.EspackTextBox txtUserCode;
        private System.Windows.Forms.TextBox txtText;
    }
}

