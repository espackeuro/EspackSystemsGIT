using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTools
{
    public class cParameters
    {
        public cConnDetails ConnDetailsDB = new cConnDetails();
        public string DBServer { get { return ConnDetailsDB.Server; } set { ConnDetailsDB.Server = value; } }
        public string DBUser { get { return ConnDetailsDB.User; } set { ConnDetailsDB.User = value; } }
        public string DBPassword { get { return ConnDetailsDB.Password; } set { ConnDetailsDB.Password = value; } }
        public string DBDataBase { get { return ConnDetailsDB.DB; } set { ConnDetailsDB.DB = value; } }
        public int? DBTimeOut { get { return ConnDetailsDB.TimeOut; } set { ConnDetailsDB.TimeOut = value; } }
        public string DomainServer { get; set; }
        public string ExchangeServer { get; set; }

        public void LoadParameters(string[] Params)
        {
            string _currentArgName = "", _currentArgValue = "";

            foreach (string _param in Params)
            {

                // Get the arg name and value
                _currentArgName = _param.Split('=')[0].ToUpper();
                if (_param.Split('=').Length == 2)
                    _currentArgValue = _param.Split('=')[1];
                else if (_param.Split('=').Length > 2)
                    throw new Exception($"Wrong argument: {_param}");
                else
                    _currentArgValue = "";

                // Identify arg name
                switch (_currentArgName)
                {
                    case "DB_SERVER":
                        DBServer = _currentArgValue;
                        break;
                    case "DB_USER":
                        DBUser = _currentArgValue;
                        break;
                    case "DB_PASSWORD":
                        DBPassword = _currentArgValue;
                        break;
                    case "DB_DATABASE":
                        DBDataBase = _currentArgValue;
                        break;
                    case "DB_TIMEOUT":
                        DBTimeOut = Int32.Parse(_currentArgValue);
                        break;
                    case "DOMAIN_SERVER":
                        DomainServer = _currentArgName;
                        break;
                    case "EXCHANGE_SERVER":
                        ExchangeServer = _currentArgName;
                        break;
                    default:
                        throw new Exception($"Wrong argument: {_currentArgName}");
                }
            }
        }
    }
}