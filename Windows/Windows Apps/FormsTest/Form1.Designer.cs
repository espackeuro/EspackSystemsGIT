namespace FormsTest
{
    partial class Form1
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
            this.listCOD3 = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtUserCode = new EspackFormControlsNS.EspackTextBox();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.SuspendLayout();
            // 
            // listCOD3
            // 
            this.listCOD3.Add = false;
            this.listCOD3.Caption = "COD3";
            this.listCOD3.CheckOnClick = true;
            this.listCOD3.ColumnWidth = 150;
            this.listCOD3.DataSource = null;
            this.listCOD3.DBField = null;
            this.listCOD3.DBFieldType = null;
            this.listCOD3.DefaultValue = null;
            this.listCOD3.Del = false;
            this.listCOD3.DependingRS = null;
            this.listCOD3.DisplayMember = "";
            this.listCOD3.ExtraDataLink = null;
            this.listCOD3.IsCTLMOwned = false;
            this.listCOD3.Location = new System.Drawing.Point(12, 102);
            this.listCOD3.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.listCOD3.MultiColumn = true;
            this.listCOD3.Name = "listCOD3";
            this.listCOD3.Order = 0;
            this.listCOD3.ParentConn = null;
            this.listCOD3.ParentDA = null;
            this.listCOD3.PK = false;
            this.listCOD3.Protected = false;
            this.listCOD3.ReadOnly = false;
            this.listCOD3.Search = false;
            this.listCOD3.SelectedItem = null;
            this.listCOD3.SelectedValue = null;
            this.listCOD3.Size = new System.Drawing.Size(321, 194);
            this.listCOD3.Status = CommonTools.EnumStatus.ADDNEW;
            this.listCOD3.TabIndex = 5;
            this.listCOD3.TBDescription = null;
            this.listCOD3.Upp = false;
            this.listCOD3.Value = "";
            this.listCOD3.ValueMember = "";
            // 
            // txtUserCode
            // 
            this.txtUserCode.Add = false;
            this.txtUserCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUserCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUserCode.Caption = "UserCode";
            this.txtUserCode.DBField = null;
            this.txtUserCode.DBFieldType = null;
            this.txtUserCode.DefaultValue = null;
            this.txtUserCode.Del = false;
            this.txtUserCode.DependingRS = null;
            this.txtUserCode.ExtraDataLink = null;
            this.txtUserCode.IsCTLMOwned = false;
            this.txtUserCode.Location = new System.Drawing.Point(13, 51);
            this.txtUserCode.Multiline = false;
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.Order = 0;
            this.txtUserCode.ParentConn = null;
            this.txtUserCode.ParentDA = null;
            this.txtUserCode.PK = false;
            this.txtUserCode.Protected = false;
            this.txtUserCode.ReadOnly = false;
            this.txtUserCode.Search = false;
            this.txtUserCode.Size = new System.Drawing.Size(154, 39);
            this.txtUserCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtUserCode.TabIndex = 4;
            this.txtUserCode.Upp = false;
            this.txtUserCode.Value = "Text";
            // 
            // CTLM
            // 
            this.CTLM.AutoSize = true;
            this.CTLM.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CTLM.BackColor = System.Drawing.Color.Transparent;
            this.CTLM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CTLM.Clear = false;
            this.CTLM.Conn = null;
            this.CTLM.DBTable = null;
            this.CTLM.Location = new System.Drawing.Point(13, 13);
            this.CTLM.MsgStatusInfoLabel = null;
            this.CTLM.MsgStatusLabel = null;
            this.CTLM.Name = "CTLM";
            this.CTLM.ReQuery = false;
            this.CTLM.Size = new System.Drawing.Size(300, 31);
            this.CTLM.sSPAdd = "";
            this.CTLM.sSPDel = "";
            this.CTLM.sSPUpp = "";
            this.CTLM.StatusBarProgress = null;
            this.CTLM.TabIndex = 3;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(584, 396);
            this.Controls.Add(this.listCOD3);
            this.Controls.Add(this.txtUserCode);
            this.Controls.Add(this.CTLM);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.EspackTextBox espackTextBox1;
        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackTextBox txtUserCode;
        private EspackFormControlsNS.EspackCheckedListBox listCOD3;
    }
}

