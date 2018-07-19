namespace Sistemas
{
    partial class ServersList
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
            this.txtServerPwd = new EspackFormControlsNS.EspackTextBox();
            this.txtServerUser = new EspackFormControlsNS.EspackTextBox();
            this.grpServers = new System.Windows.Forms.GroupBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.grpServers.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServerPwd
            // 
            this.txtServerPwd.Add = false;
            this.txtServerPwd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtServerPwd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtServerPwd.Caption = "Password";
            this.txtServerPwd.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtServerPwd.DBField = null;
            this.txtServerPwd.DBFieldType = null;
            this.txtServerPwd.DefaultValue = null;
            this.txtServerPwd.Del = false;
            this.txtServerPwd.DependingRS = null;
            this.txtServerPwd.ExtraDataLink = null;
            this.txtServerPwd.ForeColor = System.Drawing.Color.Black;
            this.txtServerPwd.IsCTLMOwned = false;
            this.txtServerPwd.IsPassword = true;
            this.txtServerPwd.Location = new System.Drawing.Point(167, 16);
            this.txtServerPwd.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtServerPwd.Multiline = false;
            this.txtServerPwd.Name = "txtServerPwd";
            this.txtServerPwd.Order = 0;
            this.txtServerPwd.ParentConn = null;
            this.txtServerPwd.ParentDA = null;
            this.txtServerPwd.PK = false;
            this.txtServerPwd.Protected = false;
            this.txtServerPwd.ReadOnly = false;
            this.txtServerPwd.Search = false;
            this.txtServerPwd.Size = new System.Drawing.Size(130, 38);
            this.txtServerPwd.Status = CommonTools.EnumStatus.EDIT;
            this.txtServerPwd.TabIndex = 90;
            this.txtServerPwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtServerPwd.Upp = true;
            this.txtServerPwd.Value = "";
            // 
            // txtServerUser
            // 
            this.txtServerUser.Add = false;
            this.txtServerUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtServerUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtServerUser.Caption = "Server User";
            this.txtServerUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtServerUser.DBField = null;
            this.txtServerUser.DBFieldType = null;
            this.txtServerUser.DefaultValue = null;
            this.txtServerUser.Del = false;
            this.txtServerUser.DependingRS = null;
            this.txtServerUser.ExtraDataLink = null;
            this.txtServerUser.ForeColor = System.Drawing.Color.Black;
            this.txtServerUser.IsCTLMOwned = false;
            this.txtServerUser.IsPassword = false;
            this.txtServerUser.Location = new System.Drawing.Point(17, 16);
            this.txtServerUser.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtServerUser.Multiline = false;
            this.txtServerUser.Name = "txtServerUser";
            this.txtServerUser.Order = 0;
            this.txtServerUser.ParentConn = null;
            this.txtServerUser.ParentDA = null;
            this.txtServerUser.PK = false;
            this.txtServerUser.Protected = false;
            this.txtServerUser.ReadOnly = false;
            this.txtServerUser.Search = false;
            this.txtServerUser.Size = new System.Drawing.Size(130, 38);
            this.txtServerUser.Status = CommonTools.EnumStatus.EDIT;
            this.txtServerUser.TabIndex = 89;
            this.txtServerUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtServerUser.Upp = true;
            this.txtServerUser.Value = "";
            // 
            // grpServers
            // 
            this.grpServers.Controls.Add(this.chkSelectAll);
            this.grpServers.Location = new System.Drawing.Point(17, 55);
            this.grpServers.Name = "grpServers";
            this.grpServers.Size = new System.Drawing.Size(280, 474);
            this.grpServers.TabIndex = 88;
            this.grpServers.TabStop = false;
            this.grpServers.Text = "Servers";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(10, 20);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(108, 17);
            this.chkSelectAll.TabIndex = 0;
            this.chkSelectAll.Text = "Check All / None";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            // 
            // ServersList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtServerPwd);
            this.Controls.Add(this.txtServerUser);
            this.Controls.Add(this.grpServers);
            this.Name = "ServersList";
            this.Size = new System.Drawing.Size(315, 550);
            this.grpServers.ResumeLayout(false);
            this.grpServers.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EspackFormControlsNS.EspackTextBox txtServerPwd;
        private EspackFormControlsNS.EspackTextBox txtServerUser;
        private System.Windows.Forms.GroupBox grpServers;
        private System.Windows.Forms.CheckBox chkSelectAll;
    }
}
