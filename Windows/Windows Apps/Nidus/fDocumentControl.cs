using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EspackDataGrid;
using EspackFormControlsNS;
using static MicrosoftOfficeTools.MSTools;
using EspackFileStream;
using System.Collections.ObjectModel;
using CTLMantenimientoNet;


namespace Nidus
{
    public enum NidusPermissions { GLOBAL_SYSTEM_PROC, GLOBAL_SYSTEM_PROC_MANUAL, LOCAL_OPER, GLOBAL_READER, LOCAL_READER, GLOBAL_ADMINISTRATOR, LOCAL_ADMINISTRATOR }
    public enum NidusDocumentStatus { APPROVED, PENDING_REVISION, PENDING_APPROVAL, OBSOLETE}
    public partial class fDocumentControl : Form
    {
        //public EspackFileDataContainer FdcData { get; set; } = new EspackFileDataContainer();

        public fDocumentControl()
        {
            InitializeComponent();

            //CTLM definitions
            CTLM.Conn = Values.gDatos;
            CTLM.sSPAdd = "pDocumentsCabAdd";
            CTLM.DBTable = "vDocumentControl";

            //var txtFileName = (EspackTextBox)fsFileData;
            var FdcData = new EspackFileDataContainer();
            //file containers
            fsFileData.FileData = FdcData;
            fsFileData.PDFFileData = FdcPDFData;
            //Header
            CTLM.AddItem(txtDocumentCode, "DocumentCode",false,false,false,1,true,true);
            CTLM.AddItem(txtTypeCode, "TypeCode", true, false, false, 2, false, true);
            CTLM.AddItem(txtSubtype, "SubTypeCode", true, false, false, 2, false, true);
            CTLM.AddItem(txtSection, "SectionCode", true, false, false, 2, false, true);
            CTLM.AddItem(txtTitle, "Title", true, false, false, 2, false, true);
            CTLM.AddItem(fsFileData, "DocumentFileName", true, false, false, 0, false, true);
            CTLM.AddItem(FdcData, "DATA", true, false, false, 2, false, false);
            CTLM.AddItem(FdcPDFData, "PDFDATA", true, false, false, 2, false, false);
            CTLM.AddItem(txtEdition, "Edition", false, false, false, 2, false, true);
            CTLM.AddItem(txtStatus, "Status", false, false, false, 2, false, true);
            CTLM.AddItem(lstFlags, "flags", true, false, false, 0, false, true);

            //Fields
            lstFlags.Source("Select codigo,DescFlagEng from flags where Tabla='DocumentsCab'");
            fsFileData.BtnSearch.Click += BtnSearch_Click;
            VS.Conn = Values.gDatos;
            VS.SQL = "Select TypeCode,SectionCode,Title from DocumentsCab ";
            VS.Start();
            
            //Resize += FDocumentControl_Resize;

            VS.UpdateEspackControl();
            //CTLM.AddItem(VS);
            //start
            CTLM.ReQuery = true;
            CTLM.AddDefaultStatusStrip();
            CTLM.Start();
            VS.FilterRowEnabled = true;
            this.Load += FDocumentControl_Load;
            var c = VS.DataCellCollection;
            //AcroPDFLib.AcroPDF acroPDF = new AcroPDFLib.AcroPDFClass();

        }
        private bool changing = false;
        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (VS.DataGridView.CurrentCell != null && !changing)
            {
                changing = true;
                CTLM.ClearValues();
                VS.DataGridView.Rows[VS.DataGridView.CurrentCell?.RowIndex ?? 0].Selected = true;
                CTLM.SetStatus(CommonTools.EnumStatus.SEARCH);
                txtTypeCode.Text = VS.CurrentRow.Cells[0].Value.ToString();
                txtSection.Text = VS.CurrentRow.Cells[1].Value.ToString();
                txtTitle.Text = VS.CurrentRow.Cells[2].Value.ToString();
                CTLM.Button_Click(CTLMButtonsEnum.btnOk);
                changing = false;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "")
                txtTitle.Text = Path.GetFileNameWithoutExtension(fsFileData.FileName);
        }

        private void TxtTest_ValueChanged(object sender, EspackFormControlsNS.ValueChangedEventArgs e)
        {
            Debug.Print("caca");//throw new NotImplementedException();
        }

        private void FDocumentControl_Load(object sender, EventArgs e)
        {
            VS.AddFilterCell(EspackCellTypes.CHECKEDCOMBO, 0, "Select distinct Type=TypeCode,TypeCode from DocumentsCab");
            VS.AddFilterCell(EspackCellTypes.CHECKEDCOMBO, 1, "Select distinct Section=SectionCode,SectionCode from DocumentsCab");
            VS.AddFilterCell(EspackCellTypes.TEXT, 2, "Select distinct Title from DocumentsCab");
            VS.DataGridView.SelectionChanged += DataGridView_SelectionChanged;
        }
        
        private List<NidusPermissions> GetUserPermissions(string user)
        {
            return new List<NidusPermissions>() { NidusPermissions.GLOBAL_SYSTEM_PROC, NidusPermissions.GLOBAL_SYSTEM_PROC_MANUAL, NidusPermissions.LOCAL_OPER };
        }

    }
}
