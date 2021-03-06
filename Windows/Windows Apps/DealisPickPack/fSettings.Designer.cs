﻿namespace DealerPickPack
{
    partial class fSettings
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
            this.cboPrinters = new EspackFormControlsNS.EspackComboBox();
            this.cboWarehouse = new EspackFormControlsNS.EspackComboBox();
            this.SuspendLayout();
            // 
            // cboPrinters
            // 
            this.cboPrinters.Add = false;
            this.cboPrinters.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboPrinters.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboPrinters.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboPrinters.BackColor = System.Drawing.Color.White;
            this.cboPrinters.Caption = "Default Label Printer";
            this.cboPrinters.DataSource = null;
            this.cboPrinters.DBField = null;
            this.cboPrinters.DBFieldType = null;
            this.cboPrinters.DefaultValue = null;
            this.cboPrinters.Del = false;
            this.cboPrinters.DependingRS = null;
            this.cboPrinters.DisplayMember = "";
            this.cboPrinters.ExtraDataLink = null;
            this.cboPrinters.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPrinters.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboPrinters.ForeColor = System.Drawing.Color.Black;
            this.cboPrinters.FormattingEnabled = true;
            this.cboPrinters.IsCTLMOwned = false;
            this.cboPrinters.Location = new System.Drawing.Point(12, 25);
            this.cboPrinters.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboPrinters.Name = "cboPrinters";
            this.cboPrinters.Order = 0;
            this.cboPrinters.ParentConn = null;
            this.cboPrinters.ParentDA = null;
            this.cboPrinters.PK = false;
            this.cboPrinters.Protected = false;
            this.cboPrinters.ReadOnly = false;
            this.cboPrinters.Search = false;
            this.cboPrinters.SelectedItem = null;
            this.cboPrinters.SelectedValue = null;
            this.cboPrinters.Size = new System.Drawing.Size(274, 40);
            this.cboPrinters.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboPrinters.TabIndex = 43;
            this.cboPrinters.TBDescription = null;
            this.cboPrinters.Upp = false;
            this.cboPrinters.Value = "";
            this.cboPrinters.ValueMember = "";
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.Add = false;
            this.cboWarehouse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cboWarehouse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboWarehouse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboWarehouse.BackColor = System.Drawing.Color.White;
            this.cboWarehouse.Caption = "Warehouse";
            this.cboWarehouse.DataSource = null;
            this.cboWarehouse.DBField = null;
            this.cboWarehouse.DBFieldType = null;
            this.cboWarehouse.DefaultValue = null;
            this.cboWarehouse.Del = false;
            this.cboWarehouse.DependingRS = null;
            this.cboWarehouse.DisplayMember = "";
            this.cboWarehouse.ExtraDataLink = null;
            this.cboWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboWarehouse.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboWarehouse.ForeColor = System.Drawing.Color.Black;
            this.cboWarehouse.FormattingEnabled = true;
            this.cboWarehouse.IsCTLMOwned = false;
            this.cboWarehouse.Location = new System.Drawing.Point(12, 84);
            this.cboWarehouse.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Order = 0;
            this.cboWarehouse.ParentConn = null;
            this.cboWarehouse.ParentDA = null;
            this.cboWarehouse.PK = false;
            this.cboWarehouse.Protected = false;
            this.cboWarehouse.ReadOnly = false;
            this.cboWarehouse.Search = false;
            this.cboWarehouse.SelectedItem = null;
            this.cboWarehouse.SelectedValue = null;
            this.cboWarehouse.Size = new System.Drawing.Size(274, 40);
            this.cboWarehouse.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboWarehouse.TabIndex = 46;
            this.cboWarehouse.TBDescription = null;
            this.cboWarehouse.Upp = false;
            this.cboWarehouse.Value = "";
            this.cboWarehouse.ValueMember = "";
            // 
            // fSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 141);
            this.Controls.Add(this.cboWarehouse);
            this.Controls.Add(this.cboPrinters);
            this.Name = "fSettings";
            this.ShowIcon = false;
            this.Text = "fSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private EspackFormControlsNS.EspackComboBox cboPrinters;
        private EspackFormControlsNS.EspackComboBox cboWarehouse;
    }
}