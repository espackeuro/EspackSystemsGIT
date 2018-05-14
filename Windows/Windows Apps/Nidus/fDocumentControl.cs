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
using VSGrid;
namespace Nidus
{
    public partial class fDocumentControl : Form
    {
        public fDocumentControl()
        {
            InitializeComponent();
            VS.Conn = Values.gDatos;
            VS.SQL = "Select Area,UserCode from Users ";
            VS.Start();
            VS.UpdateEspackControl();
            VS.FilterRowEnabled = true;
            this.Load += FDocumentControl_Load;
            this.KeyDown += FDocumentControl_KeyDown;
        }

        private void FDocumentControl_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.Print("Caca");
        }

        private void FDocumentControl_Load(object sender, EventArgs e)
        {
            VS.AddFilterCell(FilterCellTypes.CHECKEDCOMBO, 0, "Select distinct idArea,Description from MasterAreas");
            VS.AddFilterCell(FilterCellTypes.TEXT, 1, "Select UserCode from Users order by UserCode");
        }

        private void CboTest_Changed(object sender, EspackFormControls.ChangeEventArgs e)
        {
            Debug.Print(e.NewValue);
        }
    }
}
