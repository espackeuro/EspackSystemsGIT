using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using CheckedComboBoxNS;
using EspackControls;
using CommonTools;
using AccesoDatosNet;


namespace EspackFormControls
{
    public partial class EspackCheckedComboBox : CheckedComboBox, EspackFormControl
    {
        public bool IsCTLMOwned { get; set; } = false;
        public EspackControl ExtraDataLink { get; set; } = null;
        public EspackControlTypeEnum EspackControlType { get; set; }
        public EspackLabel CaptionLabel { get; set; }
        public DynamicRS DependingRS { get; set; }
        public cAccesoDatosNet ParentConn { get; set; }
        private EnumStatus mStatus;
        private DynamicRS _RS;
        private string _SQL;
        private bool noChange = false;
        public bool Protected { get; set; }


        public event EventHandler<ChangeEventArgs> Changed;
        public event EventHandler<AfterItemCheckEventArgs> AfterItemCheck;


        public new bool Visible
        {
            get
            {
                return base.Visible;
            }
            set
            {
                base.Visible = value;
                if (CaptionLabel != null)
                    CaptionLabel.Visible = value;
            }
        }

        //Default event handler for CTLM
        private void DefaultEventChanged(object source, EventArgs e)
        {
            return;
        }

        public EnumStatus GetStatus()
        {
            return mStatus;
        }

        public void SetStatus(EnumStatus value)
        {
            mStatus = value;
            if (IsCTLMOwned)
                Enabled = ((Add && GetStatus() == EnumStatus.ADDNEW) || (Upp && GetStatus() == EnumStatus.EDIT && !PK) || (Del && GetStatus() == EnumStatus.DELETE) || (Search && GetStatus() == EnumStatus.SEARCH)) && !Protected;
        }

        public DA ParentDA { get; set; }
        public object Value
        {
            get
            {
                string _result = ListJoin;

                return _result;// == "" ? "" : "|" + _result + "|";
                //return base.Text;
            }
            set
            {
                if (value != null)
                {
                    base.Text = value.ToString();
                    Items.OfType<DataRowView>().Where(i => base.Text.Contains(i[ValueMember].ToString())).ToList().ForEach(c =>
                    {
                        SetItemChecked(Items.IndexOf(c), true);
                    });
                    Items.OfType<DataRowView>().Where(i => !base.Text.Contains(i[ValueMember].ToString())).ToList().ForEach(c =>
                    {
                        SetItemChecked(Items.IndexOf(c), false);
                    });
                    //UpdateEspackControl();
                }
            }
        }
        public string Caption
        {
            get
            {
                if (CaptionLabel != null)
                {
                    return CaptionLabel.Caption;
                }
                else return null;
            }
            set
            {
                if (CaptionLabel.Parent == null && Parent != null)
                {
                    Parent.Controls.Add(CaptionLabel);
                }
                CaptionLabel.Caption = value;
                //CaptionLabel.Location = new Point(Location.X - CaptionLabel.PreferredWidth - 6, Location.Y);
                CaptionLabel.Location = new Point(base.Location.X, base.Location.Y - CaptionLabel.PreferredHeight);
            }
        }

        public string DBField { get; set; }
        public bool Add { get; set; }
        public bool Upp { get; set; }
        public bool Del { get; set; }
        public int Order { get; set; }
        public bool PK { get; set; }
        public bool Search { get; set; }
        public object DefaultValue { get; set; }
        public Type DBFieldType { get; set; }

        //own properties
        //public DynamicRS DataSource { get; set; }
        //public string DisplayMember { get; set; }
        //public string ValueMember { get; set; }



        public EspackCheckedComboBox()
            : base()
        {
            CaptionLabel = new EspackLabel("", this) { AutoSize = true };
            CheckOnClick = true;
            //Format = DateTimePickerFormat.Custom;
            //CustomFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern‌ + " " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern‌;
            var _m = new Padding();
            _m = base.Margin;
            _m.Top = 16;
            base.Margin = _m;
            EspackTheme.changeControlFormat(this);
            ItemCheck += EspackCheckedComboBox_ItemCheck;
            Changed += DefaultEventChanged;
            AfterItemCheck += EspackCheckedListBox_AfterItemCheck;
        }

        private void EspackCheckedListBox_AfterItemCheck(object sender, AfterItemCheckEventArgs e)
        {
            if (e.ListNewValue != e.ListCurrentValue)
            {
                var _ev = new ChangeEventArgs() { CurrentValue = e.ListCurrentValue, NewValue = e.ListNewValue };
                Changed(this, _ev);
            }

        }

