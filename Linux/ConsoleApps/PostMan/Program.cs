using System;
using System.IO;

namespace PostMan
{
    class Program
    {
        // This variable is for knowing if the app is running in Debug mode or not.
        private static bool pDebug;

        static void Main(string[] args)
        {
#if DEBUG
            pDebug = true;
#else
            pDebug = false;
#endif
            string _myName = System.Reflection.Assembly.GetCallingAssembly().GetName().Name;
            string _stage = "";

            try
            {
                //
                _stage = "Checkings";
                Console.WriteLine($"----==== Starting [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");
                string _fileName = args[0];
                if (_fileName == "")
                    throw new Exception("Missing absolute file path.");
                if (!File.Exists(_fileName))
                    throw new Exception($"File not found: {_fileName}");

                //
                _stage = "Connecting to email server";
                ExchangeAttachments _email = new ExchangeAttachments();
                _email.Connect("procesos@espackeuro.com", "*seso69*");

                //
                _stage = "Sending email";
                _email.SendEmail("dvalles@espackeuro.com", "Test", "Body", _fileName);

                _stage = "Closing connection";
                _email.Dispose();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Main#{_stage}] {ex.Message}");
                Console.WriteLine($"----==== Ending [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");
            }

            Console.WriteLine($"----==== Ending [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");
        }
    }
}
