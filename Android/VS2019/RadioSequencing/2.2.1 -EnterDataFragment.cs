using System;
using System.Collections;
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
using CommonAndroidTools;
using System.Threading.Tasks;
using Scanner;
using System.Text.RegularExpressions;
using CommonTools;
using AccesoDatosXML;
using static RadioSequencing.Values;
using Android.Views.InputMethods;
using Xamarin.Essentials;

namespace RadioSequencing
{
    public enum ReadingStatusEnum { TROLL,TICKET,PARTNUMBER,QTY,FINISHED}
    public static class ReadingStatus
    {
        public static int SequenceIndex { get; set; } = 1;
        public static ReadingStatusEnum Status { get; set; } = ReadingStatusEnum.TROLL;
        public static DataReading CurrentData { get; set; } = new DataReading();
        public static string CurrentTrolley { get; set; }
        public static string CurrentGap { get; set; }
        public static void Next()
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
                    Status = ReadingStatusEnum.QTY;
                    break;
                case ReadingStatusEnum.QTY:
                    if (SequenceIndex < Values.MaxSequencesPerSession)
                    {
                        SequenceIndex++;
                        Status = ReadingStatusEnum.TROLL;
                    }
                    else
                        Status = ReadingStatusEnum.FINISHED;
                    break;
            }
        }
        public static string MessageStatus
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
                        return "Now scan PARTNUMBER 2D LABEL";
                    case ReadingStatusEnum.QTY:
                        return "Now enter the QTY (0 if no stock)";
                    case ReadingStatusEnum.FINISHED:
                        return "Sequence session finished";
                    default:
                        return "";
                }
            }
        }
        public async static Task AddData(string text)
        {
            if (text == "007") //reset reading
            {
                CurrentData = new DataReading();
                Status = ReadingStatusEnum.TROLL;
            }
            //ticket
            var ticketPattern = @"(.*)(?:\ +|%)(\d\d\d\d)(?:\ +|%)(.*)";
            var ticketMatch = Regex.Match(text, ticketPattern);
            if (ticketMatch.Success) //ticket
            {
                if (Status != ReadingStatusEnum.TICKET)
                    throw new Exception($"Wrong data, expecting {Status.ToString()}");
                var ticketVINNr = ticketMatch.Groups[1].ToString().Replace("%", "");
                var ticketSequenceNumber = ticketMatch.Groups[2].ToString().Replace("%", "");
                var ticketPartnumberSeqLabel = ticketMatch.Groups[3].ToString().Replace("%", "");
                //check if already read
                if (await SQLidb.db.Table<ScannedData>().Where(o => o.VINNr == ticketVINNr && o.SequenceNumber==ticketSequenceNumber && o.PartnumberSeqLabel==ticketPartnumberSeqLabel).CountAsync() != 0)
                    throw new Exception($"Wrong ticket, already scanned.");
                CurrentData.VINNr = ticketVINNr;
                CurrentData.SequenceNumber = ticketSequenceNumber;
                CurrentData.PartnumberSeqLabel = ticketPartnumberSeqLabel;
                iFt.InfoSeqNr.Text = $"SeqNr: { CurrentData.SequenceNumber}";
                iFt.InfoVIN.Text = $"VIN: { CurrentData.VINNr}";
                iFt.InfoPartnumber.Text = $"Partnumber: { CurrentData.PartnumberSeqLabel}";
                return;
            }
            //trolley
            var trollPattern = "(T..)-(..)";
            var trollMatch = Regex.Match(text, trollPattern);
            if (trollMatch.Success) //troll
            {
                if (Status != ReadingStatusEnum.TROLL)
                    throw new Exception($"Wrong data, expecting {Status.ToString()}");
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
            if (text.IsNumeric()) //QTY
            {
                if (Status != ReadingStatusEnum.QTY)
                    throw new Exception($"Wrong data, expecting {Status.ToString()}");
                CurrentData.Qty = text.ToInt();
                iFt.InfoQTY.Text = "Qty: "+ text;
                return;
            }
            //partnumber
            if (Status == ReadingStatusEnum.PARTNUMBER)
            {
                var labelPattern = @"(.*)(?:\r\n|\n)(.*)(?:\r\n|\n|)";
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
                iFt.InfoPartnumber.Text = $"Partnumber: {partnumber}✓";
                iFt.InfoBatch.Text = $"Batch: {batch}";
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
        public static EditText ElData { get; private set; }
        //public RadioGroup rg { get; private set; }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            MainScreen = (MainScreen)Activity;
            var _root = inflater.Inflate(Resource.Layout.enterDataFt, container, false);
            //edittext to enter data
            ElData = _root.FindViewById<EditText>(Resource.Id.data);
            ElData.KeyPress += ElData_KeyPress;
            ElData.ClearFocus();

            //scanner intent

            sScanner.RegisterScannerActivity(Activity, _root, true, Silent: true);
            sScanner.AfterReceive += Scanner_AfterReceive;
            
            ElData.RequestFocus();
            //end

            //var _query = await Values.SQLidb.db.QueryAsync<QueryResult>("Select 'test', 10 ");//Rack, count(*) from ScannedData group by Rack order by idreg desc limit 3");


            iFt.SetMessage(ReadingStatus.MessageStatus);
            hFt.Clear();
            tFt.Clear();
            var oldElements = Values.SQLidb.db.Table<ScannedData>().ToListAsync().Result;
            oldElements.ForEach(o =>
            {
                DataReading data = new DataReading() { SequenceNumber = o.SequenceNumber, VINNr = o.VINNr, PartnumberSeqLabel = o.PartnumberSeqLabel, PartnumberLabel = o.PartnumberLabel, Batch = o.Batch, TrollLocation = o.TrollLocation, Qty = o.Qty };
                tFt.FillData($"g{o.TrollLocation.Substring(4, 2)}", data);
                hFt.t3.Text = $"Trolley: {o.TrollLocation.Substring(0, 3)}";

            });
            return _root;
        }


        private async void Scanner_AfterReceive(object sender, ReceiveEventArgs e)
        {
            if (Values.DataReadingList.Processing)
                return;
            ((FragmentActivity)sender).RunOnUiThread(() =>
            {
                cSounds.Scan(Activity);
                ElData.Enabled = false;
                ElData.Tag = "SCAN";
            });
            Values.DataReadingList.Context = (FragmentActivity)sender;
            DataTransferManager.Active = false;
            await Process(e.ReceivedData);
        }

        public async Task Process(string data)
        {
            try
            {
                await ReadingStatus.AddData(data);
                if (ReadingStatus.Status == ReadingStatusEnum.QTY)
                {
                    cSounds.Correct(Activity);
                    await Values.DataReadingList.Add(ReadingStatus.CurrentData);
                    tFt.FillData(ReadingStatus.CurrentGap, ReadingStatus.CurrentData);
                }
                Values.DataReadingList.Processing = false;
                DataTransferManager.Active = true;
                Activity.RunOnUiThread(() =>
                {
                    ElData.Enabled = true;
                    ElData.Text = "";
                });

                ReadingStatus.Next();
                Values.iFt.SetMessage(ReadingStatus.MessageStatus);
                if (ReadingStatus.Status == ReadingStatusEnum.FINISHED)
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
                Activity.RunOnUiThread(() =>
                {
                    cSounds.Error(Activity);
                    Toast.MakeText(Activity, "Error reading scan." + ex.Message, ToastLength.Long).Show();
                    ElData.Enabled = true;
                    ElData.Text = "";
                });
            }
        }
        
    

        public override void OnDestroyView()
        {
            base.OnDestroyView();
            sScanner.UnregisterScannerActivity();
        }

        


        private async void ElData_KeyPress(object sender, View.KeyEventArgs e)
        {
            try
            {
                if (sScanner.IsBusy)
                {
                    e.Handled = true;
                    return;
                }
                sScanner.IsBusy = true;
                if (e.Event.Action == KeyEventActions.Down && (e.KeyCode == Keycode.Enter || e.KeyCode == Keycode.Tab))
                {

                    //ignore intent from scanner
                    if (ElData.Text == "" && ElData.Tag.ToString() == "SCAN")
                    {
                        ElData.Tag = null;
                        e.Handled = true;
                        sScanner.IsBusy = false;
                        return;
                    }
                    //discriminator
                    if (ElData.Text == "")
                    {
                        Toast.MakeText(Activity, "Please enter valid data", ToastLength.Long).Show();
                        e.Handled = true;
                        sScanner.IsBusy = false;
                        return;
                    }
                    ElData.Enabled = false;
                    sScanner.IsBusy = false;
                    Values.DataReadingList.Context = Activity;
                    await Process(ElData.Text);
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                    sScanner.IsBusy = false;
                }
            } catch
            {
                e.Handled = true;
                sScanner.IsBusy = false;
            }
        }

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