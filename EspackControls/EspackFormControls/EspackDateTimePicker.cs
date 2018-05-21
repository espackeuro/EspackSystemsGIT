using System;
using System.Windows.Forms;
using System.Drawing;
using EspackControls;
using CommonTools;
using AccesoDatosNet;
using System.ComponentModel;

namespace EspackFormControls
{
    public class EspackDateTimePicker : DateTimePicker, EspackFormControl
    {
        public bool IsCTLMOwned { get; set; } = false;
        public EspackControl ExtraDataLink { get; set; } = null;
        public EspackControlTypeEnum EspackControlType { get; set; }
        public EspackLabel CaptionLabel { get; set; }
        public cAccesoDatosNet ParentConn { get; set; }
        public DynamicRS DependingRS { get; set; }
        private EnumStatus mStatus;
        private DateTime? _value;
        private bool _nullable;
        private bool _checked;
        public bool Protected { get; set; }

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

        public DA ParentDA { get; set; }
        public new object Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value == null || value.ToString() == "")
                {
                    _nochangeevent = true;
                    var _ch = Checked;
                    base.Value = MinDate;
                    Checked = _ch;
                    CustomFormat = " ";
                    //Text = "";
                    _nochangeevent = false;
                    Checked = false;
                }
                else
                {
                    var _ch = Checked;
                    _nochangeevent = true;
                    if (value is string)
                        base.Value = DateTime.Parse((string)value);
                    else
                        base.Value = (DateTime)value;
                    Checked = _ch; //base.Value assignment always changes Checked to true, we return to the origina value
                    CustomFormat = _customFormat;
                    _nochangeevent = false;
                    Checked = true;
                }
            }
        }


        #region Checked
        // for the event raised when Checked the nullable check
        public new bool Checked
        {
            get
            {
                return base.Checked;
            }
            set
            {
                if (base.Checked != value)
                {
                    base.Checked = value;
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
        // end CheckedChanged event definition

        #endregion Checked

        public string DBField { get; set; }
        public bool Add { get; set; }
        public bool Upp { get; set; }
        public bool Del { get; set; }
        public int Order { get; set; }
        public bool PK { get; set; }
        public bool Search { get; set; }
        public object DefaultValue { get; set; }
        public Type DBFieldType { get; set; }
        private string _customFormat { get; set; }
        private bool _nochangeevent { get; set; }
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

        public EspackDateTimePicker()
        {
            CaptionLabel = new EspackLabel("", this) { AutoSize = true };
            //MinDate = DateTime.MinValue;
            Format = DateTimePickerFormat.Custom;
            _customFormat = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern‌ + " " + System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern‌;
            Size = new Size(130, 20);
            var _m = new Padding();
            _m = base.Margin;
            _m.Top = 16;
            base.Margin = _m;
            EspackTheme.changeControlFormat(this);
            CheckedChanged += EspackDateTimePicker_CheckedChanged;
        }

        private void EspackDateTimePicker_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.NewCheckedValue == false)
            {
                if (Value != null)
                    Value = null;
            } else
            {
                if (base.Value == MinDate)
                    Value = DateTime.Now;
            }
        }

        public void UpdateEspackControl()
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
        public void ClearEspackControl()
        {
            Value = DefaultValue;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            if (Parent != null && CaptionLabel != null)
            {
                Parent.Controls.Add(CaptionLabel);
                base.OnParentChanged(e);
            }
        }
        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            //launches CheckedChanged event if needed
            if (Checked != _checked)
            {
                _checked = Checked;
                CheckedChangedEventArgs cce = new CheckedChangedEventArgs { OldCheckedValue = !_checked, NewCheckedValue = _checked };
                OnCheckedChanged(cce);
            }

            _value = base.Value == MinDate ? null : (DateTime?)base.Value;
            
        }
        protected override void OnMove(EventArgs e)
        {
            //CaptionLabel.Location = new Point(Location.X - CaptionLabel.PreferredWidth - 6, Location.Y);
            CaptionLabel.Location = new Point(base.Location.X, base.Location.Y - CaptionLabel.PreferredHeight);
            base.OnMove(e);
        }
        // to add BorderStyle

        private Color _borderColor = Color.Black;
        private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;
        private static int WM_PAINT = 0x000F;

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

        protected override void OnEnter(EventArgs e)
        {
            if (!Checked) // null the data
            {
                CustomFormat = " ";
                Value = null;
            } else
            {
                CustomFormat = _customFormat;
            }
            base.OnEnter(e);
        }


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
    }

}
