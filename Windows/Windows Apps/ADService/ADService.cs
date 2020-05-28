using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseService;
using CommonTools;
using System.Diagnostics;
using PowerShellControl;
using System.Collections.ObjectModel;

namespace ADService
{
    public class ADServiceClass : ISyncedService
    {
        public EspackCredentials ServiceCredentials
        {
            get
            {
                return new EspackCredentials()
                {
                    
                    User = AD.EC.UserName,
                    Password = AD.EC.Password.ToSecureString()
                };
            }
            set
            {
                AD.EC.UserName = value.User;
                AD.EC.Password = value.Password.ToUnsecureString();
            }
        }
        public string ServerName { get; set; }
        public Dictionary<string,string> Flags { get; set; }
        public string ServiceName { get { return "DOMAIN"; } }
        public string[] Domains = new string[] { "espackeuro.com", "grupointerpack.com" };
        public bool Empty { get; set; } = false;
        //public async Task<bool> CheckExist(string UserCode)
        //{
        //    return await AD.CheckUser(UserCode);
        //}

        public bool Interact(EspackUser User)
        {
            try {
                AD.EC.ServerName = ServerName;

                if (User.Flags.Contains("DIS"))
                {
                    User.ServiceCommands.Add(new ServiceCommand() { Command = AD.UpdateUser(User.Name, User.Surname, User.UserCode, User.Password, User.Email, User.Sede.COD3, User.Position, User.Area, User.Sede.COD3Description) });
                    User.ServiceCommands.Add(new ServiceCommand() { Command = AD.DisableUser(User.UserCode) });
                    return true;
                }
                // insert or update the user
                User.ServiceCommands.Add(new ServiceCommand() { Command = AD.InteractUser(User.Name, User.Surname, User.UserCode, User.Password, User.Email, User.Sede.COD3, User.Position, User.Area, User.Sede.COD3Description) });
                // create the OU if not exists
                User.ServiceCommands.Add(new ServiceCommand() { Command = AD.CreateOrganizationalUnit(User.Sede.COD3, User.Sede.COD3Description, AD.DefaultPath) });
                // move to the OU if not there
                User.ServiceCommands.Add(new ServiceCommand() { Command = AD.MoveUserToOU(User.UserCode, User.Sede.COD3) });
                // remove from non present flag groups
                foreach (var f in Flags)
                {
                    if (!User.Flags.Contains(f.Key))
                        User.ServiceCommands.Add(new ServiceCommand()
                        {
                            Command = AD.RemoveUserFromGroup(User.UserCode, f.Value, AD.DefaultPath)
                        });
                }
                // add to flag groups
                if (User.Flags != null)
                {
                    foreach (var f in User.Flags)
                    {
                        User.ServiceCommands.Add(new ServiceCommand()
                        {
                            Command = AD.CreateGroup(Flags[f], Flags[f], "Security", AD.DefaultPath)
                        });
                        User.ServiceCommands.Add(new ServiceCommand()
                        {
                            Command = AD.AddUserToGroup(User.UserCode, Flags[f], GroupPath: AD.DefaultPath)
                        });
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

//        public bool InteractGroup(EspackGroup Group)
//        {
//            //moved to exchange
//#if DEBUG
//            Console.WriteLine(Group.GroupCode);
//#endif
//            AD.EC.ServerName = ServerName;
//            try
//            {
//                Group.ServiceCommands.Add(new ServiceCommand()
//                {
//                    Command = AD.CreateGroup(Group.GroupCode, Group.GroupCode, "distribution", AD.DefaultPathAliases, new Dictionary<string, string> { { "mail", Group.GroupMail } })
//                });
//                Group.ServiceCommands.Add(new ServiceCommand()
//                {
//                    Command = AD.CleanGroup(Group.GroupCode)
//                });
//                if (Group.GroupMembers.Count() != 0)
//                {

//                    foreach (var _member in Group.GroupMembers)
//                    {
//                        var _memberName = _member.Split('@')[0];
//                        bool _isContact = false;
//                        //var _path = AD.DefaultPath;
//                        if (!Domains.Contains(_member.Split('@')[1]))
//                        {
//                            _memberName = _member.ToUpper().Replace("@", "_AT_");
//                            Group.ServiceCommands.Add(new ServiceCommand()
//                            {
//                                Command = AD.CreateObject(_memberName, "contact", AD.DefaultPathContacts, new Dictionary<string, string> { { "mail", _member } })
//                            });
//                            _isContact = true;
//                        }
//                        Group.ServiceCommands.Add(new ServiceCommand()
//                        {
//                            Command = AD.AddUserToGroup(_memberName, Group.GroupCode, _isContact)
//                        });
//                    }
//                }

//                return true;
//            }
//            catch (Exception ex)
//            {
//                return false;
//                throw ex;
//            }
//        }
        public async Task<bool> Commit(Collection<ServiceCommand> serviceCommands)
        {
            if (serviceCommands.Count>0)
                return await AD.Commit(serviceCommands);
            return true;
        }

        public bool InteractGroup(EspackGroup Group)
        {
            return true;
        }
    }
}
