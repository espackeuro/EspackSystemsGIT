﻿namespace Simplistica
{
    partial class fMainSimplistica
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMainSimplistica));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.receivalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleReceivalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hSAReceivalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mastersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleProductionOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleExpeditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printRepairsUnitLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printRackLabelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receivalsToolStripMenuItem,
            this.mastersToolStripMenuItem,
            this.deliveriesToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(2192, 46);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // receivalsToolStripMenuItem
            // 
            this.receivalsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleReceivalsToolStripMenuItem,
            this.hSAReceivalsToolStripMenuItem});
            this.receivalsToolStripMenuItem.Name = "receivalsToolStripMenuItem";
            this.receivalsToolStripMenuItem.Size = new System.Drawing.Size(131, 38);
            this.receivalsToolStripMenuItem.Text = "Receivals";
            // 
            // simpleReceivalsToolStripMenuItem
            // 
            this.simpleReceivalsToolStripMenuItem.Name = "simpleReceivalsToolStripMenuItem";
            this.simpleReceivalsToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.simpleReceivalsToolStripMenuItem.Tag = "fSimpleReceivals";
            this.simpleReceivalsToolStripMenuItem.Text = "Simple Receivals";
            this.simpleReceivalsToolStripMenuItem.Click += new System.EventHandler(this.simpleReceivalsToolStripMenuItem_Click);
            // 
            // hSAReceivalsToolStripMenuItem
            // 
            this.hSAReceivalsToolStripMenuItem.Name = "hSAReceivalsToolStripMenuItem";
            this.hSAReceivalsToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.hSAReceivalsToolStripMenuItem.Tag = "fHSAReceivals";
            this.hSAReceivalsToolStripMenuItem.Text = "HSA Receivals";
            this.hSAReceivalsToolStripMenuItem.Click += new System.EventHandler(this.hSAReceivalsToolStripMenuItem_Click);
            // 
            // mastersToolStripMenuItem
            // 
            this.mastersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.referencesToolStripMenuItem});
            this.mastersToolStripMenuItem.Name = "mastersToolStripMenuItem";
            this.mastersToolStripMenuItem.Size = new System.Drawing.Size(118, 38);
            this.mastersToolStripMenuItem.Text = "Masters";
            // 
            // referencesToolStripMenuItem
            // 
            this.referencesToolStripMenuItem.Name = "referencesToolStripMenuItem";
            this.referencesToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.referencesToolStripMenuItem.Tag = "fSimpleReferences";
            this.referencesToolStripMenuItem.Text = "References";
            this.referencesToolStripMenuItem.Click += new System.EventHandler(this.referencesToolStripMenuItem_Click);
            // 
            // deliveriesToolStripMenuItem
            // 
            this.deliveriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleProductionOrderToolStripMenuItem,
            this.simpleExpeditionToolStripMenuItem});
            this.deliveriesToolStripMenuItem.Name = "deliveriesToolStripMenuItem";
            this.deliveriesToolStripMenuItem.Size = new System.Drawing.Size(139, 38);
            this.deliveriesToolStripMenuItem.Text = "Deliveries";
            // 
            // simpleProductionOrderToolStripMenuItem
            // 
            this.simpleProductionOrderToolStripMenuItem.Name = "simpleProductionOrderToolStripMenuItem";
            this.simpleProductionOrderToolStripMenuItem.Size = new System.Drawing.Size(413, 44);
            this.simpleProductionOrderToolStripMenuItem.Tag = "fProductionOrders";
            this.simpleProductionOrderToolStripMenuItem.Text = "Simple Production Order";
            this.simpleProductionOrderToolStripMenuItem.Click += new System.EventHandler(this.simpleProductionOrderToolStripMenuItem_Click);
            // 
            // simpleExpeditionToolStripMenuItem
            // 
            this.simpleExpeditionToolStripMenuItem.Name = "simpleExpeditionToolStripMenuItem";
            this.simpleExpeditionToolStripMenuItem.Size = new System.Drawing.Size(413, 44);
            this.simpleExpeditionToolStripMenuItem.Tag = "fSimpleDeliveriesEPC";
            this.simpleExpeditionToolStripMenuItem.Text = "Simple Deliveries EPC";
            this.simpleExpeditionToolStripMenuItem.Click += new System.EventHandler(this.simpleExpeditionToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.printRepairsUnitLabelsToolStripMenuItem,
            this.printRackLabelsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(90, 38);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(405, 44);
            this.settingsToolStripMenuItem.Tag = "fSettings";
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // printRepairsUnitLabelsToolStripMenuItem
            // 
            this.printRepairsUnitLabelsToolStripMenuItem.Name = "printRepairsUnitLabelsToolStripMenuItem";
            this.printRepairsUnitLabelsToolStripMenuItem.Size = new System.Drawing.Size(405, 44);
            this.printRepairsUnitLabelsToolStripMenuItem.Tag = "fPrintUnitLabels";
            this.printRepairsUnitLabelsToolStripMenuItem.Text = "Print Repairs Unit Labels";
            this.printRepairsUnitLabelsToolStripMenuItem.Click += new System.EventHandler(this.printRepairsUnitLabelsToolStripMenuItem_Click);
            // 
            // printRackLabelsToolStripMenuItem
            // 
            this.printRackLabelsToolStripMenuItem.Name = "printRackLabelsToolStripMenuItem";
            this.printRackLabelsToolStripMenuItem.Size = new System.Drawing.Size(405, 44);
            this.printRackLabelsToolStripMenuItem.Tag = "fRackLabels";
            this.printRackLabelsToolStripMenuItem.Text = "Print Rack Labels";
            this.printRackLabelsToolStripMenuItem.Click += new System.EventHandler(this.printRackLabelsToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // fMainSimplistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2192, 1458);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "fMainSimplistica";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem receivalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleReceivalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printRepairsUnitLabelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printRackLabelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mastersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem referencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deliveriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleProductionOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleExpeditionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hSAReceivalsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

