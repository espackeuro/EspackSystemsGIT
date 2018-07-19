namespace Sistemas
{
    partial class fServices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fServices));
            this.CTLM = new EspackFormControlsNS.CTLMantenimiento();
            this.txtDB = new EspackFormControlsNS.EspackTextBox();
            this.txtLocation = new EspackFormControlsNS.EspackTextBox();
            this.txtApp = new EspackFormControlsNS.EspackTextBox();
            this.txtServer1 = new EspackFormControlsNS.EspackTextBox();
            this.txtServer2 = new EspackFormControlsNS.EspackTextBox();
            this.txtActiveServer = new EspackFormControlsNS.EspackTextBox();
            this.lstFlags = new EspackFormControlsNS.EspackCheckedListBox();
            this.lstCOD3 = new EspackFormControlsNS.EspackCheckedListBox();
            this.txtDescription = new EspackFormControlsNS.EspackTextBox();
            this.txtServiceCode = new EspackFormControlsNS.EspackTextBox();
            this.grpID = new System.Windows.Forms.GroupBox();
            this.txtNetVersion = new EspackFormControlsNS.EspackTextBox();
            this.txtVersion = new EspackFormControlsNS.EspackTextBox();
            this.grpSystem = new System.Windows.Forms.GroupBox();
            this.grpVarious = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnReloadVersions = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.grpID.SuspendLayout();
            this.grpSystem.SuspendLayout();
            this.grpVarious.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
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
            this.CTLM.Location = new System.Drawing.Point(0, 0);
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
            // txtDB
            // 
            this.txtDB.Add = false;
            this.txtDB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDB.Caption = "Database";
            this.txtDB.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDB.DBField = null;
            this.txtDB.DBFieldType = null;
            this.txtDB.DefaultValue = null;
            this.txtDB.Del = false;
            this.txtDB.DependingRS = null;
            this.txtDB.ExtraDataLink = null;
            this.txtDB.ForeColor = System.Drawing.Color.Gray;
            this.txtDB.IsCTLMOwned = false;
            this.txtDB.Location = new System.Drawing.Point(24, 32);
            this.txtDB.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDB.Multiline = true;
            this.txtDB.Name = "txtDB";
            this.txtDB.Order = 0;
            this.txtDB.ParentConn = null;
            this.txtDB.ParentDA = null;
            
            this.txtDB.PK = false;
            this.txtDB.Protected = false;
            this.txtDB.ReadOnly = true;
            this.txtDB.Search = false;
            this.txtDB.Size = new System.Drawing.Size(176, 38);
            this.txtDB.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDB.TabIndex = 13;
            this.txtDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDB.Upp = false;
            
            this.txtDB.Value = "";
            // 
            // txtLocation
            // 
            this.txtLocation.Add = false;
            this.txtLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtLocation.Caption = "Location";
            this.txtLocation.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtLocation.DBField = null;
            this.txtLocation.DBFieldType = null;
            this.txtLocation.DefaultValue = null;
            this.txtLocation.Del = false;
            this.txtLocation.DependingRS = null;
            this.txtLocation.ExtraDataLink = null;
            this.txtLocation.ForeColor = System.Drawing.Color.Gray;
            this.txtLocation.IsCTLMOwned = false;
            this.txtLocation.Location = new System.Drawing.Point(235, 32);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtLocation.Multiline = true;
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Order = 0;
            this.txtLocation.ParentConn = null;
            this.txtLocation.ParentDA = null;
            
            this.txtLocation.PK = false;
            this.txtLocation.Protected = false;
            this.txtLocation.ReadOnly = true;
            this.txtLocation.Search = false;
            this.txtLocation.Size = new System.Drawing.Size(176, 38);
            this.txtLocation.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtLocation.TabIndex = 15;
            this.txtLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtLocation.Upp = false;
            
            this.txtLocation.Value = "";
            // 
            // txtApp
            // 
            this.txtApp.Add = false;
            this.txtApp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtApp.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtApp.Caption = "Application";
            this.txtApp.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtApp.DBField = null;
            this.txtApp.DBFieldType = null;
            this.txtApp.DefaultValue = null;
            this.txtApp.Del = false;
            this.txtApp.DependingRS = null;
            this.txtApp.ExtraDataLink = null;
            this.txtApp.ForeColor = System.Drawing.Color.Gray;
            this.txtApp.IsCTLMOwned = false;
            this.txtApp.Location = new System.Drawing.Point(449, 32);
            this.txtApp.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtApp.Multiline = true;
            this.txtApp.Name = "txtApp";
            this.txtApp.Order = 0;
            this.txtApp.ParentConn = null;
            this.txtApp.ParentDA = null;
            
            this.txtApp.PK = false;
            this.txtApp.Protected = false;
            this.txtApp.ReadOnly = true;
            this.txtApp.Search = false;
            this.txtApp.Size = new System.Drawing.Size(176, 38);
            this.txtApp.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtApp.TabIndex = 17;
            this.txtApp.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtApp.Upp = false;
            
            this.txtApp.Value = "";
            // 
            // txtServer1
            // 
            this.txtServer1.Add = false;
            this.txtServer1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtServer1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtServer1.Caption = "Server1";
            this.txtServer1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtServer1.DBField = null;
            this.txtServer1.DBFieldType = null;
            this.txtServer1.DefaultValue = null;
            this.txtServer1.Del = false;
            this.txtServer1.DependingRS = null;
            this.txtServer1.ExtraDataLink = null;
            this.txtServer1.ForeColor = System.Drawing.Color.Gray;
            this.txtServer1.IsCTLMOwned = false;
            this.txtServer1.Location = new System.Drawing.Point(24, 75);
            this.txtServer1.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtServer1.Multiline = true;
            this.txtServer1.Name = "txtServer1";
            this.txtServer1.Order = 0;
            this.txtServer1.ParentConn = null;
            this.txtServer1.ParentDA = null;
            
            this.txtServer1.PK = false;
            this.txtServer1.Protected = false;
            this.txtServer1.ReadOnly = true;
            this.txtServer1.Search = false;
            this.txtServer1.Size = new System.Drawing.Size(176, 38);
            this.txtServer1.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtServer1.TabIndex = 21;
            this.txtServer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtServer1.Upp = false;
            
            this.txtServer1.Value = "";
            // 
            // txtServer2
            // 
            this.txtServer2.Add = false;
            this.txtServer2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtServer2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtServer2.Caption = "Server2";
            this.txtServer2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtServer2.DBField = null;
            this.txtServer2.DBFieldType = null;
            this.txtServer2.DefaultValue = null;
            this.txtServer2.Del = false;
            this.txtServer2.DependingRS = null;
            this.txtServer2.ExtraDataLink = null;
            this.txtServer2.ForeColor = System.Drawing.Color.Gray;
            this.txtServer2.IsCTLMOwned = false;
            this.txtServer2.Location = new System.Drawing.Point(235, 75);
            this.txtServer2.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtServer2.Multiline = true;
            this.txtServer2.Name = "txtServer2";
            this.txtServer2.Order = 0;
            this.txtServer2.ParentConn = null;
            this.txtServer2.ParentDA = null;
            
            this.txtServer2.PK = false;
            this.txtServer2.Protected = false;
            this.txtServer2.ReadOnly = true;
            this.txtServer2.Search = false;
            this.txtServer2.Size = new System.Drawing.Size(176, 38);
            this.txtServer2.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtServer2.TabIndex = 23;
            this.txtServer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtServer2.Upp = false;
            
            this.txtServer2.Value = "";
            // 
            // txtActiveServer
            // 
            this.txtActiveServer.Add = false;
            this.txtActiveServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtActiveServer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtActiveServer.Caption = "Active Server";
            this.txtActiveServer.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtActiveServer.DBField = null;
            this.txtActiveServer.DBFieldType = null;
            this.txtActiveServer.DefaultValue = null;
            this.txtActiveServer.Del = false;
            this.txtActiveServer.DependingRS = null;
            this.txtActiveServer.ExtraDataLink = null;
            this.txtActiveServer.ForeColor = System.Drawing.Color.Gray;
            this.txtActiveServer.IsCTLMOwned = false;
            this.txtActiveServer.Location = new System.Drawing.Point(449, 75);
            this.txtActiveServer.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtActiveServer.Multiline = true;
            this.txtActiveServer.Name = "txtActiveServer";
            this.txtActiveServer.Order = 0;
            this.txtActiveServer.ParentConn = null;
            this.txtActiveServer.ParentDA = null;
            
            this.txtActiveServer.PK = false;
            this.txtActiveServer.Protected = false;
            this.txtActiveServer.ReadOnly = true;
            this.txtActiveServer.Search = false;
            this.txtActiveServer.Size = new System.Drawing.Size(176, 38);
            this.txtActiveServer.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtActiveServer.TabIndex = 25;
            this.txtActiveServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtActiveServer.Upp = false;
            
            this.txtActiveServer.Value = "";
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
            this.lstFlags.Location = new System.Drawing.Point(24, 32);
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
            this.lstFlags.Size = new System.Drawing.Size(600, 73);
            this.lstFlags.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstFlags.TabIndex = 27;
            this.lstFlags.TBDescription = null;
            this.lstFlags.Upp = false;
            this.lstFlags.Value = "";
            this.lstFlags.ValueMember = "";
            // 
            // lstCOD3
            // 
            this.lstCOD3.Add = false;
            this.lstCOD3.Caption = "COD3";
            this.lstCOD3.CheckOnClick = true;
            this.lstCOD3.ColumnWidth = 300;
            this.lstCOD3.DataSource = null;
            this.lstCOD3.DBField = null;
            this.lstCOD3.DBFieldType = null;
            this.lstCOD3.DefaultValue = null;
            this.lstCOD3.Del = false;
            this.lstCOD3.DependingRS = null;
            this.lstCOD3.DisplayMember = "";
            this.lstCOD3.ExtraDataLink = null;
            this.lstCOD3.ForeColor = System.Drawing.Color.Black;
            this.lstCOD3.FormattingEnabled = true;
            this.lstCOD3.IsCTLMOwned = false;
            this.lstCOD3.Location = new System.Drawing.Point(24, 127);
            this.lstCOD3.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.lstCOD3.MultiColumn = true;
            this.lstCOD3.Name = "lstCOD3";
            this.lstCOD3.Order = 0;
            this.lstCOD3.ParentConn = null;
            this.lstCOD3.ParentDA = null;
            this.lstCOD3.PK = false;
            this.lstCOD3.Protected = false;
            this.lstCOD3.ReadOnly = false;
            this.lstCOD3.Search = false;
            this.lstCOD3.SelectedItem = null;
            this.lstCOD3.SelectedValue = null;
            this.lstCOD3.Size = new System.Drawing.Size(600, 111);
            this.lstCOD3.Status = CommonTools.EnumStatus.ADDNEW;
            this.lstCOD3.TabIndex = 29;
            this.lstCOD3.TBDescription = null;
            this.lstCOD3.Upp = false;
            this.lstCOD3.Value = "";
            this.lstCOD3.ValueMember = "";
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
            this.txtDescription.Location = new System.Drawing.Point(24, 62);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Order = 0;
            this.txtDescription.ParentConn = null;
            this.txtDescription.ParentDA = null;
            
            this.txtDescription.PK = false;
            this.txtDescription.Protected = false;
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Search = false;
            this.txtDescription.Size = new System.Drawing.Size(600, 38);
            this.txtDescription.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtDescription.TabIndex = 11;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.Upp = false;
            
            this.txtDescription.Value = "";
            // 
            // txtServiceCode
            // 
            this.txtServiceCode.Add = false;
            this.txtServiceCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtServiceCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtServiceCode.Caption = "Service Code";
            this.txtServiceCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtServiceCode.DBField = null;
            this.txtServiceCode.DBFieldType = null;
            this.txtServiceCode.DefaultValue = null;
            this.txtServiceCode.Del = false;
            this.txtServiceCode.DependingRS = null;
            this.txtServiceCode.ExtraDataLink = null;
            this.txtServiceCode.ForeColor = System.Drawing.Color.Gray;
            this.txtServiceCode.IsCTLMOwned = false;
            this.txtServiceCode.Location = new System.Drawing.Point(24, 23);
            this.txtServiceCode.Margin = new System.Windows.Forms.Padding(3, 16, 3, 3);
            this.txtServiceCode.Multiline = true;
            this.txtServiceCode.Name = "txtServiceCode";
            this.txtServiceCode.Order = 0;
            this.txtServiceCode.ParentConn = null;
            this.txtServiceCode.ParentDA = null;
            
            this.txtServiceCode.PK = false;
            this.txtServiceCode.Protected = false;
            this.txtServiceCode.ReadOnly = true;
            this.txtServiceCode.Search = false;
            this.txtServiceCode.Size = new System.Drawing.Size(176, 38);
            this.txtServiceCode.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtServiceCode.TabIndex = 7;
            this.txtServiceCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtServiceCode.Upp = false;
            
            this.txtServiceCode.Value = "";
            // 
            // grpID
            // 
            this.grpID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpID.Controls.Add(this.txtNetVersion);
            this.grpID.Controls.Add(this.txtVersion);
            this.grpID.Controls.Add(this.txtServiceCode);
            this.grpID.Controls.Add(this.txtDescription);
            this.grpID.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.grpID.Location = new System.Drawing.Point(13, 47);
            this.grpID.Name = "grpID";
            this.grpID.Size = new System.Drawing.Size(634, 100);
            this.grpID.TabIndex = 38;
            this.grpID.TabStop = false;
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
            this.txtNetVersion.Location = new System.Drawing.Point(449, 23);
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
            this.txtNetVersion.Size = new System.Drawing.Size(176, 38);
            this.txtNetVersion.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtNetVersion.TabIndex = 18;
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
            this.txtVersion.Location = new System.Drawing.Point(235, 23);
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
            this.txtVersion.Size = new System.Drawing.Size(176, 38);
            this.txtVersion.Status = CommonTools.EnumStatus.ADDNEW;
            this.txtVersion.TabIndex = 13;
            this.txtVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtVersion.Upp = false;
            
            this.txtVersion.Value = "";
            // 
            // grpSystem
            // 
            this.grpSystem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpSystem.Controls.Add(this.txtLocation);
            this.grpSystem.Controls.Add(this.txtDB);
            this.grpSystem.Controls.Add(this.txtActiveServer);
            this.grpSystem.Controls.Add(this.txtApp);
            this.grpSystem.Controls.Add(this.txtServer2);
            this.grpSystem.Controls.Add(this.txtServer1);
            this.grpSystem.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.grpSystem.Location = new System.Drawing.Point(13, 153);
            this.grpSystem.Name = "grpSystem";
            this.grpSystem.Size = new System.Drawing.Size(634, 125);
            this.grpSystem.TabIndex = 39;
            this.grpSystem.TabStop = false;
            this.grpSystem.Text = "System";
            // 
            // grpVarious
            // 
            this.grpVarious.BackColor = System.Drawing.SystemColors.ControlLight;
            this.grpVarious.Controls.Add(this.lstFlags);
            this.grpVarious.Controls.Add(this.lstCOD3);
            this.grpVarious.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.grpVarious.Location = new System.Drawing.Point(13, 284);
            this.grpVarious.Name = "grpVarious";
            this.grpVarious.Size = new System.Drawing.Size(634, 256);
            this.grpVarious.TabIndex = 40;
            this.grpVarious.TabStop = false;
            this.grpVarious.Text = "Various";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(498, 9);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1, 0);
            this.toolStrip1.TabIndex = 41;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(117, 28);
            this.toolStripButton1.Text = "Reload Versions";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReloadVersions});
            this.toolStrip2.Location = new System.Drawing.Point(462, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(129, 31);
            this.toolStrip2.TabIndex = 42;
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
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // fServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 611);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.grpID);
            this.Controls.Add(this.CTLM);
            this.Controls.Add(this.grpSystem);
            this.Controls.Add(this.grpVarious);
            this.KeyPreview = true;
            this.Name = "fServices";
            this.ShowIcon = false;
            this.Text = "Services";
            this.grpID.ResumeLayout(false);
            this.grpSystem.ResumeLayout(false);
            this.grpVarious.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EspackFormControlsNS.CTLMantenimiento CTLM;
        private EspackFormControlsNS.EspackTextBox txtDB;
        private EspackFormControlsNS.EspackTextBox txtLocation;
        private EspackFormControlsNS.EspackTextBox txtApp;
        private EspackFormControlsNS.EspackTextBox txtServer1;
        private EspackFormControlsNS.EspackTextBox txtServer2;
        private EspackFormControlsNS.EspackTextBox txtActiveServer;
        private EspackFormControlsNS.EspackCheckedListBox lstFlags;
        private EspackFormControlsNS.EspackCheckedListBox lstCOD3;
        private EspackFormControlsNS.EspackTextBox txtDescription;
        private EspackFormControlsNS.EspackTextBox txtServiceCode;
        private System.Windows.Forms.GroupBox grpID;
        private System.Windows.Forms.GroupBox grpSystem;
        private System.Windows.Forms.GroupBox grpVarious;
        private EspackFormControlsNS.EspackTextBox txtVersion;
        private EspackFormControlsNS.EspackTextBox txtNetVersion;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton btnReloadVersions;
    }
}