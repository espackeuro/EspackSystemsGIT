

namespace EspackFormControlsNS
{
    partial class EspackCheckedListBox
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
            this.CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // CheckedListBox
            // 
            this.CheckedListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CheckedListBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.CheckedListBox.Location = new System.Drawing.Point(0, 15);
            this.CheckedListBox.Name = "TextBox";
            //this.CheckedListBox.Size = new System.Drawing.Size(150, 20);
            this.CheckedListBox.TabIndex = 0;
            // 
            // EspackCheckedListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.CaptionLabel);
            this.Controls.Add(this.CheckedListBox);
            this.Name = "EspackCheckedListBox";
            this.Size = new System.Drawing.Size(154, 38);
            this.Controls.SetChildIndex(this.CheckedListBox, 0);
            this.Controls.SetChildIndex(this.CaptionLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
