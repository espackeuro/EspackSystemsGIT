using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatosNet;
using EspackFormControlsNS;
namespace FormsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CTLM.Conn = new cAccesoDatosNet("DB01", "SISTEMAS", "sa", "5380");


            CTLM.DBTable = "Users";
            CTLM.AddItem(txtUserCode, "UserCode", CTLMControlTypes.Search);
            CTLM.AddItem(listCOD3, "COD3", CTLMControlTypes.Search);
            listCOD3.Source("select n.COD3,Descripcion=n.cod3 from NetworkSedes n inner join general..sedes g on g.cod3=n.COD3 order by n.Cod3");
            CTLM.Start();

        }
    }
}
