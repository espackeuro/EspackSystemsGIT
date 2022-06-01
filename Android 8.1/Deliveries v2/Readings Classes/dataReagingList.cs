
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

namespace RadioLogisticaDeliveries
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

            //if (Values.CurrentRack == "")
            //{
            //    var _ask4Rack = await Values.SQLidb.db.Table<PartnumbersRacks>().FirstOrDefaultAsync(r => r.Rack == reading);
            //    if (_ask4Rack == null)
            //    {
            //        cSounds.Error(Context);
            //        Values.iFt.SetMessage(string.Format("Error: Wrong Rack {0}.", reading));
            //        Processing = false;
            //        return;
            //    }
            //    Values.SetCurrentRack(_ask4Rack.Rack);
            //    Processing = false;
            //    return;
            //}

            //QRCODE
            if (reading.Length>2 && reading.Substring(0, 2) == "@@" && reading.Substring(reading.Length - 2, 2) == "##") //QRCODE
            {
                var _readingFields = reading.Split('|');
                if (Values.WorkMode == WorkModes.READING)
                {
                    // [dvalles] 20220517: Check there is a rack set
                    if (Values.CurrentRack == "")
                    {
                        cSounds.Error(Context);
                        Values.iFt.SetMessage(string.Format("You must scan a rack first."));
                        Processing = false;
                        return;
                    }

                    // [dvalles] 20220517: Check the label belongs to current order
                    if (Values.gOrderNumber != 0 && _readingFields[3].ToInt() != Values.gOrderNumber)
                    {
                        cSounds.Error(Context);
                        Values.iFt.SetMessage(string.Format("Label {0} does not belong to order {1}.", _readingFields[5], Values.gOrderNumber));
                        Processing = false;
                        return;
                    }
                    
                    //"QRCODE|R GRAZ|07/02/2017|724008707|VCE15|303639641|KLT3215|U00045|L538|1000|W700530S300|STRAP 3-80X4.6 PLA||"
                    reading = string.Format("%{0}%{1}%{2}",_readingFields[11],_readingFields[4],_readingFields[12]);
                } else
                {
                    reading = _readingFields[5];
                }
            }
            // Alternate PartnumberRack
            var _alternate = await Values.SQLidb.db.Table<PartnumbersRacks>().FirstOrDefaultAsync(r => r.alternate == reading);
            if (_alternate!=null)
            {
                reading = string.Format("%{0}%{1}%{2}", _alternate.Partnumber, _alternate.Rack, Values.gService);
            }
            // Alternate Rack
            if (reading.Substring(0, 2) == "RK")
            {
                int _ini = reading.IndexOf("E") + 1; //should be 9
                string _candidate = reading.Substring(_ini, reading.Length - _ini);
                var _possibleRack = await Values.SQLidb.db.Table<RacksBlocks>().FirstOrDefaultAsync(r => r.Rack == _candidate);
                if (_possibleRack != null)
                    reading = _candidate;

            }


            // CHECKING
            if ((reading.IsNumeric() && reading.Length == 9) || (reading.Length > 9 && reading.Substring(0, 1) == "S" && reading.Substring(1, 9).IsNumeric())) //checking
            {
                if (reading.Substring(0, 1) == "S" && reading.Substring(1, 9).IsNumeric())
                    reading = reading.Substring(1, 9);
                if (Values.WorkMode == WorkModes.READING)
                {
                    cSounds.Error(Context);
                    await AlertDialogHelper.ShowAsync(Context, "ERROR", "Current mode is READING, cannot process this data.", "OK", "");
                    Processing = false;
                    return;
                }
                //check if serial is in list
                if (dataList.OfType<DataChecking>().FirstOrDefault(r => r.Serial == reading) != null)
                {
                    cSounds.Error(Context);
                    Values.iFt.SetMessage(string.Format("Error: Serial {0} already checked.", reading));
                    Processing = false;
                    return;
                }
                _data = new DataChecking() { Context = Context, Rack = Values.CurrentRack, Data = reading, Serial = reading };
                if (await _data.doCheckings())
                {
                    dataList.Add(_data);//
                    position++;
                    //Values.sFt.CheckQtyReceived++;
                }
                _data.PushInfo();
                Processing = false;
                return;
            }
            else
            // READING
            if (reading.Substring(0, 1) == "%") //reading
            {
                if (Values.WorkMode== WorkModes.CHECKING)
                {
                    cSounds.Error(Context);
                    await AlertDialogHelper.ShowAsync(Context, "ERROR", "Current mode is CHECKING, cannot process this data.", "OK", "");
                    Processing = false;
                    return;
                }
                var _split = reading.Split('%');
                string _pn = _split[1];
                string _lr = _split[2];
                string _ls = _split.Length == 4 ? _split[3] : "";
                DataReading _r;
                bool newReading = false;
                //SAME READING QTY+1
                if (position > -1 && Current() is DataReading)
                {
                    _r = (DataReading)Current();
                    if (_r.Partnumber == _pn && _r.LabelRack == _lr && _r.LabelService == _ls)
                    {
                        _r.Qty++;
                        await _r.doCheckings();
                        Current().UpdateCurrent();
                        Processing = false;
                        return;
                    }
                    else
                        newReading = true;
                }
                else
                    newReading = true;
                if (newReading)
                {
                    //NEW READING
                    //get previous reading in the rack with the same data
                    var itemToRemove = dataList.SingleOrDefault(r => r is DataReading && ((DataReading)r).Partnumber == _pn && ((DataReading)r).LabelRack == _lr && ((DataReading)r).LabelService == _ls && (((DataReading)r).Status == dataStatus.READ || ((DataReading)r).Status == dataStatus.WARNING));
                    //var _query = from r in _dataList
                    //             where r is dataReading && ((dataReading)r).Partnumber == _pn && ((dataReading)r).LabelRack == _lr && ((dataReading)r).LabelService == _ls && (((dataReading)r).Status == dataStatus.READ || ((dataReading)r).Status == dataStatus.WARNING)
                    //             select r;
                    //foreach (var d in _query)
                    //_dataList.Remove(d);
                    if (itemToRemove != null)
                    {
                        dataList.Remove(itemToRemove);
                        position--;
                    }

                    //_dataList.OfType<dataReading>().Select(r) => r.Partnumber=_pn && r.)
                    _data = new DataReading()
                    {
                        Context = Context,
                        Rack = Values.CurrentRack,
                        Data = reading,
                        Partnumber = _split[1],
                        LabelRack = _split[2],
                        LabelService = _split.Length == 4 ? _split[3] : "",
                        Qty = 1
                    };
                    if (await _data.doCheckings())
                    {
                        dataList.Add(_data);
                        position++;
                        //Values.sFt.ReadQtyReceived++;
                    }
                    _data.PushInfo();
                    Processing = false;
                    return;
                }
            }
            else
            //CLOSE CODE
            if (reading == Values.gCloseCode || reading==Values.gCloseReLogInCode)
            {
                //set alert for executing the task
                string _msg = (reading == Values.gCloseReLogInCode) ? " and re-login with current user" : "";
                bool dialogResult = await AlertDialogHelper.ShowAsync(Context, "Confirm Close Session", $"This will close current session{_msg}. Are you sure?", "Close Session", "Cancel");

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
                    Values.gSession = "";
                    Values.gService = "";
                    Values.gOrderNumber = 0;
                    Values.gBlock = "";
                    dataList.Clear();
                    position = -1;
                    Values.SetCurrentRack("");
                    //if (LocatorService.Started)
                    //    LocatorService.Kill = true;
                    if (DataTransferManager.Started)
                        DataTransferManager.Kill = true;
                    //change to enter order fragment
                    var intent = new Intent(Context, typeof(MainActivity));
                    // [dvalles] 20220520: To maintain the user/password details when it's gCloseReLoginCode
                    if (reading == Values.gCloseReLogInCode)
                    {
                        intent.PutExtra("User", Values.gDatos.User);
                        intent.PutExtra("Password", Values.gDatos.Password);
                    }
                    Values.gDatos.User = "";
                    Values.gDatos.Password = "";
                    Values.gSession = null;

                    // [dvalles] 20220525: Reset stuff which makes the app to crash after restarting the activity.
                    ((MainScreen)Context).ResetActivityStuff();

                    // Start main activity
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
            else
            //NEW RACK CODE
            {
                if (reading==Values.CurrentRack)
                {
                    ((Activity)Context).RunOnUiThread(() =>
                    {
                        Toast.MakeText(Context, "Scanned Rack is the current one.", ToastLength.Short).Show();
                        cSounds.Error(Context);
                    });
                    Processing = false;
                    return;
                }
                _data = new DataChangeRack() { Context = Context, Data = reading };
                if (await _data.doCheckings())
                {
                    //after new rack code we insert all reading from previous rack
                    if (dataList.Count != 0)
                    {
                        Values.dFt.SetMessage(string.Format("Transmitting Rack {0}", Values.CurrentRack));
                        foreach (var r in dataList.Where(r => r.Status == dataStatus.READ || r.Status == dataStatus.WARNING))
                        {
                            await r.ToDB();
                        }
                    }
                    dataList.Add(_data);
                    Values.sFt.UpdateInfo();
                    position++;
                    //try
                    //{
                    //    await Values.dtm.Transfer();
                    //}
                    //catch (Exception ex)
                    //{
                    //    await Values.dFt.pushInfo(ex.Message);
                    //}
                }
                _data.PushInfo();
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