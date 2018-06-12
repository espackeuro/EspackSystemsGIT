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
using CTLMantenimientoNet;
using DiverseControls;

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

            //Header
            CTLM.AddItem(txtReceivalNumber, "RecNumber", false, true, true, 1, true, true);
            CTLM.AddItem(cboService, "Service", true, true,true, 1, true, true);
            CTLM.AddItem(txtDate, "Date", false, true, false, 0, false, false);
            CTLM.AddItem(txtSupplierDoc, "SupplierDoc", true, true, false, 0, false, false);
            CTLM.AddItem(txtUser, "UserProc", true, true, false, 0, false, false);
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
            VS.sSPDel = "pPackReceivalsDetDel";
            VS.AllowInsert = true;
            VS.AllowUpdate = false;
            VS.AllowDelete = true;
            VS.DBTable = "vPackReceivalsDet";

            //VS Columns
            VS.AddColumn("RecNumber", txtReceivalNumber, "@RecNumber", pSPDel: "@RecNumber", pVisible: false);
            VS.AddColumn("Service", cboService, "@Service", pSPDel: "@Service", pVisible: false);
            VS.AddColumn("UnitNumber", "UnitNumber", "@UnitNumber", pSPDel: "@UnitNumber");
            VS.AddColumn("Reference", "Reference", "@Reference", pSortable: true, pWidth: 90, aMode: AutoCompleteMode.SuggestAppend, aSource: AutoCompleteSource.CustomSource, aQuery: string.Format("select Reference from MasterRepairReferences where service='{0}'", cboService.Value));
            VS.AddColumn("Description", "Description", pSortable: true, pWidth: 200);
            //VS.AddColumn("Flags", "Flags", "");
            VS.CellEndEdit += VS_CellEndEdit; 
            
            //Various
            CTLM.AddDefaultStatusStrip();
            CTLM.AddItem(VS);
            CTLM.Start();
            //CTLM.AfterButtonClick += CTLM_AfterButtonClick;
            //CTLM.BeforeButtonClick += CTLM_BeforeButtonClick;
            //toolStrip.Enabled = false;
            
         

        }

        private void VS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (VS.Columns[e.ColumnIndex].Name == "Reference")
            {
                if (VS.CurrentCell.Value != "")
                {
                    using (var _rs = new StaticRS(string.Format("Select Description from MasterRepairReferences where reference='{0}' and service='{1}'", VS[e.ColumnIndex, e.RowIndex].Value, cboService.Value), Values.gDatos))
                    {
                        _rs.Open();
                        if (_rs.RecordCount == 0)
                        {
                            MessageBox.Show("Wrong partnumber", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            VS[e.ColumnIndex, e.RowIndex].Value = "";
                            VS[VS.Columns["Description"].Index, e.RowIndex].Value = "";
                            VS.CurrentCell = VS[e.ColumnIndex, e.RowIndex];
                        }
                        else
                        {
                            VS[VS.Columns["Description"].Index, e.RowIndex].Value = _rs["Description"].ToString();
                            VS.CurrentCell = VS[VS.Columns["Description"].Index, e.RowIndex];
                        }
                    }

                }
                else
                {
                    VS[VS.Columns["Description"].Index, e.RowIndex].Value = "";
                }
            }
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

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (txtReceivalNumber.Text != "")
            {
                using (var _pd = new PrintDialog())
                {
                    if (_pd.ShowDialog() == DialogResult.OK)
                    {
                        using (var _recDoc = new EspackPrinting())
                        {
                            _recDoc.PrinterSettings = _pd.PrinterSettings;
                            _pd.Document = _recDoc;

                            //EspackFont pFont = new EspackFont("Arial", 10F, pBrush: new SolidBrush(Color.Blue));

                            // Define the header
                            _recDoc.AddArea(EnumDocumentZones.HEADER, new EspackFont("Tahoma", 3.5F),EnumZoneDocking.RIGHTWARDS);
                            _recDoc.AddImage(Properties.Resources.Logo_Espack_transparente, pHeight: 36F);
                            _recDoc.AddDrawing(8F, 8F,( _pd.Document.DefaultPageSettings.PaperSize.Width / 3.937F ) -8F, 20F, EnumDrawingType.RECTANGLE,new Pen(Color.Black,0.1F));
                            
                            _recDoc.AddArea(EnumDocumentZones.HEADER, EnumZoneDocking.RIGHTWARDS);
                            _recDoc.AddText(true,"REC.NUMBER:",true);
                            _recDoc.AddText(true, "SUPPLIER DOC:", true);
                            _recDoc.AddText( "");

                            _recDoc.AddArea(EnumDocumentZones.HEADER,EnumZoneDocking.RIGHTWARDS);
                            _recDoc.AddText(txtReceivalNumber.Text,true);
                            _recDoc.AddText(txtSupplierDoc.Text);

                            _recDoc.AddArea(EnumDocumentZones.HEADER, EnumZoneDocking.RIGHTWARDS);
                            _recDoc.AddText(true,"SERVICE: ");
                            _recDoc.AddText(cboService.Text);

                            _recDoc.AddArea(EnumDocumentZones.HEADER, EnumZoneDocking.RIGHTWARDS);
                            _recDoc.AddText(true,"DATE: ");
                            _recDoc.AddText(txtDate.Text, true);


                            // Define the footer
                            _recDoc.AddArea(EnumDocumentZones.FOOTER, new EspackFont("Tahoma", 3F)); //, new Font(fontFamily, 10, FontStyle.Bold), new SolidBrush(Color.Black));
                            _recDoc.AddText("Sign");

                            // Define the body
                            if (!_recDoc.AddQuery(string.Format("select UNITNUMBER,REFERENCE,DESCRIPTION from vPackReceivalsDet where RecNumber='{0}' order by UnitNumber", txtReceivalNumber.Text), Values.gDatos, new EspackFont("Tahoma", 2.5F)))
                                return;

                            // Print that
                            _recDoc.Print();
                        }
                    }
                }
            }

        }
    }
}
