namespace EspackFormControls
{
    partial class EspackFileStream2
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
            this.espackTextBox1 = new EspackFormControls.EspackTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // espackTextBox1
            // 
            this.espackTextBox1.Add = false;
            this.espackTextBox1.BackColor = System.Drawing.Color.White;
            this.espackTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.espackTextBox1.Caption = "";
            this.espackTextBox1.DBField = null;
            this.espackTextBox1.DBFieldType = null;
            this.espackTextBox1.DefaultValue = null;
            this.espackTextBox1.Del = false;
            this.espackTextBox1.DependingRS = null;
            this.espackTextBox1.ExtraDataLink = null;
            this.espackTextBox1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.espackTextBox1.ForeColor = System.Drawing.Color.Black;
            this.espackTextBox1.IsCTLMOwned = false;
            this.espackTextBox1.Location = new System.Drawing.Point(4, 67);
            this.espackTextBox1.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.espackTextBox1.Name = "espackTextBox1";
            this.espackTextBox1.Order = 0;
            this.espackTextBox1.ParentConn = null;
            this.espackTextBox1.ParentDA = null;
            this.espackTextBox1.PK = false;
            this.espackTextBox1.Protected = false;
            this.espackTextBox1.Search = false;
            this.espackTextBox1.Size = new System.Drawing.Size(203, 17);
            this.espackTextBox1.Status = CommonTools.EnumStatus.ADDNEW;
            this.espackTextBox1.TabIndex = 0;
            this.espackTextBox1.Upp = false;
            this.espackTextBox1.Value = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EspackFileStream2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.espackTextBox1);
            this.Name = "EspackFileStream2";
            this.Size = new System.Drawing.Size(481, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackTextBox espackTextBox1;
        private System.Windows.Forms.Button button1;
    }
}
