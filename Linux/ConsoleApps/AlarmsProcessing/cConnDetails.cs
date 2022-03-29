using System;
using System.Collections.Generic;
using System.Text;


public class cConnDetails : IDisposable
{
    public string Server;
    public string User;
    public string Password;
    public string DB;
    public Nullable<int> TimeOut;

    public cConnDetails(string server, string user, string password, string db = null, Nullable<int> timeOut = 60)
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

