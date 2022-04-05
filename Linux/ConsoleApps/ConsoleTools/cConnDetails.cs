using System;

namespace ConsoleTools
{
    public class cConnDetails : IDisposable
    {
        public string Server;
        public string User;
        public string Password;
        public string DB;
        public int? TimeOut;

        public cConnDetails()
        {
        }

        public cConnDetails(string server, string user, string password, string db = null, int? timeOut = 60)
        {
            Server = server;
            User = user;
            Password = password;
            DB = db;
            TimeOut = timeOut;
        }

        public void Dispose()
        {

        }
    }
}