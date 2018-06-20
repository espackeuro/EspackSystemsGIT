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
            string pe;
            string pa;
            pe=IntToLetters(128);

            pa = IntToLettersRec(128);

            using (var _conn = new cAccesoDatosNet("DB01", "SISTEMAS", "sa", "5380"))
            {
                using (var _rs = new StaticRS("select UserCode,Name,Surname1,Surname2,EmailAddress from Users",_conn))
                {
                    _rs.Open();
                    _rs.SaveExcelFile(@"D:\text.xlsx");
                }
            }
        }

        // Do the translation from number base 10 to alpha base 26: 1=A, 2=B, ..., 27=AA, 28=AB, ...
        private static string IntToLettersRec(int value)
        {
            if (value > 0)
            {
                value--;
                return IntToLetters(value / 26) + (char)('A' + value % 26);
            }
            return "";
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
