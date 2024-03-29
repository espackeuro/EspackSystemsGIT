using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AccesoDatosNet;
using CommonTools;
using System.Threading;
using System.Threading.Tasks;
using Android.Views.InputMethods;
using CommonAndroidTools;
using Scanner;
using AccesoDatosXML;
using Xamarin.Essentials;

namespace RadioLogisticaDeliveries
{
    public class orderFragment : Fragment
    {
        //private Button buttonOk;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(Activity, savedInstanceState);
            // Create your fragment here
        }
        private EditText orderNumberET;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            var _root = inflater.Inflate(Resource.Layout.enterOrderFt, container, false);
            orderNumberET = _root.FindViewById<EditText>(Resource.Id.orderNumber);
#if DEBUG
// orderNumberET.Text = "726008607";
#endif
            // orderNumberET.
            //5orderNumberET.EditorAction += OrderNumberET_EditorAction;
            orderNumberET.KeyPress += OrderNumberET_KeyPress;
            orderNumberET.InputType = Android.Text.InputTypes.TextFlagCapCharacters;
            //scanner intent
            sScanner.RegisterScannerActivity(Activity, _root, true);
            sScanner.AfterReceive += SScanner_AfterReceive;
            orderNumberET.RequestFocus();
            return _root;
        }

        //private async void SScanner_AfterReceive(object sender, ReceiveEventArgs e)
        //{
        //    var _res=await ActionGo(e.ReceivedData);
        //    if (!_res)
        //        orderNumberET.Text = "";
        //}

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            sScanner.UnregisterScannerActivity();
        }
        private void DisableReadings(object sender)
        {
            ((FragmentActivity)sender).RunOnUiThread(() =>
            {
                orderNumberET.Enabled = false;
            });
        }

        private void EnableReadings(object sender)
        {
            ((FragmentActivity)sender).RunOnUiThread(() =>
            {
                orderNumberET.Enabled = true;
                orderNumberET.Text = "";
            });
        }

        private async void SScanner_AfterReceive(object sender, ReceiveEventArgs e)
        {
            DisableReadings(sender);
            if (Values.scannerIsBusy)
            {
                orderNumberET.Text = "";
                return;
            }

            Values.scannerIsBusy = true;

            //sScanner.AfterReceive -= SScanner_AfterReceive;

                var _scan = e.ReceivedData;
            if (_scan.Substring(0, 2) == "@@" && _scan.Substring(_scan.Length - 2, 2) == "##") //QRCODE
            {
                var _recordList = _scan.Split('|');
                try
                {
                    _scan = _recordList[3];
                }
                catch
                {
                    Toast.MakeText(Activity, "Wrong reading.", ToastLength.Long).Show();
                    Values.iFt.pushInfo("Wrong reading.");
                    EnableReadings(sender);
                    Values.scannerIsBusy = false;
                    return;
                }

            }
            orderNumberET.Text = _scan;
            var _res = await ActionGo(_scan);
            EnableReadings(sender);
            if (_res)
                orderNumberET.Tag = "SCAN";
            Values.scannerIsBusy = false;
        }

        private async void OrderNumberET_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.Event.Action == KeyEventActions.Down && (e.KeyCode == Keycode.Enter || e.KeyCode == Keycode.Tab))
            {
                /*
                if(orderNumberET.Text == Values.gCloseCode)
                {
                    //set alert for executing the task
                    bool dialogResult = await AlertDialogHelper.ShowAsync(Context, "Confirm Close Application", $"This will close the application. Are you sure?", "Close App", "Cancel");
                    if (!dialogResult)
                    {
                        Toast.MakeText(Context, "Cancelled!", ToastLength.Short).Show();
                        return;
                    }
                    
                    var activity = (MainActivity)Context;
                    activity.FinishActivity(0);
                    return;

                }
                */
                orderNumberET.Enabled = false;
                await ActionGo(orderNumberET.Text);
                orderNumberET.Enabled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private async Task<bool> ActionGo(string data)
        {
            if (data == "")
            {
                await cSounds.Error(Activity);
                Toast.MakeText(Activity, "Please enter one valid Order Number", ToastLength.Long).Show();
                data = "";
                return false;
            }

            string _orderNumber;
            string _blockCode;

            if (data.IsNumeric() && data.Length>6)
            {
                _orderNumber = data;
                _blockCode = "";
            } else
            {
                _orderNumber = null;
                _blockCode = data;
            }
            //buttonOk.Enabled = false;
            Values.gDatos.DataBase = "LOGISTICA";
            Values.iFt.pushInfo("Creating Session");
            var _sp = new SPXML(Values.gDatos, "pAddCabReadingSession");
            _sp.AddParameterValue("Block", _blockCode);
            //_sp.AddParameterValue("Service", " ");
            _sp.AddParameterValue("User", Values.gDatos.User);
            _sp.AddParameterValue("orderNumber", _orderNumber);
            try
            {
                await _sp.ExecuteAsync();
            }
            catch (Exception ex)
            {
                Toast.MakeText(Activity, ex.Message, ToastLength.Long).Show();
                Values.iFt.pushInfo(ex.Message);
                data = "";
                //buttonOk.Enabled = true;
                return false;
            }
            Values.iFt.pushInfo("Done");
            Values.gSession = _sp.LastMsg.Substring(3);
            Values.hFt.t2.Text = string.Format("Session: {0}", Values.gSession); 
            Values.gBlock = _sp.ReturnValues()["@Block"].ToString();
            
            if (_orderNumber!=null)
            {
                Values.gOrderNumber = data.ToInt();
                Values.hFt.t4.Text = string.Format("Order: {0}", Values.gOrderNumber);
            }

            Values.gService = _sp.ReturnValues()["@Service"].ToString();

            //update database data
            //await Values.sFt.ChangeProgressVisibility(true);
            var _settings = new Settings { User = Values.gDatos.User, Password = Values.gDatos.Password, Block = Values.gBlock, Order = Values.gOrderNumber, Session = Values.gSession, Service = Values.gService };
            await Values.SQLidb.db.ExecuteAsync("DELETE FROM Settings");
            await Values.SQLidb.db.InsertAsync(_settings);
            await getDataFromServer();
            Values.SQLidb.Complete = true;
            //await Values.sFt.ChangeProgressVisibility(false);
            return true;


        }

        //method to get all the data from sql server
        private async Task getDataFromServer()
        {
            //Dismiss Keybaord
            InputMethodManager imm = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
            //get location if android >= 5.1
 /*
            if (Values.GEO)
            {
                var androindVersion = Android.OS.Build.VERSION.SdkInt;
                if (androindVersion >= BuildVersionCodes.LollipopMr1)
                {


                    using (var rs = new XMLRS("Select CMP_INTEGER from Datos_Empresa where Codigo='LOC_TIME'", Values.gDatos))
                    {
                        await rs.OpenAsync();
                        if (rs.RecordCount != 0)
                            Values.LocTime = rs["CMP_INTEGER"].ToInt();
                    }
                    var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(30));
                    var ini = await Geolocation.GetLastKnownLocationAsync();
                    Location location = null;
                    //try
                    //{
                    //    location = await Geolocation.GetLocationAsync(request);
                    //}
                    //catch (Exception ex)
                    //{
                    //    Console.WriteLine(ex.Message);
                    //}
                    if (location != null)
                    {
                        var _locData = new DataLocation() { Accuracy = location.Accuracy, Course = location.Course, Altitude = location.Altitude, Latitude = location.Latitude, Longitude = location.Longitude, Speed = location.Speed, Timestamp = location.Timestamp };
                        await _locData.ToDB();
                    }
                    Activity.StartService(new Intent(Activity, typeof(LocatorService)));
                    LocatorService.Active = true;
                }
            } */
            imm.HideSoftInputFromWindow(orderNumberET.WindowToken, 0);
            int _progress = 0;
            if (Values.gOrderNumber!=0)
            {
                Values.iFt.pushInfo("Getting Label Data");
                //data from labels for checkng
                using (var _rs = new XMLRS(string.Format("select numero,partnumber,qty,cajas,rack,Modulo from etiquetas where Numero_orden={0} and Tipo='PEQ'", Values.gOrderNumber), Values.gDatos))
                {
                    await _rs.OpenAsync();
                    Values.sFt.socksProgress.Indeterminate = false;
                    Values.sFt.socksProgress.Max = _rs.RecordCount / 5;
                    Values.sFt.socksProgress.Progress = 0;
                    foreach (var r in _rs.Rows)
                    {
                        await Values.SQLidb.db.InsertAsync(new Labels { Serial = r["numero"].ToString(), Partnumber = r["partnumber"].ToString(), qty = r["qty"].ToInt(), boxes = r["cajas"].ToInt(), rack = r["rack"].ToString(), mod = r["Modulo"].ToString() });
                        _progress++;
                        if (_progress % 5 == 0 )
                            Values.sFt.socksProgress.Progress++;
                    }
                    Values.sFt.socksProgress.Indeterminate = true;
                    //Values.sFt.CheckQtyTotal= _rs.Rows.Count;
                    //Values.sFt.UpdateInfo();
                }
                Values.iFt.pushInfo("Done");
            }

            Values.iFt.pushInfo("Getting RacksBlocks table");
            //data from RacksBlocks table
            using (var _rs = new XMLRS(string.Format("select Block,Rack from RacksBlocks where service='{0}' and dbo.CheckFlag(flags,'OBS')=0", Values.gService), Values.gDatos))
            {
                await _rs.OpenAsync();
                Values.sFt.socksProgress.Indeterminate = false;
                Values.sFt.socksProgress.Max = _rs.RecordCount / 5;
                Values.sFt.socksProgress.Progress = 0;
                foreach (var r in _rs.Rows)
                {
                    await Values.SQLidb.db.InsertAsync(new RacksBlocks { Block = r["Block"].ToString(), Rack = r["Rack"].ToString() });
                    _progress++;
                    if (_progress % 5 == 0)
                        Values.sFt.socksProgress.Progress++;
                }
            }
            Values.sFt.socksProgress.Indeterminate = true;
            Values.iFt.pushInfo("Done");
            Values.iFt.pushInfo("Getting PartnumberRacks table");
            //data from RacksBlocks table
            // [dvalles] 20220513: Added isnull to the alternate column so it doesn't raise an error later. When the column gets a null value, the column is not created in the SQLidb object
            string _prquery = $"Select p.Rack,Partnumber,MinBoxes,MaxBoxes,p.flags,alternate=isnull(dbo.fObtenerValor(ExtraData,'ALTREAD'),'') from PartnumbersRacks p inner join RacksBlocks r on r.Rack=p.Rack where p.service='{Values.gService}' " +
#if DEBUG
                $"and r.Block='{Values.gBlock}' " +
#endif                    
                $"and dbo.CheckFlag(r.flags,'OBS')=0";
            using (var _rs = new XMLRS(_prquery, Values.gDatos))
            {
                await _rs.OpenAsync();
                Values.sFt.socksProgress.Indeterminate = false;
                Values.sFt.socksProgress.Max = _rs.RecordCount / 5;
                Values.sFt.socksProgress.Progress = 0;
                foreach (var r in _rs.Rows)
                {
                    await Values.SQLidb.db.InsertAsync(new PartnumbersRacks { Rack = r["Rack"].ToString(), Partnumber = r["Partnumber"].ToString(), MinBoxes = r["MinBoxes"].ToInt(), MaxBoxes = r["MaxBoxes"].ToInt(), alternate= r["alternate"].ToString() });
                    _progress++;
                    if (_progress % 5 == 0)
                        Values.sFt.socksProgress.Progress++;
                }
            }
            Values.sFt.socksProgress.Indeterminate = true;
            Values.iFt.pushInfo("Done loading database data");
            Values.elIntent = new Intent(Activity, typeof(DataTransferManager));
            Activity.StartService(Values.elIntent);
            DataTransferManager.Active = true;
            ((MainScreen)Activity).changeOrderToEnterDataFragments();
        }

    }
}