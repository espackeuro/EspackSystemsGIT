using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.IsolatedStorage;
using System.Xml;
using CommonToolsWin;

namespace Sistemas
{
    public partial class fSettings : Form
    {
        public fSettings()
        {
            InitializeComponent();
            txtDefaultPasswordForServers.Text = Values.DefaultPasswordForServers;
            txtDefaultUserForServers.Text = Values.DefaultUserForServers;
            this.FormClosed += FSettings_FormClosed;
        }

        private void FSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            cSettings.writeSetting("DefaultUserForServers", txtDefaultUserForServers.Text);
            Values.DefaultUserForServers = txtDefaultUserForServers.Text;
            cSettings.writeSetting("DefaultPasswordForServers", txtDefaultPasswordForServers.Text);
            Values.DefaultPasswordForServers = txtDefaultPasswordForServers.Text;
        }

    }
}
