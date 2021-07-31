
namespace DealerPickPack
{
    partial class fPendingWork
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.VS = new System.Windows.Forms.DataGridView();
            this.VSHUCab = new System.Windows.Forms.DataGridView();
            this.VSHUDet = new System.Windows.Forms.DataGridView();
            this.lblPendingHU = new System.Windows.Forms.Label();
            this.btnHUCabDel = new System.Windows.Forms.Button();
            this.btnPrintHULabel = new System.Windows.Forms.Button();
            this.btnHUCabAdd = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnHUDetDel = new System.Windows.Forms.Button();
            this.btnPrintPendingHUs = new System.Windows.Forms.Button();
            this.txtHUTypeDescription = new EspackFormControlsNS.EspackTextBox();
            this.cboHUType = new EspackFormControlsNS.EspackComboBox();
            this.txtRouteDescription = new EspackFormControlsNS.EspackTextBox();
            this.cboRoute = new EspackFormControlsNS.EspackComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.VS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VSHUCab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VSHUDet)).BeginInit();
            this.SuspendLayout();
            // 
            // VS
            // 
            this.VS.AllowUserToAddRows = false;
            this.VS.AllowUserToDeleteRows = false;
            this.VS.AllowUserToResizeRows = false;
            this.VS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.VS.ColumnHeadersHeight = 29;
            this.VS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.VS.EnableHeadersVisualStyles = false;
            this.VS.Location = new System.Drawing.Point(13, 128);
            this.VS.Margin = new System.Windows.Forms.Padding(4);
            this.VS.MultiSelect = false;
            this.VS.Name = "VS";
            this.VS.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VS.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.VS.RowHeadersVisible = false;
            this.VS.RowHeadersWidth = 51;
            this.VS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VS.Size = new System.Drawing.Size(1065, 340);
            this.VS.TabIndex = 15;
            // 
            // VSHUCab
            // 
            this.VSHUCab.AllowUserToAddRows = false;
            this.VSHUCab.AllowUserToDeleteRows = false;
            this.VSHUCab.AllowUserToResizeRows = false;
            this.VSHUCab.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VSHUCab.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.VSHUCab.ColumnHeadersHeight = 29;
            this.VSHUCab.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.VSHUCab.EnableHeadersVisualStyles = false;
            this.VSHUCab.Location = new System.Drawing.Point(13, 491);
            this.VSHUCab.Margin = new System.Windows.Forms.Padding(4);
            this.VSHUCab.MultiSelect = false;
            this.VSHUCab.Name = "VSHUCab";
            this.VSHUCab.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VSHUCab.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.VSHUCab.RowHeadersVisible = false;
            this.VSHUCab.RowHeadersWidth = 51;
            this.VSHUCab.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VSHUCab.Size = new System.Drawing.Size(513, 290);
            this.VSHUCab.TabIndex = 16;
            // 
            // VSHUDet
            // 
            this.VSHUDet.AllowUserToAddRows = false;
            this.VSHUDet.AllowUserToDeleteRows = false;
            this.VSHUDet.AllowUserToResizeRows = false;
            this.VSHUDet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VSHUDet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.VSHUDet.ColumnHeadersHeight = 29;
            this.VSHUDet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.VSHUDet.EnableHeadersVisualStyles = false;
            this.VSHUDet.Location = new System.Drawing.Point(535, 491);
            this.VSHUDet.Margin = new System.Windows.Forms.Padding(4);
            this.VSHUDet.MultiSelect = false;
            this.VSHUDet.Name = "VSHUDet";
            this.VSHUDet.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VSHUDet.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.VSHUDet.RowHeadersVisible = false;
            this.VSHUDet.RowHeadersWidth = 51;
            this.VSHUDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VSHUDet.Size = new System.Drawing.Size(544, 290);
            this.VSHUDet.TabIndex = 17;
            // 
            // lblPendingHU
            // 
            this.lblPendingHU.AutoSize = true;
            this.lblPendingHU.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingHU.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPendingHU.Location = new System.Drawing.Point(9, 471);
            this.lblPendingHU.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPendingHU.Name = "lblPendingHU";
            this.lblPendingHU.Size = new System.Drawing.Size(89, 17);
            this.lblPendingHU.TabIndex = 18;
            this.lblPendingHU.Text = "Pending HU";
            // 
            // btnHUCabDel
            // 
            this.btnHUCabDel.Image = global::DealerPickPack.Properties.Resources.edit_remove_16x16;
            this.btnHUCabDel.Location = new System.Drawing.Point(16, 789);
            this.btnHUCabDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnHUCabDel.Name = "btnHUCabDel";
            this.btnHUCabDel.Size = new System.Drawing.Size(52, 30);
            this.btnHUCabDel.TabIndex = 21;
            this.btnHUCabDel.UseVisualStyleBackColor = true;
            this.btnHUCabDel.Click += new System.EventHandler(this.btnHUCabDel_Click);
            // 
            // btnPrintHULabel
            // 
            this.btnPrintHULabel.Image = global::DealerPickPack.Properties.Resources.printer_16x16;
            this.btnPrintHULabel.Location = new System.Drawing.Point(133, 789);
            this.btnPrintHULabel.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintHULabel.Name = "btnPrintHULabel";
            this.btnPrintHULabel.Size = new System.Drawing.Size(52, 30);
            this.btnPrintHULabel.TabIndex = 20;
            this.btnPrintHULabel.UseVisualStyleBackColor = true;
            this.btnPrintHULabel.Visible = false;
            this.btnPrintHULabel.Click += new System.EventHandler(this.btnPrintHULabel_Click);
            // 
            // btnHUCabAdd
            // 
            this.btnHUCabAdd.Image = global::DealerPickPack.Properties.Resources.edit_add;
            this.btnHUCabAdd.Location = new System.Drawing.Point(193, 788);
            this.btnHUCabAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnHUCabAdd.Name = "btnHUCabAdd";
            this.btnHUCabAdd.Size = new System.Drawing.Size(52, 30);
            this.btnHUCabAdd.TabIndex = 19;
            this.btnHUCabAdd.UseVisualStyleBackColor = true;
            this.btnHUCabAdd.Visible = false;
            this.btnHUCabAdd.Click += new System.EventHandler(this.btnHUCabAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::DealerPickPack.Properties.Resources.quick_restart_16x16;
            this.btnRefresh.Location = new System.Drawing.Point(605, 34);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 30);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHUDetDel
            // 
            this.btnHUDetDel.Image = global::DealerPickPack.Properties.Resources.edit_remove_16x16;
            this.btnHUDetDel.Location = new System.Drawing.Point(535, 789);
            this.btnHUDetDel.Margin = new System.Windows.Forms.Padding(4);
            this.btnHUDetDel.Name = "btnHUDetDel";
            this.btnHUDetDel.Size = new System.Drawing.Size(52, 30);
            this.btnHUDetDel.TabIndex = 22;
            this.btnHUDetDel.UseVisualStyleBackColor = true;
            this.btnHUDetDel.Click += new System.EventHandler(this.btnHUDetDel_Click);
            // 
            // btnPrintPendingHUs
            // 
            this.btnPrintPendingHUs.Image = global::DealerPickPack.Properties.Resources.printer_16x16;
            this.btnPrintPendingHUs.Location = new System.Drawing.Point(665, 34);
            this.btnPrintPendingHUs.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintPendingHUs.Name = "btnPrintPendingHUs";
            this.btnPrintPendingHUs.Size = new System.Drawing.Size(52, 30);
            this.btnPrintPendingHUs.TabIndex = 27;
            this.btnPrintPendingHUs.UseVisualStyleBackColor = true;
            this.btnPrintPendingHUs.Click += new System.EventHandler(this.btnPrintPendingHUs_Click);
            // 
            // txtHUTypeDescription
            // 
            this.txtHUTypeDescription.Add = false;
            this.txtHUTypeDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtHUTypeDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtHUTypeDescription.Caption = "Description";
            this.txtHUTypeDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtHUTypeDescription.DBField = null;
            this.txtHUTypeDescription.DBFieldType = null;
            this.txtHUTypeDescription.DefaultValue = null;
            this.txtHUTypeDescription.Del = false;
            this.txtHUTypeDescription.DependingRS = null;
            this.txtHUTypeDescription.ExtraDataLink = null;
            this.txtHUTypeDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtHUTypeDescription.IsCTLMOwned = false;
            this.txtHUTypeDescription.IsPassword = false;
            this.txtHUTypeDescription.Location = new System.Drawing.Point(168, 71);
            this.txtHUTypeDescription.Margin = new System.Windows.Forms.Padding(4, 20, 4, 4);
            this.txtHUTypeDescription.Multiline = true;
            this.txtHUTypeDescription.Name = "txtHUTypeDescription";
            this.txtHUTypeDescription.Order = 0;
            this.txtHUTypeDescription.ParentConn = null;
            this.txtHUTypeDescription.ParentDA = null;
            this.txtHUTypeDescription.PK = false;
            this.txtHUTypeDescription.Protected = false;
            this.txtHUTypeDescription.ReadOnly = true;
            this.txtHUTypeDescription.Search = false;
            this.txtHUTypeDescription.Size = new System.Drawing.Size(429, 49);
            this.txtHUTypeDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtHUTypeDescription.TabIndex = 26;
            this.txtHUTypeDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtHUTypeDescription.Upp = false;
            this.txtHUTypeDescription.Value = "";
            this.txtHUTypeDescription.WordWrap = true;
            // 
            // cboHUType
            // 
            this.cboHUType.Add = false;
            this.cboHUType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboHUType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboHUType.Caption = "HU Type";
            this.cboHUType.DataSource = null;
            this.cboHUType.DBField = null;
            this.cboHUType.DBFieldType = null;
            this.cboHUType.DefaultValue = null;
            this.cboHUType.Del = false;
            this.cboHUType.DependingRS = null;
            this.cboHUType.DisplayMember = "";
            this.cboHUType.ExtraDataLink = null;
            this.cboHUType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboHUType.FormattingEnabled = false;
            this.cboHUType.IsCTLMOwned = false;
            this.cboHUType.Location = new System.Drawing.Point(13, 71);
            this.cboHUType.Margin = new System.Windows.Forms.Padding(4);
            this.cboHUType.Name = "cboHUType";
            this.cboHUType.Order = 0;
            this.cboHUType.ParentConn = null;
            this.cboHUType.ParentDA = null;
            this.cboHUType.PK = false;
            this.cboHUType.Protected = false;
            this.cboHUType.ReadOnly = false;
            this.cboHUType.Search = false;
            this.cboHUType.SelectedItem = null;
            this.cboHUType.SelectedValue = null;
            this.cboHUType.Size = new System.Drawing.Size(144, 47);
            this.cboHUType.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboHUType.TabIndex = 25;
            this.cboHUType.TBDescription = null;
            this.cboHUType.Upp = false;
            this.cboHUType.Value = "";
            this.cboHUType.ValueMember = "";
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
            this.txtRouteDescription.Location = new System.Drawing.Point(168, 16);
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
            this.txtRouteDescription.Size = new System.Drawing.Size(429, 48);
            this.txtRouteDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtRouteDescription.TabIndex = 13;
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
            this.cboRoute.Location = new System.Drawing.Point(16, 15);
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
            this.cboRoute.Size = new System.Drawing.Size(144, 47);
            this.cboRoute.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboRoute.TabIndex = 0;
            this.cboRoute.TBDescription = null;
            this.cboRoute.Upp = false;
            this.cboRoute.Value = "";
            this.cboRoute.ValueMember = "";
            // 
            // fPendingWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1096, 831);
            this.Controls.Add(this.btnPrintPendingHUs);
            this.Controls.Add(this.txtHUTypeDescription);
            this.Controls.Add(this.cboHUType);
            this.Controls.Add(this.btnHUDetDel);
            this.Controls.Add(this.btnHUCabDel);
            this.Controls.Add(this.btnPrintHULabel);
            this.Controls.Add(this.btnHUCabAdd);
            this.Controls.Add(this.lblPendingHU);
            this.Controls.Add(this.VSHUDet);
            this.Controls.Add(this.VSHUCab);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtRouteDescription);
            this.Controls.Add(this.cboRoute);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fPendingWork";
            this.Text = "fPendingWork";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.VS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VSHUCab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VSHUDet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private EspackFormControlsNS.EspackComboBox cboRoute;
        private EspackFormControlsNS.EspackTextBox txtRouteDescription;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView VS;
        private System.Windows.Forms.DataGridView VSHUCab;
        private System.Windows.Forms.DataGridView VSHUDet;
        private System.Windows.Forms.Label lblPendingHU;
        private System.Windows.Forms.Button btnHUCabAdd;
        private System.Windows.Forms.Button btnPrintHULabel;
        private System.Windows.Forms.Button btnHUCabDel;
        private System.Windows.Forms.Button btnHUDetDel;
        private EspackFormControlsNS.EspackTextBox txtHUTypeDescription;
        private EspackFormControlsNS.EspackComboBox cboHUType;
        private System.Windows.Forms.Button btnPrintPendingHUs;
    }
}