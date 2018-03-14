using AccesoDatosNet;
using EspackControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EspackControls;


namespace DiverseControls
{
    public class EspackPrinting : PrintDocument
    {
        public string SQL { get; set; }
        //public string[] Titles { get; set; }

        List<EspackControl> Titles { get; set; }

        public EspackPrinting( StaticRS RS) : base()
        {
            
        }

        public EspackPrinting( EspackControl VS ) : base()
        {

        }

        protected override void OnPrintPage(PrintPageEventArgs e)
        {
            var g = e.Graphics;
            g.PageUnit = GraphicsUnit.Millimeter;

//            e.HasMorePages = (BodyList.LastPrintedLine < BodyList.Lines.Count);

            base.OnPrintPage(e);
        }

    }
}
