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
            this.txtCheckoutPwd = new EspackFormControls.EspackTextBox();
            this.txtCheckoutUser = new EspackFormControls.EspackTextBox();
            this.grpServers = new System.Windows.Forms.GroupBox();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.grpServers.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCheckoutPwd
            // 
            this.txtCheckoutPwd.Add = false;
            this.txtCheckoutPwd.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCheckoutPwd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCheckoutPwd.Caption = "Password";
            this.txtCheckoutPwd.DBField = null;
            this.txtCheckoutPwd.DBFieldType = null;
            this.txtCheckoutPwd.DefaultValue = null;
            this.txtCheckoutPwd.Del = false;
            this.txtCheckoutPwd.DependingRS = null;
            this.txtCheckoutPwd.ExtraDataLink = null;
            this.txtCheckoutPwd.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCheckoutPwd.ForeColor = System.Drawing.Color.Gray;
            this.txtCheckoutPwd.Location = new System.Drawing.Point(124, 22);
            this.txtCheckoutPwd.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtCheckoutPwd.Name = "txtCheckoutPwd";
            this.txtCheckoutPwd.Order = 0;
            this.txtCheckoutPwd.ParentConn = null;
            this.txtCheckoutPwd.ParentDA = null;
            this.txtCheckoutPwd.PK = false;
            this.txtCheckoutPwd.Protected = false;
            this.txtCheckoutPwd.ReadOnly = true;
            this.txtCheckoutPwd.Search = false;
            this.txtCheckoutPwd.Size = new System.Drawing.Size(100, 17);
            this.txtCheckoutPwd.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtCheckoutPwd.TabIndex = 90;
            this.txtCheckoutPwd.Upp = true;
            this.txtCheckoutPwd.UseSystemPasswordChar = true;
            this.txtCheckoutPwd.Value = "";
            // 
            // txtCheckoutUser
            // 
            this.txtCheckoutUser.Add = false;
            this.txtCheckoutUser.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCheckoutUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCheckoutUser.Caption = "Server User";
            this.txtCheckoutUser.DBField = null;
            this.txtCheckoutUser.DBFieldType = null;
            this.txtCheckoutUser.DefaultValue = null;
            this.txtCheckoutUser.Del = false;
            this.txtCheckoutUser.DependingRS = null;
            this.txtCheckoutUser.ExtraDataLink = null;
            this.txtCheckoutUser.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtCheckoutUser.ForeColor = System.Drawing.Color.Gray;
            this.txtCheckoutUser.Location = new System.Drawing.Point(17, 22);
            this.txtCheckoutUser.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtCheckoutUser.Name = "txtCheckoutUser";
            this.txtCheckoutUser.Order = 0;
            this.txtCheckoutUser.ParentConn = null;
            this.txtCheckoutUser.ParentDA = null;
            this.txtCheckoutUser.PK = false;
            this.txtCheckoutUser.Protected = false;
            this.txtCheckoutUser.ReadOnly = true;
            this.txtCheckoutUser.Search = false;
            this.txtCheckoutUser.Size = new System.Drawing.Size(100, 17);
            this.txtCheckoutUser.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtCheckoutUser.TabIndex = 89;
            this.txtCheckoutUser.Upp = true;
            this.txtCheckoutUser.Value = "";
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
            this.Controls.Add(this.txtCheckoutPwd);
            this.Controls.Add(this.txtCheckoutUser);
            this.Controls.Add(this.grpServers);
            this.Name = "ServersList";
            this.Size = new System.Drawing.Size(315, 550);
            this.grpServers.ResumeLayout(false);
            this.grpServers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControls.EspackTextBox txtCheckoutPwd;
        private EspackFormControls.EspackTextBox txtCheckoutUser;
        private System.Windows.Forms.GroupBox grpServers;
        private System.Windows.Forms.CheckBox chkSelectAll;
    }
}
