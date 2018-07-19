using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CommonTools;
using AccesoDatosNet;
using EspackControls;
using static MicrosoftOfficeTools.MSTools;

namespace EspackFormControlsNS
{
    public partial class EspackFileStreamControl : EspackFormControlCaption
    {
        public EspackFileDataContainer FileData { get; set; }
        public EspackFileDataContainerPreview PDFFileData { get; set; }

        public string FileName { get => TbFileName.Text; set => TbFileName.Text = value; }
        public string FileExtension { get => Path.GetExtension(FileName).ToLower(); }
        private List<string> convertibleExtensions = new List<string> { ".doc", ".docx", ".xls", ".xlsx", ".csv", ".pdf" };
        private List<string> wordExtensions = new List<string> { ".doc", ".docx" };
        private List<string> excelExtensions = new List<string> { ".xls", ".xlsx", ".csv" };
        public bool IsPDFConvertible { get => convertibleExtensions.Contains(FileExtension); }
        public bool IsWordDocument { get => wordExtensions.Contains(FileExtension); }
        public bool IsExcelDocument { get => excelExtensions.Contains(FileExtension); }
        public bool IsPDFDocument { get => FileExtension.ToLower() == ".pdf"; }
        //published properties from textbox

        public override string Text { get => TbFileName.Text; set => TbFileName.Text = value; }
        public HorizontalAlignment TextAlign { get => TbFileName.TextAlign; set => TbFileName.TextAlign = value; }
        public bool Multiline { get => TbFileName.Multiline; set => TbFileName.Multiline = value; }
        public override bool ReadOnly { get => TbFileName.ReadOnly; set => TbFileName.ReadOnly = value; }
        public AutoCompleteMode AutoCompleteMode { get => TbFileName.AutoCompleteMode; set => TbFileName.AutoCompleteMode = value; }
        public AutoCompleteSource AutoCompleteSource { get => TbFileName.AutoCompleteSource; set => TbFileName.AutoCompleteSource = value; }
        public AutoCompleteStringCollection AutoCompleteCustomSource { get => TbFileName.AutoCompleteCustomSource; set => TbFileName.AutoCompleteCustomSource = value; }
        public override EnumStatus Status { get => TbFileName.Status; set => TbFileName.Status = value; }
        public override string DBField { get => TbFileName.DBField; set => TbFileName.DBField = value; }
        public override object DefaultValue { get => TbFileName.DefaultValue; set => TbFileName.DefaultValue = value; }
        public override Type DBFieldType { get => TbFileName.DBFieldType; set => TbFileName.DBFieldType = value; }
        public override DA ParentDA { get => TbFileName.ParentDA; set => TbFileName.ParentDA = value; }
        public override DynamicRS DependingRS { get => TbFileName.DependingRS; set => TbFileName.DependingRS = value; }
        public override EspackControlTypeEnum EspackControlType { get => TbFileName.EspackControlType; set => TbFileName.EspackControlType = value; }

        //exposed inner events
        public new event EventHandler Click
        {
            add { btnSearch.Click += value; }
            remove { btnSearch.Click -= value; }
        }


        public override Control Control
        {
            get => panel;
        }

        public EspackFileStreamControl()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Select a document";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //UseWaitCursor = true;
                Cursor.Current = Cursors.WaitCursor;
                // Assign the cursor in the Stream to the Form's Cursor property.  
                var fileStream = dialog.OpenFile();
                var rdr = new BinaryReader(fileStream);
                FileData.Value = rdr.ReadBytes((int)fileStream.Length);
                FileName = Path.GetFileName(dialog.FileName);
                FileData.FileName = FileName;
                PDFFileData.FileName = Path.ChangeExtension(FileName, ".pdf");
                PDFFileData.Value = ConvertToPDF();
                PDFFileData.WriteTempFile(".pdf");
                PDFFileData.LoadPreview();
                //UseWaitCursor = false;
                Cursor.Current = Cursors.Default;
            }
            //base.Size = new Size(0, 0);
        }

        private byte[] ConvertToPDF()
        {
            try
            {
                byte[] _result = null;
                if (IsPDFConvertible)
                {
                    if (IsWordDocument)
                        _result = ConvertWordToPDF(FileData.Data);
                    if (IsPDFDocument)
                        _result = FileData.Data;
                }
                return _result;
            }
            catch (Exception ex)
            {
                CommonToolsWin.CTWin.MsgError(ex.Message);
                return null;
            }
        }

        public override object Value
        {
            get => TbFileName?.Value;
            set => TbFileName.Value = value;
        }

        public override void SetStatus(EnumStatus value)
        {
            mStatus = value;
            Enabled = true;
            if (IsCTLMOwned)
                ReadOnly = !((Add && GetStatus() == EnumStatus.ADDNEW) || (Upp && GetStatus() == EnumStatus.EDIT && !PK) || (Del && GetStatus() == EnumStatus.DELETE) || (Search && GetStatus() == EnumStatus.SEARCH)) || Protected;
            TbFileName.SetStatus(value);
            btnSearch.Enabled = !ReadOnly;
        }

        public override void UpdateEspackControl()
        {
            TbFileName.UpdateEspackControl();
            if (FileData != null)
                FileData.FileName = Text;
            if (PDFFileData != null)
                PDFFileData.FileName = Path.ChangeExtension(Text, ".pdf");
        }

        public override void ClearEspackControl()
        {
            TbFileName.ClearEspackControl();
        }
    }
}
