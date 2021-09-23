using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace SFTPCommsNS
{
    class DocumentClass: IDisposable
    {
        public string fileName;
        public string filePath;
        public string contents;
        public string idDocument;
        public string internalCode;

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
            idDocument = null;
            internalCode = null;
            contents = null;

            try
            {

                //
                _stage = "Checkings";
                if (file == null)
                    file = ArrangePath(filePath, pSeparator) + fileName;

                if (string.IsNullOrEmpty(file))
                    throw new Exception("The file name is mandatory.");

                //
                _stage = "Reading the file contents";
                contents = File.ReadAllText(file);
                fileName = Path.GetFileName(file);
                filePath = Path.GetFullPath(file);

                // 
                _stage = "Getting document definitions";
                // For later updates, this is the query in php process
                // "select idreg,formato,descripcion,identificador,posicion_codigo_doc,longitud_codigo_doc,flags,postproceso,tablas,delimiter,quotes=rtrim(ltrim(quotes)),Subproveedores,posicion_codigo_subprov,longitud_codigo_subprov from documentos where isnull(identificador,'')<>'' /*and dbo.CheckFlag(flags,'OUT')=0*/"
                using (var _cmd = new SqlCommand("select idreg,identificador,posicion_codigo_doc,longitud_codigo_doc,flags from documentos where formato='SAP' and dbo.CheckFlag(flags,'OBS')=0 and dbo.CheckFlag(flags,'OUT')=1", connection))
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
                        idDocument = _rs["idreg"].ToString();
                        _stage = $"Comparing identifier for {idDocument}";
                        _found = Regex.IsMatch(contents, _rs["identificador"].ToString());

                        //
                        _stage = $"Getting settings from document {idDocument}";
                        _supplierCode = contents.Substring(Convert.ToInt32(_rs["posicion_codigo_doc"].ToString()), Convert.ToInt32(_rs["longitud_codigo_doc"].ToString()));
                        _flags = _rs["flags"].ToString();
                    }
                    _rs.Close();
                    _rs = null;
                }

                if (_found)
                {
                    //
                    _stage = $"Check flags for document {idDocument}";
                    if (!_flags.Contains("|SFTP|"))
                        throw new Exception($"{idDocument} document not set as SFTP");

                    //
                    _stage = $"Getting internal code for document {idDocument}";
                    using (var _cmd = new SqlCommand($"select codigo_interno from proveedores where (len(codigo_prov) = 0 or dbo.CheckFlag('|' + codigo_prov + '|', '{_supplierCode}') = 1) and documento = '{idDocument}' and dbo.CheckFlag(flags, 'A') = 1", connection))
                    {
                        SqlDataReader _rs = _cmd.ExecuteReader();
                        if (!_rs.HasRows)
                            throw new Exception($"Internal code couldn't be found");

                        //
                        _rs.Read();
                        internalCode = _rs["codigo_interno"].ToString();
                        _rs.Close();
                        _rs = null;
                    }
                }
                else
                {
                    idDocument = null;
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
