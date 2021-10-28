using System;
namespace AdjuntosExchange
{
    class Program
    {
        public static class Parametros
        {
            public static string UserEmail = "datacapture";
            public static string PasswordEmail = "ecexaqa9";
            public static string PathDownload = @"\\10.200.10.141\dropbox\";
            public static string Subject = ""; //"relacion embalajes enviados a Espack dia";
            public static string Extension = "csv";
        }
        static void Main(string[] args)
        {
            string _stage;
            string _currentArgName, _currentArgValue;
            string _user = "", _password = "", _path = "", _subject = "", _filefilter = "", _sender = "";

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
            
            Console.WriteLine(Clase.DownloadFromExchange(_user, _password, _path, _subject, _filefilter));
        }
    }
}