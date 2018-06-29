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
    public class EspackTextBox : EspackFormControlCaption
    {
        //protected override Label CaptionLabel { get; set; }
        public TextBox TextBox;

        //public override Label CaptionLabel { get; set; }

        public override bool ReadOnly { get => TextBox.ReadOnly; set => TextBox.ReadOnly = value; }
        public bool Multiline { get; set; }
        public AutoCompleteStringCollection AutoCompleteCustomSource { get => TextBox.AutoCompleteCustomSource; set => TextBox.AutoCompleteCustomSource = value; }
        public AutoCompleteSource AutoCompleteSource { get => TextBox.AutoCompleteSource; set => TextBox.AutoCompleteSource = value; }
        public AutoCompleteMode AutoCompleteMode { get => TextBox.AutoCompleteMode; set => TextBox.AutoCompleteMode = value; }
        public HorizontalAlignment TextAlign { get => TextBox.TextAlign; set => TextBox.TextAlign = value; }
        public CharacterCasing CharacterCasing { get => TextBox.CharacterCasing; set => TextBox.CharacterCasing = value; }
        public bool UseSystemPasswordChar { get => TextBox.UseSystemPasswordChar; set => TextBox.UseSystemPasswordChar = value; }


        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [Category("Appearance")]
        public override string Text
        {
            get => TextBox.Text;
            set => TextBox.Text = value;
        }
        public override Font Font { get => TextBox.Font; set => TextBox.Font = value; }

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
            TextBox.BackColor = ReadOnly ? SystemColors.ButtonFace : Color.White;
            TextBox.ForeColor = ReadOnly ? SystemColors.InactiveCaptionText : SystemColors.ControlText;
        }

        public override Control Control { get => TextBox; }

        public EspackTextBox()
            :base()
        {
            InitializeComponent();
            TextBox.Validated += EspackTextBox_Validated;
            oldText = "";
        }

        private void EspackTextBox_Validated(object sender, EventArgs e)
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

        private void InitializeComponent()
        {
            this.TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //this.TextBox.Location = new System.Drawing.Point(0, 16);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            //this.TextBox.Size = new System.Drawing.Size(154, 22);
            this.Text = "";
            this.TextBox.TabIndex = 0;
            // 
            // EspackTextBox
            // 
            this.Caption = "Caption";
            this.Controls.Add(this.CaptionLabel);
            this.Controls.Add(this.TextBox);
            this.Name = "EspackTextBox";
            this.Size = new System.Drawing.Size(154, 38);
            this.Controls.SetChildIndex(this.TextBox, 0);
            this.Controls.SetChildIndex(this.CaptionLabel, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
