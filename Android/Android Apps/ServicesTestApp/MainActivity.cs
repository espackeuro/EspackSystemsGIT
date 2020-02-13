using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Gms.Location;
using GeoLocationService;
using Android.Content;
using System.IO;
using Environment = System.Environment;
using System.Threading.Tasks;

namespace ServicesTestApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, ILocationInfoManage
    {
        FusedLocationProviderClient fusedLocationProviderClient;
        Button getLastLocationButton;
        bool isGooglePlayServicesInstalled;
        bool isRequestingLocationUpdates;
        TextView latitude;
        internal TextView latitude2;
        LocationCallback locationCallback;
        LocationRequest locationRequest;
        TextView longitude;
        internal TextView longitude2;
        TextView provider;
        internal TextView provider2;
        View rootLayout;
        internal Button requestLocationUpdatesButton;
        Intent LocationIntent;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            rootLayout = FindViewById(Resource.Id.root_layout);

            // UI to display last location
            getLastLocationButton = FindViewById<Button>(Resource.Id.get_last_location_button);
            latitude = FindViewById<TextView>(Resource.Id.latitude);
            longitude = FindViewById<TextView>(Resource.Id.longitude);
            provider = FindViewById<TextView>(Resource.Id.provider);

            // UI to display location updates
            requestLocationUpdatesButton = FindViewById<Button>(Resource.Id.request_location_updates_button);
            latitude2 = FindViewById<TextView>(Resource.Id.latitude2);
            longitude2 = FindViewById<TextView>(Resource.Id.longitude2);
            provider2 = FindViewById<TextView>(Resource.Id.provider2);

            LocationIntent = new Intent(this, typeof(GeoLocationServiceClass));
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Location.db3");
            GeoLocationServiceClass.DB = new SQLite.SQLiteAsyncConnection(databasePath);
            GeoLocationServiceClass.LocationCallback = new FusedLocationProviderCallback();
            GeoLocationServiceClass.Context = this;
            StartService(LocationIntent);
        }

        private async void LocationCallback_LocationResult(object sender, LocationCallbackResultEventArgs e)
        {
            var LastLocation = await GeoLocationServiceClass.DB.Table<DeviceLocation>().OrderByDescending(r => r.IdReg).FirstOrDefaultAsync();
            latitude.Text = LastLocation.Latitude.ToString();
            longitude.Text = LastLocation.Longitude.ToString();
            provider.Text = LastLocation.IdReg.ToString();
        }

        protected override void OnDestroy()
        {
            StopService(LocationIntent);
            base.OnDestroy();
        }

        public async Task LocationInfoManage(LocationResult loc)
        {
            var LastLocation = await GeoLocationServiceClass.DB.Table<DeviceLocation>().OrderByDescending(r => r.IdReg).FirstOrDefaultAsync();
            latitude.Text = LastLocation.Latitude.ToString();
            longitude.Text = LastLocation.Longitude.ToString();
            provider.Text = LastLocation.IdReg.ToString();

            latitude2.Text = loc.LastLocation.Latitude.ToString();
            longitude2.Text = loc.LastLocation.Longitude.ToString();
        }
    }
}

