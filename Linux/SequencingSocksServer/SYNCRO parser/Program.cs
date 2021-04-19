using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;

namespace SYNCRO_parser
{
    class Program
    {
        public static string filePath { get; set; }
        static void Main(string[] args)
        {
            filePath = @"D:\20210419-113021 - 73.txt";
            string fileText = "";
            fileText = File.ReadAllText(filePath);
            Regex rx = new Regex("UNH.*?\xC", RegexOptions.Compiled | RegexOptions.Multiline);
            Regex rxLin = new Regex(@"UNH\+0(\d{4})\+SYNCRO:2'MID\+0\1\+(\d{6}):(\d{4})'CDT\+.*:(.*)'CSG(?:.*):(.*)'SEQ\+(.*)\+(.*)\+(.*):(.*)'ARD.*'SDD\+(\d{6}):(\d{4}).*'SUB.*UNT.*\1", RegexOptions.Compiled | RegexOptions.Multiline);
            // Find matches.
            MatchCollection matches = rx.Matches(fileText);
            foreach (var match in matches)
            {
                MatchCollection linMatches = rxLin.Matches(match.ToString());
                var hostName = Dns.GetHostName();
                var transNumber = linMatches[0].Groups[1].Value;
                var transDate = linMatches[0].Groups[2].Value;
                var transTime = linMatches[0].Groups[3].Value;
                var supplierCode = linMatches[0].Groups[4].Value;
                var plantCode = linMatches[0].Groups[5].Value;
                var seqQualifier = linMatches[0].Groups[6].Value;
                var seqNumber = linMatches[0].Groups[7].Value;
                var vinNumber = linMatches[0].Groups[8].Value;
                var eccsSeqNum = linMatches[0].Groups[9].Value;
                var callInDate = linMatches[0].Groups[10].Value;
                var callInTime = linMatches[0].Groups[11].Value;

                DB.toDataBase(hostName, transNumber, DateTime.ParseExact($"{transDate}:{transTime}", "yyMMdd:HHmm", new CultureInfo("es-ES")),
                    supplierCode, plantCode, seqQualifier, seqNumber, vinNumber, eccsSeqNum,
                    DateTime.ParseExact($"{callInDate}:{callInTime}", "yyMMdd:HHmm", new CultureInfo("es-ES")));

            }

        }
    }
    public static class DB { 
    
        public static bool toDataBase(string hostName, string transNumber, DateTime transDateTime, string supplierCode, string plantCode, string seqQualifier, string seqNumber, string vinNumber, string eccsSeqNum, DateTime callInDateTime)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = "DB01B";
                builder.UserID = "sa";
                builder.Password = "5380";
                builder.InitialCatalog = "TRANSMISIONES";

                using SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                using SqlCommand sp = new SqlCommand("pAddSequencingOdetteSyncroStrings", connection) { CommandType = System.Data.CommandType.StoredProcedure };
                SqlCommandBuilder.DeriveParameters(sp);
                sp.Parameters["@msg"].Value = "";
                sp.Parameters["@HostName"].Value = hostName;
                sp.Parameters["@TransNumber"].Value = transNumber;
                sp.Parameters["@TransDateTime"].Value = transDateTime;
                sp.Parameters["@SupplierCode"].Value = supplierCode;
                sp.Parameters["@DestinationPlant"].Value = plantCode;
                sp.Parameters["@SeqQualifier"].Value = seqQualifier;
                sp.Parameters["@SeqNr"].Value = seqNumber;
                sp.Parameters["@VinNr"].Value = vinNumber;
                sp.Parameters["@ECCSSeqNum"].Value = eccsSeqNum;
                sp.Parameters["@CallInDateTime"].Value = callInDateTime;

                sp.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error adding line : {e.Message}");
                return false;
            }

            return true;
        }
    }
}
