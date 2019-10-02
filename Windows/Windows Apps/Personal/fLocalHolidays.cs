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
using AccesoDatosNet;

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
            cboCOD3.Source($"Select valor from dbo.Split((Select COD3 from SISTEMAS.dbo.Users where UserCode='{conn.User}'),'|') order by Valor", conn);
            var _mainCOD3 = new StaticRS($"Select MainCOD3 from SISTEMAS.dbo.Users where UserCode='{conn.User}'", conn);
            _mainCOD3.Open();
            cboCOD3.Update();
            cboCOD3.Value = _mainCOD3["MainCOD3"].ToString();
            _mainCOD3.Close();
            _mainCOD3 = null;
            /*
            yearCalendar.MinDate = new System.DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0, 0);
            yearCalendar.MaxDate = new System.DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59, 100);
            */

            cboYear.ValueChanged += CboYear_ValueChanged;
            cboYear.Value = DateTime.Now.Year;
            yearCalendar.CalendarDimensions = new Size(4, 3);
            yearCalendar.DateSelected += YearCalendar_DateSelected;
            conn.Open();
        }

        private async void YearCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            var day = e.Start;
            while (day<=e.End)
            {
                if (yearCalendar.BoldedDates.Contains(day))
                {
                    await yearCalendar.MiRemoveBoldedDate(day, cboCOD3.Text, conn);
                } else
                {
                    await yearCalendar.MiAddBoldedDate(day,cboCOD3.Text, conn);
                }
                yearCalendar.UpdateBoldedDates();
                day = day.AddDays(1);
            }
        }

        private void CboYear_ValueChanged(object sender, EspackFormControlsNS.ValueChangedEventArgs e)
        {
            if (Convert.ToInt32(e.NewValue) > Convert.ToInt32(e.OldValue))
            {
                yearCalendar.MaxDate = new System.DateTime(Convert.ToInt32(cboYear.Value), 12, 31, 23, 59, 59, 100);
                yearCalendar.MinDate = new System.DateTime(Convert.ToInt32(cboYear.Value), 1, 1, 0, 0, 0, 0);
            } else
            {
                yearCalendar.MinDate = new System.DateTime(Convert.ToInt32(cboYear.Value), 1, 1, 0, 0, 0, 0);
                yearCalendar.MaxDate = new System.DateTime(Convert.ToInt32(cboYear.Value), 12, 31, 23, 59, 59, 100);
            }

            LoadCalendar();
            chkWeekEnds.CheckState = CheckState.Indeterminate;
        }

        private void LoadCalendar()
        {
            yearCalendar.RemoveAllBoldedDates();
            using (var dates = new StaticRS($"Select DIA from general..calendario_laboral where year(DIA)='{cboYear.Text}' and COD3='{cboCOD3.Text}'", conn))
            {
                dates.Open();
                dates.ToList().ForEach(r =>
                {
                    DateTime elDia = (DateTime)r["DIA"];
                    yearCalendar.AddBoldedDate(elDia);
                });
            };

        }



        private async void ChkWeekEnds_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            DateTime day = yearCalendar.MinDate;
            while (day <= yearCalendar.MaxDate)
            {
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (chkWeekEnds.Checked)
                    {
                        await yearCalendar.MiAddBoldedDate(day, cboCOD3.Text, conn);
                    }
                    else if (!chkWeekEnds.Checked) //tristate
                    {
                        await yearCalendar.MiRemoveBoldedDate(day, cboCOD3.Text, conn);
                    }
                }
                day = day.AddDays(day.DayOfWeek == DayOfWeek.Sunday ? 5 : 1);
            }
            yearCalendar.UpdateBoldedDates();
            Cursor = Cursors.Default;
        }
    }
}
