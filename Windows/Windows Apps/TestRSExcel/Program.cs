using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatosNet;
using ExcelExtensions;

namespace TestRSExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            IntToLetters(27);

            using (var _conn = new cAccesoDatosNet("DB01", "SISTEMAS", "sa", "5380"))
            {
                using (var _rs = new StaticRS("select UserCode,Name,Surname1,Surname2,EmailAddress from Users",_conn))
                {
                    _rs.Open();
                    _rs.CreateExcelFile(@"D:\text.xlsx");
                }
            }
        }

        public static string IntToLetters(int value)
        {
            string result = string.Empty;
            while (--value >= 0)
            {
                result = (char)('A' + value % 26) + result;
                value /= 26;
            }
            return result;
        }

    }
}
