using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using EspackControls;
using CommonTools;
using System.ComponentModel;

namespace EspackFormControlsNS
{
    public partial class EspackMaskedTextBox : EspackFormControlCaption
    {
        //protected override Label CaptionLabel { get; set; }
        public MaskedTextBox MaskedTextBox;

        //public override Label CaptionLabel { get; set; }

        public override bool ReadOnly { get => MaskedTextBox.ReadOnly; set => MaskedTextBox.ReadOnly = value; }
        //public bool Multiline { get; set; }
        public string Mask { get => MaskedTextBox.Mask; set => MaskedTextBox.Mask = value; }
        public HorizontalAlignment TextAlign { get => MaskedTextBox.TextAlign; set => MaskedTextBox.TextAlign = value; }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [Category("Appearance")]
        public override string Text
        {
            get => MaskedTextBox.Text;
            set => MaskedTextBox.Text = value;
        }
        public override Font Font { get => MaskedTextBox.Font; set => MaskedTextBox.Font = value; }

        private string oldText;
        public override object Value
        {
            get
            {
                return Text;
            }
            set
            {
                oldText = Text;
                Text = value?.ToString();
            }
        }


        public override void SetStatus(EnumStatus value)
        {
            mStatus = value;
            Enabled = true;
            if (IsCTLMOwned)
                ReadOnly = !((Add && GetStatus() == EnumStatus.ADDNEW) || (Upp && GetStatus() == EnumStatus.EDIT && !PK) || (Del && GetStatus() == EnumStatus.DELETE) || (Search && GetStatus() == EnumStatus.SEARCH)) || Protected;
            MaskedTextBox.BackColor = ReadOnly ? SystemColors.ButtonFace : Color.White;
            MaskedTextBox.ForeColor = ReadOnly ? SystemColors.InactiveCaptionText : SystemColors.ControlText;
        }

        public override Control Control { get => MaskedTextBox; }

        public EspackMaskedTextBox()
            : base()
        {
            InitializeComponent();
            MaskedTextBox.Validated += EspackMaskedTextBox_Validated;
            oldText = "";
        }

        private void EspackMaskedTextBox_Validated(object sender, EventArgs e)
        {
            if (oldText != Text)
                OnValueChanged(new ValueChangedEventArgs(oldText, Text));
            oldText = Text;
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
