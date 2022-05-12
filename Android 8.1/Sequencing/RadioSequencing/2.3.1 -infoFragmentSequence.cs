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

namespace RadioSequencing
{
    public class infoFragmentSequence : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public TextView InfoMessage { get; set; }
        public TextView InfoTrolley { get; set; }
        public TextView InfoVIN { get; set; }
        public TextView InfoSeqNr { get; set; }
        public TextView InfoPartnumber { get; set; }
        public TextView InfoBatch { get; set; }
        public TextView InfoQTY { get; set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var _root = inflater.Inflate(Resource.Layout.infoSeqFt, container, false);
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            InfoMessage = _root.FindViewById<TextView>(Resource.Id.message);
            InfoTrolley = _root.FindViewById<TextView>(Resource.Id.trolley);
            InfoVIN = _root.FindViewById<TextView>(Resource.Id.vin);
            InfoSeqNr = _root.FindViewById<TextView>(Resource.Id.seqnr);
            InfoPartnumber = _root.FindViewById<TextView>(Resource.Id.partnumber);
            InfoBatch = _root.FindViewById<TextView>(Resource.Id.batch);
            InfoQTY = _root.FindViewById<TextView>(Resource.Id.qty);

            InfoMessage.SetTextColor(Color.Black);
            return _root;
        }
        //max number of lines present in the xml is 12
        public void SetMessage(string message)
        {
            Activity.RunOnUiThread(() =>
            {
                InfoMessage.Text = message;
            });
        }
        public void Clear()
        {
            InfoMessage.Text = "";
            InfoTrolley.Text = "Trolley:";
            InfoSeqNr.Text = "SeqNr:";
            InfoVIN.Text = "VIN:";
            InfoPartnumber.Text = "Partnumber:";
            InfoBatch.Text = "Batch:";
            InfoQTY.Text = "Qty:";
        }
    }

}