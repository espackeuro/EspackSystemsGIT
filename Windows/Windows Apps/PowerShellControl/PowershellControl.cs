using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Security;
using CommonTools;
using System.Collections.ObjectModel;

namespace PowerShellControl
{
    public class EspackDomainConnection
    {
        public string ServerName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public PSCredential Credentials
        {
            get
            {
                return new PSCredential(UserName, Password.ToSecureString());
            }

        }
        public WSManConnectionInfo WSMan
        {
            get
            {
                string shellUri = "http://schemas.microsoft.com/powershell/Microsoft.PowerShell";
                return new WSManConnectionInfo(false, ServerName, 5985, "/wsman", shellUri, Credentials);
            }
        }
        public WSManConnectionInfo WSManExchange
        {
            get
            {
                string shellUri = "http://schemas.microsoft.com/powershell/Microsoft.Exchange";
                var ws = new WSManConnectionInfo(new Uri(string.Format("http://{0}/PowerShell",ServerName)), shellUri, Credentials);
                ws.AuthenticationMechanism = AuthenticationMechanism.Kerberos;
                return ws;
            }
        }
        public static WSManConnectionInfo PowerShellConnectionInformation(string serverUrl, PSCredential psCredentials)
        {
            var connectionInfo = new WSManConnectionInfo(new Uri(serverUrl), "http://schemas.microsoft.com/powershell/Microsoft.Exchange", psCredentials);
            //var connectionInfo = new WSManConnectionInfo(new Uri(serverUrl), "http://schemas.microsoft.com/powershell", psCredentials);
            connectionInfo.AuthenticationMechanism = AuthenticationMechanism.Basic;
            connectionInfo.SkipCACheck = true;
            connectionInfo.SkipCNCheck = true;
            connectionInfo.SkipRevocationCheck = true;
            connectionInfo.MaximumConnectionRedirectionCount = 5;
            connectionInfo.OperationTimeout = 150000;
            return connectionInfo;
        }
    }



    //public class PowerShellExchangeCommand
    public class PowerShellCommand
    {
        public EspackDomainConnection EC { get; set; }
        public string Command { get; set; }
        public PSDataCollection<PSObject> Results { get; private set; }
        public string SResults
        {
            get
            {
                string _res = "";
                Results.Where(o => o != null).ToList().ForEach(output => _res += output + "\n");
                return _res;
            }
        }
        public async Task<bool> InvokeAsync(WSManConnectionInfo ws)
        {
            try
            {
                using (var runspace = RunspaceFactory.CreateRunspace(ws))
                using (var powershell = PowerShell.Create())
                {
                    runspace.Open();
                    powershell.Runspace = runspace;
                    powershell.AddCommand(Command); // [dvalles] 20220601: Change .AddScript -> .AddCommand (AddScript is obsolete)

                    Results = await Task.Factory.FromAsync(powershell.BeginInvoke(), pResult => powershell.EndInvoke(pResult));
                    if (powershell.HadErrors)
                    {
                        throw powershell.Streams.Error[0].Exception;
                    }
                    return true;

                }
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }
        }

        public async Task<bool> InvokeList(Collection<ServiceCommand> commandCollection, WSManConnectionInfo ws)
        {
            try
            {
                using (var runspace = RunspaceFactory.CreateRunspace(ws))
                {
                    runspace.Open();
                    foreach (var command in commandCollection)
                    {

                        using (var powershell = PowerShell.Create())
                        {
                            powershell.Runspace = runspace;
                            //powershell.AddCommand(command.Command); // [dvalles] 20220601: Change .AddScript -> .AddCommand (AddScript is obsolete)
                            if (!command.Command.Contains("Get-Mailbox") && !command.Command.Contains("Get-DistributionGroup"))
                            {

                                powershell.AddScript(command.Command);
                                Results = await Task.Factory.FromAsync(powershell.BeginInvoke(), pResult => powershell.EndInvoke(pResult));
                            }
                            else
                            {
                                powershell.AddCommand(command.Command);
                                powershell.Invoke();
                                //Results = await Task.Factory.FromAsync(powershell.BeginInvoke(), pResult => powershell.EndInvoke(pResult));
                            }

                            if (powershell.HadErrors)
                            {
                                command.Result = powershell.Streams.Error[0].Exception.Message;
                            }
                            else
                                command.Result = "OK";
                        }
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

        public async Task<bool> InvokeListExchange(Collection<ServiceCommand> commandCollection)
        {
            RunspaceConfiguration runspaceConfig = RunspaceConfiguration.Create();
            PSSnapInException snapInException = null;



            try
            {
                using (Runspace runspace = RunspaceFactory.CreateRunspace(runspaceConfig))
                {
                    runspace.Open();
                    Pipeline pipeline = runspace.CreatePipeline();
                    string serverFqdn = "EXCHANGE01";
                    // [dvalles] 20220601: Change .AddScript -> .Add (AddScript is obsolete)
                    pipeline.Commands.Add(string.Format("$Session = New-PSSession -ConfigurationName Microsoft.Exchange -ConnectionUri http://{0}/PowerShell/ -Authentication Kerberos", serverFqdn));
                    var res = pipeline.Invoke();
                    foreach (var command in commandCollection)
                    {

                        using (var powershell = PowerShell.Create())
                        {
                            powershell.Runspace = runspace;
                            // [dvalles] 20220601: Change .AddScript -> .AddCommand (AddScript is obsolete)
                            powershell.AddCommand(string.Format("$Session = New-PSSession -ConfigurationName Microsoft.Exchange -ConnectionUri http://{0}/PowerShell/ -Authentication Kerberos", serverFqdn));
                            powershell.AddCommand(command.Command); // [dvalles] 20220601: Change .AddScript -> .AddCommand (AddScript is obsolete)
                            Results = await Task.Factory.FromAsync(powershell.BeginInvoke(), pResult => powershell.EndInvoke(pResult));
                            if (powershell.HadErrors)
                            {
                                command.Result = powershell.Streams.Error[0].Exception.Message;
                            }
                            else
                                command.Result = "OK";
                        }
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
        //public async Task<bool> InvokeListExchange(Collection<ServiceCommand> commandCollection)
        //{
        //    try
        //    {
        //        using (var runspace = RunspaceFactory.CreateRunspace(EC.WSManExchange))
        //        using (var powershell = PowerShell.Create())
        //        {
        //            runspace.Open();
        //            powershell.Runspace = runspace;
        //            foreach (var command in commandCollection)
        //            {
        //                powershell.AddScript(command.Command);
        //                Results = await Task.Factory.FromAsync(powershell.BeginInvoke(), pResult => powershell.EndInvoke(pResult));
        //                if (powershell.HadErrors)
        //                {
        //                    command.Result = powershell.Streams.Error[0].Exception.Message;
        //                }
        //                else
        //                    command.Result = "OK";
        //            }
        //            return true;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //        throw ex;
        //    }
        //}
        //public async Task<bool> InvokeAsyncExchange()
        //{
        //    //PSSnapInException psException;
        //    try
        //    {
        //        using (var runspace = RunspaceFactory.CreateRunspace(EC.WSManExchange))
        //        using (var powershell = PowerShell.Create())
        //        {
        //            runspace.Open();
        //            powershell.Runspace = runspace;
        //            powershell.AddScript(Command);
        //            Results = await Task.Factory.FromAsync(powershell.BeginInvoke(), pResult => powershell.EndInvoke(pResult));
        //            if (powershell.HadErrors)
        //            {
        //                throw powershell.Streams.Error[0].Exception;
        //            }
        //            return true;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //return false;
        //        throw ex;
        //    }
        //}
    }

}
