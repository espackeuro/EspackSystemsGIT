
namespace DealerPickPack
{
    partial class fHUs
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
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.VS = new EspackDataGridView.EspackDataGridViewControl();
            this.txtRouteDescription = new EspackFormControlsNS.EspackTextBox();
            this.cboRoute = new EspackFormControlsNS.EspackComboBox();
            this.txtHU = new EspackFormControlsNS.EspackTextBox();
            this.txtDealer = new EspackFormControlsNS.EspackTextBox();
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
            this.CTLM.Location = new System.Drawing.Point(13, 13);
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
            this.CTLM.TabIndex = 1;
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
            this.VS.Location = new System.Drawing.Point(14, 226);
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
            this.VS.TabIndex = 43;
            this.VS.Upp = false;
            this.VS.Value = null;
            // 
            // txtRouteDescription
            // 
            this.txtRouteDescription.Add = false;
            this.txtRouteDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtRouteDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtRouteDescription.Caption = "Description";
            this.txtRouteDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRouteDescription.DBField = null;
            this.txtRouteDescription.DBFieldType = null;
            this.txtRouteDescription.DefaultValue = null;
            this.txtRouteDescription.Del = false;
            this.txtRouteDescription.DependingRS = null;
            this.txtRouteDescription.ExtraDataLink = null;
            this.txtRouteDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtRouteDescription.IsCTLMOwned = false;
            this.txtRouteDescription.IsPassword = false;
            this.txtRouteDescription.Location = new System.Drawing.Point(194, 113);
            this.txtRouteDescription.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
            this.txtRouteDescription.Multiline = true;
            this.txtRouteDescription.Name = "txtRouteDescription";
            this.txtRouteDescription.Order = 0;
            this.txtRouteDescription.ParentConn = null;
            this.txtRouteDescription.ParentDA = null;
            this.txtRouteDescription.PK = false;
            this.txtRouteDescription.Protected = false;
            this.txtRouteDescription.ReadOnly = true;
            this.txtRouteDescription.Search = false;
            this.txtRouteDescription.Size = new System.Drawing.Size(429, 47);
            this.txtRouteDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtRouteDescription.TabIndex = 45;
            this.txtRouteDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRouteDescription.Upp = false;
            this.txtRouteDescription.Value = "";
            this.txtRouteDescription.WordWrap = true;
            // 
            // cboRoute
            // 
            this.cboRoute.Add = false;
            this.cboRoute.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboRoute.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRoute.Caption = "Route";
            this.cboRoute.DataSource = null;
            this.cboRoute.DBField = null;
            this.cboRoute.DBFieldType = null;
            this.cboRoute.DefaultValue = null;
            this.cboRoute.Del = false;
            this.cboRoute.DependingRS = null;
            this.cboRoute.DisplayMember = "";
            this.cboRoute.ExtraDataLink = null;
            this.cboRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRoute.FormattingEnabled = false;
            this.cboRoute.IsCTLMOwned = false;
            this.cboRoute.Location = new System.Drawing.Point(13, 113);
            this.cboRoute.Margin = new System.Windows.Forms.Padding(4);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Order = 0;
            this.cboRoute.ParentConn = null;
            this.cboRoute.ParentDA = null;
            this.cboRoute.PK = false;
            this.cboRoute.Protected = false;
            this.cboRoute.ReadOnly = false;
            this.cboRoute.Search = false;
            this.cboRoute.SelectedItem = null;
            this.cboRoute.SelectedValue = null;
            this.cboRoute.Size = new System.Drawing.Size(173, 47);
            this.cboRoute.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboRoute.TabIndex = 44;
            this.cboRoute.TBDescription = null;
            this.cboRoute.Upp = false;
            this.cboRoute.Value = "";
            this.cboRoute.ValueMember = "";
            // 
            // txtHU
            // 
            this.txtHU.Add = false;
            this.txtHU.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtHU.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtHU.Caption = "HU";
            this.txtHU.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtHU.DBField = null;
            this.txtHU.DBFieldType = null;
            this.txtHU.DefaultValue = null;
            this.txtHU.Del = false;
            this.txtHU.DependingRS = null;
            this.txtHU.ExtraDataLink = null;
            this.txtHU.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtHU.IsCTLMOwned = false;
            this.txtHU.IsPassword = false;
            this.txtHU.Location = new System.Drawing.Point(13, 58);
            this.txtHU.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
            this.txtHU.Multiline = true;
            this.txtHU.Name = "txtHU";
            this.txtHU.Order = 0;
            this.txtHU.ParentConn = null;
            this.txtHU.ParentDA = null;
            this.txtHU.PK = false;
            this.txtHU.Protected = false;
            this.txtHU.ReadOnly = false;
            this.txtHU.Search = false;
            this.txtHU.Size = new System.Drawing.Size(152, 47);
            this.txtHU.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtHU.TabIndex = 46;
            this.txtHU.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtHU.Upp = false;
            this.txtHU.Value = "";
            this.txtHU.WordWrap = true;
            // 
            // txtDealer
            // 
            this.txtDealer.Add = false;
            this.txtDealer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDealer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDealer.Caption = "Dealer";
            this.txtDealer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDealer.DBField = null;
            this.txtDealer.DBFieldType = null;
            this.txtDealer.DefaultValue = null;
            this.txtDealer.Del = false;
            this.txtDealer.DependingRS = null;
            this.txtDealer.ExtraDataLink = null;
            this.txtDealer.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtDealer.IsCTLMOwned = false;
            this.txtDealer.IsPassword = false;
            this.txtDealer.Location = new System.Drawing.Point(173, 58);
            this.txtDealer.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
            this.txtDealer.Multiline = true;
            this.txtDealer.Name = "txtDealer";
            this.txtDealer.Order = 0;
            this.txtDealer.ParentConn = null;
            this.txtDealer.ParentDA = null;
            this.txtDealer.PK = false;
            this.txtDealer.Protected = false;
            this.txtDealer.ReadOnly = false;
            this.txtDealer.Search = false;
            this.txtDealer.Size = new System.Drawing.Size(152, 47);
            this.txtDealer.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDealer.TabIndex = 47;
            this.txtDealer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDealer.Upp = false;
            this.txtDealer.Value = "";
            this.txtDealer.WordWrap = true;
            // 
            // fHUs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 661);
            this.Controls.Add(this.txtDealer);
            this.Controls.Add(this.txtHU);
            this.Controls.Add(this.txtRouteDescription);
            this.Controls.Add(this.cboRoute);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.CTLM);
            this.Name = "fHUs";
            this.Text = "HUs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackDataGridView.EspackDataGridViewControl VS;
        private EspackFormControlsNS.EspackTextBox txtRouteDescription;
        private EspackFormControlsNS.EspackComboBox cboRoute;
        private EspackFormControlsNS.EspackTextBox txtHU;
        private EspackFormControlsNS.EspackTextBox txtDealer;
    }
}