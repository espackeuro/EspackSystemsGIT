using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace AutomaticProcesses
{
    class Program
    {
        // This variable is for knowing if the app is running in Debug mode or not.
        private static bool pDebug;

        private static cMiscFunctions.eFileType _fileType;
        private static cMiscFunctions.eOrientation _orientation;

        static void Main(string[] args)
        {
#if DEBUG
            pDebug = true;
#else
            pDebug = false;
#endif
            string _stage = "";
            string _currentArgName, _currentArgValue;
            string _DBuser = "", _DBpassword = "", _DBServer = "", _DBdataBase = "";
            string _mailServer = "", _mailUser = "", _mailPassword = "";
            Nullable<int> _DBtimeOut = null, _processQuery = null, _processSubQuery = null;
            string /*_processQuery = "",*/ _processQueryParams = "", _processMailTo = "", _processMailSubject = "", _processMailErrorTo = "";
            bool _noBand = false, _noEmpty = false, _error = false;
            string _result = "", _fileName = "";
            string _myName = System.Reflection.Assembly.GetCallingAssembly().GetName().Name;
            cConnDetails _connDetailsDB = null;
            cConnDetails _connDetailsMail = null;

            try
            {
                Console.WriteLine($"----==== Starting [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");

                Console.Write("> Loading settings file... ");

                // If the settings file exists, the params will be loaded from it
                _stage = "Loading settings file";
                string[] _lines = File.ReadAllLines((pDebug ? Directory.GetCurrentDirectory().Substring(0, 3) : $"/media/bin/{_myName}/") + $"{_myName}.settings", Encoding.Unicode);

                //
                _stage = "Getting settings from file";
                foreach (string _line in _lines)
                {
                    // Get the arg name and value
                    _currentArgName = _line.Split('=')[0].ToUpper();
                    _currentArgValue = _line.Split('=')[1];

                    // Identify arg name
                    switch (_currentArgName)
                    {
                        case "DB_SERVER":
                            _DBServer = _currentArgValue;
                            break;
                        case "DB_USER":
                            _DBuser = _currentArgValue;
                            break;
                        case "DB_PASSWORD":
                            _DBpassword = _currentArgValue;
                            break;
                        case "DB_DATABASE":
                            _DBdataBase = _currentArgValue;
                            break;
                        case "DB_TIMEOUT":
                            _DBtimeOut = Int32.Parse(_currentArgValue);
                            break;
                        case "MAIL_SERVER":
                            _mailServer = _currentArgValue;
                            break;
                        case "MAIL_USER":
                            _mailUser = _currentArgValue;
                            break;
                        case "MAIL_PASSWORD":
                            _mailPassword = _currentArgValue;
                            break;
                        case "ERR_TO":
                            _processMailErrorTo = _currentArgValue;
                            break;
                        default:
                            throw new Exception($"Wrong argument: {_currentArgName}");
                    }
                }

                //
                Console.Write("OK!\n> Getting settings from args... ");

                // If params are set, some of them can override those loaded from the settings file
                _stage = "Getting settings from args";
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
                        case "DB_SERVER":
                            _DBServer = _currentArgValue;
                            break;
                        case "DB_USER":
                            _DBuser = _currentArgValue;
                            break;
                        case "DB_PASSWORD":
                            _DBpassword = _currentArgValue;
                            break;
                        case "DB_DATABASE":
                            _DBdataBase = _currentArgValue;
                            break;
                        case "DB_TIMEOUT":
                            _DBtimeOut = Int32.Parse(_currentArgValue);
                            break;
                        case "MAIL_SERVER":
                            _mailServer = _currentArgValue;
                            break;
                        case "MAIL_USER":
                            _mailUser = _currentArgValue;
                            break;
                        case "MAIL_PASSWORD":
                            _mailPassword = _currentArgValue;
                            break;
                        case "QUERY":
                            if (!String.IsNullOrEmpty(_currentArgValue)) _processQuery = Convert.ToInt32(_currentArgValue);
                            break;
                        case "PARAMS":
                            _processQueryParams = _currentArgValue;
                            break;
                        case "TO":
                            _processMailTo = _currentArgValue;
                            break;
                        case "SUBJECT":
                            _processMailSubject = _currentArgValue;
                            break;
                        case "NOBAND":
                            _noBand = true;
                            break;
                        case "NOEMPTY":
                            _noEmpty = true;
                            break;
                        case "FILENAME":
                            _fileName = _currentArgValue;
                            break;
                        case "FILETYPE":
                            Enum.TryParse(_currentArgValue, out cMiscFunctions.eFileType _fType);
                            _fileType = _fType;
                            break;
                        case "ORIENTATION":
                            Enum.TryParse(_currentArgValue, out cMiscFunctions.eOrientation _orien);
                            _orientation = _orien;
                            break;
                        case "SUBQUERY":
                            if (!String.IsNullOrEmpty(_currentArgValue)) _processSubQuery = Convert.ToInt32(_currentArgValue);
                            break;
                        case "ERR_TO":
                            _processMailErrorTo = _currentArgValue;
                            break;
                        default:
                            throw new Exception($"Wrong argument: {_currentArgName}");
                    }
                }

                //
                Console.WriteLine("OK!");
                Console.Write("> Checking settings... ");

                // Check mandatory arguments
                _stage = "Checking settings";
                if (_processQuery is null)
                    throw new Exception("Query number is mandatory: QUERY=<QueryNumber>");
                if (String.IsNullOrEmpty(_DBServer))
                    throw new Exception("DB server is mandatory: DB_SERVER=<ServerAddress>");
                if (String.IsNullOrEmpty(_DBuser))
                    throw new Exception("DB user is mandatory: DB_USER=<UserCode>");
                if (String.IsNullOrEmpty(_DBpassword))
                    throw new Exception("DB password is mandatory: DB_USER=<Password>");
                if (String.IsNullOrEmpty(_DBdataBase))
                    throw new Exception("Database is mandatory: DB_DATABASE=<Database>");
                if (String.IsNullOrEmpty(_fileName) && _fileType != cMiscFunctions.eFileType.HTML)
                    throw new Exception($"File name is mandatory for {_fileType} files: FILENAME=<FileName>");
                if (!String.IsNullOrEmpty(_fileName) && _fileType == cMiscFunctions.eFileType.HTML)
                    throw new Exception($"File name can't be used for HTML queries.");
                if (!String.IsNullOrEmpty(_mailServer) || !String.IsNullOrEmpty(_mailUser) || !String.IsNullOrEmpty(_mailPassword))
                {
                    if (String.IsNullOrEmpty(_mailServer) || String.IsNullOrEmpty(_mailUser) || String.IsNullOrEmpty(_mailPassword))
                        throw new Exception($"All email connection details are required when one of them is specified: MAIL_SERVER, MAIL_USER & MAIL_PASSWORD");
                    if (String.IsNullOrEmpty(_processMailTo) || String.IsNullOrEmpty(_processMailSubject) || String.IsNullOrEmpty(_processMailErrorTo))
                        throw new Exception($"For email sending, recipient, error recipient and subject are required: TO=<EmailAddress1,EmailAddress2,...> ERR_TO=<EmailAddress1,EmailAddress2,...> SUBJECT=<Subject>");
                }
                if (!String.IsNullOrEmpty(_processMailTo) || !String.IsNullOrEmpty(_processMailSubject) || !String.IsNullOrEmpty(_processMailErrorTo))
                {
                    if (String.IsNullOrEmpty(_mailServer) || String.IsNullOrEmpty(_mailUser) || String.IsNullOrEmpty(_mailPassword))
                        throw new Exception($"All email connection details are required when recipient or subject are specified: MAIL_SERVER, MAIL_USER & MAIL_PASSWORD");
                    if (String.IsNullOrEmpty(_processMailTo) || String.IsNullOrEmpty(_processMailSubject))
                        throw new Exception($"Both, recipient, error recipient and subject, are required when sending emails: TO=<EmailAddress1,EmailAddress2,...> ERR_TO=<EmailAddress1,EmailAddress2,...> SUBJECT=<Subject>");
                }

                //
                Console.WriteLine("OK!");
                Console.WriteLine($"> Server: {_DBServer}, Query: {_processQuery}, Params: "+(String.IsNullOrEmpty(_processQueryParams)?"NONE":_processQueryParams)+$", Title: {_processMailSubject} ");

                //
                _stage = "Defining credentials";
                _connDetailsDB = new cConnDetails(_DBServer, _DBuser, _DBpassword, _DBdataBase, _DBtimeOut);
                _connDetailsMail = new cConnDetails(_mailServer, _mailUser, _mailPassword);
                //
                _stage = "Creating process";
                cProcess _cp = new cProcess(_connDetailsDB, _processQuery, _processQueryParams, _processMailSubject, _processSubQuery, _noBand, _fileName, _fileType, _orientation);

                //
                Console.Write($"> Executing process (TimeOut is {_connDetailsDB.TimeOut})... ");
                _stage = "Executing process";
                _result = _cp.Process();


                cProcess _csp;

                //
                if (_cp.SubQueryNumber!=null)
                {
                    foreach(var _currentRow in _cp.Results )
                    {

                        // Init the params for current subprocess
                        _processQueryParams = "";
                        _processMailSubject = _currentRow.Value["MAILSUBJECT"];
                        _processMailTo = _currentRow.Value["MAILTO"];

                        // Go for each field
                        foreach (var _field in _currentRow.Value)
                        {
                            // Add the parameter for the subquery, except for 
                            switch (_field.Key.ToUpper())
                            {
                                case "MAILSUBJECT":
                                    _processMailSubject = _field.Value;
                                    break;
                                case "MAILTO":
                                    _processMailTo = _field.Value;
                                    break;
                                default:
                                    _processQueryParams += $"{_field.Key}={_field.Value} ";
                                    break;
                            }
                        }

                        _csp = null;
                        _csp = new cProcess(_connDetailsDB, _processSubQuery, _processQueryParams, _processMailSubject, null, _noBand);
                        _csp.Process();
                    }
                }
                _fileName = _cp.FileName;
                _cp = null;



                //
                Console.WriteLine("OK!");
            }
            catch (Exception ex)
            {
                _result = $"[Main#{_stage}] {ex.Message}";
                Console.WriteLine(_result);
                _error = true;

                // Prepare the _result message for the email.
                _processQueryParams = String.IsNullOrEmpty(_processQueryParams) ? "NONE" : _processQueryParams;
                
                // Match the last occurrence of [xxx#xxx] to ensure it's part of our error message, not part of the system error. This is to show the error message in bold.
                Match _match = Regex.Match(_result, @"\[([^\[]*)#([^\[]*)\]", RegexOptions.RightToLeft);
                int _i = _match.Index+_match.Length;

                // Set to bold the error message, ignoring all the "call stack" string, and prepare the html code.
                _result = _result.Substring(0, _i) + "<ul><strong>" + _result.Substring(_i + 1);
                _result = "<html><body>Query: "+ _processQuery == null ? "NONE" : _processQuery + $"<br>Params: {_processQueryParams}<br>Error:<br>"+ _result.Replace("] ", "]<ul>") +"</strong></body></html>";
            }

            try
            {
                // We send the email if email settings are defined:
                //  - And there was an error
                //  - Or the process worked properly and there are data to show
                //  - Or there are no results, but _noEmpty is false
                if (_connDetailsMail != null && !String.IsNullOrEmpty(_connDetailsMail.Server) && !String.IsNullOrEmpty(_connDetailsMail.User) && !String.IsNullOrEmpty(_connDetailsMail.Password))
                {
                    if (_error || !String.IsNullOrEmpty(_result) || !_noEmpty)
                    {

                        // Send errors to informatica
                        if (_error)
                        {
                            _processMailSubject = "ERROR on " + _processMailSubject;
                            _fileName = null;
                        }

                        //
                        Console.Write("> Sending " + (_error ? "error " : "") + $"email... ");

                        //
                        _stage = "Connecting to email server";
                        ExchangeAttachments _email = new ExchangeAttachments();
                        _email.Connect(_connDetailsMail);

                        //
                        _stage = "Sending email";
                        if (!_email.SendEmail(_error ? _processMailErrorTo : _processMailTo, _processMailSubject + DateTime.Now.ToString(" dd/MM/yyyy"), !String.IsNullOrEmpty(_result) ? _result : "<html><body>No results found / No se encontraron resultados</body></html>", _fileName))
                            throw new Exception("Could not send the email");

                        // 
                        Console.WriteLine("OK!");

                        //
                        _stage = "Disconnecting";
                        _email.Dispose();
                    }
                    else
                    {
                        //
                        Console.WriteLine("> Empty results & NOEMPTY is set... Email skipped.");
                    }
                }
 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Main#{_stage}] {ex.Message}.");
            }

            // End message
            Console.WriteLine($"----==== Ending [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");
        }

    }
}
