using System;
using System.Windows.Forms;
using System.Drawing;
using EspackControls;
using CommonTools;
using AccesoDatosNet;

namespace EspackFormControls
{
    public class EspackTextBox : TextBox, EspackFormControl
    {
        public bool IsCTLMOwned { get; set; } = false;
        public EspackControl ExtraDataLink { get; set; } = null;
        public EspackControlTypeEnum EspackControlType { get; set; }
        public EspackLabel CaptionLabel { get; set; }
        public cAccesoDatosNet ParentConn { get; set; }
        private EnumStatus mStatus;
        private DynamicRS mDependingRS;

        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        public bool Protected { get; set; }
        //private Padding _margin;
        //private Size _size;

        //public new Size Size
        //{
        //    get
        //    {
        //        return _size;
        //    }
        //    set
        //    {
        //        _size = value;
        //        base.Height = value.Height-CaptionLabel.Height;
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
        ////[DefaultValue(typeof(Padding), "3, 3, 3, 3")]
        //public new Padding Margin
        //{
        //    get
        //    {
        //        return _margin;
        //    }
        //    set
        //    {

        //        var gap = 0;
        //        if (CaptionLabel != null)
        //            gap = CaptionLabel.Height;
        //        var _m = new Padding();
        //        _margin = value;
        //        _m = _margin;
        //        _m.Top += gap;
        //        BaseMargin = _m;
        //    }
        //}

        //[Category("Layout")]
        //[DefaultValue(typeof(Padding), "3, 16, 3, 3")]
        //public Padding BaseMargin
        //{
        //    get
        //    {
        //        return base.Margin;
        //    }
        //    set
        //    {
        //        base.Margin = value;
        //    }
        //}

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

        public EnumStatus Status { get => GetStatus(); set => SetStatus(value); }

        public EnumStatus GetStatus()
        {
            return mStatus;
        }

        public void SetStatus(EnumStatus value)
        {
            mStatus = value;
            Enabled = !Protected;
            if (IsCTLMOwned)
                ReadOnly = !((Add && GetStatus() == EnumStatus.ADDNEW) || (Upp && GetStatus() == EnumStatus.EDIT && !PK) || (Del && GetStatus() == EnumStatus.DELETE) || (Search && GetStatus() == EnumStatus.SEARCH)) || Protected;
            BackColor = ReadOnly ? SystemColors.ButtonFace : Color.White;
            ForeColor = ReadOnly ? Color.Gray : Color.Black;

        }


        public object Value
        {
            get
            {
                return Text;
            }
            set
            {
                oldText = Value.ToString();
                Text = value?.ToString();
            }
        }
        private string oldText;
        public string DBField { get; set; }
        public bool Add { get; set; }
        public bool Upp { get; set; }
        public bool Del { get; set; }
        public int Order { get; set; }
        public bool PK { get; set; }
        public bool Search { get; set; }
        public object DefaultValue { get; set; }
        public Type DBFieldType { get; set; }
        public DA ParentDA { get; set; }
        public DynamicRS DependingRS
        {
            get
            {
                return mDependingRS;
            }
            set
            {
                mDependingRS = value;
                if (value!=null)
                    mDependingRS.AfterExecution += mDependingRS_AfterExecution;
            }
        }

        void mDependingRS_AfterExecution(object sender, EventArgs e)
        {
            Text=mDependingRS[DBField].ToString();
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


        //List<StaticRS> ExternalControls;//list of possible external controls, the key is the parameter name and the object is the control
        //List<EspackControl> DependingControls; //list of those controls which have me as external control


        //void AddExternalControl(string pParameterName, StaticRS pRS)
        //{
        //    EspackControlType &= EspackControlTypeEnum.DEPENDANT;
        //    ExternalControls.Add(pParameterName, pRS);
        //    foreach (ControlParameter lControl in pRS.ControlParameters)
        //    {
        //        if (lControl.LinkedControl is EspackFormControl)
        //        {
        //            ((EspackFormControl)lControl.LinkedControl).DependingControls.Add(this);
        //        }
        //    }
        //}


        public EspackTextBox()
            : base()
        {
            CaptionLabel = new EspackLabel("", this) { AutoSize = true };
            //var _m = new Padding();
            //_m = base.Margin;
            //_m.Top = 16;
            //base.Margin = _m;
            //Margin = _m;
            EspackTheme.changeControlFormat(this);
            this.Validated += EspackTextBox_Validated;
            oldText = "";
        }

        private void EspackTextBox_Validated(object sender, EventArgs e)
        {
                if (oldText != Text)
                OnValueChanged(new ValueChangedEventArgs(oldText, Text));
            oldText = Text;
        }

        ~EspackTextBox()
        {
            if (CaptionLabel!= null)
                CaptionLabel.Dispose();
            CaptionLabel = null;
        }
        protected override void OnParentChanged(EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Controls.Add(CaptionLabel);
                base.OnParentChanged(e);
            }
        }

        protected override void OnMove(EventArgs e)
        {
            CaptionLabel.Location = new Point(base.Location.X, base.Location.Y - CaptionLabel.PreferredHeight);
            //CaptionLabel.Location = new Point(Location.X - CaptionLabel.PreferredWidth - 6, Location.Y);
            base.OnMove(e);
        }

        public void UpdateEspackControl()
        {
            if ((EspackControlType & EspackControlTypeEnum.CTLM) == EspackControlTypeEnum.CTLM)
            {
                Text = ParentDA.SelectRS[DBField.ToString()].ToString();
            }
        }

        //public void OnTextChanged(EventArgs e)
        //{
        //    foreach (EspackControl lControl in DependingControls)
        //    {
        //        lControl.UpdateEspackControl(EspackControlTypeEnum.DEPENDANT);
        //    }
        //}

        public void ClearEspackControl()
        {
            Text = "";
        }

        public void OnValueChanged(ValueChangedEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            ValueChanged?.Invoke(this, e);
        }
    }

}
