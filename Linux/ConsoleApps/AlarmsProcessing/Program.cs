using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using ConsoleTools;
using DataAccess;

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
            string _stage = "Unknown Error";
            string _myName = System.Reflection.Assembly.GetCallingAssembly().GetName().Name;

            try
            {
                Console.WriteLine($"----==== Starting [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");

                //
                _stage = "Checking OS";
                if (cMiscTools.RunningOS == "Other")
                    throw new Exception("OS not supported!");

                // If the settings file exists, the params will be loaded from it
                _stage = "Loading settings file";
                Console.Write("> Loading settings file... ");
                string[] _lines = File.ReadAllLines((cMiscTools.RunningOS == "Windows" ? Directory.GetCurrentDirectory().Substring(0, 3) : $"/media/bin/{_myName}/") + $"C# Apps Settings/{_myName}.settings", Encoding.Unicode);

                //
                _stage = "Creating Parameters object";
                cParameters _params = new cParameters();

                //
                _stage = "Getting settings from file";
                _params.LoadParameters(_lines);

                //
                _stage = "Getting settings from args";
                Console.Write($"OK!\n> Parameters: {(args.Length!=0?String.Join(" ", args):"NONE")}\n> Getting settings from args... ");
                _params.LoadParameters(args);

                //
                _stage = "Checking settings";
                Console.WriteLine("OK!");
                Console.Write("> Checking settings... ");
                if (String.IsNullOrEmpty(_params.DBServer))
                    throw new Exception("DB server is mandatory: DB_SERVER=<ServerAddress>");
                if (String.IsNullOrEmpty(_params.DBUser))
                    throw new Exception("DB user is mandatory: DB_USER=<UserCode>");
                if (String.IsNullOrEmpty(_params.DBPassword))
                    throw new Exception("DB password is mandatory: DB_PASSWORD=<Password>");
                if (String.IsNullOrEmpty(_params.DBDataBase))
                    throw new Exception("Database is mandatory: DB_DATABASE=<Database>");
                Console.WriteLine("OK!");

                //
                _stage = "Creating connection objects";
                cConnDetails _connDetailsDB = new cConnDetails(_params.DBServer, _params.DBUser, _params.DBPassword, _params.DBDataBase);
                cConnDetails _connDetailsMail = new cConnDetails(_params.MailServer, _params.MailUser, _params.MailPassword);

                //
                _stage = $"Connecting to {_connDetailsDB.Server}";
                cDataAccess _da = new cDataAccess(_connDetailsDB);
                _da.Connect();

                //
                _stage = "Getting alarms list";
                Recordset _rs = new Recordset("Select Codigo,BD,Tabla,Campo_alarma,Nombre_idreg,idreg_valor,asunto_email,emails_aviso,condicion_alarma,campos_select,flagged=dbo.checkflag(flags,'FLAGGED'),server=isnull(server,''),FechaColumn=dbo.checkflag(flags,'XFEC2FECHA')  from cab_alarmas where dbo.checkFlag(flags,'ACTIVE')=1 and codigo='ALARMTEST'", _da);
                _rs.Open();
                //Dictionary<int, Dictionary<string, string>> _alarms = _rs.ToDictionary();

                //
                string p;
                _stage = "Looping through alarms";
                
                while (!_rs.EOF)
                {
                    
                    using (cAlarm _alarm = new cAlarm(_da, _rs["Codigo"].ToString(), _rs["BD"].ToString(), _rs["Tabla"].ToString(), _rs["Campo_alarma"].ToString(), _rs["Nombre_idreg"].ToString(), Convert.ToInt32(_rs["idreg_valor"]), _rs["asunto_email"].ToString(), _rs["emails_aviso"].ToString(), _rs["condicion_alarma"].ToString(), _rs["campos_select"].ToString(), Convert.ToInt32(_rs["flagged"]) == 1, _rs["server"].ToString(), Convert.ToInt32(_rs["FechaColumn"]) == 1))
                    {
                        try
                        {

                            //
                            _stage = $"Executing alarm {_alarm.Code}";
                            Console.Write($"> Executing alarm {_alarm.Code}...");
                            _alarm.Process();
                            Console.Write($" {(_alarm.Error ? "ERROR" : "OK")}! Sending {(_alarm.Error ? "error " : "")}email...");

                            //
                            if (_alarm.Triggered || _alarm.Error)
                            {
                                _stage = $"Sending {(_alarm.Error ? "error " : "")} email";
                                using (cEmail _email = new cEmail(_connDetailsMail, _alarm.Error ? _params.MailErrorTo : (!String.IsNullOrEmpty(_params.MailTo) ? _params.MailTo : _alarm.EmailList), $"ALARM: {_alarm.EmailSubject}", _alarm.Contents, error: _alarm.Error)) 
                                {
                                    if (_alarm.Error)
                                        _email.Recipients = _params.MailErrorTo;

                                    _email.Send();
                                }
                                Console.WriteLine(" OK!");
                            }
                            else
                            {
                                Console.WriteLine(" Not triggered.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    _rs.MoveNext();
                }

                //
                _stage = "Disconnecting from DB server";
                //_dbt.Disconnect();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Main#{_stage}] {ex.Message}");
                return;
            }

          
            Console.WriteLine($"----==== Ending [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");
        }


    }
}