using System;
using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using AccesoDatosNet;
using Android.Support.V7.App;
using CommonAndroidTools;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using AccesoDatos;
using AccesoDatosXML;
using ObjectFactory;
using Android.Support.Design.Widget;
using Android.Views;
namespace LogonScreen
{
    public static class LogonDetails
    {
        public static string User { get; set; }
        public static string Password { get; set; }
        public static string ConnectionServer { get; set; }
        public static string FullName { get; set; }
    }

    [Activity(Label = "Logon Screen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Locked)]
    public class LogonScreenClass : AppCompatActivity
    {
        private TextInputEditText cUser;
        private TextInputEditText cPassword;
        private TextView cMsgText;
        private TextView cPackageInfoText;
        private cAccesoDatos gDatos;
        private FrameLayout progressBarHolder;
        private string typeofCaller;
        private string version;
        private string packageName;

        //Main method
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //get the layout from Resources
            SetContentView(Resource.Layout.LogonScreen);
            //Form Elements
            cUser = FindViewById<TextInputEditText>(Resource.Id.User);
            cUser.SetSingleLine();
            cUser.EditorAction += CUser_EditorAction; ;
            //cUser.Text = "REJ";
            cPassword = FindViewById<TextInputEditText>(Resource.Id.Password);
            cPassword.EditorAction += CPassword_EditorAction;
            //cPassword.Text = "5380";
            cMsgText = FindViewById<TextView>(Resource.Id.msgText);
            cPackageInfoText = FindViewById<TextView>(Resource.Id.msgPkgInfo);
            progressBarHolder = FindViewById<FrameLayout>(Resource.Id.progressBarHolder);
            //Button event
            typeofCaller = Intent.GetStringExtra("ConnectionType") ?? "Net";
            version = Intent.GetStringExtra("Version");
            packageName = Intent.GetStringExtra("PackageName");
            //            cPackageInfoText.Text = string.Format("{0} Version {1}", packageName, version);

            LogonDetails.ConnectionServer = "net.espackeuro.com";//typeofCaller == "Net" ? "net.espackeuro.com" : "logon.espackeuro.com";
            switch (typeofCaller)
            {
                case "Net":
                    gDatos = (cAccesoDatosNet)CObjectFactory.CreateObject("Conn", typeofCaller, serial: cDeviceInfo.Serial);
                    break;
                case "Socks":
                    gDatos = (cAccesoDatosXML)CObjectFactory.CreateObject("Conn", typeofCaller, serial: cDeviceInfo.Serial);
                    break;

            };

            cPackageInfoText.Text = string.Format("{0} Version {1}", packageName, version);
#if DEBUG
            cUser.Text = "dvalles";
            cPassword.Text = "1893";
#endif
            // [dvalles] 20220520: Recover the user/password values from the previous session
            if (!String.IsNullOrEmpty(Intent.GetStringExtra("User")))
            {
                cUser.Text = Intent.GetStringExtra("User");
                cPassword.Text = Intent.GetStringExtra("Password");
                DoThings();
            }

        }

        private async void CPassword_EditorAction(object sender, TextView.EditorActionEventArgs e)
        {
            if (e.ActionId == Android.Views.InputMethods.ImeAction.Done)
            {
                await DoThings();
            }
        }

        private void CUser_EditorAction(object sender, TextView.EditorActionEventArgs e)
        {
            if (e.ActionId == Android.Views.InputMethods.ImeAction.Next)
            {
                cPassword.RequestFocus();
            }
        }

        protected override void OnStart()
        {
            base.OnStart();

        }
        //to cancel back button in Android
        public override void OnBackPressed()
        {

        }
        public void Alert(string text)
        {
            var _ad = new Android.App.AlertDialog.Builder(this)
                .SetTitle("Alert")
                .SetMessage(text)



                ;
        }

        private async Task DoThings()
        {

            if (cUser.Text == "" || cPassword.Text == "")
            {
                cMsgText.Text = "Please input correct User and Password";
            }
            else
            {
                this.RunOnUiThread(() =>
                {
                    cUser.Enabled = false;
                    cPassword.Enabled = false;
                });
                gDatos.DataBase = "SISTEMAS";
                gDatos.Server = LogonDetails.ConnectionServer;
                gDatos.User = "SA";
                gDatos.Password = "5380";
                bool error = false;

                try
                {
                    await gDatos.ConnectAsync();
                    //RunOnUiThread(async () => { });
                }
                catch (Exception ex)
                {
                    var builder = new Android.Support.V7.App.AlertDialog.Builder(this);
                    builder.SetTitle("ERROR");
                    builder.SetIcon(Android.Resource.Drawable.IcDialogAlert);
                    builder.SetMessage("Error: " + ex.Message);
                    builder.SetNeutralButton("OK", delegate
                    {
                        Intent intent = new Intent();
                        intent.PutExtra("Result", "ERROR");
                        SetResult(Result.Ok, intent);
                        Finish();
                    });
                    RunOnUiThread(() => { builder.Create().Show(); });
                    error = true;
                }
                if (!error)
                {
                    RSFrame _RS;
                    _RS = (RSFrame)CObjectFactory.CreateObject("RS", typeofCaller, "select date=getdate()", gDatos);
                    await _RS.OpenAsync();
                    gDatos.Close();
                    SPFrame LogonSP;
                    LogonSP = (SPFrame)CObjectFactory.CreateObject("SP", typeofCaller, gDatos, "pLogonUser");
                    LogonSP.AddParameterValue("User", cUser.Text);
                    LogonSP.AddParameterValue("Password", cPassword.Text);
                    LogonSP.AddParameterValue("Origin", packageName.ToUpper());
                    LogonSP.AddParameterValue("FullName", "");
                    string _version = "123456";
                    string _packageName = "123456789";
                    LogonSP.AddParameterValue("Version", _version);
                    LogonSP.AddParameterValue("PackageName", _packageName);
                    try
                    {
                        await LogonSP.ExecuteAsync();
                        if (LogonSP.LastMsg.Substring(0, 2) != "OK")
                            throw new Exception(LogonSP.LastMsg);
                        else
                        {
                            Toast.MakeText(this, "Logon OK!", ToastLength.Short).Show();
                            LogonDetails.User = LogonSP.ReturnValues()["@User"].ToString();
                            LogonDetails.Password = LogonSP.ReturnValues()["@Password"].ToString();
                            LogonDetails.FullName = LogonSP.ReturnValues()["@FullName"].ToString();
                            _version = LogonSP.ReturnValues()["@Version"].ToString();
                            var _versionArray = _version.Split('.');
                            _version = string.Format("{0}.{1}", _versionArray[0], _versionArray[1]);
                            var versionArray = version.Split('.');
                            version = string.Format("{0}.{1}", versionArray[0], versionArray[1]);
                            _packageName = LogonSP.ReturnValues()["@PackageName"].ToString();
#if DEBUG
                            //if (true)
                            if(Convert.ToSingle(_version) >Convert.ToSingle(version) )
#else
                            if(Convert.ToSingle(_version) >Convert.ToSingle(version) )
#endif


                            {
                                bool dialogResult = await AlertDialogHelper.ShowAsync(this, "New version found", "Do you want to update your current program?", "Yes", "No");
                                if (dialogResult)
                                {
                                    try
                                    {
                                        Window.SetFlags(Android.Views.WindowManagerFlags.NotTouchable, Android.Views.WindowManagerFlags.NotTouchable);
                                        progressBarHolder.Visibility = ViewStates.Visible;
                                        await UpdatePackageURL(_packageName);
                                        //pd.Dismiss();
                                        progressBarHolder.Visibility = ViewStates.Gone;
                                        Window.ClearFlags(WindowManagerFlags.NotTouchable);
                                    }
                                    catch (Exception ex)
                                    {
                                        Window.ClearFlags(WindowManagerFlags.NotTouchable);
                                        cMsgText.Text = string.Format("Error updating app, {0}: {1}", ex.Message, ex.InnerException.Message);
                                        Window.ClearFlags(WindowManagerFlags.NotTouchable);
                                    }

                                }
                            }
                            Intent intent = new Intent();
                            intent.PutExtra("Result", "OK");
                            SetResult(Result.Ok, intent);
                            Finish();
                        }
                    }
                    catch (Exception ex)
                    {
                        cMsgText.Text = string.Format("{0}: {1}", ex.Message, ex.InnerException.Message);
                        cUser.Text = "";
                        cPassword.Text = "";
#if DEBUG
                        cUser.Text = "restelles";
                        cPassword.Text = "1312";
#endif
                        cUser.RequestFocus();
                    }
                }
                this.RunOnUiThread(() =>
                {
                    cUser.Enabled = true;
                    cPassword.Enabled = true;
                });
            }
        }

        //private async Task UpdatePackage(string packageName)
        //{
        //    var credentials = new NetworkCredential("logon", "*logon*");
        //    var _c = new WebDAVClient.Client(credentials);
        //    _c.Server = @"https://nextcloud.espackeuro.com";
        //    _c.BasePath = @"/remote.php/dav/files/logon/Android/APK/";
        //    var _local = string.Format("{0}/{1}.apk", Android.OS.Environment.ExternalStorageDirectory.Path, packageName);
        //    try
        //    {
        //        var stream = await _c.Download(String.Format("{0}/{1}.apk", _c.BasePath, packageName));
        //        using (FileStream fs = File.OpenWrite(_local))
        //            await stream.CopyToAsync(fs);

        //        //var items = await _c.List();
        //        //foreach (var item in items)
        //        //{
        //        //    var stream = await _c.Download(item.Href);
        //        //    using (FileStream fs = File.OpenWrite(string.Format(string.Format("{0}/{1}", Android.OS.Environment.ExternalStorageDirectory.Path, item.DisplayName))))
        //        //        await stream.CopyToAsync(fs);
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    var intent = new Intent(Intent.ActionView);
        //    intent.SetDataAndType(Android.Net.Uri.FromFile(new Java.IO.File(_local)), "application/vnd.android.package-archive");
        //    intent.SetFlags(ActivityFlags.NewTask);
        //    StartActivity(intent);
        //}
        private async Task UpdatePackageURL(string packageName)
        {
            using (var c = new WebClient())
            {
                var URL = string.Format("http://portal.espackeuro.com/{0}.apk", packageName);
                var _local = string.Format("{0}/{1}.apk", Android.OS.Environment.ExternalStorageDirectory.Path, packageName);
                try
                {
                    await c.DownloadFileTaskAsync(URL, _local);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                if (!File.Exists(_local))
                {
                    var builder = new Android.Support.V7.App.AlertDialog.Builder(this);
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
                var intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(Android.Net.Uri.FromFile(new Java.IO.File(_local)), "application/vnd.android.package-archive");
                intent.SetFlags(ActivityFlags.NewTask);
                StartActivity(intent);
            }

        }
    }
}
