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
            this.espackTextBox1 = new EspackFormControlsNS.EspackTextBox();
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
            this.cboCOD3.Location = new System.Drawing.Point(13, 134);
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
            // espackTextBox1
            // 
            this.espackTextBox1.Add = false;
            this.espackTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.espackTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.espackTextBox1.Caption = "";
            this.espackTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.espackTextBox1.DBField = null;
            this.espackTextBox1.DBFieldType = null;
            this.espackTextBox1.DefaultValue = null;
            this.espackTextBox1.Del = false;
            this.espackTextBox1.DependingRS = null;
            this.espackTextBox1.ExtraDataLink = null;
            this.espackTextBox1.IsCTLMOwned = false;
            this.espackTextBox1.IsPassword = false;
            this.espackTextBox1.Location = new System.Drawing.Point(173, 149);
            this.espackTextBox1.Multiline = false;
            this.espackTextBox1.Name = "espackTextBox1";
            this.espackTextBox1.Order = 0;
            this.espackTextBox1.ParentConn = null;
            this.espackTextBox1.ParentDA = null;
            this.espackTextBox1.PK = false;
            this.espackTextBox1.Protected = false;
            this.espackTextBox1.ReadOnly = false;
            this.espackTextBox1.Search = false;
            this.espackTextBox1.Size = new System.Drawing.Size(154, 25);
            this.espackTextBox1.Status = CommonTools.EnumStatus.ADDNEW;
            this.espackTextBox1.TabIndex = 118;
            this.espackTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.espackTextBox1.Upp = false;
            this.espackTextBox1.Value = "";
            // 
            // fPurchaseOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.espackTextBox1);
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
        private EspackFormControlsNS.EspackTextBox espackTextBox1;
    }
}