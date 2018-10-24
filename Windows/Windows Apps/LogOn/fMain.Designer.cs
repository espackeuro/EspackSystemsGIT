using System;

namespace LogOn
{
    partial class fMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.gbCredentials = new System.Windows.Forms.Panel();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.gbChangePassword = new System.Windows.Forms.Panel();
            this.btnCancelChange = new System.Windows.Forms.Button();
            this.btnOKChange = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.txtNewPINConfirm = new EspackFormControlsNS.EspackMaskedTextBox();
            this.txtNewPIN = new EspackFormControlsNS.EspackMaskedTextBox();
            this.txtNewPasswordConfirm = new EspackFormControlsNS.EspackTextBox();
            this.txtNewPassword = new EspackFormControlsNS.EspackTextBox();
            this.gbCred = new System.Windows.Forms.Panel();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtPassword = new EspackFormControlsNS.EspackTextBox();
            this.txtUser = new EspackFormControlsNS.EspackTextBox();
            this.gbApps = new System.Windows.Forms.Panel();
            this.tlpApps = new System.Windows.Forms.TableLayoutPanel();
            this.gbDebug = new System.Windows.Forms.Panel();
            this.gbCredentials.SuspendLayout();
            this.gbChangePassword.SuspendLayout();
            this.gbCred.SuspendLayout();
            this.gbApps.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCredentials
            // 
            this.gbCredentials.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCredentials.BackColor = System.Drawing.Color.Transparent;
            this.gbCredentials.Controls.Add(this.chkDebug);
            this.gbCredentials.Controls.Add(this.gbChangePassword);
            this.gbCredentials.Controls.Add(this.gbCred);
            this.gbCredentials.Location = new System.Drawing.Point(12, 12);
            this.gbCredentials.Name = "gbCredentials";
            this.gbCredentials.Size = new System.Drawing.Size(1686, 55);
            this.gbCredentials.TabIndex = 0;
            // 
            // chkDebug
            // 
            this.chkDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDebug.AutoSize = true;
            this.chkDebug.Location = new System.Drawing.Point(1600, 26);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(58, 17);
            this.chkDebug.TabIndex = 36;
            this.chkDebug.Text = "Debug";
            this.chkDebug.UseVisualStyleBackColor = true;
            this.chkDebug.CheckedChanged += new System.EventHandler(this.chkDebug_CheckedChanged);
            // 
            // gbChangePassword
            // 
            this.gbChangePassword.Controls.Add(this.btnCancelChange);
            this.gbChangePassword.Controls.Add(this.btnOKChange);
            this.gbChangePassword.Controls.Add(this.btnChange);
            this.gbChangePassword.Controls.Add(this.txtNewPINConfirm);
            this.gbChangePassword.Controls.Add(this.txtNewPIN);
            this.gbChangePassword.Controls.Add(this.txtNewPasswordConfirm);
            this.gbChangePassword.Controls.Add(this.txtNewPassword);
            this.gbChangePassword.Location = new System.Drawing.Point(319, 8);
            this.gbChangePassword.Name = "gbChangePassword";
            this.gbChangePassword.Size = new System.Drawing.Size(739, 41);
            this.gbChangePassword.TabIndex = 35;
            // 
            // btnCancelChange
            // 
            this.btnCancelChange.Location = new System.Drawing.Point(624, 11);
            this.btnCancelChange.Name = "btnCancelChange";
            this.btnCancelChange.Size = new System.Drawing.Size(75, 27);
            this.btnCancelChange.TabIndex = 41;
            this.btnCancelChange.Text = "Cancel";
            this.btnCancelChange.UseVisualStyleBackColor = true;
            this.btnCancelChange.Visible = false;
            this.btnCancelChange.Click += new System.EventHandler(this.btnCancelChange_Click);
            // 
            // btnOKChange
            // 
            this.btnOKChange.Location = new System.Drawing.Point(543, 11);
            this.btnOKChange.Name = "btnOKChange";
            this.btnOKChange.Size = new System.Drawing.Size(75, 27);
            this.btnOKChange.TabIndex = 40;
            this.btnOKChange.Text = "Ok";
            this.btnOKChange.UseVisualStyleBackColor = true;
            this.btnOKChange.Visible = false;
            this.btnOKChange.Click += new System.EventHandler(this.btnOKChange_Click);
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(3, 12);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(75, 27);
            this.btnChange.TabIndex = 39;
            this.btnChange.Text = "Change";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Visible = false;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtNewPINConfirm
            // 
            this.txtNewPINConfirm.Add = false;
            this.txtNewPINConfirm.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNewPINConfirm.Caption = "Confirm";
            this.txtNewPINConfirm.DBField = null;
            this.txtNewPINConfirm.DBFieldType = null;
            this.txtNewPINConfirm.DefaultValue = null;
            this.txtNewPINConfirm.Del = false;
            this.txtNewPINConfirm.DependingRS = null;
            this.txtNewPINConfirm.ExtraDataLink = null;
            this.txtNewPINConfirm.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtNewPINConfirm.IsCTLMOwned = false;
            this.txtNewPINConfirm.Location = new System.Drawing.Point(426, -2);
            this.txtNewPINConfirm.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtNewPINConfirm.Mask = "9999";
            this.txtNewPINConfirm.Multiline = false;
            this.txtNewPINConfirm.Name = "txtNewPINConfirm";
            this.txtNewPINConfirm.Order = 0;
            this.txtNewPINConfirm.ParentConn = null;
            this.txtNewPINConfirm.ParentDA = null;
            this.txtNewPINConfirm.PasswordChar = '●';
            this.txtNewPINConfirm.PK = false;
            this.txtNewPINConfirm.PromptChar = ' ';
            this.txtNewPINConfirm.Protected = false;
            this.txtNewPINConfirm.ReadOnly = false;
            this.txtNewPINConfirm.Search = false;
            this.txtNewPINConfirm.Size = new System.Drawing.Size(108, 32);
            this.txtNewPINConfirm.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtNewPINConfirm.TabIndex = 38;
            this.txtNewPINConfirm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewPINConfirm.Upp = true;
            this.txtNewPINConfirm.UseSystemPasswordChar = true;
            this.txtNewPINConfirm.Value = "";
            this.txtNewPINConfirm.Visible = false;
            // 
            // txtNewPIN
            // 
            this.txtNewPIN.Add = false;
            this.txtNewPIN.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNewPIN.Caption = "PIN";
            this.txtNewPIN.DBField = null;
            this.txtNewPIN.DBFieldType = null;
            this.txtNewPIN.DefaultValue = null;
            this.txtNewPIN.Del = false;
            this.txtNewPIN.DependingRS = null;
            this.txtNewPIN.ExtraDataLink = null;
            this.txtNewPIN.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtNewPIN.IsCTLMOwned = false;
            this.txtNewPIN.Location = new System.Drawing.Point(312, -2);
            this.txtNewPIN.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtNewPIN.Mask = "9999";
            this.txtNewPIN.Multiline = false;
            this.txtNewPIN.Name = "txtNewPIN";
            this.txtNewPIN.Order = 0;
            this.txtNewPIN.ParentConn = null;
            this.txtNewPIN.ParentDA = null;
            this.txtNewPIN.PasswordChar = '●';
            this.txtNewPIN.PK = false;
            this.txtNewPIN.PromptChar = ' ';
            this.txtNewPIN.Protected = false;
            this.txtNewPIN.ReadOnly = false;
            this.txtNewPIN.Search = false;
            this.txtNewPIN.Size = new System.Drawing.Size(108, 32);
            this.txtNewPIN.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtNewPIN.TabIndex = 37;
            this.txtNewPIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNewPIN.Upp = true;
            this.txtNewPIN.UseSystemPasswordChar = true;
            this.txtNewPIN.Value = "";
            this.txtNewPIN.Visible = false;
            // 
            // txtNewPasswordConfirm
            // 
            this.txtNewPasswordConfirm.Add = false;
            this.txtNewPasswordConfirm.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtNewPasswordConfirm.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtNewPasswordConfirm.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNewPasswordConfirm.Caption = "Confirm";
            this.txtNewPasswordConfirm.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNewPasswordConfirm.DBField = null;
            this.txtNewPasswordConfirm.DBFieldType = null;
            this.txtNewPasswordConfirm.DefaultValue = null;
            this.txtNewPasswordConfirm.Del = false;
            this.txtNewPasswordConfirm.DependingRS = null;
            this.txtNewPasswordConfirm.ExtraDataLink = null;
            this.txtNewPasswordConfirm.ForeColor = System.Drawing.Color.Gray;
            this.txtNewPasswordConfirm.IsCTLMOwned = false;
            this.txtNewPasswordConfirm.IsPassword = true;
            this.txtNewPasswordConfirm.Location = new System.Drawing.Point(198, -2);
            this.txtNewPasswordConfirm.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtNewPasswordConfirm.Multiline = true;
            this.txtNewPasswordConfirm.Name = "txtNewPasswordConfirm";
            this.txtNewPasswordConfirm.Order = 0;
            this.txtNewPasswordConfirm.ParentConn = null;
            this.txtNewPasswordConfirm.ParentDA = null;
            this.txtNewPasswordConfirm.PK = false;
            this.txtNewPasswordConfirm.Protected = false;
            this.txtNewPasswordConfirm.ReadOnly = false;
            this.txtNewPasswordConfirm.Search = false;
            this.txtNewPasswordConfirm.Size = new System.Drawing.Size(108, 46);
            this.txtNewPasswordConfirm.Status = CommonTools.EnumStatus.EDIT;
            this.txtNewPasswordConfirm.TabIndex = 36;
            this.txtNewPasswordConfirm.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNewPasswordConfirm.Upp = true;
            this.txtNewPasswordConfirm.Value = "";
            this.txtNewPasswordConfirm.Visible = false;
            this.txtNewPasswordConfirm.WordWrap = true;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Add = false;
            this.txtNewPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtNewPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtNewPassword.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNewPassword.Caption = "New Password";
            this.txtNewPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNewPassword.DBField = null;
            this.txtNewPassword.DBFieldType = null;
            this.txtNewPassword.DefaultValue = null;
            this.txtNewPassword.Del = false;
            this.txtNewPassword.DependingRS = null;
            this.txtNewPassword.ExtraDataLink = null;
            this.txtNewPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtNewPassword.IsCTLMOwned = false;
            this.txtNewPassword.IsPassword = true;
            this.txtNewPassword.Location = new System.Drawing.Point(84, -2);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtNewPassword.Multiline = true;
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Order = 0;
            this.txtNewPassword.ParentConn = null;
            this.txtNewPassword.ParentDA = null;
            this.txtNewPassword.PK = false;
            this.txtNewPassword.Protected = false;
            this.txtNewPassword.ReadOnly = false;
            this.txtNewPassword.Search = false;
            this.txtNewPassword.Size = new System.Drawing.Size(108, 46);
            this.txtNewPassword.Status = CommonTools.EnumStatus.EDIT;
            this.txtNewPassword.TabIndex = 35;
            this.txtNewPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNewPassword.Upp = true;
            this.txtNewPassword.Value = "";
            this.txtNewPassword.Visible = false;
            this.txtNewPassword.WordWrap = true;
            // 
            // gbCred
            // 
            this.gbCred.BackColor = System.Drawing.Color.Transparent;
            this.gbCred.Controls.Add(this.btnOk);
            this.gbCred.Controls.Add(this.txtPassword);
            this.gbCred.Controls.Add(this.txtUser);
            this.gbCred.Location = new System.Drawing.Point(6, 8);
            this.gbCred.Margin = new System.Windows.Forms.Padding(0);
            this.gbCred.Name = "gbCred";
            this.gbCred.Size = new System.Drawing.Size(310, 41);
            this.gbCred.TabIndex = 34;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(228, 12);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 27);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Add = false;
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtPassword.Caption = "Password";
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.DBField = null;
            this.txtPassword.DBFieldType = null;
            this.txtPassword.DefaultValue = null;
            this.txtPassword.Del = false;
            this.txtPassword.DependingRS = null;
            this.txtPassword.ExtraDataLink = null;
            this.txtPassword.ForeColor = System.Drawing.Color.Gray;
            this.txtPassword.IsCTLMOwned = false;
            this.txtPassword.IsPassword = true;
            this.txtPassword.Location = new System.Drawing.Point(114, 0);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtPassword.Multiline = true;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Order = 0;
            this.txtPassword.ParentConn = null;
            this.txtPassword.ParentDA = null;
            this.txtPassword.PK = false;
            this.txtPassword.Protected = false;
            this.txtPassword.ReadOnly = false;
            this.txtPassword.Search = false;
            this.txtPassword.Size = new System.Drawing.Size(108, 46);
            this.txtPassword.Status = CommonTools.EnumStatus.EDIT;
            this.txtPassword.TabIndex = 2;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.Upp = true;
            this.txtPassword.Value = "";
            this.txtPassword.WordWrap = true;
            // 
            // txtUser
            // 
            this.txtUser.Add = false;
            this.txtUser.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUser.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUser.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtUser.Caption = "User";
            this.txtUser.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUser.DBField = null;
            this.txtUser.DBFieldType = null;
            this.txtUser.DefaultValue = null;
            this.txtUser.Del = false;
            this.txtUser.DependingRS = null;
            this.txtUser.ExtraDataLink = null;
            this.txtUser.ForeColor = System.Drawing.Color.Gray;
            this.txtUser.IsCTLMOwned = false;
            this.txtUser.IsPassword = false;
            this.txtUser.Location = new System.Drawing.Point(0, 0);
            this.txtUser.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtUser.Multiline = true;
            this.txtUser.Name = "txtUser";
            this.txtUser.Order = 0;
            this.txtUser.ParentConn = null;
            this.txtUser.ParentDA = null;
            this.txtUser.PK = false;
            this.txtUser.Protected = false;
            this.txtUser.ReadOnly = false;
            this.txtUser.Search = false;
            this.txtUser.Size = new System.Drawing.Size(108, 46);
            this.txtUser.Status = CommonTools.EnumStatus.EDIT;
            this.txtUser.TabIndex = 0;
            this.txtUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUser.Upp = true;
            this.txtUser.Value = "";
            this.txtUser.WordWrap = false;
            // 
            // gbApps
            // 
            this.gbApps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbApps.BackColor = System.Drawing.Color.Transparent;
            this.gbApps.Controls.Add(this.tlpApps);
            this.gbApps.Location = new System.Drawing.Point(12, 74);
            this.gbApps.Name = "gbApps";
            this.gbApps.Size = new System.Drawing.Size(1686, 539);
            this.gbApps.TabIndex = 1;
            // 
            // tlpApps
            // 
            this.tlpApps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpApps.AutoScroll = true;
            this.tlpApps.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpApps.BackColor = System.Drawing.Color.Transparent;
            this.tlpApps.ColumnCount = 1;
            this.tlpApps.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1687F));
            this.tlpApps.Location = new System.Drawing.Point(0, 0);
            this.tlpApps.Name = "tlpApps";
            this.tlpApps.RowCount = 1;
            this.tlpApps.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 533F));
            this.tlpApps.Size = new System.Drawing.Size(1687, 533);
            this.tlpApps.TabIndex = 2;
            // 
            // gbDebug
            // 
            this.gbDebug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDebug.BackColor = System.Drawing.Color.Transparent;
            this.gbDebug.Location = new System.Drawing.Point(12, 619);
            this.gbDebug.Name = "gbDebug";
            this.gbDebug.Size = new System.Drawing.Size(1683, 132);
            this.gbDebug.TabIndex = 3;
            this.gbDebug.Text = "Debug";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1710, 783);
            this.Controls.Add(this.gbDebug);
            this.Controls.Add(this.gbApps);
            this.Controls.Add(this.gbCredentials);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.Text = "LogOn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbCredentials.ResumeLayout(false);
            this.gbCredentials.PerformLayout();
            this.gbChangePassword.ResumeLayout(false);
            this.gbCred.ResumeLayout(false);
            this.gbApps.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel gbCredentials;
        private System.Windows.Forms.Panel gbApps;
        private LogOnObjects.cAppBot cAppBot1;
        private System.Windows.Forms.TableLayoutPanel tlpApps;
        private System.Windows.Forms.TextBox txtDebug1;
        private System.Windows.Forms.Panel gbDebug;
        private System.Windows.Forms.Panel gbChangePassword;
        private System.Windows.Forms.Button btnCancelChange;
        private System.Windows.Forms.Button btnOKChange;
        private System.Windows.Forms.Button btnChange;
        private EspackFormControlsNS.EspackMaskedTextBox txtNewPINConfirm;
        private EspackFormControlsNS.EspackMaskedTextBox txtNewPIN;
        private EspackFormControlsNS.EspackTextBox txtNewPasswordConfirm;
        private EspackFormControlsNS.EspackTextBox txtNewPassword;
        private System.Windows.Forms.Panel gbCred;
        private System.Windows.Forms.Button btnOk;
        private EspackFormControlsNS.EspackTextBox txtPassword;
        private EspackFormControlsNS.EspackTextBox txtUser;
        private System.Windows.Forms.CheckBox chkDebug;
    }
}

