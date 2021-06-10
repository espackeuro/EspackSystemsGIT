using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Net;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;

namespace SYNCRO_parser
{
    class Program
    {
        public static string filePath { get; set; }
        static void Main(string[] args)
        {
            FileProcess fp = new FileProcess(args[0],args[1]);
            fp.Start();
            //Thread.Sleep(Timeout.Infinite);
        }

    }
    public class FileProcess {
        private string DatabaseServer { get; set; }
        private string FilePath { get; set; }
        private string FileName
        {
            get => Path.GetFileName(FilePath); 
        }
        public FileProcess(string databaseServer, string filePath)
        {
            DatabaseServer = databaseServer;
            FilePath = filePath;
        }
        public async Task Start()
        {
            LogMessage("========================================================");
            LogMessage($"Start processing {FileName}");


            string fileText = "";
            fileText = File.ReadAllText(FilePath);
            LogMessage($"Trying to process file {FilePath} to database server {DatabaseServer}");
            Regex rx = new Regex("'SEQ(?:(?!'SEQ).)*", RegexOptions.Compiled | RegexOptions.Multiline);
            //Regex rxLin = new Regex(@"UNH\+0(\d{4})\+SYNCRO:2'MID\+0\1\+(\d{6}):(\d{4})'CDT\+.*:(.*)'CSG(?:.*):(.*)'SEQ\+(.*)\+(.*)\+(.*):(.*)'ARD.*'SDD\+(\d{6}):(\d{4}).*'SUB.*UNT.*\1", RegexOptions.Compiled | RegexOptions.Multiline);
            // Find matches.
            MatchCollection matches = rx.Matches(fileText);
            foreach (var match in matches)
            {
                //MatchCollection linMatches = rxLin.Matches(match.ToString());
                //var hostName = Dns.GetHostName();
                //var transNumber = linMatches[0].Groups[1].Value;
                //var transDate = linMatches[0].Groups[2].Value;
                //var transTime = linMatches[0].Groups[3].Value;
                //var supplierCode = linMatches[0].Groups[4].Value;
                //var plantCode = linMatches[0].Groups[5].Value;
                //var seqQualifier = linMatches[0].Groups[6].Value;
                //var seqNumber = linMatches[0].Groups[7].Value;
                //var vinNumber = linMatches[0].Groups[8].Value;
                //var eccsSeqNum = linMatches[0].Groups[9].Value;
                //var callInDate = linMatches[0].Groups[10].Value;
                //var callInTime = linMatches[0].Groups[11].Value;

                //LogMessage($"Transmitting data : Sequence Number {seqNumber} -VIN number {vinNumber}");


                //toDataBase(hostName, transNumber, DateTime.ParseExact($"{transDate}:{transTime}", "yyMMdd:HHmm", new CultureInfo("es-ES")),
                //    supplierCode, plantCode, seqQualifier, seqNumber, vinNumber, eccsSeqNum,
                //    DateTime.ParseExact($"{callInDate}:{callInTime}", "yyMMdd:HHmm", new CultureInfo("es-ES")));

                LogMessage("Data transmitted correctly");

            }
            LogMessage($"Moving file {FileName} to archive folder");
            File.Move(FilePath, $"/media/archive/{FileName}", true);
            LogMessage($"File {FileName} processed correctly");
            LogMessage("========================================================");
        }
        private void LogMessage(string message,
                        [CallerMemberName] string callername = "")
        {
            //File.WriteAllText("/root/bin/test.txt", string.Format("[{0}] - Thread-{1}- {2}", callername, Thread.CurrentThread.ManagedThreadId, message));
            System.Console.WriteLine("[{0}] - Thread-{1}- {2}",
                    callername, Thread.CurrentThread.ManagedThreadId, message);
        }
        public bool toDataBase(string hostName, string transNumber, DateTime transDateTime, string supplierCode, string plantCode, string seqQualifier, string seqNumber, string vinNumber, string eccsSeqNum, DateTime callInDateTime)
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                builder.DataSource = DatabaseServer;
                builder.UserID = "sa";
                builder.Password = "5380";
                builder.InitialCatalog = "TRANSMISIONES";
                LogMessage($"Trying to connect to {DatabaseServer}");
                using SqlConnection connection = new SqlConnection(builder.ConnectionString);
                connection.Open();
                LogMessage("Connection OK");
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
                LogMessage("Trying to execute procedure");

                sp.ExecuteNonQuery();
                LogMessage("Procedure OK");

            }
            catch (Exception e)
            {
                LogMessage($"Error adding line : {e.Message}");
                LogMessage("Moving file to error folder");
                File.Move(FilePath, $"/media/archive/error/{FileName}");
                LogMessage($"File {FileName} NOT processed correctly");
                LogMessage("========================================================");
                return false;
            }

            return true;
        }
    }

}
