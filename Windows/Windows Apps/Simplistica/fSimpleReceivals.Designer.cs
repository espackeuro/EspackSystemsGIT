﻿namespace Simplistica
{
    partial class fSimpleReceivals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSimpleReceivals));
            System.Windows.Forms.DataGridViewRow dataGridViewRow1 = new System.Windows.Forms.DataGridViewRow();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btnReceived = new System.Windows.Forms.ToolStripButton();
            this.btnLabelCMs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnACheck = new System.Windows.Forms.ToolStripButton();
            this.lstFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtDesServicio = new EspackFormControlsNS.EspackTextBox();
            this.cboServicio = new EspackFormControlsNS.EspackComboBox();
            this.txtNotes = new EspackFormControlsNS.EspackTextBox();
            this.txtSuppDoc = new EspackFormControlsNS.EspackTextBox();
            this.txtFecha = new EspackFormControlsNS.EspackDateTimePicker();
            this.txtEntrada = new EspackFormControlsNS.EspackTextBox();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.VS = new EspackDataGridView.EspackDataGridViewControl();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReceived,
            this.btnLabelCMs,
            this.toolStripSeparator1,
            this.btnACheck});
            this.toolStrip.Location = new System.Drawing.Point(436, 21);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(241, 27);
            this.toolStrip.TabIndex = 30;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btnReceived
            // 
            this.btnReceived.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReceived.Image = ((System.Drawing.Image)(resources.GetObject("btnReceived.Image")));
            this.btnReceived.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReceived.Name = "btnReceived";
            this.btnReceived.Size = new System.Drawing.Size(73, 24);
            this.btnReceived.Text = "Received";
            this.btnReceived.Click += new System.EventHandler(this.btnReceived_Click);
            // 
            // btnLabelCMs
            // 
            this.btnLabelCMs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLabelCMs.Image = ((System.Drawing.Image)(resources.GetObject("btnLabelCMs.Image")));
            this.btnLabelCMs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLabelCMs.Name = "btnLabelCMs";
            this.btnLabelCMs.Size = new System.Drawing.Size(81, 24);
            this.btnLabelCMs.Text = "Label CMs";
            this.btnLabelCMs.Click += new System.EventHandler(this.btnLabelCMs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnACheck
            // 
            this.btnACheck.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnACheck.Image = ((System.Drawing.Image)(resources.GetObject("btnACheck.Image")));
            this.btnACheck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnACheck.Name = "btnACheck";
            this.btnACheck.Size = new System.Drawing.Size(68, 24);
            this.btnACheck.Text = "A-Check";
            this.btnACheck.Click += new System.EventHandler(this.btnACheck_Click);
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
            this.lstFlags.Location = new System.Drawing.Point(15, 297);
            this.lstFlags.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
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
            this.lstFlags.Size = new System.Drawing.Size(720, 66);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 31;
            this.lstFlags.TBDescription = null;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            this.lstFlags.ValueMember = "";
            // 
            // txtDesServicio
            // 
            this.txtDesServicio.Add = false;
            this.txtDesServicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDesServicio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDesServicio.BackColor = System.Drawing.Color.White;
            this.txtDesServicio.Caption = "";
            this.txtDesServicio.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDesServicio.DBField = null;
            this.txtDesServicio.DBFieldType = null;
            this.txtDesServicio.DefaultValue = null;
            this.txtDesServicio.Del = false;
            this.txtDesServicio.DependingRS = null;
            this.txtDesServicio.ExtraDataLink = null;
            this.txtDesServicio.ForeColor = System.Drawing.Color.Black;
            this.txtDesServicio.IsCTLMOwned = false;
            this.txtDesServicio.IsPassword = false;
            this.txtDesServicio.Location = new System.Drawing.Point(224, 173);
            this.txtDesServicio.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
            this.txtDesServicio.Multiline = true;
            this.txtDesServicio.Name = "txtDesServicio";
            this.txtDesServicio.Order = 0;
            this.txtDesServicio.ParentConn = null;
            this.txtDesServicio.ParentDA = null;
            this.txtDesServicio.PK = false;
            this.txtDesServicio.Protected = false;
            this.txtDesServicio.ReadOnly = false;
            this.txtDesServicio.Search = false;
            this.txtDesServicio.Size = new System.Drawing.Size(509, 47);
            this.txtDesServicio.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDesServicio.TabIndex = 15;
            this.txtDesServicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDesServicio.Upp = false;
            this.txtDesServicio.Value = "";
            this.txtDesServicio.WordWrap = true;
            // 
            // cboServicio
            // 
            this.cboServicio.Add = false;
            this.cboServicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboServicio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboServicio.BackColor = System.Drawing.Color.White;
            this.cboServicio.Caption = "Service";
            this.cboServicio.DataSource = null;
            this.cboServicio.DBField = null;
            this.cboServicio.DBFieldType = null;
            this.cboServicio.DefaultValue = null;
            this.cboServicio.Del = false;
            this.cboServicio.DependingRS = null;
            this.cboServicio.DisplayMember = "";
            this.cboServicio.ExtraDataLink = null;
            this.cboServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboServicio.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboServicio.ForeColor = System.Drawing.Color.Black;
            this.cboServicio.FormattingEnabled = true;
            this.cboServicio.IsCTLMOwned = false;
            this.cboServicio.Location = new System.Drawing.Point(17, 173);
            this.cboServicio.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
            this.cboServicio.Name = "cboServicio";
            this.cboServicio.Order = 0;
            this.cboServicio.ParentConn = null;
            this.cboServicio.ParentDA = null;
            this.cboServicio.PK = false;
            this.cboServicio.Protected = false;
            this.cboServicio.ReadOnly = false;
            this.cboServicio.Search = false;
            this.cboServicio.SelectedItem = null;
            this.cboServicio.SelectedValue = null;
            this.cboServicio.Size = new System.Drawing.Size(173, 47);
            this.cboServicio.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboServicio.TabIndex = 13;
            this.cboServicio.TBDescription = null;
            this.cboServicio.Upp = false;
            this.cboServicio.Value = "";
            this.cboServicio.ValueMember = "";
            // 
            // txtNotes
            // 
            this.txtNotes.Add = false;
            this.txtNotes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtNotes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtNotes.BackColor = System.Drawing.Color.White;
            this.txtNotes.Caption = "Notes";
            this.txtNotes.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNotes.DBField = null;
            this.txtNotes.DBFieldType = null;
            this.txtNotes.DefaultValue = null;
            this.txtNotes.Del = false;
            this.txtNotes.DependingRS = null;
            this.txtNotes.ExtraDataLink = null;
            this.txtNotes.ForeColor = System.Drawing.Color.Black;
            this.txtNotes.IsCTLMOwned = false;
            this.txtNotes.IsPassword = false;
            this.txtNotes.Location = new System.Drawing.Point(222, 234);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
            this.txtNotes.Multiline = false;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Order = 0;
            this.txtNotes.ParentConn = null;
            this.txtNotes.ParentDA = null;
            this.txtNotes.PK = false;
            this.txtNotes.Protected = false;
            this.txtNotes.ReadOnly = false;
            this.txtNotes.Search = false;
            this.txtNotes.Size = new System.Drawing.Size(511, 49);
            this.txtNotes.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtNotes.TabIndex = 11;
            this.txtNotes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNotes.Upp = false;
            this.txtNotes.Value = "";
            this.txtNotes.WordWrap = true;
            // 
            // txtSuppDoc
            // 
            this.txtSuppDoc.Add = false;
            this.txtSuppDoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSuppDoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSuppDoc.BackColor = System.Drawing.Color.White;
            this.txtSuppDoc.Caption = "Supplier Doc";
            this.txtSuppDoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSuppDoc.DBField = null;
            this.txtSuppDoc.DBFieldType = null;
            this.txtSuppDoc.DefaultValue = null;
            this.txtSuppDoc.Del = false;
            this.txtSuppDoc.DependingRS = null;
            this.txtSuppDoc.ExtraDataLink = null;
            this.txtSuppDoc.ForeColor = System.Drawing.Color.Black;
            this.txtSuppDoc.IsCTLMOwned = false;
            this.txtSuppDoc.IsPassword = false;
            this.txtSuppDoc.Location = new System.Drawing.Point(17, 234);
            this.txtSuppDoc.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
            this.txtSuppDoc.Multiline = false;
            this.txtSuppDoc.Name = "txtSuppDoc";
            this.txtSuppDoc.Order = 0;
            this.txtSuppDoc.ParentConn = null;
            this.txtSuppDoc.ParentDA = null;
            this.txtSuppDoc.PK = false;
            this.txtSuppDoc.Protected = false;
            this.txtSuppDoc.ReadOnly = false;
            this.txtSuppDoc.Search = false;
            this.txtSuppDoc.Size = new System.Drawing.Size(174, 49);
            this.txtSuppDoc.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtSuppDoc.TabIndex = 7;
            this.txtSuppDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSuppDoc.Upp = false;
            this.txtSuppDoc.Value = "";
            this.txtSuppDoc.WordWrap = true;
            // 
            // txtFecha
            // 
            this.txtFecha.Add = false;
            this.txtFecha.BackColor = System.Drawing.Color.White;
            this.txtFecha.BorderColor = System.Drawing.Color.White;
            this.txtFecha.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.txtFecha.Caption = "Receival Date";
            this.txtFecha.Checked = true;
            this.txtFecha.CustomFormat = "dd/MM/yyyy H:mm";
            this.txtFecha.DBField = null;
            this.txtFecha.DBFieldType = null;
            this.txtFecha.DefaultValue = null;
            this.txtFecha.Del = false;
            this.txtFecha.DependingRS = null;
            this.txtFecha.ExtraDataLink = null;
            this.txtFecha.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFecha.ForeColor = System.Drawing.Color.Black;
            this.txtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFecha.IsCTLMOwned = false;
            this.txtFecha.Location = new System.Drawing.Point(224, 113);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
            this.txtFecha.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Nullable = true;
            this.txtFecha.Order = 0;
            this.txtFecha.ParentConn = null;
            this.txtFecha.ParentDA = null;
            this.txtFecha.PK = false;
            this.txtFecha.Protected = false;
            this.txtFecha.ReadOnly = false;
            this.txtFecha.Search = false;
            this.txtFecha.ShowCheckBox = true;
            this.txtFecha.Size = new System.Drawing.Size(509, 47);
            this.txtFecha.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtFecha.TabIndex = 5;
            this.txtFecha.Text = "22/06/2016 13:36";
            this.txtFecha.Upp = false;
            this.txtFecha.Value = new System.DateTime(2016, 6, 22, 13, 36, 41, 91);
            // 
            // txtEntrada
            // 
            this.txtEntrada.Add = false;
            this.txtEntrada.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtEntrada.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtEntrada.BackColor = System.Drawing.Color.White;
            this.txtEntrada.Caption = "Receival Number";
            this.txtEntrada.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEntrada.DBField = null;
            this.txtEntrada.DBFieldType = null;
            this.txtEntrada.DefaultValue = null;
            this.txtEntrada.Del = false;
            this.txtEntrada.DependingRS = null;
            this.txtEntrada.ExtraDataLink = null;
            this.txtEntrada.ForeColor = System.Drawing.Color.Black;
            this.txtEntrada.IsCTLMOwned = false;
            this.txtEntrada.IsPassword = false;
            this.txtEntrada.Location = new System.Drawing.Point(17, 113);
            this.txtEntrada.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
            this.txtEntrada.Multiline = true;
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Order = 0;
            this.txtEntrada.ParentConn = null;
            this.txtEntrada.ParentDA = null;
            this.txtEntrada.PK = false;
            this.txtEntrada.Protected = false;
            this.txtEntrada.ReadOnly = false;
            this.txtEntrada.Search = false;
            this.txtEntrada.Size = new System.Drawing.Size(171, 51);
            this.txtEntrada.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtEntrada.TabIndex = 1;
            this.txtEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEntrada.Upp = false;
            this.txtEntrada.Value = "";
            this.txtEntrada.WordWrap = true;
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
            this.CTLM.Location = new System.Drawing.Point(17, 16);
            this.CTLM.Margin = new System.Windows.Forms.Padding(4);
            this.CTLM.MsgStatusInfoLabel = null;
            this.CTLM.MsgStatusLabel = null;
            this.CTLM.Name = "CTLM";
            this.CTLM.ReQuery = false;
            this.CTLM.Size = new System.Drawing.Size(310, 31);
            this.CTLM.sSPAdd = "";
            this.CTLM.sSPDel = "";
            this.CTLM.sSPUpp = "";
            this.CTLM.StatusBarProgress = null;
            this.CTLM.TabIndex = 0;
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
            this.VS.Location = new System.Drawing.Point(16, 375);
            this.VS.Margin = new System.Windows.Forms.Padding(5);
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
            dataGridViewRow1.Height = 24;
            this.VS.RowTemplate = dataGridViewRow1;
            this.VS.Search = false;
            this.VS.Size = new System.Drawing.Size(717, 336);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.Status = CommonTools.EnumStatus.SEARCH;
            this.VS.TabIndex = 39;
            this.VS.Upp = false;
            this.VS.Value = null;
            // 
            // fSimpleReceivals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 800);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.lstFlags);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.txtDesServicio);
            this.Controls.Add(this.cboServicio);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtSuppDoc);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.txtEntrada);
            this.Controls.Add(this.CTLM);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fSimpleReceivals";
            this.ShowIcon = false;
            this.Text = "Receivals";
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackTextBox txtEntrada;
        private EspackFormControlsNS.EspackDateTimePicker txtFecha;
        private EspackFormControlsNS.EspackTextBox txtSuppDoc;
        private EspackFormControlsNS.EspackTextBox txtNotes;
        private EspackFormControlsNS.EspackComboBox cboServicio;
        private EspackFormControlsNS.EspackTextBox txtDesServicio;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btnLabelCMs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnReceived;
        private EspackFormControlsNS.EspackCheckedListBox lstFlags;
        private System.Windows.Forms.ToolStripButton btnACheck;
        private EspackDataGridView.EspackDataGridViewControl VS;
    }
}