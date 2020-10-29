
using CommonTools;
using System;
using System.Reflection;
using System.Windows.Forms;


namespace EspackMenuNS
{
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
                    OpenForm();
            }
            else
                // The Tag is not defined: we show an error explaining what to do for those fool IT guys.
                MessageBox.Show(string.Format("Tag property not set when designing menu entry '{0}'. Use a form name or a '-' if not opening intended.", Text), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public Form MDIParent
        {
            get => Owner is EspackMenuItem ? ((EspackMenuItem)Owner).MDIParent : OwnerItem is EspackMenuItem ? ((EspackMenuItem)OwnerItem).MDIParent : null;
        }

        public EspackMenu MainMenuParent
        {
            get
            {
                if (Owner is EspackMenu)
                    return (EspackMenu)Owner;
                else if (OwnerItem is EspackToolStripItem)
                    return ((EspackToolStripItem)OwnerItem).MainMenuParent;
                else return null;
            }
        }

        private void OpenForm()
        {
            var formName = Tag.ToString();
            var form = (Form)GetChildInstance(formName);
            if (form == null)
                return;
            MainMenuParent.Text = string.Format("{0} Build {1} - ({1:yyyyMMdd}) - {2}", MainMenuParent.ProjectName, Assembly.GetExecutingAssembly().GetName().Version.ToString(), CT.GetBuildDateTime(Assembly.GetExecutingAssembly()), form.Text);


            
        }

        private void Form_Deactivate(object sender, EventArgs e)
        {
            MainMenuParent.DisableCloseButton();
            MainMenuParent.Text = string.Format("{0} Build {1} - ({1:yyyyMMdd})", MainMenuParent.ProjectName, Assembly.GetExecutingAssembly().GetName().Version.ToString(), CT.GetBuildDateTime(Assembly.GetExecutingAssembly()));
        }

        private void Form_Activated(object sender, EventArgs e)
        {
            MainMenuParent.EnableCloseButton();
            MainMenuParent.Text = string.Format("{0} Build {1} - ({1:yyyyMMdd}) - {2}", MainMenuParent.ProjectName, Assembly.GetExecutingAssembly().GetName().Version.ToString(), CT.GetBuildDateTime(Assembly.GetExecutingAssembly()), ((Form)sender).Name);
            ((Form)sender).Dock = DockStyle.Fill;
        }
        private void _Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainMenuParent.InstancedForms.Remove((Form)sender);
        }
        //remember to fill property ProjectName on design time
        private object GetChildInstance(String pFormName)
        {
            Form _Form;
            _Form = MainMenuParent.InstancedForm(pFormName);
            if (_Form == null)
            {
                try
                {
                    var _type = Type.GetType(string.Format("{0}.{1},{0}", MainMenuParent.ProjectName, pFormName));
                    _Form = (Form)Activator.CreateInstance(_type);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("Form '{0}' load error: {1}", pFormName, ex.Message), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
                //_Form =(Form)(Assembly.GetEntryAssembly().CreateInstance(pFormName));

                _Form.MdiParent = MDIParent;
                _Form.MaximizeBox = false;
                _Form.MinimizeBox = false;
                _Form.ControlBox = false;
                _Form.FormBorderStyle = FormBorderStyle.None;
                _Form.AutoScroll = true;
                //_Form.WindowState = FormWindowState.Maximized;
                _Form.FormClosed += _Form_FormClosed;
                _Form.Activated += Form_Activated;
                _Form.Deactivate += Form_Deactivate;
                MainMenuParent.InstancedForms.Add(_Form);
                _Form.Show();
                _Form.Activate();
            }
            else
                _Form.Activate();

            return _Form;  //just created or created earlier.Return it+69
        }


    }
}


