using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.ComponentModel;
using MvvmFoundation.Wpf;
using System.Reflection;

namespace TEST2.ViewModel
{
    public class RecordSelectionModel : INotifyPropertyChanged
    {

        private bool isSelected = false;
        //data checks and status indicators done in another class
        private readonly RecordDisplayModelStatus stat = new RecordDisplayModelStatus();
        public RecordDisplayModelStatus Stat { get { return stat; } }

        public RecordSelectionModel()
        {
            dataItems = new MyObservableCollection<Record>();
            //DataItems = App.TestModel.GetRecords();
            //listBoxCommand = new RelayCommand(() => SelectionHasChanged());
            //App.Messenger.Register("RecordCleared", (Action)(() => SelectedRecord = null));
            //App.Messenger.Register("GetRecords", (Action)(() => GetRecords()));
            //App.Messenger.Register("UpdateRecord",  (Action<Record>)(param => UpdateRecord(param)));
            //App.Messenger.Register("DeleteRecord", (Action)(() => DeleteRecord()));
            //App.Messenger.Register("AddRecord", (Action<Record>)(param => AddRecord(param)));
            //App.Messenger.Register("NextRecord", (Action)(() => NextRecord()));
            //App.Messenger.Register("PrevRecord", (Action)(() => PrevRecord()));
            //App.Messenger.Register("Start", ((Action)(() => Index = 0)));
            //Index = 0;
            var RecordType = typeof(Record);
            foreach (PropertyInfo p in RecordType.GetProperties())
                FieldListTags[p.Name] = "";
            Stat.Mode = MODES.SEARCH;
        }

        public int Index
        {
            get => dataItems.IndexOf(selectedRecord);
            set => SelectedRecord = dataItems[value];
        }

        public int FilteredIndex
        {
            get => filteredDataItems.IndexOf(selectedRecord);
            set => SelectedRecord = filteredDataItems[value];
        }

        private Record GetRecord(int index)
        {
            return dataItems[index];
        }

        private Record GetFilteredRecord(int index)
        {
            return filteredDataItems[index];
        }

        #region button_behaviour
        #region AddButton
        private RelayCommand addCommand;
        public ICommand AddCommand
        {
            get { return addCommand ?? (addCommand = new RelayCommand(() => AddRecord(), () => !isSelected)); }
        }


        private void AddRecord()
        {
            ClearSelectedRecord();
            stat.Mode = MODES.ADDNEW;


        } //AddRecord()
        #endregion
        #region EditButton
        private RelayCommand updateCommand;
        public ICommand UpdateCommand
        {
            get { return updateCommand ?? (updateCommand = new RelayCommand(() => UpdateRecord(), () => isSelected)); }
        }

        private void UpdateRecord()
        {
            stat.Mode = MODES.EDIT;
        } //UpdateRecord()
        #endregion
        #region DeleteButton
        private RelayCommand deleteCommand;
        public ICommand DeleteCommand
        {
            get { return deleteCommand ?? (deleteCommand = new RelayCommand(() => DeleteRecord(), () => isSelected)); }
        }

        private void DeleteRecord()
        {
            if (!App.TestModel.DeleteRecord(DisplayedRecord._IdReg))
            {
                stat.Status = App.TestModel.errorMessage;
                return;
            }
            dataItems.Remove(selectedRecord);
            filteredDataItems.Remove(selectedRecord);//check if this fails
            isSelected = false;
            App.Messenger.NotifyColleagues("DeleteRecord");
        } //DeleteRecord
        #endregion
        #region SearchButtons
        #region FirstButton
        private RelayCommand firstCommand;
        public ICommand FirstCommand
        {
            get { return firstCommand ?? (firstCommand = new RelayCommand(() => FirstRecord())); }
        }
        private void FirstRecord()
        {
            if (Stat.Mode == MODES.NAVIGATE)
                FilteredIndex = 0;
        }
        #endregion
        #region PrevButton
        private RelayCommand prevCommand;
        public ICommand PrevCommand
        {
            get { return prevCommand ?? (prevCommand = new RelayCommand(() => PrevRecord()/*, () => isSelected)*/)); }
        }

        private void PrevRecord()
        {
            if (FilteredIndex > 0 && stat.Mode == MODES.NAVIGATE)
            {
                SelectedRecord = GetFilteredRecord(FilteredIndex - 1);
                //App.Messenger.NotifyColleagues("PrevRecord");
            }
        }
        #endregion
        #region NextButton
        private RelayCommand nextCommand;
        public ICommand NextCommand
        {
            get { return nextCommand ?? (nextCommand = new RelayCommand(() => NextRecord()/*, () => isSelected)*/)); }
        }

        private void NextRecord()
        {
            if (FilteredIndex < filteredDataItems.Count() && stat.Mode == MODES.NAVIGATE)
            {
                SelectedRecord = GetFilteredRecord(FilteredIndex + 1);
                //App.Messenger.NotifyColleagues("NextRecord");
            }
        }
        #endregion
        #region LastButton
        private RelayCommand lastCommand;
        public ICommand LastCommand
        {
            get { return lastCommand ?? (lastCommand = new RelayCommand(() => LastRecord())); }
        }

