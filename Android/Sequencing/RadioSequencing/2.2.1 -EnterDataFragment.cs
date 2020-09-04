using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using CommonAndroidTools;
using Scanner;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static RadioSequencing.Values;

namespace RadioSequencing
{
    public enum ReadingStatusEnum { TROLL,TICKET,PARTNUMBER,FINISHED}
    public class ReadingStatus
    {
        //public static int SequenceIndex { get; set; } = 1;
        public ReadingStatusEnum Status { get; set; } = ReadingStatusEnum.TROLL;
        public DataReading CurrentData { get; set; } = new DataReading();
        public string CurrentTrolley { get; set; }
        public string CurrentGap { get; set; }
        public void Next()
        {
            switch (Status)
            {
                case ReadingStatusEnum.TROLL:
                    Status = ReadingStatusEnum.TICKET;
                    break;
                case ReadingStatusEnum.TICKET:
                    Status = ReadingStatusEnum.PARTNUMBER;
                    break;
                case ReadingStatusEnum.PARTNUMBER:
                    if (tFt.Trolley.UsedGaps < Values.MaxSequencesPerSession)
                    {
                        Status = ReadingStatusEnum.TROLL;
                    }
                    else
                        Status = ReadingStatusEnum.FINISHED;
                    break;
            }
        }
        public string MessageStatus
        {
            get
            {
                switch (Status)
                {
                    case ReadingStatusEnum.TROLL:
                        return "Please scan TROLL LABEL";
                    case ReadingStatusEnum.TICKET:
                        return "Now scan SEQUENCING TICKET";
                    case ReadingStatusEnum.PARTNUMBER:
                        return "Now scan PARTNUMBER 2D LABEL or NO STOCK code";
                    case ReadingStatusEnum.FINISHED:
                        return "Sequence session finished";
                    default:
                        return "";
                }
            }
        }
        public async Task AddData(string text, Context context)
        {
            if (Status == ReadingStatusEnum.FINISHED)
                Status = ReadingStatusEnum.TROLL;
            //ticket
            var ticketPattern = @"(.*)(?:\ +|%)(\d\d\d\d)(?:\ +|%)(.*)";
            var ticketMatch = Regex.Match(text, ticketPattern);
            if (ticketMatch.Success) //ticket
            {
                if (Status != ReadingStatusEnum.TICKET)
                    throw new Exception($"Wrong data, expecting {Status.ToString()}");
                var ticketVINNr = ticketMatch.Groups[1].ToString().Replace("%", "");
                var ticketSequenceNumber = ticketMatch.Groups[2].ToString().Replace("%", "");
                var ticketPartnumberSeqLabel = ticketMatch.Groups[3].ToString().Replace("%", "").Replace(" ","");
                //check if already read
                if (await SQLidb.db.Table<Tickets>().FirstOrDefaultAsync(o => o.SequenceNumber == ticketSequenceNumber && o.TicketVIN==ticketVINNr && o.TicketPartnumber==ticketPartnumberSeqLabel) != null)
                    throw new Exception($"This Ticket has already been read today in a different session.");
                if (await SQLidb.db.Table<ScannedData>().Where(o => o.VINNr == ticketVINNr && o.SequenceNumber==ticketSequenceNumber && o.PartnumberSeqLabel==ticketPartnumberSeqLabel).CountAsync() != 0)
                    throw new Exception($"Wrong ticket, already scanned.");
                if (ticketSequenceNumber == "0001" && tFt.Trolley.UsedGaps != 0)
                {
                    bool dialogResult = await AlertDialogHelper.ShowAsync(context, "New sequence number start", "This sequence means the end of the previous day and the start of a new group of sequence numbers. Are you sure?", "Yes", "No");

                    if (!dialogResult)
                    {
                        throw new Exception($"Cancelled the new sequence number group.");
                    }
                }
                var _usedGaps = tFt.Trolley.UsedGaps;
                if (ticketSequenceNumber != "0001" && _usedGaps != 0)
                {
                    var _prevSeqNum = tFt.Trolley[_usedGaps].SequenceNumber;
                    if (Convert.ToInt32(ticketSequenceNumber) != (Convert.ToInt32(_prevSeqNum) + 1))
                        throw new Exception($"Wrong ticket, Sequence Numbers should be consecutive or 0001.");
                }
                CurrentData.VINNr = ticketVINNr;
                CurrentData.SequenceNumber = ticketSequenceNumber;
                CurrentData.PartnumberSeqLabel = ticketPartnumberSeqLabel;
                iFt.InfoSeqNr.Text = $"SeqNr: { CurrentData.SequenceNumber}";
                iFt.InfoVIN.Text = $"VIN: { CurrentData.VINNr}";
                iFt.InfoPartnumber.Text = $"Partnumber: { CurrentData.PartnumberSeqLabel}";
                //change to avoid short prefixes
                var _prefix = ticketPartnumberSeqLabel.Split('-')[0];
                if (_prefix.Length<4)
                    throw new Exception($"Wrong ticket, the prefix of the partnumber is too short.");
                var _base = ticketPartnumberSeqLabel.Split('-')[1];
                if (_base.Length < 5)
                    throw new Exception($"Wrong ticket, the base of the partnumber is incomplete.");
                try
                {
                    var _suffix  = ticketPartnumberSeqLabel.Split('-')[2];
                } catch
                {
                    throw new Exception($"Wrong ticket, the suffix does not exist.");
                }
                // end of change
                return;
            }
            //trolley
            var trollPattern = "(T..)-(..)";
            var trollMatch = Regex.Match(text, trollPattern);
            if (trollMatch.Success) //troll
            {
                if (Status != ReadingStatusEnum.TROLL)
                    throw new Exception($"Wrong data, expecting {Status.ToString()}");
                var _previousGap = Convert.ToInt32(CurrentGap?.Substring(1, 2) ?? "0");
                var _curGap = trollMatch.Groups[2].ToString();
                if ((tFt.Trolley.Gaps[$"g{_curGap}"].Status != GapStatus.ERASED) && Convert.ToInt32(_curGap) != _previousGap + 1)
                    throw new Exception($"Wrong gap, please follow order, next gap expected is {_previousGap + 1}");
                CurrentGap = $"g{_curGap}";
                if (CurrentTrolley == null)
                {
                    CurrentTrolley = trollMatch.Groups[1].ToString();
                    hFt.t3.Text = $"Trolley: {CurrentTrolley}";
                    hFt.t4.Text = $"Gap: {CurrentGap}";
                }
                else if (CurrentTrolley!= trollMatch.Groups[1].ToString())
                {
                    throw new Exception($"Wrong trolley, expecting {CurrentTrolley}");
                }
                CurrentGap = $"g{trollMatch.Groups[2].ToString()}";
                if (await SQLidb.db.Table<ScannedData>().Where(o =>o.TrollLocation==text).CountAsync() != 0)
                //if (Values.DataReadingList.OfType<ScannedData>().Where(o => o.TrollLocation==text).Count() != 0)
                    throw new Exception($"Wrong trolley, already scanned.");
                CurrentData.TrollLocation = text;

                iFt.Clear();
                iFt.InfoTrolley.Text = $"Trolley: {text}";
                tFt.SetStatus(CurrentGap, GapStatus.FILLING);
                return;
            }
            //if (text==) //QTY
            //{
            //    if (Status != ReadingStatusEnum.QTY)
            //        throw new Exception($"Wrong data, expecting {Status.ToString()}");
            //    CurrentData.Qty = text.ToInt();
            //    iFt.InfoQTY.Text = "Qty: "+ text;
            //    return;
            //}
            //partnumber
            if (Status == ReadingStatusEnum.PARTNUMBER)
            {
                if (text== "icugoxaco9")
                {
                    CurrentData.Qty = 0;
                    CurrentData.PartnumberLabel = "NO-STOCK";
                    //iFt.InfoPartnumber.Text = $"Partnumber: {partnumber}✓";
                    iFt.InfoBatch.Text = $"Batch: --";
                    iFt.InfoQTY.Text = "Qty: NO STOCK";
                    return;
                }
                var labelPattern = @"(.*)(?:\r\n|\r|\n)(.*)(?:\r\n|\r|)";
                var match = Regex.Match(text, labelPattern, RegexOptions.Singleline);
                if (!match.Success)
                    throw new Exception($"'{text}' wrong data, expecting {Status.ToString()}");
                var partnumber = match.Groups[1].ToString();
                var batch = match.Groups[2].ToString();
                if (!partnumber.Contains(CurrentData.PartnumberSeqLabel))
                {
                    throw new Exception($"Wrong partnumber, does not match ticket.");
                }
                CurrentData.PartnumberLabel = partnumber;
                CurrentData.Batch = batch;
                CurrentData.Qty = 1;
                iFt.InfoPartnumber.Text = $"Partnumber: {partnumber}✓";
                iFt.InfoBatch.Text = $"Batch: {batch}";
                iFt.InfoQTY.Text = "Qty: OK";
                return;
            }
            throw new Exception($"'{text}' wrong data, expecting {Status.ToString()}");
        }


    }
    public class EnterDataFragment : Fragment
    {
        MainScreen MainScreen;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }
        //public static EditText ElData { get; private set; }
        //public RadioGroup rg { get; private set; }
        public static TextView EftMessage { get; set; }
        public void SetMessage(string message)
        {
            Activity.RunOnUiThread(() =>
            {
                EftMessage.Text = message;
            });
        }

