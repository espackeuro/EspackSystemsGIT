﻿namespace Repairs
{
    partial class fMainRepairs
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
            this.espackMenu1 = new EspackMenuNS.EspackMenu();
            this.movementsToolStripMenuItem = new EspackMenuNS.EspackToolStripItem();
            this.espackToolStripItem1 = new EspackMenuNS.EspackToolStripItem();
            this.espackToolStripItem2 = new EspackMenuNS.EspackToolStripItem();
            this.espackMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // espackMenu1
            // 
            this.espackMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.movementsToolStripMenuItem});
            this.espackMenu1.Location = new System.Drawing.Point(0, 0);
            this.espackMenu1.Name = "espackMenu1";
            this.espackMenu1.Size = new System.Drawing.Size(1118, 24);
            this.espackMenu1.TabIndex = 1;
            this.espackMenu1.Text = "espackMenu1";
            // 
            // movementsToolStripMenuItem
            // 
            this.movementsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.espackToolStripItem1,
            this.espackToolStripItem2});
            this.movementsToolStripMenuItem.Name = "movementsToolStripMenuItem";
            this.movementsToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.movementsToolStripMenuItem.Text = "Movements";
            // 
            // espackToolStripItem1
            // 
            this.espackToolStripItem1.Name = "espackToolStripItem1";
            this.espackToolStripItem1.Size = new System.Drawing.Size(152, 22);
            this.espackToolStripItem1.Tag = "fReceivals";
            this.espackToolStripItem1.Text = "Repairs";
            // 
            // espackToolStripItem2
            // 
            this.espackToolStripItem2.Name = "espackToolStripItem2";
            this.espackToolStripItem2.Size = new System.Drawing.Size(152, 22);
            this.espackToolStripItem2.Tag = "fDeliveries";
            this.espackToolStripItem2.Text = "Deliveries";
            // 
            // fMainRepairs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 261);
            this.Controls.Add(this.espackMenu1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.espackMenu1;
            this.Name = "fMainRepairs";
            this.Text = "fMainRepairs";
            this.espackMenu1.ResumeLayout(false);
            this.espackMenu1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackMenuNS.EspackMenu espackMenu1;
        private EspackMenuNS.EspackToolStripItem espackToolStripItem1;
        private EspackMenuNS.EspackToolStripItem espackToolStripItem2;
        private EspackMenuNS.EspackToolStripItem movementsToolStripMenuItem;
    }
}