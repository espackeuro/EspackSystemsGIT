namespace Sistemas
{
    partial class fSettings
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
            this.txtDefaultUserForServers = new EspackFormControls.EspackTextBox();
            this.txtDefaultPasswordForServers = new EspackFormControls.EspackTextBox();
            this.SuspendLayout();
            // 
            // txtDefaultUserForServers
            // 
            this.txtDefaultUserForServers.Add = false;
            this.txtDefaultUserForServers.BackColor = System.Drawing.Color.White;
            this.txtDefaultUserForServers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDefaultUserForServers.Caption = "Default User for Servers";
            this.txtDefaultUserForServers.DBField = null;
            this.txtDefaultUserForServers.DBFieldType = null;
            this.txtDefaultUserForServers.DefaultValue = null;
            this.txtDefaultUserForServers.Del = false;
            this.txtDefaultUserForServers.DependingRS = null;
            this.txtDefaultUserForServers.ExtraDataLink = null;
            this.txtDefaultUserForServers.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDefaultUserForServers.ForeColor = System.Drawing.Color.Black;
            this.txtDefaultUserForServers.Location = new System.Drawing.Point(12, 35);
            this.txtDefaultUserForServers.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDefaultUserForServers.Name = "txtDefaultUserForServers";
            this.txtDefaultUserForServers.Order = 0;
            this.txtDefaultUserForServers.ParentConn = null;
            this.txtDefaultUserForServers.ParentDA = null;
            this.txtDefaultUserForServers.PK = false;
            this.txtDefaultUserForServers.Protected = false;
            this.txtDefaultUserForServers.Search = false;
            this.txtDefaultUserForServers.Size = new System.Drawing.Size(224, 17);
            this.txtDefaultUserForServers.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.txtDefaultUserForServers.TabIndex = 4;
            this.txtDefaultUserForServers.Upp = false;
            this.txtDefaultUserForServers.Value = "";
            // 
            // txtDefaultPasswordForServers
            // 
            this.txtDefaultPasswordForServers.Add = false;
            this.txtDefaultPasswordForServers.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtDefaultPasswordForServers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDefaultPasswordForServers.Caption = "Default Password for Servers";
            this.txtDefaultPasswordForServers.DBField = null;
            this.txtDefaultPasswordForServers.DBFieldType = null;
            this.txtDefaultPasswordForServers.DefaultValue = null;
            this.txtDefaultPasswordForServers.Del = false;
            this.txtDefaultPasswordForServers.DependingRS = null;
            this.txtDefaultPasswordForServers.ExtraDataLink = null;
            this.txtDefaultPasswordForServers.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDefaultPasswordForServers.ForeColor = System.Drawing.Color.Gray;
            this.txtDefaultPasswordForServers.Location = new System.Drawing.Point(12, 71);
            this.txtDefaultPasswordForServers.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDefaultPasswordForServers.Name = "txtDefaultPasswordForServers";
            this.txtDefaultPasswordForServers.Order = 0;
            this.txtDefaultPasswordForServers.ParentConn = null;
            this.txtDefaultPasswordForServers.ParentDA = null;
            this.txtDefaultPasswordForServers.PK = false;
            this.txtDefaultPasswordForServers.Protected = false;
            this.txtDefaultPasswordForServers.Search = false;
            this.txtDefaultPasswordForServers.Size = new System.Drawing.Size(224, 17);
            this.txtDefaultPasswordForServers.SetStatus(CommonTools.EnumStatus.ADDNEW);
            this.txtDefaultPasswordForServers.TabIndex = 7;
            this.txtDefaultPasswordForServers.Upp = false;
            this.txtDefaultPasswordForServers.UseSystemPasswordChar = true;
            this.txtDefaultPasswordForServers.Value = "";
            // 
            // fSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtDefaultPasswordForServers);
            this.Controls.Add(this.txtDefaultUserForServers);
            this.Name = "fSettings";
            this.ShowIcon = false;
            this.Text = "fSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControls.EspackTextBox txtDefaultUserForServers;
        private EspackFormControls.EspackTextBox txtDefaultPasswordForServers;
    }
}