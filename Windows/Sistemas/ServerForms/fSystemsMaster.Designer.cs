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
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnReloadVersions = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnXMLFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCommit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnServerCheckout = new System.Windows.Forms.ToolStripButton();
            this.txtNetVersion = new EspackFormControlsNS.EspackTextBox();
            this.txtVersion = new EspackFormControlsNS.EspackTextBox();
            this.lstUserPositions = new EspackFormControlsNS.EspackCheckedListBox();
            this.lstAreas = new EspackFormControlsNS.EspackCheckedListBox();
            this.lstRequiredUserFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.lstFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.lstLocations = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtApp = new EspackFormControlsNS.EspackTextBox();
            this.cboDatabase = new EspackFormControlsNS.EspackComboBox();
            this.txtDescription = new EspackFormControlsNS.EspackTextBox();
            this.txtSystemCode = new EspackFormControlsNS.EspackTextBox();
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.serversList1 = new Sistemas.ServersList();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadVersions,
            this.toolStripSeparator1,
            this.btnXMLFile,
            this.toolStripSeparator2,
            this.btnCommit,
            this.toolStripSeparator3,
            this.btnServerCheckout});
            this.toolStrip2.Location = new System.Drawing.Point(917, 13);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(505, 39);
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
            this.btnReloadVersions.Size = new System.Drawing.Size(117, 36);
            this.btnReloadVersions.Text = "Reload Versions";
            this.btnReloadVersions.Click += new System.EventHandler(this.btnReloadVersions_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // btnXMLFile
            // 
            this.btnXMLFile.Image = global::Sistemas.Properties.Resources.xml;
            this.btnXMLFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnXMLFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXMLFile.Name = "btnXMLFile";
            this.btnXMLFile.Size = new System.Drawing.Size(117, 36);
            this.btnXMLFile.Text = "Generate XML";
            this.btnXMLFile.Click += new System.EventHandler(this.btnXMLFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnCommit
            // 
            this.btnCommit.Image = global::Sistemas.Properties.Resources.commit;
            this.btnCommit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(112, 36);
            this.btnCommit.Text = "SVN Commit";
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // btnServerCheckout
            // 
            this.btnServerCheckout.Image = global::Sistemas.Properties.Resources.checkout;
            this.btnServerCheckout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnServerCheckout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnServerCheckout.Name = "btnServerCheckout";
            this.btnServerCheckout.Size = new System.Drawing.Size(129, 36);
            this.btnServerCheckout.Text = "Server Checkout";
            this.btnServerCheckout.Click += new System.EventHandler(this.btnServerCheckout_Click);
            // 
            // txtNetVersion
            // 
            this.txtNetVersion.Add = false;
            this.txtNetVersion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtNetVersion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtNetVersion.Caption = "Net Version";
            this.txtNetVersion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtNetVersion.DBField = null;
            this.txtNetVersion.DBFieldType = null;
            this.txtNetVersion.DefaultValue = null;
            this.txtNetVersion.Del = false;
            this.txtNetVersion.DependingRS = null;
            this.txtNetVersion.ExtraDataLink = null;
            this.txtNetVersion.ForeColor = System.Drawing.Color.Gray;
            this.txtNetVersion.IsCTLMOwned = false;
            this.txtNetVersion.Location = new System.Drawing.Point(568, 107);
            this.txtNetVersion.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtNetVersion.Multiline = false;
            this.txtNetVersion.Name = "txtNetVersion";
            this.txtNetVersion.Order = 0;
            this.txtNetVersion.ParentConn = null;
            this.txtNetVersion.ParentDA = null;
            
            this.txtNetVersion.PK = false;
            this.txtNetVersion.Protected = false;
            this.txtNetVersion.ReadOnly = true;
            this.txtNetVersion.Search = false;
            this.txtNetVersion.Size = new System.Drawing.Size(175, 38);
            this.txtNetVersion.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtNetVersion.TabIndex = 45;
            this.txtNetVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNetVersion.Upp = false;
            
            this.txtNetVersion.Value = "";
            // 
            // txtVersion
            // 
            this.txtVersion.Add = false;
            this.txtVersion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtVersion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtVersion.Caption = "Version";
            this.txtVersion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtVersion.DBField = null;
            this.txtVersion.DBFieldType = null;
            this.txtVersion.DefaultValue = null;
            this.txtVersion.Del = false;
            this.txtVersion.DependingRS = null;
            this.txtVersion.ExtraDataLink = null;
            this.txtVersion.ForeColor = System.Drawing.Color.Gray;
            this.txtVersion.IsCTLMOwned = false;
            this.txtVersion.Location = new System.Drawing.Point(568, 63);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtVersion.Multiline = false;
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Order = 0;
            this.txtVersion.ParentConn = null;
            this.txtVersion.ParentDA = null;
            
            this.txtVersion.PK = false;
            this.txtVersion.Protected = false;
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Search = false;
            this.txtVersion.Size = new System.Drawing.Size(175, 38);
            this.txtVersion.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtVersion.TabIndex = 30;
            this.txtVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVersion.Upp = false;
            
            this.txtVersion.Value = "";
            // 
            // lstUserPositions
            // 
            this.lstUserPositions.Add = false;
            this.lstUserPositions.Caption = "User Positions";
            this.lstUserPositions.CheckOnClick = true;
            this.lstUserPositions.ColumnWidth = 200;
            this.lstUserPositions.DataSource = null;
            this.lstUserPositions.DBField = null;
            this.lstUserPositions.DBFieldType = null;
            this.lstUserPositions.DefaultValue = null;
            this.lstUserPositions.Del = false;
            this.lstUserPositions.DependingRS = null;
            this.lstUserPositions.DisplayMember = "";
            this.lstUserPositions.ExtraDataLink = null;
            this.lstUserPositions.ForeColor = System.Drawing.Color.Black;
            this.lstUserPositions.FormattingEnabled = true;
            this.lstUserPositions.IsCTLMOwned = false;
            this.lstUserPositions.Location = new System.Drawing.Point(568, 156);
            this.lstUserPositions.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstUserPositions.MultiColumn = true;
            this.lstUserPositions.Name = "lstUserPositions";
            this.lstUserPositions.Order = 0;
            this.lstUserPositions.ParentConn = null;
            this.lstUserPositions.ParentDA = null;
            this.lstUserPositions.PK = false;
            this.lstUserPositions.Protected = false;
            this.lstUserPositions.ReadOnly = false;
            this.lstUserPositions.Search = false;
            this.lstUserPositions.SelectedItem = null;
            this.lstUserPositions.SelectedValue = null;
            this.lstUserPositions.Size = new System.Drawing.Size(540, 88);
            this.lstUserPositions.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstUserPositions.TabIndex = 20;
            this.lstUserPositions.TBDescription = null;
            this.lstUserPositions.Upp = false;
            this.lstUserPositions.Value = "";
            this.lstUserPositions.ValueMember = "";
            // 
            // lstAreas
            // 
            this.lstAreas.Add = false;
            this.lstAreas.Caption = "Areas";
            this.lstAreas.CheckOnClick = true;
            this.lstAreas.ColumnWidth = 200;
            this.lstAreas.DataSource = null;
            this.lstAreas.DBField = null;
            this.lstAreas.DBFieldType = null;
            this.lstAreas.DefaultValue = null;
            this.lstAreas.Del = false;
            this.lstAreas.DependingRS = null;
            this.lstAreas.DisplayMember = "";
            this.lstAreas.ExtraDataLink = null;
            this.lstAreas.ForeColor = System.Drawing.Color.Black;
            this.lstAreas.FormattingEnabled = true;
            this.lstAreas.IsCTLMOwned = false;
            this.lstAreas.Location = new System.Drawing.Point(13, 371);
            this.lstAreas.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstAreas.MultiColumn = true;
            this.lstAreas.Name = "lstAreas";
            this.lstAreas.Order = 0;
            this.lstAreas.ParentConn = null;
            this.lstAreas.ParentDA = null;
            this.lstAreas.PK = false;
            this.lstAreas.Protected = false;
            this.lstAreas.ReadOnly = false;
            this.lstAreas.Search = false;
            this.lstAreas.SelectedItem = null;
            this.lstAreas.SelectedValue = null;
            this.lstAreas.Size = new System.Drawing.Size(540, 106);
            this.lstAreas.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstAreas.TabIndex = 18;
            this.lstAreas.TBDescription = null;
            this.lstAreas.Upp = false;
            this.lstAreas.Value = "";
            this.lstAreas.ValueMember = "";
            // 
            // lstRequiredUserFlags
            // 
            this.lstRequiredUserFlags.Add = false;
            this.lstRequiredUserFlags.Caption = "Required User Flags";
            this.lstRequiredUserFlags.CheckOnClick = true;
            this.lstRequiredUserFlags.ColumnWidth = 200;
            this.lstRequiredUserFlags.DataSource = null;
            this.lstRequiredUserFlags.DBField = null;
            this.lstRequiredUserFlags.DBFieldType = null;
            this.lstRequiredUserFlags.DefaultValue = null;
            this.lstRequiredUserFlags.Del = false;
            this.lstRequiredUserFlags.DependingRS = null;
            this.lstRequiredUserFlags.DisplayMember = "";
            this.lstRequiredUserFlags.ExtraDataLink = null;
            this.lstRequiredUserFlags.ForeColor = System.Drawing.Color.Black;
            this.lstRequiredUserFlags.FormattingEnabled = true;
            this.lstRequiredUserFlags.IsCTLMOwned = false;
            this.lstRequiredUserFlags.Location = new System.Drawing.Point(569, 263);
            this.lstRequiredUserFlags.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstRequiredUserFlags.MultiColumn = true;
            this.lstRequiredUserFlags.Name = "lstRequiredUserFlags";
            this.lstRequiredUserFlags.Order = 0;
            this.lstRequiredUserFlags.ParentConn = null;
            this.lstRequiredUserFlags.ParentDA = null;
            this.lstRequiredUserFlags.PK = false;
            this.lstRequiredUserFlags.Protected = false;
            this.lstRequiredUserFlags.ReadOnly = false;
            this.lstRequiredUserFlags.Search = false;
            this.lstRequiredUserFlags.SelectedItem = null;
            this.lstRequiredUserFlags.SelectedValue = null;
            this.lstRequiredUserFlags.Size = new System.Drawing.Size(540, 214);
            this.lstRequiredUserFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstRequiredUserFlags.TabIndex = 14;
            this.lstRequiredUserFlags.TBDescription = null;
            this.lstRequiredUserFlags.Upp = false;
            this.lstRequiredUserFlags.Value = "";
            this.lstRequiredUserFlags.ValueMember = "";
            // 
            // lstFlags
            // 
            this.lstFlags.Add = false;
            this.lstFlags.Caption = "Flags";
            this.lstFlags.CheckOnClick = true;
            this.lstFlags.ColumnWidth = 200;
            this.lstFlags.DataSource = null;
            this.lstFlags.DBField = null;
            this.lstFlags.DBFieldType = null;
            this.lstFlags.DefaultValue = null;
            this.lstFlags.Del = false;
            this.lstFlags.DependingRS = null;
            this.lstFlags.DisplayMember = "";
            this.lstFlags.ExtraDataLink = null;
            this.lstFlags.ForeColor = System.Drawing.Color.Black;
            this.lstFlags.FormattingEnabled = true;
            this.lstFlags.IsCTLMOwned = false;
            this.lstFlags.Location = new System.Drawing.Point(13, 497);
            this.lstFlags.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstFlags.MultiColumn = true;
            this.lstFlags.Name = "lstFlags";
            this.lstFlags.Order = 0;
            this.lstFlags.ParentConn = null;
            this.lstFlags.ParentDA = null;
            this.lstFlags.PK = false;
            this.lstFlags.Protected = false;
            this.lstFlags.ReadOnly = false;
            this.lstFlags.Search = false;
            this.lstFlags.SelectedItem = null;
            this.lstFlags.SelectedValue = null;
            this.lstFlags.Size = new System.Drawing.Size(1096, 142);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 11;
            this.lstFlags.TBDescription = null;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            this.lstFlags.ValueMember = "";
            // 
            // lstLocations
            // 
            this.lstLocations.Add = false;
            this.lstLocations.Caption = "Locations";
            this.lstLocations.CheckOnClick = true;
            this.lstLocations.ColumnWidth = 200;
            this.lstLocations.DataSource = null;
            this.lstLocations.DBField = null;
            this.lstLocations.DBFieldType = null;
            this.lstLocations.DefaultValue = null;
            this.lstLocations.Del = false;
            this.lstLocations.DependingRS = null;
            this.lstLocations.DisplayMember = "";
            this.lstLocations.ExtraDataLink = null;
            this.lstLocations.ForeColor = System.Drawing.Color.Black;
            this.lstLocations.FormattingEnabled = true;
            this.lstLocations.IsCTLMOwned = false;
            this.lstLocations.Location = new System.Drawing.Point(13, 156);
            this.lstLocations.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstLocations.MultiColumn = true;
            this.lstLocations.Name = "lstLocations";
            this.lstLocations.Order = 0;
            this.lstLocations.ParentConn = null;
            this.lstLocations.ParentDA = null;
            this.lstLocations.PK = false;
            this.lstLocations.Protected = false;
            this.lstLocations.ReadOnly = false;
            this.lstLocations.Search = false;
            this.lstLocations.SelectedItem = null;
            this.lstLocations.SelectedValue = null;
            this.lstLocations.Size = new System.Drawing.Size(539, 196);
            this.lstLocations.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstLocations.TabIndex = 9;
            this.lstLocations.TBDescription = null;
            this.lstLocations.Upp = false;
            this.lstLocations.Value = "";
            this.lstLocations.ValueMember = "";
            // 
            // txtApp
            // 
            this.txtApp.Add = false;
            this.txtApp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtApp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtApp.Caption = "App";
            this.txtApp.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtApp.DBField = null;
            this.txtApp.DBFieldType = null;
            this.txtApp.DefaultValue = null;
            this.txtApp.Del = false;
            this.txtApp.DependingRS = null;
            this.txtApp.ExtraDataLink = null;
            this.txtApp.ForeColor = System.Drawing.Color.Gray;
            this.txtApp.IsCTLMOwned = false;
            this.txtApp.Location = new System.Drawing.Point(149, 107);
            this.txtApp.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtApp.Multiline = false;
            this.txtApp.Name = "txtApp";
            this.txtApp.Order = 0;
            this.txtApp.ParentConn = null;
            this.txtApp.ParentDA = null;
            
            this.txtApp.PK = false;
            this.txtApp.Protected = false;
            this.txtApp.ReadOnly = true;
            this.txtApp.Search = false;
            this.txtApp.Size = new System.Drawing.Size(403, 38);
            this.txtApp.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtApp.TabIndex = 7;
            this.txtApp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtApp.Upp = false;
            
            this.txtApp.Value = "";
            // 
            // cboDatabase
            // 
            this.cboDatabase.Add = false;
            this.cboDatabase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboDatabase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboDatabase.Caption = "Database";
            this.cboDatabase.DataSource = null;
            this.cboDatabase.DBField = null;
            this.cboDatabase.DBFieldType = null;
            this.cboDatabase.DefaultValue = null;
            this.cboDatabase.Del = false;
            this.cboDatabase.DependingRS = null;
            this.cboDatabase.DisplayMember = "";
            this.cboDatabase.ExtraDataLink = null;
            this.cboDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDatabase.Font = new System.Drawing.Font("Tahoma", 10F);
            this.cboDatabase.ForeColor = System.Drawing.Color.Black;
            this.cboDatabase.FormattingEnabled = true;
            this.cboDatabase.IsCTLMOwned = false;
            this.cboDatabase.Location = new System.Drawing.Point(12, 107);
            this.cboDatabase.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.cboDatabase.Name = "cboDatabase";
            this.cboDatabase.Order = 0;
            this.cboDatabase.ParentConn = null;
            this.cboDatabase.ParentDA = null;
            this.cboDatabase.PK = false;
            this.cboDatabase.Protected = false;
            this.cboDatabase.ReadOnly = false;
            this.cboDatabase.Search = false;
            this.cboDatabase.SelectedItem = null;
            this.cboDatabase.SelectedValue = null;
            this.cboDatabase.Size = new System.Drawing.Size(130, 40);
            this.cboDatabase.Status = CommonTools.EnumStatus.ADDNEW;
            this.cboDatabase.TabIndex = 5;
            this.cboDatabase.TBDescription = null;
            this.cboDatabase.Upp = false;
            this.cboDatabase.Value = "";
            this.cboDatabase.ValueMember = "";
            // 
            // txtDescription
            // 
            this.txtDescription.Add = false;
            this.txtDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDescription.Caption = "Description";
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDescription.DBField = null;
            this.txtDescription.DBFieldType = null;
            this.txtDescription.DefaultValue = null;
            this.txtDescription.Del = false;
            this.txtDescription.DependingRS = null;
            this.txtDescription.ExtraDataLink = null;
            this.txtDescription.ForeColor = System.Drawing.Color.Gray;
            this.txtDescription.IsCTLMOwned = false;
            this.txtDescription.Location = new System.Drawing.Point(149, 63);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDescription.Multiline = false;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Order = 0;
            this.txtDescription.ParentConn = null;
            this.txtDescription.ParentDA = null;
            
            this.txtDescription.PK = false;
            this.txtDescription.Protected = false;
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Search = false;
            this.txtDescription.Size = new System.Drawing.Size(403, 38);
            this.txtDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDescription.TabIndex = 3;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.Upp = false;
            
            this.txtDescription.Value = "";
            // 
            // txtSystemCode
            // 
            this.txtSystemCode.Add = false;
            this.txtSystemCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtSystemCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtSystemCode.Caption = "System Code";
            this.txtSystemCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSystemCode.DBField = null;
            this.txtSystemCode.DBFieldType = null;
            this.txtSystemCode.DefaultValue = null;
            this.txtSystemCode.Del = false;
            this.txtSystemCode.DependingRS = null;
            this.txtSystemCode.ExtraDataLink = null;
            this.txtSystemCode.ForeColor = System.Drawing.Color.Gray;
            this.txtSystemCode.IsCTLMOwned = false;
            this.txtSystemCode.Location = new System.Drawing.Point(13, 63);
            this.txtSystemCode.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtSystemCode.Multiline = false;
            this.txtSystemCode.Name = "txtSystemCode";
            this.txtSystemCode.Order = 0;
            this.txtSystemCode.ParentConn = null;
            this.txtSystemCode.ParentDA = null;
            
            this.txtSystemCode.PK = false;
            this.txtSystemCode.Protected = false;
            this.txtSystemCode.ReadOnly = true;
            this.txtSystemCode.Search = false;
            this.txtSystemCode.Size = new System.Drawing.Size(130, 38);
            this.txtSystemCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtSystemCode.TabIndex = 1;
            this.txtSystemCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSystemCode.Upp = false;
            
            this.txtSystemCode.Value = "";
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
            this.CTLM.TabIndex = 0;
            // 
            // serversList1
            // 
            this.serversList1.BackColor = System.Drawing.Color.Gainsboro;
            this.serversList1.CallingButton = null;
            this.serversList1.Command = null;
            this.serversList1.ListServers = null;
            this.serversList1.Location = new System.Drawing.Point(1133, 89);
            this.serversList1.Name = "serversList1";
            this.serversList1.Password = "";
            this.serversList1.Size = new System.Drawing.Size(315, 550);
            this.serversList1.TabIndex = 193;
            this.serversList1.User = "";
            // 
            // fSystemsMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1480, 707);
            this.Controls.Add(this.serversList1);
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

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackTextBox txtSystemCode;
        private EspackFormControlsNS.EspackTextBox txtDescription;
        private EspackFormControlsNS.EspackComboBox cboDatabase;
        private EspackFormControlsNS.EspackTextBox txtApp;
        private EspackFormControlsNS.EspackCheckedListBox lstLocations;
        private EspackFormControlsNS.EspackCheckedListBox lstFlags;
        private EspackFormControlsNS.EspackCheckedListBox lstRequiredUserFlags;
        private EspackFormControlsNS.EspackCheckedListBox lstAreas;
        private EspackFormControlsNS.EspackCheckedListBox lstUserPositions;
        private EspackFormControlsNS.EspackTextBox txtVersion;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnReloadVersions;
        private EspackFormControlsNS.EspackTextBox txtNetVersion;
        private System.Windows.Forms.ToolStripButton btnXMLFile;
        private System.Windows.Forms.ToolStripButton btnCommit;
        private System.Windows.Forms.ToolStripButton btnServerCheckout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private ServersList serversList1;
    }
}