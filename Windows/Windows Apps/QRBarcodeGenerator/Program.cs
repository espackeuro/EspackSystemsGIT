using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using static QRTest.Values;

namespace QRTest
{
    public static class Values
    {
        public static SqlConnection conn { get; private set; }
        public static string DestinationFolder { get => string.Format(@"{0}QRBarcodes\",Path.GetTempPath()); }
        public static string SQLQuery { get; private set; } = "";
        public static string FileNameField { get; private set; } = "";
        public static void ParseArgs(string[] args)
        {
            string _dbServer = "";
            string _user = "";
            string _pwd = "";
            string _dataBase = "";
            foreach (var _arg in args)
            {
                var _splittedArg = _arg.Split(':');
                if (_splittedArg.Length == 2)
                {
                    switch (_splittedArg[0].ToUpper())
                    {
                        case "/DBSERVER": _dbServer = _splittedArg[1];
                            break;
                        case "/DB": _dataBase = _splittedArg[1];
                            break;
                        case "/SQLQUERY": SQLQuery= _splittedArg[1];
                            break;
                        case "/USR": _user = _splittedArg[1];
                            break;
                        case "/PWD": _pwd= _splittedArg[1];
                            break;
                        case "/FILENAMEFIELD": FileNameField = _splittedArg[1];
                            break;
                    }
                }
            }
            if (_dbServer == "" || _dataBase == "" || SQLQuery== "" || _user=="" || _pwd == "" || FileNameField == "")
            {
                var ex = new Exception("Incomplete Parameters");
                throw (ex);
            }
            var _csb = new SqlConnectionStringBuilder();
            _csb.UserID = _user;
            _csb.Password = _pwd;
            _csb.InitialCatalog = _dataBase;
            _csb.DataSource = _dbServer;
            _csb.AsynchronousProcessing = true;
            conn = new SqlConnection(_csb.ConnectionString);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            ParseArgs(args);
            var qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            if (Directory.Exists(DestinationFolder))
                Directory.Delete(DestinationFolder, recursive: true);
            Directory.CreateDirectory(DestinationFolder);
            using (conn)
            {
                SqlCommand _query = new SqlCommand(SQLQuery, conn);
                conn.Open();
                SqlDataReader _reader = _query.ExecuteReader();
                if (_reader.HasRows)
                {
                    while (_reader.Read())
                    {
                        string _fileName = "";
                        string RS = ((char)030).ToString();
                        string GS = ((char)029).ToString();
                        string EOT = ((char)004).ToString();

                        string _text = "[)>" + RS;
                        for ( var i = 0; i < _reader.FieldCount; i++ )
                        {
                            _text += _reader.GetString(i);
                            if (i == _reader.FieldCount - 1)
                                _text += RS + EOT;
                            else
                                _text += GS;
                            if (_reader.GetName(i) == FileNameField)
                                _fileName = _reader.GetString(i);
                        }
                        if (_fileName == "")
                        {
                            var ex = new Exception("FileName field not found");
                            throw (ex);
                        }
                        var _qrCode = qrEncoder.Encode(_text);
                        var renderer = new GraphicsRenderer(new FixedModuleSize(5, QuietZoneModules.Two), Brushes.Black, Brushes.White);
                        using (var stream = new FileStream(string.Format("{0}{1}.bmp", DestinationFolder, _fileName), FileMode.Create))
                            renderer.WriteToStream(_qrCode.Matrix, ImageFormat.Bmp, stream);
                    }
                }
            }
        }
    }
}
