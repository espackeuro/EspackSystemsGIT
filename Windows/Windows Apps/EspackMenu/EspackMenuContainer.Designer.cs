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
            this.ElMenu = new EspackMenuNS.EspackMenu();
            this.Menu1 = new EspackMenuNS.EspackToolStripItem();
            this.CloseButton = new EspackMenuNS.EspackToolStripItem();
            this.ElMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ElMenu
            // 
            this.ElMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ElMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Menu1,
            this.CloseButton});
            this.ElMenu.Location = new System.Drawing.Point(0, 0);
            this.ElMenu.Name = "ElMenu";
            this.ElMenu.Size = new System.Drawing.Size(553, 28);
            this.ElMenu.TabIndex = 1;
            this.ElMenu.Tag = "-";
            this.ElMenu.Text = "ElMenu";
            // 
            // Menu1
            // 
            this.Menu1.Name = "Menu1";
            this.Menu1.Size = new System.Drawing.Size(60, 24);
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
            this.CloseButton.Size = new System.Drawing.Size(34, 24);
            // 
            // EspackMenuContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.ElMenu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(133, 30);
            this.Name = "EspackMenuContainer";
            this.Size = new System.Drawing.Size(553, 34);
            this.ElMenu.ResumeLayout(false);
            this.ElMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackMenu ElMenu;
        private EspackToolStripItem Menu1;
        private EspackToolStripItem CloseButton;
    }
}
