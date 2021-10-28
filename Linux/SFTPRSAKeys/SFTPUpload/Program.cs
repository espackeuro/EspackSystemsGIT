using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace SFTPUploadNS
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
            string _server = "", _profile = "", _stage = "", _separator = pDebug ? "\\" : "/"; ;
            string _file = "", _idDoc = "", _internalCode = "";
            string _fileName = "", _sourceFilePath = "", _archiveFile = "";
            string _localArchivePath = "/media/HISTORICOS/Transmisiones/";
            SqlConnection _conn = null;
            Dictionary<string, string> _settings = null;

            if (!CheckArgs(args, ref _server, ref _profile, ref _file))
                return;

            // Connect to DB
            if (!Connect2DB(_server, ref _conn))
                return;

            // Get the "pure" name, without path, and the "pure" path, without the file name
            _fileName = Path.GetFileName(_file);
            _sourceFilePath = ArrangePath(Path.GetDirectoryName(_file),_separator);

            //_fileName = Path.GetFileName(Path.GetDirectoryName(_file));

            //
            _stage = "Identifying document";
            if (!IdentifyDocument(_conn, _file, ref _idDoc, ref _internalCode))
            {
                if (_idDoc != null)
                {
                    Console.WriteLine($"File {_fileName} identified as {_idDoc} with errors. Moving it to ERROR.");
                    System.IO.Directory.CreateDirectory($"{_localArchivePath}ERROR/{_internalCode}");
                    File.Move(_file, $"{_localArchivePath}ERROR/{System.DateTime.Now.ToString("yyyyMMdd")}.{_internalCode}/{_fileName}");
                }
                else
                {
                    Console.WriteLine($"File {_fileName} couldn't be identified. Moving it to BASURA.");
                    File.Move(_file, $"{_localArchivePath}BASURA/{_fileName}");
                }
                return;
            }

            // Load settings from DB
            if (!LoadSettings(_conn, _profile, _idDoc, ref _settings))
                return;

            // Close conn
            _conn.Close();

            //
            Console.WriteLine($"-----===== SFTPUpload starting execution at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} =====-----");

            using (var _sftp = new SFTPClass())
            {
                try
                {
                    //
                    bool _done=false;
                    int _attempts = 0;

                    _stage = $"Connecting to  {_settings["FTPSERVER"]}";
                    while (!_done && _attempts < 3)
                    {
                        //
                        if (!_sftp.Connect(_settings["FTPSERVER"], _settings["FTPUSER"], _settings["RSAKEY"], _settings["RSAPASSPHRASE"]))
                        {
                            Console.WriteLine($"-> Try {_attempts + 1}/3 failed. Retrying...");
                            _attempts++;
                            System.Threading.Thread.Sleep(5);
                            continue;
                        }
                        _done = true;
                    }

                    if (!_done)
                        throw new Exception($"Could not connect to server");

                    _done = false;
                    _attempts = 0;

                    //
                    _stage = $"Uploading {_file} to {_settings["UPLOADFOLDER"]}{_fileName}";
                    while (!_done && _attempts < 3)
                    { 
                        if (!_sftp.Upload(_fileName, _sourceFilePath, _settings["UPLOADFOLDER"]))
                        {
                            Console.WriteLine($"-> Try {_attempts+1}/3 failed. Retrying...");
                            _attempts++;
                            System.Threading.Thread.Sleep(5);
                            continue;
                        }
                        _done = true;
                    }

                    if (!_done)
                        throw new Exception("Could not upload the file");

                    Console.WriteLine($"File {_file} uploaded to {_settings["UPLOADFOLDER"]}.");

                    //
                    if (_settings.ContainsKey("UPLOADPERMISSIONS"))
                    {
                        _stage = $"Changing file permissions to {_settings["UPLOADPERMISSIONS"]}"; 
                        if (!_sftp.RemoteChangePermissions(_settings["UPLOADFOLDER"] +_fileName, Convert.ToInt16(_settings["UPLOADPERMISSIONS"])))
                            throw new Exception("Could not perform the change");
                        
                        Console.WriteLine($"File {_settings["UPLOADFOLDER"]}{_fileName} permissions changed.");
                    }

                    //
                   
                    _archiveFile = $"{ _settings["ARCHIVEFOLDER"]}{ _internalCode}{_separator}{ System.DateTime.Now.ToString("yyyyMMdd")}.{ _fileName}";
                    _stage = $"Moving {_file} to {_archiveFile}";
                    File.Move(_file, _archiveFile);
                    Console.WriteLine($"File {_file} moved to {_archiveFile}.");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[{_stage}] {ex.Message}.");
                    return;
                }
            }
            Console.WriteLine($"-----===== SFTPUpload finishing execution at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} =====-----");
            return;
        }

        // Add separator at the end of a string if it is not there
        private static string ArrangePath(string path, string separator)
        {
            if (path.Substring(path.Length - separator.Length) != separator)
                path = path + separator;

            return path;
        }

        private static bool CheckArgs(string[] args, ref string Server, ref string Profile, ref string Filename)
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
                            Console.WriteLine($"\tFILE=<File Name>\t\t- The full path and file name to be uploaded.");
                            return false;

                        case "SERVER":
                            Server = _currentArgValue;
                            break;

                        case "PROFILE":
                            Profile = _currentArgValue;
                            break;

                        case "FILE":
                            Filename = _currentArgValue;
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
                    if (Filename == "")
                        throw new Exception($"Argument FILENAME is missing");
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
        public static bool LoadSettings(SqlConnection Connection, string Profile, string idDoc, ref Dictionary<string, string> Settings)
        {
            string _stage = "", _flag = "";
            Dictionary<string, Dictionary<string, string>> _settings;

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
                try
                {
                    _flag = "FTPSERVER";
                    Settings.Add("FTPSERVER", _settings.Where(p => p.Value["FLAGS"].Contains("|FTPSERVER|")).Select(p => p.Value["VALUE1"]).First());
                    _flag = "FTPUSER";
                    Settings.Add("FTPUSER", _settings.Where(p => p.Value["FLAGS"].Contains("|FTPUSER|")).Select(p => p.Value["VALUE1"]).First());
                    _flag = pDebug ? "RSAKEY_WIN" : "RSAKEY_LIN";
                    Settings.Add("RSAKEY", _settings.Where(p => p.Value["FLAGS"].Contains($"|{_flag}|")).Select(p => p.Value["VALUE1"]).First());
                    _flag = "RSAPASSPHRASE";
                    Settings.Add("RSAPASSPHRASE", _settings.Where(p => p.Value["FLAGS"].Contains("|RSAPASSPHRASE|")).Select(p => p.Value["VALUE1"]).First());
                    _flag = "OUT";
                    Settings.Add("UPLOADFOLDER", ArrangePath(_settings.Where(p => p.Value["FLAGS"].Contains("|OUT|") && p.Value["VALUE2"] == idDoc).Select(p => p.Value["VALUE1"]).First(), "/"));
                    _flag = pDebug ? "LOCAL_ARCHIVE_WIN" : "LOCAL_ARCHIVE_LIN";
                    Settings.Add("ARCHIVEFOLDER", ArrangePath(_settings.Where(p => p.Value["FLAGS"].Contains($"|{_flag}|")).Select(p => p.Value["VALUE1"]).First(), pDebug ? "\\" : "/"));
                    _flag = "UPLOADPERMISSIONS";
                    Settings.Add("UPLOADPERMISSIONS", _settings.Where(p => p.Value["FLAGS"].Contains("|UPLOADPERMISSIONS|")).Select(p => p.Value["VALUE1"]).First());
                }
                catch(Exception ex)
                {
                    throw new Exception($"{_flag} flag for profile {Profile} ({idDoc}) not found");
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

        public static bool IdentifyDocument(SqlConnection connection, string file, ref string idDocument, ref string internalCode)
        {
            string _stage = "";
            bool _found = false;
            string _contents = "";
            string _flags = "";
            string _supplierCode = "";

            try
            {
                //
                _stage = "Reading the file contents";
                _contents = File.ReadAllText(file);

                // 
                _stage = "Getting document definitions";
                // For later updates, this is the query in php process
                // "select idreg,formato,descripcion,identificador,posicion_codigo_doc,longitud_codigo_doc,flags,postproceso,tablas,delimiter,quotes=rtrim(ltrim(quotes)),Subproveedores,posicion_codigo_subprov,longitud_codigo_subprov from documentos where isnull(identificador,'')<>'' /*and dbo.CheckFlag(flags,'OUT')=0*/"
                using (var _cmd = new SqlCommand("select idreg,identificador,posicion_codigo_doc,longitud_codigo_doc,flags from documentos where formato='SAP' and dbo.CheckFlag(flags,'OBS')=0 and dbo.CheckFlag(flags,'OUT')=1", connection))
                {
                    //
                    _stage = "Executing query";
                    SqlDataReader _rs = _cmd.ExecuteReader();
                    if (!_rs.HasRows)
                        throw new Exception($"Document definitions not found");

                    //
                    while (_rs.Read() && !_found)
                    {
                        //
                        idDocument = _rs["idreg"].ToString();
                        _stage = $"Comparing identifier for {idDocument}";
                        _found = Regex.IsMatch(_contents, _rs["identificador"].ToString());

                        //
                        _stage = $"Getting settings from document {idDocument}";
                        _supplierCode = _contents.Substring(Convert.ToInt32(_rs["posicion_codigo_doc"].ToString()), Convert.ToInt32(_rs["longitud_codigo_doc"].ToString()));
                        _flags = _rs["flags"].ToString();
                    }
                    _rs.Close();
                    _rs = null;
                }

                if (_found)
                {
                    //
                    _stage = $"Check flags for document {idDocument}";
                    if (!_flags.Contains("|SFTP|"))
                        throw new Exception($"{idDocument} document not set as SFTP");

                    //
                    _stage = $"Getting internal code for document {idDocument}";
                    using (var _cmd = new SqlCommand($"select codigo_interno from proveedores where (len(codigo_prov) = 0 or dbo.CheckFlag('|' + codigo_prov + '|', '{_supplierCode}') = 1) and documento = '{idDocument}' and dbo.CheckFlag(flags, 'A') = 1", connection))
                    {
                        SqlDataReader _rs = _cmd.ExecuteReader();
                        if (!_rs.HasRows)
                            throw new Exception($"Internal code couldn't be found");

                        //
                        _rs.Read();
                        internalCode = _rs["codigo_interno"].ToString();
                        _rs.Close();
                        _rs = null;
                    }
                }
                else
                {
                    idDocument = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"[IdentifyDocument#{_stage}] {ex.Message}.");
            }

            // OK
            return _found;
        }
    }
}
