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

namespace RadioLogisticaDeliveries
{
    public struct QueryResult { public string Rack; public int count; }

    [Activity(Label = "Radio LOGISTICA deliveries", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class MainScreen : AppCompatActivity
    {
        public async Task<DeviceInfo> GetDeviceInfo(string deviceSerial)
        {
            //SendMessage("Getting device info.");
            var _result = new DeviceInfo();
            _result.Serial = deviceSerial;
            using (var _rs = new XMLRS($"Select CM,Code, MainCOD3, TypeFLAGS from Sistemas..ItemsCab where Serial='{deviceSerial}'", Values.gDatos))
            {
                await _rs.OpenAsync();
                if (_rs.RecordCount == 0)
                {
                    //SendError("Device not found in Espack Inventory.");
                    return _result;
                }
                _result.CM = _rs["CM"].ToString();
                _result.DeviceCOD3 = _rs["MainCOD3"].ToString();
                _result.DeviceCode = _rs["Code"].ToString();
                _result.flags = _rs["TypeFLAGS"].ToString();
                //SendMessage($"Device found {_result.CM} assigned to {_result.DeviceCOD3} warehouse");
            }
            return _result;
        }

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.mainLayout);
            // Create your application here


            string _mainScreenMode = Intent.GetStringExtra("MainScreenMode");
            


            Values.hFt = new headerFragment();
            
            var ft = SupportFragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.headerFragment, Values.hFt);
            //ft.Commit();

            if (_mainScreenMode=="NEW")
            {
                var oFt = new orderFragment();
                ft.Replace(Resource.Id.dataInputFragment, oFt);
            } else
            {
                var edFt = new EnterDataFragment();
                ft.Replace(Resource.Id.dataInputFragment, edFt);
                Values.elIntent = new Intent(this, typeof(DataTransferManager));
                StartService(Values.elIntent);
            }



            Values.iFt = new infoFragment(8);
            ft.Replace(Resource.Id.InfoFragment, Values.iFt);

            Values.dFt = new infoFragment(5);
            ft.Replace(Resource.Id.DebugFragment, Values.dFt);

            Values.sFt = new statusFragment();
            ft.Replace(Resource.Id.StatusFragment, Values.sFt);
            ft.Commit();

            //Values.dtm = new DataTransferManager();
            //start the transmission service
            Values.MyDeviceInfo = await GetDeviceInfo(cDeviceInfo.Serial);

            Values.GEO = Values.MyDeviceInfo.flags.Contains("GEOLOCATION");

            EspackCommServer.Server.PropertyChanged += ConnectionServer_PropertyChanged; 
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



        public void changeOrderToEnterDataFragments()
        {
            using (var ft = SupportFragmentManager.BeginTransaction())
            {
                var edFt = new EnterDataFragment();
                ft.Replace(Resource.Id.dataInputFragment, edFt);
                ft.Commit();
            }
        }

        public void changeEnterDataToOrderFragments()
        {
            using (var ft = SupportFragmentManager.BeginTransaction())
            {
                if (Values.oFt != null)
                    Values.oFt.Dispose();
                if (LocatorService.Started)
                    LocatorService.Kill = true;
                if (DataTransferManager.Started)
                    DataTransferManager.Kill = true;
                Values.oFt = new orderFragment();
                ft.Replace(Resource.Id.dataInputFragment, Values.oFt);
                ft.Commit();
            }
        }
        public override void OnBackPressed()
        {
        }
    }
}