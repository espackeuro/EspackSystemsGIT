namespace Sistemas
{
    partial class fAlias
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
            System.Windows.Forms.DataGridViewRow dataGridViewRow2 = new System.Windows.Forms.DataGridViewRow();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDomain = new EspackFormControlsNS.EspackTextBox();
            this.txtLocalPart = new EspackFormControlsNS.EspackTextBox();
            this.txtAddress = new EspackFormControlsNS.EspackTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstCOD3 = new EspackFormControlsNS.EspackCheckedListBox();
            this.lstFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.VS = new EspackDataGridView.EspackDataGridViewControl();
            this.VSExceptions = new EspackDataGridView.EspackDataGridViewControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.groupBox1.Controls.Add(this.txtDomain);
            this.groupBox1.Controls.Add(this.txtLocalPart);
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(13, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(592, 131);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Header";
            // 
            // txtDomain
            // 
            this.txtDomain.Add = false;
            this.txtDomain.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDomain.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDomain.Caption = "Domain";
            this.txtDomain.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDomain.DBField = null;
            this.txtDomain.DBFieldType = null;
            this.txtDomain.DefaultValue = null;
            this.txtDomain.Del = false;
            this.txtDomain.DependingRS = null;
            this.txtDomain.ExtraDataLink = null;
            this.txtDomain.ForeColor = System.Drawing.Color.Gray;
            this.txtDomain.IsCTLMOwned = false;
            this.txtDomain.Location = new System.Drawing.Point(343, 75);
            this.txtDomain.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDomain.Multiline = true;
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Order = 0;
            this.txtDomain.ParentConn = null;
            this.txtDomain.ParentDA = null;
            
            this.txtDomain.PK = false;
            this.txtDomain.Protected = false;
            this.txtDomain.ReadOnly = true;
            this.txtDomain.Search = false;
            this.txtDomain.Size = new System.Drawing.Size(225, 38);
            this.txtDomain.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDomain.TabIndex = 18;
            this.txtDomain.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDomain.Upp = false;
            
            this.txtDomain.Value = "";
            // 
            // txtLocalPart
            // 
            this.txtLocalPart.Add = false;
            this.txtLocalPart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtLocalPart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtLocalPart.Caption = "LocalPart";
            this.txtLocalPart.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLocalPart.DBField = null;
            this.txtLocalPart.DBFieldType = null;
            this.txtLocalPart.DefaultValue = null;
            this.txtLocalPart.Del = false;
            this.txtLocalPart.DependingRS = null;
            this.txtLocalPart.ExtraDataLink = null;
            this.txtLocalPart.ForeColor = System.Drawing.Color.Gray;
            this.txtLocalPart.IsCTLMOwned = false;
            this.txtLocalPart.Location = new System.Drawing.Point(28, 75);
            this.txtLocalPart.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtLocalPart.Multiline = true;
            this.txtLocalPart.Name = "txtLocalPart";
            this.txtLocalPart.Order = 0;
            this.txtLocalPart.ParentConn = null;
            this.txtLocalPart.ParentDA = null;
            
            this.txtLocalPart.PK = false;
            this.txtLocalPart.Protected = false;
            this.txtLocalPart.ReadOnly = true;
            this.txtLocalPart.Search = false;
            this.txtLocalPart.Size = new System.Drawing.Size(225, 38);
            this.txtLocalPart.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtLocalPart.TabIndex = 16;
            this.txtLocalPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLocalPart.Upp = false;
            
            this.txtLocalPart.Value = "";
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
            this.txtAddress.ForeColor = System.Drawing.Color.Gray;
            this.txtAddress.IsCTLMOwned = false;
            this.txtAddress.Location = new System.Drawing.Point(28, 32);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Order = 0;
            this.txtAddress.ParentConn = null;
            this.txtAddress.ParentDA = null;
            
            this.txtAddress.PK = false;
            this.txtAddress.Protected = false;
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Search = false;
            this.txtAddress.Size = new System.Drawing.Size(540, 38);
            this.txtAddress.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtAddress.TabIndex = 0;
            this.txtAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAddress.Upp = false;
            
            this.txtAddress.Value = "";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.lstCOD3);
            this.groupBox2.Controls.Add(this.lstFlags);
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(13, 174);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(592, 233);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Various";
            // 
            // lstCOD3
            // 
            this.lstCOD3.Add = false;
            this.lstCOD3.Caption = "COD3";
            this.lstCOD3.CheckOnClick = true;
            this.lstCOD3.ColumnWidth = 270;
            this.lstCOD3.DataSource = null;
            this.lstCOD3.DBField = null;
            this.lstCOD3.DBFieldType = null;
            this.lstCOD3.DefaultValue = null;
            this.lstCOD3.Del = false;
            this.lstCOD3.DependingRS = null;
            this.lstCOD3.DisplayMember = "";
            this.lstCOD3.ExtraDataLink = null;
            this.lstCOD3.ForeColor = System.Drawing.Color.Black;
            this.lstCOD3.FormattingEnabled = true;
            this.lstCOD3.IsCTLMOwned = false;
            this.lstCOD3.Location = new System.Drawing.Point(28, 127);
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
            this.lstCOD3.Size = new System.Drawing.Size(540, 88);
            this.lstCOD3.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstCOD3.TabIndex = 2;
            this.lstCOD3.TBDescription = null;
            this.lstCOD3.Upp = false;
            this.lstCOD3.Value = "";
            this.lstCOD3.ValueMember = "";
            // 
            // lstFlags
            // 
            this.lstFlags.Add = false;
            this.lstFlags.Caption = "Flags";
            this.lstFlags.CheckOnClick = true;
            this.lstFlags.ColumnWidth = 180;
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
            this.lstFlags.Location = new System.Drawing.Point(28, 32);
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
            this.lstFlags.Size = new System.Drawing.Size(540, 70);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 0;
            this.lstFlags.TBDescription = null;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            this.lstFlags.ValueMember = "";
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
            this.VS.Location = new System.Drawing.Point(12, 413);
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
            this.VS.Size = new System.Drawing.Size(278, 198);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.Status = CommonTools.EnumStatus.SEARCH;
            this.VS.TabIndex = 3;
            this.VS.Upp = false;
            this.VS.Value = null;
            // 
            // VSExceptions
            // 
            this.VSExceptions.Add = false;
            this.VSExceptions.AllowDelete = false;
            this.VSExceptions.AllowInsert = false;
            this.VSExceptions.AllowUpdate = false;
            this.VSExceptions.AllowUserToAddRows = false;
            this.VSExceptions.AllowUserToResizeColumns = true;
            this.VSExceptions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.VSExceptions.Caption = "Exceptions";
            this.VSExceptions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VSExceptions.ColumnHeadersVisible = true;
            this.VSExceptions.Conn = null;
            this.VSExceptions.CurrentCell = null;
            this.VSExceptions.DataSource = null;
            this.VSExceptions.DBField = null;
            this.VSExceptions.DBFieldType = null;
            this.VSExceptions.DBTable = null;
            this.VSExceptions.DefaultValue = null;
            this.VSExceptions.Del = false;
            this.VSExceptions.DependingRS = null;
            this.VSExceptions.DGFocused = false;
            this.VSExceptions.Dirty = false;
            this.VSExceptions.EspackControlParent = null;
            this.VSExceptions.ExtraDataLink = null;
            this.VSExceptions.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.VSExceptions.HorizontalScrollingOffset = 0;
            this.VSExceptions.IsCTLMOwned = false;
            this.VSExceptions.Location = new System.Drawing.Point(328, 413);
            this.VSExceptions.MsgStatusLabel = null;
            this.VSExceptions.Name = "VSExceptions";
            this.VSExceptions.NumPages = 0;
            this.VSExceptions.Order = 0;
            this.VSExceptions.Page = 0;
            this.VSExceptions.Paginate = false;
            this.VSExceptions.ParentConn = null;
            this.VSExceptions.ParentDA = null;
            this.VSExceptions.PK = false;
            this.VSExceptions.Protected = false;
            this.VSExceptions.ReadOnly = false;
            this.VSExceptions.RowCount = 0;
            this.VSExceptions.RowHeadersVisible = false;
            this.VSExceptions.RowTemplate = dataGridViewRow2;
            this.VSExceptions.Search = false;
            this.VSExceptions.Size = new System.Drawing.Size(277, 198);
            this.VSExceptions.SQL = null;
            this.VSExceptions.sSPAdd = "";
            this.VSExceptions.sSPDel = "";
            this.VSExceptions.sSPUpp = "";
            this.VSExceptions.Status = CommonTools.EnumStatus.SEARCH;
            this.VSExceptions.TabIndex = 5;
            this.VSExceptions.Upp = false;
            this.VSExceptions.Value = null;
            // 
            // fAlias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 650);
            this.Controls.Add(this.VSExceptions);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CTLM);
            this.KeyPreview = true;
            this.Name = "fAlias";
            this.ShowIcon = false;
            this.Text = "Aliases";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private System.Windows.Forms.GroupBox groupBox1;
        private EspackFormControlsNS.EspackTextBox txtAddress;
        private System.Windows.Forms.GroupBox groupBox2;
        private EspackFormControlsNS.EspackTextBox txtDomain;
        private EspackFormControlsNS.EspackTextBox txtLocalPart;
        private EspackFormControlsNS.EspackCheckedListBox lstFlags;
        private EspackDataGridView.EspackDataGridViewControl VS;
        private EspackFormControlsNS.EspackCheckedListBox lstCOD3;
        private EspackDataGridView.EspackDataGridViewControl VSExceptions;
    }
}