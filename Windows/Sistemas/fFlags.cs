using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccesoDatosNet;
using CommonTools;

namespace Sistemas
{
    public partial class fFlags : Form
    {
        //private string _prevStatus;
        public fFlags()
        {
            InitializeComponent();
            //CTLM Definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "pAddFlags";
            CTLM.sSPUpp = "pUppFlags";
            CTLM.sSPDel = "pDelFlags";
            CTLM.AddItem(txtIdReg, "IdReg", false, true, false,0, true, true);
            CTLM.AddItem(cboTable,"Tabla", true, true, true, 1, false, true);
            CTLM.AddItem(txtSection, "Section", true, true, true, 2, false, true);
            CTLM.AddItem(txtLetter, "Letra", true, true, false, 0, false, true);
            CTLM.AddItem(txtCode, "Codigo", true, true, true, 3, false, true);
            CTLM.AddItem(txtDescFlag, "DescFlag", true, true, false, 0, false, true);
            CTLM.AddItem(txtDesFlagEng, "DescFlagEng", true, true, false, 0, false, true);
            CTLM.AddItem(lstServices, "Servicio", true, true, false, 0, false, true);
            CTLM.AddItem(lstRequired, "DependencyFlags", true, true, false, 0, false, true);
            CTLM.AddItem(lstIncompatible, "IncompatibleFlags", true, true, false, 0, false, true);

            CTLM.AddDefaultStatusStrip();
            CTLM.DBTable = "vFlags";

            lstServices.Source("select ServiceCode,ServiceCode as 'DESC' from services order by servicecode, Description");
            lstRequired.Source(string.Format("select DescFlagEng from vFlags where tabla='{0}' and Section='{1}'  order by Codigo", cboTable.Value, txtSection.Value));
            lstIncompatible.Source(string.Format("select DescFlagEng from vFlags where tabla='{0}' and Section='{1}'  order by Codigo", cboTable.Value, txtSection.Value));
            cboTable.Source("select name from sistemas.sys.tables where is_ms_shipped=0 order by name");

            CTLM.Start();

            cboTable.ComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged;
            txtSection.Validated += TxtSection_Validated;
            CTLM.AfterButtonClick += CTLM_AfterButtonClick;
        }

        private void CTLM_AfterButtonClick(object sender, EspackFormControlsNS.CTLMEventArgs e)
        {
            UpdateLists();
        }

        private void TxtSection_Validated(object sender, EventArgs e)
        {
            UpdateLists();
        }


        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateLists();
        }

        private void UpdateLists()
        {
            lstRequired.Source(string.Format("select Codigo,DescFlagEng from vFlags where tabla='{0}' and Section='{1}' order by Codigo", cboTable.Value, txtSection.Value));
            lstRequired.UpdateEspackControl();
            lstIncompatible.Source(string.Format("select Codigo,DescFlagEng from vFlags where tabla='{0}' and Section='{1}' order by Codigo", cboTable.Value, txtSection.Value));
            lstIncompatible.UpdateEspackControl();
        }
    }
}
