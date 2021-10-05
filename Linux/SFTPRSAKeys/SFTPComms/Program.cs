using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.IO;

namespace SFTPCommsNS
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
            string _fileName = "";
            bool _upload = false;
            string _archiveKey;
            
            string _localArchivePath = "/media/HISTORICOS/Transmisiones/";
            string _file = "";

            SqlConnection _conn = null;
            Dictionary<string, string> _settings = null;
            DocumentClass _doc = null;

            if (!CheckArgs(args, ref _server, ref _profile, ref _upload, ref _fileName))
                return;

            // Connect to DB
            if (!Connect2DB(_server, ref _conn))
                return;

            _doc = new DocumentClass();
            if (_upload)
            {
                if (!_doc.Identify(_conn, _fileName))
                {
                    if (_doc.DocumentID != null)
                    {
                        Console.WriteLine($"File {_fileName} identified as {_doc.DocumentID} with errors. Moving it to ERROR.");
                        System.IO.Directory.CreateDirectory($"{_localArchivePath}ERROR/{_doc.InternalCode}");
                        File.Move(_file, $"{_localArchivePath}ERROR/{System.DateTime.Now.ToString("yyyyMMdd")}.{_doc.InternalCode}/{_fileName}");
                    }
                    else
                    {
                        Console.WriteLine($"File {_fileName} couldn't be identified. Moving it to BASURA.");
                        File.Move(_file, $"{_localArchivePath}BASURA/{_fileName}");
                    }
                    return;
                }


                    return;
            }
            else
            {
                _doc.TransferDirection = TransferDirections.TD_INBOUND;
                _doc.TransferProtocol = TransferProtocols.TP_RSAFTP;
            }

            // Load settings from DB
            if (!LoadSettings(_conn, _profile, _doc, ref _settings))
                return;

            // Close conn
            _conn.Close();

            //
            Console.WriteLine($"-----===== SFTPComms starting execution at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} =====-----");

            using (var _sftp = new SFTPClass())
            {
                try
                {
                    //
                    _stage = $"Connecting to  {_settings["FTPSERVER"]}";
                    if (!_sftp.Connect(_settings["FTPSERVER"], _settings["FTPUSER"], _settings["RSAKEY"], _settings["RSAPASSPHRASE"]))
                        throw new Exception($"Could not connect to server");

                    if (!_upload)
                    {
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
                            catch (Exception ex)
                            {
                                Console.WriteLine($"[{_stage}] {ex.Message}.");
                            }
                        });
                    }
                    else
                    {
                        //
                        _stage = $"Uploading {_doc.} to {_settings["UPLOADFOLDER"]}{_fileName}";
                        if (!_sftp.Upload(_fileName, _sourceFilePath, _settings["UPLOADFOLDER"]))
                            throw new Exception("Could not upload the file");

                        Console.WriteLine($"File {_file} uploaded to {_settings["UPLOADFOLDER"]}.");

                        //
                        if (_settings.ContainsKey("UPLOADPERMISSIONS"))
                        {
                            _stage = $"Changing file permissions to {_settings["UPLOADPERMISSIONS"]}";
                            if (!_sftp.RemoteChangePermissions(_settings["UPLOADFOLDER"] + _fileName, Convert.ToInt16(_settings["UPLOADPERMISSIONS"])))
                                throw new Exception("Could not change");

                            Console.WriteLine($"File {_settings["UPLOADFOLDER"]}{_fileName} permissions changed.");
                        }

                        //

                        _archiveFile = $"{ _settings["ARCHIVEFOLDER"]}{ _internalCode}{_separator}{ System.DateTime.Now.ToString("yyyyMMdd")}.{ _fileName}";
                        _stage = $"Moving {_file} to {_archiveFile}";
                        File.Move(_file, _archiveFile);
                        Console.WriteLine($"File {_file} moved to {_archiveFile}.");

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{_stage}] {ex.Message}.");
                    return;
                }
            }
            Console.WriteLine($"-----===== SFTPComms finishing execution at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} =====-----");
            return;
        }

        // Add separator at the end of a string if it is not there
        private static string ArrangePath(string path, string separator)
        {
            if (path.Substring(path.Length - separator.Length) != separator)
                path = path + separator;

            return path;
        }

        private static bool CheckArgs(string[] args, ref string Server, ref string Profile, ref bool Upload, ref string FileName)
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
                            Console.WriteLine($"\tUPLOAD=<File Name>|DOWNLOAD\t\t- Upload the <File Name> | Download ALL from the folders indicated in the profile.");
                            return false;

                        case "SERVER":
                            Server = _currentArgValue;
                            break;

                        case "PROFILE":
                            Profile = _currentArgValue;
                            break;

                        case "UPLOAD":
                        case "DOWNLOAD":
                            FileName = _currentArgValue;
                            Upload = _currentArgName.ToUpper() == "UPLOAD";
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
        public static bool LoadSettings(SqlConnection Connection, string Profile, DocumentClass document, ref Dictionary<string, string> Settings)
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

                
                if (document.TransferProtocol == TransferProtocols.TP_RSAFTP)
                {
                    Settings.Add("FTPSERVER", _settings.Where(p => p.Value["FLAGS"].Contains("|FTPSERVER|")).Select(p => p.Value["VALUE1"]).First());
                    Settings.Add("FTPUSER", _settings.Where(p => p.Value["FLAGS"].Contains("|FTPUSER|")).Select(p => p.Value["VALUE1"]).First());
                    Settings.Add("RSAKEY", _settings.Where(p => p.Value["FLAGS"].Contains(pDebug ? "|RSAKEY_WIN|" : "|RSAKEY_LIN|")).Select(p => p.Value["VALUE1"]).First());
                    Settings.Add("RSAPASSPHRASE", _settings.Where(p => p.Value["FLAGS"].Contains("|RSAPASSPHRASE|")).Select(p => p.Value["VALUE1"]).First());
                }
                else
                {
                    throw new Exception($"Transfer protocol not supported {document.TransferProtocol}");
                }
                
                //
                _stage = $"Assigning FTP folder settings for {Profile}";
                if (document.TransferDirection == TransferDirections.TD_INBOUND)
                {
                    // Drop folder
                    Settings.Add("DROPFOLDER", ArrangePath(_settings.Where(p => p.Value["FLAGS"].Contains(pDebug ? "|DROP_WIN|" : "|DROP_LIN|")).Select(p => p.Value["VALUE1"]).First(), pDebug ? "\\" : "/"));

                    // Source & archive folders: I am forced to do this in to steps as I can't use ref variables inside a lambda expression
                    // Step 1
                    _folderSettings = new Dictionary<string, string>();
                    _settings.Where(p => p.Value["FLAGS"].Contains("|IN|")).ToList().ForEach(x => { _folderSettings.Add(x.Value["VALUE2"] + "_IN", x.Value["VALUE1"]); });
                    _settings.Where(p => p.Value["FLAGS"].Contains("|ARCHIVE|")).ToList().ForEach(x => { _folderSettings.Add(x.Value["VALUE2"] + "_ARCHIVE", x.Value["VALUE1"]); });
                    // Step 2
                    foreach (var _item in _folderSettings)
                    {
                        Settings.Add(_item.Key, ArrangePath(_item.Value, "/"));
                    }
                }
                else
                {
                    //
                    string _flag = "OUT";
                    try
                    {
                        Settings.Add("UPLOADFOLDER", ArrangePath(_settings.Where(p => p.Value["FLAGS"].Contains("|OUT|") && p.Value["VALUE2"] == document.DocumentID).Select(p => p.Value["VALUE1"]).First(), "/"));
                        _flag = pDebug ? "LOCAL_ARCHIVE_WIN" : "LOCAL_ARCHIVE_LIN";
                        Settings.Add("ARCHIVEFOLDER", ArrangePath(_settings.Where(p => p.Value["FLAGS"].Contains($"|{_flag}|")).Select(p => p.Value["VALUE1"]).First(), pDebug ? "\\" : "/"));
                        _flag = "UPLOADPERMISSIONS";
                        Settings.Add("UPLOADPERMISSIONS", _settings.Where(p => p.Value["FLAGS"].Contains("|UPLOADPERMISSIONS|")).Select(p => p.Value["VALUE1"]).First());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"{_flag} flag for profile {Profile} ({document.DocumentID}) not found");
                    }
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

