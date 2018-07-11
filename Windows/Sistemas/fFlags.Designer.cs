namespace Sistemas
{
    partial class fFlags
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
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboTable = new EspackFormControlsNS.EspackComboBox();
            this.txtCode = new EspackFormControlsNS.EspackTextBox();
            this.txtLetter = new EspackFormControlsNS.EspackTextBox();
            this.txtIdReg = new EspackFormControlsNS.EspackTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDesFlagEng = new EspackFormControlsNS.EspackTextBox();
            this.txtDescFlag = new EspackFormControlsNS.EspackTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstServices = new EspackFormControlsNS.EspackCheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.CTLM.Location = new System.Drawing.Point(0, 0);
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
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.cboTable);
            this.groupBox1.Controls.Add(this.txtCode);
            this.groupBox1.Controls.Add(this.txtLetter);
            this.groupBox1.Controls.Add(this.txtIdReg);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(703, 73);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Id";
            // 
            // cboTable
            // 
            this.cboTable.Add = false;
            this.cboTable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboTable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboTable.Caption = "Table";
            this.cboTable.DataSource = null;
            this.cboTable.DBField = null;
            this.cboTable.DBFieldType = null;
            this.cboTable.DefaultValue = null;
            this.cboTable.Del = false;
            this.cboTable.DependingRS = null;
            this.cboTable.DisplayMember = "";
            this.cboTable.ExtraDataLink = null;
            this.cboTable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTable.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboTable.ForeColor = System.Drawing.Color.Black;
            this.cboTable.FormattingEnabled = true;
            this.cboTable.IsCTLMOwned = false;
            this.cboTable.Location = new System.Drawing.Point(177, 32);
            this.cboTable.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboTable.Name = "cboTable";
            this.cboTable.Order = 0;
            this.cboTable.ParentConn = null;
            this.cboTable.ParentDA = null;
            this.cboTable.PK = false;
            this.cboTable.Protected = false;
            this.cboTable.ReadOnly = false;
            this.cboTable.Search = false;
            this.cboTable.SelectedItem = null;
            this.cboTable.SelectedValue = null;
            this.cboTable.Size = new System.Drawing.Size(250, 40);
            this.cboTable.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboTable.TabIndex = 11;
            this.cboTable.TBDescription = null;
            this.cboTable.Upp = false;
            this.cboTable.Value = "";
            this.cboTable.ValueMember = "";
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
            this.txtCode.ForeColor = System.Drawing.Color.Gray;
            this.txtCode.IsCTLMOwned = false;
            this.txtCode.Location = new System.Drawing.Point(564, 32);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.Order = 0;
            this.txtCode.ParentConn = null;
            this.txtCode.ParentDA = null;
            this.txtCode.PasswordChar = '\0';
            this.txtCode.PK = false;
            this.txtCode.Protected = false;
            this.txtCode.ReadOnly = true;
            this.txtCode.Search = false;
            this.txtCode.Size = new System.Drawing.Size(125, 40);
            this.txtCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtCode.TabIndex = 15;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCode.Upp = false;
            this.txtCode.UseSystemPasswordChar = false;
            this.txtCode.Value = "";
            // 
            // txtLetter
            // 
            this.txtLetter.Add = false;
            this.txtLetter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtLetter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtLetter.Caption = "Letter";
            this.txtLetter.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLetter.DBField = null;
            this.txtLetter.DBFieldType = null;
            this.txtLetter.DefaultValue = null;
            this.txtLetter.Del = false;
            this.txtLetter.DependingRS = null;
            this.txtLetter.ExtraDataLink = null;
            this.txtLetter.ForeColor = System.Drawing.Color.Gray;
            this.txtLetter.IsCTLMOwned = false;
            this.txtLetter.Location = new System.Drawing.Point(464, 32);
            this.txtLetter.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtLetter.Multiline = true;
            this.txtLetter.Name = "txtLetter";
            this.txtLetter.Order = 0;
            this.txtLetter.ParentConn = null;
            this.txtLetter.ParentDA = null;
            this.txtLetter.PasswordChar = '\0';
            this.txtLetter.PK = false;
            this.txtLetter.Protected = false;
            this.txtLetter.ReadOnly = true;
            this.txtLetter.Search = false;
            this.txtLetter.Size = new System.Drawing.Size(55, 40);
            this.txtLetter.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtLetter.TabIndex = 13;
            this.txtLetter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLetter.Upp = false;
            this.txtLetter.UseSystemPasswordChar = false;
            this.txtLetter.Value = "";
            // 
            // txtIdReg
            // 
            this.txtIdReg.Add = false;
            this.txtIdReg.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtIdReg.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtIdReg.Caption = "IdReg";
            this.txtIdReg.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtIdReg.DBField = null;
            this.txtIdReg.DBFieldType = null;
            this.txtIdReg.DefaultValue = null;
            this.txtIdReg.Del = false;
            this.txtIdReg.DependingRS = null;
            this.txtIdReg.ExtraDataLink = null;
            this.txtIdReg.ForeColor = System.Drawing.Color.Gray;
            this.txtIdReg.IsCTLMOwned = false;
            this.txtIdReg.Location = new System.Drawing.Point(17, 32);
            this.txtIdReg.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtIdReg.Multiline = true;
            this.txtIdReg.Name = "txtIdReg";
            this.txtIdReg.Order = 0;
            this.txtIdReg.ParentConn = null;
            this.txtIdReg.ParentDA = null;
            this.txtIdReg.PasswordChar = '\0';
            this.txtIdReg.PK = false;
            this.txtIdReg.Protected = false;
            this.txtIdReg.ReadOnly = true;
            this.txtIdReg.Search = false;
            this.txtIdReg.Size = new System.Drawing.Size(125, 40);
            this.txtIdReg.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtIdReg.TabIndex = 9;
            this.txtIdReg.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIdReg.Upp = false;
            this.txtIdReg.UseSystemPasswordChar = false;
            this.txtIdReg.Value = "";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.txtDesFlagEng);
            this.groupBox2.Controls.Add(this.txtDescFlag);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(13, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(703, 71);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Description";
            // 
            // txtDesFlagEng
            // 
            this.txtDesFlagEng.Add = false;
            this.txtDesFlagEng.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDesFlagEng.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDesFlagEng.Caption = "DescFlagEng";
            this.txtDesFlagEng.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDesFlagEng.DBField = null;
            this.txtDesFlagEng.DBFieldType = null;
            this.txtDesFlagEng.DefaultValue = null;
            this.txtDesFlagEng.Del = false;
            this.txtDesFlagEng.DependingRS = null;
            this.txtDesFlagEng.ExtraDataLink = null;
            this.txtDesFlagEng.ForeColor = System.Drawing.Color.Gray;
            this.txtDesFlagEng.IsCTLMOwned = false;
            this.txtDesFlagEng.Location = new System.Drawing.Point(499, 32);
            this.txtDesFlagEng.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDesFlagEng.Multiline = true;
            this.txtDesFlagEng.Name = "txtDesFlagEng";
            this.txtDesFlagEng.Order = 0;
            this.txtDesFlagEng.ParentConn = null;
            this.txtDesFlagEng.ParentDA = null;
            this.txtDesFlagEng.PasswordChar = '\0';
            this.txtDesFlagEng.PK = false;
            this.txtDesFlagEng.Protected = false;
            this.txtDesFlagEng.ReadOnly = true;
            this.txtDesFlagEng.Search = false;
            this.txtDesFlagEng.Size = new System.Drawing.Size(190, 40);
            this.txtDesFlagEng.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDesFlagEng.TabIndex = 2;
            this.txtDesFlagEng.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDesFlagEng.Upp = false;
            this.txtDesFlagEng.UseSystemPasswordChar = false;
            this.txtDesFlagEng.Value = "";
            // 
            // txtDescFlag
            // 
            this.txtDescFlag.Add = false;
            this.txtDescFlag.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDescFlag.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDescFlag.Caption = "DescFlag";
            this.txtDescFlag.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDescFlag.DBField = null;
            this.txtDescFlag.DBFieldType = null;
            this.txtDescFlag.DefaultValue = null;
            this.txtDescFlag.Del = false;
            this.txtDescFlag.DependingRS = null;
            this.txtDescFlag.ExtraDataLink = null;
            this.txtDescFlag.ForeColor = System.Drawing.Color.Gray;
            this.txtDescFlag.IsCTLMOwned = false;
            this.txtDescFlag.Location = new System.Drawing.Point(17, 32);
            this.txtDescFlag.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDescFlag.Multiline = true;
            this.txtDescFlag.Name = "txtDescFlag";
            this.txtDescFlag.Order = 0;
            this.txtDescFlag.ParentConn = null;
            this.txtDescFlag.ParentDA = null;
            this.txtDescFlag.PasswordChar = '\0';
            this.txtDescFlag.PK = false;
            this.txtDescFlag.Protected = false;
            this.txtDescFlag.ReadOnly = true;
            this.txtDescFlag.Search = false;
            this.txtDescFlag.Size = new System.Drawing.Size(190, 40);
            this.txtDescFlag.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDescFlag.TabIndex = 0;
            this.txtDescFlag.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescFlag.Upp = false;
            this.txtDescFlag.UseSystemPasswordChar = false;
            this.txtDescFlag.Value = "";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Controls.Add(this.lstServices);
            this.groupBox3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(12, 197);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(703, 326);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Services";
            // 
            // lstServices
            // 
            this.lstServices.Add = false;
            this.lstServices.Caption = "";
            this.lstServices.CheckOnClick = true;
            this.lstServices.ColumnWidth = 225;
            this.lstServices.DataSource = null;
            this.lstServices.DBField = null;
            this.lstServices.DBFieldType = null;
            this.lstServices.DefaultValue = null;
            this.lstServices.Del = false;
            this.lstServices.DependingRS = null;
            this.lstServices.DisplayMember = "";
            this.lstServices.ExtraDataLink = null;
            this.lstServices.ForeColor = System.Drawing.Color.Black;
            this.lstServices.FormattingEnabled = true;
            this.lstServices.IsCTLMOwned = false;
            this.lstServices.Location = new System.Drawing.Point(14, 21);
            this.lstServices.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstServices.MultiColumn = true;
            this.lstServices.Name = "lstServices";
            this.lstServices.Order = 0;
            this.lstServices.ParentConn = null;
            this.lstServices.ParentDA = null;
            this.lstServices.PK = false;
            this.lstServices.Protected = false;
            this.lstServices.ReadOnly = false;
            this.lstServices.Search = false;
            this.lstServices.SelectedItem = null;
            this.lstServices.SelectedValue = null;
            this.lstServices.Size = new System.Drawing.Size(675, 285);
            this.lstServices.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstServices.TabIndex = 0;
            this.lstServices.TBDescription = null;
            this.lstServices.Upp = false;
            this.lstServices.Value = "";
            this.lstServices.ValueMember = "";
            // 
            // fFlags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 586);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.CTLM);
            this.Controls.Add(this.groupBox1);
            this.Name = "fFlags";
            this.ShowIcon = false;
            this.Text = "Flags";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private System.Windows.Forms.GroupBox groupBox1;
        private EspackFormControlsNS.EspackComboBox cboTable;
        private EspackFormControlsNS.EspackTextBox txtIdReg;
        private EspackFormControlsNS.EspackTextBox txtCode;
        private EspackFormControlsNS.EspackTextBox txtLetter;
        private System.Windows.Forms.GroupBox groupBox2;
        private EspackFormControlsNS.EspackTextBox txtDesFlagEng;
        private EspackFormControlsNS.EspackTextBox txtDescFlag;
        private System.Windows.Forms.GroupBox groupBox3;
        private EspackFormControlsNS.EspackCheckedListBox lstServices;
    }
}