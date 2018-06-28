using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EspackControls;
using CommonTools;
using AccesoDatosNet;

namespace EspackFormControlsNS
{

    public partial class EspackComboBox : EspackFormControlCaption
    {
        //protected override Label CaptionLabel { get; set; }
        public ComboBox ComboBox;
        //public override Label CaptionLabel { get; set; }

        public EspackTextBox TBDescription { get; set; }
        public AutoCompleteStringCollection AutoCompleteCustomSource { get => ComboBox.AutoCompleteCustomSource; set => ComboBox.AutoCompleteCustomSource = value; }
        public AutoCompleteSource AutoCompleteSource { get => ComboBox.AutoCompleteSource; set => ComboBox.AutoCompleteSource = value; }
        public AutoCompleteMode AutoCompleteMode { get => ComboBox.AutoCompleteMode; set => ComboBox.AutoCompleteMode = value; }
        public FlatStyle FlatStyle { get => ComboBox.FlatStyle; set => ComboBox.FlatStyle = value; }
        public string ValueMember { get => ComboBox.ValueMember; set => ComboBox.ValueMember = value; }
        public object SelectedValue { get => ComboBox.SelectedValue; set => ComboBox.SelectedValue = value; }
        public object SelectedItem { get => ComboBox.SelectedItem; set => ComboBox.SelectedItem = value; }
        public object DataSource { get => ComboBox.DataSource; set => ComboBox.DataSource = value; }
        public string DisplayMember { get => ComboBox.DisplayMember; set => ComboBox.DisplayMember = value; }
        

        private string oldText;
        private StaticRS _RS;
        private string _SQL;

        public override string Text
        {
            get => ComboBox.Text;
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


        public override object Value
        {
            get
            {
                return Text == "System.Data.DataRowView" ? "" : Text;
            }
            set
            {
                if (value != null)
                {
                    Text = value.ToString();
                }
            }
        }
        public override string Caption
        {
            get => CaptionLabel.Text;
            set => CaptionLabel.Text = value;

        }


        public override void SetStatus(EnumStatus value)
        {
            mStatus = value;
            if (IsCTLMOwned)
                Enabled = ((Add && GetStatus() == EnumStatus.ADDNEW) || (Upp && GetStatus() == EnumStatus.EDIT && !PK) || (Del && GetStatus() == EnumStatus.DELETE) || (Search && GetStatus() == EnumStatus.SEARCH)) && !Protected;
        }
        public override Control Control { get => ComboBox; }

        public EspackComboBox()
            : base()
        {
            InitializeComponent();
            Text = "";
            //Format = DateTimePickerFormat.Custom;
            //CustomFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern‌ + " " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern‌;
            Size = new Size(130, 20);
            var _m = new Padding();
            _m = base.Margin;
            _m.Top = 16;
            base.Margin = _m;
            AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            AutoCompleteSource = AutoCompleteSource.ListItems;
            ComboBox.SelectedValueChanged += EspackComboBox_SelectedValueChanged;
            this.FlatStyle = FlatStyle.Flat;
            oldText = "";
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

            _SQL = pSQL;
            _RS = new StaticRS(_SQL, pConn);
            _RS.Open();
            DataSource = _RS.DataObject;
            DisplayMember = _RS.Fields[0];
            if (_RS.FieldCount > 1)
                ValueMember = _RS.Fields[1];
            SelectedItem = null;
            //Text = "...";
            //Value = "";
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
            Text = ParentDA.SelectRS[DBField.ToString()].ToString();
            //return Task.FromResult(0);
        }
        public override void ClearEspackControl()
        {

            if (TBDescription != null)
            {
                TBDescription.Text = "";
            }
            SelectedItem = null;
        }


    }
}

    