using System;
//using Android.App;
//using Android.Content;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using Android.OS;
using System.Data;
using System.Data.SqlClient;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Content.PM;
using Java.Util.Zip;
using I18N.Common;
using I18N.West;
using Android.Support.V7.App;


namespace logon
{
    using Android.Widget;
    using CommonAndroidTools;
    using System.Threading.Tasks;
    using static Values;

    public static class Values
    {
        public static LogonDetailsStruct LogonDetails { get; set; } = new LogonDetailsStruct();
        public static LoginActivityClass loginActivityClass { get; set; }
    }

    [Activity(Label = "Espack Logon", MainLauncher = true, Icon = "@drawable/keyiconWhite")]
    public class MainActivity : AppCompatActivity
    {
        private string CallingPkg { get; set; }
        protected override void OnCreate(Bundle bundle)
        {
            CallingPkg = Intent.GetStringExtra("CallingPackage");
            var a = CP1252.GetEncoding("utf-32");
            base.OnCreate(bundle);
            //for the image barcode scanner
            //MobileBarcodeScanner.Initialize(Application);
            //version control
            Context context = this.ApplicationContext;
            LogonDetails.Version = context.PackageManager.GetPackageInfo(context.PackageName, 0).VersionName;
            ApplicationInfo ai = PackageManager.GetApplicationInfo(context.PackageName, 0);
            ZipFile zf = new ZipFile(ai.SourceDir);
            ZipEntry ze = zf.GetEntry("classes.dex");
            long time = ze.Time;
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(Math.Round(time / 1000D)).ToLocalTime();
            zf.Close();
            LogonDetails.Version = string.Format("{0}.{1}", LogonDetails.Version, dtDateTime.ToString("yyyyMMdd.Hmmss"));

            if (LogonDetails.User==null || CallingPkg== null)
            {
                var intent = new Intent(this, typeof(LoginActivityClass));
                intent.SetAction(Intent.ActionView);
                intent.AddCategory(Intent.CategoryLauncher);
                intent.PutExtra("Version", LogonDetails.Version);
                intent.PutExtra("PackageName", CallingPkg ?? "com.espack.logon");
                StartActivityForResult(intent, 0);
            }
        }
        protected async override void OnStart()
        {
            base.OnStart();
            CallingPkg = Intent.GetStringExtra("CallingPackage");
            Intent.RemoveExtra("CallingPackage");
            if (LogonDetails.User != null && CallingPkg != null)
            {
                LogonDetails = await LogonUser.DoLogon(LogonDetails.User, LogonDetails.Password, "appdb.local", CallingPkg);
                LaunchPackage(CallingPkg, this);
                CallingPkg = null;
                return;
            }
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok && requestCode == 0)
            {
                string Result = data.GetStringExtra("Result");
                if (Result == "OK")
                {
                    if (CallingPkg == null)
                    {
                        var intent = new Intent(this, typeof(MainScreen));
                        StartActivityForResult(intent, 1);
                    } else
                    {
                        MainActivity.LaunchPackage(CallingPkg, this);
                    }
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
        public static void LaunchPackage(string packageName, Context context)
        {
            try
            {
                Intent intent = context.PackageManager.GetLaunchIntentForPackage(packageName);
                ((Activity)context).RunOnUiThread(async () => 
                {
                    //check if package exists
                    if (intent == null)
                    {
                        var pd = ProgressDialog.Show(context, "", "Downloading...", false, false);
                        pd.SetProgressStyle(ProgressDialogStyle.Spinner);
                        try
                        {
                            await UpdatePackage.DoUpdatePackage(packageName, context);
                            intent = context.PackageManager.GetLaunchIntentForPackage(packageName);
                        }
                        catch (Exception ex)
                        {
                            Toast.MakeText(context, ex.Message, ToastLength.Long);
                            pd.Dismiss();
                            return;
                        }
                        pd.Dismiss();

                    }
                    //check if package is updated
                    if (UpdatePackage.CheckPackageIsOutdated(packageName, Values.LogonDetails.Version, context))
                    {
                        bool dialogResult = await AlertDialogHelper.ShowAsync(context, "New version found", "Do you want to update your current program?", "Yes", "No");
                        if (dialogResult)
                        {
                            var pd = ProgressDialog.Show(context, "", "Downloading...", false, false);
                            pd.SetProgressStyle(ProgressDialogStyle.Spinner);
                            try
                            {
                                await UpdatePackage.DoUpdatePackage(packageName, context);
                                intent = context.PackageManager.GetLaunchIntentForPackage(packageName);
                            }
                            catch (Exception ex)
                            {
                                var builder = new Android.Support.V7.App.AlertDialog.Builder(context);
                                builder.SetTitle("ERROR");
                                builder.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                                builder.SetMessage(ex.Message);
                                builder.SetNeutralButton("OK", delegate
                                {
                                });
                            }
                            pd.Dismiss();
                        }
                    }

                    intent.PutExtra("USR", LogonDetails.User);
                    intent.PutExtra("PWD", LogonDetails.Password);
                    intent.PutExtra("SRV", "db01.local");
                    intent.PutExtra("VERSION", LogonDetails.Version);
                    intent.PutExtra("FULLNAME", LogonDetails.FullName);
                    context.StartActivity(intent);
                });
            }
            catch (Exception ex)
            {
                Toast.MakeText(context, ex.Message, ToastLength.Long);
            }
        }
    }
}

