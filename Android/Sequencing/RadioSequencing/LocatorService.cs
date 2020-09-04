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

namespace RadioSequencing
{
    [Service]
    public class LocatorService : Service
    {
        public static bool Active { get; set; } = false;
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public async Task DoWork()
        {
            while (true)
            {
                SpinWait.SpinUntil(() => Active);
                Thread.Sleep(Values.LocTime*1000);
                await RetrieveLocation();
            }
        }

        private async Task RetrieveLocation()
        {
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
            catch (Exception ex)
            {
                Values.sFt.SetLocationInfo();
                // Unable to get location
            }

        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            new Task(async () => await DoWork()).Start();
            return StartCommandResult.Sticky;
        }
    }
}