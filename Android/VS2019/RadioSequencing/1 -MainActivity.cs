using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using AccesoDatosNet;
using LogonScreen;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Java.Util.Zip;
using Android.Content.PM;
using Android.Icu.Text;
using CommonAndroidTools;
using AccesoDatosXML;

namespace RadioSequencing
{
    public enum WorkModes { READING, CHECKING }
    static class Values
    {
        public static cAccesoDatosXML gDatos = new cAccesoDatosXML();
        public static string System { get; set; } = "LOGISTICA";
        public static string CustomerService { get; set; } = "KAUTEX";
        public static string COD3 { get; set; } = "CRA";
        
        public static string Version { get; set; }

        public static string CloseCode = "000";
        private static string _session;
        public static string Session
        {
            get => _session;
            set
            {
                if (hFt.t2?.Text != null)
                    hFt.t2.Text = $"Session: {value}";
                _session = value;
            }
        }
        public static int LocTime { get; set; } = 30; //time between gps readings
        public static bool IsLocationService { get; set; }
        public static string GeoSession { get; set; }
        public static DataReadingList DataReadingList = new DataReadingList();
        public static int MaxSequencesPerSession { get; } = 12;
        //public static void SetCurrentRack(string Rack)
        //{
        //    hFt.Activity.RunOnUiThread(() =>
        //    {
        //        _rack = Rack;
        //        hFt.t5.Text = string.Format("Rack: {0}", _rack);
        //    });
        //}
        public static headerFragment hFt { get; set; }
        public static infoFragment iFt { get; set; }
        public static infoFragment dFt { get; set; }
        public static statusFragment sFt { get; set; }
        public static DataTransferManager dtm { get; set; }
        public static LocatorService ls { get; set; }
        public static Intent elIntent { get; set; }
        public static SQLiteDatabase SQLidb { get; set; }

        public async static Task CreateDatabase()
        {
            SQLidb.CreateDatabase();
            await SQLidb.db.CreateTableAsync<DeviceLocation>();
            await SQLidb.db.CreateTableAsync<Referencias>();
            await SQLidb.db.CreateTableAsync<ScannedData>();
            await SQLidb.db.CreateTableAsync<Settings>();
            
            // to do what to do when readings exist
        }
        public async static Task EmptyDatabase()
        {
            await SQLidb.db.ExecuteAsync("Delete from Referencias ");
            await SQLidb.db.DropTableAsync<Referencias>();
            await SQLidb.db.ExecuteAsync("Delete from ScannedData ");
            await SQLidb.db.DropTableAsync<ScannedData>();
            await SQLidb.db.ExecuteAsync("Delete from Settings ");
            await SQLidb.db.DropTableAsync<Settings>();
            await SQLidb.db.ExecuteAsync("Delete from DeviceLocation ");
            await SQLidb.db.DropTableAsync<DeviceLocation>();

        }
        public static WorkModes WorkMode { get; set; }

    }

    

