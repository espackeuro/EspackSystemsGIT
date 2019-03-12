namespace Simplistica
{
    partial class fSimpleReferences
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
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.txtReference = new EspackFormControlsNS.EspackTextBox();
            this.txtDescription = new EspackFormControlsNS.EspackTextBox();
            this.txtFase4 = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtPrice = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtPeso = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtNotes = new EspackFormControlsNS.EspackTextBox();
            this.cboServicio = new EspackFormControlsNS.EspackComboBox();
            this.txtDesServicio = new EspackFormControlsNS.EspackTextBox();
            this.lstFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtMin = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtMax = new EspackFormControlsNS.EspackNumericTextBox();
            this.txtSupplier = new EspackFormControlsNS.EspackTextBox();
            this.SuspendLayout();
            // 
            // CTLM
            // 
            this.CTLM.Clear = false;
            this.CTLM.Conn = null;
            this.CTLM.DBTable = null;
            this.CTLM.Dock = System.Windows.Forms.DockStyle.None;
            this.CTLM.Location = new System.Drawing.Point(9, 9);
            this.CTLM.MsgStatusInfoLabel = null;
            this.CTLM.MsgStatusLabel = null;
            this.CTLM.Name = "CTLM";
            this.CTLM.ReQuery = false;
            this.CTLM.Size = new System.Drawing.Size(290, 29);
            this.CTLM.sSPAdd = "";
            this.CTLM.sSPDel = "";
            this.CTLM.sSPUpp = "";
            this.CTLM.StatusBarProgress = null;
            this.CTLM.TabIndex = 0;
            this.CTLM.Text = "ctlMantenimientoNet1";
            // 
            // txtReference
            // 
            this.txtReference.Add = false;
            this.txtReference.BackColor = System.Drawing.Color.White;
            this.txtReference.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtReference.Caption = "Reference";
            this.txtReference.DBField = null;
            this.txtReference.DBFieldType = null;
            this.txtReference.DefaultValue = null;
            this.txtReference.Del = false;
            this.txtReference.DependingRS = null;
            this.txtReference.ExtraDataLink = null;
            this.txtReference.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtReference.ForeColor = System.Drawing.Color.Black;
            this.txtReference.IsCTLMOwned = false;
            this.txtReference.Location = new System.Drawing.Point(12, 73);
            this.txtReference.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtReference.Name = "txtReference";
            this.txtReference.Order = 0;
            this.txtReference.ParentConn = null;
            this.txtReference.ParentDA = null;
            this.txtReference.PK = true;
            this.txtReference.Protected = false;
            this.txtReference.Search = false;
            this.txtReference.Size = new System.Drawing.Size(287, 17);
            this.txtReference.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtReference.TabIndex = 1;
            this.txtReference.Upp = false;
            this.txtReference.Value = "";
            // 
            // txtDescription
            // 
            this.txtDescription.Add = false;
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Caption = "Description";
            this.txtDescription.DBField = null;
            this.txtDescription.DBFieldType = null;
            this.txtDescription.DefaultValue = null;
            this.txtDescription.Del = false;
            this.txtDescription.DependingRS = null;
            this.txtDescription.ExtraDataLink = null;
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDescription.ForeColor = System.Drawing.Color.Black;
            this.txtDescription.IsCTLMOwned = false;
            this.txtDescription.Location = new System.Drawing.Point(13, 154);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Order = 0;
            this.txtDescription.ParentConn = null;
            this.txtDescription.ParentDA = null;
            this.txtDescription.PK = false;
            this.txtDescription.Protected = false;
            this.txtDescription.Search = false;
            this.txtDescription.Size = new System.Drawing.Size(433, 17);
            this.txtDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Upp = false;
            this.txtDescription.Value = "";
            // 
            // txtFase4
            // 
            this.txtFase4.Add = false;
            this.txtFase4.AllowSpace = false;
            this.txtFase4.BackColor = System.Drawing.Color.White;
            this.txtFase4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFase4.Caption = "Qty per pack";
            this.txtFase4.DBField = null;
            this.txtFase4.DBFieldType = null;
            this.txtFase4.DefaultValue = null;
            this.txtFase4.Del = false;
            this.txtFase4.DependingRS = null;
            this.txtFase4.ExtraDataLink = null;
            this.txtFase4.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtFase4.ForeColor = System.Drawing.Color.Black;
            this.txtFase4.IsCTLMOwned = false;
            this.txtFase4.Length = 0;
            this.txtFase4.Location = new System.Drawing.Point(13, 190);
            this.txtFase4.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtFase4.Mask = false;
            this.txtFase4.Name = "txtFase4";
            this.txtFase4.Order = 0;
            this.txtFase4.ParentConn = null;
            this.txtFase4.ParentDA = null;
            this.txtFase4.PK = false;
            this.txtFase4.Precision = 0;
            this.txtFase4.Protected = false;
            this.txtFase4.Search = false;
            this.txtFase4.Size = new System.Drawing.Size(100, 17);
            this.txtFase4.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtFase4.TabIndex = 5;
            this.txtFase4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtFase4.ThousandsGroup = false;
            this.txtFase4.Upp = false;
            this.txtFase4.Value = null;
            // 
            // txtPrice
            // 
            this.txtPrice.Add = false;
            this.txtPrice.AllowSpace = false;
            this.txtPrice.BackColor = System.Drawing.Color.White;
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrice.Caption = "Price";
            this.txtPrice.DBField = null;
            this.txtPrice.DBFieldType = null;
            this.txtPrice.DefaultValue = null;
            this.txtPrice.Del = false;
            this.txtPrice.DependingRS = null;
            this.txtPrice.ExtraDataLink = null;
            this.txtPrice.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPrice.ForeColor = System.Drawing.Color.Black;
            this.txtPrice.IsCTLMOwned = false;
            this.txtPrice.Length = 0;
            this.txtPrice.Location = new System.Drawing.Point(120, 190);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtPrice.Mask = false;
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Order = 0;
            this.txtPrice.ParentConn = null;
            this.txtPrice.ParentDA = null;
            this.txtPrice.PK = false;
            this.txtPrice.Precision = 0;
            this.txtPrice.Protected = false;
            this.txtPrice.Search = false;
            this.txtPrice.Size = new System.Drawing.Size(100, 17);
            this.txtPrice.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPrice.TabIndex = 9;
            this.txtPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrice.ThousandsGroup = false;
            this.txtPrice.Upp = false;
            this.txtPrice.Value = null;
            // 
            // txtPeso
            // 
            this.txtPeso.Add = false;
            this.txtPeso.AllowSpace = false;
            this.txtPeso.BackColor = System.Drawing.Color.White;
            this.txtPeso.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPeso.Caption = "Weight";
            this.txtPeso.DBField = null;
            this.txtPeso.DBFieldType = null;
            this.txtPeso.DefaultValue = null;
            this.txtPeso.Del = false;
            this.txtPeso.DependingRS = null;
            this.txtPeso.ExtraDataLink = null;
            this.txtPeso.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPeso.ForeColor = System.Drawing.Color.Black;
            this.txtPeso.IsCTLMOwned = false;
            this.txtPeso.Length = 0;
            this.txtPeso.Location = new System.Drawing.Point(227, 190);
            this.txtPeso.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtPeso.Mask = false;
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Order = 0;
            this.txtPeso.ParentConn = null;
            this.txtPeso.ParentDA = null;
            this.txtPeso.PK = false;
            this.txtPeso.Precision = 0;
            this.txtPeso.Protected = false;
            this.txtPeso.Search = false;
            this.txtPeso.Size = new System.Drawing.Size(100, 17);
            this.txtPeso.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPeso.TabIndex = 11;
            this.txtPeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPeso.ThousandsGroup = false;
            this.txtPeso.Upp = false;
            this.txtPeso.Value = null;
            // 
            // txtNotes
            // 
            this.txtNotes.Add = false;
            this.txtNotes.BackColor = System.Drawing.Color.White;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNotes.Caption = "Notes";
            this.txtNotes.DBField = null;
            this.txtNotes.DBFieldType = null;
            this.txtNotes.DefaultValue = null;
            this.txtNotes.Del = false;
            this.txtNotes.DependingRS = null;
            this.txtNotes.ExtraDataLink = null;
            this.txtNotes.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNotes.ForeColor = System.Drawing.Color.Black;
            this.txtNotes.IsCTLMOwned = false;
            this.txtNotes.Location = new System.Drawing.Point(13, 262);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Order = 0;
            this.txtNotes.ParentConn = null;
            this.txtNotes.ParentDA = null;
            this.txtNotes.PK = false;
            this.txtNotes.Protected = false;
            this.txtNotes.Search = false;
            this.txtNotes.Size = new System.Drawing.Size(433, 64);
            this.txtNotes.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtNotes.TabIndex = 13;
            this.txtNotes.Upp = false;
            this.txtNotes.Value = "";
            // 
            // cboServicio
            // 
            this.cboServicio.Add = false;
            this.cboServicio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboServicio.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboServicio.BackColor = System.Drawing.Color.White;
            this.cboServicio.Caption = "Service";
            this.cboServicio.DBField = null;
            this.cboServicio.DBFieldType = null;
            this.cboServicio.DefaultValue = null;
            this.cboServicio.Del = false;
            this.cboServicio.DependingRS = null;
            this.cboServicio.ExtraDataLink = null;
            this.cboServicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboServicio.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboServicio.ForeColor = System.Drawing.Color.Black;
            this.cboServicio.FormattingEnabled = true;
            this.cboServicio.IsCTLMOwned = false;
            this.cboServicio.Location = new System.Drawing.Point(12, 109);
            this.cboServicio.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboServicio.Name = "cboServicio";
            this.cboServicio.Order = 0;
            this.cboServicio.ParentConn = null;
            this.cboServicio.ParentDA = null;
            this.cboServicio.PK = false;
            this.cboServicio.Protected = false;
            this.cboServicio.Search = false;
            this.cboServicio.Size = new System.Drawing.Size(130, 24);
            this.cboServicio.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboServicio.TabIndex = 17;
            this.cboServicio.TBDescription = null;
            this.cboServicio.Upp = false;
            this.cboServicio.Value = "";
            // 
            // txtDesServicio
            // 
            this.txtDesServicio.Add = false;
            this.txtDesServicio.BackColor = System.Drawing.Color.White;
            this.txtDesServicio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDesServicio.Caption = "";
            this.txtDesServicio.DBField = null;
            this.txtDesServicio.DBFieldType = null;
            this.txtDesServicio.DefaultValue = null;
            this.txtDesServicio.Del = false;
            this.txtDesServicio.DependingRS = null;
            this.txtDesServicio.ExtraDataLink = null;
            this.txtDesServicio.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDesServicio.ForeColor = System.Drawing.Color.Black;
            this.txtDesServicio.IsCTLMOwned = false;
            this.txtDesServicio.Location = new System.Drawing.Point(149, 115);
            this.txtDesServicio.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDesServicio.Name = "txtDesServicio";
            this.txtDesServicio.Order = 0;
            this.txtDesServicio.ParentConn = null;
            this.txtDesServicio.ParentDA = null;
            this.txtDesServicio.PK = false;
            this.txtDesServicio.Protected = false;
            this.txtDesServicio.Search = false;
            this.txtDesServicio.Size = new System.Drawing.Size(297, 17);
            this.txtDesServicio.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDesServicio.TabIndex = 19;
            this.txtDesServicio.Upp = false;
            this.txtDesServicio.Value = "";
            // 
            // lstFlags
            // 
            this.lstFlags.Add = false;
            this.lstFlags.BackColor = System.Drawing.Color.White;
            this.lstFlags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFlags.Caption = "Flags";
            this.lstFlags.CheckOnClick = true;
            this.lstFlags.DBField = null;
            this.lstFlags.DBFieldType = null;
            this.lstFlags.DefaultValue = null;
            this.lstFlags.Del = false;
            this.lstFlags.DependingRS = null;
            this.lstFlags.ExtraDataLink = null;
            this.lstFlags.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lstFlags.ForeColor = System.Drawing.Color.Black;
            this.lstFlags.FormattingEnabled = true;
            this.lstFlags.IsCTLMOwned = false;
            this.lstFlags.Location = new System.Drawing.Point(12, 345);
            this.lstFlags.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstFlags.Name = "lstFlags";
            this.lstFlags.Order = 0;
            this.lstFlags.ParentConn = null;
            this.lstFlags.ParentDA = null;
            this.lstFlags.PK = false;
            this.lstFlags.Protected = false;
            this.lstFlags.Search = false;
            this.lstFlags.Size = new System.Drawing.Size(433, 76);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 21;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            // 
            // txtMin
            // 
            this.txtMin.Add = false;
            this.txtMin.AllowSpace = false;
            this.txtMin.BackColor = System.Drawing.Color.White;
            this.txtMin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMin.Caption = "Min";
            this.txtMin.DBField = null;
            this.txtMin.DBFieldType = null;
            this.txtMin.DefaultValue = null;
            this.txtMin.Del = false;
            this.txtMin.DependingRS = null;
            this.txtMin.ExtraDataLink = null;
            this.txtMin.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMin.ForeColor = System.Drawing.Color.Black;
            this.txtMin.IsCTLMOwned = false;
            this.txtMin.Length = 0;
            this.txtMin.Location = new System.Drawing.Point(12, 226);
            this.txtMin.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtMin.Mask = false;
            this.txtMin.Name = "txtMin";
            this.txtMin.Order = 0;
            this.txtMin.ParentConn = null;
            this.txtMin.ParentDA = null;
            this.txtMin.PK = false;
            this.txtMin.Precision = 0;
            this.txtMin.Protected = false;
            this.txtMin.Search = false;
            this.txtMin.Size = new System.Drawing.Size(100, 17);
            this.txtMin.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtMin.TabIndex = 23;
            this.txtMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMin.ThousandsGroup = false;
            this.txtMin.Upp = false;
            this.txtMin.Value = null;
            // 
            // txtMax
            // 
            this.txtMax.Add = false;
            this.txtMax.AllowSpace = false;
            this.txtMax.BackColor = System.Drawing.Color.White;
            this.txtMax.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMax.Caption = "Max";
            this.txtMax.DBField = null;
            this.txtMax.DBFieldType = null;
            this.txtMax.DefaultValue = null;
            this.txtMax.Del = false;
            this.txtMax.DependingRS = null;
            this.txtMax.ExtraDataLink = null;
            this.txtMax.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtMax.ForeColor = System.Drawing.Color.Black;
            this.txtMax.IsCTLMOwned = false;
            this.txtMax.Length = 0;
            this.txtMax.Location = new System.Drawing.Point(120, 226);
            this.txtMax.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtMax.Mask = false;
            this.txtMax.Name = "txtMax";
            this.txtMax.Order = 0;
            this.txtMax.ParentConn = null;
            this.txtMax.ParentDA = null;
            this.txtMax.PK = false;
            this.txtMax.Precision = 0;
            this.txtMax.Protected = false;
            this.txtMax.Search = false;
            this.txtMax.Size = new System.Drawing.Size(100, 17);
            this.txtMax.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtMax.TabIndex = 26;
            this.txtMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMax.ThousandsGroup = false;
            this.txtMax.Upp = false;
            this.txtMax.Value = null;
            // 
            // txtSupplier
            // 
            this.txtSupplier.Add = false;
            this.txtSupplier.BackColor = System.Drawing.Color.White;
            this.txtSupplier.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSupplier.Caption = "Supplier";
            this.txtSupplier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtSupplier.DBField = null;
            this.txtSupplier.DBFieldType = null;
            this.txtSupplier.DefaultValue = null;
            this.txtSupplier.Del = false;
            this.txtSupplier.DependingRS = null;
            this.txtSupplier.ExtraDataLink = null;
            this.txtSupplier.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSupplier.ForeColor = System.Drawing.Color.Black;
            this.txtSupplier.IsCTLMOwned = false;
            this.txtSupplier.Location = new System.Drawing.Point(305, 73);
            this.txtSupplier.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtSupplier.Name = "txtSupplier";
            this.txtSupplier.Order = 0;
            this.txtSupplier.ParentConn = null;
            this.txtSupplier.ParentDA = null;
            this.txtSupplier.PK = false;
            this.txtSupplier.Protected = false;
            this.txtSupplier.Search = false;
            this.txtSupplier.Size = new System.Drawing.Size(137, 17);
            this.txtSupplier.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtSupplier.TabIndex = 38;
            this.txtSupplier.Upp = false;
            this.txtSupplier.Value = "";
            // 
            // fSimpleReferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 463);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.txtMax);
            this.Controls.Add(this.txtMin);
            this.Controls.Add(this.lstFlags);
            this.Controls.Add(this.txtDesServicio);
            this.Controls.Add(this.cboServicio);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.txtPeso);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtFase4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.CTLM);
            this.Name = "fSimpleReferences";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "References";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackTextBox txtReference;
        private EspackFormControlsNS.EspackTextBox txtDescription;
        private EspackFormControlsNS.EspackNumericTextBox txtFase4;
        private EspackFormControlsNS.EspackNumericTextBox txtPrice;
        private EspackFormControlsNS.EspackNumericTextBox txtPeso;
        private EspackFormControlsNS.EspackTextBox txtNotes;
        private EspackFormControlsNS.EspackComboBox cboServicio;
        private EspackFormControlsNS.EspackTextBox txtDesServicio;
        private EspackFormControlsNS.EspackCheckedListBox lstFlags;
        private EspackFormControlsNS.EspackNumericTextBox txtMin;
        private EspackFormControlsNS.EspackNumericTextBox txtMax;
        private EspackFormControlsNS.EspackTextBox txtSupplier;
    }
}