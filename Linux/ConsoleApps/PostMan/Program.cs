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
            string _sendTo="", _subject="";
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
                switch (_fileName.Substring(_fileName.IndexOf("_") + 1))
                {
                    case "DEDMB":
                        _subject = "Informe de líneas TW";
                        _sendTo = "po_lineas_tw@grupointerpack.com";
                        break;
                    case "AB3CA":
                        _subject = "Informe de líneas XPO";
                        _sendTo = "po_lineas_nd@grupointerpack.com";
                        break;
                    case "V9":
                        _subject = "Informe de líneas V9";
                        _sendTo = "po_lineas_v9@grupointerpack.com";
                        break;
                    default:
                        throw new Exception($"File {_fileName} not recognized");
                }

                //
                _stage = "Connecting to email server";
                ExchangeAttachments _email = new ExchangeAttachments();
                _email.Connect("processes", "*seso69*");

                //
                _stage = "Sending email";
                _email.SendEmail(_sendTo, _subject, "", _fileName);

                _stage = "Disconnecting";
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
