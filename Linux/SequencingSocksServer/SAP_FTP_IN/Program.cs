using System;
using System.Collections.Generic;
using System.IO;
using Renci.SshNet;

namespace SAP_FTP_IN
{


    class Program
    {
        static void Main(string[] args)
        {
            var localPath = @"C:\Projects\SshProject\CopyTarget";
            var keyFile = new PrivateKeyFile(@"/etc/ssl/private/sap_ftp/tstprivate2.ppk", "*Rsakey21*");
            var keyFiles = new[] { keyFile };
            var username = "ftpmesp";

            var methods = new List<AuthenticationMethod>();
            //methods.Add(new PasswordAuthenticationMethod(username, ));
            methods.Add(new PrivateKeyAuthenticationMethod(username, keyFiles));

            var con = new ConnectionInfo("19.70.124.63", 22, username, methods.ToArray());
            using (var client = new SftpClient(con))
            {
                client.Connect();

                var files = client.ListDirectory("/");
                foreach (var file in files)
                {
                    Console.WriteLine(file.Name);
                    //using (var fs = new FileStream(localPath + file.Name, FileMode.Create))
                    //{
                    //    client.DownloadFile(file.FullName, fs);
                    //}
                }
            }
        }
    }
}