        private ReadingStatus RS;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            MainScreen = (MainScreen)Activity;
            var _root = inflater.Inflate(Resource.Layout.enterDataFt, container, false);
            EftMessage = _root.FindViewById<TextView>(Resource.Id.eftmessage);
            RS = new ReadingStatus();
            //edittext to enter data
            //ElData = _root.FindViewById<EditText>(Resource.Id.data);
            //ElData.KeyPress += ElData_KeyPress;
            //ElData.ClearFocus();

            //scanner intent

            sScanner.RegisterScannerActivity(Activity, _root, true, Silent: true);
            sScanner.AfterReceive += Scanner_AfterReceive;

            //ElData.RequestFocus();
            //end

            //var _query = await Values.SQLidb.db.QueryAsync<QueryResult>("Select 'test', 10 ");//Rack, count(*) from ScannedData group by Rack order by idreg desc limit 3");
            SetMessage(RS.MessageStatus);
            hFt.Clear();
            tFt.Clear();
            hFt.t1.Text = string.Format("User: {0}", Values.PendingDataReading.UserCode);
            hFt.t2.Text = string.Format("Session: {0}", Values.PendingDataReading.SessionID);
            //var oldElements = Values.SQLidb.db.Table<ScannedData>().OrderBy(t => t.TrollLocation).ToListAsync().Result;
            var _order = 1;
            Values.PendingDataReading.Readings.ForEach(o =>
            {
                DataReading data = new DataReading() { SequenceNumber = o.SequenceNumber, VINNr = o.VINNr, PartnumberSeqLabel = o.PartnumberSeqLabel, PartnumberLabel = o.PartnumberLabel, Batch = o.Batch, TrollLocation = o.TrollLocation, Qty = o.Qty };
                tFt.FillData(_order, data);
                _order++;
                //hFt.t3.Text = $"Trolley: {o.TrollLocation.Substring(0, 3)}";
            });
            //RS.CurrentGap = $"g{ o.TrollLocation.Substring(4, 2)}";
            //RS.CurrentData.SequenceNumber = o.SequenceNumber;
            try
            {
                var lastGap = tFt.Trolley.Gaps.Where(o => o.Value.Data.PartnumberSeqLabel != "").OrderBy(o => o.Value.Order).First();
                RS.CurrentGap = lastGap.Value.Data.TrollLocation.Substring(4, 2);
                RS.CurrentData.SequenceNumber = lastGap.Value.Data.SequenceNumber;
            } catch
            {
                RS.CurrentGap = "01";
                RS.CurrentData.SequenceNumber = tFt.Trolley.Gaps.Values.Where(o => o.Order == 1).First().Data.SequenceNumber;
            }

