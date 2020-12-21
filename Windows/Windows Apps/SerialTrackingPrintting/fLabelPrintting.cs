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
using CommonToolsWin;
using EspackDataGridView;
using System.Threading;
using EspackClasses;
//using RawPrinterHelper;


namespace SerialTrackingPrintting
{
    public partial class fLabelPrintting : Form
    {
        public fLabelPrintting()
        {
            InitializeComponent();
        }

        // Object Events
        private void txtEnterData_KeypPress(object sender, KeyPressEventArgs e)
        {
            // Click print button when Enter Key is pressed
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                btnPrint.PerformClick();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //if (txtEnterData.Text!="")
            //{


            //    // EspackTextbox doesn't allow to select text programmatically
            //    //txtEnterData.SelectionStart = 0;
            //    //txtEnterData.SelectionLength = txtEnterData.Text.Length
            //    txtEnterData.Text = "";
            //    txtEnterData.Select();
        }
        private void printLabel()
        {
            //string _printerAddress = "";
            //int _printerResolution = 0;
            //using (var _RS = new DynamicRS(string.Format("select descripcion,cmp_varchar,cmp_integer from ETIQUETAS..datosEmpresa where codigo='{0}'", Values.LabelPrinterAddress), Values.gDatos))
            //{
            //    _RS.Open();
            //    _printerAddress = _RS["cmp_varchar"].ToString();
            //    _printerResolution = Convert.ToInt32(_RS["cmp_integer"]);
            //    //_printerType = _RS["descripcion"].ToString().Split('|')[0];
            //}
            //var _label = new ZPLLabel(70, 32, 3, _printerResolution);
            //var _unitLabel = new SingleBarcode(_label);

            ////_label.addLine(35, 3, 0, "C", "", "[BC][UNITNUMBER]", 0, 2.5F, 1,true);
            ////var _param = new Dictionary<string, string>();
            //using (var _printer = new cRawPrinterHelper(_printerAddress))
            //{
            //    var _delimiterLabel = new ZPLLabel(_unitLabel.Label.width, _unitLabel.Label.height, 3, _unitLabel.Label.dpi);
            //    delimiterLabel.delim(_delimiterLabel, "START UNIT LABELS", "-");
            //    _printer.SendUTF8StringToPrinter(_delimiterLabel.ToString(), 1);
            //    //for (var i = _labelInit; i < _labelInit + Convert.ToInt32(txtQty.Value); i++)
            //    for (var i = _labelInit + Convert.ToInt32(txtQty.Value) - 1; i >= _labelInit; i--)
            //    {
            //        _unitLabel.Parameters["VALUE"] = txtCharacter.Text + i.ToString().PadLeft(8, '0');
            //        for (var j = 0; j < Convert.ToInt32(txtQtyLabel.Text); j++)
            //            _printer.SendUTF8StringToPrinter(_unitLabel.ToString(), 1);
            //    }
            //    delimiterLabel.delim(_delimiterLabel, "END UNIT LABLES", "-");
            //    _printer.SendUTF8StringToPrinter(_delimiterLabel.ToString(), 1);
            //}
        }
    }



}

