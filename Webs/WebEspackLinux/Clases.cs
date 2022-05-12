using System;
using System.Globalization;

namespace WebEspackLinux
{
    public class Clases
    {

        public static void IdiomaCheck(string lengua)
        {
            if (!string.IsNullOrEmpty(lengua)&lengua!="-")
            {                
                CultureInfo.CurrentCulture = new CultureInfo(lengua);
                CultureInfo.CurrentUICulture = new CultureInfo(lengua);
                CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture(lengua);
            }
        }
        public static double ValorPantalla()
        {
            return Console.WindowWidth;
        }
    }
}