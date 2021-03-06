﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation.Runspaces;
using System.Management.Automation;
using System.Security;
using CommonTools;


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
        public async Task<bool> InvokeAsync()
        {
            try
            {
                using (var runspace = RunspaceFactory.CreateRunspace(EC.WSMan))
                using (var powershell = PowerShell.Create())
                {
                    runspace.Open();
                    powershell.Runspace = runspace;
                    powershell.AddScript(Command);

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
        public async Task<bool> InvokeAsyncExchange()
        {
            //PSSnapInException psException;
            try
            {
                using (var runspace = RunspaceFactory.CreateRunspace(EC.WSManExchange))
                using (var powershell = PowerShell.Create())
                {
                    runspace.Open();
                    powershell.Runspace = runspace;
                    powershell.AddScript(Command);
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
    }

}
