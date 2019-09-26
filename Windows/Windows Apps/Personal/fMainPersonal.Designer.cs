namespace Personal
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
            this.espackMenu1 = new EspackMenuNS.EspackMenu();
            this.mnuCalendars = new EspackMenuNS.EspackToolStripItem();
            this.mnuFestivosCalendar = new EspackMenuNS.EspackToolStripItem();
            this.espackMenu1.SuspendLayout();
            this.SuspendLayout();
            // 
            // espackMenu1
            // 
            this.espackMenu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.espackMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCalendars});
            this.espackMenu1.Location = new System.Drawing.Point(0, 0);
            this.espackMenu1.Name = "espackMenu1";
            this.espackMenu1.Size = new System.Drawing.Size(1312, 28);
            this.espackMenu1.TabIndex = 1;
            this.espackMenu1.Text = "espackMenu1";
            // 
            // mnuCalendars
            // 
            this.mnuCalendars.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFestivosCalendar});
            this.mnuCalendars.Name = "mnuCalendars";
            this.mnuCalendars.Size = new System.Drawing.Size(88, 24);
            this.mnuCalendars.Tag = "-";
            this.mnuCalendars.Text = "Calendars";
            // 
            // mnuFestivosCalendar
            // 
            this.mnuFestivosCalendar.Name = "mnuFestivosCalendar";
            this.mnuFestivosCalendar.Size = new System.Drawing.Size(224, 26);
            this.mnuFestivosCalendar.Tag = "fLocalHolidays";
            this.mnuFestivosCalendar.Text = "Local Holidays";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 870);
            this.Controls.Add(this.espackMenu1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.espackMenu1;
            this.Name = "fMain";
            this.Text = "Personal";
            this.espackMenu1.ResumeLayout(false);
            this.espackMenu1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackMenuNS.EspackMenu espackMenu1;
        private EspackMenuNS.EspackToolStripItem mnuCalendars;
        private EspackMenuNS.EspackToolStripItem mnuFestivosCalendar;
    }
}

