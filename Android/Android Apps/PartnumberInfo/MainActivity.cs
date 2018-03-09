using Android.App;
using Android.Widget;
using Android.OS;
using System.Data.SqlClient;

namespace PartnumberInfo
{
    using Android.Content;
    using static Values;
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

    [Activity(Label = "PartnumberInfo", MainLauncher = false)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //oldVersion = Intent.GetStringExtra("Version");
            base.OnCreate(savedInstanceState);
#if DEBUG
            User = "sa";
            Pwd = "5380";
            Server = "db01.local";
            Version = "DEBUG";
            FullName = "PEPITO PÉREZ";
#else
            User = Intent.GetStringExtra("USR");
            Pwd = Intent.GetStringExtra("PWD");
            Server = Intent.GetStringExtra("SRV");
            Version = Intent.GetStringExtra("VERSION");
            FullName = Intent.GetStringExtra("FULLNAME");
#endif
            var intent = new Intent(this, typeof(PartnumberInfo));
            StartActivityForResult(intent, 0);
            // Set our view from the "main" layout resource
           // SetContentView(Resource.Layout.Main);
        }
    }
}

