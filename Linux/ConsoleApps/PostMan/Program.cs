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
            string _sendTo = "", _subject = "", _carrier = "", _destPath = "";
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
                        _carrier = "TW";
                        break;
                    case "AB3CA":
                        _carrier = "ND";
                        _sendTo = "po_lineas_nd@grupointerpack.com";
                        break;
                    case "V9":
                        _carrier = "V9";
                        break;
                    default:
                        throw new Exception($"File {_fileName} not recognized");
                }

                _subject = $"Informe de líneas {_carrier}";
                _sendTo = "dvalles@espackeuro.com"; // $"po_lineas_{_carrier.ToLower()}@grupointerpack.com";
                _destPath = $"/media/HISTORICOS/Transmisiones/SAP_REPORT_LINEAS_{_carrier}/";

                //
                _stage = "Connecting to email server";
                ExchangeAttachments _email = new ExchangeAttachments();
                if (!_email.Connect("processes", "*seso69*"))
                    throw new Exception("Could not connect to email server.");

                //
                _stage = "Sending email";
                if (!_email.SendEmail(_sendTo, _subject, "", _fileName))
                    throw new Exception("Could not send the email.");

                //
                _stage = "Disconnecting";
                _email.Dispose();

                //
                _stage = "Moving file";
                File.Move(_fileName, $"{_destPath}{DateTime.Now.ToString("yyyyMMdd")}.{Path.GetFileName(_fileName)}");

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
