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
            this.txtServerPwd = new EspackFormControls.EspackTextBox();
            this.txtServerUser = new EspackFormControls.EspackTextBox();
            this.grpServers = new System.Windows.Forms.GroupBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.grpServers.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtServerPwd
            // 
            this.txtServerPwd.Add = false;
            this.txtServerPwd.BackColor = System.Drawing.Color.White;
            this.txtServerPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtServerPwd.Caption = "Password";
            this.txtServerPwd.DBField = null;
            this.txtServerPwd.DBFieldType = null;
            this.txtServerPwd.DefaultValue = null;
            this.txtServerPwd.Del = false;
            this.txtServerPwd.DependingRS = null;
            this.txtServerPwd.ExtraDataLink = null;
            this.txtServerPwd.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtServerPwd.ForeColor = System.Drawing.Color.Black;
            this.txtServerPwd.Location = new System.Drawing.Point(167, 22);
            this.txtServerPwd.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtServerPwd.Name = "txtServerPwd";
            this.txtServerPwd.Order = 0;
            this.txtServerPwd.ParentConn = null;
            this.txtServerPwd.ParentDA = null;
            this.txtServerPwd.PK = false;
            this.txtServerPwd.Protected = false;
            this.txtServerPwd.Search = false;
            this.txtServerPwd.Size = new System.Drawing.Size(130, 17);
            this.txtServerPwd.SetStatus(CommonTools.EnumStatus.EDIT);
            this.txtServerPwd.TabIndex = 90;
            this.txtServerPwd.Upp = true;
            this.txtServerPwd.UseSystemPasswordChar = true;
            this.txtServerPwd.Value = "";
            // 
            // txtServerUser
            // 
            this.txtServerUser.Add = false;
            this.txtServerUser.BackColor = System.Drawing.Color.White;
            this.txtServerUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtServerUser.Caption = "Server User";
            this.txtServerUser.DBField = null;
            this.txtServerUser.DBFieldType = null;
            this.txtServerUser.DefaultValue = null;
            this.txtServerUser.Del = false;
            this.txtServerUser.DependingRS = null;
            this.txtServerUser.ExtraDataLink = null;
            this.txtServerUser.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtServerUser.ForeColor = System.Drawing.Color.Black;
            this.txtServerUser.Location = new System.Drawing.Point(17, 22);
            this.txtServerUser.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtServerUser.Name = "txtServerUser";
            this.txtServerUser.Order = 0;
            this.txtServerUser.ParentConn = null;
            this.txtServerUser.ParentDA = null;
            this.txtServerUser.PK = false;
            this.txtServerUser.Protected = false;
            this.txtServerUser.Search = false;
            this.txtServerUser.Size = new System.Drawing.Size(144, 17);
            this.txtServerUser.SetStatus(CommonTools.EnumStatus.EDIT);
            this.txtServerUser.TabIndex = 89;
            this.txtServerUser.Upp = true;
            this.txtServerUser.Value = "";
            // 
            // grpServers
            // 
            this.grpServers.BackColor = System.Drawing.SystemColors.Control;
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
            this.PerformLayout();

        }

        #endregion

        private EspackFormControls.EspackTextBox txtServerPwd;
        private EspackFormControls.EspackTextBox txtServerUser;
        private System.Windows.Forms.GroupBox grpServers;
        private System.Windows.Forms.CheckBox chkSelectAll;
    }
}
