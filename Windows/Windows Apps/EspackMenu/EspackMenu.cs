using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EspackMenuNS
{
    public class EspackToolStripItemCollection : ToolStripItemCollection
    {

    }

    public class EspackMenu:MenuStrip
    {

        //form opening control
        private static Dictionary<string, Form> InstancedForms = new Dictionary<string, Form>();
        public string ProjectName { get; set; }
        //private Form Parent { get; set; }

        public override ToolStripItemCollection Items
        {
            get;
            set
            {

            }
        }

        private void openForm(object menuOption)
        {
            var formName = ((ToolStripMenuItem)menuOption).Tag.ToString();
            var form = (Form)GetChildInstance(formName);
            form.WindowState = FormWindowState.Maximized;
        }
        //remember to fill property ProjectName on design time
        private object GetChildInstance(String pFormName)
        {
            Form _Form;
            if (!InstancedForms.TryGetValue(pFormName, out _Form))
            {
                _Form = (Form)Activator.CreateInstance(Type.GetType(ProjectName + "." + pFormName));
                _Form.MdiParent = (Form)this.Parent;
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



        protected override void OnItemClicked(ToolStripItemClickedEventArgs e)
        {
            base.OnItemClicked(e);
            if (!(e.ClickedItem.Tag == null) && e.ClickedItem.Tag.ToString() != "")
                openForm(e.ClickedItem);
        }
    }

}
