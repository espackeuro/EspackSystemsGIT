using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace AlarmsProcessing
{
    class Program
    {
        // This variable is for knowing if the app is running in Debug mode or not.
        private static bool pDebug;

        static void Main(string[] args)
        {
#if DEBUG
            pDebug = true;
#else
            pDebug = false;
#endif
            string _stage;
            string _currentArgName, _currentArgValue;
            string _user = "", _password = "", _server = "", _db = "";
            string _myName = System.Reflection.Assembly.GetCallingAssembly().GetName().Name;

            // Args
            _stage = "Checking args";
            try
            {
                Console.WriteLine($"----==== Starting [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");

                try
                {
                    // If the settings file exists, the params will be loaded from it
                    _stage = "Loading settings file";
                    //string[] lines = File.ReadAllLines($"../.{_myName}.creds");
                    string[] _lines = File.ReadAllLines($@"D:\{_myName}.settings", Encoding.Unicode);

                    //
                    _stage = "Getting settings from file";
                    foreach (string _line in _lines)
                    {
                        // Get the arg name and value
                        _currentArgName = _line.Split('=')[0].ToUpper();
                        _currentArgValue = _line.Split('=')[1];

                        // Identify arg name
                        switch (_currentArgName)
                        {
                            case "SERVER":
                                _server = _currentArgValue;
                                break;
                            case "USER":
                                _user = _currentArgValue;
                                break;
                            case "PASSWORD":
                                _password = _currentArgValue;
                                break;
                            case "DB":
                                _db = _currentArgValue;
                                break;
                            default:
                                throw new Exception($"Wrong argument: {_currentArgName}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Main#{_stage}] {ex.Message}");
                }

                // If params are set, they will override those loaded from the settings file
                _stage = "Getting settings from args";
                foreach (string arg in args)
                {
                    // Get the arg name and value
                    _currentArgName = arg.Split('=')[0].ToUpper();
                    if (arg.Split('=').Length == 2)
                        _currentArgValue = arg.Split('=')[1];
                    else if (arg.Split('=').Length > 2)
                        throw new Exception($"Wrong argument: {arg}");
                    else
                        _currentArgValue = "";

                    // Identify arg name
                    switch (_currentArgName.ToUpper())
                    {
                        case "USER":
                            _user = _currentArgValue;
                            break;
                        case "PASSWORD":
                            _password = _currentArgValue;
                            break;
                        case "SERVER":
                            _server = _currentArgValue;
                            break;
                        case "DB":
                            _db = _currentArgValue;
                            break;
                        default:
                            throw new Exception($"Wrong argument: {_currentArgName}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Main#{_stage}] {ex.Message}");
                return;
            }

            
            Console.WriteLine($"> Parameters: {String.Join(" ", args) }");

            if (_user == "" || _password == "" || _server == "" || _db=="")
            {
                Console.WriteLine($"> ERROR at {_stage}: USER, PASSWORD, DATABASE and SERVER are mandatory.");
            }
            else
            {
                cDBTools _dbt = new cDBTools(_server, _user, _password, _db);
                _dbt.Connect();
                _dbt.Query("Select Codigo,BD,Tabla,Campo_alarma,Nombre_idreg,idreg_valor,asunto_email,emails_aviso,condicion_alarma,campos_select,flagged=dbo.checkflag(flags,'FLAGGED'),server=isnull(server,''),FechaColumn=dbo.checkflag(flags,'XFEC2FECHA')  from cab_alarmas where dbo.checkFlag(flags,'ACTIVE')=1");
                
                //Dictionary<string,cAlarm> _alarms = new Dictionary<string, cAlarm>();
                
                while (!_dbt.EOF())
                {
                    using (cAlarm _alarm = new cAlarm(_dbt.FieldValue(0), _dbt.FieldValue(1), _dbt.FieldValue(2), _dbt.FieldValue(3), _dbt.FieldValue(4), Convert.ToInt32(_dbt.FieldValue(5)), _dbt.FieldValue(6), _dbt.FieldValue(7), _dbt.FieldValue(8), _dbt.FieldValue(9), Convert.ToInt32(_dbt.FieldValue(10)) == 1, _dbt.FieldValue(11), Convert.ToInt32(_dbt.FieldValue(12)) == 1))
                    {
                        _alarm.Process();
                    }
                    _dbt.MoveNext();
                } 
                _dbt.Disconnect();

            }
            Console.WriteLine($"----==== Ending [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");
        }

        
    }
}