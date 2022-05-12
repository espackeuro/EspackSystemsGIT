using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using static RadioSequencing.Values;
using CommonTools;
using Android.Views.InputMethods;
using Nito.AsyncEx;
using AccesoDatosXML;
using System.Timers;
using CommonAndroidTools;
using System.Threading;

namespace RadioSequencing
{
    [Activity(Label = "Radio LOGISTICA sequencing")]
    public class InitialCheckingsActivity : AppCompatActivity
    {
        public bool CommandStopped;
        private readonly SynchronizationContext SyncContext;
        private TextView ConsoleChecks { get; set; }
        private ProgressBar ProgressChecks { get; set; }
        private string _mainScreenMode;
        private System.Timers.Timer runAction = new System.Timers.Timer(1000);
        private SqlServerCommands commands = new SqlServerCommands(Values.gDatos);
        private void AddText(string text)
        {
            RunOnUiThread(()=> ConsoleChecks.Text += $"\n{text}");
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.initialCheckings);
            ConsoleChecks = FindViewById<TextView>(Resource.Id.checkConsole);
            ProgressChecks = FindViewById<ProgressBar>(Resource.Id.checkProgress);
            ConsoleChecks.Text = "";
            _mainScreenMode = Intent.GetStringExtra("MainScreenMode");
            commands.Callback += Commands_Callback;
            commands.ErrorCallback += Commands_ErrorCallback;
            runAction.Elapsed += RunAction_Elapsed;
            runAction.Start();


            // Create your application here
        }

        private void Commands_ErrorCallback(object sender, SqlServerCommands.AsyncTaskResponse e)
        {
            RunOnUiThread(() => ConsoleChecks.Text += $"\nERROR: {e.Message}");
        }

        private void Commands_Callback(object sender, SqlServerCommands.AsyncTaskResponse e)
        {
            RunOnUiThread(() =>
            {
                if (e.Message.Substring(0, 2) == "@@")
                {
                    switch (e.Message)
                    {
                        case "@@startprogress":
                            ProgressChecks.Indeterminate = false;
                            ProgressChecks.Max = e.ExtraData.ToInt();
                            ProgressChecks.Progress = 0;
                            break;
                        case "@@progressplus":
                            ProgressChecks.Progress++;
                            break;
                        case "@@endprogress":
                            ProgressChecks.Indeterminate = true;
                            break;
                    }
                }
                else
                    ConsoleChecks.Text += $"\n{e.Message}";
            });
        }

        private async void RunAction_Elapsed(object sender, ElapsedEventArgs e)
        {
            runAction.Stop();
            await ActionGo();
        }

        //protected override void OnStart()
        //{
        //    base.OnStart();
        //    try
        //    {
        //        if (Values.Session == null)
        //            AsyncContext.Run(ActionGo);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        private async Task<bool> ActionGo()
        {
            AddText("Connecting to database SEQUENCING");
            //buttonOk.Enabled = false;
            Values.gDatos.DataBase = "SEQUENCING_TEST";
            //await getDataFromServer();
            //Values.iFt.pushInfo("Creating Session");
            //string _msg = "";
            
            MyDeviceInfo = await commands.GetDeviceInfo(cDeviceInfo.Serial);
            
            
            PendingDataReading = await commands.CheckUnclosedSessions();
            if (PendingDataReading == null)
            {
                PendingDataReading = await commands.CreateNewSession(Values.System, CustomerService, COD3, gDatos.User, MyDeviceInfo.Serial);
            }
            

            
            AddText("Getting service partnumbers");
            
            //await Values.sFt.ChangeProgressVisibility(true);
            var _settings = new Settings { User = Values.gDatos.User, Password = gDatos.Password, Session = Session, Service = CustomerService, COD3 = COD3 };
            await Values.SQLidb.db.ExecuteAsync("DELETE FROM Settings");
            await Values.SQLidb.db.InsertAsync(_settings);
            Values.SQLidb.Complete = true;
            //lets get the partnumbers
            ServicePartnumbers = await commands.GetServicePartnumbers(Values.CustomerService);



            //launch work activity

            var intent = new Intent(this, typeof(MainScreen));
            intent.PutExtra("MainScreenMode", _mainScreenMode);
            StartActivityForResult(intent, 1);



            //await Values.sFt.ChangeProgressVisibility(false);
            return true;


        }



        

    }


}