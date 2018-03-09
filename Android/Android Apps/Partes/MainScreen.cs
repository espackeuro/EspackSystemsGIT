using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Util;
using Android.Views;
using Android.Widget;
using static Android.Content.PM.PackageManager;

namespace logon
{
    [Activity(Label = "Partnumber Info", WindowSoftInputMode = SoftInput.AdjustPan, Theme = "@style/AppTheme.NoActionBar")]
    public class MainScreen : AppCompatActivity
    {
        public ImageButton Button1_1 { get; set; }
        public Button Button1_2 { get; set; }
        public Button Button2_1 { get; set; }
        public Button Button2_2 { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Selector);
            Button1_1 = FindViewById<ImageButton>(Resource.Id.button1_1);
            Button1_2 = FindViewById<Button>(Resource.Id.button1_2);
            Button2_1 = FindViewById<Button>(Resource.Id.button2_1);
            Button2_2 = FindViewById<Button>(Resource.Id.button2_2);
            Button1_2.Text = "";
            Button2_1.Text = "";
            Button2_2.Text = "";
            //disable non unsed buttons
            Button1_2.Enabled = false;
            Button2_1.Enabled = false;
            Button2_2.Enabled = false;
            Button1_1.Click += Button1_1_Click;
        }

        private void Button1_1_Click(object sender, EventArgs e)
        {
            try
            {
                Intent intent = PackageManager.GetLaunchIntentForPackage("com.espack.partnumberinfo");
                if (intent != null)
                {
                    intent.PutExtra("USR", Values.User);
                    intent.PutExtra("PWD", Values.Pwd);
                    intent.PutExtra("SRV", "db01.local");
                    intent.PutExtra("VERSION", Values.Version);
                    intent.PutExtra("FULLNAME", LoginActivity.LoginDetails.FullName);
                    StartActivity(intent);
                }
            }
            catch (Exception ex)
            {
                Log.Error("LOGON", ex.Message);
            }
            /*
            var intent = new Intent(this, typeof(PartnumberInfo));
            StartActivityForResult(intent, 0);
            */
        }
    }
}