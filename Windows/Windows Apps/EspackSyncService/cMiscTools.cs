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

        public static void RegisterMessage(EventLog eventLog,string message)
        {
#if !DEBUG  
            eventLog.WriteEntry(message);
#else
            Console.WriteLine(message);
#endif
        }
        //public static void RegisterMessage(EventLog eventLog,string message, EventLogEntryType? errorType)
        //{
        //    RegisterMessage(eventLog, message, errorType);
        //}
        public static void RegisterMessage(EventLog eventLog,string message, EventLogEntryType errorType)
        {

#if !DEBUG  
            eventLog.WriteEntry(message, errorType);
#else
            Console.WriteLine(message);
#endif
        }
    }
}
