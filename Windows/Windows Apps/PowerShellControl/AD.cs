using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTools;

namespace PowerShellControl
{
    public static class AD
    {
        public static EspackDomainConnection EC { get; set; } = new EspackDomainConnection();
        public const string DefaultPath = "OU=ESPACK,DC=SYSTEMS,DC=espackeuro,DC=com";
        public const string DefaultPathAliases = "CN=Distribution Lists,OU=ESPACK,DC=SYSTEMS,DC=espackeuro,DC=com";
        public const string DefaultPathContacts = "CN=Contacts,OU=ESPACK,DC=SYSTEMS,DC=espackeuro,DC=com";
        public static string Results { get; set; }
        //public static Collection<string> UserCommands { get; set; } = new Collection<string>();
        public static Collection<string> GroupsChanged { get; set; } = new Collection<string>();
        public static string CreateUser(string Name, string Surname, string UserCode, string Password, string EmailAddress, string COD3, string Position, string Area, string Company)
        {
            var division = string.Format("{0}/{1}", EmailAddress.Substring(EmailAddress.IndexOf('@') + 1), UserCode);
            return string.Format(@"if (![bool](Get-ADUser -Identity '{2}' -ErrorAction SilentlyContinue)){{New-ADUser -Name '{0} {1}' -GivenName '{0}' -Surname '{1}' -SamAccountName '{2}' -DisplayName '{0} {1}' -EmailAddress '{4}' -UserPrincipalName '{2}@systems.espackeuro.com' -Division '{5}' -PasswordNeverExpires:$True -AccountPassword (ConvertTo-SecureString -AsPlainText '{3}' -Force) -PassThru -Company '{6}' -Department '{7}' -Organization 'Espack Eurologística' -Title '{8}' | Enable-ADAccount;}}", Name, Surname, UserCode, Password, EmailAddress, division, Company.ToUpperFirstLetter(), Area.ToUpperFirstLetter(), Position.ToUpperFirstLetter());
        }
        public static string DisableUser(string UserCode)
        {
            return string.Format("if ([bool](Get-ADUser -Identity '{0}')){{Disable-ADAccount -Identity {0}}}", UserCode);
        }
        public static string PropertyAdd(string Code, string PropertyName, string PropertyValue, bool CleanFirst)
        {
            string commandString = string.Format("$object = Get-ADObject -LDAPFilter '(SAMAccountName={0})'; ", Code);
            commandString += CleanFirst ? string.Format("Set-ADObject -Identity $object -Clear {0}; ", PropertyName) : "";
            commandString += string.Format("Set-ADObject -Identity $object -Add @{{{0}={1}}}; ", PropertyName, PropertyValue);
            return commandString;//  var _res = await command.InvokeAsync();
        }


