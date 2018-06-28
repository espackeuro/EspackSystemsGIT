using AccesoDatosNet;
using CommonTools;
using EspackControls;
using EspackFormControlsNS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MicrosoftOfficeTools.MSTools;

namespace EspackFileStream
{
#if DEBUG
    public class EspackFileStream : EspackFormControlCommonMiddle
#else
    public class EspackFileStream : EspackFormControlCommon
#endif
    {
        //private FileStream fileStream;// = new FileStream();
        public EspackTextBox TbFileName { get; set; }
        public EspackFileDataContainer FileData { get; set; }
        public EspackFileDataContainerPreview PDFFileData { get; set; }
        //public byte[] FileData { get; set; }
        public Button BtnSearch { get; set; }
        // File name and type properties
        public string FileName { get => TbFileName.Text; set => TbFileName.Text = value; }
        public string FileExtension { get => Path.GetExtension(FileName).ToLower(); }
        private List<string> convertibleExtensions = new List<string> { ".doc", ".docx", ".xls", ".xlsx", ".csv" };
        private List<string> wordExtensions = new List<string> { ".doc", ".docx" };
        private List<string> excelExtensions = new List<string> { ".xls", ".xlsx", ".csv" };
        public bool IsPDFConvertible { get => convertibleExtensions.Contains(FileExtension); }
        public bool IsWordDocument { get => wordExtensions.Contains(FileExtension); }
        public bool IsExcelDocument { get => excelExtensions.Contains(FileExtension); }
        //database properties
        /*
        public string DBFileDataField { get => FileData?.DBDataField; set => FileData.DBDataField = value; }
        public string DBFileCode { get => FileData?.DBCodeField; set => FileData.DBCodeField = value; }
        public string DBPDFFileDataField { get => PDFFileData?.DBDataField; set => PDFFileData.DBDataField = value; }
        public string DBPDFFileCode { get => PDFFileData?.DBCodeField; set => PDFFileData.DBCodeField = value; }
        */
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
        public override bool Add { get => TbFileName.Add; set => TbFileName.Add = value; }
        public override bool Upp { get => TbFileName.Upp; set => TbFileName.Upp = value; }
        public override bool Del { get => TbFileName.Del; set => TbFileName.Del = value; }
        public override int Order { get => TbFileName.Order; set => TbFileName.Order = value; }
        public override bool PK { get => TbFileName.PK; set => TbFileName.PK = value; }
        public override bool Search { get => TbFileName.Search; set => TbFileName.Search = value; }
        public override object DefaultValue { get => TbFileName.DefaultValue; set => TbFileName.DefaultValue = value; }
        public override Type DBFieldType { get => TbFileName.DBFieldType; set => TbFileName.DBFieldType = value; }
        public override DA ParentDA { get => TbFileName.ParentDA; set => TbFileName.ParentDA = value; }
        public override DynamicRS DependingRS { get => TbFileName.DependingRS; set => TbFileName.DependingRS = value; }
        public override EspackControlTypeEnum EspackControlType { get => TbFileName.EspackControlType; set => TbFileName.EspackControlType = value; }

        public override string Caption
        {
            get
            {
                if (CaptionLabel != null)
                {
                    return CaptionLabel.Caption;
                }
                else return null;
            }
            set
            {
                CaptionLabel.Caption = value;
                //CaptionLabel.Location = new Point(Location.X - CaptionLabel.PreferredWidth - 6, Location.Y);
                CaptionLabel.Location = new System.Drawing.Point(0, 0);//(base.Location.X, base.Location.Y - CaptionLabel.PreferredHeight);
            }
        }

        //public EspackControl TextBox { get => (EspackTextBox)this; }
        public EspackFileStream()
            : base()
        {
            InitializeComponent();
            //Move += EspackFileStream_Move;
            BtnSearch.Click += BtnSearch_Click;

            //ParentChanged += EspackFileStream_ParentChanged;
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
                }
                return _result;
            } catch (Exception ex)
            {
                CommonToolsWin.CTWin.MsgError(ex.Message);
                return null;
            }
        }

        //private bool resizing = false;

        //public new Size Size
        //{
        //    get => new Size(TbFileName?.Width??0 + BtnSearch?.Width??0, TbFileName?.Height??0);
        //    set => TbFileName.Size = new Size(value.Width - BtnSearch.Width, value.Height);
        //}

        private void EspackFileStream_Resize(object sender, EventArgs e)
        {
            TbFileName.Location = new System.Drawing.Point(0, 3 + CaptionLabel.PreferredHeight);
            TbFileName.Size = new Size(base.Size.Width - BtnSearch.Size.Width, Size.Height);

            BtnSearch.Location = new System.Drawing.Point(TbFileName.Width, CaptionLabel.PreferredHeight + 1);
        }

        public override object Value
        {
            get => TbFileName?.Value;
            set => TbFileName.Value = value;
        }

        public override void UpdateEspackControl()
        {
            TbFileName.UpdateEspackControl();
            if (FileData != null)
                FileData.FileName = Text;
            if (PDFFileData != null)
                PDFFileData.FileName = Path.ChangeExtension(Text,".pdf");
        }

        public override void ClearEspackControl()
        {
            TbFileName.ClearEspackControl();
        }


        // Public implementation of Dispose pattern callable by consumers.
        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        bool disposed = false;
        protected override void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                foreach (Control c in Controls)
                    c.Dispose();
                base.Dispose(true);
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        private void InitializeComponent()
        {
            TbFileName = new EspackTextBox() { Size = new Size(200, 17), Location = new System.Drawing.Point(0, 9) };
            BtnSearch = new Button() { Text = "...", Size = new Size(30, 19), Location = new System.Drawing.Point(200, 7) };
            //FileData = new EspackFileDataContainer();
            //PDFFileData = new EspackFileDataContainer();
            SuspendLayout();
            CaptionLabel = TbFileName.CaptionLabel;
            CaptionLabel.ForeColor = Color.Black;
            TbFileName.Caption = Caption;
            Controls.Add(TbFileName);
            Controls.Add(BtnSearch);
            BackColor = System.Drawing.SystemColors.Control; ;
            Resize += EspackFileStream_Resize;
            this.Name = "EspackFileStream";
            this.Size = new Size(230, 19 + CaptionLabel.PreferredHeight);
            this.ResumeLayout(false);
            this.PerformLayout();


            this.SuspendLayout();
            // 
            // EspackFileStream
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Name = "EspackFileStream";
            this.Size = new System.Drawing.Size(405, 141);
            this.ResumeLayout(false);

        }
    }
}
