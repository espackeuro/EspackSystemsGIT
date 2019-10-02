namespace Personal
{
    partial class fLocalHolidays
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
            this.cboYear = new EspackFormControlsNS.EspackComboBox();
            this.cboCOD3 = new EspackFormControlsNS.EspackComboBox();
            this.yearCalendar = new Personal.MiMonthCalendar();
            this.chkWeekEnds = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cboYear
            // 
            this.cboYear.Add = false;
            this.cboYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboYear.Caption = "Year";
            this.cboYear.DataSource = null;
            this.cboYear.DBField = null;
            this.cboYear.DBFieldType = null;
            this.cboYear.DefaultValue = null;
            this.cboYear.Del = false;
            this.cboYear.DependingRS = null;
            this.cboYear.DisplayMember = "";
            this.cboYear.ExtraDataLink = null;
            this.cboYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboYear.FormattingEnabled = false;
            this.cboYear.IsCTLMOwned = false;
            this.cboYear.Location = new System.Drawing.Point(31, 25);
            this.cboYear.Name = "cboYear";
            this.cboYear.Order = 0;
            this.cboYear.ParentConn = null;
            this.cboYear.ParentDA = null;
            this.cboYear.PK = false;
            this.cboYear.Protected = false;
            this.cboYear.ReadOnly = false;
            this.cboYear.Search = false;
            this.cboYear.SelectedItem = null;
            this.cboYear.SelectedValue = null;
            this.cboYear.Size = new System.Drawing.Size(130, 47);
            this.cboYear.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboYear.TabIndex = 0;
            this.cboYear.TBDescription = null;
            this.cboYear.Text = "espackComboBox1";
            this.cboYear.Upp = false;
            this.cboYear.Value = "espackComboBox1";
            this.cboYear.ValueMember = "";
            // 
            // cboCOD3
            // 
            this.cboCOD3.Add = false;
            this.cboCOD3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCOD3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCOD3.Caption = "Warehouse";
            this.cboCOD3.DataSource = null;
            this.cboCOD3.DBField = null;
            this.cboCOD3.DBFieldType = null;
            this.cboCOD3.DefaultValue = null;
            this.cboCOD3.Del = false;
            this.cboCOD3.DependingRS = null;
            this.cboCOD3.DisplayMember = "";
            this.cboCOD3.ExtraDataLink = null;
            this.cboCOD3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCOD3.FormattingEnabled = false;
            this.cboCOD3.IsCTLMOwned = false;
            this.cboCOD3.Location = new System.Drawing.Point(167, 25);
            this.cboCOD3.Name = "cboCOD3";
            this.cboCOD3.Order = 0;
            this.cboCOD3.ParentConn = null;
            this.cboCOD3.ParentDA = null;
            this.cboCOD3.PK = false;
            this.cboCOD3.Protected = false;
            this.cboCOD3.ReadOnly = false;
            this.cboCOD3.Search = false;
            this.cboCOD3.SelectedItem = null;
            this.cboCOD3.SelectedValue = null;
            this.cboCOD3.Size = new System.Drawing.Size(130, 47);
            this.cboCOD3.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboCOD3.TabIndex = 1;
            this.cboCOD3.TBDescription = null;
            this.cboCOD3.Text = "espackComboBox2";
            this.cboCOD3.Upp = false;
            this.cboCOD3.Value = "espackComboBox2";
            this.cboCOD3.ValueMember = "";
            // 
            // yearCalendar
            // 
            this.yearCalendar.CalendarDimensions = new System.Drawing.Size(4, 3);
            this.yearCalendar.Location = new System.Drawing.Point(31, 79);
            this.yearCalendar.MaxDate = new System.DateTime(2019, 12, 31, 0, 0, 0, 0);
            this.yearCalendar.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.yearCalendar.Name = "yearCalendar";
            this.yearCalendar.ShowToday = false;
            this.yearCalendar.TabIndex = 2;
            // 
            // chkWeekEnds
            // 
            this.chkWeekEnds.AutoSize = true;
            this.chkWeekEnds.Checked = true;
            this.chkWeekEnds.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkWeekEnds.Location = new System.Drawing.Point(303, 46);
            this.chkWeekEnds.Name = "chkWeekEnds";
            this.chkWeekEnds.Size = new System.Drawing.Size(97, 21);
            this.chkWeekEnds.TabIndex = 3;
            this.chkWeekEnds.Text = "Weekends";
            this.chkWeekEnds.ThreeState = true;
            this.chkWeekEnds.UseVisualStyleBackColor = true;
            this.chkWeekEnds.CheckedChanged += new System.EventHandler(this.ChkWeekEnds_CheckedChanged);
            // 
            // fLocalHolidays
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 877);
            this.Controls.Add(this.chkWeekEnds);
            this.Controls.Add(this.yearCalendar);
            this.Controls.Add(this.cboCOD3);
            this.Controls.Add(this.cboYear);
            this.Name = "fLocalHolidays";
            this.Text = "fLocalHolidays";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.EspackComboBox cboYear;
        private EspackFormControlsNS.EspackComboBox cboCOD3;
        private MiMonthCalendar yearCalendar;
        private System.Windows.Forms.CheckBox chkWeekEnds;
    }
}