        public static string UpdateUser(string Name, string Surname, string UserCode, string Password, string EmailAddress, string COD3, string Position, string Area, string Company)
        {
            var division = string.Format("{1}/{2}", COD3.ToLower(), EmailAddress.Substring(EmailAddress.IndexOf('@') + 1), UserCode);
            return string.Format(@"
Enable-ADAccount -Identity '{0}';
Get-ADUser -Identity '{0}' | Rename-ADObject -NewName '{1} {2}' ;
Get-ADUser -Identity '{0}' | Set-ADUser -DisplayName '{1} {2}' -GivenName '{1}' -Surname '{2}' {4} -Division '{5}' -PasswordNeverExpires:$True -Company '{6}' -Department '{7}' -Organization 'Espack Eurologística' -Title '{8}';
Get-ADUser -Identity '{0}' | Set-ADAccountPassword -Reset -NewPassword (ConvertTo-SecureString -AsPlainText '{3}' –Force);
", UserCode, Name, Surname, Password, EmailAddress != "" ? "-EmailAddress " + EmailAddress : "", division, Company.ToUpperFirstLetter(), Area.ToUpperFirstLetter(), Position.ToUpperFirstLetter());
        }


        public static string InteractUser(string Name, string Surname, string UserCode, string Password, string EmailAddress, string COD3, string Position, string Area, string Company)
        {
            var division = string.Format("{0}/{1}", EmailAddress.Substring(EmailAddress.IndexOf('@') + 1), UserCode);
            return string.Format(@"
if (![bool](Get-ADUser -Filter {{SamAccountName -eq '{0}'}}))
{{
New-ADUser -Name '{1} {2}' -GivenName '{1}' -Surname '{2}' -SamAccountName '{0}' -DisplayName '{1} {2}' {4} -UserPrincipalName '{0}@systems.espackeuro.com' -Division '{5}' -PasswordNeverExpires:$True -AccountPassword (ConvertTo-SecureString -AsPlainText '{3}' -Force) -PassThru -Company '{6}' -Department '{7}' -Organization 'Espack Eurologística' -Title '{8}' | Enable-ADAccount;
}}
else
{{
Enable-ADAccount -Identity '{0}';
Get-ADUser -Identity '{0}' | Rename-ADObject -NewName '{1} {2}' ;
Get-ADUser -Identity '{0}' | Set-ADUser -DisplayName '{1} {2}' -GivenName '{1}' -Surname '{2}' {4} -Division '{5}' -PasswordNeverExpires:$True -Company '{6}' -Department '{7}' -Organization 'Espack Eurologística' -Title '{8}';
Get-ADUser -Identity '{0}' | Set-ADAccountPassword -Reset -NewPassword (ConvertTo-SecureString -AsPlainText '{3}' –Force);
}}

", UserCode, Name, Surname, Password, EmailAddress != "" ? "-EmailAddress " + EmailAddress : "", division, Company.ToUpperFirstLetter(), Area==""?"-": Area.ToUpperFirstLetter(), Position.ToUpperFirstLetter());

        }


        public static string CreateGroup(string GroupCode, string GroupName, string GroupCategory, string Path, Dictionary<string, string> AttributeList = null) //= "OU=ESPACK,DC=SYSTEMS,DC=espackeuro,DC=com")
        {
            var command = string.Format(@"
if (![bool](Get-ADGroup -Filter {{Name -eq '{0}'}}))
{{
New-ADGroup -Name '{1}' -SamAccountName '{0}' -GroupCategory {2} -GroupScope Universal -DisplayName '{1}' -Path '{3}'
}}
", GroupCode, GroupName, GroupCategory, Path);
            if (AttributeList != null)
                command += UpdateObject(GroupCode, "group", Path, AttributeList);

            return command; // _res;
        }



        public static string CreateOrganizationalUnit(string OUCode, string OUDescription, string Path)
        {
            return string.Format(@"
if (![bool](Get-ADOrganizationalUnit -Filter {{Name -eq'{0}'}}))
{{
New-ADOrganizationalUnit -Name '{0}'  -DisplayName '{1}' -Description '{1}' -path '{2}'
}}
", OUCode, OUDescription, Path);
        }


        public static string AddUserToGroup(string UserCode, string GroupCode, bool isContact = false, string GroupPath = DefaultPathAliases)
        {
            return string.Format(@"$dlGroup = [adsi]'LDAP://CN={0},{1}';$dlUser = Get-ADObject -Filter {{{3} -eq '{2}'}};$dlGroup.Member.Add($dlUser.DistinguishedName);$dlGroup.psbase.CommitChanges()", GroupCode, GroupPath, UserCode, isContact ? "Name" : "SamAccountName");
        }

        public static string RemoveUserFromGroup(string UserCode, string GroupCode, string GroupPath = DefaultPathAliases)
        {
            return string.Format(@"Get-ADGroup -LDAPFilter '(SAMAccountName={0})' -SearchBase '{1}' | remove-adgroupmember -Member '{2}'  -Confirm:$false", GroupCode, GroupPath, UserCode);
        }

        public static string MoveUserToOU(string UserCode, string OUCode)
        {
            return string.Format(@"Get-ADUser -Identity '{0}' | Move-ADObject -TargetPath 'OU={1},OU=ESPACK,DC=SYSTEMS,DC=espackeuro,DC=com' ", UserCode, OUCode);
        }

        public static string MoveGroupToOU(string GroupCode, string OUCode)
        {
            return string.Format(@"Get-ADGroup '{0}' | Move-ADObject -TargetPath 'OU={1},OU=ESPACK,DC=SYSTEMS,DC=espackeuro,DC=com' ", GroupCode, OUCode);
        }

        public static string CheckObject(string ObjectName, string ObjectType, string Path = "OU=ESPACK,DC=SYSTEMS,DC=espackeuro,DC=com")
        {
            return string.Format(@"Get-ADObject -Filter {{(Name -eq '{0}') -and (objectClass -eq '{1}')}} -SearchBase '{2}' -SearchScope OneLevel", ObjectName, ObjectType, Path);
        }

        public static string CreateObject(string ObjectName, string ObjectType, string Path = "OU=ESPACK,DC=SYSTEMS,DC=espackeuro,DC=com", Dictionary<string, string> AttributeList = null)
        {
            return string.Format(@"
if (![bool](Get-ADObject -Filter {{(Name -eq '{0}') -and (objectClass -eq '{1}')}} -SearchBase '{2}' -SearchScope OneLevel -ErrorAction SilentlyContinue))
{{
New-ADObject -Name '{0}' -Type '{1}' -Path '{2}';
}}
", ObjectName, ObjectType, Path);
        }

        public static string UpdateObject(string ObjectName, string ObjectType, string Path = "OU=ESPACK,DC=SYSTEMS,DC=espackeuro,DC=com", Dictionary<string, string> AttributeList = null)
        {
            string _attributeListString = "";
            //string _attributeKeys = "";
            if (AttributeList != null)
            {
                _attributeListString = string.Join(";", AttributeList.Select(r => string.Format("{0}='{1}'", r.Key, r.Value)).ToArray());
                //_attributeKeys = string.Join(",", AttributeList.Select(r => r.Key).ToArray());
            }
            return string.Format(@"Get-ADObject -LDAPFilter '(Name={0})' -SearchBase '{2}'| Set-ADObject -Add @{{{1}}};", ObjectName, _attributeListString, Path);
        }

        public static string CleanGroup(string GroupName)
        {
            return string.Format(@"
Get-ADGroupMember '{0}'| ForEach-Object {{Remove-ADGroupMember '{0}' $_ -Confirm:$false}};
$memberof=get-adgroup '{0}' |select -expandproperty distinguishedname;
Get-ADObject -Filter {{memberof -eq $memberof -and (objectClass -eq ""user"" -or ObjectClass -eq ""contact"")}} | ForEach-Object {{Get-ADGroup 'po_lineas_tw' | Set-ADObject -Remove @{{'member'=""$_""}}}};
", GroupName);
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
                _res = await command.InvokeList(serviceCommands);
            } catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return _res;
        }

    }
}
