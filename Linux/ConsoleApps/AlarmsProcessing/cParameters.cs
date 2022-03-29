using System;
using System.Collections.Generic;
using System.Text;

namespace AlarmsProcessing
{
    class cParameters
    {
        public string DBServer, DBUser, DBPassword, DBDataBase;
        public string MailServer, MailUser, MailPassword, MailTo, MailErrorTo;
        public Nullable<int> DBTimeOut;


                            // Identify arg name
                    switch (_currentArgName)
                    {
                        case "DB_SERVER":
                            _DBServer = _currentArgValue;
                            break;
                        case "DB_USER":
                            _DBuser = _currentArgValue;
                            break;
                        case "DB_PASSWORD":
                            _DBpassword = _currentArgValue;
                            break;
                        case "DB_DATABASE":
                            _DBdataBase = _currentArgValue;
                            break;
                        case "DB_TIMEOUT":
                            _DBtimeOut = Int32.Parse(_currentArgValue);
                            break;
                        case "MAIL_SERVER":
                            _mailServer = _currentArgValue;
                            break;
                        case "MAIL_USER":
                            _mailUser = _currentArgValue;
                            break;
                        case "MAIL_PASSWORD":
                            _mailPassword = _currentArgValue;
                            break;
                        case "ERR_TO":
                            _processMailErrorTo = _currentArgValue;
                            break;
                        default:
                            throw new Exception($"Wrong argument: {_currentArgName}");
    }
}



    }
}
