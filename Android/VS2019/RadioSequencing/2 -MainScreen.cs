using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Support.V4;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using AccesoDatosNet;
using Android.Util;
using AccesoDatosXML;
using Xamarin.Essentials;
using CommonAndroidTools;
using static RadioSequencing.Values;
using CommonTools;
using Android.Views.InputMethods;
using Nito.AsyncEx;

namespace RadioSequencing
{
    public struct QueryResult { public string Rack; public int count; }

    [Activity(Label = "Radio LOGISTICA sequencing", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class MainScreen : AppCompatActivity
    {
        private string _mainScreenMode;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.mainLayout);
            // Create your application here


            _mainScreenMode = Intent.GetStringExtra("MainScreenMode");


            var ft = SupportFragmentManager.BeginTransaction();

            Values.iFt = new infoFragmentSequence();
            ft.Replace(Resource.Id.InfoFragment, Values.iFt);

            Values.hFt = new headerFragment();
            ft.Replace(Resource.Id.headerFragment, Values.hFt);
            //ft.Commit();

            Values.dFt = new infoFragment(5);
            ft.Replace(Resource.Id.DebugFragment, Values.dFt);

            Values.tFt = new trolleyFragment();
            ft.Replace(Resource.Id.trolleyFragment, Values.tFt);

            Values.sFt = new statusFragment();
            ft.Replace(Resource.Id.StatusFragment, Values.sFt);
            ft.Commit();

            ft = SupportFragmentManager.BeginTransaction();
            var edFt = new EnterDataFragment();
            ft.Replace(Resource.Id.dataInputFragment, edFt);
            ft.Commit();
            //Values.dtm = new DataTransferManager();
            //start the transmission service
            //await ActionGo();
            

            try
            {
                if (Values.Session == null)
                    AsyncContext.Run(ActionGo);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            



            EspackCommServer.Server.PropertyChanged += ConnectionServer_PropertyChanged;
            Values.elIntent = new Intent(this, typeof(DataTransferManager));
            StartService(Values.elIntent);
            DataTransferManager.Active = true;

        }



        //public override View OnCreateView(string name, Context context, IAttributeSet attrs)
        //{
        //    //info when recovering
        //    if (_mainScreenMode != "NEW")
        //    {

        //        var _query = from p in Values.SQLidb.db.Table<ScannedData>().ToListAsync().Result group p by p.Rack into grp select new { Rack = grp.Key, qty = grp.Count(), id = grp.Min(x => x.idreg) };
        //        foreach (var x in _query.OrderBy(r => r.id))
        //            Values.iFt.pushInfo(x.Rack, x.qty.ToString());
        //        Values.iFt.pushInfo("Racks previously read");
        //    }
        //    return base.OnCreateView(name, context, attrs);

        //}
        private async void ConnectionServer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName=="Status")
            {
                switch (EspackCommServer.Server.Status)
                {
                    case CommStatus.OFFLINE:
                        await Values.sFt.commProgressStatus(ProgressStatusEnum.CONNECTED);
                        break;
                    case CommStatus.CONNECTED:
                        await Values.sFt.commProgressStatus(ProgressStatusEnum.TRANSMITTING);
                        break;
                    case CommStatus.ERROR:
                        await Values.sFt.commProgressStatus(ProgressStatusEnum.DISCONNECTED);
                        break;
                }
            }
        }



        public void ChangeToEnterDataFragments()
        {
            using (var ft = SupportFragmentManager.BeginTransaction())
            {
                var edFt = new EnterDataFragment();
                ft.Replace(Resource.Id.dataInputFragment, edFt);
                ft.Commit();
            }
        }

        public override void OnBackPressed()
        {
        }
        private async Task<bool> ActionGo()
        {
            //buttonOk.Enabled = false;
            Values.gDatos.DataBase = "SEQUENCING";
            //await getDataFromServer();
            //Values.iFt.pushInfo("Creating Session");
            //string _msg = "";
            var _sp = new SPXML(Values.gDatos, "SEQUENCING..pSequencingSessionCabAdd");
            //_sp.AddParameterValue("msg", _msg);
            _sp.AddParameterValue("System", Values.System);
            _sp.AddParameterValue("CustomerService", CustomerService);
            _sp.AddParameterValue("COD3", COD3);
            _sp.AddParameterValue("UserCode", gDatos.User);
            try
            {
                await _sp.ExecuteAsync();
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                //Values.iFt.pushInfo(ex.Message);
                //buttonOk.Enabled = true;
                return false;
            }
            //iFt.pushInfo("Done");
            Session = _sp.LastMsg.Substring(3);
            //hFt.t2.Text = string.Format("Session: {0}", Values.Session);
            //get if service should have gps control
            /*
            using (var rs = new XMLRS($"Select GEO=dbo.CheckFlag(flags,'GEO'), COD3 from {Values.System}..Servicios WHERE Codigo='{CustomerService}'", Values.gDatos))
            {
                await rs.OpenAsync();
                if (rs.RecordCount != 0)
                {
                    IsLocationService = rs["GEO"].ToInt() == 1;
                    COD3 = rs["COD3"].ToString();
                    sFt.LocationVisibility = true;
                }
                else
                {
                    IsLocationService = false;
                    sFt.LocationVisibility = false;
                }
            }
            // create GeoSession
            Values.gDatos.DataBase = "GEO";
            using (var sp = new SPXML(gDatos, "GEO..pGeoSessionCabAdd"))
            {
                sp.AddParameterValue("COD3", COD3);
                sp.AddParameterValue("System", Values.System);
                sp.AddParameterValue("Service", CustomerService);
                sp.AddParameterValue("ServiceSession", Session);
                sp.AddParameterValue("UserCode", gDatos.User);
                try
                {
                    await sp.ExecuteAsync();
                    Values.GeoSession = sp.LastMsg.Substring(3);
                }
                catch (Exception ex)
                {
                    Toast.MakeText(this, $"Failure starting GeoLocation: {ex.Message}", ToastLength.Long).Show();
                    //Values.iFt.pushInfo(ex.Message);
                    Values.IsLocationService = false;
                    //return false;
                    //buttonOk.Enabled = true;
                }

                Values.gDatos.DataBase = "LOGISTICA";
                
        
            }
            */
            //update database data
            //await Values.sFt.ChangeProgressVisibility(true);
            var _settings = new Settings { User = Values.gDatos.User, Password = gDatos.Password, Session = Session, Service = CustomerService, COD3 = COD3 };
            await Values.SQLidb.db.ExecuteAsync("DELETE FROM Settings");
            await Values.SQLidb.db.InsertAsync(_settings);
            Values.SQLidb.Complete = true;
            //await Values.sFt.ChangeProgressVisibility(false);
            return true;


        }

        //method to get all the data from sql server

    }
}