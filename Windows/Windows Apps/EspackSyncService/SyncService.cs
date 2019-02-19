using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using CommonTools;
//using AccesoDatosNet;
using BaseService;
using ADService;
using ExchangeService;
using System.Collections.ObjectModel;
using System.Data.SqlClient;

namespace EspackSyncService
{



    public partial class SyncServiceClass : ServiceBase
    {
        public SyncServiceClass(string[] args)
        {
            InitializeComponent();
        }

        private List<ISyncedService> SyncedServices = new List<ISyncedService>();
        //private bool IsRunning = false;
        private System.Timers.Timer timer;

        protected override void OnStart(string[] args)
        {
            // Update the service state to Start Pending.  
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
            //Services definition

            Values.Servers.ToList().ForEach(pair =>
            {
                switch (pair.Key)
                {
                    //case "NEXTCLOUD":
                    //    var NCService = new NextCloudService()
                    //    {
                    //        ServiceCredentials = new EspackCredentials()
                    //        {
                    //            User = "system",
                    //            Password = "*seso69*".ToSecureString()
                    //        },
                    //        ServerName = pair.Value
                    //    };
                    //    SyncedServices.Add(NCService);
                    //    EventLog.WriteEntry(string.Format("Added {0} Service to server {1}", pair.Key, pair.Value));
                    //    break;
                    case "DOMAIN":
                        SyncedServices.Add(new ADServiceClass()
                        {
                            ServiceCredentials = new EspackCredentials()
                            {
                                User = "SYSTEMS\\administrador",
                                Password = "Y?D6d#b@".ToSecureString()
                            },
                            ServerName = pair.Value,
                            Flags = Values.FlagsDefs
                        });
                        EventLog.WriteEntry(string.Format("Added {0} Service to server {1}", pair.Key, pair.Value));
                        break;
                    case "EXCHANGE":
                        SyncedServices.Add(new ExchangeServiceClass()
                        {
                            ServiceCredentials = new EspackCredentials()
                            {
                                User = "SYSTEMS\\administrador",
                                Password = "Y?D6d#b@".ToSecureString()
                            },
                            ServerName = pair.Value,
                            Flags = Values.FlagsDefs
                        });
                        EventLog.WriteEntry(string.Format("Added {0} Service to server {1}", pair.Key, pair.Value));
                        break;
                }

            });


            // Timer creation
            EventLog.WriteEntry(string.Format("Service Espack Sync Started on database server {0}",Values.DBServer));
            // Set up a timer to trigger every minute.  
            timer = new System.Timers.Timer();
            timer.Interval = Values.PollingTime * 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            //await Synchronize();

            // Update the service state to Running.  
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }


