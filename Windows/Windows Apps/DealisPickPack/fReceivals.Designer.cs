
namespace DealerPickPack
{
    partial class fReceivals
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
            this.txtDate = new EspackFormControlsNS.EspackDateTimePicker();
            this.txtReceival = new EspackFormControlsNS.EspackTextBox();
            this.VS = new EspackDataGridView.EspackDataGridViewControl();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.SuspendLayout();
            // 
            // txtDate
            // 
            this.txtDate.Add = false;
            this.txtDate.BorderColor = System.Drawing.Color.White;
            this.txtDate.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.txtDate.Caption = "Date";
            this.txtDate.Checked = false;
            this.txtDate.CustomFormat = " ";
            this.txtDate.DBField = null;
            this.txtDate.DBFieldType = null;
            this.txtDate.DefaultValue = null;
            this.txtDate.Del = false;
            this.txtDate.DependingRS = null;
            this.txtDate.ExtraDataLink = null;
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDate.ForeColor = System.Drawing.Color.Black;
            this.txtDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtDate.IsCTLMOwned = false;
            this.txtDate.Location = new System.Drawing.Point(132, 48);
            this.txtDate.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.txtDate.Name = "txtDate";
            this.txtDate.Nullable = true;
            this.txtDate.Order = 0;
            this.txtDate.ParentConn = null;
            this.txtDate.ParentDA = null;
            this.txtDate.PK = false;
            this.txtDate.Protected = false;
            this.txtDate.ReadOnly = false;
            this.txtDate.Search = false;
            this.txtDate.ShowCheckBox = true;
            this.txtDate.Size = new System.Drawing.Size(136, 39);
            this.txtDate.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDate.TabIndex = 59;
            this.txtDate.Text = " ";
            this.txtDate.Upp = false;
            this.txtDate.Value = null;
            // 
            // txtReceival
            // 
            this.txtReceival.Add = false;
            this.txtReceival.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtReceival.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtReceival.Caption = "Receival";
            this.txtReceival.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtReceival.DBField = null;
            this.txtReceival.DBFieldType = null;
            this.txtReceival.DefaultValue = null;
            this.txtReceival.Del = false;
            this.txtReceival.DependingRS = null;
            this.txtReceival.ExtraDataLink = null;
            this.txtReceival.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtReceival.IsCTLMOwned = false;
            this.txtReceival.IsPassword = false;
            this.txtReceival.Location = new System.Drawing.Point(12, 49);
            this.txtReceival.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtReceival.Multiline = true;
            this.txtReceival.Name = "txtReceival";
            this.txtReceival.Order = 0;
            this.txtReceival.ParentConn = null;
            this.txtReceival.ParentDA = null;
            this.txtReceival.PK = false;
            this.txtReceival.Protected = false;
            this.txtReceival.ReadOnly = false;
            this.txtReceival.Search = false;
            this.txtReceival.Size = new System.Drawing.Size(114, 38);
            this.txtReceival.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtReceival.TabIndex = 57;
            this.txtReceival.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtReceival.Upp = false;
            this.txtReceival.Value = "";
            this.txtReceival.WordWrap = true;
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
            this.VS.Location = new System.Drawing.Point(13, 104);
            this.VS.Margin = new System.Windows.Forms.Padding(4);
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
            this.VS.Size = new System.Drawing.Size(748, 336);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.Status = CommonTools.EnumStatus.SEARCH;
            this.VS.TabIndex = 55;
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
            this.CTLM.TabIndex = 54;
            // 
            // fReceivals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 463);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtReceival);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.CTLM);
            this.Name = "fReceivals";
            this.Tag = "";
            this.Text = "Receivals";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.EspackDateTimePicker txtDate;
        private EspackFormControlsNS.EspackTextBox txtReceival;
        private EspackDataGridView.EspackDataGridViewControl VS;
        private EspackFormControlsNS.CTLMantenimiento CTLM;
    }
}