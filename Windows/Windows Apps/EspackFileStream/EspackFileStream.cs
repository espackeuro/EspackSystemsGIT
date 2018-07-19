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

//namespace EspackFormControlsNS
//{
//    public class EspackFileStream : EspackFormControlCaption
//    {
//        //private FileStream fileStream;// = new FileStream();
//        public EspackTextBox TbFileName { get; set; } = new EspackTextBox();
//        public EspackFileDataContainer FileData { get; set; }
//        public EspackFileDataContainerPreview PDFFileData { get; set; }
//        //public byte[] FileData { get; set; }
//        public Button BtnSearch { get; set; } = new Button();
//        // File name and type properties
//        public string FileName { get => TbFileName.Text; set => TbFileName.Text = value; }
//        public string FileExtension { get => Path.GetExtension(FileName).ToLower(); }
//        private List<string> convertibleExtensions = new List<string> { ".doc", ".docx", ".xls", ".xlsx", ".csv" };
//        private List<string> wordExtensions = new List<string> { ".doc", ".docx" };
//        private List<string> excelExtensions = new List<string> { ".xls", ".xlsx", ".csv" };
//        public bool IsPDFConvertible { get => convertibleExtensions.Contains(FileExtension); }
//        public bool IsWordDocument { get => wordExtensions.Contains(FileExtension); }
//        public bool IsExcelDocument { get => excelExtensions.Contains(FileExtension); }
//        //database properties
//        /*
//        public string DBFileDataField { get => FileData?.DBDataField; set => FileData.DBDataField = value; }
//        public string DBFileCode { get => FileData?.DBCodeField; set => FileData.DBCodeField = value; }
//        public string DBPDFFileDataField { get => PDFFileData?.DBDataField; set => PDFFileData.DBDataField = value; }
//        public string DBPDFFileCode { get => PDFFileData?.DBCodeField; set => PDFFileData.DBCodeField = value; }
//        */
//        //published properties from textbox

//        public override string Text { get => TbFileName.Text; set => TbFileName.Text = value; }
//        public HorizontalAlignment TextAlign { get => TbFileName.TextAlign; set => TbFileName.TextAlign = value; }
//        public bool Multiline { get => TbFileName.Multiline; set => TbFileName.Multiline = value; }
//        public override bool ReadOnly { get => TbFileName.ReadOnly; set => TbFileName.ReadOnly = value; }
//        public AutoCompleteMode AutoCompleteMode { get => TbFileName.AutoCompleteMode; set => TbFileName.AutoCompleteMode = value; }
//        public AutoCompleteSource AutoCompleteSource { get => TbFileName.AutoCompleteSource; set => TbFileName.AutoCompleteSource = value; }
//        public AutoCompleteStringCollection AutoCompleteCustomSource { get => TbFileName.AutoCompleteCustomSource; set => TbFileName.AutoCompleteCustomSource = value; }
//        public override EnumStatus Status { get => TbFileName.Status; set => TbFileName.Status = value; }
//        public override string DBField { get => TbFileName.DBField; set => TbFileName.DBField = value; }
//        public override object DefaultValue { get => TbFileName.DefaultValue; set => TbFileName.DefaultValue = value; }
//        public override Type DBFieldType { get => TbFileName.DBFieldType; set => TbFileName.DBFieldType = value; }
//        public override DA ParentDA { get => TbFileName.ParentDA; set => TbFileName.ParentDA = value; }
//        public override DynamicRS DependingRS { get => TbFileName.DependingRS; set => TbFileName.DependingRS = value; }
//        public override EspackControlTypeEnum EspackControlType { get => TbFileName.EspackControlType; set => TbFileName.EspackControlType = value; }


//        //public EspackControl TextBox { get => (EspackTextBox)this; }
//        public EspackFileStream()
//            : base()
//        {
//            InitializeComponent();
//            //Move += EspackFileStream_Move;
//            BtnSearch.Click += BtnSearch_Click;

//            //ParentChanged += EspackFileStream_ParentChanged;
//        }

//        public override Control Control
//        {
//            get => TbFileName;
//        }

