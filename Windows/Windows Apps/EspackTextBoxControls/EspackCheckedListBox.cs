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


namespace EspackFormControlsNS
{
    public partial class EspackCheckedListBox : EspackFormControlCaption
    {
        public CheckedListBox CheckedListBox;
        //public override Label CaptionLabel { get; set; }

        public EspackTextBox TBDescription { get; set; }
        public string ValueMember { get => CheckedListBox.ValueMember; set => CheckedListBox.ValueMember = value; }
        public object SelectedValue { get => CheckedListBox.SelectedValue; set => CheckedListBox.SelectedValue = value; }
        public object SelectedItem { get => CheckedListBox.SelectedItem; set => CheckedListBox.SelectedItem = value; }
        public object DataSource { get => CheckedListBox.DataSource; set => CheckedListBox.DataSource = value; }
        public string DisplayMember { get => CheckedListBox.DisplayMember; set => CheckedListBox.DisplayMember = value; }
        public bool CheckOnClick { get => CheckedListBox.CheckOnClick; set => CheckedListBox.CheckOnClick = value; }
        public override Font Font { get => CheckedListBox.Font; set => CheckedListBox.Font = value; }
        public bool MultiColumn { get => CheckedListBox.MultiColumn; set => CheckedListBox.MultiColumn = value; }
        public int ColumnWidth { get => CheckedListBox.ColumnWidth; set => CheckedListBox.ColumnWidth = value; }
        public bool FormattingEnabled { get => CheckedListBox.FormattingEnabled; set => CheckedListBox.FormattingEnabled = value; }

        public List<string> CheckedValues
        {
            get
            {
                return CheckedItems.Cast<DataRowView>().Select(x => x[ValueMember].ToString()).ToList();
                //IEnumerable<string> l = (from DataRowView item in CheckedItems select item.Row[ValueMember].ToString());
                //return l.ToList<string>();
            }
        }
        public CheckedListBox.CheckedItemCollection CheckedItems { get => CheckedListBox.CheckedItems; }
        public CheckedListBox.ObjectCollection Items { get => CheckedListBox.Items; }
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

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [Category("Appearance")]
        public override string Text
        {
            get => CheckedListBox.Text;
            set
            {
                if (value != CheckedListBox.Text)
                {
                    //raise the value change event
                    oldText = base.Text;
                    CheckedListBox.Text = value;
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
            CheckedListBox.SetItemChecked(index, value);
        }
        public bool GetItemChecked(int index)
        {
            return CheckedListBox.GetItemChecked(index);
        }
        public void SetItemCheckState(int index, CheckState state)
        { 
            CheckedListBox.SetItemCheckState(index, state);
        }
        public void ClearSelected()
        {
            CheckedListBox.ClearSelected();
        }
        public override string Caption
        {
            get => CaptionLabel.Text;
            set
            {
                CaptionLabel.Text = value;
                //Name = string.Format("lbl{0}", Caption.Replace(" ", "_"));
            }
        }


        public override void SetStatus(EnumStatus value)
        {
            mStatus = value;
            if (IsCTLMOwned)
                Enabled = ((Add && GetStatus() == EnumStatus.ADDNEW) || (Upp && GetStatus() == EnumStatus.EDIT && !PK) || (Del && GetStatus() == EnumStatus.DELETE) || (Search && GetStatus() == EnumStatus.SEARCH)) && !Protected;
        }
        public override Control Control { get => CheckedListBox; }

        public EspackCheckedListBox()
            : base()
        {
            InitializeComponent();
            CheckOnClick = true;
            var _m = new Padding();
            _m = base.Margin;
            _m.Top = 16;
            base.Margin = _m;

            CheckedListBox.ItemCheck += EspackCheckedListBox_ItemCheck;
            Resize += EspackCheckedListBox_Resize;
            CheckedListBox.Size = new Size(this.Width, CheckedListBox.Height);
        }

        private void EspackCheckedListBox_Resize(object sender, EventArgs e)
        {
            CheckedListBox.Size = new Size(this.Width, this.Height - CheckedListBox.Top);
        }

        private void EspackCheckedListBox_DropDownClosed(object sender, EventArgs e)
        {
            if (oldValue != Value)
                OnValueChanged(new ValueChangedEventArgs(oldValue, Value));
        }


        private object oldValue;
        private void EspackCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
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
                CheckedListBox.DisplayMember = _RS.Fields[1];
            CheckedListBox.ValueMember = _RS.Fields[0];
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
