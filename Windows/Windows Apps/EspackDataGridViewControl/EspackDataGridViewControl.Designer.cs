namespace EspackDataGridView
{
    partial class EspackDataGridViewControl
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
            this.panel = new System.Windows.Forms.Panel();
            this.FilterDataGrid = new System.Windows.Forms.DataGridView();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilterDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.DataGridView);
            this.panel.Controls.Add(this.FilterDataGrid);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(800, 450);
            this.panel.TabIndex = 3;
            // 
            // FilterDataGrid
            // 
            this.FilterDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilterDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.FilterDataGrid.Location = new System.Drawing.Point(0, 0);
            this.FilterDataGrid.Name = "FilterDataGrid";
            this.FilterDataGrid.Size = new System.Drawing.Size(800, 150);
            this.FilterDataGrid.TabIndex = 2;
            this.FilterDataGrid.Visible = false;
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.Location = new System.Drawing.Point(0, 150);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(800, 300);
            this.DataGridView.TabIndex = 3;
            // 
            // EspackDataGridViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel);
            this.Name = "EspackDataGridViewControl";
            this.Size = new System.Drawing.Size(800, 450);
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FilterDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        public System.Windows.Forms.DataGridView DataGridView;
        public System.Windows.Forms.DataGridView FilterDataGrid;
    }
}
