using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RadioSequencing
{
    public class DataLocation : cData
    {
        public double? Accuracy { get; set; }
        public double? Course { get; set; }
        public double? Altitude { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double? Speed { get; set; }
        public DateTimeOffset Timestamp { get; set; }

        public override Task<bool> doCheckings()
        {
            _status = dataStatus.READ;
            return Task.FromResult(true);
        }
        public override async Task<bool> ToDB()
        {
            try
            {
                await Values.SQLidb.db.InsertAsync(new DeviceLocation() {Session= Values.GeoSession, Accuracy =Accuracy, Course=Course, Altitude=Altitude, Latitude=Latitude, Longitude=Longitude,Speed=Speed,Timestamp=Timestamp, Transmitted = false });
            }
            catch (Exception ex)
            {
                _errorMessage = ex.Message;
                _status = dataStatus.ERROR;
                return false;
            }
            _status = dataStatus.DATABASE;
            return true;
        }
    }
}