        private void LastRecord()
        {
            if (Stat.Mode == MODES.NAVIGATE)
                FilteredIndex = filteredDataItems.Count() - 1;
        }
        #endregion
        #endregion
        #region SearchButton
        private RelayCommand searchCommand;
        public ICommand SearchCommand
        {
            get { return searchCommand ?? (searchCommand = new RelayCommand(() => SearchRecord())); }
        }
        public void SearchRecord()
        {
            Stat.Mode = MODES.SEARCH;
            ClearSelectedRecord();
        }
        #endregion
        #region ClearButton
        private RelayCommand clearCommand;
        public ICommand ClearCommand
        {
            get { return clearCommand ?? (clearCommand = new RelayCommand(() => ClearSelectedRecord()/*, ()=>isSelected*/)); }
        }
        private void ClearSelectedRecord()
        {
            SelectedRecord = null;
            isSelected = false;
            stat.NoError();
            DisplayedRecord = new Record();
            App.Messenger.NotifyColleagues("RecordCleared");
        }
        #endregion
        #region CommitButton
        private RelayCommand commitCommand;
        public ICommand CommitCommand
        {
            get { return updateCommand ?? (commitCommand = new RelayCommand(() => Commit())); }
        }

        private void Commit()
        {
            switch (stat.Mode)
            {
                case MODES.ADDNEW:
                    if (!stat.ChkRecordForAdd(DisplayedRecord)) return;
                    if (!App.TestModel.AddRecord(DisplayedRecord))
                    {
                        stat.Status = App.TestModel.errorMessage;
                        return;
                    }
                    dataItems.Add(DisplayedRecord);
                    App.Messenger.NotifyColleagues("AddRecord", DisplayedRecord);
                    break;
                case MODES.EDIT:
                    if (!stat.ChkRecordForUpdate(DisplayedRecord)) return;
                    if (!App.TestModel.UpdateRecord(DisplayedRecord))
                    {
                        stat.Status = App.TestModel.errorMessage;
                        return;
                    }
                    int index = dataItems.IndexOf(selectedRecord);
                    dataItems.ReplaceItem(index, DisplayedRecord);
    
                    //check if we need to do the same in filtered
                    SelectedRecord = DisplayedRecord;
                    App.Messenger.NotifyColleagues("UpdateRecord", DisplayedRecord);
                    break;
                case MODES.SEARCH:
                    if (dataItems.Count == 0)
                        GetRecords();
                    if (DisplayedRecord.IsClean())
                    {
                        FilteredDataItems = DataItems;
                    } else
                    {
                        FilteredDataItems = new MyObservableCollection<Record>(DataItems.OfType<Record>().Where(p => p.MatchesFilter(DisplayedRecord)));
                    }

                    Stat.Mode = MODES.NAVIGATE;
                    //Index = dataItems.Count()-1;
                    FilteredIndex = FilteredDataItems.Count() - 1;
                    break;
            }
        }
        #endregion
        #endregion


        private void GetRecords()
        {
            DataItems = App.TestModel.GetRecords();
            if (App.TestModel.hasError)
                App.Messenger.NotifyColleagues("SetStatus", App.TestModel.errorMessage);
            isSelected = false;
            stat.NoError();
            //DisplayedRecord = new Record();
            App.Messenger.NotifyColleagues("GetRecords");
        }
















        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private MyObservableCollection<Record> dataItems;
        public MyObservableCollection<Record> DataItems
        {
            get { return dataItems; }
            //If dataItems replaced by new collection, WPF must be told
            set { dataItems = value; OnPropertyChanged(new PropertyChangedEventArgs("DataItems")); }
        }

        private MyObservableCollection<Record> filteredDataItems;
        public MyObservableCollection<Record> FilteredDataItems
        {
            get { return filteredDataItems; }
            //If dataItems replaced by new collection, WPF must be told
            set { filteredDataItems = value; OnPropertyChanged(new PropertyChangedEventArgs("FilteredDataItems")); }
        }

        private Record selectedRecord;
        public Record SelectedRecord
        {
            get { return selectedRecord; }
            set
            { if (value != selectedRecord)
                {
                    selectedRecord = value;
                    ProcessRecord(selectedRecord);
                    App.Messenger.NotifyColleagues("RecordSelectionChanged", selectedRecord);
                    OnPropertyChanged(new PropertyChangedEventArgs("SelectedRecord"));
                }
            }
        }

        private Record displayedRecord = new Record();
        public Record DisplayedRecord
        {
            get { return displayedRecord; }
            set { displayedRecord = value; OnPropertyChanged(new PropertyChangedEventArgs("DisplayedRecord")); }
        }

        public void ProcessRecord(Record r)
        {
            if (r == null) { /*DisplayedRecord = null;*/  isSelected = false; return; }
            Record temp = new Record();
            temp.CopyRecord(r);
            DisplayedRecord = temp;
            isSelected = true;
            stat.NoError();
            //App.Messenger.NotifyColleagues("Start");
        } // ProcessRecord()

        private Dictionary<string,string> fieldListTags = new Dictionary<string, string>();
        public Dictionary<string, string> FieldListTags
        {
            get => fieldListTags;
            set { fieldListTags = value; OnPropertyChanged(new PropertyChangedEventArgs("FieldListTags")); }
        }


        //private RelayCommand listBoxCommand;
        //public ICommand ListBoxCommand
        //{
        //    get { return listBoxCommand; }
        //}





        //private void SelectionHasChanged()
        //{
        //    Messenger messenger = App.Messenger;
        //    messenger.NotifyColleagues("RecordSelectionChanged", selectedRecord);
        //}
    }//class RecordSelectionModel



    public class MyObservableCollection<Record> : ObservableCollection<Record>
    {
        public MyObservableCollection(IEnumerable<Record> collection) : base(collection)
        {
        }

        public MyObservableCollection()
        {
        }

        public void UpdateCollection()
        {
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(
                                NotifyCollectionChangedAction.Reset));
        }


        public void ReplaceItem(int index, Record item)
        {
             base.SetItem(index, item);      
        }


    } // class MyObservableCollection
}
