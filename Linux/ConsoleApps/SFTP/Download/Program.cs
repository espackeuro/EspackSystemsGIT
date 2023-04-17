using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace SFTPDownloadNS
{
    class Program
    {
        private static bool pDebug;

        static void Main(string[] args)
        {
#if DEBUG
            pDebug = true;
#else
            pDebug = false;
#endif
            // Declare vars
            string _server = "", _profile = "", _stage = "";
            string _archiveKey;
            SqlConnection _conn = null;
            Dictionary<string, string> _settings = null;

            if (!CheckArgs(args, ref _server, ref _profile))
                return;

            // Connect to DB
            if (!Connect2DB(_server, ref _conn))
                return;

            // Load settings from DB
            if (!LoadSettings(_conn, _profile, ref _settings))
                return;

            // Close conn
            _conn.Close();

            //
            Console.WriteLine($"-----===== SFTPDownload starting execution at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} =====-----");

            using (var _sftp = new SFTPClass())
            {
                try
                {
                    //
                    _stage = $"Connecting to  {_settings["FTPSERVER"]}";
                    if (!_sftp.Connect(_settings["FTPSERVER"], _settings["FTPUSER"], _settings["RSAKEY"], _settings["RSAPASSPHRASE"]))
                        throw new Exception($"Could not connect to server");

                    //
                    _stage = "Getting source folders";
                    if (_settings.Where(p => p.Key.Contains("_IN")).ToList().Count == 0)
                        throw new Exception("Couldn't find any source folders in settings.");

                    _settings.Where(p => p.Key.Contains("_IN")).ToList().ForEach(p =>
                    {
                        _stage = $"Downloading from {p.Key}";
                        //_archiveKey = p.Key.Substring(0, p.Key.Length - 3) + "ARCHIVE";
                        _archiveKey = p.Key[0..^2] + "ARCHIVE";
                        try
                        {
                            _sftp.DownloadFolder(p.Value, _settings["DROPFOLDER"], _settings.ContainsKey(_archiveKey) ? _settings[_archiveKey] : null);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"[{_stage}] {ex.Message}.");
                        }
                    });
                       
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{_stage}] {ex.Message}.");
                    return;
                }
            }
            Console.WriteLine($"-----===== SFTPDownload finishing execution at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} =====-----");
            return;
        }

        // Add separator at the end of a string if it is not there
        private static string ArrangePath(string path, string separator)
        {
            if (path.Substring(path.Length - separator.Length) != separator)
                path = path + separator;

            return path;
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
                            return false;

                        case "SERVER":
                            Server = _currentArgValue;
                            break;

                        case "PROFILE":
                            Profile = _currentArgValue;
                            break;

                        default:
                            throw new Exception($"Wrong argument: {arg}");
                    }
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
        public static bool LoadSettings(SqlConnection Connection, string Profile, ref Dictionary<string, string> Settings)
        {
            string _stage = "";
            Dictionary<string, Dictionary<string, string>> _settings;
            Dictionary<string, string> _folderSettings;

            try
            {
                using (SqlCommand _cmd = new SqlCommand($"select [Key]=codigo,Value1=CMP_varchar,Value2=convert(varchar(max),CMP_Text),flags from datosEmpresa where dbo.checkFlag(flags,'{Profile}')=1", Connection))
                {
                    //
                    _stage = "Executing query";
                    SqlDataReader _rs = _cmd.ExecuteReader();

                    if (!_rs.HasRows)
                        throw new Exception($"Profile {Profile} not found");

                    //                    
                    _settings = new Dictionary<string, Dictionary<string, string>>();

                    //
                    _stage = $"Loading settings for {Profile}";
                    while (_rs.Read())
                    {
                        _settings.Add(_rs["Key"].ToString(), new Dictionary<string, string>());
                        _settings[_rs["Key"].ToString()].Add("VALUE1", _rs["Value1"].ToString());
                        _settings[_rs["Key"].ToString()].Add("VALUE2", _rs["Value2"].ToString());
                        _settings[_rs["Key"].ToString()].Add("FLAGS", _rs["Flags"].ToString());
                    }
                }

                //
                _stage = $"Assigning FTP connection settings for {Profile}";
                Settings = new Dictionary<string, string>();
                Settings.Add("FTPSERVER", _settings.Where(p => p.Value["FLAGS"].Contains("|FTPSERVER|")).Select(p => p.Value["VALUE1"]).First());
                Settings.Add("FTPUSER", _settings.Where(p => p.Value["FLAGS"].Contains("|FTPUSER|")).Select(p => p.Value["VALUE1"]).First());
                Settings.Add("RSAKEY", _settings.Where(p => p.Value["FLAGS"].Contains(pDebug ? "|RSAKEY_WIN|" : "|RSAKEY_LIN|")).Select(p => p.Value["VALUE1"]).First());
                Settings.Add("RSAPASSPHRASE", _settings.Where(p => p.Value["FLAGS"].Contains("|RSAPASSPHRASE|")).Select(p => p.Value["VALUE1"]).First());

                //
                _stage = $"Assigning FTP folder settings for {Profile}";

                // Drop folder
                Settings.Add("DROPFOLDER", ArrangePath(_settings.Where(p => p.Value["FLAGS"].Contains(pDebug ? "|DROP_WIN|" : "|DROP_LIN|")).Select(p => p.Value["VALUE1"]).First(), pDebug ? "\\" : "/"));
                
                // Source & archive folders: I am forced to do this in to steps as I can't use ref variables inside a lambda expression
                // Step 1
                _folderSettings = new Dictionary<string, string>();
                _settings.Where(p => p.Value["FLAGS"].Contains("|IN|")).ToList().ForEach(x => { _folderSettings.Add(x.Value["VALUE2"] + "_IN", x.Value["VALUE1"]); });
                _settings.Where(p => p.Value["FLAGS"].Contains("|ARCHIVE|")).ToList().ForEach(x => { _folderSettings.Add(x.Value["VALUE2"] + "_ARCHIVE", x.Value["VALUE1"]); });
                // Step 2
                foreach(var _item in _folderSettings)
                {
                    Settings.Add(_item.Key, ArrangePath(_item.Value, "/"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LoadSettings#{_stage}] {ex.Message}.");
                return false;
            }

            // OK
            return true;
        }
    }
}
