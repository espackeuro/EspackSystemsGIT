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
        public string[] Domains = new string[] { "espackeuro.com", "grupointerpack.com" };
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


#if DEBUG
            Console.WriteLine(Group.GroupCode);
#endif
            try
            {
                Group.ServiceCommands.Add(new ServiceCommand()
                {
                    Command = Exchange.CreateGroup(Group.GroupCode, "distribution", AD.DefaultPathAliases)
                });
                Group.ServiceCommands.Add(new ServiceCommand()
                {
                    Command = Exchange.CleanGroup(Group.GroupCode)
                });
                if (Group.GroupMembers.Count() != 0)
                {

                    foreach (var _member in Group.GroupMembers)
                    {
                        var _memberName = _member.Split('@')[0];
                        //var _path = AD.DefaultPath;
                        if (!Domains.Contains(_member.Split('@')[1]))
                        {
                            _memberName = _member.ToUpper().Replace("@", "_AT_");
                            Group.ServiceCommands.Add(new ServiceCommand()
                            {
                                Command = Exchange.CreateContact(_memberName, _member, AD.DefaultPathContacts)
                            });
                        }
                        Group.ServiceCommands.Add(new ServiceCommand()
                        {
                            Command = Exchange.AddMemberToGroup(_memberName, Group.GroupCode)
                        });
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public async Task<bool> Commit(Collection<ServiceCommand> serviceCommands)
        {
            if (serviceCommands.Count > 0)
                return await Exchange.Commit(serviceCommands);
            return true;
        }
    }
}
