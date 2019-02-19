using CommonTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellControl
{
    public static class Exchange
    {
        public static EspackDomainConnection EC { get; set; } = new EspackDomainConnection();
        public static string Results { get; set; }
        public static string EnableMailbox(string UserCode, string ExchangeDatabase)
        {
            return string.Format(@"if (![bool](Get-Mailbox -Identity '{0}' -ErrorAction SilentlyContinue)) {{Enable-Mailbox -Identity '{0}' -Database '{1}';Enable-Mailbox -Identity '{0}' -Archive -ArchiveDatabase 'Archive';}}", UserCode, ExchangeDatabase);
        }
        public static string EnableGroup(string GroupCode)
        {
            return string.Format(@"if (![bool](Get-DistributionGroup -Identity '{0}' -ErrorAction SilentlyContinue)) {{Enable-DistributionGroup -Identity '{0}';}}", GroupCode);
        }
        public static async Task<bool> Commit(Collection<ServiceCommand> serviceCommands)
        {
            var command = new PowerShellCommand()
            {
                EC = EC
            };
            bool _res;
            try
            {
                _res = await command.InvokeListExchange(serviceCommands);
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return _res;
        }
    }
}
