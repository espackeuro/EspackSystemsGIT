namespace Invoicing
{
    partial class fSuppliers
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
            this.ctlMantenimiento1 = new EspackFormControlsNS.CTLMantenimiento();
            this.SuspendLayout();
            // 
            // ctlMantenimiento1
            // 
            this.ctlMantenimiento1.AutoSize = true;
            this.ctlMantenimiento1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctlMantenimiento1.BackColor = System.Drawing.Color.Transparent;
            this.ctlMantenimiento1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ctlMantenimiento1.Clear = false;
            this.ctlMantenimiento1.Conn = null;
            this.ctlMantenimiento1.DBTable = null;
            this.ctlMantenimiento1.Location = new System.Drawing.Point(12, 12);
            this.ctlMantenimiento1.MsgStatusInfoLabel = null;
            this.ctlMantenimiento1.MsgStatusLabel = null;
            this.ctlMantenimiento1.Name = "ctlMantenimiento1";
            this.ctlMantenimiento1.ReQuery = false;
            this.ctlMantenimiento1.Size = new System.Drawing.Size(300, 31);
            this.ctlMantenimiento1.sSPAdd = "";
            this.ctlMantenimiento1.sSPDel = "";
            this.ctlMantenimiento1.sSPUpp = "";
            this.ctlMantenimiento1.StatusBarProgress = null;
            this.ctlMantenimiento1.TabIndex = 0;
            // 
            // fSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ctlMantenimiento1);
            this.Name = "fSuppliers";
            this.Text = "Suppliers";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento ctlMantenimiento1;
    }
}