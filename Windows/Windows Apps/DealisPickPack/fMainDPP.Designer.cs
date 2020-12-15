namespace DealisPickPack
{
    partial class fMainDPP
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inboundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receivalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.husToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outboundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inboundToolStripMenuItem,
            this.processingToolStripMenuItem,
            this.outboundToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inboundToolStripMenuItem
            // 
            this.inboundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receivalsToolStripMenuItem});
            this.inboundToolStripMenuItem.Name = "inboundToolStripMenuItem";
            this.inboundToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.inboundToolStripMenuItem.Text = "Inbound";
            // 
            // receivalsToolStripMenuItem
            // 
            this.receivalsToolStripMenuItem.Name = "receivalsToolStripMenuItem";
            this.receivalsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.receivalsToolStripMenuItem.Tag = "fSimpleReceivals";
            this.receivalsToolStripMenuItem.Text = "Receivals";
            // 
            // processingToolStripMenuItem
            // 
            this.processingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendingWorkToolStripMenuItem,
            this.husToolStripMenuItem,
            this.containersToolStripMenuItem});
            this.processingToolStripMenuItem.Name = "processingToolStripMenuItem";
            this.processingToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.processingToolStripMenuItem.Text = "Processing";
            // 
            // pendingWorkToolStripMenuItem
            // 
            this.pendingWorkToolStripMenuItem.Name = "pendingWorkToolStripMenuItem";
            this.pendingWorkToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pendingWorkToolStripMenuItem.Tag = "fPendingWork";
            this.pendingWorkToolStripMenuItem.Text = "Pending Work";
            this.pendingWorkToolStripMenuItem.Click += new System.EventHandler(this.pendingWorkToolStripMenuItem_Click);
            // 
            // husToolStripMenuItem
            // 
            this.husToolStripMenuItem.Name = "husToolStripMenuItem";
            this.husToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.husToolStripMenuItem.Tag = "fHUs";
            this.husToolStripMenuItem.Text = "HU\'s";
            // 
            // containersToolStripMenuItem
            // 
            this.containersToolStripMenuItem.Name = "containersToolStripMenuItem";
            this.containersToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.containersToolStripMenuItem.Tag = "fContainers";
            this.containersToolStripMenuItem.Text = "Containers";
            // 
            // outboundToolStripMenuItem
            // 
            this.outboundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deliveriesToolStripMenuItem});
            this.outboundToolStripMenuItem.Name = "outboundToolStripMenuItem";
            this.outboundToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.outboundToolStripMenuItem.Text = "Outbound";
            // 
            // deliveriesToolStripMenuItem
            // 
            this.deliveriesToolStripMenuItem.Name = "deliveriesToolStripMenuItem";
            this.deliveriesToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.deliveriesToolStripMenuItem.Tag = "fDeliveries";
            this.deliveriesToolStripMenuItem.Text = "Deliveries";
            // 
            // fMainDPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fMainDPP";
            this.Text = "Dealis Pick Pack";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inboundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receivalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem containersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outboundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deliveriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem husToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pendingWorkToolStripMenuItem;
    }
}

