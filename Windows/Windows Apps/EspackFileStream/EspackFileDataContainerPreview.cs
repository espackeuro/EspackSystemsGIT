using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonTools;

namespace EspackFileStream
{
    public class EspackFileDataContainerPreview : EspackFileDataContainer
    {
        private System.Windows.Forms.WebBrowser wbPreview;

        public override bool ReadOnly { get; set; }

        private void InitializeComponent()
        {
            this.wbPreview = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // wbPreview
            // 
            this.wbPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPreview.Location = new System.Drawing.Point(0, 0);
            this.wbPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPreview.Name = "wbPreview";
            this.wbPreview.Size = new System.Drawing.Size(210, 164);
            this.wbPreview.TabIndex = 0;
            // 
            // EspackFileDataContainerPreview
            // 
            this.Controls.Add(this.wbPreview);
            this.Name = "EspackFileDataContainerPreview";
            this.Size = new System.Drawing.Size(210, 164);
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
            wbPreview.Navigate(@"about:blank");
            SpinWait.SpinUntil(() => wbPreview.IsBusy == false);
            Application.DoEvents();
            //Thread.Sleep(1000);
        }

        public void LoadPreview()
        {
            //wbPreview.Navigate(@"about:blank");
            //SpinWait.SpinUntil(() => wbPreview.IsBusy == false);
            //Application.DoEvents();
            //Thread.Sleep(1000);

            if (TempFileDataPath != "")
            {
                wbPreview.Navigate(string.Format(@"file:///{0}", TempFileDataPath));
                SpinWait.SpinUntil(() => wbPreview.IsBusy == false);
                Application.DoEvents();
            }
        }
        public EspackFileDataContainerPreview(): base()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            wbPreview.Dispose();
            base.Dispose(disposing);
        }
    }
}
