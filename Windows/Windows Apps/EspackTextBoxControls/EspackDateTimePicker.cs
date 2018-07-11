using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonTools;
using EspackControls;

namespace EspackFormControlsNS
{
    public partial class EspackDateTimePicker : EspackFormControlCaption
    {
        //protected override Label CaptionLabel { get; set; }
        public DateTimePickerFormatted DateTimePicker;
        //public override Label CaptionLabel { get; set; }
        public DateTime MinDate { get => DateTimePicker.MinDate; set => DateTimePicker.MinDate = value; }
        public string CustomFormat { get => DateTimePicker.CustomFormat; set => DateTimePicker.CustomFormat = value; }
        public DateTimePickerFormat Format { get => DateTimePicker.Format; set => DateTimePicker.Format = value; }


        private DateTime? _value;
        private bool _nullable;
        private bool _checked;
        private string _customFormat { get; set; }
        private bool _nochangeevent { get; set; }

        [Category("Appearance")]
        public Color BorderColor { get => DateTimePicker.BorderColor; set => DateTimePicker.BorderColor = value; }
        [Category("Appearance")]
        public new ButtonBorderStyle BorderStyle { get => DateTimePicker.BorderStyle; set => DateTimePicker.BorderStyle = value; }

        public bool ShowCheckBox { get => DateTimePicker.ShowCheckBox; set => DateTimePicker.ShowCheckBox = value; }

        [Category("Behavior")]
        public bool Nullable
        {
            get
            {
                return _nullable;
            }
            set
            {
                _nullable = value;
                ShowCheckBox = _nullable;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        public override string Text
        {
            get => DateTimePicker.Text;
            set => Value = value;
        }

        public override object Value
        {
            get
            {
                return _value;
            }
            set
            {
                var oldValue = Value;
                if (value == null || value.ToString() == "")
                {
                    _nochangeevent = true;
                    var _ch = Checked;
                    //base.Value = MinDate;
                    Checked = _ch;
                    CustomFormat = " ";
                    DateTimePicker.Value = MinDate;
                    _nochangeevent = false;
                    Checked = false;
                }
                else
                {
                    var _ch = Checked;
                    _nochangeevent = true;
                    if (value is string)
                    {
                        DateTime _result ;
                        if (DateTime.TryParse((string)value, out _result))
                        {
                            DateTimePicker.Value = _result;
                        }
                        else
                        {
                            Checked = false;
                            Value = null;
                        }
                    }
                    else
                        DateTimePicker.Value = (DateTime)value;
                    Checked = _ch; //base.Value assignment always changes Checked to true, we return to the origina value
                    CustomFormat = _customFormat;
                    _nochangeevent = false;
                    Checked = true;
                }
                if (oldValue != value)
                    OnValueChanged(new ValueChangedEventArgs(oldValue, value));
            }
        }
        protected override void OnValueChanged(ValueChangedEventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            //launches CheckedChanged event if needed
            if (Checked != _checked)
            {
                _checked = Checked;
                CheckedChangedEventArgs cce = new CheckedChangedEventArgs { OldCheckedValue = !_checked, NewCheckedValue = _checked };
                OnCheckedChanged(cce);
            }

            _value = DateTimePicker.Value == MinDate ? null : (DateTime?)DateTimePicker.Value;

        }
        public bool Checked
        {
            get
            {
                return DateTimePicker.Checked;
            }
            set
            {
                if (DateTimePicker.Checked != value)
                {
                    DateTimePicker.Checked = value;
                    _checked = value;
                    OnCheckedChanged(new CheckedChangedEventArgs { OldCheckedValue = !value, NewCheckedValue = value });
                }
            }
        }
        protected virtual void OnCheckedChanged(CheckedChangedEventArgs e)
        {
            if (!_nochangeevent)
                CheckedChanged?.Invoke(this, e);
        }

        public class CheckedChangedEventArgs : EventArgs
        {
            public bool OldCheckedValue { get; set; }
            public bool NewCheckedValue { get; set; }
        }
        public delegate void CheckedChangedEventHandler(object sender, CheckedChangedEventArgs e);
        public event CheckedChangedEventHandler CheckedChanged;


        public override void SetStatus(EnumStatus value)
        {
            mStatus = value;
            if (IsCTLMOwned)
                Enabled = ((Add && GetStatus() == EnumStatus.ADDNEW) || (Upp && GetStatus() == EnumStatus.EDIT && !PK) || (Del && GetStatus() == EnumStatus.DELETE) || (Search && GetStatus() == EnumStatus.SEARCH)) && !Protected;
        }
        public override Control Control { get => DateTimePicker; }

        public EspackDateTimePicker()
            : base()
        {
            InitializeComponent();

            Format = DateTimePickerFormat.Custom;
            _customFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern‌ + " " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern‌;
            Size = new Size(130, 20);
            var _m = new Padding();
            _m = DateTimePicker.Margin;
            _m.Top = 16;
            DateTimePicker.Margin = _m;
            CheckedChanged += EspackDateTimePicker_CheckedChanged;
            DateTimePicker.Enter += DateTimePicker_Enter;
        }

        private void DateTimePicker_Enter(object sender, EventArgs e)
        {
            if (!Checked) // null the data
            {
                CustomFormat = " ";
                Value = null;
            }
            else
            {
                CustomFormat = _customFormat;
            }
        }

        private void EspackDateTimePicker_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.NewCheckedValue == false)
            {
                if (Value != null)
                    Value = null;
            }
            else
            {
                if (DateTimePicker.Value == MinDate)
                    Value = DateTime.Now;
            }
        }

        public override void ClearEspackControl()
        {
            Value = MinDate;
            Checked = false;
        }

        public override void UpdateEspackControl()
        {
            if (ParentDA.SelectRS[DBField.ToString()] is DBNull)
            {
                Value = null;
            }
            else
            {
                //Text = ParentDA.SelectRS[DBField.ToString()].ToString();
                Value = ParentDA.SelectRS[DBField.ToString()];
                CustomFormat = _customFormat;
            }
        }

    }

    public class DateTimePickerFormatted : DateTimePicker
    {
        private Color _borderColor = Color.Black;
        private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 0x000F;
        [Category("Appearance")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                Invalidate(); // causes control to be redrawn
            }
        }

        [Category("Appearance")]
        public ButtonBorderStyle BorderStyle
        {
            get { return _borderStyle; }
            set
            {
                _borderStyle = value;
                Invalidate();
            }
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == WM_PAINT)
            {
                Graphics g = Graphics.FromHwnd(Handle);
                Rectangle bounds = new Rectangle(0, 0, Width, Height);
                ControlPaint.DrawBorder(g, bounds, _borderColor, _borderStyle);
            }
        }
    }
        
}
