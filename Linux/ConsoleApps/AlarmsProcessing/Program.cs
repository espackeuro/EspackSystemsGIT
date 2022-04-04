using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using ConsoleTools;

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
            cConnDetails _connDetailsMail = null;
            cParameters _params;
            

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
                string[] _lines = File.ReadAllLines((cMiscTools.RunningOS == "Windows" ? Directory.GetCurrentDirectory().Substring(0, 3) : $"/media/bin/{_myName}/") + $"{_myName}.settings", Encoding.Unicode);

                //
                _stage = "Creating Parameters object";
                _params = new cParameters();

                //
                _stage = "Getting settings from file";
                _params.LoadParameters(_lines);

                //
                _stage = "Getting settings from args";
                Console.Write("OK!\n> Getting settings from args... ");
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



            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Main#{_stage}] {ex.Message}");
                return;
            }


            Console.WriteLine($"> Parameters: {String.Join(" ", args) }");

            if (String.IsNullOrEmpty(_params.DBUser) || String.IsNullOrEmpty(_params.DBPassword) || String.IsNullOrEmpty(_params.DBServer) || String.IsNullOrEmpty(_params.DBDataBase))
            {
                Console.WriteLine($"> ERROR at {_stage}: USER, PASSWORD, DATABASE and SERVER are mandatory.");
            }
            else
            {
                cConnDetails _connDetailsDB = new cConnDetails(_params.DBServer, _params.DBUser, _params.DBPassword, _params.DBDataBase);
                cDBTools _dbt = new cDBTools(_connDetailsDB);
                _dbt.Connect();
                _dbt.Query("Select Codigo,BD,Tabla,Campo_alarma,Nombre_idreg,idreg_valor,asunto_email,emails_aviso,condicion_alarma,campos_select,flagged=dbo.checkflag(flags,'FLAGGED'),server=isnull(server,''),FechaColumn=dbo.checkflag(flags,'XFEC2FECHA')  from cab_alarmas where dbo.checkFlag(flags,'ACTIVE')=1");

                //Dictionary<string,cAlarm> _alarms = new Dictionary<string, cAlarm>();

                while (!_dbt.EOF)
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