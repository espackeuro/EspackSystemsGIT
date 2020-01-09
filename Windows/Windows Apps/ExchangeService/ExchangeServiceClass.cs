using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PowerShellControl;
using BaseService;
using CommonTools;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace ExchangeService
{
    public class ExchangeServiceClass : ISyncedService
    {
        public EspackCredentials ServiceCredentials
        {
            get
            {
                return new EspackCredentials()
                {
                    User = Exchange.EC.UserName,
                    Password = Exchange.EC.Password.ToSecureString()
                };
            }
            set
            {
                Exchange.EC.UserName = value.User;
                Exchange.EC.Password = value.Password.ToUnsecureString();
            }
        }
        public string ServerName { get; set; }
        public Dictionary<string, string> Flags { get; set; }
        public string ServiceName { get { return "EXCHANGE"; } }
        public bool Empty { get; set; } = false;
        //public async Task<bool> CheckExist(string UserCode)
        //{
        //    return await Exchange.CheckUser(UserCode);
        //}



        public bool Interact(EspackUser User)
        {
            Exchange.EC.ServerName = ServerName;
            User.ServiceCommands.Add(new ServiceCommand()
            {
                Command = Exchange.EnableMailbox(User.UserCode, User.ExchangeDatabase)
            });
            return true;
        }

        public bool InteractGroup(EspackGroup Group)
        {
            Exchange.EC.ServerName = ServerName;
            Group.ServiceCommands.Add(new ServiceCommand()
            {
                Command = Exchange.EnableGroup(Group.GroupCode)

            });
            //for the moment we are going to do nothing, after all mails are in exchange we wil cover this part
            return true;
        }

        public async Task<bool> Commit(Collection<ServiceCommand> serviceCommands)
        {
            if (serviceCommands.Count > 0)
                return await Exchange.Commit(serviceCommands);
            return true;
        }
    }
}
