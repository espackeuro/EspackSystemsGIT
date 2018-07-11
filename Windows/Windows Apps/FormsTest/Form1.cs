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
            txtUserCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtUserCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //txtUserCode.TextBox.Multiline = false;
            var autoCompleteCustomSource = new AutoCompleteStringCollection();
            txtText.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtText.AutoCompleteSource = AutoCompleteSource.CustomSource;
            using (DynamicRS rs = new DynamicRS("Select UserCode from Users", CTLM.Conn))
            {
                rs.Open();
                rs.ToList().ForEach(r => autoCompleteCustomSource.Add(r[0].ToString()));
            }
            txtUserCode.AutoCompleteCustomSource = autoCompleteCustomSource;
            txtText.AutoCompleteCustomSource = autoCompleteCustomSource;
            CTLM.DBTable = "vUsers";
            CTLM.AddItem(txtUserCode, "UserCode", CTLMControlTypes.Search);
            CTLM.AddItem(txtUserNumber, "UserNumber", CTLMControlTypes.Search);
            CTLM.AddItem(txtPwdExp, "PasswordEXP", CTLMControlTypes.NoSearch);
            CTLM.AddItem(cboMainCOD3, "MainCOD3", CTLMControlTypes.Search);
            CTLM.AddItem(lstCOD3, "COD3", CTLMControlTypes.Search);
            CTLM.AddItem(txtDesCod3,"desCOD3", CTLMControlTypes.NoSearch);

            lstCOD3.Source("select n.COD3,Descripcion=n.cod3 from NetworkSedes n inner join general..sedes g on g.cod3=n.COD3 order by n.Cod3");
            cboMainCOD3.Source("select n.COD3,g.Descripcion from NetworkSedes n inner join general..sedes g on g.cod3=n.COD3 order by n.Cod3", txtDesCod3);
            CTLM.Start();


        }

    }
}
