using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistemas
{
    public class ServerCheckWithInfo
    {
        public CheckBox CheckBox { get; set; }
        public Label Label { get; set; }
        public ServerInfo Info { get; set; } = new ServerInfo();
    }

    public class ServerInfo
    {
        public string COD3 { get; set; }
        public string ServerName { get; set; }
        public string FileName { get; set; } = "";
        public string FileContent { get; set; } = "";
    }
}
