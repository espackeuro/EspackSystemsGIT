using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//using Android.App;
using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace RadioSequencing
{
    public class statusFragment : Fragment
    {
        public ProgressBar socksProgress { get; set; }
        public TextView readingsInfo { get; set; }
        public TextView checkingsInfo { get; set; }
        private TextView locationInfo { get; set; }
        public void SetLocationInfo(DataLocation loc = null)
        {
            if (loc == null)
                Activity.RunOnUiThread(() => locationInfo.Text = "Latitude: ---, Longitude: ---, Altitude: ---");
            else
                Activity.RunOnUiThread(() => locationInfo.Text = $"Latitude: {loc.Latitude}, Longitude: {loc.Longitude}, Altitude: {loc.Altitude}");
        }
        public bool LocationVisibility
        {
            get => locationInfo.Visibility == ViewStates.Visible;
            set
            {
                if (value)
                    locationInfo.Visibility = ViewStates.Visible;
                else
                    locationInfo.Visibility = ViewStates.Invisible;
            }
        }
        public int ReadQtyReceived
        {
            get
            {
                return Values.SQLidb.db.Table<ScannedData>().Where(r => r.Action == "ADD").CountAsync().Result;
            }
        }
        public int ReadQtyTransmitted
        {
            get
            {
                return Values.SQLidb.db.Table<ScannedData>().Where(r => r.Transmitted == true && r.Action=="ADD").CountAsync().Result;
                
            }
        }


        public int CheckQtyReceived
        {
            get
            {
                return Values.SQLidb.db.Table<ScannedData>().Where(r => r.Action == "CHECK").CountAsync().Result;
            }
        }
        public int CheckQtyTransmitted
        {
            get
            {
                return Values.SQLidb.db.Table<ScannedData>().Where(r => r.Transmitted == true && r.Action == "CHECK").CountAsync().Result;
            }
        }
        public void UpdateInfo()
        {
            Activity.RunOnUiThread(() =>
            {
                readingsInfo.Text = readingsInfoText;
                checkingsInfo.Text = checkingsInfoText;
            });
        }
        public void Clear()
        {
            Activity.RunOnUiThread(() =>
            {
                readingsInfo.Text = "";
                checkingsInfo.Text = "";
            });
        }
        private string readingsInfoText
        {
            get
            {
                return string.Format("{0}/{1}", ReadQtyReceived, ReadQtyTransmitted);
            }
        }
        private string checkingsInfoText
        {
            get
            {
                return string.Format("{0}/{1}", CheckQtyReceived, CheckQtyTransmitted);
            }
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        
        public Task ChangeProgressVisibility(bool visible)
        {
            return Task.Run(() => Activity.RunOnUiThread(() =>
             {
                 socksProgress.Visibility = visible ? ViewStates.Visible : ViewStates.Gone;
             }));  
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            var _root = inflater.Inflate(Resource.Layout.statusFragment, container, false);
            socksProgress = _root.FindViewById<ProgressBar>(Resource.Id.socksProgress);
            socksProgress.IndeterminateDrawable.SetColorFilter(Color.Blue, PorterDuff.Mode.Multiply);
            //socksProgress.ProgressDrawable.SetColorFilter(Color.Red, PorterDuff.Mode.SrcIn);
            socksProgress.Visibility = ViewStates.Gone;
            readingsInfo = _root.FindViewById<TextView>(Resource.Id.readingsInfo);
            checkingsInfo = _root.FindViewById<TextView>(Resource.Id.checkingsInfo);
            locationInfo = _root.FindViewById<TextView>(Resource.Id.locationInfo);
            LocationVisibility = false;
            UpdateInfo();
            return _root;
        }
        public Task commProgressStatus(ProgressStatusEnum _status)
        {
            return Task.Run(() => 
            Activity.RunOnUiThread(() =>
            {
                switch (_status)
                {
                    case ProgressStatusEnum.DISCONNECTED:
                        socksProgress.Visibility = ViewStates.Gone;
                        socksProgress.IndeterminateDrawable.SetColorFilter(null);
                        socksProgress.IndeterminateDrawable.SetColorFilter(Color.Red, PorterDuff.Mode.SrcIn);
                        socksProgress.Visibility = ViewStates.Visible;
                        break;
                    case ProgressStatusEnum.CONNECTED:
                        socksProgress.Visibility = ViewStates.Gone;
                        socksProgress.IndeterminateDrawable.SetColorFilter(null);
                        socksProgress.IndeterminateDrawable.SetColorFilter(Color.Green, PorterDuff.Mode.SrcIn);
                        socksProgress.Visibility = ViewStates.Visible;
                        break;
                    case ProgressStatusEnum.TRANSMITTING:
                        socksProgress.Visibility = ViewStates.Gone;
                        socksProgress.IndeterminateDrawable.SetColorFilter(null);
                        socksProgress.IndeterminateDrawable.SetColorFilter(Color.Blue, PorterDuff.Mode.SrcIn);
                        socksProgress.Visibility = ViewStates.Visible;
                        break;
                    case ProgressStatusEnum.GONE:
                        socksProgress.Visibility = ViewStates.Gone;
                        break;
                }
            }));
        }

    }

    public enum ProgressStatusEnum { DISCONNECTED, CONNECTED, TRANSMITTING, GONE}
}