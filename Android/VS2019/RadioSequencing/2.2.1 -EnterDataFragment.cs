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
        public static void AddData(string text)
        {
            if (text == "xxx") //reset reading
            {
                CurrentData = new DataReading();
                Status = ReadingStatusEnum.TROLL;
            }
            var ticketPattern = @"(.*)(?:\ *|%)(\d\d\d\d)(?:\ *|%)(.*)";
            var ticketMatch = Regex.Match(text, ticketPattern);
            if (ticketMatch.Success) //ticket
            {
                if (Status != ReadingStatusEnum.TICKET)
                    throw new Exception($"Wrong data, expecting {Status.ToString()}");
                CurrentData.VINNr = ticketMatch.Groups[1].ToString().Replace("%","");
                CurrentData.SequenceNumber = ticketMatch.Groups[2].ToString().Replace("%", "");
                CurrentData.PartnumberSeqLabel = ticketMatch.Groups[3].ToString().Replace("%", "");
                iFt.pushInfo("Ticket", CurrentData.VINNr, CurrentData.SequenceNumber, CurrentData.PartnumberSeqLabel);
                return;
            }
            var trollPattern = "T..-..";
            if (Regex.Match(text,trollPattern).Success) //troll
            {
                if (Status != ReadingStatusEnum.TROLL)
                    throw new Exception($"Wrong data, expecting {Status.ToString()}");
                CurrentData.TrollLocation = text;
                iFt.pushInfo("Trolley", text);
                return;
            }
            if (text.IsNumeric()) //QTY
            {
                if (Status != ReadingStatusEnum.QTY)
                    throw new Exception($"Wrong data, expecting {Status.ToString()}");
                CurrentData.Qty = text.ToInt();
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
                iFt.pushInfo("Part:", partnumber, batch);
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


            Values.iFt.SetMessage(ReadingStatus.MessageStatus);
            return _root;
        }


        private void Scanner_AfterReceive(object sender, ReceiveEventArgs e)
        {
            if (Values.DataReadingList.Processing)
                return;
            ((FragmentActivity)sender).RunOnUiThread(() =>
            {
                ElData.Enabled = false;
                ElData.Tag = "SCAN";
            });
            Values.DataReadingList.Context = (FragmentActivity)sender;
            DataTransferManager.Active = false;
            try
            {
                ReadingStatus.AddData(e.ReceivedData);
                if (ReadingStatus.Status == ReadingStatusEnum.QTY)
                {
                    Values.DataReadingList.Add(ReadingStatus.CurrentData);
                }
                Values.DataReadingList.Processing = false;
                DataTransferManager.Active = true;
                ((FragmentActivity)sender).RunOnUiThread(() =>
                {
                    ElData.Enabled = true;
                    ElData.Text = "";
                });

                ReadingStatus.Next();
                Values.iFt.SetMessage(ReadingStatus.MessageStatus);
                if (ReadingStatus.Status == ReadingStatusEnum.FINISHED)
                {
                    ((FragmentActivity)sender).RunOnUiThread(async () =>
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
                ((FragmentActivity)sender).RunOnUiThread(() =>
                {
                    cSounds.Error(Activity);
                    Toast.MakeText(Activity, "Error reading scan." + ex.Message, ToastLength.Long).Show();
                    ElData.Enabled = true;
                    ElData.Text = "";
                });
            }
        }

        
    

        private void RadioReading_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            Values.WorkMode = e.IsChecked ? WorkModes.READING : WorkModes.CHECKING;
            ElData.RequestFocus();
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

                    Values.DataReadingList.Context = Activity;
                    await Values.DataReadingList.Add(ElData.Text);
                    ElData.Text = "";
                    ElData.ClearFocus();
                    ElData.Enabled = true;
                    sScanner.IsBusy = false;
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