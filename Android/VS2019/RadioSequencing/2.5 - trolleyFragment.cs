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
using Android.Graphics;
using static RadioSequencing.Values;
using CommonAndroidTools;

namespace RadioSequencing
{
    public enum GapStatus { EMPTY, FILLING, FILLED, ERASED, ERROR }

    public class TrolleyGap
    {
        public int Order { get; set; }
        public DataReading Data { get; set; }
        public TextView Visual { get; set; }
        public GapStatus Status { get; private set; }
        public void SetStatus(GapStatus status, Context context)
        {
            Status = status;
            ((FragmentActivity)context).RunOnUiThread(() =>
            {
                switch (status)
                {
                    case GapStatus.EMPTY:
                        Visual.SetBackgroundColor(Color.White);
                        Visual.SetTextColor(Color.Black);
                        Visual.Text = "-";
                        break;
                    case GapStatus.FILLING:
                        Visual.SetBackgroundColor(Color.LightGreen);
                        Visual.SetTextColor(Color.Black);
                        break;
                    case GapStatus.FILLED:
                        Visual.SetBackgroundColor(Color.LightBlue);
                        Visual.SetTextColor(Color.Black);
                        break;
                    case GapStatus.ERASED:
                        Visual.SetBackgroundColor(Color.White);
                        Visual.SetTextColor(Color.Black);
                        Visual.Text = "-";
                        break;
                    case GapStatus.ERROR:
                        Visual.SetBackgroundColor(Color.Red);
                        Visual.SetTextColor(Color.White);
                        break;
                }
            });
        }

        public void FillData(DataReading data, Context context=null)
        {
            Data = (DataReading)data.Clone();
            if (context !=null)
            {
                if (data.Qty == 0)
                    SetStatus(GapStatus.ERROR, context);
                else
                    SetStatus(GapStatus.FILLED, context);
                Visual.Text = Data.SequenceNumber;
            }
        }
        public void Clear(Context context = null)
        {
            SetStatus(GapStatus.EMPTY, context);
            Data = null;
        }
        public void Erase(Context context = null)
        {
            SetStatus(GapStatus.ERASED, context);
            Data = null;
        }
    }
    

    public class TrolleyClass
    {
        private string _trolleyNumber;
        public string TrolleyNumber
        {
            get => _trolleyNumber;
            set
            {
                if (hFt?.t2?.Text != null)
                    hFt.t2.Text = $"Trolley: {value}";
                _trolleyNumber = value;
            }
        }

        public int UsedGaps
        {
            get
            {
                return Gaps.Where(x => x.Value.Status == GapStatus.FILLED || x.Value.Status == GapStatus.ERROR).Count();
            }
        }

        public DataReading this[int i]
        {
            get
            {
                var _key = string.Format("g{0}", i.ToString("D2"));
                return Gaps[_key].Data;
            }
        }

        public Dictionary<string, TrolleyGap> Gaps = new Dictionary<string, TrolleyGap>();

        public void Clear(Context context)
        {
            foreach (var g in Gaps.Values)
            {
                g.Clear(context);
            }
        }
        public void FillData(string location, DataReading data, Context context=null)
        {
            Gaps[location].FillData(data, context);
        }
        
        public void SetStatus(string location, GapStatus status, Context context)
        {
            Gaps[location].SetStatus(status, context);
        }
    }

    public class trolleyFragment : Fragment
    {
        public TrolleyClass Trolley { get; set; } = new TrolleyClass();
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public trolleyFragment()
        {
            for (int j = 1; j <= Values.MaxSequencesPerSession; j++)
            {
                var location = string.Format("g{0}", j.ToString("D2"));
                Trolley.Gaps[location] = new TrolleyGap() { Order = j };
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var _root = inflater.Inflate(Resource.Layout.trolleyFt, container, false);
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            for (int j = 1; j <= Values.MaxSequencesPerSession; j++)
            {
                var location = string.Format("g{0}", j.ToString("D2"));
                int resId = Resources.GetIdentifier(location, "id", Activity.PackageName);
                var tv = _root.FindViewById<TextView>(resId);
                Trolley.Gaps[location].Visual = _root.FindViewById<TextView>(resId);
                Trolley.Gaps[location].Visual.Typeface = Typeface.Monospace;
                Trolley.Gaps[location].Visual.Touch += TrolleyFragment_Touch;
                Trolley.Gaps[location].SetStatus(GapStatus.EMPTY, Activity);
            }
            return _root;
        }
        //to avoid repeated touches
        private bool IsBeingTouched = false;
        public bool EnableDeleting { get; set; } = true;
        private async void TrolleyFragment_Touch(object sender, View.TouchEventArgs e)
        {
            if (!IsBeingTouched && EnableDeleting)
            {
                try
                {
                    IsBeingTouched = true;
                    var gap = Trolley.Gaps.Where(g => g.Value.Visual.Text == ((TextView)sender).Text).FirstOrDefault();
                    //check if it is the last gap with data
                    if (Trolley.Gaps.Values.Where(o => o.Order > gap.Value.Order && o.Data != null).FirstOrDefault() != null)
                    {
                        IsBeingTouched = false;
                        return;
                    }


                    var answer = await AlertDialogHelper.ShowAsync(Activity, $"Warning", $"Do you want to remove the data for sequence {gap.Value.Data.SequenceNumber} in Trolley tray {gap.Value.Data.TrollLocation}?", "ERASE", "CANCEL");
                    if (answer) //ERASE
                    {
                        var answer2 = await AlertDialogHelper.ShowAsync(Activity, "Warning", "This will erase the data for that sequence, are you sure?", "ERASE", "CANCEL");
                        if (answer2)
                        {
                            await Values.SQLidb.db.Table<ScannedData>().DeleteAsync(r => r.TrollLocation == gap.Value.Data.TrollLocation);
                            gap.Value.Erase(Activity);
                        }
                    }
                    IsBeingTouched = false;
                } catch (Exception ex)
                {
                    IsBeingTouched = false;
                }
            }
        }

        public void SetStatus(string location, GapStatus status)
        {
            Trolley.SetStatus(location, status, Activity);
        }

        public void FillData(string location, DataReading data)
        {
            Trolley.FillData(location, data, Activity);
        }

        //max number of lines present in the xml is 12

        public void Clear()
        {
            Trolley.Clear(Activity);
        }
    }

}