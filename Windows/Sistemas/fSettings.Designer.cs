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
            this.txtDefaultPasswordForServers = new EspackFormControlsNS.EspackTextBox();
            this.txtDefaultUserForServers = new EspackFormControlsNS.EspackTextBox();
            this.SuspendLayout();
            // 
            // txtDefaultPasswordForServers
            // 
            this.txtDefaultPasswordForServers.Add = false;
            this.txtDefaultPasswordForServers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDefaultPasswordForServers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDefaultPasswordForServers.Caption = "Default Password For Servers";
            this.txtDefaultPasswordForServers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDefaultPasswordForServers.DBField = null;
            this.txtDefaultPasswordForServers.DBFieldType = null;
            this.txtDefaultPasswordForServers.DefaultValue = null;
            this.txtDefaultPasswordForServers.Del = false;
            this.txtDefaultPasswordForServers.DependingRS = null;
            this.txtDefaultPasswordForServers.ExtraDataLink = null;
            this.txtDefaultPasswordForServers.IsCTLMOwned = false;
            this.txtDefaultPasswordForServers.IsPassword = true;
            this.txtDefaultPasswordForServers.Location = new System.Drawing.Point(12, 57);
            this.txtDefaultPasswordForServers.Multiline = false;
            this.txtDefaultPasswordForServers.Name = "txtDefaultPasswordForServers";
            this.txtDefaultPasswordForServers.Order = 0;
            this.txtDefaultPasswordForServers.ParentConn = null;
            this.txtDefaultPasswordForServers.ParentDA = null;
            
            this.txtDefaultPasswordForServers.PK = false;
            this.txtDefaultPasswordForServers.Protected = false;
            this.txtDefaultPasswordForServers.ReadOnly = false;
            this.txtDefaultPasswordForServers.Search = false;
            this.txtDefaultPasswordForServers.Size = new System.Drawing.Size(260, 38);
            this.txtDefaultPasswordForServers.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDefaultPasswordForServers.TabIndex = 9;
            this.txtDefaultPasswordForServers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDefaultPasswordForServers.Upp = false;
            
            this.txtDefaultPasswordForServers.Value = "";
            // 
            // txtDefaultUserForServers
            // 
            this.txtDefaultUserForServers.Add = false;
            this.txtDefaultUserForServers.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDefaultUserForServers.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDefaultUserForServers.Caption = "Default User for Servers";
            this.txtDefaultUserForServers.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDefaultUserForServers.DBField = null;
            this.txtDefaultUserForServers.DBFieldType = null;
            this.txtDefaultUserForServers.DefaultValue = null;
            this.txtDefaultUserForServers.Del = false;
            this.txtDefaultUserForServers.DependingRS = null;
            this.txtDefaultUserForServers.ExtraDataLink = null;
            this.txtDefaultUserForServers.IsCTLMOwned = false;
            this.txtDefaultUserForServers.IsPassword = false;
            this.txtDefaultUserForServers.Location = new System.Drawing.Point(12, 13);
            this.txtDefaultUserForServers.Multiline = false;
            this.txtDefaultUserForServers.Name = "txtDefaultUserForServers";
            this.txtDefaultUserForServers.Order = 0;
            this.txtDefaultUserForServers.ParentConn = null;
            this.txtDefaultUserForServers.ParentDA = null;
            
            this.txtDefaultUserForServers.PK = false;
            this.txtDefaultUserForServers.Protected = false;
            this.txtDefaultUserForServers.ReadOnly = false;
            this.txtDefaultUserForServers.Search = false;
            this.txtDefaultUserForServers.Size = new System.Drawing.Size(260, 38);
            this.txtDefaultUserForServers.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDefaultUserForServers.TabIndex = 8;
            this.txtDefaultUserForServers.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDefaultUserForServers.Upp = false;
            
            this.txtDefaultUserForServers.Value = "";
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

        }

        #endregion
        private EspackFormControlsNS.EspackTextBox txtDefaultUserForServers;
        private EspackFormControlsNS.EspackTextBox txtDefaultPasswordForServers;
    }
}