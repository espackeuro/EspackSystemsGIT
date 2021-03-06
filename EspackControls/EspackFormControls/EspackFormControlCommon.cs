﻿using System;
using System.Windows.Forms;
using System.Drawing;
using EspackControls;
using CommonTools;
using AccesoDatosNet;

namespace EspackFormControls
{
    public class EspackFormControlCommonMiddle : EspackFormControlCommon
    {
        public override bool ReadOnly { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override object Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override string Caption { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void ClearEspackControl()
        {
            throw new NotImplementedException();
        }

        public override void UpdateEspackControl()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class EspackFormControlCommon : UserControl, EspackFormControl
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
        public EspackLabel CaptionLabel { get; set; }
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

        public abstract bool ReadOnly { get; set; }

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
        public virtual bool Add { get; set; }
        public virtual bool Upp { get; set; }
        public virtual bool Del { get; set; }
        public virtual int Order { get; set; }
        public virtual bool PK { get; set; }
        public virtual bool Search { get; set; }
        public virtual object DefaultValue { get; set; }
        public virtual Type DBFieldType { get; set; }
        public virtual DA ParentDA { get; set; }
        public virtual DynamicRS DependingRS { get => mDependingRS; set => mDependingRS = value; }
        //public override 

        public abstract string Caption { get; set; }


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


        public void OnValueChanged(ValueChangedEventArgs e)
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
