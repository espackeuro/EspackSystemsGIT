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
using Nito.AsyncEx;
using Android.Views.InputMethods;
using AccesoDatosXML;

namespace RadioSequencing
{
    public class infoData
    {
        public string c0;
        public string c1;
        public string c2;
        public string c3;
    }
    public class infoFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public TextView[,] infoArray { get; set; }
        public TextView infoMessage { get; set; }
        private int numLines;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var _root = inflater.Inflate(Resource.Layout.infoFt, container, false);
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            for (int i = 0; i < numLines; i++)
                for (int j = 0; j < 4; j++)
                {
                    int resId = Resources.GetIdentifier(string.Format("c{0}{1}", i, j), "id", Activity.PackageName);
                    infoArray[i, j] = _root.FindViewById<TextView>(resId);
                    infoArray[i, j].SetTextColor(Color.White);
                    infoArray[i, j].Typeface = Typeface.Monospace;
                }
            infoMessage = _root.FindViewById<TextView>(Resource.Id.message);
            infoMessage.SetTextColor(Color.White);

            try
            {
                AsyncContext.Run(getDataFromServer);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return _root;
        }
        //max number of lines present in the xml is 12
        public infoFragment(int MaxLines)
        {
            numLines = MaxLines;
            infoArray  = new TextView[numLines, 4];
        }
        public void SetMessage(string message)
        {
            Activity.RunOnUiThread(() =>
            {
                infoMessage.Text = message;
            });
        }
        public void pushInfo(infoData d)
        {
            pushInfo(d.c0, d.c1, d.c2, d.c3);
        }
        public void pushInfo(FragmentActivity context, string c0, string c1 = "", string c2 = "", string c3 = "")
        {
            context.RunOnUiThread(() =>
            {
                for (int i = numLines - 1; i > 0; i--)
                    for (int j = 0; j < 4; j++)
                    {
                        infoArray[i, j].Text = infoArray[i - 1, j].Text;
                    }
                infoArray[0, 0].Text = c0;
                infoArray[0, 1].Text = c1;
                infoArray[0, 2].Text = c2;
                infoArray[0, 3].Text = c3;
            });
        }
        public void pushInfo(string c0, string c1 = "", string c2 = "", string c3 = "")
        {
            Activity.RunOnUiThread(() =>
            {
                for (int i = numLines - 1; i > 0; i--)
                    for (int j = 0; j < 4; j++)
                    {
                        infoArray[i, j].Text = infoArray[i - 1, j].Text;
                    }
                infoArray[0, 0].Text = c0;
                infoArray[0, 1].Text = c1;
                infoArray[0, 2].Text = c2;
                infoArray[0, 3].Text = c3;
            });
        }
        public void Clear()
        {
            Activity.RunOnUiThread(() =>
            {
                infoMessage.Text = "";
                for (int i = 0; i < numLines; i++)
                    for (int j = 0; j < 4; j++)
                        infoArray[i, j].Text = "";
            });
        }
        public void updateMainLine(string c0, string c1 = "", string c2 = "", string c3 = "")
        {
            Activity.RunOnUiThread(() =>
            {
                infoArray[0, 0].Text = c0;
                infoArray[0, 1].Text = c1;
                infoArray[0, 2].Text = c2;
                infoArray[0, 3].Text = c3;
            });
        }
        public void updateMainLine(infoData d)
        {
            updateMainLine(d.c0, d.c1, d.c2, d.c3);
        }
        private async Task getDataFromServer()
        {
            //Dismiss Keybaord
            InputMethodManager imm = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
            //get location
            int _progress = 0;

            Values.iFt.SetMessage("Getting Sequence Numbers table");
            //data from RacksBlocks table
            using (var _rs = new XMLRS($"select distinct SequenceNumber,TicketVIN,TicketPartnumber from SequencingSessionDet where CONVERT(varchar(10),xfec,103)=CONVERT(varchar(10),getdate(),103) order by SequenceNumber", Values.gDatos))
            {
                await _rs.OpenAsync();/*
                Values.sFt.socksProgress.Indeterminate = false;
                Values.sFt.socksProgress.Max = _rs.RecordCount / 5;
                Values.sFt.socksProgress.Progress = 0;
                */
                foreach (var r in _rs.Rows)
                {
                    await Values.SQLidb.db.InsertAsync(new Tickets { SequenceNumber = r["SequenceNumber"].ToString(), TicketVIN= r["TicketVIN"].ToString(), TicketPartnumber= r["TicketPartnumber"].ToString(), });
                    //_progress++;
                    //if (_progress % 5 == 0)
                    //    Values.sFt.socksProgress.Progress++;
                }
            }
            //Values.sFt.socksProgress.Indeterminate = true;
            Values.iFt.SetMessage("Done");
            /*
            Values.iFt.pushInfo("Getting PartnumberRacks table");
            //data from RacksBlocks table
            using (var _rs = new XMLRS(string.Format("Select p.Rack,Partnumber,MinBoxes,MaxBoxes,p.flags from LOGISTICA..PartnumbersRacks p inner join LOGISTICA..RacksBlocks r on r.Rack=p.Rack where p.service='{0}' and dbo.CheckFlag(r.flags,'OBS')=0", Values.gService), Values.gDatos))
            {
                await _rs.OpenAsync();
                Values.sFt.socksProgress.Indeterminate = false;
                Values.sFt.socksProgress.Max = _rs.RecordCount / 5;
                Values.sFt.socksProgress.Progress = 0;
                foreach (var r in _rs.Rows)
                {
                    await Values.SQLidb.db.InsertAsync(new PartnumbersRacks { Rack = r["Rack"].ToString(), Partnumber = r["Partnumber"].ToString(), MinBoxes = r["MinBoxes"].ToInt(), MaxBoxes = r["MaxBoxes"].ToInt() });
                    _progress++;
                    if (_progress % 5 == 0)
                        Values.sFt.socksProgress.Progress++;
                }
            }
            Values.sFt.socksProgress.Indeterminate = true;
            Values.iFt.pushInfo("Done loading database data");
            */
            Values.elIntent = new Intent(Activity, typeof(DataTransferManager));
            Activity.StartService(Values.elIntent);
            DataTransferManager.Active = true;
        }
    }



}