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



namespace Repairs
{
    public partial class fReceivals : Form
    {
        public fReceivals()
        {
            InitializeComponent();

            //CTLM Definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "pPackReceivalsCabAdd";
            CTLM.sSPUpp = "pPackReceivalsCabUpp";
            CTLM.sSPDel = "pPackReceivalsCabDel";
            CTLM.DBTable = "vPackReceivalsCabCOD3";
            //CTLM.DBTable = "(Select H.*,DescService=S.Nombre from HSAReceivalsCab H inner join Servicios S on S.codigo=H.service where s.cod3='" + Values.COD3 + "' and dbo.CheckFlag(s.flags,'HSA')=1) a";

            //Header
            CTLM.AddItem(txtReceivalNumber, "RecNumber", false, true, true, 1, true, true);
            CTLM.AddItem(cboService, "Service", true, true,true, 1, true, true);
            CTLM.AddItem(txtDate, "Date", false, true, false, 0, false, true);
            CTLM.AddItem(txtSupplierDoc, "SupplierDoc", true, true, false, 0, false, false);
            CTLM.AddItem(txtUser, "User", true, true, false, 0, false, false);
            CTLM.AddItem(txtNotes, "Notes", true, true, false, 0, false, false);
            CTLM.AddItem(lstFlags, "Flags", true, true, false, 0, false, true);
            CTLM.AddItem(txtDescService, "DescService");
            CTLM.AddItem(Values.COD3, "cod3", pSearch: true);

            CTLM.ReQuery = true;

            //fields
            cboService.Source("Select ServiceCode,Description from MasterRepairServices where cod3='" + Values.COD3 + "' order by ServiceCode", txtDescService);
            cboService.SelectedValueChanged += CboService_SelectedValueChanged;
            lstFlags.Source("Select FlagCode,Caption from MasterFlags where TableName='PackReceivalsCab'");


            
            //VS Definitions
            VS.Conn = Values.gDatos;
            VS.sSPAdd = "pPackReceivalsDetAdd";
            VS.sSPAdd = "pPackReceivalsDetDel";
            VS.AllowInsert = true;
            VS.AllowUpdate = false;
            VS.AllowDelete = true;
            VS.DBTable = "vHSAReceivalsDet";

            //VS Details
            VS.AddColumn("RecCode", txtReceivalNumber, "@RecCode");
            VS.AddColumn("Line", "line");
            VS.AddColumn("Partnumber", "partnumber", "@partnumber", pSortable: true, pWidth: 90, aMode: AutoCompleteMode.SuggestAppend, aSource: AutoCompleteSource.CustomSource, aQuery: string.Format("select partnumber from referencias where servicio='{0}'", cboService.Value));
            VS.AddColumn("Description", "description", pSortable: true, pWidth: 200);
            VS.AddColumn("Qty", "Qty", "@qty", pWidth: 90);
            VS.AddColumn("SupplierDoc", "SupplierDoc", "@supplierDoc");
            //VS.AddColumn("Flags", "Flags", "");
            //VS.CellEndEdit += VS_CellEndEdit; //VS_CellValidating; ; ;
            
            //Various
            CTLM.AddDefaultStatusStrip();
            //CTLM.AddItem(VS);
            CTLM.Start();
            //CTLM.AfterButtonClick += CTLM_AfterButtonClick;
            //CTLM.BeforeButtonClick += CTLM_BeforeButtonClick;
            //toolStrip.Enabled = false;
            
         

        }

        private void CboService_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboService.Value.ToString() != "")
            {
                try
                {
                    using (var _RS = new StaticRS(string.Format("Select Description from MasterRepairServices where ServiceCode='{0}' and Cod3='{1}'", cboService.Value, Values.COD3), Values.gDatos))
                    {
                        _RS.Open();
                        if (_RS.RecordCount != 0)
                        {
                            //txtDescService.Text = _RS["Description"].ToString();
                        }
                        else
                        {
                            cboService.Value = "";
                            txtDescService.Value = "";
                        }

                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboService.Value = "";
                    txtDescService.Value = "";
                }
            }
            else
            {
                txtDescService.Value = "";
            }
        }
    }
}
