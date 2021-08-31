using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using Tamir.SharpSsh.jsch;
using Renci.SshNet;

namespace SFTPConnectSample
{
    class Program
    {
        /*
        static void Main(string[] args)
        {


            string _privateSshKeyPath = @"D://Key//tstprivate2.ppk";

            Sftp sftp = new Sftp("19.70.124.63", "ftpmesp");
            sftp.AddIdentityFile ( _privateSshKeyPath);
            sftp.Connect();
            ArrayList res = sftp.GetFileList(".");
           // sftp.Put(@"D://txtfilesevice.txt", "txtfilesevice.txt");
            sftp.Get("a.xml", @"D://Key//hello.txt");
            ArrayList Newres = sftp.GetFileList(".");
            sftp.Close();
        }
        */
        static void Main(string[] args)
        {

            SftpClient _sftp=null;

            // replaced by args
            string uploadFile = @"D:\prueba.txt";
            string moveDir = @"/sapglobal/interfaces/FOE/TST/outbound/EWM/3PL/PickingOrders/ES12/archive/";
            string uploadDir = @"/sapglobal/interfaces/FOE/TST/outbound/EWM/3PL/PickingOrders/ES12/out/";

            // Try conneciton
            if (!Connect(ref _sftp))
                return;

            Upload(ref _sftp, @"prueba.txt", @"D:\prueba.txt",uploadDir);
            Download(ref _sftp, @"prueba.txt",uploadDir+"prueba.txt", @"D:\down\");
            RemoteMove(ref _sftp, uploadDir + "prueba.txt", moveDir + "prueba.txt");

            _sftp.Disconnect();

        }

        static bool Connect(ref SftpClient sftp)
        {

            // replace by args
            //PrivateKeyFile keyFile = new PrivateKeyFile(@"/etc/ssl/private/sap_ftp/tstprivate2.ppk", "*Rsakey21*");
            PrivateKeyFile _keyFile = new PrivateKeyFile(@"D:\tstprivate2.ppk", "*Rsakey21*");
            var _keyFiles = new[] { _keyFile };
            
            string _userName = "ftpmesp";
            string _serverIP = "19.70.124.63";


            // Try connection
            try
            {
                var methods = new List<AuthenticationMethod>();
                methods.Add(new PrivateKeyAuthenticationMethod(_userName, _keyFiles));
                ConnectionInfo _con = new ConnectionInfo(_serverIP, 22, _userName, methods.ToArray());
                sftp = new SftpClient(_con);
                sftp.Connect();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }

        static bool Upload(ref SftpClient sftp, string FileName,string Source, string TargetDir)
        {
            string _stage="";
            string _file = TargetDir + FileName;

            try
            {
                //
                _stage = "Checkings";
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
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[{_stage}] {ex.Message}");
                return false;
            }
            
            // OK
            return true;
        }
        static bool Download(ref SftpClient sftp, string FileName, string Source, string TargetDir)
        {
            string _stage = "";
            string _file = TargetDir + FileName;

            try
            {
                //
                _stage = "Checkings";
                if (!sftp.Exists(Source))
                    throw new Exception("Source file not found.");
                if (File.Exists(_file))
                    throw new Exception("Target file already exists.");

                //
                _stage = "Downloading file";
                FileStream fs = File.OpenWrite(_file);
                sftp.DownloadFile(Source, fs);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{_stage}] {ex.Message}");
                return false;
            }

            // OK
            return true;
        }

        static bool RemoteMove(ref SftpClient sftp, string Source, string Target)
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
    }
}
