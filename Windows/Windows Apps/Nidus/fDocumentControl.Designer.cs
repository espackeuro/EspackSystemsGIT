namespace Nidus
{
    partial class fDocumentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDocumentControl));
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.VS = new EspackDataGridView.EspackDataGridViewControl();
            this.fsFileData = new EspackFormControlsNS.EspackFileStreamControl();
            this.FdcPDFData = new EspackFormControlsNS.EspackFileDataContainerPreview();
            this.txtStatus = new EspackFormControlsNS.EspackTextBox();
            this.lstFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtTitle = new EspackFormControlsNS.EspackTextBox();
            this.txtSection = new EspackFormControlsNS.EspackTextBox();
            this.txtSubtype = new EspackFormControlsNS.EspackTextBox();
            this.txtTypeCode = new EspackFormControlsNS.EspackTextBox();
            this.txtEdition = new EspackFormControlsNS.EspackTextBox();
            this.txtDocumentCode = new EspackFormControlsNS.EspackTextBox();
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
            this.CTLM.Location = new System.Drawing.Point(449, 13);
            this.CTLM.MsgStatusInfoLabel = null;
            this.CTLM.MsgStatusLabel = null;
            this.CTLM.Name = "CTLM";
            this.CTLM.ReQuery = false;
            this.CTLM.Size = new System.Drawing.Size(300, 31);
            this.CTLM.sSPAdd = "";
            this.CTLM.sSPDel = "";
            this.CTLM.sSPUpp = "";
            this.CTLM.StatusBarProgress = null;
            this.CTLM.TabIndex = 8;
            // 
            // VS
            // 
            this.VS.Add = false;
            this.VS.AllowDelete = false;
            this.VS.AllowInsert = false;
            this.VS.AllowUpdate = false;
            this.VS.AllowUserToAddRows = false;
            this.VS.AllowUserToResizeColumns = true;
            this.VS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.VS.Caption = "Test VS";
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
            this.VS.Dock = System.Windows.Forms.DockStyle.Left;
            this.VS.EspackControlParent = null;
            this.VS.ExtraDataLink = null;
            this.VS.FGFocused = false;
            this.VS.FilterRow = null;
            this.VS.FilterRowEnabled = false;
            this.VS.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.VS.HorizontalScrollingOffset = 0;
            this.VS.IsCTLMOwned = false;
            this.VS.IsFilterFocused = false;
            this.VS.Location = new System.Drawing.Point(0, 0);
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
            this.VS.ReadOnly = false;
            this.VS.RowCount = 0;
            this.VS.RowHeadersVisible = false;
            this.VS.RowTemplate = dataGridViewRow1;
            this.VS.Search = false;
            this.VS.Size = new System.Drawing.Size(439, 1078);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.Status = CommonTools.EnumStatus.SEARCH;
            this.VS.TabIndex = 5;
            this.VS.Upp = false;
            this.VS.Value = null;
            // 
            // fsFileData
            // 
            this.fsFileData.Add = false;
            this.fsFileData.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.fsFileData.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.fsFileData.BackColor = System.Drawing.Color.Transparent;
            this.fsFileData.Caption = "File";
            this.fsFileData.DBField = null;
            this.fsFileData.DBFieldType = null;
            this.fsFileData.DefaultValue = null;
            this.fsFileData.Del = false;
            this.fsFileData.DependingRS = null;
            this.fsFileData.ExtraDataLink = null;
            this.fsFileData.FileData = null;
            this.fsFileData.FileName = "";
            this.fsFileData.IsCTLMOwned = false;
            this.fsFileData.Location = new System.Drawing.Point(872, 78);
            this.fsFileData.Multiline = true;
            this.fsFileData.Name = "fsFileData";
            this.fsFileData.Order = 0;
            this.fsFileData.ParentConn = null;
            this.fsFileData.ParentDA = null;
            this.fsFileData.PDFFileData = null;
            this.fsFileData.PK = false;
            this.fsFileData.Protected = false;
            this.fsFileData.ReadOnly = false;
            this.fsFileData.Search = false;
            this.fsFileData.Size = new System.Drawing.Size(144, 37);
            this.fsFileData.Status = CommonTools.EnumStatus.ADDNEW;
            this.fsFileData.TabIndex = 53;
            this.fsFileData.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.fsFileData.Upp = false;
            this.fsFileData.Value = "";
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
            this.FdcPDFData.Location = new System.Drawing.Point(1130, 78);
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
            this.FdcPDFData.TabIndex = 51;
            this.FdcPDFData.Upp = false;
            this.FdcPDFData.Value = null;
            // 
            // txtStatus
            // 
            this.txtStatus.Add = false;
            this.txtStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtStatus.Caption = "Status";
            this.txtStatus.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtStatus.DBField = null;
            this.txtStatus.DBFieldType = null;
            this.txtStatus.DefaultValue = null;
            this.txtStatus.Del = false;
            this.txtStatus.DependingRS = null;
            this.txtStatus.ExtraDataLink = null;
            this.txtStatus.ForeColor = System.Drawing.Color.Black;
            this.txtStatus.IsCTLMOwned = false;
            this.txtStatus.IsPassword = false;
            this.txtStatus.Location = new System.Drawing.Point(874, 114);
            this.txtStatus.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtStatus.Multiline = false;
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Order = 0;
            this.txtStatus.ParentConn = null;
            this.txtStatus.ParentDA = null;
            this.txtStatus.PK = false;
            this.txtStatus.Protected = false;
            this.txtStatus.ReadOnly = false;
            this.txtStatus.Search = false;
            this.txtStatus.Size = new System.Drawing.Size(100, 37);
            this.txtStatus.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtStatus.TabIndex = 33;
            this.txtStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtStatus.Upp = false;
            this.txtStatus.Value = "";
            // 
            // lstFlags
            // 
            this.lstFlags.Add = false;
            this.lstFlags.BackColor = System.Drawing.Color.White;
            this.lstFlags.Caption = "";
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
            this.lstFlags.ForeColor = System.Drawing.Color.Black;
            this.lstFlags.FormattingEnabled = true;
            this.lstFlags.IsCTLMOwned = false;
            this.lstFlags.Location = new System.Drawing.Point(449, 180);
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
            this.lstFlags.Size = new System.Drawing.Size(653, 54);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 23;
            this.lstFlags.TBDescription = null;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            this.lstFlags.ValueMember = "";
            // 
            // txtTitle
            // 
            this.txtTitle.Add = false;
            this.txtTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTitle.Caption = "Title";
            this.txtTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTitle.DBField = null;
            this.txtTitle.DBFieldType = null;
            this.txtTitle.DefaultValue = null;
            this.txtTitle.Del = false;
            this.txtTitle.DependingRS = null;
            this.txtTitle.ExtraDataLink = null;
            this.txtTitle.ForeColor = System.Drawing.Color.Black;
            this.txtTitle.IsCTLMOwned = false;
            this.txtTitle.IsPassword = false;
            this.txtTitle.Location = new System.Drawing.Point(555, 78);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtTitle.Multiline = false;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Order = 0;
            this.txtTitle.ParentConn = null;
            this.txtTitle.ParentDA = null;
            this.txtTitle.PK = false;
            this.txtTitle.Protected = false;
            this.txtTitle.ReadOnly = false;
            this.txtTitle.Search = false;
            this.txtTitle.Size = new System.Drawing.Size(311, 37);
            this.txtTitle.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtTitle.TabIndex = 19;
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTitle.Upp = false;
            this.txtTitle.Value = "";
            // 
            // txtSection
            // 
            this.txtSection.Add = false;
            this.txtSection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSection.Caption = "Section";
            this.txtSection.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSection.DBField = null;
            this.txtSection.DBFieldType = null;
            this.txtSection.DefaultValue = null;
            this.txtSection.Del = false;
            this.txtSection.DependingRS = null;
            this.txtSection.ExtraDataLink = null;
            this.txtSection.ForeColor = System.Drawing.Color.Black;
            this.txtSection.IsCTLMOwned = false;
            this.txtSection.IsPassword = false;
            this.txtSection.Location = new System.Drawing.Point(661, 114);
            this.txtSection.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtSection.Multiline = false;
            this.txtSection.Name = "txtSection";
            this.txtSection.Order = 0;
            this.txtSection.ParentConn = null;
            this.txtSection.ParentDA = null;
            this.txtSection.PK = false;
            this.txtSection.Protected = false;
            this.txtSection.ReadOnly = false;
            this.txtSection.Search = false;
            this.txtSection.Size = new System.Drawing.Size(100, 37);
            this.txtSection.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtSection.TabIndex = 17;
            this.txtSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSection.Upp = false;
            this.txtSection.Value = "";
            // 
            // txtSubtype
            // 
            this.txtSubtype.Add = false;
            this.txtSubtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSubtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSubtype.Caption = "SubType";
            this.txtSubtype.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSubtype.DBField = null;
            this.txtSubtype.DBFieldType = null;
            this.txtSubtype.DefaultValue = null;
            this.txtSubtype.Del = false;
            this.txtSubtype.DependingRS = null;
            this.txtSubtype.ExtraDataLink = null;
            this.txtSubtype.ForeColor = System.Drawing.Color.Black;
            this.txtSubtype.IsCTLMOwned = false;
            this.txtSubtype.IsPassword = false;
            this.txtSubtype.Location = new System.Drawing.Point(555, 114);
            this.txtSubtype.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtSubtype.Multiline = false;
            this.txtSubtype.Name = "txtSubtype";
            this.txtSubtype.Order = 0;
            this.txtSubtype.ParentConn = null;
            this.txtSubtype.ParentDA = null;
            this.txtSubtype.PK = false;
            this.txtSubtype.Protected = false;
            this.txtSubtype.ReadOnly = false;
            this.txtSubtype.Search = false;
            this.txtSubtype.Size = new System.Drawing.Size(100, 37);
            this.txtSubtype.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtSubtype.TabIndex = 15;
            this.txtSubtype.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSubtype.Upp = false;
            this.txtSubtype.Value = "";
            // 
            // txtTypeCode
            // 
            this.txtTypeCode.Add = false;
            this.txtTypeCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtTypeCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtTypeCode.Caption = "Type";
            this.txtTypeCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTypeCode.DBField = null;
            this.txtTypeCode.DBFieldType = null;
            this.txtTypeCode.DefaultValue = null;
            this.txtTypeCode.Del = false;
            this.txtTypeCode.DependingRS = null;
            this.txtTypeCode.ExtraDataLink = null;
            this.txtTypeCode.ForeColor = System.Drawing.Color.Black;
            this.txtTypeCode.IsCTLMOwned = false;
            this.txtTypeCode.IsPassword = false;
            this.txtTypeCode.Location = new System.Drawing.Point(449, 114);
            this.txtTypeCode.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtTypeCode.Multiline = false;
            this.txtTypeCode.Name = "txtTypeCode";
            this.txtTypeCode.Order = 0;
            this.txtTypeCode.ParentConn = null;
            this.txtTypeCode.ParentDA = null;
            this.txtTypeCode.PK = false;
            this.txtTypeCode.Protected = false;
            this.txtTypeCode.ReadOnly = false;
            this.txtTypeCode.Search = false;
            this.txtTypeCode.Size = new System.Drawing.Size(100, 37);
            this.txtTypeCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtTypeCode.TabIndex = 13;
            this.txtTypeCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTypeCode.Upp = false;
            this.txtTypeCode.Value = "";
            // 
            // txtEdition
            // 
            this.txtEdition.Add = false;
            this.txtEdition.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtEdition.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtEdition.Caption = "Edition";
            this.txtEdition.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEdition.DBField = null;
            this.txtEdition.DBFieldType = null;
            this.txtEdition.DefaultValue = null;
            this.txtEdition.Del = false;
            this.txtEdition.DependingRS = null;
            this.txtEdition.ExtraDataLink = null;
            this.txtEdition.ForeColor = System.Drawing.Color.Black;
            this.txtEdition.IsCTLMOwned = false;
            this.txtEdition.IsPassword = false;
            this.txtEdition.Location = new System.Drawing.Point(767, 114);
            this.txtEdition.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtEdition.Multiline = false;
            this.txtEdition.Name = "txtEdition";
            this.txtEdition.Order = 0;
            this.txtEdition.ParentConn = null;
            this.txtEdition.ParentDA = null;
            this.txtEdition.PK = false;
            this.txtEdition.Protected = false;
            this.txtEdition.ReadOnly = false;
            this.txtEdition.Search = false;
            this.txtEdition.Size = new System.Drawing.Size(100, 37);
            this.txtEdition.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtEdition.TabIndex = 11;
            this.txtEdition.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEdition.Upp = false;
            this.txtEdition.Value = "";
            // 
            // txtDocumentCode
            // 
            this.txtDocumentCode.Add = false;
            this.txtDocumentCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDocumentCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDocumentCode.Caption = "Document Code";
            this.txtDocumentCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDocumentCode.DBField = null;
            this.txtDocumentCode.DBFieldType = null;
            this.txtDocumentCode.DefaultValue = null;
            this.txtDocumentCode.Del = false;
            this.txtDocumentCode.DependingRS = null;
            this.txtDocumentCode.ExtraDataLink = null;
            this.txtDocumentCode.ForeColor = System.Drawing.Color.Black;
            this.txtDocumentCode.IsCTLMOwned = false;
            this.txtDocumentCode.IsPassword = false;
            this.txtDocumentCode.Location = new System.Drawing.Point(449, 78);
            this.txtDocumentCode.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDocumentCode.Multiline = false;
            this.txtDocumentCode.Name = "txtDocumentCode";
            this.txtDocumentCode.Order = 0;
            this.txtDocumentCode.ParentConn = null;
            this.txtDocumentCode.ParentDA = null;
            this.txtDocumentCode.PK = false;
            this.txtDocumentCode.Protected = false;
            this.txtDocumentCode.ReadOnly = false;
            this.txtDocumentCode.Search = false;
            this.txtDocumentCode.Size = new System.Drawing.Size(100, 37);
            this.txtDocumentCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDocumentCode.TabIndex = 9;
            this.txtDocumentCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDocumentCode.Upp = false;
            this.txtDocumentCode.Value = "";
            // 
            // fDocumentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1891, 1082);
            this.Controls.Add(this.fsFileData);
            this.Controls.Add(this.FdcPDFData);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lstFlags);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtSection);
            this.Controls.Add(this.txtSubtype);
            this.Controls.Add(this.txtTypeCode);
            this.Controls.Add(this.txtEdition);
            this.Controls.Add(this.txtDocumentCode);
            this.Controls.Add(this.CTLM);
            this.Controls.Add(this.VS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fDocumentControl";
            this.Text = "Document Control";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackDataGridView.EspackDataGridViewControl VS;
        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackTextBox txtDocumentCode;
        private EspackFormControlsNS.EspackTextBox txtEdition;
        private EspackFormControlsNS.EspackTextBox txtTypeCode;
        private EspackFormControlsNS.EspackTextBox txtSubtype;
        private EspackFormControlsNS.EspackTextBox txtSection;
        private EspackFormControlsNS.EspackTextBox txtTitle;
        private EspackFormControlsNS.EspackCheckedListBox lstFlags;
        private EspackFormControlsNS.EspackTextBox txtStatus;
        private EspackFormControlsNS.EspackFileDataContainerPreview FdcPDFData;
        private EspackFormControlsNS.EspackFileStreamControl fsFileData;
    }
}