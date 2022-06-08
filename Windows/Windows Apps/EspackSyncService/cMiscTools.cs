using System;
using System.Diagnostics;

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

        public static void RegisterMessage(string message)
        {
            RegisterMessage(message, null);
        }
        public static void RegisterMessage(string message, EventLogEntryType errorType)
        {
            RegisterMessage(message, errorType);
        }
        private static void RegisterMessage(string message, int? errorType=null)
        {

#if !DEBUG  
            EventLog _eLog = new EventLog();
            if (errorType != null)
                _eLog.WriteEntry(message, (EventLogEntryType)errorType);
            else
                _eLog.WriteEntry(message);
            _eLog.Dispose();
#else
            Console.WriteLine(message);
#endif
        }
    }
}
