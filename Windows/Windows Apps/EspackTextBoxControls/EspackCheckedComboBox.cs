using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatosNet;
using CommonTools;
using CheckedComboBoxNS;

namespace EspackFormControlsNS
{
    public partial class EspackCheckedComboBox : EspackFormControlCaption
    {
        //protected override Label CaptionLabel { get; set; }
        public CheckedComboBox CheckedComboBox;
        //public override Label CaptionLabel { get; set; }

        public EspackTextBox TBDescription { get; set; }
        public AutoCompleteStringCollection AutoCompleteCustomSource { get => CheckedComboBox.AutoCompleteCustomSource; set => CheckedComboBox.AutoCompleteCustomSource = value; }
        public AutoCompleteSource AutoCompleteSource { get => CheckedComboBox.AutoCompleteSource; set => CheckedComboBox.AutoCompleteSource = value; }
        public AutoCompleteMode AutoCompleteMode { get => CheckedComboBox.AutoCompleteMode; set => CheckedComboBox.AutoCompleteMode = value; }
        public FlatStyle FlatStyle { get => CheckedComboBox.FlatStyle; set => CheckedComboBox.FlatStyle = value; }
        public string ValueMember { get => CheckedComboBox.ValueMember; set => CheckedComboBox.ValueMember = value; }
        public object SelectedValue { get => CheckedComboBox.SelectedValue; set => CheckedComboBox.SelectedValue = value; }
        public object SelectedItem { get => CheckedComboBox.SelectedItem; set => CheckedComboBox.SelectedItem = value; }
        public object DataSource { get => CheckedComboBox.DataSource; set => CheckedComboBox.DataSource = value; }
        public string DisplayMember { get => CheckedComboBox.DisplayMember; set => CheckedComboBox.DisplayMember = value; }
        public bool CheckOnClick { get => CheckedComboBox.CheckOnClick; set => CheckedComboBox.CheckOnClick = value; }


        public List<string> CheckedValues
        {
            get
            {
                return CheckedItems.Cast<DataRowView>().Select(x => x[ValueMember].ToString()).ToList();
                //IEnumerable<string> l = (from DataRowView item in CheckedItems select item.Row[ValueMember].ToString());
                //return l.ToList<string>();
            }
        }
        public CheckedListBox.CheckedItemCollection CheckedItems { get => CheckedComboBox.CheckedItems; }
        public CheckedListBox.ObjectCollection Items { get => CheckedComboBox.Items; }
        private string oldText;
        private StaticRS _RS;
        private string _SQL;
        private bool noChange = false;

        public event EventHandler<AfterItemCheckEventArgs> AfterItemCheck;
        //Default event handler for CTLM
        private void DefaultEventChanged(object source, EventArgs e)
        {
            return;
        }
        public override string Text
        {
            get => CheckedComboBox.Text;
            set
            {
                if (value != base.Text)
                {
                    //raise the value change event
                    oldText = base.Text;
                    base.Text = value;
                    OnValueChanged(new ValueChangedEventArgs(oldText, value));
                    oldText = value;
                }
            }
        }

        private string ListJoin
        {
            get
            {
                return string.Join("|", CheckedValues);
            }

        }
        public override object Value
        {
            get
            {
                return ListJoin;
                //return base.Text;
            }
            set
            {
                var oldValue = Value;
                if (value != null && !(value is DBNull))
                {
                    var _textList = value.ToString().Split('|');
                    Items.OfType<DataRowView>().Where(i => _textList.Contains(i[ValueMember].ToString())).ToList().ForEach(c =>
                    {
                        SetItemChecked(Items.IndexOf(c), true);
                    });
                    Items.OfType<DataRowView>().Where(i => !_textList.Contains(i[ValueMember].ToString())).ToList().ForEach(c =>
                    {
                        SetItemChecked(Items.IndexOf(c), false);
                    });
                    //UpdateEspackControl();
                }
                if (oldValue != Value)
                    OnValueChanged(new ValueChangedEventArgs(oldValue, value));
            }
        }
        public void SetItemChecked(int index, bool value)
        {
            CheckedComboBox.SetItemChecked(index, value);
        }
        public bool GetItemChecked(int index)
        {
            return CheckedComboBox.GetItemChecked(index);
        }
        public void SetItemCheckState(int index, CheckState state)
        { 
            CheckedComboBox.SetItemCheckState(index, state);
        }
        public void ClearSelected()
        {
            CheckedComboBox.ClearSelected();
        }



        public override void SetStatus(EnumStatus value)
        {
            mStatus = value;
            if (IsCTLMOwned)
                Enabled = ((Add && GetStatus() == EnumStatus.ADDNEW) || (Upp && GetStatus() == EnumStatus.EDIT && !PK) || (Del && GetStatus() == EnumStatus.DELETE) || (Search && GetStatus() == EnumStatus.SEARCH)) && !Protected;
        }