    [Activity(Label = "RadioSequencing", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //version control
            Context context = this.ApplicationContext;
            Values.Version = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
            ApplicationInfo ai = PackageManager.GetApplicationInfo(context.PackageName, 0);
            ZipFile zf = new ZipFile(ai.SourceDir);
            ZipEntry ze = zf.GetEntry("classes.dex");
            long time = ze.Time;
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(Math.Round(time / 1000D)).ToLocalTime();
            zf.Close();
            Values.Version = string.Format("{0}.{1}", Values.Version, dtDateTime.ToString("yyyyMMdd.Hmmss"));
#if DEBUG
            var intent = new Intent(this, typeof(LogonScreenClass));
            intent.SetAction(Intent.ActionMain);
            intent.AddCategory(Intent.CategoryLauncher);
            intent.PutExtra("ConnectionType", "Socks");
            intent.PutExtra("Version", Values.Version);
            intent.PutExtra("PackageName", "Radio Sequencing");
            StartActivityForResult(intent, 0);
            Values.WorkMode = WorkModes.READING;
#else
            Values.gDatos.DataBase = "SEQUENCING";
            Values.gDatos.Server = "net.espackeuro.com";
            Values.gDatos.User = "SA";
            Values.gDatos.Password = "5380";
            string _mainScreenMode = "NEW";
            Values.SQLidb = new SQLiteDatabase("SEQUENCING");
            var intent = new Intent(this, typeof(MainScreen));
            intent.PutExtra("MainScreenMode", _mainScreenMode);
            StartActivityForResult(intent, 1);
#endif
        }
        protected override async void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok && requestCode == 0)
            {
                string Result = data.GetStringExtra("Result");
                if (Result == "OK")
                {
                    Values.gDatos.DataBase = "SEQUENCING";
                    Values.gDatos.Server = "net.espackeuro.com";
                    Values.gDatos.User = LogonDetails.User;
                    Values.gDatos.Password = LogonDetails.Password;
                    string _mainScreenMode = "NEW";
                    //create sqlite database
                    Values.SQLidb = new SQLiteDatabase("SEQUENCING");
                    if (Values.SQLidb.Exists) //check if database exists
                    {
                        //Values.SQLidb.CreateDatabase(); //link the file to the sqlite database
                        await Values.CreateDatabase(); //create tables if not exist
                        Settings _settings = await Values.SQLidb.db.Table<Settings>().FirstOrDefaultAsync(); //get settings of persistent data
                        if (_settings != null && _settings.User == Values.gDatos.User && _settings.Password == Values.gDatos.Password) //if not empty and user and password matches the logon ones
                        {
                            //var _lastXfec = from r in Values.SQLidb.db.Table<ScannedData>().ToListAsync().Result orderby r.xfec descending select xfec;
                            try
                            {
                                var _lastRecord = await Values.SQLidb.db.QueryAsync<ScannedData>("Select * from ScannedData order by idreg desc limit 1");
                                //ScannedData _lastRecord = await Values.SQLidb.db.Table<ScannedData>().FirstOrDefaultAsync(); //get the last record time added, nullable datetime type
                                if (_lastRecord.Count !=0 && (DateTime.Now - _lastRecord[0].xfec).Minutes < 60) //if time less than one hour
                                {
                                    bool _a1, _a2 = false;
                                    _a1 = await AlertDialogHelper.ShowAsync(this, "Warning", "There are incomplete session data in the device, do you want to continue last session or erase and start a new one?", "ERASE", "CONTINUE SESSION");
                                    if (_a1) //ERASE
                                    {
                                        _a2 = await AlertDialogHelper.ShowAsync(this, "Warning", "This will erase all pending content present in the device, are you sure?", "ERASE", "CONTINUE SESSION");
                                    }
                                    if (!_a1 || !_a2)
                                    {
                                        Values.Session = _settings.Session;
                                        Values.IsLocationService = _settings.IsLocationService;
                                        Values.COD3 = _settings.COD3;
                                        _mainScreenMode = "CONTINUE";
                                    } else
                                    {
                                        await Values.EmptyDatabase();
                                        await Values.CreateDatabase();
                                    }
                                }
                                else
                                {
                                    await Values.EmptyDatabase();
                                    await Values.CreateDatabase();
                                }
                            } catch(Exception ex) {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            await Values.EmptyDatabase();
                            await Values.CreateDatabase();
                        }
                    }
                    else
                    {
                        await Values.CreateDatabase();
                    }
                    //

                    var intent = new Intent(this, typeof(MainScreen));
                    intent.PutExtra("MainScreenMode", _mainScreenMode);
                    StartActivityForResult(intent, 1);
                    //SetContentView(Resource.Layout.mainLayout);
                }
                else
                {
                    Finish();
                }
            }
            else
            {
                Finish();
            }
        }
        public override void OnBackPressed()
        {
        }
    }
}


