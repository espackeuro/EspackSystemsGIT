using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonTools;
using Ghostscript.NET;
using Ghostscript.NET.Viewer;

namespace EspackFileStream
{
    public partial class EspackFileDataContainerPreview : EspackFileDataContainer
    {

        public override bool ReadOnly { get; set; }
        private GhostscriptViewer _viewer;
        //private GhostscriptVersionInfo _gsVersion = GhostscriptVersionInfo.GetLastInstalledVersion();
        private GhostscriptVersionInfo _gsVersion = new GhostscriptVersionInfo(string.Format(@"D:\Users\Rafa\Downloads\Ghostscript.NET-master\Ghostscript.NET.Viewer\bin\Debug\{0}", Environment.Is64BitProcess ? "gsdll64.dll" : "gsdll32.dll"));
        private StringBuilder _stdOut = new StringBuilder();
        private StringBuilder _stdErr = new StringBuilder();
        private Panel panelTop;
        private ToolStrip toolStrip1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripButton tbPageFirst;
        private ToolStripButton tbPagePrevious;
        private ToolStripTextBox tbPageNumber;
        private ToolStripLabel tbTotalPages;
        private ToolStripButton tbPageNext;
        private ToolStripButton tbPageLast;
        private ToolStripLabel toolStripLabel3;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel2;
        private ToolStripButton tpZoomOut;
        private ToolStripButton tpZoomIn;
        private ToolStripLabel toolStripLabel4;
        private ToolStripSeparator toolStripSeparator2;
        private Panel panelContent;
        private PictureBox pbPage;
        private bool _supressPageNumberChangeEvent = false;
        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbPageFirst = new System.Windows.Forms.ToolStripButton();
            this.tbPagePrevious = new System.Windows.Forms.ToolStripButton();
            this.tbPageNumber = new System.Windows.Forms.ToolStripTextBox();
            this.tbTotalPages = new System.Windows.Forms.ToolStripLabel();
            this.tbPageNext = new System.Windows.Forms.ToolStripButton();
            this.tbPageLast = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tpZoomOut = new System.Windows.Forms.ToolStripButton();
            this.tpZoomIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pbPage = new System.Windows.Forms.PictureBox();
            this.panelTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPage)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.toolStrip1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(919, 32);
            this.panelTop.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tbPageFirst,
            this.tbPagePrevious,
            this.tbPageNumber,
            this.tbTotalPages,
            this.tbPageNext,
            this.tbPageLast,
            this.toolStripLabel3,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.tpZoomOut,
            this.tpZoomIn,
            this.toolStripLabel4,
            this.toolStripSeparator2});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(919, 31);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(51, 28);
            this.toolStripLabel1.Text = "    Page: ";
            // 
            // tbPageFirst
            // 
            this.tbPageFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPageFirst.Image = global::EspackFileStreamControl.Properties.Resources.tb_first;
            this.tbPageFirst.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbPageFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPageFirst.Name = "tbPageFirst";
            this.tbPageFirst.Size = new System.Drawing.Size(28, 28);
            this.tbPageFirst.Text = "toolStripButton1";
            this.tbPageFirst.ToolTipText = "First Page";
            this.tbPageFirst.Click += new System.EventHandler(this.tbPageFirst_Click);
            // 
            // tbPagePrevious
            // 
            this.tbPagePrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPagePrevious.Image = global::EspackFileStreamControl.Properties.Resources.tb_previous;
            this.tbPagePrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbPagePrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPagePrevious.Name = "tbPagePrevious";
            this.tbPagePrevious.Size = new System.Drawing.Size(28, 28);
            this.tbPagePrevious.Text = "toolStripButton2";
            this.tbPagePrevious.ToolTipText = "Previous Page";
            this.tbPagePrevious.Click += new System.EventHandler(this.tbPagePrevious_Click);
            // 
            // tbPageNumber
            // 
            this.tbPageNumber.Name = "tbPageNumber";
            this.tbPageNumber.Size = new System.Drawing.Size(40, 31);
            // 
            // tbTotalPages
            // 
            this.tbTotalPages.Name = "tbTotalPages";
            this.tbTotalPages.Size = new System.Drawing.Size(0, 28);
            // 
            // tbPageNext
            // 
            this.tbPageNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPageNext.Image = global::EspackFileStreamControl.Properties.Resources.tb_next;
            this.tbPageNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbPageNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPageNext.Name = "tbPageNext";
            this.tbPageNext.Size = new System.Drawing.Size(28, 28);
            this.tbPageNext.Text = "toolStripButton3";
            this.tbPageNext.ToolTipText = "Next Page";
            this.tbPageNext.Click += new System.EventHandler(this.tbPageNext_Click);
            // 
            // tbPageLast
            // 
            this.tbPageLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbPageLast.Image = global::EspackFileStreamControl.Properties.Resources.tb_last;
            this.tbPageLast.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tbPageLast.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbPageLast.Name = "tbPageLast";
            this.tbPageLast.Size = new System.Drawing.Size(28, 28);
            this.tbPageLast.Text = "toolStripButton4";
            this.tbPageLast.ToolTipText = "LastPage";
            this.tbPageLast.Click += new System.EventHandler(this.tbPageLast_Click);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(19, 28);
            this.toolStripLabel3.Text = "    ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(19, 28);
            this.toolStripLabel2.Text = "    ";
            // 
            // tpZoomOut
            // 
            this.tpZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tpZoomOut.Image = global::EspackFileStreamControl.Properties.Resources.tb_zoom_out;
            this.tpZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpZoomOut.Name = "tpZoomOut";
            this.tpZoomOut.Size = new System.Drawing.Size(23, 28);
            this.tpZoomOut.Text = "-";
            this.tpZoomOut.ToolTipText = "Zoom Out";
            this.tpZoomOut.Click += new System.EventHandler(this.tpZoomOut_Click);
            // 
            // tpZoomIn
            // 
            this.tpZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tpZoomIn.Image = global::EspackFileStreamControl.Properties.Resources.tb_zoom_in;
            this.tpZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpZoomIn.Name = "tpZoomIn";
            this.tpZoomIn.Size = new System.Drawing.Size(23, 28);
            this.tpZoomIn.Text = "+";
            this.tpZoomIn.ToolTipText = "Zoom In";
            this.tpZoomIn.Click += new System.EventHandler(this.tpZoomIn_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(19, 28);
            this.toolStripLabel4.Text = "    ";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // panelContent
            // 
            this.panelContent.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panelContent.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panelContent.Controls.Add(this.pbPage);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 32);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(919, 703);
            this.panelContent.TabIndex = 5;
            // 
            // pbPage
            // 
            this.pbPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPage.Location = new System.Drawing.Point(0, 0);
            this.pbPage.Name = "pbPage";
            this.pbPage.Size = new System.Drawing.Size(919, 703);
            this.pbPage.TabIndex = 2;
            this.pbPage.TabStop = false;
            // 
            // EspackFileDataContainerPreview
            // 
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTop);
            this.Name = "EspackFileDataContainerPreview";
            this.Size = new System.Drawing.Size(919, 735);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPage)).EndInit();
            this.ResumeLayout(false);

        }
        /*
         *            wbViewer.Navigate(string.Format(@"about:blank", fsFileData.PDFFileData.TempFileDataPath));
            SpinWait.SpinUntil(() => wbViewer.IsBusy == false);
            Application.DoEvents();
            if ((CTLM.Status == CommonTools.EnumStatus.ADDNEW || CTLM.Status == CommonTools.EnumStatus.SEARCH || CTLM.Status == CommonTools.EnumStatus.NAVIGATE) && fsFileData.PDFFileData.Data != null)
            {
                wbViewer.Navigate(string.Format(@"file:///{0}", fsFileData.PDFFileData.TempFileDataPath));
                SpinWait.SpinUntil(() => wbViewer.IsBusy == false);
                Application.DoEvents();
            }
         * */
        public override void SetStatus(EnumStatus value)
        {
            this.Enabled = true;
        }
        public override void UpdateEspackControl()
        {
            base.UpdateEspackControl();
            LoadPreview();

        }
        public override void ClearEspackControl()
        {
            base.ClearEspackControl();
            //pbPage.Invalidate();
            _viewer.Close();

            _stdOut.Clear();
            _stdErr.Clear();

            pbPage.Image = null;
            tbPageNumber.Text = string.Empty;
            tbTotalPages.Text = string.Empty;

            //pbPage.Update();
            //pbPage = null;
        }

        public void LoadPreview()
        {
            //wbPreview.Navigate(@"about:blank");
            //SpinWait.SpinUntil(() => wbPreview.IsBusy == false);
            //Application.DoEvents();
            //Thread.Sleep(1000);

            if (TempFileDataPath != "")
            {
                
                _viewer.Open(TempFileDataPath, _gsVersion, true);

                _viewer.Zoom(1);
                //wbPreview.Navigate(string.Format(@"file:///{0}", TempFileDataPath));
                //SpinWait.SpinUntil(() => wbPreview.IsBusy == false);
                //Application.DoEvents();
            }
        }
        public EspackFileDataContainerPreview(): base()
        {
            InitializeComponent();
            _viewer = new GhostscriptViewer();
            _viewer.AttachStdIO(new GhostscriptStdIOHandler(_stdOut, _stdErr));

            _viewer.DisplaySize += new GhostscriptViewerViewEventHandler(_viewer_DisplaySize);
            _viewer.DisplayUpdate += new GhostscriptViewerViewEventHandler(_viewer_DisplayUpdate);
            _viewer.DisplayPage += new GhostscriptViewerViewEventHandler(_viewer_DisplayPage);
            
        }



        protected override void Dispose(bool disposing)
        {
            _viewer.Dispose();
            base.Dispose(disposing);
        }


    }
}
