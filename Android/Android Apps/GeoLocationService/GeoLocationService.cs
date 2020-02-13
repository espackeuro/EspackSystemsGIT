using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.Gms.Common;
using Android.Gms.Common.Apis;
using Android.Gms.Location;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SQLite;
using SQLiteDataObjects;

namespace GeoLocationService
{
    [Service]
    public class GeoLocationServiceClass : Service
    {
        public static LocationCallback LocationCallback { get; set; }
        public static LocationRequest LocationRequest { get; set; }
        public static FusedLocationProviderClient fusedLocationProviderClient;
        public static SQLiteAsyncConnection DB { get; set; }
        public static int Session { get; set; }
        public static Context Context { get; set; }
        public override IBinder OnBind(Intent intent)
        {
            throw new NotImplementedException();
        }

        private Timer elTimer;
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            if (IsGooglePlayServicesInstalled())
            {
                LocationRequest = new LocationRequest()
                                  .SetPriority(LocationRequest.PriorityHighAccuracy)
                                  .SetInterval(20000)
                                  .SetFastestInterval(20000);
                fusedLocationProviderClient = LocationServices.GetFusedLocationProviderClient(this);

                elTimer = new Timer(1000);
                elTimer.Elapsed += ElTimer_Elapsed;
                elTimer.Enabled = true;
            }
            else
            {
                // If there is no Google Play Services installed, then this sample won't run.
                Log.Error("Error","Needs Google Play services.");
                throw new Exception("Needs Google Play services.");
            }
            return StartCommandResult.Sticky;
        }

        public override bool StopService(Intent name)
        {
            fusedLocationProviderClient.RemoveLocationUpdates(LocationCallback);
            return base.StopService(name);
        }

        private async void ElTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            elTimer.Enabled = false;
            await DB.CreateTableAsync<DeviceLocation>();
            if (Context != null)
                ((Activity)Context).RunOnUiThread(async () => { await fusedLocationProviderClient.RequestLocationUpdatesAsync(LocationRequest, LocationCallback); });
            else
            {
                var callbackIntent = PendingIntentFactory.
                fusedLocationProviderClient.RequestLocationUpdatesAsync(locationRequest);
            }
        }

        bool IsGooglePlayServicesInstalled()
        {
            var queryResult = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
            if (queryResult == ConnectionResult.Success)
            {
                Log.Info("MainActivity", "Google Play Services is installed on this device.");
                return true;
            }

            if (GoogleApiAvailability.Instance.IsUserResolvableError(queryResult))
            {
                var errorString = GoogleApiAvailability.Instance.GetErrorString(queryResult);
                Log.Error("MainActivity", "There is a problem with Google Play Services on this device: {0} - {1}",
                          queryResult, errorString);
            }

            return false;
        }
    }
}