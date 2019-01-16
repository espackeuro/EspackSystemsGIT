using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmFoundation.Wpf;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;



namespace TEST2.ViewModel
{/*
    public class RecordDisplayModel : INotifyPropertyChanged
    {
        
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        //data checks and status indicators done in another class
        private readonly RecordDisplayModelStatus stat = new RecordDisplayModelStatus();
        public RecordDisplayModelStatus Stat { get { return stat; } }

        private Record displayedRecord = new Record();
        public Record DisplayedRecord
        {
            get { return displayedRecord; }
            set { displayedRecord = value; OnPropertyChanged(new PropertyChangedEventArgs("DisplayedRecord")); }
        }


        private RelayCommand getRecordsCommand;
        public ICommand GetRecordsCommand
        {
            get { return getRecordsCommand ?? (getRecordsCommand = new RelayCommand(() => GetRecords())); }
        }




        //private RelayCommand clearCommand;
        //public ICommand ClearCommand
        //{
        //    get { return clearCommand ?? (clearCommand = new RelayCommand(() => ClearRecordDisplay())); }
        //}





        public RecordDisplayModel()
        {
            Messenger messenger = App.Messenger;
            messenger.Register("RecordSelectionChanged", (Action<Record>)(param => ProcessRecord(param)));
            messenger.Register("SetStatus", (Action<String>)(param => stat.Status = param));
            messenger.Register("RecordCleared", (Action)(() => ClearRecordDisplay()));
        } //ctor

    
    }
    */
}
