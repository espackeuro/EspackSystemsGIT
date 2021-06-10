using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using Tamir.SharpSsh.jsch;
namespace SFTPConnectSample
{
    class Program
    {
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
    }
}
