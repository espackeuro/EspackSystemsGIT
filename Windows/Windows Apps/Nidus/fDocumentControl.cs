using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EspackDataGrid;
using EspackFormControls;

namespace Nidus
{
    public partial class fDocumentControl : Form
    {
        public fDocumentControl()
        {
            InitializeComponent();

            //CTLM definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "pDocumentsCabAdd";
            CTLM.DBTable = "(Select *, DATA=null, PDFDATA=null from DocumentsCab) B";

            //var txtFileName = (EspackTextBox)fsFileData;

            //Header
            CTLM.AddItem(txtDocumentCode, "DocumentCode",false,false,false,1,true,true);
            CTLM.AddItem(txtTypeCode, "TypeCode", true, false, false, 2, false, true);
            CTLM.AddItem(txtSubtype, "SubTypeCode", true, false, false, 2, false, true);
            CTLM.AddItem(txtSection, "SectionCode", true, false, false, 2, false, true);
            CTLM.AddItem(txtTitle, "Title", true, false, false, 2, false, true);
            CTLM.AddItem(fsFileData.FileData, "DATA", true, false, false, 2, false, false);
            CTLM.AddItem(fsFileData.PDFFileData, "PDFDATA", true, false, false, 2, false, false);
            CTLM.AddItem(fsFileData.TbFileName, "DocumentFileName", true, false, false, 0, false, true);
            CTLM.AddItem(txtEdition, "Edition", false, false, false, 2, false, true);
            CTLM.AddItem(txtStatus, "Status", false, false, false, 2, false, true);
            CTLM.AddItem(lstFlags, "flags", true, false, false, 0, false, true);

            //filestream object data
            fsFileData.DBFileCode = "DocumentCode";
            fsFileData.DBFileDataField = "DATA";
            fsFileData.DBPDFFileCode = "DocumentCode";
            fsFileData.DBPDFFileDataField = "DATA";
            //Fields
            lstFlags.Source("Select codigo,DescFlagEng from flags where Tabla='DocumentsCab'");

            VS.Conn = Values.gDatos;
            VS.SQL = "Select TypeCode,SectionCode,Title from DocumentsCab ";
            VS.Start();
            Resize += FDocumentControl_Resize;

            VS.UpdateEspackControl();

            //start
            CTLM.ReQuery = true;
            CTLM.AddDefaultStatusStrip();
            CTLM.Start();

            //VS.FilterRowEnabled = true;
            this.Load += FDocumentControl_Load;

        }

        private void FDocumentControl_Resize(object sender, EventArgs e)
        {
            VS.Height = ClientRectangle.Height- CTLM.CTLStatusBar.Height;
        }

        private void TxtTest_ValueChanged(object sender, EspackFormControls.ValueChangedEventArgs e)
        {
            Debug.Print("caca");//throw new NotImplementedException();
        }

        private void FDocumentControl_Load(object sender, EventArgs e)
        {
            //VS.AddFilterCell(EspackCellTypes.CHECKEDCOMBO, 0, "Select distinct idArea,Description from MasterAreas");
            //VS.AddFilterCell(EspackCellTypes.TEXT, 1, "Select UserCode from Users order by UserCode");
            //VS.AddFilterCell(EspackCellTypes.COMBO, 2, "Select distinct Domain from Users order by Domain");
        }

    }
}
