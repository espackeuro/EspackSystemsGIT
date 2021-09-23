using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Renci.SshNet;
using System.IO;

namespace SFTPCommsNS
{
    class SFTPClass : IDisposable
    {
        //private bool pDebug;
        private SftpClient pSFtp;
        public string Server;
        public string User;
        public string PrivateKeyPath;
        public string PrivateKeyPassphrase;

#if DEBUG
        private const bool pDebug = true;
#else
        private const bool pDebug = false;
#endif

        public bool Connect(string server = null, string user = null, string privateKeyPath = null, string privateKeyPassphrase = null)
        {
            string _stage = "";

            try
            {
                //
                _stage = "Checkings";
                if (pSFtp != null && pSFtp.IsConnected)
                    throw new Exception($"Already connected to {pSFtp.ConnectionInfo.Host}.");

                // Override current values with the parameter values
                if (server != null)
                    Server = server;
                if (user != null)
                    User = user;
                if (privateKeyPath != null)
                    PrivateKeyPath = privateKeyPath;
                if (privateKeyPassphrase != null)
                    PrivateKeyPassphrase = privateKeyPassphrase;

                //
                if (Server == "")
                    throw new Exception("Server is mandatory.");
                if (User == "")
                    throw new Exception("User is mandatory.");
                if (PrivateKeyPath == "")
                    throw new Exception("Private Key Path is mandatory.");
                if (PrivateKeyPassphrase == "")
                    throw new Exception("Private Key Passphrase is mandatory.");

                //
                _stage = "Preparing private key";
                PrivateKeyFile _keyFile = new PrivateKeyFile(PrivateKeyPath, PrivateKeyPassphrase);
                var _keyFiles = new[] { _keyFile };
                var methods = new List<AuthenticationMethod>();
                methods.Add(new PrivateKeyAuthenticationMethod(User, _keyFiles));

                //
                _stage = "Preparing connection";
                ConnectionInfo _con = new ConnectionInfo(Server, 22, User, methods.ToArray());
                pSFtp = new SftpClient(_con);

                //
                _stage = "Connecting";
                pSFtp.Connect();
                //pSftp.BufferSize = 4 * 1024;
            }
            catch (Exception ex)
            {
                throw new Exception($"[Connect#{_stage}] {ex.Message}");
            }
            return true;

        }

        public bool Download(string fileName, string sourceDir, string targetDir)
        {
            string _stage = "";
            string _sourceFile = sourceDir + fileName;
            string _targetFile = targetDir + fileName;
            string _tmpPath = (pDebug ? Path.GetTempPath() : "/tmp/") + fileName;

            try
            {
                //
                _stage = "Checkings";
                if (!pSFtp.Exists(_sourceFile))
                    throw new Exception("Source file not found");
                if (File.Exists(_targetFile))
                    throw new Exception("Target file already exists");

                //
                _stage = "Reading remote file";
                byte[] _data = pSFtp.ReadAllBytes(_sourceFile);

                //
                _stage = $"Writting data to {_tmpPath}";
                File.WriteAllBytes(_tmpPath, _data);

                //
                _stage = $"Move file from {_tmpPath} to {_targetFile}";
                File.Move(_tmpPath, _targetFile);


            }
            catch (Exception ex)
            {
                throw new Exception($"[Download#{_stage}] {ex.Message}");
            }

            // OK
            return true;
        }

        public bool Upload(string fileName, string sourceDir, string targetDir)
        {
            string _stage = "";
            string _sourceFile = sourceDir + fileName;
            string _targetFile = targetDir + fileName;

            try
            {
                //
                _stage = "Checkings";
                if (!File.Exists(_sourceFile))
                    throw new Exception("Source file not found.");
                if (pSFtp.Exists(_targetFile))
                    throw new Exception("Target file already exists.");

                //
                _stage = "Changing remote directory";
                pSFtp.ChangeDirectory(targetDir);

                //
                _stage = "Uploading file";
                using (FileStream fs = new FileStream(_sourceFile, FileMode.Open))
                {
                    pSFtp.BufferSize = 4 * 1024;
                    pSFtp.UploadFile(fs, Path.GetFileName(_sourceFile));
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"[Upload#{_stage}] {ex.Message}");
            }

            // OK
            return true;
        }

