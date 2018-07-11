namespace EspackFormControlsNS
{
    partial class EspackCheckedComboBox
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
            this.CheckedComboBox = new CheckedComboBoxNS.CheckedComboBox();
            this.SuspendLayout();
            // 
            // CheckedComboBox
            // 
            this.CheckedComboBox.CheckOnClick = true;
            this.CheckedComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.CheckedComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.CheckedComboBox.DropDownHeight = 1;
            this.CheckedComboBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckedComboBox.IntegralHeight = false;
            this.CheckedComboBox.Location = new System.Drawing.Point(0, 14);
            this.CheckedComboBox.Name = "CheckedComboBox";
            this.CheckedComboBox.Size = new System.Drawing.Size(204, 24);
            this.CheckedComboBox.TabIndex = 0;
            this.CheckedComboBox.ValueSeparator = ", ";
            // 
            // EspackCheckedComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CaptionLabel);
            this.Controls.Add(this.CheckedComboBox);
            this.Name = "EspackCheckedComboBox";
            this.Size = new System.Drawing.Size(204, 25);
            this.Controls.SetChildIndex(this.CheckedComboBox, 0);
            this.Controls.SetChildIndex(this.CaptionLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
