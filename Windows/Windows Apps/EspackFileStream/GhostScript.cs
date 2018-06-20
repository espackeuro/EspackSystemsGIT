using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ghostscript.NET;
using Ghostscript.NET.Viewer;

namespace EspackFileStream
{
    public class GhostscriptStdIOHandler : GhostscriptStdIO
    {
        private StringBuilder _stdOut;
        private StringBuilder _stdErr;

        public GhostscriptStdIOHandler(StringBuilder stdOut, StringBuilder stdErr) : base(false, true, true)
        {
            _stdOut = stdOut;
            _stdErr = stdErr;
        }

        public override void StdIn(out string input, int count)
        {
            throw new NotImplementedException();
        }

        public override void StdOut(string output)
        {
            _stdOut.AppendLine(output);
        }

        public override void StdError(string error)
        {
            _stdErr.AppendLine(error);
        }
    }

    public partial class EspackFileDataContainerPreview
    {

        void _viewer_DisplaySize(object sender, GhostscriptViewerViewEventArgs e)
        {
            pbPage.Image = e.Image;
        }

        void _viewer_DisplayUpdate(object sender, GhostscriptViewerViewEventArgs e)
        {
            pbPage.Invalidate();
            pbPage.Update();
        }

        void _viewer_DisplayPage(object sender, GhostscriptViewerViewEventArgs e)
        {
            pbPage.Invalidate();
            pbPage.Update();

            _supressPageNumberChangeEvent = true;
            tbPageNumber.Text = _viewer.CurrentPageNumber.ToString();
            _supressPageNumberChangeEvent = false;

            tbTotalPages.Text = " / " + _viewer.LastPageNumber.ToString();
        }

        private void tbPageFirst_Click(object sender, EventArgs e)
        {
            _stdOut.AppendLine("@GSNET_VIEWER -> COMMAND -> SHOW FIRST PAGE");
            _viewer.ShowFirstPage();
        }

        private void tbPagePrevious_Click(object sender, EventArgs e)
        {
            _stdOut.AppendLine("@GSNET_VIEWER -> COMMAND -> SHOW PREVIOUS PAGE");
            _viewer.ShowPreviousPage();
        }

        private void tbPageNext_Click(object sender, EventArgs e)
        {
            _stdOut.AppendLine("@GSNET_VIEWER -> COMMAND -> SHOW NEXT PAGE");
            _viewer.ShowNextPage();
        }

        private void tbPageLast_Click(object sender, EventArgs e)
        {
            _stdOut.AppendLine("@GSNET_VIEWER -> COMMAND -> SHOW LAST PAGE");
            _viewer.ShowLastPage();
        }
        private void tpZoomIn_Click(object sender, EventArgs e)
        {
            _stdOut.AppendLine("@GSNET_VIEWER -> COMMAND -> ZOOM IN");
            _viewer.ZoomIn();
        }

        private void tpZoomOut_Click(object sender, EventArgs e)
        {
            _stdOut.AppendLine("@GSNET_VIEWER -> COMMAND -> ZOOM OUT");
            _viewer.ZoomOut();
        }
    }
}
