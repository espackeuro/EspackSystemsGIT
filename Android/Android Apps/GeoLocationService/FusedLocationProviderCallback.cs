using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Gms.Location;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;

namespace GeoLocationService
{
    public interface ILocationInfoManage
    {
        Task LocationInfoManage(LocationResult loc);
    }
    public class FusedLocationProviderCallback : LocationCallback
    {

        public override void OnLocationAvailability(LocationAvailability locationAvailability)
        {
            Log.Debug("FusedLocationProviderSample", "IsLocationAvailable: {0}", locationAvailability.IsLocationAvailable);
        }


        public async override void OnLocationResult(LocationResult result)
        {
            if (result.Locations.Any())
            {
                var loc = new DeviceLocation();
                var lr = result.Locations.First();
                loc.Accuracy = lr.Accuracy;
                loc.Altitude = lr.Altitude;
                loc.Latitude = lr.Latitude;
                loc.Longitude = lr.Longitude;
                loc.Bearing = lr.Bearing;
                loc.Speed = lr.Speed;
                loc.Transferred = false;
                loc.Status = IData.dataStatus.DATABASE;
                await GeoLocationServiceClass.DB.InsertAsync(loc);
                if (GeoLocationServiceClass.Context is ILocationInfoManage)
                    await ((ILocationInfoManage)GeoLocationServiceClass.Context).LocationInfoManage(result);
            }
        }

    }
}