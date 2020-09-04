namespace EspackMenuNS
{
    partial class EspackMenuContainer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EspackMenuContainer));
            this.ElPanel = new System.Windows.Forms.Panel();
            this.ElMenu = new EspackMenuNS.EspackMenu();
            this.Menu1 = new EspackMenuNS.EspackToolStripItem();
            this.CloseButton = new EspackMenuNS.EspackToolStripItem();
            this.ElPanel.SuspendLayout();
            this.ElMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ElPanel
            // 
            this.ElPanel.AutoSize = true;
            this.ElPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ElPanel.Controls.Add(this.ElMenu);
            this.ElPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ElPanel.Location = new System.Drawing.Point(0, 0);
            this.ElPanel.Name = "ElPanel";
            this.ElPanel.Size = new System.Drawing.Size(415, 24);
            this.ElPanel.TabIndex = 0;
            // 
            // ElMenu
            // 
            this.ElMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu1,
            this.CloseButton});
            this.ElMenu.Location = new System.Drawing.Point(0, 0);
            this.ElMenu.Name = "ElMenu";
            this.ElMenu.Size = new System.Drawing.Size(415, 24);
            this.ElMenu.TabIndex = 0;
            this.ElMenu.Tag = "-";
            this.ElMenu.Text = "ElMenu";
            // 
            // Menu1
            // 
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(50, 20);
            this.Menu1.Tag = "-";
            this.Menu1.Text = "Menu";
            // 
            // CloseButton
            // 
            this.CloseButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CloseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseButton.Enabled = false;
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(28, 20);
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // EspackMenuContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ElPanel);
            this.MinimumSize = new System.Drawing.Size(100, 24);
            this.Name = "EspackMenuContainer";
            this.Size = new System.Drawing.Size(415, 24);
            this.ElPanel.ResumeLayout(false);
            this.ElPanel.PerformLayout();
            this.ElMenu.ResumeLayout(false);
            this.ElMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel ElPanel;
        private EspackMenuNS.EspackMenu ElMenu;
        private EspackMenuNS.EspackToolStripItem Menu1;
        private EspackMenuNS.EspackToolStripItem CloseButton;
    }
}
