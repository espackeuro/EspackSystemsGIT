namespace Sistemas
{
    partial class fMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));

            this.mnuNetwork = new EspackMenuNS.EspackToolStripItem();
            this.mnuTowns = new EspackMenuNS.EspackToolStripItem();
            this.mnuZones = new EspackMenuNS.EspackToolStripItem();
            this.mnuItems = new EspackMenuNS.EspackToolStripItem();
            this.systemsToolStripMenuItem = new EspackMenuNS.EspackToolStripItem();
            this.actionsToolStripMenuItem = new EspackMenuNS.EspackToolStripItem();
            this.dHCPControlToolStripMenuItem = new EspackMenuNS.EspackToolStripItem();
            this.dNSControlToolStripMenuItem = new EspackMenuNS.EspackToolStripItem();
            this.tasksToolStripMenuItem = new EspackMenuNS.EspackToolStripItem();
            this.controlToolStripMenuItem = new EspackMenuNS.EspackToolStripItem();
            this.flagsToolStripMenuItem = new EspackMenuNS.EspackToolStripItem();
            this.servicesToolStripMenuItem1 = new EspackMenuNS.EspackToolStripItem();
            this.usersToolStripMenuItem1 = new EspackMenuNS.EspackToolStripItem();
            this.aliasToolStripMenuItem = new EspackMenuNS.EspackToolStripItem();
            this.securityProfilesToolStripMenuItem = new EspackMenuNS.EspackToolStripItem();
            this.windowToolStripMenuItem = new EspackMenuNS.EspackToolStripItem();
            this.espackToolStripItem1 = new EspackMenuNS.EspackToolStripItem();
            this.espackToolStripItem2 = new EspackMenuNS.EspackToolStripItem();
            //this.espackMenu1 = new EspackMenu.EspackMenu();
            this.ElContenedor = new EspackMenuNS.EspackMenuContainer();
            this.ElContenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // EspackMenu
            // 
            this.ElContenedor.GetEspackMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNetwork,
            this.actionsToolStripMenuItem,
            this.tasksToolStripMenuItem,
            this.controlToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.espackToolStripItem1});
            // 
            // mnuNetwork
            // 
            this.mnuNetwork.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTowns,
            this.mnuZones,
            this.mnuItems,
            this.systemsToolStripMenuItem});
            this.mnuNetwork.Name = "mnuNetwork";
            this.mnuNetwork.Size = new System.Drawing.Size(74, 24);
            this.mnuNetwork.Tag = "-";
            this.mnuNetwork.Text = "Masters";
            // 
            // mnuTowns
            // 
            this.mnuTowns.Name = "mnuTowns";
            this.mnuTowns.Size = new System.Drawing.Size(193, 26);
            this.mnuTowns.Tag = "fTown";
            this.mnuTowns.Text = "Towns";
            // 
            // mnuZones
            // 
            this.mnuZones.Name = "mnuZones";
            this.mnuZones.Size = new System.Drawing.Size(193, 26);
            this.mnuZones.Tag = "fZones";
            this.mnuZones.Text = "Network Zones";
            // 
            // mnuItems
            // 
            this.mnuItems.Name = "mnuItems";
            this.mnuItems.Size = new System.Drawing.Size(193, 26);
            this.mnuItems.Tag = "fItems";
            this.mnuItems.Text = "Inventory Items";
            // 
            // systemsToolStripMenuItem
            // 
            this.systemsToolStripMenuItem.Name = "systemsToolStripMenuItem";
            this.systemsToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.systemsToolStripMenuItem.Tag = "fSystemsMaster";
            this.systemsToolStripMenuItem.Text = "Systems";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dHCPControlToolStripMenuItem,
            this.dNSControlToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.actionsToolStripMenuItem.Tag = "-";
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // dHCPControlToolStripMenuItem
            // 
            this.dHCPControlToolStripMenuItem.Name = "dHCPControlToolStripMenuItem";
            this.dHCPControlToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.dHCPControlToolStripMenuItem.Tag = "fDHCP";
            this.dHCPControlToolStripMenuItem.Text = "DHCP Control";
            // 
            // dNSControlToolStripMenuItem
            // 
            this.dNSControlToolStripMenuItem.Name = "dNSControlToolStripMenuItem";
            this.dNSControlToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.dNSControlToolStripMenuItem.Tag = "fDNS";
            this.dNSControlToolStripMenuItem.Text = "DNS Control";
            // 
            // tasksToolStripMenuItem
            // 
            this.tasksToolStripMenuItem.Name = "tasksToolStripMenuItem";
            this.tasksToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.tasksToolStripMenuItem.Tag = "fTasks";
            this.tasksToolStripMenuItem.Text = "Tasks";
            // 
            // controlToolStripMenuItem
            // 
            this.controlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flagsToolStripMenuItem,
            this.servicesToolStripMenuItem1,
            this.usersToolStripMenuItem1,
            this.aliasToolStripMenuItem,
            this.securityProfilesToolStripMenuItem});
            this.controlToolStripMenuItem.Name = "controlToolStripMenuItem";
            this.controlToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.controlToolStripMenuItem.Tag = "-";
            this.controlToolStripMenuItem.Text = "Control";
            // 
            // flagsToolStripMenuItem
            // 
            this.flagsToolStripMenuItem.Name = "flagsToolStripMenuItem";
            this.flagsToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.flagsToolStripMenuItem.Tag = "fFlags";
            this.flagsToolStripMenuItem.Text = "Flags";
            // 
            // servicesToolStripMenuItem1
            // 
            this.servicesToolStripMenuItem1.Name = "servicesToolStripMenuItem1";
            this.servicesToolStripMenuItem1.Size = new System.Drawing.Size(197, 26);
            this.servicesToolStripMenuItem1.Tag = "fServices";
            this.servicesToolStripMenuItem1.Text = "Services";
            // 
            // usersToolStripMenuItem1
            // 
            this.usersToolStripMenuItem1.Name = "usersToolStripMenuItem1";
            this.usersToolStripMenuItem1.Size = new System.Drawing.Size(197, 26);
            this.usersToolStripMenuItem1.Tag = "fUsers";
            this.usersToolStripMenuItem1.Text = "Users";
            // 
            // aliasToolStripMenuItem
            // 
            this.aliasToolStripMenuItem.Name = "aliasToolStripMenuItem";
            this.aliasToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.aliasToolStripMenuItem.Tag = "fAlias";
            this.aliasToolStripMenuItem.Text = "Alias";
            // 
            // securityProfilesToolStripMenuItem
            // 
            this.securityProfilesToolStripMenuItem.Name = "securityProfilesToolStripMenuItem";
            this.securityProfilesToolStripMenuItem.Size = new System.Drawing.Size(197, 26);
            this.securityProfilesToolStripMenuItem.Tag = "fProfiles";
            this.securityProfilesToolStripMenuItem.Text = "Security Profiles";
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.windowToolStripMenuItem.Text = "Window";
            // 
            // espackToolStripItem1
            // 
            this.espackToolStripItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.espackToolStripItem2});
            this.espackToolStripItem1.Name = "espackToolStripItem1";
            this.espackToolStripItem1.Size = new System.Drawing.Size(58, 24);
            this.espackToolStripItem1.Tag = "-";
            this.espackToolStripItem1.Text = "Tools";
            // 
            // espackToolStripItem2
            // 
            this.espackToolStripItem2.Name = "espackToolStripItem2";
            this.espackToolStripItem2.Size = new System.Drawing.Size(145, 26);
            this.espackToolStripItem2.Tag = "fSettings";
            this.espackToolStripItem2.Text = "Settings";

            // 
            // ElContenedor
            // 
            this.ElContenedor.AutoSize = true;
            this.ElContenedor.Dock = System.Windows.Forms.DockStyle.Top;
            this.ElContenedor.Location = new System.Drawing.Point(0, 0);
            this.ElContenedor.Margin = new System.Windows.Forms.Padding(0);
            this.ElContenedor.Name = "ElContenedor";
            this.ElContenedor.Size = new System.Drawing.Size(1675, 0);
            this.ElContenedor.TabIndex = 10;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1675, 887);
            this.Controls.Add(this.ElContenedor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.ElContenedor.GetEspackMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fMain";
            this.ShowIcon = false;
            this.Text = "Sistemas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ElContenedor.ResumeLayout(false);
            this.ElContenedor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private EspackMenuNS.EspackToolStripItem mnuNetwork;
        private EspackMenuNS.EspackToolStripItem mnuTowns;
        private EspackMenuNS.EspackToolStripItem mnuZones;
        private EspackMenuNS.EspackToolStripItem mnuItems;
        private EspackMenuNS.EspackToolStripItem systemsToolStripMenuItem;
        private EspackMenuNS.EspackToolStripItem actionsToolStripMenuItem;
        private EspackMenuNS.EspackToolStripItem dHCPControlToolStripMenuItem;
        private EspackMenuNS.EspackToolStripItem dNSControlToolStripMenuItem;
        private EspackMenuNS.EspackToolStripItem tasksToolStripMenuItem;
        private EspackMenuNS.EspackToolStripItem controlToolStripMenuItem;
        private EspackMenuNS.EspackToolStripItem flagsToolStripMenuItem;
        private EspackMenuNS.EspackToolStripItem servicesToolStripMenuItem1;
        private EspackMenuNS.EspackToolStripItem usersToolStripMenuItem1;
        private EspackMenuNS.EspackToolStripItem aliasToolStripMenuItem;
        private EspackMenuNS.EspackToolStripItem securityProfilesToolStripMenuItem;
        private EspackMenuNS.EspackToolStripItem windowToolStripMenuItem;
        private EspackMenuNS.EspackToolStripItem espackToolStripItem1;
        private EspackMenuNS.EspackToolStripItem espackToolStripItem2;
        private EspackMenuNS.EspackMenuContainer ElContenedor;
    }
}

