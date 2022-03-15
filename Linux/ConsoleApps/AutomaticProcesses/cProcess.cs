﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticProcesses
{
    class cProcess
    {
        public cCredentials Credentials;
        public string Server { get { return Credentials.Server; } set { Credentials.Server = value; } }
        public string User { get { return Credentials.User; } set { Credentials.User = value; } }
        public string Password { get { return Credentials.Password; } set { Credentials.Password = value; } }
        public string DB { get { return Credentials.DB; } set { Credentials.DB = value; } }

        public string ArgsString;


        public cMiscFunctions.eFileType FileType;
        public static cMiscFunctions.eOrientation Orientation;
        public string FileName; // exported filename
        public int PDFFontSize=25; // font size of the report
        public bool Banded = false; // NOBAND
        public string Title;
        private string Emails; // check @

        public string QueryParams; // PARAMS for the query
        public int QueryNumber;
        public string MailTo;
        public bool NoBand, Error;



        public cProcess(cCredentials credentials, int queryNumber, string args,string title,bool noBand)
        {
            Credentials = credentials;
            QueryNumber = queryNumber;
            ArgsString = args;
            NoBand = noBand;
            Title = title;
        }
        public cProcess(string server, string user, string password, string db, int queryNumber, string args,string title, bool noBand) :this(new cCredentials(server, user, password, db),queryNumber,args,title,noBand)
        {

        }

        private bool ParseSQL(ref string sql,Dictionary<int,string> args, Dictionary<string,string> queryParams)
        {
            string _stage = "";
            int _count;

            try
            {
                //
                _stage = "Checkings";
                if (args.Count != queryParams.Count)
                    throw new Exception($"Number of args ({args.Count}) differ the number of parameters ({queryParams.Count}).");

                //
                _stage = "Matching parameters with arguments";
                _count = 1;
                foreach (var _a in queryParams)
                {
                    sql = sql.Replace($"?{_count}", args[_count]);
                    Console.WriteLine($">> {_a.Key}={args[_count]}");
                    _count++;
                }
                
            }
            catch(Exception ex)
            {
                Console.WriteLine($"[cProcess/ParseSQL#{_stage}] {ex.Message}.");
                return false;
            }
            return true;
        }
        private bool GetQueryDetails(cDBTools dbt, ref string sql, ref string queryDB, ref Dictionary<string,string> queryParams)
        {
            string _stage = "";

            try
            {
                //
                _stage = $"Getting SQL for query {QueryNumber}";
                dbt.Query($"select SQL,Base_Datos from cabecera_consultas where idreg={QueryNumber}");
                if (dbt.EOF)
                    throw new Exception("Query not found.");
                sql = "set dateformat dmy "+dbt.FieldValue(0).ToString();
                queryDB = dbt.FieldValue(1);

                //
                _stage = $"Getting parameters for query {QueryNumber}";
                dbt.Query($"select Param=Nombre_Parametro from detalle_consultas where consulta={QueryNumber} order by linea");
                queryParams = dbt.ToDictionaryKeys();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[cProcess/GetQueryDetails#{_stage}] {ex.Message}.");
                return false;
            }
            return true;
        }
        public string Process()
        {
            string _stage = "";
            Dictionary<string, string> _params = null;
            Dictionary<int, Dictionary<string, string>> _result = null;
            Dictionary<int, string> _args = null;
            string _sql = "", _queryDB = "", _html = "";
            int _count;
            
            try
            {
                //
                _stage = $"Check process args";
                

                //
                _stage = $"Connecting to {Credentials.Server}";
                cDBTools _dbt = new cDBTools(Credentials);
                _dbt.Connect();

                //
                _stage = "Getting query details";
                if (!GetQueryDetails(_dbt, ref _sql, ref _queryDB, ref _params))
                    throw new Exception("Aborted!");

                //
                _stage = "Processing args string";
                _args = cMiscFunctions.CheckArgs(ArgsString);

                //
                _stage = "Parsing SQL";
                if (!ParseSQL(ref _sql,_args,_params))
                    throw new Exception("Aborted!");

                //
                _stage = $"Changing to {_queryDB} DB";
                _dbt.ChangeDB(_queryDB);
                
                //
                _stage = "Executing query";
                if (!_dbt.Query(_sql))
                    throw new Exception("Aborted!");

                //
                _stage = "Converting data to dictionary";
                if (_dbt.RS.HasRows) _result = _dbt.ToDictionary();
                _dbt.Disconnect();

                _stage = "Converting data to {HTML}";
                if (_result!=null)
                    _html = cMiscFunctions.ProcessHTML(_result, Title, "", !NoBand);
            }
            catch (Exception ex)
            {
                _html = $"[cProcess/Process#{_stage}] {ex.Message}";
                Console.WriteLine(_html);
                Error = true;
            }

            //function recorset_proceso($args= Array())
            return _html;
        }


        /*        
                $nomArch="";
    $a=$argv; unset($a[0]);  #preparamos el array de parámetros
    $pdf=($argv[count($argv) - 3]=="PDF"?true:false);
    $txt=($argv[count($argv) - 3]=="TXT"?true:false);
    $xls=($argv[count($argv) - 3]=="XLS"?true:false);
        if ($pdf) { $nomArch=$argv[count($argv) - 4]; $orientacion=$argv[count($argv) - 5]; $fontsize=$argv[count($argv) - 6];}# si el antepenúltimo argumento es PDF, hay que buscar el nombre del fichero y la orientación de página

$subject =$argv[count($argv) - 1]; #print $subject; #asunto del email mandado


         */


        public void Process2()
        {
            string _msg="";
            /*
            Dictionary<int, string> _params = CheckParams();
            recorset_proceso(_params);

            switch (FileType)
            {
                case eFileType.PDF:
                    //pdf_proceso($rst,$nomArch,$subject,$orientacion,$fontsize,$band);
                    ProcessPDF();
                    break;
                case eFileType.TXT:
                    //txt_proceso($rst,$nomArch,$subject);
                    ProcessTXT();
                    break;
                case eFileType.XLS:
                    //html_arch_proceso($rst,$nomArch,$subject, '', 10,$band, true);
                    ProcessXLS();
                    break;
                default:
                    //$msg = html_proceso($rst,$subject, '', 11,$band);
                    _msg = ProcessHTLM();
                    break;
            }
            */
            _msg = (_msg!=""?_msg:"<html><body>Automatically sent message.<br><strong>Mensaje enviado automáticamente.</strong></body></html>");
            //mail_attach_html($to, $from, $subject, $msg, $nomArch);
        }


    }
}
