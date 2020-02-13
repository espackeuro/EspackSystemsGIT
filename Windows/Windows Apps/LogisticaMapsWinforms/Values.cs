using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticaMapsWinforms
{
    public static class Values
    {
        public static string User { get => "procesos"; }
        public static string Password { get => "*seso69*"; }
        public static string DataBase { get => "LOGISTICA"; }
        public static string DBServer { get; set; } = "DB01B";
        public static SqlConnection Conn { get; set; } = new SqlConnection();
        static Values()
        {
            Conn.ConnectionString = new SqlConnectionStringBuilder()
            {
                InitialCatalog = Values.DataBase,
                UserID = Values.User,
                Password = Values.Password,
                DataSource = Values.DBServer
            }.ConnectionString;
        }
        public static string Session { get => "D800005353"; }
    }
}
