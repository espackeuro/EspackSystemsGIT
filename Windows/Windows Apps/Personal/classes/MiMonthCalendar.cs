using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatosNet;
namespace Personal
{
    class MiMonthCalendar : MonthCalendar
    {
        public async Task MiAddBoldedDate(DateTime date, string COD3, cAccesoDatosNet conn  ,string description = "")
        {
            using (var sp= new SP(conn,"GENERAL..PAdd_Calendario_Laboral"))
            {
                sp.AddParameterValue("dia", date);
                sp.AddParameterValue("descripcion", description);
                sp.AddParameterValue("COD3", COD3);
                await sp.ExecuteAsync();

            }
            AddBoldedDate(date);
        }
        public async Task MiRemoveBoldedDate(DateTime date, string COD3, cAccesoDatosNet conn)
        {
            using (var sp = new SP(conn, "GENERAL..PDel_Calendario_Laboral"))
            {
                sp.AddParameterValue("dia", date);
                sp.AddParameterValue("COD3", COD3);
                await sp.ExecuteAsync();

            }
            RemoveBoldedDate(date);
        }
    }
}
