using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using Renci.SshNet;

namespace SFTPConnectSample
{
    class Program
    {

        public static bool Debug;

        static void Main(string[] args)
        {
            // Initialize vars
            SftpClient _sftp = null;
            SqlConnection _conn = null;
            Dictionary<string, string> _settings = null;
            string _server = "";
            string _action = "";
            string _profile = "";
            string _sourceDir, _targetDir;

#if DEBUG
            Debug = true;
#else
            Debug=false;
#endif

            // Check the args
            if (!CheckArgs(args, ref _server, ref _action, ref _profile))
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

            // Close conn
            _conn.Close();

            // Try conneciton
            if (!Connect2FTP(ref _sftp, _profile, _settings))
                return;

            //
            switch (_action)
            {
                case "DOWNLOAD":
                    DoDownload(_sftp, _settings);
                    break;
                case "UPLOAD":
                    DoUpload(_sftp, _settings);
                    break;
                default:
                    Console.WriteLine("This should never happen!");
                    break;
            }

            _sftp.Disconnect();

            Console.Write("Press a key to exit...");
            Console.ReadKey();


            // replace by args
            //PrivateKeyFile keyFile = new PrivateKeyFile(@"/etc/ssl/private/sap_ftp/tstprivate2.ppk", "*Rsakey21*");
            //PrivateKeyFile _keyFile = new PrivateKeyFile(@"D:\tstprivate2.ppk", "*Rsakey21*");


            //string _userName = "ftpmesp";
            //string _serverIP = "19.70.124.63";

            // replaced by args

            //string uploadFile = @"D:\prueba.txt";
            //string moveDir = @"/interfacesXI/outbound/EWM/3PL/PickingOrders/ES12/archive/"; //"/sapglobal/interfaces/FOE/TST/outbound/EWM/3PL/PickingOrders/ES12/archive/";
            //string uploadDir = @"/interfacesXI/outbound/EWM/3PL/PickingOrders/ES12/out/"; // "/sapglobal/interfaces/FOE/TST/outbound/EWM/3PL/PickingOrders/ES12/out/";

            /*
            Upload(ref _sftp, @"prueba.txt", @"D:\prueba.txt",uploadDir,777);
            Download(ref _sftp, @"prueba.txt",uploadDir+"prueba.txt", @"D:\down\");
            RemoteMove(ref _sftp, uploadDir + "prueba.txt", moveDir + "prueba.txt");
            */


        }


        private static bool CheckArgs(string[] args, ref string Server, ref string Action, ref string Profile)
        {
            string _stage = "";
            string _currentArgName = "";
            string _currentArgValue = "";
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
                    switch (_currentArgName)
                    {
                        case "HELP":
                            // Show the help
                            Console.WriteLine($"Available arguments:\n\tHELP\t\t\t\t- This text.\n\tSERVER=<DB Server>\t\t- Database server name or IP to access.\n\tACTION=UPLOAD|DOWNLOAD\t\t- Choose the action to be done.");
                            Console.WriteLine($"\tPROFILE=<Profile>\t\t- The code in DB under which the settings are stored.");
                            _help = true;
                            break;

                        case "SERVER":
                            Server = _currentArgValue;
                            break;

                        case "ACTION":
                            Action = _currentArgValue.ToUpper();
                            if (Action != "DOWNLOAD" && Action != "UPLOAD")
                                throw new Exception($"Wrong ACTION {Action}. Allowed values are: UPLOAD and DOWNLOAD");
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
                    if (Action == "")
                        throw new Exception($"Argument ACTION is missing");
                    if (Profile == "")
                        throw new Exception($"Argument PROFILE is missing");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{_stage}] {ex.Message}.\nType HELP in arguments for getting help.\n");
                return false;
            }

            // OK
            return true;
        }

