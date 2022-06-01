using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ConsoleTools
{
    public static class cMiscTools
    {
        public static string RunningOS
        {
            get
            {
                if (Environment.OSVersion.ToString().Contains("Windows"))
                    return "Windows";
                //if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                //    return "Linux";
                return "Other";
            }
        }

    }
}
