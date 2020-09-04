//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Drawing;
//using System.Data;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace EspackMenu
//{
//    public partial class EspackMenuContainer : UserControl
//    {
//        public EspackMenuContainer()
//        {
//            InitializeComponent();
//        }
//    }
//}
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace EspackMenuNS
{
    public class EspackMenu : MenuStrip, EspackMenuItem
    {
        private Form mdiFormParent { get; set; }
        public Form MDIParent()
        {
            if (Parent is Form)
                return (Form)Parent;
            else return null;
        }
        public EspackToolStripItem CloseButton
        {
            get => Items.OfType<EspackToolStripItem>().Where(i => i.Name=="CloseButton").FirstOrDefault();
        }
    }
}


