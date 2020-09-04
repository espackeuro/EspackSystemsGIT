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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Reflection;

namespace EspackMenuNS
{
    public interface EspackMenuItem
    {
        Form MDIParent();
    }

    public partial class EspackMenuContainer : UserControl
    {
        public EspackToolStripItem GetCloseButton
        {
            get => CloseButton;
        }

        public EspackMenu GetEspackMenu
        {
            get => ElMenu;
        }

        //public String ProjectName { get; set; }
        

        public EspackMenuContainer()
        {
            InitializeComponent();
        }

        private void ElBotonDeCerrar_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        //form opening control
        public static Dictionary<string, Form> InstancedForms = new Dictionary<string, Form>();
        public static string ProjectName { get => Assembly.GetEntryAssembly().GetName().Name; }
        //private Form Parent { get; set; }
        public static Form CurrentForm
        {
            get; set;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CurrentForm?.Close();
        }
    }
}


