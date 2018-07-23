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
            this.cboCOD3 = new EspackFormControlsNS.EspackComboBox();
            this.txtPONumber = new EspackFormControlsNS.EspackTextBox();
            this.txtPOCode = new EspackFormControlsNS.EspackTextBox();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.txtDesCod3 = new EspackFormControlsNS.EspackTextBox();
            this.cboSuppliers = new EspackFormControlsNS.EspackComboBox();
            this.fsPODocument = new EspackFormControlsNS.EspackFileStreamControl();
            this.FdcPDFData = new EspackFormControlsNS.EspackFileDataContainerPreview();
            this.txtDescription = new EspackFormControlsNS.EspackTextBox();
            this.SuspendLayout();
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
            this.cboCOD3.Location = new System.Drawing.Point(333, 83);
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
            this.cboCOD3.TabIndex = 117;
            this.cboCOD3.TBDescription = null;
            this.cboCOD3.Upp = true;
            this.cboCOD3.Value = "";
            this.cboCOD3.ValueMember = "";
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
            this.txtDesCod3.Location = new System.Drawing.Point(493, 98);
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
            this.txtDesCod3.TabIndex = 118;
            this.txtDesCod3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDesCod3.Upp = false;
            this.txtDesCod3.Value = "";
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
            this.cboSuppliers.Location = new System.Drawing.Point(12, 129);
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
            this.cboSuppliers.TabIndex = 119;
            this.cboSuppliers.TBDescription = null;
            this.cboSuppliers.Upp = false;
            this.cboSuppliers.Value = "";
            this.cboSuppliers.ValueMember = "";
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
            this.fsPODocument.Location = new System.Drawing.Point(794, 83);
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
            this.fsPODocument.Size = new System.Drawing.Size(154, 41);
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
            this.FdcPDFData.Location = new System.Drawing.Point(954, 13);
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
            this.txtDescription.Caption = "";
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDescription.DBField = null;
            this.txtDescription.DBFieldType = null;
            this.txtDescription.DefaultValue = null;
            this.txtDescription.Del = false;
            this.txtDescription.DependingRS = null;
            this.txtDescription.ExtraDataLink = null;
            this.txtDescription.IsCTLMOwned = false;
            this.txtDescription.IsPassword = false;
            this.txtDescription.Location = new System.Drawing.Point(173, 143);
            this.txtDescription.Multiline = false;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Order = 0;
            this.txtDescription.ParentConn = null;
            this.txtDescription.ParentDA = null;
            this.txtDescription.PK = false;
            this.txtDescription.Protected = false;
            this.txtDescription.ReadOnly = false;
            this.txtDescription.Search = false;
            this.txtDescription.Size = new System.Drawing.Size(775, 68);
            this.txtDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDescription.TabIndex = 122;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.Upp = false;
            this.txtDescription.Value = "";
            // 
            // fPurchaseOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1683, 909);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.FdcPDFData);
            this.Controls.Add(this.fsPODocument);
            this.Controls.Add(this.cboSuppliers);
            this.Controls.Add(this.txtDesCod3);
            this.Controls.Add(this.cboCOD3);
            this.Controls.Add(this.txtPONumber);
            this.Controls.Add(this.txtPOCode);
            this.Controls.Add(this.CTLM);
            this.Name = "fPurchaseOrders";
            this.Text = "fPurchaseOrders";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackTextBox txtPOCode;
        private EspackFormControlsNS.EspackTextBox txtPONumber;
        private EspackFormControlsNS.EspackComboBox cboCOD3;
        private EspackFormControlsNS.EspackTextBox txtDesCod3;
        private EspackFormControlsNS.EspackComboBox cboSuppliers;
        private EspackFormControlsNS.EspackFileStreamControl fsPODocument;
        private EspackFormControlsNS.EspackFileDataContainerPreview FdcPDFData;
        private EspackFormControlsNS.EspackTextBox txtDescription;
    }
}