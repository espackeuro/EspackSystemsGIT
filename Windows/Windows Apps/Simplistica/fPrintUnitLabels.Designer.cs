namespace Simplistica
{
    partial class fPrintUnitLabels
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
            this.txtQty = new EspackFormControlsNS.EspackNumericTextBox();
            this.cboService = new EspackFormControlsNS.EspackComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtDesService = new EspackFormControlsNS.EspackTextBox();
            this.txtQtyLabel = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtCharacter = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtPrinter = new EspackFormControlsNS.EspackNumericTextBox();
            this.SuspendLayout();
            // 
            // txtQty
            // 
            this.txtQty.Add = false;
            this.txtQty.AllowSpace = false;
            this.txtQty.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtQty.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtQty.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtQty.Caption = "Number of labels";
            this.txtQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtQty.DBField = null;
            this.txtQty.DBFieldType = null;
            this.txtQty.DefaultValue = null;
            this.txtQty.Del = false;
            this.txtQty.DependingRS = null;
            this.txtQty.ExtraDataLink = null;
            this.txtQty.ForeColor = System.Drawing.Color.Gray;
            this.txtQty.IsCTLMOwned = false;
            this.txtQty.IsPassword = false;
            this.txtQty.Length = 0;
            this.txtQty.Location = new System.Drawing.Point(12, 68);
            this.txtQty.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtQty.Mask = false;
            this.txtQty.Multiline = false;
            this.txtQty.Name = "txtQty";
            this.txtQty.Order = 0;
            this.txtQty.ParentConn = null;
            this.txtQty.ParentDA = null;
            this.txtQty.PK = false;
            this.txtQty.Precision = 0;
            this.txtQty.Protected = false;
            this.txtQty.ReadOnly = false;
            this.txtQty.Search = false;
            this.txtQty.Size = new System.Drawing.Size(116, 44);
            this.txtQty.Status = CommonTools.EnumStatus.SEARCH;
            this.txtQty.TabIndex = 0;
            this.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQty.ThousandsGroup = false;
            this.txtQty.Upp = true;
            this.txtQty.Value = null;
            this.txtQty.WordWrap = true;
            // 
            // cboService
            // 
            this.cboService.Add = false;
            this.cboService.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboService.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboService.BackColor = System.Drawing.Color.White;
            this.cboService.Caption = "Service";
            this.cboService.DataSource = null;
            this.cboService.DBField = null;
            this.cboService.DBFieldType = null;
            this.cboService.DefaultValue = null;
            this.cboService.Del = false;
            this.cboService.DependingRS = null;
            this.cboService.DisplayMember = "";
            this.cboService.ExtraDataLink = null;
            this.cboService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboService.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboService.ForeColor = System.Drawing.Color.Black;
            this.cboService.FormattingEnabled = true;
            this.cboService.IsCTLMOwned = false;
            this.cboService.Location = new System.Drawing.Point(12, 25);
            this.cboService.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboService.Name = "cboService";
            this.cboService.Order = 0;
            this.cboService.ParentConn = null;
            this.cboService.ParentDA = null;
            this.cboService.PK = false;
            this.cboService.Protected = false;
            this.cboService.ReadOnly = false;
            this.cboService.Search = false;
            this.cboService.SelectedItem = null;
            this.cboService.SelectedValue = null;
            this.cboService.Size = new System.Drawing.Size(160, 40);
            this.cboService.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboService.TabIndex = 2;
            this.cboService.TBDescription = null;
            this.cboService.Upp = false;
            this.cboService.Value = "";
            this.cboService.ValueMember = "";
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(360, 152);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtDesService
            // 
            this.txtDesService.Add = false;
            this.txtDesService.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDesService.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDesService.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtDesService.Caption = "";
            this.txtDesService.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDesService.DBField = null;
            this.txtDesService.DBFieldType = null;
            this.txtDesService.DefaultValue = null;
            this.txtDesService.Del = false;
            this.txtDesService.DependingRS = null;
            this.txtDesService.ExtraDataLink = null;
            this.txtDesService.ForeColor = System.Drawing.Color.Gray;
            this.txtDesService.IsCTLMOwned = false;
            this.txtDesService.IsPassword = false;
            this.txtDesService.Location = new System.Drawing.Point(178, 25);
            this.txtDesService.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDesService.Multiline = true;
            this.txtDesService.Name = "txtDesService";
            this.txtDesService.Order = 0;
            this.txtDesService.ParentConn = null;
            this.txtDesService.ParentDA = null;
            this.txtDesService.PK = false;
            this.txtDesService.Protected = false;
            this.txtDesService.ReadOnly = true;
            this.txtDesService.Search = false;
            this.txtDesService.Size = new System.Drawing.Size(257, 24);
            this.txtDesService.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDesService.TabIndex = 5;
            this.txtDesService.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDesService.Upp = false;
            this.txtDesService.Value = "";
            this.txtDesService.WordWrap = true;
            // 
            // txtQtyLabel
            // 
            this.txtQtyLabel.Add = false;
            this.txtQtyLabel.AllowSpace = false;
            this.txtQtyLabel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtQtyLabel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtQtyLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtQtyLabel.Caption = "Copies per label";
            this.txtQtyLabel.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtQtyLabel.DBField = null;
            this.txtQtyLabel.DBFieldType = null;
            this.txtQtyLabel.DefaultValue = null;
            this.txtQtyLabel.Del = false;
            this.txtQtyLabel.DependingRS = null;
            this.txtQtyLabel.ExtraDataLink = null;
            this.txtQtyLabel.ForeColor = System.Drawing.Color.Gray;
            this.txtQtyLabel.IsCTLMOwned = false;
            this.txtQtyLabel.IsPassword = false;
            this.txtQtyLabel.Length = 0;
            this.txtQtyLabel.Location = new System.Drawing.Point(204, 68);
            this.txtQtyLabel.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtQtyLabel.Mask = false;
            this.txtQtyLabel.Multiline = false;
            this.txtQtyLabel.Name = "txtQtyLabel";
            this.txtQtyLabel.Order = 0;
            this.txtQtyLabel.ParentConn = null;
            this.txtQtyLabel.ParentDA = null;
            this.txtQtyLabel.PK = false;
            this.txtQtyLabel.Precision = 0;
            this.txtQtyLabel.Protected = false;
            this.txtQtyLabel.ReadOnly = true;
            this.txtQtyLabel.Search = false;
            this.txtQtyLabel.Size = new System.Drawing.Size(149, 44);
            this.txtQtyLabel.Status = CommonTools.EnumStatus.SEARCH;
            this.txtQtyLabel.TabIndex = 9;
            this.txtQtyLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtQtyLabel.ThousandsGroup = false;
            this.txtQtyLabel.Upp = true;
            this.txtQtyLabel.Value = null;
            this.txtQtyLabel.WordWrap = true;
            // 
            // txtCharacter
            // 
            this.txtCharacter.Add = false;
            this.txtCharacter.AllowSpace = false;
            this.txtCharacter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtCharacter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtCharacter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCharacter.Caption = "Char";
            this.txtCharacter.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCharacter.DBField = null;
            this.txtCharacter.DBFieldType = null;
            this.txtCharacter.DefaultValue = null;
            this.txtCharacter.Del = false;
            this.txtCharacter.DependingRS = null;
            this.txtCharacter.ExtraDataLink = null;
            this.txtCharacter.ForeColor = System.Drawing.Color.Gray;
            this.txtCharacter.IsCTLMOwned = false;
            this.txtCharacter.IsPassword = false;
            this.txtCharacter.Length = 0;
            this.txtCharacter.Location = new System.Drawing.Point(134, 68);
            this.txtCharacter.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtCharacter.Mask = false;
            this.txtCharacter.Multiline = false;
            this.txtCharacter.Name = "txtCharacter";
            this.txtCharacter.Order = 0;
            this.txtCharacter.ParentConn = null;
            this.txtCharacter.ParentDA = null;
            this.txtCharacter.PK = false;
            this.txtCharacter.Precision = 0;
            this.txtCharacter.Protected = false;
            this.txtCharacter.ReadOnly = false;
            this.txtCharacter.Search = false;
            this.txtCharacter.Size = new System.Drawing.Size(38, 44);
            this.txtCharacter.Status = CommonTools.EnumStatus.SEARCH;
            this.txtCharacter.TabIndex = 10;
            this.txtCharacter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCharacter.ThousandsGroup = false;
            this.txtCharacter.Upp = true;
            this.txtCharacter.Value = null;
            this.txtCharacter.WordWrap = true;
            // 
            // txtPrinter
            // 
            this.txtPrinter.Add = false;
            this.txtPrinter.AllowSpace = false;
            this.txtPrinter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPrinter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPrinter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPrinter.Caption = "Printer";
            this.txtPrinter.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPrinter.DBField = null;
            this.txtPrinter.DBFieldType = null;
            this.txtPrinter.DefaultValue = null;
            this.txtPrinter.Del = false;
            this.txtPrinter.DependingRS = null;
            this.txtPrinter.ExtraDataLink = null;
            this.txtPrinter.ForeColor = System.Drawing.Color.Gray;
            this.txtPrinter.IsCTLMOwned = false;
            this.txtPrinter.IsPassword = false;
            this.txtPrinter.Length = 0;
            this.txtPrinter.Location = new System.Drawing.Point(12, 131);
            this.txtPrinter.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtPrinter.Mask = false;
            this.txtPrinter.Multiline = false;
            this.txtPrinter.Name = "txtPrinter";
            this.txtPrinter.Order = 0;
            this.txtPrinter.ParentConn = null;
            this.txtPrinter.ParentDA = null;
            this.txtPrinter.PK = false;
            this.txtPrinter.Precision = 0;
            this.txtPrinter.Protected = false;
            this.txtPrinter.ReadOnly = true;
            this.txtPrinter.Search = false;
            this.txtPrinter.Size = new System.Drawing.Size(160, 44);
            this.txtPrinter.Status = CommonTools.EnumStatus.SEARCH;
            this.txtPrinter.TabIndex = 11;
            this.txtPrinter.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPrinter.ThousandsGroup = false;
            this.txtPrinter.Upp = true;
            this.txtPrinter.Value = null;
            this.txtPrinter.WordWrap = true;
            // 
            // fPrintUnitLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 190);
            this.Controls.Add(this.txtPrinter);
            this.Controls.Add(this.txtCharacter);
            this.Controls.Add(this.txtQtyLabel);
            this.Controls.Add(this.txtDesService);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cboService);
            this.Controls.Add(this.txtQty);
            this.Name = "fPrintUnitLabels";
            this.ShowIcon = false;
            this.Text = "Unit Labels";
            this.ResumeLayout(false);

        }

        #endregion
        private EspackFormControlsNS.EspackComboBox cboService;
        private System.Windows.Forms.Button btnPrint;
        private EspackFormControlsNS.EspackTextBox txtDesService;
        private EspackFormControlsNS.EspackNumericTextBox txtQty;
        private EspackFormControlsNS.EspackNumericTextBox txtQtyLabel;
        private EspackFormControlsNS.EspackNumericTextBox txtCharacter;
        private EspackFormControlsNS.EspackNumericTextBox txtPrinter;
    }
}