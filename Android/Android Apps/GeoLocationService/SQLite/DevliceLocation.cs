using System;
using SQLite;
using SQLiteDataObjects;

namespace GeoLocationService
{
    [Table("DeviceLocation")]
    public class DeviceLocation: SQLiteDataObjects.GenericRecord
    {
        [PrimaryKey, AutoIncrement]
        public override int IdReg { get; set; }
        public string Session { get; set; }
        public double? Accuracy { get; set; }
        public double? Bearing { get; set; }
        public double? Altitude { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Speed { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string TransmissionResult { get; set; } = "";
    }

    //public class DeviceLocationInterface : GenericDataObject<DeviceLocation>
    //{

    //}
}
