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
            string _stage = "Unknown Error";
            string _currentArgName, _currentArgValue;
            string _DBuser = "", _DBpassword = "", _DBServer = "", _DBdataBase = "";
            string _mailServer = "", _mailUser = "", _mailPassword = "", _processMailErrorTo = "";
            int? _DBtimeOut = null;
            string _myName = System.Reflection.Assembly.GetCallingAssembly().GetName().Name;
            ConsoleTools.cConnDetails _connDetailsMail = null;
            ConsoleTools.cParameters _params = null;

            try
            {
                Console.WriteLine($"----==== Starting [{_myName}] at {System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")} ====----");

                Console.Write("> Loading settings file... ");

                // If the settings file exists, the params will be loaded from it
                _stage = "Loading settings file";
                string[] _lines = File.ReadAllLines((pDebug ? Directory.GetCurrentDirectory().Substring(0, 3) : $"/media/bin/{_myName}/") + $"{_myName}.settings", Encoding.Unicode);

                _params = new ConsoleTools.cParameters();

                //
                _stage = "Getting settings from file";
                _params.LoadParameters(_lines);

                //
                _stage = "Getting settings from args";
                _params.LoadParameters(_lines);
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
                ConsoleTools.cConnDetails _connDetailsDB = new ConsoleTools.cConnDetails(_params.DBServer, _params.DBUser, _params.DBPassword, _params.DBDataBase);
                ConsoleTools.cDBTools _dbt = new ConsoleTools.cDBTools(_connDetailsDB);
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