        private async Task Synchronize()
        {
            var prevState = Values.conn.State;
            if (prevState == ConnectionState.Closed)
            {
                await Values.conn.OpenAsync();
                SqlCommand cmd = Values.conn.CreateCommand();
                string lSql = "set CONTEXT_INFO @C";
                cmd.CommandText = lSql;
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@C";
                param.DbType = DbType.Binary;
                param.Size = 128;
                param.Value = Values.MasterPassword;
                cmd.Parameters.Add(param);
                await cmd.ExecuteNonQueryAsync();
            }
            //using (SqlDataAdapter _sDA = new SqlDataAdapter("select * from Users where UserCode = 'guest' and (GETDATE() >= PasswordEXP or PasswordEXP is null)", Values.conn))
            //{
            //    DataTable T = new DataTable();
            //    _sDA.Fill(T);
            //    var _RS = T.Rows;

            //    if (_RS.Count != 0)
            //    {
            //        //generate new password
            //        var _newPassword = CT.GeneratePassword(8);
            //        //change guest password
            //        using (var _sp = new SqlCommand("pUppUserPassword", Values.conn) { CommandType = CommandType.StoredProcedure })
            //        {
            //            //prevState = Values.conn.State;
            //            //if (prevState == ConnectionState.Closed)
            //            //    await Values.conn.OpenAsync();
            //            SqlCommandBuilder.DeriveParameters(_sp);
            //            _sp.Parameters["@msg"].Value = "";
            //            _sp.Parameters["@UserCode"].Value = "guest";
            //            _sp.Parameters["@Password"].Value = _newPassword;
            //            _sp.Parameters["@PIN"].Value = "0000";
            //            int _error = 0;
            //            try
            //            {
            //                await _sp.ExecuteNonQueryAsync();
            //            }
            //            catch (Exception ex)
            //            {
            //                EventLog.WriteEntry(string.Format("Error updating guest password: {0}", ex.Message), EventLogEntryType.Error);
            //                _error = 1;
            //            }
            //            if (_error == 0 && _sp.Parameters["@msg"].Value.ToString() != "OK")
            //            {
            //                EventLog.WriteEntry(string.Format("Error updating guest password: {0}", _sp.Parameters["@msg"].Value.ToString()), EventLogEntryType.Error);
            //            }
            //            if (_error == 0 && _sp.Parameters["@msg"].Value.ToString() == "OK")
            //            {
            //                EventLog.WriteEntry("Guest user password changed correctly.");
            //            }
            //        }
            //    }
            //}
            using (var _sDA = new SqlDataAdapter(string.Format("select top 10 UserCode, Name, Surname1,Password,Position, MainCOD3, emailAddress, localDomain, flags, desCOD3,Area, remaining=(Select count(*) from users where dbo.CheckFlag(flags,'CHANGED')=1)  from vUsers where dbo.CheckFlag(flags,'CHANGED')=1 order by Surname1 desc"), Values.conn))
            {
                using (DataTable T = new DataTable())
                {
                    try
                    {
                        _sDA.Fill(T);
                    }
                    catch (Exception ex)
                    {
                        EventLog.WriteEntry(string.Format("Error accesing database: {0}", ex.Message), EventLogEntryType.Error);
                        return;
                    }
                    var _RS = T.Rows;
                    if (_RS.Count != 0)
                    {
                        Collection<EspackUser> users = new Collection<EspackUser>();
                        foreach (DataRow r in _RS)
                        {
                            //var r = _RS.Rows[0];
                            Collection<string> _flags = r["flags"].ToString().Split('|').ToList().Where(fr => Values.FlagsDefs.Keys.Contains(fr)).ToCollection();
                            //create the user object
                            var _user = new EspackUser()
                            {
                                UserCode = r["UserCode"].ToString(),
                                Name = r["Name"].ToString().ToUpperFirstLetter(),
                                Surname = r["Surname1"].ToString().ToUpperFirstLetter(),
                                Group = "ESPACK_" + r["Position"].ToString(),
                                Password = r["Password"].ToString(),
                                Email = r["emailAddress"].ToString(),
                                Sede = new EspackSede()
                                {
                                    COD3 = r["MainCOD3"].ToString(),
                                    COD3Description = r["desCOD3"].ToString()
                                },
                                Flags = _flags.ToCollection(),
                                Position = r["Position"].ToString(),
                                Area = r["Area"].ToString(),
                                Services = r["flags"].ToString().Split('|').Where(s => SyncedServices.Select(ss => ss.ServiceName).Contains(s)).ToCollection(),
                                LocalDomain = r["localDomain"].ToString()
                            };
                            users.Add(_user);
                        }
                        foreach (var s in SyncedServices)
                        {
                            var _userServices = users.Where(u => u.Services.Contains(s.ServiceName));
                            if (_userServices.Count() != 0)
                            {
                                foreach (var _user in _userServices)
                                {

                                    //_flags.Remove(s.ServiceName);
                                    //define the alias list
                                    var _alias = Values.DomainList.Select(d => string.Format("'smtp:{0}@{1}'", _user.UserCode, d));
                                    _user.Aliases = new Collection<string>(_alias.Concat(new string[] { string.Format("'smtp:{0}@{1}'", _user.UserCode, _user.LocalDomain) }).ToCollection());
                                    //get the command list for the user
                                    s.Interact(_user);
                                }
                                //execute the commands for the user list
                                var commandCollection = _userServices.SelectMany(u => u.ServiceCommands).ToCollection();
                                try
                                {
                                    await s.Commit(commandCollection);
                                }
                                catch (Exception ex)
                                {
                                    EventLog.WriteEntry(string.Format("Error interacting users {0}.", ex.Message), EventLogEntryType.Error);
                                }

                                foreach (var _user in _userServices)
                                {
                                    await _user.DoFlags(Values.conn);
                                    var errorMessages = _user.ServiceCommands.Select(c => c.Result).Where(o => o != "OK");
                                    var errorMessage = string.Join("· ", errorMessages);
                                    if (errorMessages.Count() == 0)
                                        EventLog.WriteEntry(string.Format("User {0} from {1} was modified correctly in service {2}", _user.UserCode, _user.Sede.COD3, s.ServiceName));
                                    else
                                        EventLog.WriteEntry(string.Format("User {0} from {1} was NOT modified correctly in service {2}. \nError message was {3}", _user.UserCode, _user.Sede.COD3, s.ServiceName, errorMessage), EventLogEntryType.Error);
                                    _user.ServiceCommands.Clear();
                                }
                            }
                        }
                    }
                }
            }
            



            //now lets sync the groups
            //Values.gDatos.DataBase = "MAIL";
            //Values.gDatos.Connect();
            using (var _sDA = new SqlDataAdapter("Select top 10 local_part,address,flags from mail..aliasCAB where dbo.CheckFlag(flags,'CHANGED')=1 and local_part!='' order by address", Values.conn))
            {
                DataTable T = new DataTable();
                _sDA.SelectCommand.CommandTimeout = 300;
                try
                {
                    _sDA.Fill(T);
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry(string.Format("Error accesing database {0}", ex.Message), EventLogEntryType.Error);
                    return;
                }
                var _RS = T.Rows;
                Collection<EspackGroup> groups = new Collection<EspackGroup>();
                foreach (DataRow r in _RS)
                //_RS.ToList().ForEach(async r =>
                {
                    var _flags = r["flags"].ToString().Split('|');
                    //lets get the group members
                    //using (var _aliases = new SqlDataAdapter(string.Format("select * from MAIL.dbo.fExpandAlias('{0}') where gotoAddress not in (select gotoAddress from MAIL.dbo.fExpandAliasExceptions('{0}'))", r["address"].ToString()), Values.conn))
                    //using (var _aliases = new SqlDataAdapter(string.Format("EXEC Mail..pExpandAlias '{0}'", r["address"].ToString()), Values.conn))
                    using (var _aliases = new SqlCommand("MAil..pExpandAlias", Values.conn) { CommandType = CommandType.StoredProcedure })
                    {
                        _aliases.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = "@address",
                            DbType = DbType.String,
                            Value = r["address"].ToString()
                        });
                        var tAliases = new DataTable();
                        try
                        {
                            tAliases.Load(await _aliases.ExecuteReaderAsync());
                            //_aliases.Fill(tAliases);
                        }
                        catch (Exception ex)
                        {
                            EventLog.WriteEntry(string.Format("Error accesing database {0}", ex.Message), EventLogEntryType.Error);
                            return;
                        }
                        var _alList = tAliases.Rows.OfType<DataRow>().Select(a => string.Format("{0}@{1}", a["local_part_goto"], CleanDomain(a["domain_goto"].ToString()))).ToArray();
                        //create the group object
                        var _group = new EspackGroup()
                        {
                            GroupCode = r["local_part"].ToString() != "" ? r["local_part"].ToString() : r["address"].ToString().Replace('@', '_').ToUpper(),
                            GroupMail = r["address"].ToString(),
                            GroupMembers = _alList
                        };
                        foreach (var s in SyncedServices)
                        {
                            if (_flags.Contains(s.ServiceName))
                            {
                                s.InteractGroup(_group);
                                groups.Add(_group);
                            }
                            var commandCollection = groups.SelectMany(u => u.ServiceCommands).ToCollection();
                            try
                            {
                                await s.Commit(commandCollection);
                            }
                            catch (Exception ex)
                            {
                                EventLog.WriteEntry(string.Format("Error interacting groups {0}.", ex.Message), EventLogEntryType.Error);
                            }
                            foreach (var group in groups)
                            {
                                await group.DoFlags(Values.conn);
                                var errorMessages = group.ServiceCommands.Select(c => c.Result).Where(o => o != "OK");
                                var errorMessage = string.Join("· ", errorMessages);
                                if (errorMessages.Count() == 0)
                                    EventLog.WriteEntry(string.Format("Group {0} was modified correctly in service {1}", group.GroupCode, s.ServiceName));
                                else
                                    EventLog.WriteEntry(string.Format("Group {0} was NOT modified correctly in service {1}. \nError message was {2}", group.GroupCode, s.ServiceName, errorMessage), EventLogEntryType.Error);
                            }
                        }
                    }
                }
            }
            Values.conn.Close();
        }

        private string CleanDomain(string domain)
        {
            var _dom = domain.Split('.');
            if (_dom.Contains("espackeuro"))
                return "espackeuro.com";
            if (_dom.Contains("grupointerpack") && !_dom.Contains("gapps"))
                return "grupointerpack.com";
            return domain;
        }

        private async void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            await Synchronize();
            timer.Start();
        }

        internal void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.ReadLine();
            this.OnStop();
        }
        protected override void OnStop()
        {
            EventLog.WriteEntry("Service Espack Sync Stopped.");
        }

        protected override void OnContinue()
        {
            EventLog.WriteEntry("In OnContinue.");
        }

        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(IntPtr handle, ref ServiceStatus serviceStatus);
    }



    public enum ServiceState
    {
        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ServiceStatus
    {
        public long dwServiceType;
        public ServiceState dwCurrentState;
        public long dwControlsAccepted;
        public long dwWin32ExitCode;
        public long dwServiceSpecificExitCode;
        public long dwCheckPoint;
        public long dwWaitHint;
    };
}