//        private void BtnSearch_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog dialog = new OpenFileDialog();
//            dialog.Title = "Select a document";
//            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//            {
//                //UseWaitCursor = true;
//                Cursor.Current = Cursors.WaitCursor;
//                // Assign the cursor in the Stream to the Form's Cursor property.  
//                var fileStream = dialog.OpenFile();
//                var rdr = new BinaryReader(fileStream);
//                FileData.Value = rdr.ReadBytes((int)fileStream.Length);
//                FileName = Path.GetFileName(dialog.FileName);
//                FileData.FileName = FileName;
//                PDFFileData.FileName = Path.ChangeExtension(FileName, ".pdf");
//                PDFFileData.Value = ConvertToPDF();
//                PDFFileData.WriteTempFile(".pdf");
//                PDFFileData.LoadPreview();
//                //UseWaitCursor = false;
//                Cursor.Current = Cursors.Default;
//            }
//            //base.Size = new Size(0, 0);
//        }



//        private byte[] ConvertToPDF()
//        {
//            try
//            {
//                byte[] _result = null;
//                if (IsPDFConvertible)
//                {
//                    if (IsWordDocument)
//                        _result = ConvertWordToPDF(FileData.Data);
//                }
//                return _result;
//            } catch (Exception ex)
//            {
//                CommonToolsWin.CTWin.MsgError(ex.Message);
//                return null;
//            }
//        }

//        //private bool resizing = false;

//        //public new Size Size
//        //{
//        //    get => new Size(TbFileName?.Width??0 + BtnSearch?.Width??0, TbFileName?.Height??0);
//        //    set => TbFileName.Size = new Size(value.Width - BtnSearch.Width, value.Height);
//        //}

//        private void EspackFileStream_Resize(object sender, EventArgs e)
//        {
//            TbFileName.Location = new System.Drawing.Point(0, 3 + CaptionLabel.PreferredHeight);
//            TbFileName.Size = new Size(base.Size.Width - BtnSearch.Size.Width, Size.Height);

//            BtnSearch.Location = new System.Drawing.Point(TbFileName.Width, CaptionLabel.PreferredHeight + 1);
//        }

//        public override object Value
//        {
//            get => TbFileName?.Value;
//            set => TbFileName.Value = value;
//        }

//        public override void UpdateEspackControl()
//        {
//            TbFileName.UpdateEspackControl();
//            if (FileData != null)
//                FileData.FileName = Text;
//            if (PDFFileData != null)
//                PDFFileData.FileName = Path.ChangeExtension(Text,".pdf");
//        }

//        public override void ClearEspackControl()
//        {
//            TbFileName.ClearEspackControl();
//        }


//        // Public implementation of Dispose pattern callable by consumers.
//        public new void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        bool disposed = false;
//        protected override void Dispose(bool disposing)
//        {
//            if (disposed)
//                return;
//            if (disposing)
//            {
//                foreach (Control c in Controls)
//                    c.Dispose();
//                base.Dispose(true);
//                // Free any other managed objects here.
//                //
//            }

//            // Free any unmanaged objects here.
//            //
//            disposed = true;
//        }

//        private void InitializeComponent()
//        {
//            //this.TbFileName = new EspackFormControlsNS.EspackTextBox();
//            this.SuspendLayout();
//            // 
//            // TbFileName
//            // 
//            this.TbFileName.Add = false;
//            this.TbFileName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
//            this.TbFileName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
//            this.TbFileName.Caption = "";
//            this.TbFileName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
//            this.TbFileName.DBField = null;
//            this.TbFileName.DBFieldType = null;
//            this.TbFileName.DefaultValue = null;
//            this.TbFileName.Del = false;
//            this.TbFileName.DependingRS = null;
//            this.TbFileName.ExtraDataLink = null;
//            this.TbFileName.IsCTLMOwned = false;
//            this.TbFileName.IsPassword = false;
//            this.TbFileName.Location = new System.Drawing.Point(0, 0);
//            this.TbFileName.Multiline = false;
//            this.TbFileName.Name = "TbFileName";
//            this.TbFileName.Order = 0;
//            this.TbFileName.ParentConn = null;
//            this.TbFileName.ParentDA = null;
//            this.TbFileName.PK = false;
//            this.TbFileName.Protected = false;
//            this.TbFileName.ReadOnly = false;
//            this.TbFileName.Search = false;
//            this.TbFileName.Size = new System.Drawing.Size(154, 25);
//            this.TbFileName.Status = CommonTools.EnumStatus.ADDNEW;
//            this.TbFileName.TabIndex = 0;
//            this.TbFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
//            this.TbFileName.Upp = false;
//            this.TbFileName.Value = "";
//            // 
//            // EspackFileStream
//            // 
//            this.BackColor = System.Drawing.Color.Transparent;
//            this.Controls.Add(this.TbFileName);
//            this.Name = "EspackFileStream";
//            this.Size = new System.Drawing.Size(359, 264);
//            this.ResumeLayout(false);

//        }
//    }
//}
