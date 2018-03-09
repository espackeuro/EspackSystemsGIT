using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;

namespace logon
{
    public struct LogonDetails
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionServer { get; set; }
        public string FullName { get; set; }
        public string Version { get; set; }
    }
    public static class LogonUser
    {
        public static async Task<LogonDetails> DoLogon(string User, string Password, string Server, string PackageName)
        {
            LogonDetails result = new LogonDetails();
            string _connectionString = string.Format("Server={0};Initial Catalog={1};User Id={2};Password={3};MultipleActiveResultSets=True;Connection Lifetime=3;Max Pool Size=3", Server, "SISTEMAS", "SA", "5380");
            using (SqlConnection gDatos = new SqlConnection(_connectionString))
            {
                try
                {
                    await gDatos.OpenAsync();
                }
                catch (Exception ex)
                {
                    throw ex;//control errores TBD
                }
                using (var sp = new SqlCommand("pLogonUser", gDatos) { CommandType = CommandType.StoredProcedure })
                {
                    SqlCommandBuilder.DeriveParameters(sp);
                    sp.Parameters["@msg"].Value = "";
                    sp.Parameters["@User"].Value = User;
                    sp.Parameters["@Password"].Value = Password;
                    sp.Parameters["@Origin"].Value = PackageName;
                    sp.Parameters["@Version"].Value = "";
                    sp.Parameters["@PackageName"].Value = "";
                    sp.Parameters["@FullName"].Value = "";
                    try
                    {
                        await sp.ExecuteNonQueryAsync();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    if (sp.Parameters["@msg"].Value.ToString() != "OK")
                    {
                        throw new Exception(sp.Parameters["@msg"].Value.ToString());
                    }
                    result.Version = sp.Parameters["@Version"].Value.ToString();
                    result.User = sp.Parameters["@User"].Value.ToString();
                    result.FullName = sp.Parameters["@FullName"].Value.ToString();
                    result.Password = sp.Parameters["@Password"].Value.ToString();
                    return result;
                }

            }

        }
    }
}
