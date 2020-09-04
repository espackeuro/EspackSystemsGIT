
using CommonTools;
using System;
using System.Reflection;
using System.Windows.Forms;
using static EspackMenuNS.EspackMenuContainer;

namespace EspackMenuNS
{
    public class EspackToolStripItem : ToolStripMenuItem, EspackMenuItem
    {
        public event EventHandler FormActivated;
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
            }
            else
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

        public EspackMenu MainMenuParent()
        {
            if (Owner is EspackMenu)
                return (EspackMenu)Owner;
            else if (OwnerItem is EspackToolStripItem)
                return ((EspackToolStripItem)OwnerItem).MainMenuParent();
            else return null;
        }

        private void openForm()
        {
            var formName = Tag.ToString();
            var form = (Form)GetChildInstance(formName);
            if (form == null)
                return;
            //form.WindowState = FormWindowState.Maximized;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.ControlBox = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.AutoScroll = true;
            form.Dock = DockStyle.Fill;
            MainMenuParent().Text = string.Format("{0} Build {1} - ({1:yyyyMMdd}) - {2}", ProjectName ,Assembly.GetExecutingAssembly().GetName().Version.ToString(), CT.GetBuildDateTime(Assembly.GetExecutingAssembly()), form.Text);
            form.WindowState = FormWindowState.Normal;
            CurrentForm = form;
            form.Activated -= Form_Activated;
            form.Activated += Form_Activated;
            form.Deactivate -= Form_Deactivate;
            form.Deactivate += Form_Deactivate;
        }

        private void Form_Deactivate(object sender, EventArgs e)
        {
            this.MainMenuParent().CloseButton.Enabled = false;
            MainMenuParent().Text = string.Format("{0} Build {1} - ({1:yyyyMMdd})", ProjectName, Assembly.GetExecutingAssembly().GetName().Version.ToString(), CT.GetBuildDateTime(Assembly.GetExecutingAssembly()));
            CurrentForm = null;
        }

        private void Form_Activated(object sender, EventArgs e)
        {
            CurrentForm = (Form)sender;
            this.MainMenuParent().CloseButton.Enabled = true;
            MainMenuParent().Text = string.Format("{0} Build {1} - ({1:yyyyMMdd}) - {2}", ProjectName, Assembly.GetExecutingAssembly().GetName().Version.ToString(), CT.GetBuildDateTime(Assembly.GetExecutingAssembly()), CurrentForm.Text);
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
                    MessageBox.Show(string.Format("Form '{0}' load error: {1}", pFormName, ex.Message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
}


