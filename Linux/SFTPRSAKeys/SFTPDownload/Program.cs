using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace SFTPDownloadNS
{
    class Program
    {
        public static bool Debug;

        static void Main(string[] args)
        {
#if DEBUG
            Debug = true;
#else
            Debug = false;
#endif
            // Declare vars
            string _server = "", _profile = "", _stage = "";
            string _ftpAddress, _ftpUser, _ftpRSAKey, _ftpRSAPassphrase;
            SqlConnection _conn = null;
            Dictionary<string, Dictionary<string, string>> _settings = null;

            if (!CheckArgs(args, ref _server, ref _profile))
            {
                Console.ReadLine();
                return;
            }

            // Connect to DB
            if (!Connect2DB(_server, ref _conn))
            {
                Console.ReadLine();
                return;
            }

            // Load settings from DB
            if (!LoadSettings(_conn, _profile, ref _settings))
            {
                Console.ReadLine();
                return;
            }

            //
            _ftpAddress = _settings.Where(p => p.Value["FLAGS"].Contains("|FTPSERVER|")).Select(p => p.Value["VALUE"]).First();
            _ftpUser = _settings.Where(p => p.Value["FLAGS"].Contains("|FTPUSER|")).Select(p => p.Value["VALUE"] ).First();
            _ftpRSAKey = _settings.Where(p => p.Value["FLAGS"].Contains(Debug?"|RSAKEY_WIN|":"|RSAKEY_LIN|")).Select(p => p.Value["VALUE"]).First();
            _ftpRSAPassphrase = _settings.Where(p => p.Value["FLAGS"].Contains("|RSAPASSPHRASE|")).Select(p => p.Value["VALUE"]).First();

            // Close conn
            _conn.Close();



            string _archiveFolder = "/media/HISTORICOS/Transmisiones/";
            string _thrashFolder = _archiveFolder + "BASURA/";
            string _errorFolder = _archiveFolder + "ERROR/";

            using (var _sftp = new SFTPClass())
            {
                try
                {
                    //
                    _stage = $"Connecting to  {_ftpAddress}";
                    if (!_sftp.Connect(_ftpAddress, _ftpUser, _ftpRSAKey, _ftpRSAPassphrase))
                        throw new Exception($"Could not connect to server");

                    //
                    _stage = "Getting source folders";
                    var outFolders = _settings.Where(p => p.Value["FLAGS"].Contains("|OUT|")).Select(p => p.Value["VALUE"]);
                    if (outFolders.Count() == 0)
                        throw new Exception("Couldn't find any source folders in settings.");

                    //
                    _stage = $"Downloading from {_settings["SOURCEDIR"]}";
                    //_sftp.DownloadFolder(_settings["SOURCEDIR"], _settings["TARGETDIR"], _settings["ARCHIVEDIR"]);
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{_stage}] {ex.Message}.");
                    return;
                }
            }
        }

        private static bool CheckArgs(string[] args, ref string Server, ref string Profile)
        {
            string _stage;
            string _currentArgName;
            string _currentArgValue;
            bool _help = false;

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
                        case "HELP":
                            // Show the help
                            Console.WriteLine($"Available arguments:\n\tHELP\t\t\t\t- This text.\n\tSERVER=<DB Server>\t\t- Database server name or IP to access data.");
                            Console.WriteLine($"\tPROFILE=<Profile>\t\t- The profile code for getting the settings from DB.");
                            _help = true;
                            break;

                        case "SERVER":
                            Server = _currentArgValue;
                            break;

                        case "PROFILE":
                            Profile = _currentArgValue;
                            break;

                        default:
                            throw new Exception($"Wrong argument: {arg}");
                    }

                    // Exit when the help is shown
                    if (_help)
                        break;
                }

                // If HELP has not been asked for, we check the mandatory values
                if (!_help)
                {
                    if (Server == "")
                        throw new Exception($"Argument SERVER is missing");
                    if (Profile == "")
                        throw new Exception($"Argument PROFILE is missing");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[CheckArgs#{_stage}] {ex.Message}.\nType HELP in arguments for getting help.\n");
                return false;
            }

            // OK
            return true;
        }

        private static bool Connect2DB(string DBServer, ref SqlConnection Connection)
        {
            string _stage = "";
            try
            {
                //
                _stage = "Preparing connection details";
                SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder();
                _builder.DataSource = DBServer;
                _builder.UserID = "procesos";
                _builder.Password = "*seso69*";
                _builder.InitialCatalog = "TRANSMISIONES";

                //
                _stage = "Opening connection";
                Console.WriteLine($"Connecting to DB server {DBServer}...");
                Connection = new SqlConnection(_builder.ConnectionString);
                Connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{_stage}] {ex.Message}.");
                return false;
            }

            // OK
            return true;
        }

        private static bool LoadSettings(SqlConnection Connection, string Profile, ref Dictionary<string, Dictionary<string, string>> Settings)
        {
            string _stage = "";

            try
            {
                using (SqlCommand _cmd = new SqlCommand($"select codigo,CMP_varchar,flags from datosEmpresa where dbo.checkFlag(flags,'{Profile}')=1", Connection))
                {
                    //
                    _stage = "Executing query";
                    SqlDataReader _rs = _cmd.ExecuteReader();

                    if (!_rs.HasRows)
                        throw new Exception($"Profile {Profile} not found");

                    //                    
                    Settings = new Dictionary<string, Dictionary<string, string>>();

                    //
                    _stage = $"Loading settings for {Profile}";
                    while (_rs.Read())
                    {
                        Settings.Add(_rs["Codigo"].ToString(), new Dictionary<string, string>());
                        Settings[_rs["Codigo"].ToString()].Add("VALUE", _rs["CMP_Varchar"].ToString());
                        Settings[_rs["Codigo"].ToString()].Add("FLAGS", _rs["Flags"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{_stage}] {ex.Message}.");
                return false;
            }

            // OK
            return true;
        }
    }
}
