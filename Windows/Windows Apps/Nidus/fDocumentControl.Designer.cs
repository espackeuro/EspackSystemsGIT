namespace Nidus
{
    partial class fDocumentControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDocumentControl));
            this.VS = new EspackDataGrid.EspackDataGridView();
            this.txtTest = new EspackFormControls.EspackTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.VS)).BeginInit();
            this.SuspendLayout();
            // 
            // VS
            // 
            this.VS.Add = false;
            this.VS.AllowDelete = false;
            this.VS.AllowInsert = false;
            this.VS.AllowUpdate = false;
            this.VS.AllowUserToAddRows = false;
            this.VS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.VS.Caption = "Test VS";
            this.VS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VS.Conn = null;
            this.VS.DBField = null;
            this.VS.DBFieldType = null;
            this.VS.DBTable = null;
            this.VS.DefaultValue = null;
            this.VS.Del = false;
            this.VS.DependingRS = null;
            this.VS.Dirty = false;
            this.VS.EspackControlParent = null;
            this.VS.ExtraDataLink = null;
            this.VS.FilterRow = null;
            this.VS.FilterRowEnabled = false;
            this.VS.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.VS.IsCTLMOwned = false;
            this.VS.IsFilterFocused = false;
            this.VS.Location = new System.Drawing.Point(58, 54);
            this.VS.MsgStatusLabel = null;
            this.VS.Name = "VS";
            this.VS.NumPages = 0;
            this.VS.Order = 0;
            this.VS.Page = 0;
            this.VS.Paginate = false;
            this.VS.ParentConn = null;
            this.VS.ParentDA = null;
            this.VS.PK = false;
            this.VS.Protected = false;
            this.VS.RowHeadersVisible = false;
            this.VS.Search = false;
            this.VS.Size = new System.Drawing.Size(439, 440);
            this.VS.SQL = null;
            this.VS.sSPAdd = "";
            this.VS.sSPDel = "";
            this.VS.sSPUpp = "";
            this.VS.Status = CommonTools.EnumStatus.SEARCH;
            this.VS.TabIndex = 5;
            this.VS.Upp = false;
            this.VS.Value = null;
            // 
            // txtTest
            // 
            this.txtTest.Add = false;
            this.txtTest.BackColor = System.Drawing.Color.White;
            this.txtTest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTest.Caption = "";
            this.txtTest.DBField = null;
            this.txtTest.DBFieldType = null;
            this.txtTest.DefaultValue = null;
            this.txtTest.Del = false;
            this.txtTest.DependingRS = null;
            this.txtTest.ExtraDataLink = null;
            this.txtTest.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtTest.ForeColor = System.Drawing.Color.Black;
            this.txtTest.IsCTLMOwned = false;
            this.txtTest.Location = new System.Drawing.Point(58, 523);
            this.txtTest.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtTest.Name = "txtTest";
            this.txtTest.Order = 0;
            this.txtTest.ParentConn = null;
            this.txtTest.ParentDA = null;
            this.txtTest.PK = false;
            this.txtTest.Protected = false;
            this.txtTest.Search = false;
            this.txtTest.Size = new System.Drawing.Size(100, 17);
            this.txtTest.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtTest.TabIndex = 6;
            this.txtTest.Upp = false;
            this.txtTest.Value = "";
            // 
            // fDocumentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 562);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.VS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fDocumentControl";
            this.Text = "Document Control";
            ((System.ComponentModel.ISupportInitialize)(this.VS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackDataGrid.EspackDataGridView VS;
        private EspackFormControls.EspackTextBox txtTest;
    }
}