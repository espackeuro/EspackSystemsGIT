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
            txtDefaultPasswordForServers.TextChanged += TxtDefaultPasswordForServers_TextChanged;
            txtDefaultUserForServers.TextChanged += TxtDefaultUserForServers_TextChanged;
            txtDefaultPasswordForServers.Text = Values.DefaultPasswordForServers;
            txtDefaultUserForServers.Text = Values.DefaultUserForServers;
        }

        private void TxtDefaultUserForServers_TextChanged(object sender, EventArgs e)
        {
            cSettings.writeSetting("DefaultUserForServers", txtDefaultUserForServers.Text);
            Values.DefaultUserForServers = txtDefaultUserForServers.Text;
        }

        private void TxtDefaultPasswordForServers_TextChanged(object sender, EventArgs e)
        {
            cSettings.writeSetting("DefaultPasswordForServers", txtDefaultUserForServers.Text);
            Values.DefaultPasswordForServers = txtDefaultPasswordForServers.Text;
        }

    }
}
