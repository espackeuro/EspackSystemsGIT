using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Essentials;

namespace RadioLogisticaDeliveries
{
    [Service]
    public class LocatorService : Service
    {
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        public static bool Started { get; set; } = false;
        public static bool Active { get; set; } = false;
        public static bool Kill { get; set; } = false;
        //public async Task DoWork()
        //{
        //    while (true)
        //    {
        //        SpinWait.SpinUntil(() => Active);
        //        Thread.Sleep(Values.LocTime * 1000);
        //        await RetrieveLocation();
        //    }
        //}
        private System.Timers.Timer elTimer;
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            //new Task(async () => await DoWork()).Start();
            //var elTimer = new Timer(LocationChecker.RetrieveLocation, autoEvent, 1000, Values.LocTime * 1000);
            elTimer = new System.Timers.Timer(Values.LocTime * 1000);
            elTimer.Elapsed += ElTimer_Elapsed;
            elTimer.AutoReset = true;
            elTimer.Enabled = true;
            Started = true;
            Kill = false;
            return StartCommandResult.Sticky;

        }
        public override void OnDestroy()
        {
            elTimer.Stop();
            elTimer.Dispose();
            Started = false;
            Active = false;
        }

        private async void ElTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Kill)
            {
                StopSelf();
                return;
            }
            if (Active)
                await LocationChecker.RetrieveLocation();
        }
    }

    public static class LocationChecker {
        private static bool retrieving = false;
        public static async Task RetrieveLocation()
        {
            if (retrieving)
                return;
            retrieving = true;
            try
            {
                //var kk = await Geolocation.GetLastKnownLocationAsync();
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(30));
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {

                    //Values.iFt.SetMessage($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    var _locData = new DataLocation() { Accuracy = location.Accuracy, Course = location.Course, Altitude = location.Altitude, Latitude = location.Latitude, Longitude = location.Longitude, Speed = location.Speed, Timestamp = location.Timestamp };
                    Values.sFt.SetLocationInfo(_locData);
                    await _locData.ToDB();
                }
                else Values.sFt.SetLocationInfo();
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                retrieving = false;
                return;
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                retrieving = false;
                return;                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                retrieving = false;
                return;                // Handle permission exception
            }
            catch (Exception ex)
            {
                retrieving = false;
                return;                // Unable to get location
            }
            retrieving = false;
            return;
        }
    }


}