
namespace DealerPickPack
{
    partial class fDeliveries
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
            this.txtDelivery = new EspackFormControlsNS.EspackTextBox();
            this.cboRoute = new EspackFormControlsNS.EspackComboBox();
            this.VS = new EspackDataGridView.EspackDataGridViewControl();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.txtDate = new EspackFormControlsNS.EspackDateTimePicker();
            this.SuspendLayout();
            // 
            // txtDelivery
            // 
            this.txtDelivery.Add = false;
            this.txtDelivery.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDelivery.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDelivery.Caption = "Delivery";
            this.txtDelivery.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDelivery.DBField = null;
            this.txtDelivery.DBFieldType = null;
            this.txtDelivery.DefaultValue = null;
            this.txtDelivery.Del = false;
            this.txtDelivery.DependingRS = null;
            this.txtDelivery.ExtraDataLink = null;
            this.txtDelivery.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtDelivery.IsCTLMOwned = false;
            this.txtDelivery.IsPassword = false;
            this.txtDelivery.Location = new System.Drawing.Point(14, 59);
            this.txtDelivery.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
            this.txtDelivery.Multiline = true;
            this.txtDelivery.Name = "txtDelivery";
            this.txtDelivery.Order = 0;
            this.txtDelivery.ParentConn = null;
            this.txtDelivery.ParentDA = null;
            this.txtDelivery.PK = false;
            this.txtDelivery.Protected = false;
            this.txtDelivery.ReadOnly = false;
            this.txtDelivery.Search = false;
            this.txtDelivery.Size = new System.Drawing.Size(152, 47);
            this.txtDelivery.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDelivery.TabIndex = 51;
            this.txtDelivery.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDelivery.Upp = false;
            this.txtDelivery.Value = "";
            this.txtDelivery.WordWrap = true;
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
            this.cboRoute.Location = new System.Drawing.Point(174, 59);
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
            this.cboRoute.Size = new System.Drawing.Size(150, 47);
            this.cboRoute.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboRoute.TabIndex = 50;
            this.cboRoute.TBDescription = null;
            this.cboRoute.Upp = false;
            this.cboRoute.Value = "";
            this.cboRoute.ValueMember = "";
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
            this.VS.Location = new System.Drawing.Point(14, 115);
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
            this.VS.Size = new System.Drawing.Size(493, 312);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.Status = CommonTools.EnumStatus.SEARCH;
            this.VS.TabIndex = 49;
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
            this.CTLM.Location = new System.Drawing.Point(14, 14);
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
            this.CTLM.TabIndex = 48;
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
            this.txtDate.Location = new System.Drawing.Point(332, 59);
            this.txtDate.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
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
            this.txtDate.Size = new System.Drawing.Size(175, 47);
            this.txtDate.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDate.TabIndex = 52;
            this.txtDate.Text = " ";
            this.txtDate.Upp = false;
            this.txtDate.Value = null;
            // 
            // fDeliveries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 446);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtDelivery);
            this.Controls.Add(this.cboRoute);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.CTLM);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fDeliveries";
            this.Text = "Deliveries";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.EspackTextBox txtDelivery;
        private EspackFormControlsNS.EspackComboBox cboRoute;
        private EspackDataGridView.EspackDataGridViewControl VS;
        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackDateTimePicker txtDate;
    }
}