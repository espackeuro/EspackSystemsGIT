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
namespace Nidus
{
    public partial class fDocumentControl : Form
    {
        public fDocumentControl()
        {
            InitializeComponent();
            VS.Conn = Values.gDatos;
            VS.SQL = "Select Area,UserCode,Domain from Users ";
            VS.Start();


            VS.UpdateEspackControl();
            VS.FilterRowEnabled = true;
            this.Load += FDocumentControl_Load;
            txtTest.ValueChanged += TxtTest_ValueChanged;
        }

        private void TxtTest_ValueChanged(object sender, EspackFormControls.ValueChangedEventArgs e)
        {
            Debug.Print("caca");//throw new NotImplementedException();
        }

        private void FDocumentControl_Load(object sender, EventArgs e)
        {
            VS.AddFilterCell(EspackCellTypes.CHECKEDCOMBO, 0, "Select distinct idArea,Description from MasterAreas");
            VS.AddFilterCell(EspackCellTypes.TEXT, 1, "Select UserCode from Users order by UserCode");
            VS.AddFilterCell(EspackCellTypes.COMBO, 2, "Select distinct Domain from Users order by Domain");
        }

        private void CboTest_Changed(object sender, EspackFormControls.ChangeEventArgs e)
        {
            Debug.Print(e.NewValue);
        }
    }
}
