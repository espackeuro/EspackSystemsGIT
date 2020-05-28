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
        public static string CreateGroup(string GroupCode, string GroupCategory, string Path) //= "OU=ESPACK,DC=SYSTEMS,DC=espackeuro,DC=com")
        {
            var command = $@"
if (![bool](Get-DistributionGroup -Filter {{Name -eq '{GroupCode}'}}))
{{
New-DistributionGroup -Name '{GroupCode}' -Type '{GroupCategory}' -DisplayName '{GroupCode}' -OrganizationalUnit '{Path}' -RequireSenderAuthenticationEnabled $false
}}
";
            return command;
        }

        public static string CreateContact(string Name, string MailAddress, string OrganizationalUnit)
        {
            return $@"if (![bool](Get-MailContact '{Name}' -ErrorAction SilentlyContinue)) 
{{
    New-MailContact -Name '{Name}' -ExternalEmailAddress '{MailAddress}' -OrganizationalUnit '{OrganizationalUnit}';
}}";

        }

        public static string CleanGroup(string GroupName)
        {
            //return  $@"Get-DistributionGroupMember '{GroupName}' | ForEach-Object {{Remove-DistributionGroupMember -Identity '{GroupName}' -Member $_ -Confirm:$false}}";
            return $@"foreach($member in Get-DistributionGroupMember '{GroupName}') {{Remove-DistributionGroupMember -Identity '{GroupName}' -Member $member -Confirm:$false}}";
        }

        public static string EnableGroup(string GroupCode)
        {
            return string.Format(@"if (![bool](Get-DistributionGroup -Identity '{0}' -ErrorAction SilentlyContinue)) {{Enable-DistributionGroup -Identity '{0}'; Set-DistributionGroup -Identity '{0}' -RequireSenderAuthenticationEnabled $false }};", GroupCode);
        }

        public static string AddMemberToGroup(string MemberName, string GroupCode)
        {
            return $"Add-DistributionGroupMember -Identity '{GroupCode}' -Member '{MemberName}' -Confirm:$false";
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
                _res = await command.InvokeList(serviceCommands,EC.WSManExchange);
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
