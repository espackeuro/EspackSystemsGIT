﻿namespace Sistemas
{
    partial class fDNS
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
            this.btnProcess = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblMsg = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtPassword = new EspackFormControlsNS.EspackTextBox();
            this.txtUser = new EspackFormControlsNS.EspackTextBox();
            this.txtServerName = new EspackFormControlsNS.EspackTextBox();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(99, 199);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(133, 23);
            this.btnProcess.TabIndex = 17;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblMsg});
            this.statusStrip.Location = new System.Drawing.Point(0, 239);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(284, 22);
            this.statusStrip.TabIndex = 16;
            this.statusStrip.Text = "statusStrip";
            // 
            // lblMsg
            // 
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(42, 17);
            this.lblMsg.Text = "Status:";
            // 
            // txtPassword
            // 
            this.txtPassword.Add = false;
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.Caption = "Password";
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.DBField = null;
            this.txtPassword.DBFieldType = null;
            this.txtPassword.DefaultValue = null;
            this.txtPassword.Del = false;
            this.txtPassword.DependingRS = null;
            this.txtPassword.ExtraDataLink = null;
            this.txtPassword.ForeColor = System.Drawing.Color.Black;
            this.txtPassword.IsCTLMOwned = false;
            this.txtPassword.Location = new System.Drawing.Point(44, 139);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Order = 0;
            this.txtPassword.ParentConn = null;
            this.txtPassword.ParentDA = null;
            this.txtPassword.IsPassword = true;
            this.txtPassword.PK = false;
            this.txtPassword.Protected = false;
            this.txtPassword.ReadOnly = false;
            this.txtPassword.Search = true;
            this.txtPassword.Size = new System.Drawing.Size(188, 38);
            this.txtPassword.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtPassword.TabIndex = 15;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.Upp = true;
            
            this.txtPassword.Value = "";
            // 
            // txtUser
            // 
            this.txtUser.Add = false;
            this.txtUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUser.Caption = "User";
            this.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUser.DBField = null;
            this.txtUser.DBFieldType = null;
            this.txtUser.DefaultValue = null;
            this.txtUser.Del = false;
            this.txtUser.DependingRS = null;
            this.txtUser.ExtraDataLink = null;
            this.txtUser.ForeColor = System.Drawing.Color.Black;
            this.txtUser.IsCTLMOwned = false;
            this.txtUser.Location = new System.Drawing.Point(44, 82);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtUser.Multiline = true;
            this.txtUser.Name = "txtUser";
            this.txtUser.Order = 0;
            this.txtUser.ParentConn = null;
            this.txtUser.ParentDA = null;
            
            this.txtUser.PK = false;
            this.txtUser.Protected = false;
            this.txtUser.ReadOnly = false;
            this.txtUser.Search = true;
            this.txtUser.Size = new System.Drawing.Size(188, 38);
            this.txtUser.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtUser.TabIndex = 14;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUser.Upp = true;
            
            this.txtUser.Value = "";
            // 
            // txtServerName
            // 
            this.txtServerName.Add = false;
            this.txtServerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtServerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtServerName.Caption = "Server Name";
            this.txtServerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtServerName.DBField = null;
            this.txtServerName.DBFieldType = null;
            this.txtServerName.DefaultValue = null;
            this.txtServerName.Del = false;
            this.txtServerName.DependingRS = null;
            this.txtServerName.ExtraDataLink = null;
            this.txtServerName.ForeColor = System.Drawing.Color.Black;
            this.txtServerName.IsCTLMOwned = false;
            this.txtServerName.Location = new System.Drawing.Point(44, 25);
            this.txtServerName.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtServerName.Multiline = true;
            this.txtServerName.Name = "txtServerName";
            this.txtServerName.Order = 0;
            this.txtServerName.ParentConn = null;
            this.txtServerName.ParentDA = null;
            
            this.txtServerName.PK = false;
            this.txtServerName.Protected = false;
            this.txtServerName.ReadOnly = false;
            this.txtServerName.Search = true;
            this.txtServerName.Size = new System.Drawing.Size(188, 38);
            this.txtServerName.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtServerName.TabIndex = 13;
            this.txtServerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtServerName.Upp = true;
            
            this.txtServerName.Value = "";
            // 
            // fDNS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtServerName);
            this.Name = "fDNS";
            this.ShowIcon = false;
            this.Text = "DNS Control";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblMsg;
        private EspackFormControlsNS.EspackTextBox txtPassword;
        private EspackFormControlsNS.EspackTextBox txtUser;
        private EspackFormControlsNS.EspackTextBox txtServerName;
    }
}