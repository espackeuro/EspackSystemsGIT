using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Personal.Values;

namespace Personal
{
    public partial class fLocalHolidays : Form
    {
        public fLocalHolidays()
        {
            InitializeComponent();
            var iniYear = DateTime.Now.Year - 1;
            var yearRange = 11;
            cboYear.DataSource = Enumerable.Range(iniYear, yearRange).ToList();
            // cboCOD3.Source($"Select valor,valor from dbo.Split((Select COD3 from SISTEMAS.dbo.Users where UserCode='{conn.User}'),'|') order by Valor", conn);
            cboCOD3.Update();
            /*
            yearCalendar.MinDate = new System.DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0, 0);
            yearCalendar.MaxDate = new System.DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59, 100);
            */

            cboYear.ValueChanged += CboYear_ValueChanged;
            cboYear.Value = DateTime.Now.Year;
            yearCalendar.CalendarDimensions = new Size(4, 3);
        }

        private void CboYear_ValueChanged(object sender, EspackFormControlsNS.ValueChangedEventArgs e)
        {
            yearCalendar.MaxDate = new System.DateTime(Convert.ToInt32(cboYear.Value), 12, 31, 23, 59, 59, 100);
            yearCalendar.MinDate = new System.DateTime(Convert.ToInt32(cboYear.Value), 1, 1, 0, 0, 0, 0);
            
        }

        private void FLocalHolidays_Load(object sender, EventArgs e)
        {

        }
    }
}
