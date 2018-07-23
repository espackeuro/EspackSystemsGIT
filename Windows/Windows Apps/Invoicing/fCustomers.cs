using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EspackFormControlsNS;
using static Invoicing.Values;

namespace Invoicing
{
    public partial class fCustomers : Form
    {
        public fCustomers()
        {
            InitializeComponent();

            //CTLM definitions
            CTLM.Conn = gDatos;
            CTLM.sSPAdd = "PAdd_Clientes";
            CTLM.sSPUpp = "PUpp_Clientes";
            CTLM.sSPDel = "PDel_Clientes";
            CTLM.AddItem(txtCode, "Codigo", CTLMControlTypes.PK);
            CTLM.AddItem(txtName, "Nombre", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtAddress, "Direccion", CTLMControlTypes.AddUppNoSearch);
            CTLM.AddItem(txtTown, "Poblacion", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtPostalCode, "Codigo_Postal", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtCounty, "Provincia", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtVATNumber, "Cif", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtPaymentCode, "CPago", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtDueDays, "Dias_Vto", CTLMControlTypes.AddUppNoSearch);
            CTLM.AddItem(txtSupplierCode, "SupCod", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtVAT, "IVA", CTLMControlTypes.AddUppNoSearch);
            CTLM.AddItem(txtCurrencyCode, "Cod_Divisa", CTLMControlTypes.AddUppSearch);
            CTLM.AddItem(txtIBAN, "IBAN", CTLMControlTypes.AddUppSearch);



            CTLM.AddDefaultStatusStrip();
            CTLM.DBTable = string.Format("(Select * from vUsers where isnull(PositionLevel,50)>={0}) B", SecurityLevel);
            CTLM.ReQuery = true;



            cboCOD3.Source("select n.COD3,g.Descripcion from NetworkSedes n inner join general..sedes g on g.cod3=n.COD3 order by n.Cod3", txtDesCod3);
            listCOD3.Source("select n.COD3,g.Descripcion from NetworkSedes n inner join general..sedes g on g.cod3=n.COD3 order by n.Cod3");
            listCOD3.ValueChanged += ListCOD3_Changed;
            cboDomain.Source("Select domain from domain where domain<>'ALL' order by domain");
            cboPosition.Source(string.Format("select PositionCode,PositionDescription from MasterUserPositions where MinSecurityLevel>={0} order by MinSecurityLevel", SecurityLevel), txtPosition);
            cboPositionLevel.Source(string.Format("select SecurityLevel from MasterSecurityLevels where SecurityLevel>={0} order by SecurityLevel", SecurityLevel));
            cboSecurityLevel.Source(string.Format("select SecurityLevel from MasterSecurityLevels where SecurityLevel>={0} order by SecurityLevel", SecurityLevel));
            cboArea.Source(string.Format("select idArea from MasterAreas order by idArea", SecurityLevel));
            lstFlags.Source("Select codigo,DescFlagEng from flags where Tabla='Users'");
            CTLM.AfterButtonClick += CTLM_AfterButtonClick;
            CTLM.Start();

        }
    }
}
