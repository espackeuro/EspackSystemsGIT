using AccesoDatosNet;
using CommonTools;
using EspackControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace EspackFormControlsNS
{
    public class ValueChangedEventArgs : EventArgs
    {
        public object OldValue { get; set; }
        public object NewValue { get; set; }
        public ValueChangedEventArgs(object oldValue, object newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
    public class ChangeEventArgs : EventArgs
    {
        public string CurrentValue { get; set; }
        public List<int> Index { get; set; }
        public string NewValue { get; set; }

    }
    public class AfterItemCheckEventArgs : ItemCheckEventArgs
    {
        public AfterItemCheckEventArgs(int Index, CheckState CurrentValue, CheckState NewValue) : base(Index, CurrentValue, NewValue) { }

        public string ListCurrentValue { get; set; }
        public string ListNewValue { get; set; }

    }

    public class EspackFormControlCommonMiddle : EspackFormControlCommon
    {
        public override object Value { get; set; }

        //public string Caption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void ClearEspackControl()
        {
            throw new NotImplementedException();
        }

        public override void UpdateEspackControl()
        {
            throw new NotImplementedException();
        }
        //public override Label CaptionLabel { get; set; }
    }

    public class EspackFormControlCaption : EspackFormControlCommon
    {
        protected Label CaptionLabel;
        public override bool ReadOnly { get; set; }
        public override object Value { get; set; }
        public virtual Control Control { get; }
        public override void ClearEspackControl()
        {
            //throw new NotImplementedException();
        }

        public override void UpdateEspackControl()
        {
            //throw new NotImplementedException();
        }
        public EspackFormControlCaption()
            : base()
        {
            CaptionLabel = new Label();
            SuspendLayout();
            this.CaptionLabel.AutoSize = true;
            this.CaptionLabel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CaptionLabel.Location = new System.Drawing.Point(0, 0);
            this.CaptionLabel.Name = "CaptionLabel";
            this.CaptionLabel.Size = new System.Drawing.Size(50, 13);
            this.CaptionLabel.TabIndex = 1;
            this.CaptionLabel.Text = "";

            

            this.ResumeLayout(false);
            Load += EspackFormControlCaption_Load;
            this.Invalidated += EspackFormControlCaption_Invalidated;
            this.PerformLayout();
            
        }

        private void EspackFormControlCaption_Invalidated(object sender, InvalidateEventArgs e)
        {
            _resizing = true;
            var _labelHeight = CaptionLabel.Text == "" ? 0 : CaptionLabel.Height + 3;
            if (Control != null)
            {
                this.Size = new Size(this.Width, _labelHeight + Control.Height);
                //Control.Size = new Size(this.Width, this.Height - _labelHeight);
                Control.Location = new Point(0, _labelHeight);
            }
            _resizing = false;
        }

        public virtual string Caption
        {
            get => CaptionLabel.Text;
            set
            {
                //if (value == "")
                //    CaptionLabel.Size = new Size(0, 0);
                //else
                //    CaptionLabel.Size= new System.Drawing.Size(50, 13);
                CaptionLabel.Text = value;
                Invalidate();
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
            get
            {
                if (this.DesignMode && (Environment.StackTrace.Contains("System.Windows.Forms.Design.ControlDesigner.InitializeNewComponent")))
                    return "";
                return Control?.Text ?? "";
            }
            set
            {
                if (this.DesignMode && (Environment.StackTrace.Contains("System.Windows.Forms.Design.ControlDesigner.InitializeNewComponent")))
                    return;
                Control.Text = value;
                Invalidate();
            }
        }

        private void EspackFormControlCaption_Load(object sender, EventArgs e)
        {
            var _labelHeight = CaptionLabel.Text == "" ? 0 : CaptionLabel.Height + 3;
            if (Control != null)
            {
                Control.Size = new Size(this.Width, this.Height - _labelHeight);
                Control.Location = new Point(0, _labelHeight);
                this.Size = new Size(Control.Width, _labelHeight + Control.Height);
            }


            Resize += EspackFormControlCaption_Resize;
        }

        private bool _resizing = false;
        private void EspackFormControlCaption_Resize(object sender, EventArgs e)
        {
            if (!_resizing)
            {
                _resizing = true;
                var _labelHeight = CaptionLabel.Text == "" ? 0 : CaptionLabel.Height + 3;
                if (Control != null)
                {
                    Control.Size = new Size(this.Width, this.Height - Control.Top);
                    Control.Location = new Point(0, _labelHeight);
                    this.Size = new Size(Control.Width, _labelHeight + Control.Height);
                }
                _resizing = false;
            }
        }
    }

    public abstract class EspackFormControlCommon : UserControl, EspackControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        public bool IsCTLMOwned { get; set; } = false;
        public EspackControl ExtraDataLink { get; set; } = null;
        public virtual EspackControlTypeEnum EspackControlType { get; set; }
        public cAccesoDatosNet ParentConn { get; set; }
        protected EnumStatus mStatus;
        protected DynamicRS mDependingRS;

        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        public bool Protected { get; set; }

        public virtual EnumStatus Status { get => GetStatus(); set => SetStatus(value); }

        public EnumStatus GetStatus()
        {
            return mStatus;
        }

        public virtual bool ReadOnly { get; set; }

        public virtual void SetStatus(EnumStatus value)
        {
            mStatus = value;
            Enabled = !Protected;
            if (IsCTLMOwned)
                ReadOnly = !((Add && GetStatus() == EnumStatus.ADDNEW) || (Upp && GetStatus() == EnumStatus.EDIT && !PK) || (Del && GetStatus() == EnumStatus.DELETE) || (Search && GetStatus() == EnumStatus.SEARCH)) || Protected;
            BackColor = ReadOnly ? SystemColors.ButtonFace : Color.White;
            ForeColor = ReadOnly ? Color.Gray : Color.Black;

        }



        public abstract object Value { get; set; }

        public virtual string DBField { get; set; }
        public bool Add { get; set; }
        public bool Upp { get; set; }
        public bool Del { get; set; }
        public int Order { get; set; }
        public bool PK { get; set; }
        public bool Search { get; set; }
        public virtual object DefaultValue { get; set; }
        public virtual Type DBFieldType { get; set; }
        public virtual DA ParentDA { get; set; }
        public virtual DynamicRS DependingRS { get => mDependingRS; set => mDependingRS = value; }
        //public override 

        


        public EspackFormControlCommon()
            : base()
        {
            //CaptionLabel = new EspackLabel("", this) { AutoSize = true };
            this.SuspendLayout();
            //Controls.Add(CaptionLabel);

            this.Size = new Size(10, 10);
            ResumeLayout(false);
            PerformLayout();
            //ParentChanged += EspackFormControlCommon_ParentChanged;
        }

        private void EspackFormControlCommon_ParentChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                foreach (Control c in Controls)
                    Parent.Controls.Add(c);
            }
        }

        protected override void OnMove(EventArgs e)
        {
            //CaptionLabel.Location = new Point(base.Location.X, base.Location.Y - CaptionLabel.PreferredHeight);
            //CaptionLabel.Location = new Point(Location.X - CaptionLabel.PreferredWidth - 6, Location.Y);
            base.OnMove(e);
        }

        public abstract void UpdateEspackControl();

        //public void OnTextChanged(EventArgs e)
        //{
        //    foreach (EspackControl lControl in DependingControls)
        //    {
        //        lControl.UpdateEspackControl(EspackControlTypeEnum.DEPENDANT);
        //    }
        //}

        public abstract void ClearEspackControl();


        protected virtual void OnValueChanged(ValueChangedEventArgs e)
        {
            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            ValueChanged?.Invoke(this, e);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // EspackFormControlCommon
            // 
            this.Name = "EspackFormControlCommon";
            this.Size = new System.Drawing.Size(639, 150);
            this.ResumeLayout(false);

        }
    }
}