            return _root;
        }


        private async void Scanner_AfterReceive(object sender, ReceiveEventArgs e)
        {
            if (Values.DataReadingList.Processing)
                return;
            ((FragmentActivity)sender).RunOnUiThread(() =>
            {
                cSounds.Scan(Activity);
                //ElData.Enabled = false;
                //ElData.Tag = "SCAN";
            });
            Values.DataReadingList.Context = (FragmentActivity)sender;
            DataTransferManager.Active = false;
            await Process(e.ReceivedData);
        }

        public async Task Process(string data)
        {
            try
            {
                tFt.EnableDeleting = false;
                await RS.AddData(data, Activity);
                if (RS.Status == ReadingStatusEnum.PARTNUMBER)
                {
                    cSounds.Correct(Activity);
                    await Values.DataReadingList.Add(RS.CurrentData);
                    tFt.EnableDeleting = true;
                    tFt.FillData(RS.CurrentGap, RS.CurrentData);
                }
                Values.DataReadingList.Processing = false;
                DataTransferManager.Active = true;
                //Activity.RunOnUiThread(() =>
                //{
                //    ElData.Enabled = true;
                //    ElData.Text = "";
                //});

                RS.Next();
                SetMessage(RS.MessageStatus);
                if (RS.Status == ReadingStatusEnum.FINISHED)
                {
                    Activity.RunOnUiThread(async () =>
                    {
                        await Values.DataReadingList.Add(Values.CloseCode);
                    });
                }
                //await Values.gDRL.Add(e.ReceivedData);
            }
            catch (Exception ex)
            {
                Values.DataReadingList.Processing = false;
                DataTransferManager.Active = true;
                Activity.RunOnUiThread(async () =>
                {
                    cSounds.Error(Activity);
                    bool dialogResult = await AlertDialogHelper.ShowAsync(Context, "ERROR", "Error reading scan: " + ex.Message, "ACKNOWLEDGE", "");
                    //Toast.MakeText(Activity, "Error reading scan." + ex.Message, ToastLength.Long).Show();
                    //ElData.Enabled = true;
                    //ElData.Text = "";
                });
            }
        }
        
    

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            sScanner.UnregisterScannerActivity();
        }

        


        //private async void ElData_KeyPress(object sender, View.KeyEventArgs e)
        //{
        //    try
        //    {
        //        if (sScanner.IsBusy)
        //        {
        //            e.Handled = true;
        //            return;
        //        }
        //        sScanner.IsBusy = true;
        //        if (e.Event.Action == KeyEventActions.Down && (e.KeyCode == Keycode.Enter || e.KeyCode == Keycode.Tab))
        //        {

        //            //ignore intent from scanner
        //            if (ElData.Text == "" && ElData.Tag.ToString() == "SCAN")
        //            {
        //                ElData.Tag = null;
        //                e.Handled = true;
        //                sScanner.IsBusy = false;
        //                return;
        //            }
        //            //discriminator
        //            if (ElData.Text == "")
        //            {
        //                Toast.MakeText(Activity, "Please enter valid data", ToastLength.Long).Show();
        //                e.Handled = true;
        //                sScanner.IsBusy = false;
        //                return;
        //            }
        //            ElData.Enabled = false;
        //            sScanner.IsBusy = false;
        //            Values.DataReadingList.Context = Activity;
        //            await Process(ElData.Text);
        //            e.Handled = true;
        //        }
        //        else
        //        {
        //            e.Handled = false;
        //            sScanner.IsBusy = false;
        //        }
        //    } catch
        //    {
        //        e.Handled = true;
        //        sScanner.IsBusy = false;
        //    }
        //}

        public override void OnResume()
        {
            base.OnResume();
            Values.iFt.Clear();
        }
    }

    public class DataAddedEventArgs : EventArgs
    {
        public string ReceivedData { get; set; }
    }

}