using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading; //import following Namespace first  
using System.Reflection; //import following Namespace first  
using Microsoft.AspNetCore.Builder;
using System.Resources;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Web.UI.MobileControls;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Windows.Controls;

namespace WebEspackeuro
{
    public class Clases
    {
        public static void IdiomaCheck(string lengua)
        { 
                if (!string.IsNullOrEmpty(lengua))
                {
                CultureInfo.CurrentCulture = new CultureInfo(lengua);
                CultureInfo.CurrentUICulture = new CultureInfo(lengua);
                }
        }
        public static double ValorPantalla()
        {
            return Console.WindowWidth;
        }
    }

    public class PostLengua
    {
        public string Lengua { set; get; }
    }
}