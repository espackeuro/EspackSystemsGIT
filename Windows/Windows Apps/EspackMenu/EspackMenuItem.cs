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
using System.Windows.Forms;

namespace EspackMenuNS
{
    public interface EspackMenuItem
    {
        Form MDIParent { get; }
    }
}


