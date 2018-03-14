using Android.App;
using Android.Widget;
using Android.OS;
using System.Data;
using System.Data.SqlClient;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using System;
using Android.Content;
using CommonAndroidTools;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Android.Views;

namespace logon
{
    using static Values;

    [Activity(Label = "", Theme = "@style/AppTheme.NoActionBar")]
    public class LoginActivityClass : AppCompatActivity
    {
        private EditText txtUser;
        private TextInputEditText txtPwd;
        private TextView txtMsg;
        private TextView txtPkgInfo;

        //private SqlConnection gDatos;
        private string oldVersion;
        private string packageName;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (loginActivityClass == null)
            {
                loginActivityClass = this;
            }
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            //var currentView = LayoutInflater.Inflate(Resource.Layout.LoginScreen, null);

            SetContentView(Resource.Layout.ls);
            //Form Elements
            txtUser = this.FindViewById<EditText>(Resource.Id.txtUser);

            //cUser.Text = "REJ";
            txtPwd = FindViewById<TextInputEditText>(Resource.Id.txtPwd);
            //cPassword.Text = "5380";
            txtMsg = FindViewById<TextView>(Resource.Id.msgText);
            txtPkgInfo = FindViewById<TextView>(Resource.Id.msgPkgInfo);
            //Button event
            //cLoginButton.Click += CLoginButton_Click;
            //typeofCaller = Intent.GetStringExtra("ConnectionType") ?? "Net";
            oldVersion = Intent.GetStringExtra("Version");
            packageName = Intent.GetStringExtra("PackageName");
            LogonDetails.ConnectionServer = "appdb.local";
            txtUser.EditorAction += TxtUser_EditorAction;
            txtPwd.EditorAction += TxtPwd_EditorAction;
            txtPkgInfo.Text = string.Format("{0} Version {1}", packageName, oldVersion);
#if DEBUG
            txtUser.Text = "restelles";
            txtPwd.Text = "1312";
#endif
        }
        private void TxtUser_EditorAction(object sender, TextView.EditorActionEventArgs e)
        {
            e.Handled = false;
            if (e.ActionId == Android.Views.InputMethods.ImeAction.Next)
            {
                txtPwd.RequestFocus();
                e.Handled = true;
            }
        }
        private async void TxtPwd_EditorAction(object sender, TextView.EditorActionEventArgs e)
        {
            e.Handled = false;
            if (e.ActionId == Android.Views.InputMethods.ImeAction.Send)
            {
                e.Handled = true;
                await CheckLogin();
            }

        }

        

        public async Task CheckLogin()
        {
            if (txtUser.Text == "" || txtPwd.Text == "")
            {
                txtMsg.Text = "Please input correct User and Password";
            }
            else
            {
                try
                {
                    LogonDetails = await LogonUser.DoLogon(txtUser.Text, txtPwd.Text, "appdb.local", packageName);
                }
                catch (Exception ex)
                {
                    txtMsg.Text = ex.Message;
                    txtUser.Text = "";
                    txtPwd.Text = "";
#if DEBUG
                    txtUser.Text = "restelles";
                    txtPwd.Text = "1312";
#endif
                    txtUser.RequestFocus();
                    return;
                }

                //Intent intent = new Intent();
                //intent.PutExtra("Result", "OK");
                //SetResult(Result.Ok, intent);
                Finish();
            }
        }


        public override void OnBackPressed()
        {

        }
    }

}

