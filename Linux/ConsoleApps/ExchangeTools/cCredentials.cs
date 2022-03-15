using System;
using System.Collections.Generic;
using System.Text;


    public class cCredentials:IDisposable
    {
        public string Server;
        public string User;
        public string Password;
        public string DB;

        public cCredentials(string server, string user, string password, string db)
        {
            Server = server;
            User = user;
            Password = password;
            DB = db;
        }

        public void Dispose()
        {

        }
    }