        public bool RemoteChangePermissions(string fileName, short setPermissions)
        {
            string _stage = "";

            //
            _stage = "Changing file permissions";
            try
            {
                pSFtp.ChangePermissions(fileName, setPermissions);
            }
            catch (Exception ex)
            {
                throw new Exception($"[RemoteChangePermissions#{_stage}] {ex.Message}.");
            }
            return true;
        }

        // Move file at the ftp
        public bool RemoteMove(string source, string target)
        {
            string _stage = "";

            try
            {
                //
                _stage = "Checkings";
                if (!pSFtp.Exists(source))
                    throw new Exception("Source file not found.");
                if (pSFtp.Exists(target))
                    throw new Exception("Target file already exists.");

                //
                _stage = "Moving remote file";
                pSFtp.RenameFile(source, target);
            }
            catch (Exception ex)
            {
                throw new Exception($"[RemoteMove#{_stage}] {ex.Message}");
            }

            // OK
            return true;
        }

        // Move file at the ftp
        public bool RemoteDelete(string target)
        {
            string _stage = "";

            try
            {
                //
                _stage = "Checkings";
                if (!pSFtp.Exists(target))
                    throw new Exception("Target file does not found.");

                //
                _stage = "Deleting remote file";
                pSFtp.Delete(target);
            }
            catch (Exception ex)
            {
                throw new Exception($"[RemoteDelete#{_stage}] {ex.Message}");
            }

            // OK
            return true;
        }

        public bool IsConnected()
        {
            string _stage = "";

            //
            _stage = "Checkings";
            try
            {
                return (!(pSFtp == null) && pSFtp.IsConnected);
            }
            catch (Exception ex)
            {
                throw new Exception($"[IsConnected#{_stage}] {ex.Message}");
            }
        }

        // Download all files in a directory (and move them to the archive dir if set)
        public void DownloadFolder(string sourceDir, string targetDir, string archiveDir = null)
        {
            string _stage = "";
            int _count = 0, _total = 0;

            //
            _stage = $"Downloading from {sourceDir}";
            Console.WriteLine($"*** {_stage} ***");


            foreach (var ftpfile in pSFtp.ListDirectory(sourceDir))
            {

                // Skip current iteration for directories (this includes  "." and "..")
                if (ftpfile.IsDirectory)
                    continue;

                try
                {
                    //
                    _stage = $"Downloading {ftpfile.Name}";
                    if (Download(ftpfile.Name, sourceDir, targetDir))
                    {
                        Console.WriteLine($"  -> Download success: {ftpfile.Name}");
                        _count++;

                        if (archiveDir != null)
                        {
                            _stage = "Moving to archive folder";
                            string _archiveFile = archiveDir + ftpfile.Name;

                            if (!pSFtp.Exists(_archiveFile))
                                if (!RemoteMove(sourceDir + ftpfile.Name, _archiveFile))
                                    Console.WriteLine($"Could not move to archive {_archiveFile}.");
                        }

                        // In case there was no archive directory or the previous move command failed (because the target existed yet), we need to delete the source file to avoid duplicate
                        // next captures.
                        _stage = $"Deleting {sourceDir + ftpfile.Name}";
                        if (pSFtp.Exists(sourceDir + ftpfile.Name))
                            if (!RemoteDelete(sourceDir + ftpfile.Name))
                                throw new Exception($"Could not remove file {sourceDir + ftpfile.Name}.");

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[DownloadFolder#{_stage}] {ex.Message}.");
                }
                _total++;
            }
            Console.WriteLine($"  -> Downloaded {_count}/{_total} files.");
            return;
        }

        public void Dispose()
        {
            string _stage = "";

            try
            {
                //
                _stage = "Checkings";
                if (pSFtp != null)
                {
                    if (pSFtp.IsConnected) pSFtp.Disconnect();
                    pSFtp.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"[Dispose#{_stage}] {ex.Message}");
            }
        }

    }
}
