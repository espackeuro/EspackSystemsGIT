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

namespace RadioLogisticaDeliveries
{
    public class trolleyFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        public enum GapStatus { EMPTY, FILLING, FILLED, ERROR}
        public Dictionary<string,TextView> trolleyArray { get; set; }
        private int numLines;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var _root = inflater.Inflate(Resource.Layout.infoFt, container, false);
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            for (int i = 0; i < 2; i++)
                for (int j = 1; j <= 6; j++)
                {
                    var location = string.Format("{0}{1}", i, j);
                    int resId = Resources.GetIdentifier(location, "id", Activity.PackageName);

                    trolleyArray[location] = _root.FindViewById<TextView>(resId);
                    trolleyArray[location].Typeface = Typeface.Monospace;

                }
            return _root;
        }
        //max number of lines present in the xml is 12
        public void SetStatus(string location, GapStatus status)
        {
            Activity.RunOnUiThread(() =>
            {
                switch (status) {
                    case GapStatus.EMPTY:
                        trolleyArray[location].SetBackgroundColor(Color.White);
                        break;
                    case GapStatus.FILLING:
                        trolleyArray[location].SetBackgroundColor(Color.Green);
                        break;
                    case GapStatus.FILLED:
                        trolleyArray[location].SetBackgroundColor(Color.Blue);
                        break;
                    case GapStatus.ERROR:
                        trolleyArray[location].SetBackgroundColor(Color.Red);
                        break;
                }
            });
        }
        public void Clear()
        {
            Activity.RunOnUiThread(() =>
            {
                trolleyArray.ToList().ForEach(t => SetStatus(t.Key, GapStatus.EMPTY));
            });
        }
    }
    
}