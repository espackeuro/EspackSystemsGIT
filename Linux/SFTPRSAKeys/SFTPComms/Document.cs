using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace SFTPCommsNS
{
    enum TransferProtocols
    {
        TP_NONE, 
        TP_FTP,
        TP_SFTP,
        TP_RSAFTP,
        TP_EMAIL
    }
    enum TransferDirections
    {
        TD_NONE,
        TD_INBOUND,
        TD_OUTBOUND
    }

    class DocumentClass: IDisposable
    {
        private string _fileName;
        private string _filePath;
        private string _contents;
        private string _id;
        private string _internalCode;
        private TransferDirections _transferDirection = TransferDirections.TD_NONE;
        private TransferProtocols _transferProtocol = TransferProtocols.TP_NONE;

        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        public string Contents
        {
            get { return _contents; }
        }
        public string DocumentID
        {
            get { return _id; }
        }
        public string InternalCode
        {
            get { return _internalCode; }
        }
        public TransferDirections TransferDirection
        {
            get { return _transferDirection; }
            set
            { 
                    if (!String.IsNullOrEmpty(_id))
                        throw new Exception($"Can't change transfer direction for document {_id}");
                    _transferDirection = value; 
            }
        }
        public TransferProtocols TransferProtocol
        {
            get { return _transferProtocol; }
            set {
                if (!String.IsNullOrEmpty(_id))
                    throw new Exception($"Can't change transfer protocol for document {_id}");
                _transferProtocol = value;
            }
        }

#if DEBUG
        private const string pSeparator = "\\";
#else
        private const string pSeparator = "/"
#endif
        public bool Identify(SqlConnection connection,  string file = null)
        {
            string _stage = "";
            string _flags = "";
            string _supplierCode = "";
            bool _found = false;

            // Init vars
            _id = null;
            _internalCode = null;
            _contents = null;

            try
            {

                //
                _stage = "Checkings";
                if (file == null)
                    file = ArrangePath(_filePath, pSeparator) + _fileName;

                if (string.IsNullOrEmpty(file))
                    throw new Exception("The file name is mandatory.");

                //
                _stage = "Reading the file contents";
                _contents = File.ReadAllText(file);
                _fileName = Path.GetFileName(file);
                _filePath = Path.GetFullPath(file);

                // 
                _stage = "Getting document definitions";
                // For later updates, this is the query in php process
                // "select idreg,formato,descripcion,identificador,posicion_codigo_doc,longitud_codigo_doc,flags,postproceso,tablas,delimiter,quotes=rtrim(ltrim(quotes)),Subproveedores,posicion_codigo_subprov,longitud_codigo_subprov from documentos where isnull(identificador,'')<>'' /*and dbo.CheckFlag(flags,'OUT')=0*/"
                //using (var _cmd = new SqlCommand("select idreg,identificador,posicion_codigo_doc,longitud_codigo_doc,flags from documentos where formato='SAP' and dbo.CheckFlag(flags,'OBS')=0 and dbo.CheckFlag(flags,'OUT')=1", connection))
                using (var _cmd = new SqlCommand("select idreg,identificador,posicion_codigo_doc,longitud_codigo_doc,flags from documentos where formato='SAP' and dbo.CheckFlag(flags,'OBS')=0", connection))
                {
                    //
                    _stage = "Executing query";
                    SqlDataReader _rs = _cmd.ExecuteReader();
                    if (!_rs.HasRows)
                        throw new Exception($"Document definitions not found");

                    //
                    while (_rs.Read() && !_found)
                    {
                        //
                        _id = _rs["idreg"].ToString();
                        _stage = $"Comparing identifier for {_id}";
                        _found = Regex.IsMatch(_contents, _rs["identificador"].ToString());

                        //
                        _stage = $"Getting settings from document {_id}";
                        _supplierCode = _contents.Substring(Convert.ToInt32(_rs["posicion_codigo_doc"].ToString()), Convert.ToInt32(_rs["longitud_codigo_doc"].ToString()));
                        _flags = _rs["flags"].ToString();
                    }
                    _rs.Close();
                    _rs = null;
                }

                if (_found)
                {
                    //
                    _stage = $"Setting setting values for document {_id}";
                    _transferDirection = _flags switch
                    { 
                        string a when a.Contains("|OUT|") => TransferDirections.TD_OUTBOUND,
                        _ => TransferDirections.TD_INBOUND
                    };
                    _transferProtocol = _flags switch
                    {
                        string a when a.Contains("|RSAFTP|") => TransferProtocols.TP_RSAFTP,
                        string a when a.Contains("|SFTP|") => TransferProtocols.TP_SFTP,
                        string a when a.Contains("|FTP|") => TransferProtocols.TP_SFTP,
                        string a when a.Contains("|EMAIL|") => TransferProtocols.TP_EMAIL,
                        _ => TransferProtocols.TP_NONE
                    };

                    //
                    _stage = $"Getting internal code for document {_id}";
                    using (var _cmd = new SqlCommand($"select codigo_interno from proveedores where (len(codigo_prov) = 0 or dbo.CheckFlag('|' + codigo_prov + '|', '{_supplierCode}') = 1) and documento = '{_id}' and dbo.CheckFlag(flags, 'A') = 1", connection))
                    {
                        SqlDataReader _rs = _cmd.ExecuteReader();
                        if (!_rs.HasRows)
                            throw new Exception($"Internal code couldn't be found");

                        //
                        _rs.Read();
                        _internalCode = _rs["codigo_interno"].ToString();
                        _rs.Close();
                        _rs = null;
                    }
                }
                else
                {
                    _id = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"[IdentifyDocument#{_stage}] {ex.Message}.");
            }

            // OK
            return _found;
        }

        // Add separator at the end of a string if it is not there
        private static string ArrangePath(string path, string separator)
        {
            if (path.Substring(path.Length - separator.Length) != separator)
                path = path + separator;

            return path;
        }

        public void Dispose()
        {
            string _stage = "";

            try
            {
                //
                _stage = "Checkings";

               // Anything to do?? 

            }
            catch (Exception ex)
            {
                throw new Exception($"[Dispose#{_stage}] {ex.Message}");
            }
        }
    }
}
