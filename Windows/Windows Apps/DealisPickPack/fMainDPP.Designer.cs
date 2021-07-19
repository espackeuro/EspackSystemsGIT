namespace DealerPickPack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMainDPP));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inboundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receivalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pendingWorkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.husToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.containersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outboundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deliveriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inboundToolStripMenuItem,
            this.processingToolStripMenuItem,
            this.outboundToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.windowsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inboundToolStripMenuItem
            // 
            this.inboundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.receivalsToolStripMenuItem});
            this.inboundToolStripMenuItem.Name = "inboundToolStripMenuItem";
            this.inboundToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.inboundToolStripMenuItem.Text = "Inbound";
            // 
            // receivalsToolStripMenuItem
            // 
            this.receivalsToolStripMenuItem.Name = "receivalsToolStripMenuItem";
            this.receivalsToolStripMenuItem.Size = new System.Drawing.Size(153, 26);
            this.receivalsToolStripMenuItem.Tag = "fReceivals";
            this.receivalsToolStripMenuItem.Text = "Receivals";
            this.receivalsToolStripMenuItem.Click += new System.EventHandler(this.receivalsToolStripMenuItem_Click);
            // 
            // processingToolStripMenuItem
            // 
            this.processingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pendingWorkToolStripMenuItem,
            this.husToolStripMenuItem,
            this.containersToolStripMenuItem});
            this.processingToolStripMenuItem.Name = "processingToolStripMenuItem";
            this.processingToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.processingToolStripMenuItem.Text = "Processing";
            // 
            // pendingWorkToolStripMenuItem
            // 
            this.pendingWorkToolStripMenuItem.Name = "pendingWorkToolStripMenuItem";
            this.pendingWorkToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.pendingWorkToolStripMenuItem.Tag = "fPendingWork";
            this.pendingWorkToolStripMenuItem.Text = "Pending Work";
            this.pendingWorkToolStripMenuItem.Click += new System.EventHandler(this.pendingWorkToolStripMenuItem_Click);
            // 
            // husToolStripMenuItem
            // 
            this.husToolStripMenuItem.Name = "husToolStripMenuItem";
            this.husToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.husToolStripMenuItem.Tag = "fHUs";
            this.husToolStripMenuItem.Text = "HU\'s";
            this.husToolStripMenuItem.Click += new System.EventHandler(this.husToolStripMenuItem_Click);
            // 
            // containersToolStripMenuItem
            // 
            this.containersToolStripMenuItem.Name = "containersToolStripMenuItem";
            this.containersToolStripMenuItem.Size = new System.Drawing.Size(183, 26);
            this.containersToolStripMenuItem.Tag = "fContainers";
            this.containersToolStripMenuItem.Text = "Containers";
            this.containersToolStripMenuItem.Click += new System.EventHandler(this.containersToolStripMenuItem_Click);
            // 
            // outboundToolStripMenuItem
            // 
            this.outboundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deliveriesToolStripMenuItem});
            this.outboundToolStripMenuItem.Name = "outboundToolStripMenuItem";
            this.outboundToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.outboundToolStripMenuItem.Text = "Outbound";
            // 
            // deliveriesToolStripMenuItem
            // 
            this.deliveriesToolStripMenuItem.Name = "deliveriesToolStripMenuItem";
            this.deliveriesToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.deliveriesToolStripMenuItem.Tag = "fDeliveries";
            this.deliveriesToolStripMenuItem.Text = "Deliveries";
            this.deliveriesToolStripMenuItem.Click += new System.EventHandler(this.deliveriesToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.settingsToolStripMenuItem.Tag = "fSettings";
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // windowsToolStripMenuItem
            // 
            this.windowsToolStripMenuItem.Name = "windowsToolStripMenuItem";
            this.windowsToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.windowsToolStripMenuItem.Text = "Windows";
            // 
            // fMainDPP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "fMainDPP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dealis Pick Pack";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void HusToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
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
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsToolStripMenuItem;
    }
}

