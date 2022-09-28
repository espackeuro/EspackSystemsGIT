
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtLastMessageID = new System.Windows.Forms.TextBox();
            this.btnACK = new System.Windows.Forms.Button();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblPendingMessages = new System.Windows.Forms.Label();
            this.lblLastProcessedMessages = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(1286, 785);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(137, 48);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(648, 351);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(632, 428);
            this.txtLog.TabIndex = 1;
            // 
            // txtLastMessageID
            // 
            this.txtLastMessageID.Location = new System.Drawing.Point(1286, 351);
            this.txtLastMessageID.Name = "txtLastMessageID";
            this.txtLastMessageID.Size = new System.Drawing.Size(137, 22);
            this.txtLastMessageID.TabIndex = 2;
            // 
            // btnACK
            // 
            this.btnACK.Location = new System.Drawing.Point(1286, 379);
            this.btnACK.Name = "btnACK";
            this.btnACK.Size = new System.Drawing.Size(137, 48);
            this.btnACK.TabIndex = 3;
            this.btnACK.Text = "ACK message";
            this.btnACK.UseVisualStyleBackColor = true;
            this.btnACK.Click += new System.EventHandler(this.btnACK_Click);
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Interval = 1000;
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Location = new System.Drawing.Point(648, 803);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(271, 21);
            this.chkAutoRefresh.TabIndex = 4;
            this.chkAutoRefresh.Text = "Perform an autorefresh in XX seconds";
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            this.chkAutoRefresh.CheckedChanged += new System.EventHandler(this.chkAutoRefresh_CheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(451, 150);
            this.dataGridView1.TabIndex = 5;
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
            this.lblLastProcessedMessages.Location = new System.Drawing.Point(12, 186);
            this.lblLastProcessedMessages.Name = "lblLastProcessedMessages";
            this.lblLastProcessedMessages.Size = new System.Drawing.Size(174, 17);
            this.lblLastProcessedMessages.TabIndex = 8;
            this.lblLastProcessedMessages.Text = "Last Processed Messages";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 206);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(451, 150);
            this.dataGridView2.TabIndex = 7;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1435, 843);
            this.Controls.Add(this.lblLastProcessedMessages);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.lblPendingMessages);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chkAutoRefresh);
            this.Controls.Add(this.btnACK);
            this.Controls.Add(this.txtLastMessageID);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnConnect);
            this.Name = "fMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtLastMessageID;
        private System.Windows.Forms.Button btnACK;
        private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.CheckBox chkAutoRefresh;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblPendingMessages;
        private System.Windows.Forms.Label lblLastProcessedMessages;
        private System.Windows.Forms.DataGridView dataGridView2;
    }
}