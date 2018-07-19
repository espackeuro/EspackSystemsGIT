namespace EspackFormControlsNS
{
    partial class EspackFileStreamControl
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.TbFileName = new EspackFormControlsNS.EspackTextBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // CaptionLabel
            // 
            this.CaptionLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CaptionLabel.Size = new System.Drawing.Size(0, 13);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Controls.Add(this.btnSearch);
            this.panel.Controls.Add(this.TbFileName);
            this.panel.ForeColor = System.Drawing.Color.Transparent;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(154, 25);
            this.panel.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Silver;
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(129, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(25, 25);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "...";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // TbFileName
            // 
            this.TbFileName.Add = false;
            this.TbFileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.TbFileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.TbFileName.Caption = "";
            this.TbFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.TbFileName.DBField = null;
            this.TbFileName.DBFieldType = null;
            this.TbFileName.DefaultValue = null;
            this.TbFileName.Del = false;
            this.TbFileName.DependingRS = null;
            this.TbFileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TbFileName.ExtraDataLink = null;
            this.TbFileName.IsCTLMOwned = false;
            this.TbFileName.IsPassword = false;
            this.TbFileName.Location = new System.Drawing.Point(0, 0);
            this.TbFileName.Multiline = true;
            this.TbFileName.Name = "TbFileName";
            this.TbFileName.Order = 0;
            this.TbFileName.ParentConn = null;
            this.TbFileName.ParentDA = null;
            this.TbFileName.PK = false;
            this.TbFileName.Protected = false;
            this.TbFileName.ReadOnly = false;
            this.TbFileName.Search = false;
            this.TbFileName.Size = new System.Drawing.Size(154, 25);
            this.TbFileName.Status = CommonTools.EnumStatus.ADDNEW;
            this.TbFileName.TabIndex = 0;
            this.TbFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TbFileName.Upp = false;
            this.TbFileName.Value = "";
            // 
            // EspackFileStreamControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.CaptionLabel);
            this.Name = "EspackFileStreamControl";
            this.Size = new System.Drawing.Size(154, 25);
            this.Controls.SetChildIndex(this.CaptionLabel, 0);
            this.Controls.SetChildIndex(this.panel, 0);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSearch;
        private EspackTextBox TbFileName;
    }
}
