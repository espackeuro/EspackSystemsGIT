using Android.App;
using Android.Widget;
using Android.OS;
using System.Data.SqlClient;
using Android.Content;
using Android.Support.V7.App;
using System;
using ZXing.Mobile;
using static PartnumberInfo.Values;

namespace PartnumberInfo
{
    public static class Values
    {
        public static SqlConnection gDatos;
        public static string User { get; set; }
        public static string Pwd { get; set; }
        public static string Server { get; set; }
        public static string Version { get; set; }
        public static string FullName { get; set; }
        public static HeaderFragment hF { get; set; }
        public static DataInputFragment diF { get; set; }
        public static DataOutputFragment doF { get; set; }
        public static StatusFragment sF { get; set; }
    }

    [Activity(Label = "PartnumberInfo", MainLauncher = true, Icon = "@drawable/info")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Toast.MakeText(this, "Pollo", ToastLength.Short).Show();
            //oldVersion = Intent.GetStringExtra("Version");
            base.OnCreate(savedInstanceState);
            //for the image barcode scanner
            MobileBarcodeScanner.Initialize(Application);
/*
            User = "sa";
            Pwd = "5380";
            Server = "db01.local";
            Values.Version = "DEBUG";
            FullName = "PEPITO PÉREZ";
*/

            try
            {
                User = Intent.GetStringExtra("USR");
                if (User == null)
                {
                    Intent i = PackageManager.GetLaunchIntentForPackage("com.espack.logon");
                    i.PutExtra("CallingPackage", "com.espack.partnumberinfo");
                    StartActivity(i);
                    return;
                }
                Pwd = Intent.GetStringExtra("PWD");
                Server = Intent.GetStringExtra("SRV");
                Values.Version = Intent.GetStringExtra("VERSION");
                FullName = Intent.GetStringExtra("FULLNAME");
            } catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Short).Show();
                User = "sa";
                Pwd = "5380";
                Server = "db01.local";
                Values.Version = "DEBUG";
                FullName = "PEPITO PÉREZ";
            }

            var intent = new Intent(this, typeof(PartnumberInfo));
            StartActivityForResult(intent, 0);
            // Set our view from the "main" layout resource
           // SetContentView(Resource.Layout.Main);
           
        }
    }
}

