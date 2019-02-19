using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerShellControl
{
    public static class Exchange
    {
        public static EspackDomainConnection EC { get; set; } = new EspackDomainConnection();
        public static string Results { get; set; }
        public static async Task<bool> EnableMailbox(string UserCode)
        {
            var command = new PowerShellCommand()
            {
                EC = EC,
                Command = string.Format(@"if (![bool](Get-Mailbox -Identity '{0}' -ErrorAction SilentlyContinue)) {{Enable-Mailbox -Identity '{0}';}}", UserCode)
            };
            var _res = await command.InvokeAsyncExchange();
            Results = command.SResults;
            return _res;
        }
        public static async Task<bool> EnableGroup(string GroupCode)
        {
            var command = new PowerShellCommand()
            {
                EC = EC,
                Command = string.Format(@"if (![bool](Get-DistributionGroup -Identity '{0}' -ErrorAction SilentlyContinue)) {{Enable-DistributionGroup -Identity '{0}';}}", GroupCode)
            };
            var _res = await command.InvokeAsyncExchange();
            Results = command.SResults;
            return _res;
        }
    }
}
