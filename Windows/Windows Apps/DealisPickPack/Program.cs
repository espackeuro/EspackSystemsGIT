﻿using System;
using System.Reflection;
using System.Windows.Forms;
using CommonTools;
using CommonToolsWin;

namespace DealerPickPack
{
    static class Program
    {
        public static fMainDPP fMain { get; set; }
        public static fDeliveries fDeliveries { get; set; }

        public static string VersionNumber
        {
            get
            {
                return string.Format("{0} Build {1} - ({2:yyyyMMdd})*", Values.ProjectName, Assembly.GetExecutingAssembly().GetName().Version.ToString(), CT.GetBuildDateTime(Assembly.GetExecutingAssembly()));
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            new frmSplash(args).ShowDialog();

            fMain = new fMainDPP(args);
            Application.Run(fMain);
        }
    }
}
