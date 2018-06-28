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

namespace EspackFormControlsNS
{
    public partial class EspackMaskedTextBox : EspackFormControlCaption
    {
        //protected override Label CaptionLabel { get; set; }
        public MaskedTextBox MaskedTextBox;
        //public override Label CaptionLabel { get; set; }

        public override bool ReadOnly { get => MaskedTextBox.ReadOnly; set => MaskedTextBox.ReadOnly = value; }
        public bool Multiline { get => MaskedTextBox.Multiline; set => MaskedTextBox.Multiline = value; }

        public override string Text
        {
            get => MaskedTextBox.Text;
            set => MaskedTextBox.Text = value;
        }
        private string oldText;
        public override object Value
        {
            get
            {
                return Text;
            }
            set
            {
                oldText = Text.ToString();
                Text = value?.ToString();
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
            Enabled = true;
            if (IsCTLMOwned)
                ReadOnly = !((Add && GetStatus() == EnumStatus.ADDNEW) || (Upp && GetStatus() == EnumStatus.EDIT && !PK) || (Del && GetStatus() == EnumStatus.DELETE) || (Search && GetStatus() == EnumStatus.SEARCH)) || Protected;
            BackColor = ReadOnly ? SystemColors.ButtonFace : Color.White;
            ForeColor = ReadOnly ? SystemColors.InactiveCaptionText : SystemColors.ControlText;
        }
        public override Control Control { get => MaskedTextBox; }

        public EspackMaskedTextBox()
                : base()
        {
            InitializeComponent();
            MaskedTextBox.Validated += EspackTextBox_Validated;
            oldText = "";
        }

        private void EspackTextBox_Validated(object sender, EventArgs e)
        {
            if (oldText != Text)
                OnValueChanged(new ValueChangedEventArgs(oldText, Text));
            oldText = Text;
        }
        protected override void OnParentChanged(EventArgs e)
        {
            if (Parent != null)
            {
                Parent.Controls.Add(CaptionLabel);
                base.OnParentChanged(e);
            }
        }
        public override void ClearEspackControl()
        {
            Text = "";
        }

        public override void UpdateEspackControl()
        {
            if ((EspackControlType & EspackControlTypeEnum.CTLM) == EspackControlTypeEnum.CTLM)
            {
                Text = ParentDA.SelectRS[DBField.ToString()].ToString();
            }
        }


    }
}

