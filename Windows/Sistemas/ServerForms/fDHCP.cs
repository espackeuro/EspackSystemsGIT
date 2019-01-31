using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccesoDatosNet;
using System.IO;


namespace Sistemas
{
    public partial class fDHCP : Form
    {
        //public Dictionary<string, ServerCheckWithInfo> ListServers = new Dictionary<string, ServerCheckWithInfo>();

        public fDHCP()
        {
            InitializeComponent();
            // servers list
            serverList1.User = Values.DefaultUserForServers;
            serverList1.Password = Values.DefaultPasswordForServers;
            serverList1.Start("DHCPServer", "service isc-dhcp-server restart", btnProcess);

        }

        private async void btnProcess_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will update the DHCP server assignments and will restart the service.\n Are you sure? ", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                foreach (var server in serverList1.ListServers.Where(s => s.CheckBox.Checked == true))
                {
                    string _configFile = "";
                    //create the temp File
                    using (var _RSD = new DynamicRS("Select * from vDHCPConfig where COD3='" + server.Info.COD3 + "'", Values.gDatos))
                    {

                        await _RSD.OpenAsync();
                        string _group = "";

                        while (!_RSD.EOF)
                        {
                            if (_RSD["Group"].ToString() != _group)
                            {
                                if (_group != "")
                                    _configFile += "\t}\n";
                                _group = _RSD["Group"].ToString();
                                _configFile += "# " + _group + '\n' + "group " + _group + "{" + '\n';
                            }
                            _configFile += "\t# " + _RSD["Comment"].ToString() + '\n';
                            _configFile += "\thost " + _RSD["Host"].ToString() + " {" + '\n';
                            _configFile += "\t\thardware ethernet " + _RSD["MAC"].ToString() + ";" + '\n';
                            _configFile += "\t\tfixed-address " + _RSD["IP"].ToString() + ";" + '\n';
                            _configFile += "\t\t}\n";
                            _RSD.MoveNext();
                        }
                        _configFile += "\t}\n";
                        _RSD.Close();
                    }
                    server.Info.FileName = string.Format("/etc/dhcp/{0}_NET.conf", server.Info.COD3);
                    server.Info.FileContent = _configFile;
                }
                //execute tasks
                await serverList1.ExecuteCommandInServers();
            }
        }
    }
}