        private void EspackCheckedComboBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (noChange)
                return;
            noChange = true;
            var _old = Value;
            //noChange = true;
            var handler = AfterItemCheck;
            if (handler != null)
            {
                Delegate[] invocationList = AfterItemCheck.GetInvocationList();
                foreach (var receiver in invocationList)
                {
                    AfterItemCheck -= (EventHandler<AfterItemCheckEventArgs>)receiver;
                }

                SetItemCheckState(e.Index, e.NewValue);

                foreach (var receiver in invocationList)
                {
                    AfterItemCheck += (EventHandler<AfterItemCheckEventArgs>)receiver;
                }
            }
            var ex = new AfterItemCheckEventArgs(e.Index, e.CurrentValue, e.NewValue) { ListCurrentValue = _old.ToString(), ListNewValue = Value.ToString() };
            OnAfterItemCheck(ex);
            noChange = false;
        }

        public void OnAfterItemCheck(AfterItemCheckEventArgs e)
        {
            AfterItemCheck?.Invoke(this, e);
        }


        ~EspackCheckedComboBox()
        {
            CaptionLabel.Visible = false;
            CaptionLabel.Dispose();
            CaptionLabel = null;
        }

        public void Source(string pSQL, cAccesoDatosNet pConn)
        {
            noChange = true;
            _SQL = pSQL;
            _RS = new DynamicRS(_SQL, pConn);
            _RS.Open();
            DataSource = null;
            DataSource = _RS.DataObject;
            DisplayMember = _RS.Fields[1];
            if (_RS.FieldCount > 1)
                ValueMember = _RS.Fields[0];
            SelectedItem = null;
            noChange = false;
        }
        //public void Load()
        //{
        //    while (!_RS)
        //}

        public void Source(string pSql)
        {
            Source(pSql, ParentConn);
        }


        //protected override void OnItemCheck(ItemCheckEventArgs e)
        //{
        //    base.OnItemCheck(e);
        //    EventHandler handler = AfterItemCheck;
        //    if (handler != null)
        //        SetItemCheckState(e.Index, e.NewValue);
        //    if (noChange == false)
        //    {
        //        EventArgs _ev = new EventArgs();
        //        Changed(this, _ev);
        //    }
        //}


        public void UpdateEspackControl()
        {
            var _old = Value;
            noChange = true;
            ClearSelected();
            if (ParentDA != null)
                Text = ParentDA.SelectRS[DBField.ToString()].ToString();
            var _textList = Text.Split('|');
            Items.OfType<DataRowView>().Where(i => _textList.Contains(i[ValueMember].ToString())).ToList().ForEach(c =>
            {
                SetItemChecked(Items.IndexOf(c), true);
            });
            Items.OfType<DataRowView>().Where(i => !_textList.Contains(i[ValueMember].ToString())).ToList().ForEach(c =>
            {
                SetItemChecked(Items.IndexOf(c), false);
            });
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
            if (Value.ToString() != _old.ToString())
            {
                var _ev = new ChangeEventArgs() { CurrentValue = _old.ToString(), NewValue = Value.ToString() };
                Changed(this, _ev);
            }
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

        public void ClearEspackControl()
        {
            var _old = Value;
            noChange = true;
            Items.Cast<DataRowView>().ToList().ForEach(x => SetItemChecked(Items.IndexOf(x), false));
            //for (var i = 0; i < Items.Count; i++)
            //{
            //    SetItemChecked(i, false);
            //}

            if (Value.ToString() != _old.ToString())
            {
                var _ev = new ChangeEventArgs() { CurrentValue = _old.ToString(), NewValue = Value.ToString() };
                Changed(this, _ev);
            }
            noChange = false;
        }
        public List<string> CheckedValues
        {
            get
            {
                return CheckedItems.Cast<DataRowView>().Select(x => x[ValueMember].ToString()).ToList();
                //IEnumerable<string> l = (from DataRowView item in CheckedItems select item.Row[ValueMember].ToString());
                //return l.ToList<string>();
            }
        }
        private string ListJoin
        {
            get
            {
                return string.Join("|", CheckedValues);
            }

        }
        protected override void OnParentChanged(EventArgs e)
        {
            if (Parent != null && CaptionLabel != null)
            {
                Parent.Controls.Add(CaptionLabel);
                base.OnParentChanged(e);
            }
        }

        protected override void OnMove(EventArgs e)
        {
            //CaptionLabel.Location = new Point(Location.X - CaptionLabel.PreferredWidth - 6, Location.Y);
            CaptionLabel.Location = new Point(base.Location.X, base.Location.Y - CaptionLabel.PreferredHeight);
            base.OnMove(e);
        }



    }
}
