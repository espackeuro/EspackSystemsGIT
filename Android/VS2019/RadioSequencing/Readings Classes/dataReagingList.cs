
using System.Collections.Generic;
using System.Linq;
using CommonTools;
using System.Collections;
using System.Threading.Tasks;
using CommonAndroidTools;
using Android.Content;
using System;
using System.Threading;
using Android.App;
using Android.Widget;

namespace RadioSequencing
{
    public class DataReadingList : IEnumerable
    {
        public Context Context { get; set; } = null;
        private List<cData> dataList = new List<cData>();

        public IEnumerator<cData> GetEnumerator()
        {
            return dataList.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public void Add(cData d)
        {
            dataList.Add(d);
        }

        public bool Processing { get; set; } = false;

        public async Task Add(string reading)
        {
            if (Context == null)
            {
                throw new Exception("Context not set");
            }
            Processing = true;
            cData _data;
            //CLOSE CODE
            if (reading == Values.CloseCode)
            {
                //set alert for executing the task
                bool dialogResult = await AlertDialogHelper.ShowAsync(Context, "Confirm Close Session", "This will close current session. Are you sure?", "Close Session", "Cancel");

                if (!dialogResult)
                {
                    ((Activity)Context).RunOnUiThread(() =>
                    {
                        Toast.MakeText(Context, "Cancelled!", ToastLength.Short).Show();
                    });
                    Processing = false;
                    return;
                }
                _data = new DataCloseSession() { Context = Context, Data = reading };
                if (await _data.doCheckings())
                {
                    dataList.Add(_data);
                    //after close code we insert all reading from previous rack
                    Values.dFt.SetMessage("Waiting for the pending data to be transmitted");
                    foreach (var r in dataList.Where(r => r.Status == dataStatus.READ || r.Status == dataStatus.WARNING))
                    {
                        await r.ToDB();
                    }
                    Values.sFt.UpdateInfo();
                    //await Values.iFt.pushInfo("Waiting for the pending data to be transmitted");
                    while (true)
                    {
                        //SpinWait.SpinUntil(() => Values.SQLidb.pendingData && (monitor.State == NetworkState.ConnectedData || monitor.State == NetworkState.ConnectedWifi));
                        await Task.Delay(1000);
                        if (Values.SQLidb.db.Table<ScannedData>().Where(r => r.Transmitted == false).CountAsync().Result==0)//(Values.sFt.ReadQtyReceived == Values.sFt.ReadQtyTransmitted && Values.sFt.CheckQtyReceived == Values.sFt.CheckQtyTransmitted)
                        {
                            break;
                        }
                    }

                    await Values.EmptyDatabase();
                    //clear info, debug and status fragments
                    Values.iFt.Clear();
                    Values.dFt.Clear();
                    Values.sFt.Clear();
                    Values.hFt.Clear();
                    Values.gDatos.User = "";
                    Values.gDatos.Password = "";
                    Values.Session = "";
                    dataList.Clear();
                    position = -1;
                    //change to enter order fragment
                    var intent = new Intent(Context, typeof(MainActivity));
                    ((MainScreen)Context).StartActivityForResult(intent, 1);
                    //Context.Dispose();
                    Processing = false;
                    return;
                }
            }
            else
            //NEW READING QTY
            if (reading.IsNumeric())
            {
                if (position > -1 && Current() is DataReading)
                {
                    DataReading _r = (DataReading)Current();
                    _r.Qty = reading.ToInt();
                    await _r.doCheckings();
                } else
                {
                    cSounds.Error(Context);
                    Processing = false;
                    return;
                }
                cSounds.Scan(Context);
                Current().UpdateCurrent();
                Processing = false;
                return;
            }
        }
        public int position { get; set; } = -1;
        public cData Current()
        {
            return dataList.ElementAt(position);
        }


    }
}