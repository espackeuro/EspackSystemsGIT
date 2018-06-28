namespace EspackFormControlsNS
{
    partial class EspackDateTimePicker
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
            this.DateTimePicker = new DateTimePickerFormatted();
            this.SuspendLayout();
            // 
            // DateTimePicker
            // 
            this.DateTimePicker.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.DateTimePicker.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateTimePicker.Location = new System.Drawing.Point(0, 15);
            this.DateTimePicker.Name = "DateTimePicker";
            this.DateTimePicker.Size = new System.Drawing.Size(150, 20);
            this.DateTimePicker.TabIndex = 0;
            // 
            // EspackTextBox
            // 
            this.Controls.Add(this.CaptionLabel);
            this.Controls.Add(this.DateTimePicker);
            this.Name = "EspackDateTimePicker";
            this.Size = new System.Drawing.Size(154, 38);
            this.Controls.SetChildIndex(this.DateTimePicker, 0);
            this.Controls.SetChildIndex(this.CaptionLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
