namespace Nidus
{
    partial class fMainNidus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMainNidus));
            this.espackMenu1 = new EspackFormControls.EspackMenu();
            this.espackToolStripItem1 = new EspackFormControls.EspackToolStripItem();
            this.espackToolStripItem2 = new EspackFormControls.EspackToolStripItem();
            this.espackMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // espackMenu1
            // 
            this.espackMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.espackToolStripItem1});
            this.espackMenu1.Location = new System.Drawing.Point(0, 0);
            this.espackMenu1.Name = "espackMenu1";
            this.espackMenu1.Size = new System.Drawing.Size(855, 24);
            this.espackMenu1.TabIndex = 1;
            this.espackMenu1.Text = "espackMenu1";
            // 
            // espackToolStripItem1
            // 
            this.espackToolStripItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.espackToolStripItem2});
            this.espackToolStripItem1.Name = "espackToolStripItem1";
            this.espackToolStripItem1.Size = new System.Drawing.Size(80, 20);
            this.espackToolStripItem1.Tag = "-";
            this.espackToolStripItem1.Text = "Documents";
            // 
            // espackToolStripItem2
            // 
            this.espackToolStripItem2.Name = "espackToolStripItem2";
            this.espackToolStripItem2.Size = new System.Drawing.Size(152, 22);
            this.espackToolStripItem2.Tag = "fDocumentControl";
            this.espackToolStripItem2.Text = "Management";
            // 
            // fMainNidus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 617);
            this.Controls.Add(this.espackMenu1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.espackMenu1;
            this.Name = "fMainNidus";
            this.Text = "Nidus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.espackMenu1.ResumeLayout(false);
            this.espackMenu1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControls.EspackMenu espackMenu1;
        private EspackFormControls.EspackToolStripItem espackToolStripItem1;
        private EspackFormControls.EspackToolStripItem espackToolStripItem2;
    }
}

