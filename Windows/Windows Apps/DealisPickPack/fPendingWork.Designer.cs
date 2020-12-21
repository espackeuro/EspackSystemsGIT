
namespace DealisPickPack
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
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtRouteDescription = new EspackFormControlsNS.EspackTextBox();
            this.cboRoute = new EspackFormControlsNS.EspackComboBox();
            this.VS = new System.Windows.Forms.DataGridView();
            this.Route = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Finis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyPending = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dealer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DealerDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderItemNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.VS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::DealerPickPack.Properties.Resources.reload_24;
            this.btnRefresh.Location = new System.Drawing.Point(477, 53);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(39, 24);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.txtRouteDescription.Location = new System.Drawing.Point(148, 39);
            this.txtRouteDescription.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtRouteDescription.Multiline = true;
            this.txtRouteDescription.Name = "txtRouteDescription";
            this.txtRouteDescription.Order = 0;
            this.txtRouteDescription.ParentConn = null;
            this.txtRouteDescription.ParentDA = null;
            this.txtRouteDescription.PK = false;
            this.txtRouteDescription.Protected = false;
            this.txtRouteDescription.ReadOnly = true;
            this.txtRouteDescription.Search = false;
            this.txtRouteDescription.Size = new System.Drawing.Size(322, 38);
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
            this.cboRoute.Location = new System.Drawing.Point(12, 37);
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
            this.cboRoute.Size = new System.Drawing.Size(130, 40);
            this.cboRoute.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboRoute.TabIndex = 0;
            this.cboRoute.TBDescription = null;
            this.cboRoute.Upp = false;
            this.cboRoute.Value = "";
            this.cboRoute.ValueMember = "";
            // 
            // VS
            // 
            this.VS.AllowUserToAddRows = false;
            this.VS.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VS.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.VS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Route,
            this.Finis,
            this.Qty,
            this.QtyPending,
            this.Dealer,
            this.DealerDesc,
            this.OrderNumber,
            this.OrderItemNumber});
            this.VS.Location = new System.Drawing.Point(13, 84);
            this.VS.Name = "VS";
            this.VS.ReadOnly = true;
            this.VS.Size = new System.Drawing.Size(775, 276);
            this.VS.TabIndex = 15;
            // 
            // Route
            // 
            this.Route.HeaderText = "ROUTE";
            this.Route.Name = "Route";
            this.Route.ReadOnly = true;
            this.Route.Width = 70;
            // 
            // Finis
            // 
            this.Finis.HeaderText = "FINIS";
            this.Finis.Name = "Finis";
            this.Finis.ReadOnly = true;
            this.Finis.Width = 70;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "QTY";
            this.Qty.Name = "Qty";
            this.Qty.ReadOnly = true;
            this.Qty.Width = 50;
            // 
            // QtyPending
            // 
            this.QtyPending.HeaderText = "PENDING QTY";
            this.QtyPending.Name = "QtyPending";
            this.QtyPending.ReadOnly = true;
            this.QtyPending.Width = 105;
            // 
            // Dealer
            // 
            this.Dealer.HeaderText = "DEALER";
            this.Dealer.Name = "Dealer";
            this.Dealer.ReadOnly = true;
            // 
            // DealerDesc
            // 
            this.DealerDesc.HeaderText = "DESCRIPTION";
            this.DealerDesc.Name = "DealerDesc";
            this.DealerDesc.ReadOnly = true;
            // 
            // OrderNumber
            // 
            this.OrderNumber.HeaderText = "ORDER NUMBER";
            this.OrderNumber.Name = "OrderNumber";
            this.OrderNumber.ReadOnly = true;
            // 
            // OrderItemNumber
            // 
            this.OrderItemNumber.HeaderText = "ORDER ITEM";
            this.OrderItemNumber.Name = "OrderItemNumber";
            this.OrderItemNumber.ReadOnly = true;
            // 
            // fPendingWork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.VS);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtRouteDescription);
            this.Controls.Add(this.cboRoute);
            this.Name = "fPendingWork";
            this.Text = "fPendingWork";
            ((System.ComponentModel.ISupportInitialize)(this.VS)).EndInit();
            this.ResumeLayout(false);

        }

        private EspackFormControlsNS.EspackComboBox cboRoute;
        private EspackFormControlsNS.EspackTextBox txtRouteDescription;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView VS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Route;
        private System.Windows.Forms.DataGridViewTextBoxColumn Finis;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyPending;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dealer;
        private System.Windows.Forms.DataGridViewTextBoxColumn DealerDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrderItemNumber;
    }
}