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
using System;
using System.Collections.ObjectModel;

namespace EspackMenuNS
{
    public class EspackMenu : MenuStrip, EspackMenuItem
    {
        private Form mdiFormParent { get; set; }
        //private EspackToolStripItem Menu1;
        private EspackToolStripItem CloseButton;
        public Collection<Form> InstancedForms = new Collection<Form>();
        public string ProjectName { get => Assembly.GetEntryAssembly().GetName().Name; }
        public EspackMenu()
        {
            InitializeComponent();
            CloseButton.Click += CloseButton_Click;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CurrentForm.Close();
        }

        public void DisableCloseButton()
        {
            CloseButton.Enabled = false;
        }

        public void EnableCloseButton()
        {
            CloseButton.Enabled = true;
        }
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EspackMenu));
            //Menu1 = new EspackMenuNS.EspackToolStripItem();
            CloseButton = new EspackMenuNS.EspackToolStripItem();
            SuspendLayout();
            // 
            // ElMenu
            // 
            ImageScalingSize = new System.Drawing.Size(20, 20);
            Items.AddRange(new EspackToolStripItem[] {
            //this.Menu1,
            this.CloseButton});
            Location = new System.Drawing.Point(0, 0);
            Name = "ElMenu";
            Size = new System.Drawing.Size(553, 28);
            TabIndex = 1;
            Tag = "-";
            Text = "ElMenu";
            // 
            // Menu1
            // 
            //this.Menu1.Name = "Menu1";
            //this.Menu1.Size = new System.Drawing.Size(60, 24);
            //this.Menu1.Tag = "-";
            //this.Menu1.Text = "Menu";
            // 
            // CloseButton
            // 
            this.CloseButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CloseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.CloseButton.Enabled = false;
            this.CloseButton.Image = Properties.Resources.close;
            this.CloseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(34, 24);
            CloseButton.Tag = '-';
            // 
            // EspackMenuContainer
            // 
            AutoSize = true;
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            MinimumSize = new System.Drawing.Size(133, 30);
            Name = "EspackMenu";
            Size = new System.Drawing.Size(553, 34);
            ResumeLayout(false);
            PerformLayout();
        }

        public Form MDIParent
        {
            get
            {
                if (Parent is Form)
                    return (Form)Parent;
                else return null;
            }
        }

        public Form InstancedForm(string formName)
        {
            return InstancedForms.Where(n => n.Name == formName).FirstOrDefault();
        }
        public Form CurrentForm
        {
            get => MDIParent.ActiveMdiChild;
        }
    }
}


