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
using EspackDataGridView;
using EspackFormControlsNS;
using static MicrosoftOfficeTools.MSTools;
using System.Collections.ObjectModel;


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
            //try
            //{
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
            CTLM.AddItem(txtDocumentCode, "DocumentCode", CTLMControlTypes.NoAddPK);
            CTLM.AddItem(txtTypeCode, "TypeCode", CTLMControlTypes.AddSearch);
            CTLM.AddItem(txtSubtype, "SubTypeCode", CTLMControlTypes.AddSearch);
            CTLM.AddItem(txtSection, "SectionCode", CTLMControlTypes.AddSearch);
            CTLM.AddItem(txtTitle, "Title", CTLMControlTypes.AddSearch);
            CTLM.AddItem(fsFileData, "DocumentFileName", CTLMControlTypes.AddSearch);
            CTLM.AddItem(FdcData, "DATA", CTLMControlTypes.AddNoSearch);
            CTLM.AddItem(FdcPDFData, "PDFDATA", CTLMControlTypes.AddNoSearch);
            CTLM.AddItem(txtEdition, "Edition", CTLMControlTypes.Search);
            CTLM.AddItem(txtStatus, "Status", CTLMControlTypes.Search);
            CTLM.AddItem(lstFlags, "flags", CTLMControlTypes.AddSearch);

            //Fields
            lstFlags.Source("Select codigo,DescFlagEng from flags where Tabla='DocumentsCab'");
            fsFileData.Click += BtnSearch_Click;
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
            //VS.AddFilterCell(EspackCellTypes.WILDCARDTEXT, 0, "Select distinct TypeCode from DocumentsCab order by TypeCode");
            this.Load += FDocumentControl_Load;
            var c = VS.DataCellCollection;
            //AcroPDFLib.AcroPDF acroPDF = new AcroPDFLib.AcroPDFClass();
            //} catch (Exception ex)
            //{
            //    CommonToolsWin.CTWin.MsgError(String.Format("Error 1: {0}\nError 2: {1}",ex.Message, ex.InnerException?.Message?? ""));
            //}

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
