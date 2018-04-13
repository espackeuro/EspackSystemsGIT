namespace Sistemas
{
    partial class fSystemsMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fSystemsMaster));
            this.lstUserPositions = new EspackFormControls.EspackCheckedListBox();
            this.lstAreas = new EspackFormControls.EspackCheckedListBox();
            this.lstRequiredUserFlags = new EspackFormControls.EspackCheckedListBox();
            this.lstFlags = new EspackFormControls.EspackCheckedListBox();
            this.lstLocations = new EspackFormControls.EspackCheckedListBox();
            this.txtApp = new EspackFormControls.EspackTextBox();
            this.cboDatabase = new EspackFormControls.EspackComboBox();
            this.txtDescription = new EspackFormControls.EspackTextBox();
            this.txtSystemCode = new EspackFormControls.EspackTextBox();
            this.CTLM = new CTLMantenimientoNet.CTLMantenimientoNet();
            this.txtVersion = new EspackFormControls.EspackTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnReloadVersions = new System.Windows.Forms.ToolStripButton();
            this.txtNetVersion = new EspackFormControls.EspackTextBox();
            this.btnXMLFile = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstUserPositions
            // 
            this.lstUserPositions.Add = false;
            this.lstUserPositions.BackColor = System.Drawing.Color.White;
            this.lstUserPositions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstUserPositions.Caption = "User Positions";
            this.lstUserPositions.CheckOnClick = true;
            this.lstUserPositions.ColumnWidth = 200;
            this.lstUserPositions.DBField = null;
            this.lstUserPositions.DBFieldType = null;
            this.lstUserPositions.DefaultValue = null;
            this.lstUserPositions.Del = false;
            this.lstUserPositions.DependingRS = null;
            this.lstUserPositions.ExtraDataLink = null;
            this.lstUserPositions.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lstUserPositions.ForeColor = System.Drawing.Color.Black;
            this.lstUserPositions.FormattingEnabled = true;
            this.lstUserPositions.Location = new System.Drawing.Point(568, 156);
            this.lstUserPositions.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstUserPositions.MultiColumn = true;
            this.lstUserPositions.Name = "lstUserPositions";
            this.lstUserPositions.Order = 0;
            this.lstUserPositions.ParentConn = null;
            this.lstUserPositions.ParentDA = null;
            this.lstUserPositions.PK = false;
            this.lstUserPositions.Protected = false;
            this.lstUserPositions.Search = false;
            this.lstUserPositions.Size = new System.Drawing.Size(540, 95);
            this.lstUserPositions.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstUserPositions.TabIndex = 20;
            this.lstUserPositions.Upp = false;
            this.lstUserPositions.Value = "";
            // 
            // lstAreas
            // 
            this.lstAreas.Add = false;
            this.lstAreas.BackColor = System.Drawing.Color.White;
            this.lstAreas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstAreas.Caption = "Areas";
            this.lstAreas.CheckOnClick = true;
            this.lstAreas.ColumnWidth = 200;
            this.lstAreas.DBField = null;
            this.lstAreas.DBFieldType = null;
            this.lstAreas.DefaultValue = null;
            this.lstAreas.Del = false;
            this.lstAreas.DependingRS = null;
            this.lstAreas.ExtraDataLink = null;
            this.lstAreas.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lstAreas.ForeColor = System.Drawing.Color.Black;
            this.lstAreas.FormattingEnabled = true;
            this.lstAreas.Location = new System.Drawing.Point(12, 384);
            this.lstAreas.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstAreas.MultiColumn = true;
            this.lstAreas.Name = "lstAreas";
            this.lstAreas.Order = 0;
            this.lstAreas.ParentConn = null;
            this.lstAreas.ParentDA = null;
            this.lstAreas.PK = false;
            this.lstAreas.Protected = false;
            this.lstAreas.Search = false;
            this.lstAreas.Size = new System.Drawing.Size(540, 95);
            this.lstAreas.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstAreas.TabIndex = 18;
            this.lstAreas.Upp = false;
            this.lstAreas.Value = "";
            // 
            // lstRequiredUserFlags
            // 
            this.lstRequiredUserFlags.Add = false;
            this.lstRequiredUserFlags.BackColor = System.Drawing.Color.White;
            this.lstRequiredUserFlags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstRequiredUserFlags.Caption = "Required User Flags";
            this.lstRequiredUserFlags.CheckOnClick = true;
            this.lstRequiredUserFlags.ColumnWidth = 200;
            this.lstRequiredUserFlags.DBField = null;
            this.lstRequiredUserFlags.DBFieldType = null;
            this.lstRequiredUserFlags.DefaultValue = null;
            this.lstRequiredUserFlags.Del = false;
            this.lstRequiredUserFlags.DependingRS = null;
            this.lstRequiredUserFlags.ExtraDataLink = null;
            this.lstRequiredUserFlags.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lstRequiredUserFlags.ForeColor = System.Drawing.Color.Black;
            this.lstRequiredUserFlags.FormattingEnabled = true;
            this.lstRequiredUserFlags.Location = new System.Drawing.Point(568, 270);
            this.lstRequiredUserFlags.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstRequiredUserFlags.MultiColumn = true;
            this.lstRequiredUserFlags.Name = "lstRequiredUserFlags";
            this.lstRequiredUserFlags.Order = 0;
            this.lstRequiredUserFlags.ParentConn = null;
            this.lstRequiredUserFlags.ParentDA = null;
            this.lstRequiredUserFlags.PK = false;
            this.lstRequiredUserFlags.Protected = false;
            this.lstRequiredUserFlags.Search = false;
            this.lstRequiredUserFlags.Size = new System.Drawing.Size(540, 209);
            this.lstRequiredUserFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstRequiredUserFlags.TabIndex = 14;
            this.lstRequiredUserFlags.Upp = false;
            this.lstRequiredUserFlags.Value = "";
            // 
            // lstFlags
            // 
            this.lstFlags.Add = false;
            this.lstFlags.BackColor = System.Drawing.Color.White;
            this.lstFlags.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstFlags.Caption = "Flags";
            this.lstFlags.CheckOnClick = true;
            this.lstFlags.ColumnWidth = 200;
            this.lstFlags.DBField = null;
            this.lstFlags.DBFieldType = null;
            this.lstFlags.DefaultValue = null;
            this.lstFlags.Del = false;
            this.lstFlags.DependingRS = null;
            this.lstFlags.ExtraDataLink = null;
            this.lstFlags.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lstFlags.ForeColor = System.Drawing.Color.Black;
            this.lstFlags.FormattingEnabled = true;
            this.lstFlags.Location = new System.Drawing.Point(12, 498);
            this.lstFlags.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstFlags.MultiColumn = true;
            this.lstFlags.Name = "lstFlags";
            this.lstFlags.Order = 0;
            this.lstFlags.ParentConn = null;
            this.lstFlags.ParentDA = null;
            this.lstFlags.PK = false;
            this.lstFlags.Protected = false;
            this.lstFlags.Search = false;
            this.lstFlags.Size = new System.Drawing.Size(1096, 95);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 11;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            // 
            // lstLocations
            // 
            this.lstLocations.Add = false;
            this.lstLocations.BackColor = System.Drawing.Color.White;
            this.lstLocations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLocations.Caption = "Locations";
            this.lstLocations.CheckOnClick = true;
            this.lstLocations.ColumnWidth = 200;
            this.lstLocations.DBField = null;
            this.lstLocations.DBFieldType = null;
            this.lstLocations.DefaultValue = null;
            this.lstLocations.Del = false;
            this.lstLocations.DependingRS = null;
            this.lstLocations.ExtraDataLink = null;
            this.lstLocations.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lstLocations.ForeColor = System.Drawing.Color.Black;
            this.lstLocations.FormattingEnabled = true;
            this.lstLocations.Location = new System.Drawing.Point(13, 156);
            this.lstLocations.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstLocations.MultiColumn = true;
            this.lstLocations.Name = "lstLocations";
            this.lstLocations.Order = 0;
            this.lstLocations.ParentConn = null;
            this.lstLocations.ParentDA = null;
            this.lstLocations.PK = false;
            this.lstLocations.Protected = false;
            this.lstLocations.Search = false;
            this.lstLocations.Size = new System.Drawing.Size(539, 209);
            this.lstLocations.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstLocations.TabIndex = 9;
            this.lstLocations.Upp = false;
            this.lstLocations.Value = "";
            // 
            // txtApp
            // 
            this.txtApp.Add = false;
            this.txtApp.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtApp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtApp.Caption = "App";
            this.txtApp.DBField = null;
            this.txtApp.DBFieldType = null;
            this.txtApp.DefaultValue = null;
            this.txtApp.Del = false;
            this.txtApp.DependingRS = null;
            this.txtApp.ExtraDataLink = null;
            this.txtApp.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtApp.ForeColor = System.Drawing.Color.Gray;
            this.txtApp.Location = new System.Drawing.Point(149, 107);
            this.txtApp.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtApp.Name = "txtApp";
            this.txtApp.Order = 0;
            this.txtApp.ParentConn = null;
            this.txtApp.ParentDA = null;
            this.txtApp.PK = false;
            this.txtApp.Protected = false;
            this.txtApp.ReadOnly = true;
            this.txtApp.Search = false;
            this.txtApp.Size = new System.Drawing.Size(403, 17);
            this.txtApp.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtApp.TabIndex = 7;
            this.txtApp.Upp = false;
            this.txtApp.Value = "";
            // 
            // cboDatabase
            // 
            this.cboDatabase.Add = false;
            this.cboDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDatabase.BackColor = System.Drawing.Color.White;
            this.cboDatabase.Caption = "Database";
            this.cboDatabase.DBField = null;
            this.cboDatabase.DBFieldType = null;
            this.cboDatabase.DefaultValue = null;
            this.cboDatabase.Del = false;
            this.cboDatabase.DependingRS = null;
            this.cboDatabase.ExtraDataLink = null;
            this.cboDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDatabase.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboDatabase.ForeColor = System.Drawing.Color.Black;
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.Location = new System.Drawing.Point(12, 107);
            this.cboDatabase.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Order = 0;
            this.cboDatabase.ParentConn = null;
            this.cboDatabase.ParentDA = null;
            this.cboDatabase.PK = false;
            this.cboDatabase.Protected = false;
            this.cboDatabase.Search = false;
            this.cboDatabase.Size = new System.Drawing.Size(130, 24);
            this.cboDatabase.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboDatabase.TabIndex = 5;
            this.cboDatabase.TBDescription = null;
            this.cboDatabase.Upp = false;
            this.cboDatabase.Value = "";
            // 
            // txtDescription
            // 
            this.txtDescription.Add = false;
            this.txtDescription.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Caption = "Description";
            this.txtDescription.DBField = null;
            this.txtDescription.DBFieldType = null;
            this.txtDescription.DefaultValue = null;
            this.txtDescription.Del = false;
            this.txtDescription.DependingRS = null;
            this.txtDescription.ExtraDataLink = null;
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtDescription.Location = new System.Drawing.Point(149, 71);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Order = 0;
            this.txtDescription.ParentConn = null;
            this.txtDescription.ParentDA = null;
            this.txtDescription.PK = false;
            this.txtDescription.Protected = false;
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Search = false;
            this.txtDescription.Size = new System.Drawing.Size(403, 17);
            this.txtDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Upp = false;
            this.txtDescription.Value = "";
            // 
            // txtSystemCode
            // 
            this.txtSystemCode.Add = false;
            this.txtSystemCode.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtSystemCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSystemCode.Caption = "System Code";
            this.txtSystemCode.DBField = null;
            this.txtSystemCode.DBFieldType = null;
            this.txtSystemCode.DefaultValue = null;
            this.txtSystemCode.Del = false;
            this.txtSystemCode.DependingRS = null;
            this.txtSystemCode.ExtraDataLink = null;
            this.txtSystemCode.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtSystemCode.ForeColor = System.Drawing.Color.Gray;
            this.txtSystemCode.Location = new System.Drawing.Point(13, 71);
            this.txtSystemCode.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtSystemCode.Name = "txtSystemCode";
            this.txtSystemCode.Order = 0;
            this.txtSystemCode.ParentConn = null;
            this.txtSystemCode.ParentDA = null;
            this.txtSystemCode.PK = false;
            this.txtSystemCode.Protected = false;
            this.txtSystemCode.ReadOnly = true;
            this.txtSystemCode.Search = false;
            this.txtSystemCode.Size = new System.Drawing.Size(130, 17);
            this.txtSystemCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtSystemCode.TabIndex = 1;
            this.txtSystemCode.Upp = false;
            this.txtSystemCode.Value = "";
            // 
            // CTLM
            // 
            this.CTLM.Clear = false;
            this.CTLM.Conn = null;
            this.CTLM.DBTable = null;
            this.CTLM.Dock = System.Windows.Forms.DockStyle.None;
            this.CTLM.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.CTLM.Location = new System.Drawing.Point(13, 13);
            this.CTLM.MsgStatusInfoLabel = null;
            this.CTLM.MsgStatusLabel = null;
            this.CTLM.Name = "CTLM";
            this.CTLM.ReQuery = false;
            this.CTLM.Size = new System.Drawing.Size(290, 29);
            this.CTLM.sSPAdd = "";
            this.CTLM.sSPDel = "";
            this.CTLM.sSPUpp = "";
            this.CTLM.StatusBarProgress = null;
            this.CTLM.TabIndex = 0;
            this.CTLM.Text = "ctlMantenimientoNet1";
            // 
            // txtVersion
            // 
            this.txtVersion.Add = false;
            this.txtVersion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVersion.Caption = "Version";
            this.txtVersion.DBField = null;
            this.txtVersion.DBFieldType = null;
            this.txtVersion.DefaultValue = null;
            this.txtVersion.Del = false;
            this.txtVersion.DependingRS = null;
            this.txtVersion.ExtraDataLink = null;
            this.txtVersion.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtVersion.ForeColor = System.Drawing.Color.Gray;
            this.txtVersion.Location = new System.Drawing.Point(568, 71);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Order = 0;
            this.txtVersion.ParentConn = null;
            this.txtVersion.ParentDA = null;
            this.txtVersion.PK = false;
            this.txtVersion.Protected = false;
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Search = false;
            this.txtVersion.Size = new System.Drawing.Size(175, 17);
            this.txtVersion.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtVersion.TabIndex = 30;
            this.txtVersion.Upp = false;
            this.txtVersion.Value = "";
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadVersions,
            this.btnXMLFile});
            this.toolStrip2.Location = new System.Drawing.Point(834, 13);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(261, 31);
            this.toolStrip2.TabIndex = 43;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnReloadVersions
            // 
            this.btnReloadVersions.Image = global::Sistemas.Properties.Resources.reload_24;
            this.btnReloadVersions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReloadVersions.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReloadVersions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReloadVersions.Name = "btnReloadVersions";
            this.btnReloadVersions.Size = new System.Drawing.Size(117, 28);
            this.btnReloadVersions.Text = "Reload Versions";
            this.btnReloadVersions.Click += new System.EventHandler(this.btnReloadVersions_Click);
            // 
            // txtNetVersion
            // 
            this.txtNetVersion.Add = false;
            this.txtNetVersion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtNetVersion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNetVersion.Caption = "Net Version";
            this.txtNetVersion.DBField = null;
            this.txtNetVersion.DBFieldType = null;
            this.txtNetVersion.DefaultValue = null;
            this.txtNetVersion.Del = false;
            this.txtNetVersion.DependingRS = null;
            this.txtNetVersion.ExtraDataLink = null;
            this.txtNetVersion.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtNetVersion.ForeColor = System.Drawing.Color.Gray;
            this.txtNetVersion.Location = new System.Drawing.Point(568, 107);
            this.txtNetVersion.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtNetVersion.Name = "txtNetVersion";
            this.txtNetVersion.Order = 0;
            this.txtNetVersion.ParentConn = null;
            this.txtNetVersion.ParentDA = null;
            this.txtNetVersion.PK = false;
            this.txtNetVersion.Protected = false;
            this.txtNetVersion.ReadOnly = true;
            this.txtNetVersion.Search = false;
            this.txtNetVersion.Size = new System.Drawing.Size(175, 17);
            this.txtNetVersion.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtNetVersion.TabIndex = 45;
            this.txtNetVersion.Upp = false;
            this.txtNetVersion.Value = "";
            // 
            // btnXMLFile
            // 
            this.btnXMLFile.Image = ((System.Drawing.Image)(resources.GetObject("btnXMLFile.Image")));
            this.btnXMLFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXMLFile.Name = "btnXMLFile";
            this.btnXMLFile.Size = new System.Drawing.Size(101, 28);
            this.btnXMLFile.Text = "Generate XML";
            this.btnXMLFile.Click += new System.EventHandler(this.btnXMLFile_Click);
            // 
            // fSystemsMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1120, 707);
            this.Controls.Add(this.txtNetVersion);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.lstUserPositions);
            this.Controls.Add(this.lstAreas);
            this.Controls.Add(this.lstRequiredUserFlags);
            this.Controls.Add(this.lstFlags);
            this.Controls.Add(this.lstLocations);
            this.Controls.Add(this.txtApp);
            this.Controls.Add(this.cboDatabase);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtSystemCode);
            this.Controls.Add(this.CTLM);
            this.Name = "fSystemsMaster";
            this.ShowIcon = false;
            this.Text = "fSystemsMaster";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CTLMantenimientoNet.CTLMantenimientoNet CTLM;
        private EspackFormControls.EspackTextBox txtSystemCode;
        private EspackFormControls.EspackTextBox txtDescription;
        private EspackFormControls.EspackComboBox cboDatabase;
        private EspackFormControls.EspackTextBox txtApp;
        private EspackFormControls.EspackCheckedListBox lstLocations;
        private EspackFormControls.EspackCheckedListBox lstFlags;
        private EspackFormControls.EspackCheckedListBox lstRequiredUserFlags;
        private EspackFormControls.EspackCheckedListBox lstAreas;
        private EspackFormControls.EspackCheckedListBox lstUserPositions;
        private EspackFormControls.EspackTextBox txtVersion;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnReloadVersions;
        private EspackFormControls.EspackTextBox txtNetVersion;
        private System.Windows.Forms.ToolStripButton btnXMLFile;
    }
}