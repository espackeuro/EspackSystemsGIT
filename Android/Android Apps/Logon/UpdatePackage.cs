using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace logon
{
    public static class UpdatePackage
    {
        public static bool CheckPackageIsOutdated(string packageName, string NetVersion, Context context)
        {
            var NetVersionArray = NetVersion.Split('.');
            NetVersion = string.Format("{0}.{1}", NetVersionArray[0], NetVersionArray[1]);
            var LocalVersion = context.PackageManager.GetPackageInfo(packageName, 0).VersionName;
            var LocalVersionArray = LocalVersion.Split('.');
            LocalVersion = string.Format("{0}.{1}", LocalVersionArray[0], LocalVersionArray[1]);
            return (LocalVersion != NetVersion);
        }
        public static async Task DoUpdatePackage(string packageName, Context context)
        {
            using (var c = new WebClient())
            {
                var URL = string.Format("http://portal.espackeuro.com/{0}.apk", packageName);
                var _local = string.Format("{0}/{1}.apk", Android.OS.Environment.ExternalStorageDirectory.Path, packageName);
                try
                {
                    await c.DownloadFileTaskAsync(URL, _local);
                } catch (Exception ex)
                {
                    Toast.MakeText(context, ex.Message, ToastLength.Long);
                    return;
                }
                if (!File.Exists(_local))
                {
                    throw new Exception("Error: the file was not downloaded correctly, the app will not be updated.");
                }
                /*
                    var builder = new Android.Support.V7.App.AlertDialog.Builder(context);
                    builder.SetTitle("ERROR");
                    builder.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                    builder.SetMessage("Error: the file was not downloaded correctly, the app will not be updated.");
                    builder.SetNeutralButton("OK", delegate
                    {
                        Intent intnt = new Intent();
                        intnt.PutExtra("Result", "OK");
                        SetResult(Result.Ok, intnt);
                        Finish();
                    });
                    RunOnUiThread(() => { builder.Create().Show(); });
                }
                */
                var intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(Android.Net.Uri.FromFile(new Java.IO.File(_local)), "application/vnd.android.package-archive");
                intent.SetFlags(ActivityFlags.NewTask);
                ((Activity)context).StartActivity(intent);
            }

        }
    }
}
