
using SQLite;
using System;
using System.IO;


namespace RadioSequencing
{


    #region Tables
    [Table("Settings")]
    public class Settings
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string Session { get; set; }
        public string Service { get; set; }
        public bool IsLocationService { get; set; }
        public string COD3 { get; set; }
    }

    /*
    [Table("Readings")]
    public class Readings
    {
        [PrimaryKey, AutoIncrement]
        public int idreg { get; set; }
        public string Session { get; set; }
        public string Rack { get; set; }
        public string Partnumber { get; set; }
        public string Service { get; set; }
        public int Qty { get; set; }
        public string LabelRack { get; set; }
    }

    //table Labels
    public class Labels
    {
        [PrimaryKey, AutoIncrement]
        public int idreg { get; set; }
        public string Serial { get; set; }
        public string Partnumber { get; set; }
        public int qty { get; set; }
        public int boxes { get; set; }
        public string rack { get; set; }
        public string mod { get; set; }
    }

    /*
    //table Referencias
    */
    public class Tickets
    {
        [PrimaryKey, AutoIncrement]
        public int idreg { get; set; }
        public string SequenceNumber { get; set; }
        public string TicketVIN { get; set; }
        public string TicketPartnumber { get; set; }
    }
    public class Referencias
    {
        [PrimaryKey]
        public string partnumber { get; set; }
        public string pnPrefix { get; set; }
        public string pnBase { get; set; }
        public string pnSuffix { get; set; }
    }
    /*

    //table RacksBlocks
    public class RacksBlocks
    {
        [PrimaryKey, AutoIncrement]
        public int idreg { get; set; }
        public string Block { get; set; }
        public string Rack { get; set; }
    }

    //table PartnumbersRacks
    public class PartnumbersRacks
    {
        [PrimaryKey, AutoIncrement]
        public int idreg { get; set; }
        public string Rack { get; set; }
        public string Partnumber { get; set; }
        public int MinBoxes { get; set; }
        public int MaxBoxes { get; set; }

    }
    public class SerialTracking
    {
        [PrimaryKey, AutoIncrement]
        public int idreg { get; set; }
        public string Serial { get; set; }
    } 
    
    */
    public class ScannedData
    {
        [PrimaryKey, AutoIncrement]
        public int idreg { get; set; }
        public string Action { get; set; }
        public string System { get; set; }
        public string CustomerService { get; set; }
        public string Session { get; set; }
        //ticket
        public string SequenceNumber { get; set; }
        public string VINNr { get; set; }
        public string PartnumberSeqLabel { get; set; }
        //partnumber datamatrix
        public string PartnumberLabel { get; set; }
        public string Batch { get; set; }
        //Truck position
        public string TrollLocation { get; set; }
        //Qty
        public int Qty { get; set; }
        public bool Transmitted { get; set; } = false;
        public string TransmissionResult { get; set; } = "";
        public DateTime xfec { get; set; } = DateTime.Now;

    }

    public class DeviceLocation
    {
        [PrimaryKey, AutoIncrement]
        public int idreg { get; set; }
        public string Session { get; set; }
        public double? Accuracy { get; set; }
        public double? Course { get; set; }
        public double? Altitude { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Speed { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public bool Transmitted { get; set; } = false;
        public string TransmissionResult { get; set; } = "";
    }
    
    public static class ScannedDataControl
    {
        public static string ProcedureParameters(this ScannedData SD)
        {
            return string.Format($"@IdSession='{SD.Session}',@SequenceNumber='{SD.SequenceNumber}',@TicketVIN='{SD.VINNr}',@TicketPartnumber='{SD.PartnumberSeqLabel}',@TicketExtraData='',@LabelPartnumber='{SD.PartnumberLabel}',@LabelExtraData='|BATCH:{SD.Batch}|TOLLEYLOCATION:{SD.TrollLocation}|',@Flags='',@ExtraData=''");
        }
        public static  infoData ToInfoData(this ScannedData SD)
        {
            var result = new infoData();
            switch (SD.Action)
            {
                case "ADD":
                    result.c0 = string.Format("ADD");
                    result.c1 = string.Format("PN:{0}", SD.PartnumberLabel);
                    //result.c2 = string.Format("R:{0}", SD.LabelRack);
                    result.c2 = string.Format("Q:{0}", SD.Qty);
                    result.c3 = SD.xfec.ToShortTimeString();
                    break;/*
                case "CHECK":
                    result.c0 = string.Format("CHECK");
                    result.c1 = string.Format("SERIAL:{0}", SD.Serial);
                    result.c2 = string.Format("R:{0}", SD.Rack);
                    break;*/
                case "CLOSE":
                    result.c0 = string.Format("CLOSE");
                    break;
            }
            return result;
        }
    }
    
    public static class DeviceLocationControl
    {
        public static string ProcedureParameters(this DeviceLocation DL)
        {
            return $"@Session='{DL.Session}', @Accuracy={DL.Accuracy.ToString().Replace(',','.')},@Altitude={(DL.Altitude ?? -1).ToString().Replace(',', '.')},@Course={(DL.Course ?? -1).ToString().Replace(',', '.')},@Latitude={DL.Latitude.ToString().Replace(',', '.')},@Longitude={DL.Longitude.ToString().Replace(',', '.')},@Speed={(DL.Speed ?? -1).ToString().Replace(',', '.')},@Timestamp='{DL.Timestamp.DateTime}'";
        }
    }

    #endregion
    public class SQLiteDatabase
    {
        public EventSQLiteAsyncConnection db;
        public bool Complete { get; set; } = false;
        public string DatabaseName { get; private set; }
        public bool Exists
        {
            get
            {
                return File.Exists(dbPath);
            }
        }
        public string dbPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), DatabaseName + ".db3");
            }
        }
        public void CreateDatabase()
        {
            //dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName+".db3");
            db = new EventSQLiteAsyncConnection(dbPath);
            db.AfterInsert += Db_AfterInsert;
            db.AfterUpdate += Db_AfterUpdate;

        }

        private async void Db_AfterUpdate(object sender, AfterUpdateEventArgs e)
        {
            var _pending = (await Values.SQLidb.db.FindAsync<ScannedData>(r => r.Transmitted == false) != null);
            if (_pending != pendingData)
                pendingData = _pending;
        }

        public void DropDatabase()
        {
            db = null;
            if (File.Exists(dbPath))
                File.Delete(dbPath);
            Complete = false;
        }
        private void Db_AfterInsert(object sender, AfterInsertEventArgs e)
        {
            if (e.ItemInserted is ScannedData)
            {
                //((ScannedData)e.ItemInserted).xfec = DateTime.Now;
                //await Values.SQLidb.db.UpdateAsync((ScannedData)e.ItemInserted);
                Values.dFt.pushInfo(((ScannedData)e.ItemInserted).ToInfoData());
            }
            var _pending = (Values.SQLidb.db.FindAsync<ScannedData>(r => r.Transmitted == false) != null);
            if (_pending != pendingData)
                pendingData = _pending;
        }

        public SQLiteDatabase(string _databaseName)
        {
            DatabaseName = _databaseName;
        }
        public bool pendingData { get; private set; }

    }

}