        public override Control Control { get => CheckedComboBox; }

        public EspackCheckedComboBox()
            : base()
        {
            InitializeComponent();
            CheckOnClick = true;
            var _m = new Padding();
            _m = base.Margin;
            _m.Top = 16;
            base.Margin = _m;
            CheckedComboBox.ItemCheck += EspackCheckedComboBox_ItemCheck;
            CheckedComboBox.DropDownClosed += EspackCheckedComboBox_DropDownClosed;
        }

        private void EspackCheckedComboBox_Resize(object sender, EventArgs e)
        {
            CheckedComboBox.Size = new Size(this.Width, this.Height - CheckedComboBox.Top);
        }

        private void EspackCheckedComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (oldValue != Value)
                OnValueChanged(new ValueChangedEventArgs(oldValue, Value));
        }


        private object oldValue;
        private void EspackCheckedComboBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (noChange)
                return;
            noChange = true;
            //noChange = true;
            //var handler = ValueChanged;

            oldValue = Value;
            SetItemCheckState(e.Index, e.NewValue);
            var ex = new AfterItemCheckEventArgs(e.Index, e.CurrentValue, e.NewValue) { ListCurrentValue = oldValue.ToString(), ListNewValue = Value.ToString() };
            OnAfterItemCheck(ex);
            noChange = false;
        }
        public void OnAfterItemCheck(AfterItemCheckEventArgs e)
        {
            AfterItemCheck?.Invoke(this, e);
        }

        private void EspackComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (oldText != Text)
                OnValueChanged(new ValueChangedEventArgs(oldText, Text));
            oldText = Value.ToString();
            if (TBDescription != null)
            {
                if (ValueMember != null && SelectedValue != null)
                {
                    TBDescription.Text = SelectedValue.ToString();
                }
                else
                {
                    TBDescription.Text = "";
                }
            }
        }
        public void Source(string pSQL, cAccesoDatosNet pConn)
        {
            noChange = true;
            _SQL = pSQL;
            _RS = new StaticRS(_SQL, pConn);
            _RS.Open();
            DataSource = null;
            DataSource = _RS.DataObject;

            if (_RS.FieldCount > 1)
                DisplayMember = _RS.Fields[1];
            ValueMember = _RS.Fields[0];
            SelectedItem = null;
            noChange = false;
        }
        public void Source(string pSql)
        {
            Source(pSql, ParentConn);
        }
        public void Source(string pSql, EspackTextBox pTB)
        {
            Source(pSql, ParentConn);
            TBDescription = pTB;
            TBDescription.IsCTLMOwned = true;
        }

        public override void UpdateEspackControl()
        {
            var _old = Value;
            noChange = true;
            ClearSelected();
            if (ParentDA != null)
                Text = ParentDA.SelectRS[DBField.ToString()].ToString();
            Value = Text;
            //for (var i = 0; i < Items.Count; i++)
            //{
            //    SetItemChecked(i, false);
            //    foreach (var item in Text.Split('|'))
            //    {
            //        var r = ((DataRowView)Items[i]).Row;
            //        var _l = r[ValueMember].ToString();
            //        if (_l == item)
            //        {
            //            SetItemChecked(i, true);
            //            break;
            //        }
            //    }
            //}
            noChange = false;
        }
        public string keyItem(int _index)
        {
            var r = ((DataRowView)Items[_index]).Row;
            return r[ValueMember].ToString();
        }
        public int indexItem(string key)
        {
            return Items.IndexOf(Items.Cast<DataRowView>().First(x => x[ValueMember].ToString() == key));
            //for (var i = 0; i < Items.Count; i++)
            //{
            //    var r = ((DataRowView)Items[i]).Row;
            //    var _l = r[ValueMember].ToString();
            //    if (_l == key)
            //    {
            //        return i;
            //    }
            //}
            //return -1;
        }
        public bool this[string key]
        {
            get
            {
                return GetItemChecked(Items.IndexOf(Items.Cast<DataRowView>().First(x => x[ValueMember].ToString() == key)));
            }
            set
            {
                SetItemChecked(indexItem(key), value);
            }
        }
        public bool itemStatus(string key)
        {
            return GetItemChecked(indexItem(key));
        }
        public bool itemStatus(int index)
        {
            return GetItemChecked(index);
        }

        public void CheckItem(string key)
        {
            SetItemChecked(indexItem(key), true);
        }

        public void UnCheckItem(string key)
        {
            SetItemChecked(indexItem(key), false);
        }

        public override void ClearEspackControl()
        {
            var _old = Value;
            noChange = true;
            Value = "";
            noChange = false;
        }




    }
}
