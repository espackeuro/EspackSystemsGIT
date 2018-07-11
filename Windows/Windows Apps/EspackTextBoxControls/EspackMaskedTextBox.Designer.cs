namespace EspackFormControlsNS
{
    partial class EspackMaskedTextBox
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
            this.MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // MaskedTextBox
            // 
            this.MaskedTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MaskedTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.MaskedTextBox.Location = new System.Drawing.Point(3, 16);
            this.MaskedTextBox.Name = "MaskedTextBox";
            //this.MaskedTextBox.Size = new System.Drawing.Size(154, 22);
            this.MaskedTextBox.TabIndex = 0;
            // 
            // EspackMaskedTextBox
            // 
            this.Caption = "Caption";
            this.Controls.Add(this.CaptionLabel);
            this.Controls.Add(this.MaskedTextBox);
            this.Name = "EspackMaskedTextBox";
            this.Size = new System.Drawing.Size(154, 25);
            this.Controls.SetChildIndex(this.MaskedTextBox, 0);
            this.Controls.SetChildIndex(this.CaptionLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}
