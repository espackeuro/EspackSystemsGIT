using System;
using System.Text.RegularExpressions;

namespace ExchangeTools
{
    class Program
    {
        //public static class Parametros
        //{
        //    public static string UserEmail = "datacapture";
        //    public static string PasswordEmail = "ecexaqa9";
        //    public static string PathDownload = @"\\10.200.10.141\dropbox\";
        //    public static string Subject = ""; //"relacion embalajes enviados a Espack dia";
        //    public static string Extension = "csv";
        //}

        private static bool pDebug;

        static void Main(string[] args)
        {
#if DEBUG
            pDebug = true;
#else
            pDebug = false;
#endif
            string _stage;
            string _currentArgName, _currentArgValue;
            string _user = "", _password = "", _path = "", _subject = "", _filefilter = "", _sender = "", _reportTo = "";
            string _separator = pDebug ? "\\" : "/", _result = "";

            // Args
            _stage = "Checking args";
            try
            {
                foreach (string arg in args)
                {
                    // Get the arg name and value
                    _currentArgName = arg.Split('=')[0].ToUpper();
                    if (arg.Split('=').Length == 2)
                        _currentArgValue = arg.Split('=')[1];
                    else if (arg.Split('=').Length > 2)
                        throw new Exception($"Wrong argument: {arg}");
                    else
                        _currentArgValue = "";

                    // Identify arg name
                    switch (_currentArgName.ToUpper())
                    {
                        case "USER":
                            _user = _currentArgValue;
                            break;

                        case "PASSWORD":
                            _password = _currentArgValue;
                            break;

                        case "PATH":
                            _path = _currentArgValue;
                            if (_path.Substring(_path.Length - _separator.Length) != _separator)
                                _path = _path + _separator;
                            break;

                        case "SUBJECT":
                            _subject = _currentArgValue;
                            break;

                        case "FILEFILTER":
                            _filefilter = _currentArgValue;
                            break;

                        case "SENDER":
                            _sender = _currentArgValue;
                            break;

                        case "REPORTTO":
                            _reportTo = _currentArgValue;
                            if (!Regex.IsMatch(_reportTo, @".*@.*\..*"))
                                throw new Exception($"Wrong email address: {_reportTo}");
                            break;

                        default:
                            throw new Exception($"Wrong argument: {_currentArgName}");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[Main#{_stage}] {ex.Message}");
                return;
            }

            Console.WriteLine($"----==== Starting Exchange Attachment Checking Process at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");
            Console.WriteLine($"> Parameters: {String.Join(" ",args) }");

            if (_user == "" || _password == "" || _path == "")
            {
                Console.WriteLine($"> ERROR at {_stage}: USER, PASSWORD and PATH are mandatory.");
            }
            else
            {
                //Console.WriteLine("CACA");
                using (var _exchange = new ExchangeAttachments())
                {
                    try
                    {
                        //
                        _stage = "Creating connection";
                        _exchange.Connect(_user, _password);

                        //
                        _stage = "Looking for matching emails";
                        if (_exchange.DownloadFromExchange(_path, _subject, _filefilter, _sender) && _reportTo != "")
                        {
                            //
                            _stage = "Sending report";
                            _exchange.SendEmail(_reportTo);
                            Console.WriteLine($" -> Report sent to {_reportTo}");
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"> ERROR at {_stage}: {ex.Message}");
                    }
                }
            }
            Console.WriteLine($"----==== Ending Exchange Attachment Checking Process at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");
        }
    }
}