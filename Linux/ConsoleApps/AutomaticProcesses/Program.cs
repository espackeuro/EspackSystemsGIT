using System;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
            string _myName = System.Reflection.Assembly.GetCallingAssembly().GetName().Name;
            string _currentArgName, _currentArgValue;

            string _DBuser = "", _DBpassword = "", _DBServer = "", _DBdataBase = "";
            string _mailServer = "", _mailUser = "", _mailPassword = "";
            Nullable<int> _DBtimeOut = null, _processQuery = null, _processSubQuery = null, _fontsize = 11;
            string _processQueryParams = "", _processMailTo = "", _processMailSubject = "", _processMailErrorTo = "";
            bool _noBand = false, _noEmpty = false, _noExecDate = false;
            string _result = "", _fileName = "", _emptyMessage = "", _copyTo = "";
            
            cConnDetails _connDetailsDB = null;
            cConnDetails _connDetailsMail = null;
            Dictionary <int,cProcess> _procList = null;
            List<Task> _taskList = null;
            
            try
            {
                Console.WriteLine($"----==== Starting [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");

                Console.Write("> Loading settings file... ");

                // If the settings file exists, the params will be loaded from it
                _stage = "Loading settings file";
                string[] _lines = File.ReadAllLines((pDebug ? Directory.GetCurrentDirectory().Substring(0, 3)+ "C# Apps Settings\\" : $"/media/bin/{_myName}/") + $"{_myName}.settings", Encoding.Unicode);

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
                            if (!String.IsNullOrEmpty(_currentArgValue)) _DBtimeOut = Convert.ToInt32(_currentArgValue);
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
                        case "FONTSIZE":
                            if (!String.IsNullOrEmpty(_currentArgValue)) _fontsize = Convert.ToInt32(_currentArgValue);
                            break;
                        case "NOBAND":
                            _noBand = true;
                            break;
                        case "NOEMPTY":
                            _noEmpty = true;
                            break;
                        case "EMPTYMESSAGE":
                            _emptyMessage = _currentArgValue;
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
                        case "NOEXECUTIONDATE":
                            _noExecDate = true;
                            break;
                        case "COPYTO":
                            _copyTo = _currentArgValue;
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
                if (String.IsNullOrEmpty(_fileName) && !String.IsNullOrEmpty(_copyTo))
                    throw new Exception($"You must set a filename for storing the file: FILENAME=<FileName>");
                if (!String.IsNullOrEmpty(_mailServer) || !String.IsNullOrEmpty(_mailUser) || !String.IsNullOrEmpty(_mailPassword))
                {
                    if (String.IsNullOrEmpty(_mailServer) || String.IsNullOrEmpty(_mailUser) || String.IsNullOrEmpty(_mailPassword))
                        throw new Exception($"All email connection details are required when one of them is specified: MAIL_SERVER, MAIL_USER & MAIL_PASSWORD");
                    if ((String.IsNullOrEmpty(_processMailTo) || String.IsNullOrEmpty(_processMailSubject) || String.IsNullOrEmpty(_processMailErrorTo)) && String.IsNullOrEmpty(_copyTo))
                        throw new Exception($"You have to define a email address or a copy destination for the generated file.");
                }
                if (!String.IsNullOrEmpty(_processMailTo) || !String.IsNullOrEmpty(_processMailSubject) || !String.IsNullOrEmpty(_processMailErrorTo))
                {
                    if (String.IsNullOrEmpty(_mailServer) || String.IsNullOrEmpty(_mailUser) || String.IsNullOrEmpty(_mailPassword))
                        throw new Exception($"All email connection details are required when recipient or subject are specified: MAIL_SERVER, MAIL_USER & MAIL_PASSWORD");
                    if (String.IsNullOrEmpty(_processMailErrorTo))
                        throw new Exception($"Error email address is required: ERR_TO=<EmailAddress1,EmailAddress2,...>");
                }

                //
                Console.WriteLine("OK!");
                Console.WriteLine($"> Server: {_DBServer}, Query: {_processQuery}, Params: "+(String.IsNullOrEmpty(_processQueryParams)?"NONE":_processQueryParams)+$", Title: {_processMailSubject}, Font Size: {_fontsize} ");

                //
                _stage = "Defining credentials";
                _connDetailsDB = new cConnDetails(_DBServer, _DBuser, _DBpassword, _DBdataBase, _DBtimeOut);
                _connDetailsMail = new cConnDetails(_mailServer, _mailUser, _mailPassword);
                
                // When the main process has a subquery, a list of processes will be generated from its results
                _stage = "Creating process/es";
                _procList = new Dictionary<int,cProcess>();
                _taskList = new List<Task>();
                cProcess _cp = new cProcess(_connDetailsDB, _connDetailsMail, _processQuery, _processQueryParams, _processMailSubject, _processMailTo, _processMailErrorTo, _processSubQuery, _emptyMessage, _noBand, _noExecDate, _noEmpty, _fileName, _fileType, _orientation, _fontsize, _copyTo);
                cProcess _cpSub = null;
                Console.Write($"> Executing {(_processSubQuery!=null?"parent":"")} process (TimeOut is {_connDetailsDB.TimeOut})... ");
                
                // Only when the SubQuery is set
                if (_processSubQuery != null)
                {
                    //
                    _stage = "Executing parent process";
                    var _task = _cp.Process();
                    if (_cp.Error)
                        throw new Exception(_cp.ErrorMessage);

                    //
                    _stage = "Looping through results";
                    foreach (var _currentRow in _cp.Results)
                    {

                        // Init the params for current subprocess
                        _processQueryParams = "";

                        // Go for each field
                        foreach (var _field in _currentRow.Value)
                        {
                            // Add the parameter for the subquery, except for 
                            if (_field.Key.ToUpper() != "MAILSUBJECT" && _field.Key.ToUpper() != "MAILTO")
                                _processQueryParams += $"{_field.Value} ";
                        }
                        _processQueryParams = _processQueryParams.Trim();

                        //
                        _stage = "Creating new subprocess";
                        _cpSub = new cProcess(_connDetailsDB, _connDetailsMail, _processSubQuery, _processQueryParams, _currentRow.Value.ContainsKey("MAILSUBJECT") ? _currentRow.Value["MAILSUBJECT"] : _processMailSubject, _currentRow.Value.ContainsKey("MAILTO") ? _currentRow.Value["MAILTO"] : _processMailTo, _processMailErrorTo, null, _emptyMessage, _noBand, _noExecDate, _noEmpty);

                        //
                        _stage = "Adding task for subprocess execution";
                        _taskList.Add(Task.Run(() => _cpSub.Process()));
                        _procList.Add(_taskList.Last().Id, _cpSub);
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    // Adding single process
                    _stage = "Adding task for process execution";
                    _taskList.Add(Task.Run(() => _cp.Process()));
                    _procList.Add(_taskList.Last().Id, _cp);
                }

                //
                _stage = "Waiting for tasks to finish";
                Console.Write($"> Executed {_procList.Count} process{(_procList.Count > 1 ? "es" : "")} (TimeOut is {_connDetailsDB.TimeOut})... ");
                WaitForTasks(_taskList,_procList,_connDetailsMail,_noEmpty).Wait();
                
                //
                Console.WriteLine("OK!");
            }
            catch (Exception ex)
            {
                _result = $"[Main#{_stage}] {ex.Message}";
                Console.WriteLine(_result);
            }
            // End message
            Console.WriteLine($"----==== Ending [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");
        }

        static async Task WaitForTasks(List<Task> taskList,Dictionary<int,cProcess> processList,cConnDetails connDetailsMail,bool noEmpty)
        {
            string _stage = "";
            Task _finished = null;

            while (taskList.Any())
            {
                try
                {
                    //
                    _stage = "Checking task list";
                    _finished = await Task.WhenAny(taskList);

                    //
                    _stage = "Sending email";
                    if (!processList[_finished.Id].NoSend)
                        processList[_finished.Id].SendEmail();

                    //
                    _stage = "Copying file";
                    if (!String.IsNullOrEmpty(processList[_finished.Id].CopyTo))
                        processList[_finished.Id].DoCopy();

                    //
                    _stage = "Removing task";
                    taskList.Remove(_finished);
                    //Console.WriteLine($">>> Removed task {_finished.Id}");
                }
                catch(Exception e)
                {
                    if (_finished!=null)
                        if (!processList[_finished.Id].NoSend)
                            processList[_finished.Id].SendEmail();
                }
            }
        }

    }
}
