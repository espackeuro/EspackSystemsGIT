using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using CommonTools;
using System.Data;
namespace BaseService
{
    public class EspackUser
    {
        public string UserCode { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public EspackSede Sede { get; set; }
        public Collection<string> Flags { get; set; } = new Collection<string>();
        public Collection<string> Aliases { get; set; } = new Collection<string>();
        public string Position { get; set; }
        public string Area { get; set; }
        public Collection<ServiceCommand> ServiceCommands { get; set; } = new Collection<ServiceCommand>();
        public async Task<Collection<string>> DoFlags(SqlConnection conn)
        {
            Collection<string> result = new Collection<string>(ServiceCommands.Where(s => s.Result != "OK").Select(s => s.Result).ToList());
            int error = result.Count() != 0 ? 1 : 0;
            var prevStatus = conn.State;
            if (prevStatus == ConnectionState.Closed)
                await conn.OpenAsync();

            string errorMessage = string.Join("· ", result);
            using (SqlCommand sp = new SqlCommand("pUppUserFlagCheckedClear", conn) { CommandType = CommandType.StoredProcedure })
            {
                SqlCommandBuilder.DeriveParameters(sp);
                sp.Parameters["@msg"].Value = "";
                sp.Parameters["@UserCode"].Value = UserCode;
                sp.Parameters["@Error"].Value = error;
                sp.Parameters["@errorMessage"].Value = errorMessage;
                await sp.ExecuteNonQueryAsync();
                if (sp.Parameters["@msg"].Value.ToString() != "OK")
                    result.Add(sp.Parameters["@msg"].Value.ToString());
            }


            return result;

        }
        public Collection<string> Services { get; set; } = new Collection<string>();
        public string LocalDomain { get; set; }
        public string ExchangeDatabase { get; set; }
    }

    public class EspackGroup
    {
        public string GroupCode { get; set; }
        public string GroupMail { get; set; }
        public string[] GroupMembers { get; set; }
        public Collection<ServiceCommand> ServiceCommands { get; set; } = new Collection<ServiceCommand>();
        public async Task<Collection<string>> DoFlags(SqlConnection conn)
        {
            Collection<string> result = new Collection<string>(ServiceCommands.Where(s => s.Result != "OK").Select(s => s.Result).ToList());
            int error = result.Count() != 0 ? 1 : 0;
            var prevStatus = conn.State;
            if (prevStatus == ConnectionState.Closed)
                await conn.OpenAsync();
            using (SqlCommand sp = new SqlCommand("Mail..pUppAliasFlagCheckedClear", conn) { CommandType = CommandType.StoredProcedure })
            {
                SqlCommandBuilder.DeriveParameters(sp);
                sp.Parameters["@msg"].Value = "";
                sp.Parameters["@address"].Value = GroupMail;
                sp.Parameters["@Error"].Value = error;
                await sp.ExecuteNonQueryAsync();
                if (sp.Parameters["@msg"].Value.ToString() != "OK")
                    result.Add(sp.Parameters["@msg"].Value.ToString());
            }


            return result;

        }
    }
    public struct EspackSede
    {
        public string COD3 { get; set; }
        public string COD3Description { get; set; }
    }


    public interface ISyncedService
    {
        EspackCredentials ServiceCredentials { get; set; }
        String ServerName { get; set; }
        string ServiceName { get; }
        Dictionary<string, string> Flags { get; set; }
        //Task<bool> CheckExist(string UserCode);
        bool Interact(EspackUser User);
        bool InteractGroup(EspackGroup Group);
        Task<bool> Commit(Collection<ServiceCommand> ServiceCommands);
        bool Empty { get; set; }
        //string ErrorMessage { get; set; }
    }
}
