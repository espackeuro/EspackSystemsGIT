using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTools
{
    public class cParameters
    {
        public enum eFileType { HTML, PDF, XLS, TXT }
        public enum ePageOrientation { PORTRAIT, LANDSCAPE }
        public cConnDetails ConnDetailsDB = new cConnDetails();
        public cConnDetails ConnDetailsMail = new cConnDetails();
        public string DBServer { get { return ConnDetailsDB.Server; } set { ConnDetailsDB.Server = value; } }
        public string DBUser { get { return ConnDetailsDB.User; } set { ConnDetailsDB.User = value; } }
        public string DBPassword { get { return ConnDetailsDB.Password; } set { ConnDetailsDB.Password = value; } }
        public string DBDataBase { get { return ConnDetailsDB.DB; } set { ConnDetailsDB.DB = value; } }
        public int? DBTimeOut { get { return ConnDetailsDB.TimeOut; } set { ConnDetailsDB.TimeOut = value; } }
        public string MailServer { get { return ConnDetailsMail.Server; } set { ConnDetailsMail.Server = value; } }
        public string MailUser { get { return ConnDetailsMail.User; } set { ConnDetailsMail.User = value; } }
        public string MailPassword { get { return ConnDetailsMail.Password; } set { ConnDetailsMail.Password = value; } }

        public string MailSubject, MailTo, MailErrorTo;
        public int? ProcessQuery, ProcessSubQuery, ProcessFontSize;
        public string ProcessParams, ProcessEmptyMessage, ProcessFileName;
        public bool ProcessNoBand, ProcessNoEmpty;
        public eFileType ProcessFileType;
        public ePageOrientation ProcessPageOrientation;

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
                    case "MAIL_SERVER":
                        MailServer = _currentArgValue;
                        break;
                    case "MAIL_USER":
                        MailUser = _currentArgValue;
                        break;
                    case "MAIL_PASSWORD":
                        MailPassword = _currentArgValue;
                        break;
                    case "SUBJECT":
                        MailSubject = _currentArgValue;
                        break;
                    case "TO":
                        MailTo = _currentArgValue;
                        break;
                    case "ERR_TO":
                        MailErrorTo = _currentArgValue;
                        break;
                    case "QUERY":
                        if (!String.IsNullOrEmpty(_currentArgValue)) ProcessQuery = Convert.ToInt32(_currentArgValue);
                        break;
                    case "SUBQUERY":
                        if (!String.IsNullOrEmpty(_currentArgValue)) ProcessSubQuery = Convert.ToInt32(_currentArgValue);
                        break;
                    case "PARAMS":
                        ProcessParams = _currentArgValue;
                        break;
                    case "FONTSIZE":
                        if (!String.IsNullOrEmpty(_currentArgValue)) ProcessFontSize = Convert.ToInt32(_currentArgValue);
                        break;
                    case "NOBAND":
                        ProcessNoBand = true;
                        break;
                    case "NOEMPTY":
                        ProcessNoEmpty = true;
                        break;
                    case "EMPTYMESSAGE":
                        ProcessEmptyMessage = _currentArgValue;
                        break;
                    case "FILENAME":
                        ProcessFileName = _currentArgValue;
                        break;
                    case "FILETYPE":
                        Enum.TryParse(_currentArgValue, out eFileType _fileType);
                        ProcessFileType = _fileType;
                        break;
                    case "ORIENTATION":
                        Enum.TryParse(_currentArgValue, out ePageOrientation _pageOrientation);
                        ProcessPageOrientation = _pageOrientation;
                        break;

                    default:
                        throw new Exception($"Wrong argument: {_currentArgName}");
                }
            }
        }
    }
}