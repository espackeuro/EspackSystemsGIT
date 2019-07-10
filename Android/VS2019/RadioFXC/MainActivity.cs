using AccesoDatosNet;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Internal;
using Java.Util.Zip;
using LogonScreen;
using System;

namespace RadioFXC
{
    public static class Values
    {
        public static cAccesoDatosNet gDatos = new cAccesoDatosNet();
        public static cAccesoDatosNet gDatosLOG = new cAccesoDatosNet();
        public static string gFTPServer;
        public static string gFTPUser;
        public static string gFTPDir;
        public static string gFTPPassword;
        public static string gService;
        public static string Version;
        public static BottomNavigationItemView MenuItem1(Activity context)
        {
            return context.FindViewById<BottomNavigationItemView>(Resource.Id.navigation_1);
        }
        public static BottomNavigationItemView MenuItem2(Activity context)
        {
            return context.FindViewById<BottomNavigationItemView>(Resource.Id.navigation_2);
        }
        public static BottomNavigationItemView MenuItem3(Activity context)
        {
            return context.FindViewById<BottomNavigationItemView>(Resource.Id.navigation_3);
        }
        public static BottomNavigationItemView menuItem2;
        public static BottomNavigationItemView menuItem3;
    }

    [Activity(Label = "*Radio REPAIRS", MainLauncher = true, Icon = "@drawable/ic_launcher")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {

            //var a = CP1252.GetEncoding("utf-32");
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
            var intent = new Intent(this, typeof(LogonScreenClass));
            intent.SetAction(Intent.ActionMain);
            intent.AddCategory(Intent.CategoryLauncher);
            intent.PutExtra("ConnectionType", "Net");
            intent.PutExtra("Version", Values.Version);
            intent.PutExtra("PackageName", "Radio repairs");
            StartActivityForResult(intent, 0);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok && requestCode == 0)
            {
                string Result = data.GetStringExtra("Result");
                if (Result == "OK")
                {
                    Values.gDatos.DataBase = "REPAIRS";
                    Values.gDatos.Server = "net.espackeuro.com";

#if DEBUG
                    //Values.gDatos.Server = "WOLDB";
#endif

                    Values.gDatos.User = LogonDetails.User;
                    Values.gDatos.Password = LogonDetails.Password;


                    //var RS = new DynamicRS("Select Datos=CMP_Varchar from datosEmpresa where codigo='FTP_DATA'",Values.gDatos);
                    //RS.Open();
                    //Values.gFTPServer = RS["Datos"].ToString().Split('|')[1]; //"10.201.10.1";
                    //Values.gFTPDir = RS["Datos"].ToString().Split('|')[2]; ;//"/FTP/";
                    //Values.gFTPUser = RS["Datos"].ToString().Split('|')[3];//"logon";
                    //Values.gFTPPassword = RS["Datos"].ToString().Split('|')[4]; ;//"*logon*";
                    Values.gFTPServer = "ftprepairs.espackeuro.com";
                    Values.gFTPDir = "/FTP/";
                    Values.gFTPUser = "logon";
                    Values.gFTPPassword = "*logon*";

                    // gDatos for LOGISTICA
                    Values.gDatosLOG.DataBase = "LOGISTICA";
                    Values.gDatosLOG.Server = "net.espackeuro.com";
                    Values.gDatosLOG.User = LogonDetails.User;
                    Values.gDatosLOG.Password = LogonDetails.Password;

                    var intent = new Intent(this, typeof(ServiceSelection));
                    StartActivityForResult(intent, 1);
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
    }


}

