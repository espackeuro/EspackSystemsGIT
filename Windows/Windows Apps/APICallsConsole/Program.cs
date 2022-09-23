using System;
using System.Reflection;
using System.Windows.Forms;

namespace APICallsConsole
{
    class Program
    {
        public static fMain fMain { get; set; }


        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fMain = new fMain(args);
            Application.Run(fMain);
        }

    }
}
