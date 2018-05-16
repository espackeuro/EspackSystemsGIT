using System;
using System.Windows.Forms;
using System.Drawing;
using EspackControls;
using CommonTools;
using AccesoDatosNet;

namespace EspackFormControls
{
    public class EspackComboBox : ComboBox, EspackFormControl
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
        public EspackTextBox TBDescription { get; set; }
        public bool Protected { get; set; }

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

        private Size _size;

        //public new Size Size
        //{
        //    get
        //    {
        //        return _size;
        //    }
        //    set
        //    {
        //        _size = value;
        //        base.Height = value.Height - CaptionLabel.Height;
        //        base.Width = value.Width;
        //    }
        //}
        //public new Point Location
        //{
        //    get
        //    {
        //        if (CaptionLabel != null)
        //        {
        //            var _l = new Point();
        //            _l.X = base.Location.X;
        //            _l.Y = base.Location.Y - CaptionLabel.Height;
        //            return _l;
        //        }
        //        else return base.Location;
        //    }
        //    set
        //    {
        //        var gap = 0;
        //        if (CaptionLabel != null)
        //        {
        //            CaptionLabel.Location = value;
        //            gap = CaptionLabel.Height;
        //        }

        //        var _l = new Point();
        //        _l.X = value.X;
        //        _l.Y = value.Y + gap;
        //        base.Location = _l;

        //    }
        //}
        //[DefaultValue(typeof(Padding), "3, 3, 3, 3")]
        //public new Padding Margin
        //{
        //    get
        //    {
        //        var gap = 0;
        //        if (CaptionLabel != null)
        //            gap = CaptionLabel.Height;
        //        else
        //            gap = 10;
        //        var _m = new Padding();
        //        _m = base.Margin;
        //        //Text = base.Margin.Top.ToString();
        //        _m.Top -= gap;
        //        return _m;
        //    }
        //    set
        //    {
        //        var gap = 0;
        //        if (CaptionLabel != null)
        //            gap = CaptionLabel.Height;
        //        var _m = new Padding();
        //        _m = value;
        //        _m.Top += gap;
        //        base.Margin = _m;
        //    }
        //}
        public EnumStatus GetStatus()
        {
            return mStatus;
        }

        //public new Size Size
        //{
        //    get
        //    {
        //        return _size;
        //    }
        //    set
        //    {
        //        _size = value;
        //        base.Height = value.Height - CaptionLabel.Height;
        //        base.Width = value.Width;
        //    }
        //}
        //public new Point Location
        //{
        //    get
        //    {
        //        if (CaptionLabel != null)
        //        {
        //            var _l = new Point();
        //            _l.X = base.Location.X;
        //            _l.Y = base.Location.Y - CaptionLabel.Height;
        //            return _l;
        //        }
        //        else return base.Location;
        //    }
        //    set
        //    {
        //        var gap = 0;
        //        if (CaptionLabel != null)
        //        {
        //            CaptionLabel.Location = value;
        //            gap = CaptionLabel.Height;
        //        }

        //        var _l = new Point();
        //        _l.X = value.X;
        //        _l.Y = value.Y + gap;
        //        base.Location = _l;

        //    }
        //}
        //[DefaultValue(typeof(Padding), "3, 3, 3, 3")]
        //public new Padding Margin
        //{
        //    get
        //    {
        //        var gap = 0;
        //        if (CaptionLabel != null)
        //            gap = CaptionLabel.Height;
        //        else
        //            gap = 10;
        //        var _m = new Padding();
        //        _m = base.Margin;
        //        //Text = base.Margin.Top.ToString();
        //        _m.Top -= gap;
        //        return _m;
        //    }
        //    set
        //    {
        //        var gap = 0;
        //        if (CaptionLabel != null)
        //            gap = CaptionLabel.Height;
        //        var _m = new Padding();
        //        _m = value;
        //        _m.Top += gap;
        //        base.Margin = _m;
        //    }
        //}
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
                return Text == "System.Data.DataRowView" ? "" : Text;
            }
            set
            {
                if (value!= null)
                {
                    Text = value.ToString();
                } 
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

        public EspackComboBox()
        {
            CaptionLabel = new EspackLabel("", this) { AutoSize = true };
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
            this.SelectedValueChanged += delegate
            {
                if (TBDescription!= null)
                {
                    if (ValueMember!= null && SelectedValue!=null)
                    {
                        TBDescription.Text = SelectedValue.ToString();
                    }
                    else
                    {
                        TBDescription.Text = "";
                    }
                }
            };
            this.FlatStyle = FlatStyle.Flat;
            EspackTheme.changeControlFormat(this);
        }

        public void Source(string pSQL, cAccesoDatosNet pConn)
        {
            
            _SQL = pSQL;
            _RS = new DynamicRS(_SQL, pConn);
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
        public void UpdateEspackControl()
        {
            Text = ParentDA.SelectRS[DBField.ToString()].ToString();
            //return Task.FromResult(0);
        }
        public void ClearEspackControl()
        {
            
            if (TBDescription!= null)
            {
                TBDescription.Text = "";
            }
            base.SelectedItem = null;
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

        ////to be able to change borderstyle

        //private Color _borderColor = Color.Black;
        //private ButtonBorderStyle _borderStyle = ButtonBorderStyle.Solid;
        //private static int WM_PAINT = 0x000F;

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);

        //    if (m.Msg == WM_PAINT)
        //    {
        //        Graphics g = Graphics.FromHwnd(Handle);
        //        Rectangle bounds = new Rectangle(0, 0, Width, Height);
        //        ControlPaint.DrawBorder(g, bounds, _borderColor, _borderStyle);
        //    }
        //}

        //[Category("Appearance")]
        //public Color BorderColor
        //{
        //    get { return _borderColor; }
        //    set
        //    {
        //        _borderColor = value;
        //        Invalidate(); // causes control to be redrawn
        //    }
        //}

        //[Category("Appearance")]
        //public ButtonBorderStyle BorderStyle
        //{
        //    get { return _borderStyle; }
        //    set
        //    {
        //        _borderStyle = value;
        //        Invalidate();
        //    }
        //}


    }

}
