
namespace SerialTrackingPrintting
{
    partial class fLabelPrintting
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtEnterData = new EspackFormControlsNS.EspackTextBox();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(296, 28);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtEnterData
            // 
            this.txtEnterData.Add = false;
            this.txtEnterData.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtEnterData.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtEnterData.Caption = "Enter Data";
            this.txtEnterData.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtEnterData.DBField = null;
            this.txtEnterData.DBFieldType = null;
            this.txtEnterData.DefaultValue = null;
            this.txtEnterData.Del = false;
            this.txtEnterData.DependingRS = null;
            this.txtEnterData.ExtraDataLink = null;
            this.txtEnterData.IsCTLMOwned = false;
            this.txtEnterData.IsPassword = false;
            this.txtEnterData.Location = new System.Drawing.Point(12, 12);
            this.txtEnterData.Multiline = false;
            this.txtEnterData.Name = "txtEnterData";
            this.txtEnterData.Order = 0;
            this.txtEnterData.ParentConn = null;
            this.txtEnterData.ParentDA = null;
            this.txtEnterData.PK = false;
            this.txtEnterData.Protected = false;
            this.txtEnterData.ReadOnly = false;
            this.txtEnterData.Search = false;
            this.txtEnterData.Size = new System.Drawing.Size(278, 41);
            this.txtEnterData.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtEnterData.TabIndex = 2;
            this.txtEnterData.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEnterData.Upp = false;
            this.txtEnterData.Value = "";
            this.txtEnterData.WordWrap = true;
            // 
            // fLabelPrintting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 202);
            this.Controls.Add(this.txtEnterData);
            this.Controls.Add(this.btnPrint);
            this.Name = "fLabelPrintting";
            this.Text = "Label Printting";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        private EspackFormControlsNS.EspackTextBox txtEnterData;
    }
}

