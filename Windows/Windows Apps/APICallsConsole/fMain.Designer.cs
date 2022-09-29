
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtLastMessageID = new System.Windows.Forms.TextBox();
            this.btnACK = new System.Windows.Forms.Button();
            this.tmrRefreshPending = new System.Windows.Forms.Timer(this.components);
            this.dgvPendingMessages = new System.Windows.Forms.DataGridView();
            this.lblPendingMessages = new System.Windows.Forms.Label();
            this.lblLastProcessedMessages = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblAutoRefreshCounter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingMessages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(1820, 863);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(137, 48);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtLastMessageID
            // 
            this.txtLastMessageID.Location = new System.Drawing.Point(1534, 876);
            this.txtLastMessageID.Name = "txtLastMessageID";
            this.txtLastMessageID.Size = new System.Drawing.Size(137, 22);
            this.txtLastMessageID.TabIndex = 2;
            // 
            // btnACK
            // 
            this.btnACK.Location = new System.Drawing.Point(1677, 863);
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
            this.dgvPendingMessages.Size = new System.Drawing.Size(1945, 395);
            this.dgvPendingMessages.TabIndex = 5;
            // 
            // lblPendingMessages
            // 
            this.lblPendingMessages.AutoSize = true;
            this.lblPendingMessages.Location = new System.Drawing.Point(13, 13);
            this.lblPendingMessages.Name = "lblPendingMessages";
            this.lblPendingMessages.Size = new System.Drawing.Size(128, 17);
            this.lblPendingMessages.TabIndex = 6;
            this.lblPendingMessages.Text = "Pending Messages";
            // 
            // lblLastProcessedMessages
            // 
            this.lblLastProcessedMessages.AutoSize = true;
            this.lblLastProcessedMessages.Location = new System.Drawing.Point(9, 431);
            this.lblLastProcessedMessages.Name = "lblLastProcessedMessages";
            this.lblLastProcessedMessages.Size = new System.Drawing.Size(174, 17);
            this.lblLastProcessedMessages.TabIndex = 8;
            this.lblLastProcessedMessages.Text = "Last Processed Messages";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeight = 22;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Location = new System.Drawing.Point(12, 452);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1945, 395);
            this.dataGridView1.TabIndex = 9;
            // 
            // lblAutoRefreshCounter
            // 
            this.lblAutoRefreshCounter.AutoSize = true;
            this.lblAutoRefreshCounter.Location = new System.Drawing.Point(16, 880);
            this.lblAutoRefreshCounter.Name = "lblAutoRefreshCounter";
            this.lblAutoRefreshCounter.Size = new System.Drawing.Size(0, 17);
            this.lblAutoRefreshCounter.TabIndex = 10;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1973, 921);
            this.Controls.Add(this.lblAutoRefreshCounter);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblLastProcessedMessages);
            this.Controls.Add(this.lblPendingMessages);
            this.Controls.Add(this.dgvPendingMessages);
            this.Controls.Add(this.btnACK);
            this.Controls.Add(this.txtLastMessageID);
            this.Controls.Add(this.btnConnect);
            this.Name = "fMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendingMessages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblAutoRefreshCounter;
    }
}