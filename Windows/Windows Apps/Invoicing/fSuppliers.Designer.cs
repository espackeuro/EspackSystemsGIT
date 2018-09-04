namespace Invoicing
{
    partial class fSuppliers
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
            this.txtCode = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtDescription = new EspackFormControlsNS.EspackTextBox();
            this.lstFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtCOD3Description = new EspackFormControlsNS.EspackTextBox();
            this.cboCOD3 = new EspackFormControlsNS.EspackComboBox();
            this.txtInternalCompanyDescription = new EspackFormControlsNS.EspackTextBox();
            this.cboInternalCompanyCode = new EspackFormControlsNS.EspackComboBox();
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
            this.CTLM.TabIndex = 17;
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
            this.txtCode.TabIndex = 21;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCode.ThousandsGroup = false;
            this.txtCode.Upp = false;
            this.txtCode.Value = null;
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
            this.txtDescription.Location = new System.Drawing.Point(172, 49);
            this.txtDescription.Multiline = false;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Order = 0;
            this.txtDescription.ParentConn = null;
            this.txtDescription.ParentDA = null;
            this.txtDescription.PK = false;
            this.txtDescription.Protected = false;
            this.txtDescription.ReadOnly = false;
            this.txtDescription.Search = false;
            this.txtDescription.Size = new System.Drawing.Size(314, 40);
            this.txtDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDescription.TabIndex = 20;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.Upp = false;
            this.txtDescription.Value = "";
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
            this.lstFlags.Location = new System.Drawing.Point(12, 200);
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
            this.lstFlags.Size = new System.Drawing.Size(474, 70);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 127;
            this.lstFlags.TBDescription = null;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            this.lstFlags.ValueMember = "";
            // 
            // txtCOD3Description
            // 
            this.txtCOD3Description.Add = false;
            this.txtCOD3Description.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCOD3Description.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCOD3Description.Caption = "";
            this.txtCOD3Description.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCOD3Description.DBField = null;
            this.txtCOD3Description.DBFieldType = null;
            this.txtCOD3Description.DefaultValue = null;
            this.txtCOD3Description.Del = false;
            this.txtCOD3Description.DependingRS = null;
            this.txtCOD3Description.ExtraDataLink = null;
            this.txtCOD3Description.IsCTLMOwned = false;
            this.txtCOD3Description.IsPassword = false;
            this.txtCOD3Description.Location = new System.Drawing.Point(172, 157);
            this.txtCOD3Description.Multiline = false;
            this.txtCOD3Description.Name = "txtCOD3Description";
            this.txtCOD3Description.Order = 0;
            this.txtCOD3Description.ParentConn = null;
            this.txtCOD3Description.ParentDA = null;
            this.txtCOD3Description.PK = false;
            this.txtCOD3Description.Protected = false;
            this.txtCOD3Description.ReadOnly = true;
            this.txtCOD3Description.Search = false;
            this.txtCOD3Description.Size = new System.Drawing.Size(314, 24);
            this.txtCOD3Description.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtCOD3Description.TabIndex = 132;
            this.txtCOD3Description.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtCOD3Description.Upp = false;
            this.txtCOD3Description.Value = "";
            // 
            // cboCOD3
            // 
            this.cboCOD3.Add = false;
            this.cboCOD3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCOD3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCOD3.Caption = "COD3";
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
            this.cboCOD3.Location = new System.Drawing.Point(12, 141);
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
            this.cboCOD3.TabIndex = 131;
            this.cboCOD3.TBDescription = null;
            this.cboCOD3.Upp = false;
            this.cboCOD3.Value = "";
            this.cboCOD3.ValueMember = "";
            // 
            // txtInternalCompanyDescription
            // 
            this.txtInternalCompanyDescription.Add = false;
            this.txtInternalCompanyDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtInternalCompanyDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtInternalCompanyDescription.Caption = "";
            this.txtInternalCompanyDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtInternalCompanyDescription.DBField = null;
            this.txtInternalCompanyDescription.DBFieldType = null;
            this.txtInternalCompanyDescription.DefaultValue = null;
            this.txtInternalCompanyDescription.Del = false;
            this.txtInternalCompanyDescription.DependingRS = null;
            this.txtInternalCompanyDescription.ExtraDataLink = null;
            this.txtInternalCompanyDescription.IsCTLMOwned = false;
            this.txtInternalCompanyDescription.IsPassword = false;
            this.txtInternalCompanyDescription.Location = new System.Drawing.Point(172, 111);
            this.txtInternalCompanyDescription.Multiline = false;
            this.txtInternalCompanyDescription.Name = "txtInternalCompanyDescription";
            this.txtInternalCompanyDescription.Order = 0;
            this.txtInternalCompanyDescription.ParentConn = null;
            this.txtInternalCompanyDescription.ParentDA = null;
            this.txtInternalCompanyDescription.PK = false;
            this.txtInternalCompanyDescription.Protected = false;
            this.txtInternalCompanyDescription.ReadOnly = true;
            this.txtInternalCompanyDescription.Search = false;
            this.txtInternalCompanyDescription.Size = new System.Drawing.Size(314, 24);
            this.txtInternalCompanyDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtInternalCompanyDescription.TabIndex = 134;
            this.txtInternalCompanyDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtInternalCompanyDescription.Upp = false;
            this.txtInternalCompanyDescription.Value = "";
            // 
            // cboInternalCompanyCode
            // 
            this.cboInternalCompanyCode.Add = false;
            this.cboInternalCompanyCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboInternalCompanyCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboInternalCompanyCode.Caption = "Internal Company Code";
            this.cboInternalCompanyCode.DataSource = null;
            this.cboInternalCompanyCode.DBField = null;
            this.cboInternalCompanyCode.DBFieldType = null;
            this.cboInternalCompanyCode.DefaultValue = null;
            this.cboInternalCompanyCode.Del = false;
            this.cboInternalCompanyCode.DependingRS = null;
            this.cboInternalCompanyCode.DisplayMember = "";
            this.cboInternalCompanyCode.ExtraDataLink = null;
            this.cboInternalCompanyCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboInternalCompanyCode.FormattingEnabled = false;
            this.cboInternalCompanyCode.IsCTLMOwned = false;
            this.cboInternalCompanyCode.Location = new System.Drawing.Point(12, 95);
            this.cboInternalCompanyCode.Name = "cboInternalCompanyCode";
            this.cboInternalCompanyCode.Order = 0;
            this.cboInternalCompanyCode.ParentConn = null;
            this.cboInternalCompanyCode.ParentDA = null;
            this.cboInternalCompanyCode.PK = false;
            this.cboInternalCompanyCode.Protected = false;
            this.cboInternalCompanyCode.ReadOnly = false;
            this.cboInternalCompanyCode.Search = false;
            this.cboInternalCompanyCode.SelectedItem = null;
            this.cboInternalCompanyCode.SelectedValue = null;
            this.cboInternalCompanyCode.Size = new System.Drawing.Size(154, 40);
            this.cboInternalCompanyCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboInternalCompanyCode.TabIndex = 133;
            this.cboInternalCompanyCode.TBDescription = null;
            this.cboInternalCompanyCode.Upp = false;
            this.cboInternalCompanyCode.Value = "";
            this.cboInternalCompanyCode.ValueMember = "";
            // 
            // fSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 291);
            this.Controls.Add(this.txtInternalCompanyDescription);
            this.Controls.Add(this.cboInternalCompanyCode);
            this.Controls.Add(this.txtCOD3Description);
            this.Controls.Add(this.cboCOD3);
            this.Controls.Add(this.lstFlags);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.CTLM);
            this.Name = "fSuppliers";
            this.Text = "Suppliers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackNumericTextBox txtCode;
        private EspackFormControlsNS.EspackTextBox txtDescription;
        private EspackFormControlsNS.EspackCheckedListBox lstFlags;
        private EspackFormControlsNS.EspackTextBox txtCOD3Description;
        private EspackFormControlsNS.EspackComboBox cboCOD3;
        private EspackFormControlsNS.EspackTextBox txtInternalCompanyDescription;
        private EspackFormControlsNS.EspackComboBox cboInternalCompanyCode;
    }
}