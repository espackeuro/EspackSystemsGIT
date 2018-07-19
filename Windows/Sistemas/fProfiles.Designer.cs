using EspackDataGridView;

namespace Sistemas
{
    partial class fProfiles
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new EspackFormControlsNS.EspackTextBox();
            this.lstCOD3 = new EspackFormControlsNS.EspackCheckedListBox();
            this.lstFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtProfileCode = new EspackFormControlsNS.EspackTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstServiceDefaultFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.VS = new EspackDataGridView.EspackDataGridViewControl();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.lstCOD3);
            this.groupBox1.Controls.Add(this.lstFlags);
            this.groupBox1.Controls.Add(this.txtProfileCode);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(593, 184);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Profile Header";
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
            this.txtDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtDescription.IsCTLMOwned = false;
            this.txtDescription.Location = new System.Drawing.Point(240, 33);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Order = 0;
            this.txtDescription.ParentConn = null;
            this.txtDescription.ParentDA = null;
            
            this.txtDescription.PK = false;
            this.txtDescription.Protected = false;
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Search = false;
            this.txtDescription.Size = new System.Drawing.Size(345, 38);
            this.txtDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDescription.TabIndex = 29;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.Upp = false;
            
            this.txtDescription.Value = "";
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
            this.lstCOD3.Location = new System.Drawing.Point(6, 75);
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
            this.lstCOD3.Size = new System.Drawing.Size(400, 92);
            this.lstCOD3.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstCOD3.TabIndex = 26;
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
            this.lstFlags.Location = new System.Drawing.Point(412, 75);
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
            this.lstFlags.Size = new System.Drawing.Size(174, 92);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 25;
            this.lstFlags.TBDescription = null;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            this.lstFlags.ValueMember = "";
            // 
            // txtProfileCode
            // 
            this.txtProfileCode.Add = false;
            this.txtProfileCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtProfileCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtProfileCode.Caption = "Profile Code";
            this.txtProfileCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtProfileCode.DBField = null;
            this.txtProfileCode.DBFieldType = null;
            this.txtProfileCode.DefaultValue = null;
            this.txtProfileCode.Del = false;
            this.txtProfileCode.DependingRS = null;
            this.txtProfileCode.ExtraDataLink = null;
            this.txtProfileCode.ForeColor = System.Drawing.Color.Gray;
            this.txtProfileCode.IsCTLMOwned = false;
            this.txtProfileCode.Location = new System.Drawing.Point(6, 32);
            this.txtProfileCode.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtProfileCode.Multiline = true;
            this.txtProfileCode.Name = "txtProfileCode";
            this.txtProfileCode.Order = 0;
            this.txtProfileCode.ParentConn = null;
            this.txtProfileCode.ParentDA = null;
            
            this.txtProfileCode.PK = false;
            this.txtProfileCode.Protected = false;
            this.txtProfileCode.ReadOnly = true;
            this.txtProfileCode.Search = false;
            this.txtProfileCode.Size = new System.Drawing.Size(225, 40);
            this.txtProfileCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtProfileCode.TabIndex = 0;
            this.txtProfileCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtProfileCode.Upp = false;
            
            this.txtProfileCode.Value = "";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Controls.Add(this.lstServiceDefaultFlags);
            this.groupBox2.Controls.Add(this.VS);
            this.groupBox2.Location = new System.Drawing.Point(9, 231);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(595, 387);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // lstServiceDefaultFlags
            // 
            this.lstServiceDefaultFlags.Add = false;
            this.lstServiceDefaultFlags.Caption = "Service Default Flags";
            this.lstServiceDefaultFlags.CheckOnClick = true;
            this.lstServiceDefaultFlags.ColumnWidth = 180;
            this.lstServiceDefaultFlags.DataSource = null;
            this.lstServiceDefaultFlags.DBField = null;
            this.lstServiceDefaultFlags.DBFieldType = null;
            this.lstServiceDefaultFlags.DefaultValue = null;
            this.lstServiceDefaultFlags.Del = false;
            this.lstServiceDefaultFlags.DependingRS = null;
            this.lstServiceDefaultFlags.DisplayMember = "";
            this.lstServiceDefaultFlags.ExtraDataLink = null;
            this.lstServiceDefaultFlags.ForeColor = System.Drawing.Color.Black;
            this.lstServiceDefaultFlags.FormattingEnabled = true;
            this.lstServiceDefaultFlags.IsCTLMOwned = false;
            this.lstServiceDefaultFlags.Location = new System.Drawing.Point(9, 24);
            this.lstServiceDefaultFlags.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstServiceDefaultFlags.MultiColumn = true;
            this.lstServiceDefaultFlags.Name = "lstServiceDefaultFlags";
            this.lstServiceDefaultFlags.Order = 0;
            this.lstServiceDefaultFlags.ParentConn = null;
            this.lstServiceDefaultFlags.ParentDA = null;
            this.lstServiceDefaultFlags.PK = false;
            this.lstServiceDefaultFlags.Protected = false;
            this.lstServiceDefaultFlags.ReadOnly = false;
            this.lstServiceDefaultFlags.Search = false;
            this.lstServiceDefaultFlags.SelectedItem = null;
            this.lstServiceDefaultFlags.SelectedValue = null;
            this.lstServiceDefaultFlags.Size = new System.Drawing.Size(579, 73);
            this.lstServiceDefaultFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstServiceDefaultFlags.TabIndex = 30;
            this.lstServiceDefaultFlags.TBDescription = null;
            this.lstServiceDefaultFlags.Upp = false;
            this.lstServiceDefaultFlags.Value = "";
            this.lstServiceDefaultFlags.ValueMember = "";
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
            this.VS.FGFocused = false;
            this.VS.FilterDataGrid = null;
            this.VS.FilterRow = null;
            this.VS.FilterRowEnabled = false;
            this.VS.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.VS.HorizontalScrollingOffset = 0;
            this.VS.IsCTLMOwned = false;
            this.VS.IsFilterFocused = false;
            this.VS.Location = new System.Drawing.Point(10, 106);
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
            this.VS.Size = new System.Drawing.Size(579, 264);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.Status = CommonTools.EnumStatus.SEARCH;
            this.VS.TabIndex = 3;
            this.VS.Upp = false;
            this.VS.Value = null;
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
            this.CTLM.Location = new System.Drawing.Point(9, 9);
            this.CTLM.MsgStatusInfoLabel = null;
            this.CTLM.MsgStatusLabel = null;
            this.CTLM.Name = "CTLM";
            this.CTLM.ReQuery = false;
            this.CTLM.Size = new System.Drawing.Size(300, 31);
            this.CTLM.sSPAdd = "";
            this.CTLM.sSPDel = "";
            this.CTLM.sSPUpp = "";
            this.CTLM.StatusBarProgress = null;
            this.CTLM.TabIndex = 1;
            // 
            // fProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 650);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CTLM);
            this.Name = "fProfiles";
            this.ShowIcon = false;
            this.Text = "Profiles";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private System.Windows.Forms.GroupBox groupBox1;
        private EspackFormControlsNS.EspackTextBox txtProfileCode;
        private EspackFormControlsNS.EspackCheckedListBox lstCOD3;
        private EspackFormControlsNS.EspackCheckedListBox lstFlags;
        private EspackDataGridView.EspackDataGridViewControl VS;
        private EspackFormControlsNS.EspackTextBox txtDescription;
        private System.Windows.Forms.GroupBox groupBox2;
        private EspackFormControlsNS.EspackCheckedListBox lstServiceDefaultFlags;
        private EspackDataGridView.EspackDataGridViewColumn ProfileCode;
        private EspackDataGridView.EspackDataGridViewColumn Service;
        private EspackDataGridView.EspackDataGridViewColumn DefaultFlags;
    }
}