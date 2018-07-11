namespace EspackFormControlsNS
{
    partial class EspackComboBox
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
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ComboBox
            // 
            this.ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ComboBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.ComboBox.Location = new System.Drawing.Point(0, 15);
            this.ComboBox.Name = "TextBox";
            //this.ComboBox.Size = new System.Drawing.Size(150, 20);
            this.ComboBox.TabIndex = 0;
            // 
            // EspackTextBox
            // 
            this.Controls.Add(this.CaptionLabel);
            this.Controls.Add(this.ComboBox);
            this.Name = "EspackComboBox";
            this.Size = new System.Drawing.Size(409, 22);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