        //static bool Connect2FTP(ref SftpClient sftp,string Server,string User,string KeyFilePath,string KeyPassPhrase)
        static bool Connect2FTP(ref SftpClient sftp, string Profile, Dictionary<string, string> Settings)
        {
            string _stage = "";
            string _ftpServer, _ftpUser, _ftpKeyFilePath, _ftpKeyPassPhrase, _profileFlags;

            // Obtain the FTP connection details from the DB
            try
            {
                //
                _stage = Profile + "FLAG";
                _profileFlags = Settings[_stage];
                if (!_profileFlags.Contains("|RSAKEYS|"))
                    throw new Exception("Flag RSAKEYS not set in profile");

                //
                _stage = Profile;
                _ftpServer = Settings[_stage];
                //
                _stage = Profile + "USR";
                _ftpUser = Settings[_stage];
                //
                _stage = Profile + (Debug ? "_RSAKEYSPATH_WIN" : "_RSAKEYSPATH_LIN");
                _ftpKeyFilePath = Settings[_stage];
                //
                _stage = Profile + "_RSAPASSPHRASE";
                _ftpKeyPassPhrase = Settings[_stage];
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Checking settings] {_stage}: {ex.Message}.");
                return false;
            }

            try
            {
                //
                _stage = "Preparing private key";
                PrivateKeyFile _keyFile = new PrivateKeyFile(_ftpKeyFilePath, _ftpKeyPassPhrase);
                var _keyFiles = new[] { _keyFile };
                var methods = new List<AuthenticationMethod>();
                methods.Add(new PrivateKeyAuthenticationMethod(_ftpUser, _keyFiles));

                //
                _stage = "Preparing connection";
                ConnectionInfo _con = new ConnectionInfo(_ftpServer, 22, _ftpUser, methods.ToArray());
                sftp = new SftpClient(_con);

                //
                _stage = "Connecting";
                sftp.Connect();
                sftp.BufferSize = 4 * 1024;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{_stage}] {ex.Message}.");
                return false;
            }

            // OK
            return true;
        }

        private static bool Upload(ref SftpClient sftp, string FileName, string Source, string TargetDir, short SetPermissions = 0)
        {
            string _stage = "";
            string _file = TargetDir + FileName;

            try
            {
                //
                _stage = "Checkings";
                if (SetPermissions != 0)
                {
                    if (SetPermissions < 700 || SetPermissions > 777)
                        throw new Exception($"Wrong permissions: {SetPermissions}");
                }


                if (!File.Exists(Source))
                    throw new Exception("Source file not found.");
                if (sftp.Exists(_file))
                    throw new Exception("Target file already exists.");

                //
                _stage = "Changing remote directory";
                sftp.ChangeDirectory(TargetDir);

                //
                _stage = "Uploading file";
                using (FileStream fs = new FileStream(Source, FileMode.Open))
                {
                    sftp.BufferSize = 4 * 1024;
                    sftp.UploadFile(fs, Path.GetFileName(Source));
                    if (SetPermissions != 0)
                        sftp.ChangePermissions(_file, SetPermissions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{_stage}] {ex.Message}");
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

        private static bool LoadSettings(SqlConnection Connection, string Profile, ref Dictionary<string, string> Settings)
        {
            string _stage = "";

            try
            {
                using (SqlCommand _cmd = new SqlCommand($"select codigo,CMP_varchar from datosEmpresa where codigo like '{Profile}%'", Connection))
                {
                    //
                    _stage = "Executing query";
                    SqlDataReader _rs = _cmd.ExecuteReader();

                    if (!_rs.HasRows)
                        throw new Exception($"Profile {Profile} not found");

                    //                    
                    Settings = new Dictionary<string, string>();

                    //
                    _stage = $"Loading settings for {Profile}";
                    while (_rs.Read())
                    {
                        Settings.Add(_rs["Codigo"].ToString(), _rs["CMP_Varchar"].ToString()); ;
                        //Console.WriteLine($"Result set: {_rs["Codigo"]}\t- {_rs["CMP_Varchar"]} ");
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

        private static void DoDownload(SftpClient sftp, Dictionary<string, string> Settings)
        {
            string _stage = "";
            string _archiveDir = null;
            string _targetDir = null;
            string _keyDownload = (Debug ? "SAPFTSTDW" : "SAPFTSTDL");

            try
            {
                //
                _stage = "Getting download folder";
                if (!Settings.ContainsKey(_keyDownload))
                    throw new Exception("Couldn't find download folder in settings.");
                _targetDir = Settings[_keyDownload];

                //
                _stage = "Getting source folders";
                var outFolders = Settings.Where(p => p.Key.Substring(p.Key.Length - 2) == "_I");
                if (outFolders.Count()==0)
                    throw new Exception("Couldn't find any source folders in settings.");

                //
                _stage = "Downloading from folders";
                foreach (var p in outFolders)
                {
                    // Obtaining archive folder (if it is set)
                    if (Settings.ContainsKey(p.Key.Substring(0,p.Key.Length - 2) + "_A"))
                        _archiveDir = Settings[p.Key.Substring(0,p.Key.Length - 2) + "_A"];
                    else
                        _archiveDir = null;

                    // Downloading
                    DownloadFolder(sftp, p.Value, _targetDir, _archiveDir);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[{_stage}] {ex.Message}.");
            }

            return;
        }

        // Download all files in a directory (and move them to the archive dir if set)
        private static void DownloadFolder(SftpClient sftp, string SourceDir, string TargetDir, string ArchiveDir = null)
        {
            string _stage = "";
            int _count = 0, _total = 0;

            SourceDir = ArrangePath(SourceDir,"/");
            TargetDir = ArrangePath(TargetDir,"\\");
            if (!(ArchiveDir is null)) ArchiveDir = ArrangePath(ArchiveDir,"/");

            //
            _stage = $"Downloading from {SourceDir}";
            Console.WriteLine($"*** {_stage} ***");


            foreach (var ftpfile in sftp.ListDirectory(SourceDir))
            {

                // Skip current iteration for directories (this includes  "." and "..")
                if (ftpfile.IsDirectory)
                    continue;

                try
                {
                    //
                    _stage = $"Downloading {ftpfile.Name}";
                    if (Download(sftp, ftpfile.Name, SourceDir, TargetDir))
                    {
                        Console.WriteLine($"  -> Download success: {ftpfile.Name}");
                        _count++;

                        //
                        if(!(ArchiveDir is null))
                        {
                            _stage = $"Moving to archive folder";
                            if(!RemoteMove(sftp, SourceDir + ftpfile.Name, ArchiveDir + ftpfile.Name))
                                Console.WriteLine($"[{_stage}] Could not move file to archive folder.");
                        }

                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"[{_stage}] {ex.Message}.");
                }
                _total++;
            }
            Console.WriteLine($"  -> Downloaded {_count}/{_total} files.");
            return;
        }

        // Download a single file
        private static bool Download(SftpClient sftp, string FileName, string SourceDir, string TargetDir)
        {
            string _stage = "";
            string _sourceFile = SourceDir + FileName;
            string _targetFile = TargetDir + FileName;
            string _tmpPath = (Debug ? Path.GetTempPath() : "/tmp/")+FileName;

            try
            {
                //
                _stage = "Checkings";
                if (!sftp.Exists(_sourceFile))
                    throw new Exception("Source file not found.");
                if (File.Exists(_targetFile))
                    throw new Exception("Target file already exists.");

                //
                _stage = "Reading remote file";
                byte[] _data=sftp.ReadAllBytes(_sourceFile);

                //
                _stage = "Writting data to tmp folder";
                File.WriteAllBytes(_tmpPath, _data);

                //
                _stage = "Copying file from tmp folder to download folder";
                File.Copy(_tmpPath, _targetFile);
            }
            catch (Exception ex)
            {
                throw new Exception($"[{_stage}] {ex.Message}");
            }

            // OK
            return true;
        }
        
        // Move file at the ftp
        private static bool RemoteMove(SftpClient sftp, string Source, string Target)
        {
            string _stage = "";

            try
            {
                //
                _stage = "Checkings";
                if (!sftp.Exists(Source))
                    throw new Exception("Source file not found.");
                if (sftp.Exists(Target))
                    throw new Exception("Target file already exists.");

                //
                _stage = "Moving remote file";
                sftp.RenameFile(Source, Target);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{_stage}] {ex.Message}");
                return false;
            }

            // OK
            return true;
        }

        private static void DoUpload(SftpClient sftp, Dictionary<string, string> Settings)
        {
            //_stage = _profile + (_debug ? "DLW" : "DL");
            //_targetDir = _settings[_stage];
            //_archiveDir = _settings[];
            return;
        }

        // Add separator at the end of a string if it is not there
        private static string ArrangePath(string path,string separator)
        {
            if (path.Substring(path.Length - separator.Length) != separator)
                path = path + separator;

            return path;
        }
    }
}


