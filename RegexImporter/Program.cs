using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using static RegexImporter.Values;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace RegexImporter
{
    /*
     /REGEX1="<H3> *(\w\w\w) *(.*?)<\/H3>\r\n\r\n       Function:(.*?)\r" /REGEX2="(\d\d\d)    <A HREF =.*?>(....)<\/A> (.*?) *? (C|M) *(\d)(.*?)\r" /DIRTOPARSE="D:\Users\restelles\Downloads\html\tisd"
     * */
    public static class Values
    {
        public static SqlConnection conn { get; private set; }
        //public static string DestinationFolder { get => string.Format(@"{0}QRBarcodes\", Path.GetTempPath()); }
        public static Regex RegExp1 { get; set; }
        public static Regex RegExp2 { get; set; }
        public static string DirToParse { get; private set; } = "";
        public static void ParseArgs(string[] args)
        {
            string _dbServer = "DB01B";
            string _user = "sa";
            string _pwd = "5380";
            string _dataBase = "SISTEMAS";
            foreach (var _arg in args)
            {
                var _splittedArg = _arg.Split("=".ToCharArray(),2);
                if (_splittedArg.Length == 2)
                {
                    switch (_splittedArg[0].ToUpper())
                    {
                        case "/REGEX1":
                            RegExp1 = new Regex(@_splittedArg[1]);
                            break;
                        case "/REGEX2":
                            RegExp2 = new Regex(@_splittedArg[1]);
                            break;
                        case "/DIRTOPARSE":
                            DirToParse = _splittedArg[1];
                            break;
                    }
                }
            }
            if (_dbServer == "" || _dataBase == "" || RegExp1 == null || _user == "" || _pwd == "" || DirToParse == "")
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
            //RegExp1 = new Regex(@"(?:<H3>\ *?(\w\w\w)(.*?)<\/H3>");
            var FilesToParse = Directory.GetFiles(DirToParse).ToList();
            var captureBlock = 1;
            int captureIndex;
            using (conn)
            {
                var q = new SqlCommand("Select isnull(Max(CaptureIndex),0) from RegexCaptureTable",conn);
                conn.Open();
                using (SqlDataReader _reader = q.ExecuteReader())
                {
                    
                    if (_reader.HasRows)
                    {
                        _reader.Read();
                        captureIndex = Convert.ToInt32(_reader[0]) + 1;
                    }
                    else
                        captureIndex = 1;
                    
                }
                //iteramos los ficheros
                FilesToParse.ForEach(f =>
                {
                    //obtenemos el contenido
                    //var path = string.Format("{0}\\{1}", DirToParse, f);

                    var fileContent = File.ReadAllText(f);
                    //var reg = new Regex(@"<H3> *(\w\w\w) *(.*?)<\/H3>\r\n\r\n       Function:(.*?)\r");
                    var match1 = RegExp1.Matches(fileContent);
                    var match2 = RegExp2.Matches(fileContent);
                    //Regex.Matches(fileContent, @"<H3>\ *?(?<code>\w\w\w)(?<description>.*?)<\/H3>\r\n");
                    //var match2 = Regex.Matches(fileContent, RegExp2);
                    foreach (Match match in match1)
                    {
                        bool skip = true;
                        foreach (Group group in match.Groups)
                        {
                            if (!skip)
                                using (SqlCommand insertQuery = new SqlCommand(string.Format("INSERT INTO [RegexCaptureTable] ([CaptureIndex],[CaptureBlock],[DependingBlock],[Field]) VALUES ({0},{1},null,'{2}')", captureIndex, captureBlock, group.ToString()), conn))
                                {
                                    try
                                    {
                                        insertQuery.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                            skip = false;
                        }
                        
                    }
                    var dependingCapture = captureBlock;
                    captureBlock++;
                    foreach (Match match in match2)
                    {
                        bool skip = true;
                        foreach (Group group in match.Groups)
                        {
                            if (!skip)
                                using (SqlCommand insertQuery = new SqlCommand(string.Format("INSERT INTO [RegexCaptureTable] ([CaptureIndex],[CaptureBlock],[DependingBlock],[Field]) VALUES ({0},{1},{2},'{3}')", captureIndex, captureBlock, dependingCapture, group), conn))
                                {
                                    try
                                    {
                                        insertQuery.ExecuteNonQuery();
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                }
                            skip = false;
                        }
                        captureBlock++;
                    }
                });
            }
        }
    }
}
