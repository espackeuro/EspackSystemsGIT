using System;
using System.Collections.Generic;
using System.IO;
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

        public cMiscFunctions.eFileType FileType;
        public cMiscFunctions.eOrientation Orientation;
        public string ArgsString, FileName, Title, HTML = "";
        public int QueryNumber, PDFFontSize = 25;
        public bool NoBand, Error;

        public cProcess(cCredentials credentials, int queryNumber, string args, string title, bool noBand = false, string fileName = null, cMiscFunctions.eFileType fileType = cMiscFunctions.eFileType.HTML, cMiscFunctions.eOrientation orientation = cMiscFunctions.eOrientation.PORTRAIT)
        {
            Credentials = credentials;
            QueryNumber = queryNumber;
            ArgsString = args;
            Title = title;
            NoBand = noBand;
            FileType = fileType;
            Orientation = orientation;
            FileName = fileName;
        }
        public cProcess(string server, string user, string password, string db, int queryNumber, string args, string title, bool noBand = false, string fileName = null, cMiscFunctions.eFileType fileType = cMiscFunctions.eFileType.HTML, cMiscFunctions.eOrientation orientation = cMiscFunctions.eOrientation.PORTRAIT) : this(new cCredentials(server, user, password, db), queryNumber, args, title, noBand, fileName, fileType, orientation)
        {

        }

        private bool ParseSQL(ref string sql, Dictionary<int, string> args, Dictionary<string, string> queryParams)
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
            catch (Exception ex)
            {
                Console.WriteLine($"[cProcess/ParseSQL#{_stage}] {ex.Message}.");
                return false;
            }
            return true;
        }
        private bool GetQueryDetails(cDBTools dbt, ref string sql, ref string queryDB, ref Dictionary<string, string> queryParams)
        {
            string _stage = "";

            try
            {
                //
                _stage = $"Getting SQL for query {QueryNumber}";
                dbt.Query($"select SQL,Base_Datos from cabecera_consultas where idreg={QueryNumber}");
                if (dbt.EOF)
                    throw new Exception("Query not found.");
                sql = "set dateformat dmy " + dbt.FieldValue(0).ToString();
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
            Dictionary<int, string> _args;
            string _sql = "", _queryDB = "", _fullFilePath, _filePath;

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
                if (!ParseSQL(ref _sql, _args, _params))
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
                if (_result != null)
                {
                    HTML = cMiscFunctions.ProcessHTML(_result, Title, "", NoBand);
                    if (FileType == cMiscFunctions.eFileType.XLS)
                        FileName = ToExcel();
                }
            }
            catch (Exception ex)
            {
                HTML = $"[cProcess/Process#{_stage}] {ex.Message}";
                Console.WriteLine(HTML);
                Error = true;
            }


            //function recorset_proceso($args= Array())
            return HTML;
        }

        private string ToExcel()
        {
            string _stage = "";
            string _filePath, _fullFilePath;

            // Check file name null


            _stage = "Preparing temp path";
            _filePath = Path.GetTempPath();
            if (!FileName.ToUpper().EndsWith(".XLS")) FileName += ".xls";
            _fullFilePath = $"{_filePath}{Path.DirectorySeparatorChar}{FileName}";
            if (File.Exists(_fullFilePath))
            {
                //
                _stage = $"Deleting {_fullFilePath}";
                File.Delete(_fullFilePath);
            }

            //
            _stage = "Saving to excel file";
            using (FileStream _fs = File.Create(_fullFilePath))
            {
                byte[] _info = new UTF8Encoding(true).GetBytes(HTML);
                // Add some information to the file.
                _fs.Write(_info, 0, _info.Length);
            }

            return _fullFilePath;
        }


    }


    
}
