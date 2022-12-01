
namespace APICallsConsole
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtLastMessageID = new System.Windows.Forms.TextBox();
            this.btnACK = new System.Windows.Forms.Button();
            this.tmrRefreshPending = new System.Windows.Forms.Timer(this.components);
            this.dgvPendingMessages = new System.Windows.Forms.DataGridView();
            this.lblPendingMessages = new System.Windows.Forms.Label();
            this.lblLastProcessedMessages = new System.Windows.Forms.Label();
            this.dgvLastProcessedMessages = new System.Windows.Forms.DataGridView();
            this.lblAutoRefreshCounter = new System.Windows.Forms.Label();
            this.tmrProcessPending = new System.Windows.Forms.Timer(this.components);
            this.dgvErrors = new System.Windows.Forms.DataGridView();
            this.lblErrors = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLastProcessedMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(1245, 893);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(137, 48);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtLastMessageID
            // 
            this.txtLastMessageID.Location = new System.Drawing.Point(959, 906);
            this.txtLastMessageID.Name = "txtLastMessageID";
            this.txtLastMessageID.Size = new System.Drawing.Size(137, 22);
            this.txtLastMessageID.TabIndex = 2;
            // 
            // btnACK
            // 
            this.btnACK.Location = new System.Drawing.Point(1102, 893);
            this.btnACK.Name = "btnACK";
            this.btnACK.Size = new System.Drawing.Size(137, 48);
            this.btnACK.TabIndex = 3;
            this.btnACK.Text = "ACK message";
            this.btnACK.UseVisualStyleBackColor = true;
            this.btnACK.Click += new System.EventHandler(this.btnACK_Click);
            // 
            // tmrRefreshPending
            // 
            this.tmrRefreshPending.Enabled = true;
            this.tmrRefreshPending.Interval = 1000;
            this.tmrRefreshPending.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // dgvPendingMessages
            // 
            this.dgvPendingMessages.AllowUserToAddRows = false;
            this.dgvPendingMessages.AllowUserToDeleteRows = false;
            this.dgvPendingMessages.AllowUserToResizeRows = false;
            this.dgvPendingMessages.ColumnHeadersHeight = 22;
            this.dgvPendingMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvPendingMessages.Location = new System.Drawing.Point(12, 33);
            this.dgvPendingMessages.Name = "dgvPendingMessages";
            this.dgvPendingMessages.ReadOnly = true;
            this.dgvPendingMessages.RowHeadersVisible = false;
            this.dgvPendingMessages.RowHeadersWidth = 51;
            this.dgvPendingMessages.RowTemplate.Height = 24;
            this.dgvPendingMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendingMessages.Size = new System.Drawing.Size(1370, 306);
            this.dgvPendingMessages.TabIndex = 5;
            // 
            // lblPendingMessages
            // 
            this.lblPendingMessages.AutoSize = true;
            this.lblPendingMessages.Location = new System.Drawing.Point(9, 13);
            this.lblPendingMessages.Name = "lblPendingMessages";
            this.lblPendingMessages.Size = new System.Drawing.Size(128, 17);
            this.lblPendingMessages.TabIndex = 6;
            this.lblPendingMessages.Text = "Pending Messages";
            // 
            // lblLastProcessedMessages
            // 
            this.lblLastProcessedMessages.AutoSize = true;
            this.lblLastProcessedMessages.Location = new System.Drawing.Point(9, 342);
            this.lblLastProcessedMessages.Name = "lblLastProcessedMessages";
            this.lblLastProcessedMessages.Size = new System.Drawing.Size(174, 17);
            this.lblLastProcessedMessages.TabIndex = 8;
            this.lblLastProcessedMessages.Text = "Last Processed Messages";
            // 
            // dgvLastProcessedMessages
            // 
            this.dgvLastProcessedMessages.AllowUserToAddRows = false;
            this.dgvLastProcessedMessages.AllowUserToDeleteRows = false;
            this.dgvLastProcessedMessages.AllowUserToResizeRows = false;
            this.dgvLastProcessedMessages.ColumnHeadersHeight = 22;
            this.dgvLastProcessedMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLastProcessedMessages.Location = new System.Drawing.Point(12, 362);
            this.dgvLastProcessedMessages.Name = "dgvLastProcessedMessages";
            this.dgvLastProcessedMessages.ReadOnly = true;
            this.dgvLastProcessedMessages.RowHeadersVisible = false;
            this.dgvLastProcessedMessages.RowHeadersWidth = 51;
            this.dgvLastProcessedMessages.RowTemplate.Height = 24;
            this.dgvLastProcessedMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLastProcessedMessages.Size = new System.Drawing.Size(1370, 331);
            this.dgvLastProcessedMessages.TabIndex = 9;
            // 
            // lblAutoRefreshCounter
            // 
            this.lblAutoRefreshCounter.AutoSize = true;
            this.lblAutoRefreshCounter.Location = new System.Drawing.Point(16, 880);
            this.lblAutoRefreshCounter.Name = "lblAutoRefreshCounter";
            this.lblAutoRefreshCounter.Size = new System.Drawing.Size(0, 17);
            this.lblAutoRefreshCounter.TabIndex = 10;
            // 
            // tmrProcessPending
            // 
            this.tmrProcessPending.Interval = 500;
            this.tmrProcessPending.Tick += new System.EventHandler(this.tmrProcessPending_Tick);
            // 
            // dgvErrors
            // 
            this.dgvErrors.AllowUserToAddRows = false;
            this.dgvErrors.AllowUserToDeleteRows = false;
            this.dgvErrors.AllowUserToResizeRows = false;
            this.dgvErrors.ColumnHeadersHeight = 22;
            this.dgvErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Date,
            this.Origin,
            this.Stage,
            this.Message});
            this.dgvErrors.Location = new System.Drawing.Point(12, 716);
            this.dgvErrors.Name = "dgvErrors";
            this.dgvErrors.ReadOnly = true;
            this.dgvErrors.RowHeadersVisible = false;
            this.dgvErrors.RowHeadersWidth = 51;
            this.dgvErrors.RowTemplate.Height = 24;
            this.dgvErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvErrors.Size = new System.Drawing.Size(1370, 164);
            this.dgvErrors.TabIndex = 11;
            // 
            // lblErrors
            // 
            this.lblErrors.AutoSize = true;
            this.lblErrors.Location = new System.Drawing.Point(9, 696);
            this.lblErrors.Name = "lblErrors";
            this.lblErrors.Size = new System.Drawing.Size(47, 17);
            this.lblErrors.TabIndex = 12;
            this.lblErrors.Text = "Errors";
            // 
            // Date
            // 
            this.Date.HeaderText = "Date";
            this.Date.MinimumWidth = 6;
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 125;
            // 
            // Origin
            // 
            this.Origin.HeaderText = "Origin";
            this.Origin.MinimumWidth = 6;
            this.Origin.Name = "Origin";
            this.Origin.ReadOnly = true;
            this.Origin.Width = 250;
            // 
            // Stage
            // 
            this.Stage.HeaderText = "Stage";
            this.Stage.MinimumWidth = 6;
            this.Stage.Name = "Stage";
            this.Stage.ReadOnly = true;
            this.Stage.Width = 250;
            // 
            // Message
            // 
            this.Message.HeaderText = "Message";
            this.Message.MinimumWidth = 6;
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.Width = 768;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 953);
            this.Controls.Add(this.lblErrors);
            this.Controls.Add(this.dgvErrors);
            this.Controls.Add(this.lblAutoRefreshCounter);
            this.Controls.Add(this.dgvLastProcessedMessages);
            this.Controls.Add(this.lblLastProcessedMessages);
            this.Controls.Add(this.lblPendingMessages);
            this.Controls.Add(this.dgvPendingMessages);
            this.Controls.Add(this.btnACK);
            this.Controls.Add(this.txtLastMessageID);
            this.Controls.Add(this.btnConnect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.Text = "JLR API Sequencing";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLastProcessedMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvErrors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtLastMessageID;
        private System.Windows.Forms.Button btnACK;
        private System.Windows.Forms.Timer tmrRefreshPending;
        private System.Windows.Forms.DataGridView dgvPendingMessages;
        private System.Windows.Forms.Label lblPendingMessages;
        private System.Windows.Forms.Label lblLastProcessedMessages;
        private System.Windows.Forms.DataGridView dgvLastProcessedMessages;
        private System.Windows.Forms.Label lblAutoRefreshCounter;
        private System.Windows.Forms.Timer tmrProcessPending;
        private System.Windows.Forms.DataGridView dgvErrors;
        private System.Windows.Forms.Label lblErrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
    }
}