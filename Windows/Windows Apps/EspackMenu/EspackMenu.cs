using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static EspackMenuNS.EspackMenu;

namespace EspackMenuNS
{
    public interface EspackMenuItem
    {
        Form MDIParent();
    }
    public class EspackToolStripItem : ToolStripMenuItem, EspackMenuItem
    {
        protected override void OnClick(EventArgs e)
        {
            // Call the base code
            base.OnClick(e);

            // Check the Tag is defined.
            if (Tag != null)
            {
                // If we don't want to do anything with this item click event, we set the Tag to "-". Useful for the root items of a menu.
                if (Tag.ToString() != "-")
                    // Open the form whose name is the Tag string.
                    openForm();
            }  else
                // The Tag is not defined: we show an error explaining what to do for those fool IT guys.
                MessageBox.Show(string.Format("Tag property not set when designing menu entry '{0}'. Use a form name or a '-' if you not opening intended.", Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public Form MDIParent()
        {

            EspackMenuItem _parent = null;
            if (Owner is EspackMenuItem)
                _parent = (EspackMenuItem)Owner;
            else if (OwnerItem is EspackMenuItem)
                _parent = (EspackMenuItem)OwnerItem;

            if (_parent != null)
                return _parent.MDIParent();
            else return null;
        }
        private void openForm()
        {
            var formName = Tag.ToString();
            var form = (Form)GetChildInstance(formName);
            if (form == null)
                return;
            form.WindowState = FormWindowState.Maximized;
        }
        //remember to fill property ProjectName on design time
        private object GetChildInstance(String pFormName)
        {
            Form _Form;
            if (!InstancedForms.TryGetValue(pFormName, out _Form))
            {
                try
                {
                    var _type = Type.GetType(string.Format("{0}.{1},{0}", ProjectName, pFormName));
                    _Form = (Form)Activator.CreateInstance(_type);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Form '{0}' doesn't exist yet. {1}", pFormName, ex.Message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                //_Form =(Form)(Assembly.GetEntryAssembly().CreateInstance(pFormName));

                _Form.MdiParent = MDIParent();
                InstancedForms.Add(pFormName, _Form);
            }
            InstancedForms[pFormName].Show();
            InstancedForms[pFormName].WindowState = FormWindowState.Normal;
            InstancedForms[pFormName].FormClosed += delegate (object source, FormClosedEventArgs e)
            {
                InstancedForms.Remove(pFormName);
                //base.FormClosed(source, e);
            };
            return InstancedForms[pFormName];  //just created or created earlier.Return it+69
        }


    }

    public class EspackMenu : MenuStrip, EspackMenuItem
    {
        private Form mdiFormParent { get; set; }
        public Form MDIParent()
        {
            if (Parent is Form)
                return (Form)Parent;
            else return null;
        }

        //form opening control
        public static Dictionary<string, Form> InstancedForms = new Dictionary<string, Form>();
        public static string ProjectName { get => Assembly.GetEntryAssembly().GetName().Name; }
        //private Form Parent { get; set; }

    }
}


