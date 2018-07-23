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
        //public TextBox TextBox { get; set; }

        //public override Label CaptionLabel { get; set; }

        public override bool ReadOnly { get => TextBox.ReadOnly; set => TextBox.ReadOnly = value; }
        public bool Multiline { get; set; }
        public AutoCompleteStringCollection AutoCompleteCustomSource { get => TextBox.AutoCompleteCustomSource; set => TextBox.AutoCompleteCustomSource = value; }
        public AutoCompleteSource AutoCompleteSource { get => TextBox.AutoCompleteSource; set => TextBox.AutoCompleteSource = value; }
        public AutoCompleteMode AutoCompleteMode
        {
            get => TextBox.AutoCompleteMode;
            set
            {
                if (value != AutoCompleteMode.None)
                    TextBox.Multiline = false;
                TextBox.AutoCompleteMode = value;
            }
        }
        public HorizontalAlignment TextAlign { get => TextBox.TextAlign; set => TextBox.TextAlign = value; }
        public CharacterCasing CharacterCasing { get => TextBox.CharacterCasing; set => TextBox.CharacterCasing = value; }
        // public bool UseSystemPasswordChar { get => TextBox.UseSystemPasswordChar; set => TextBox.UseSystemPasswordChar = value; }
        // public char PasswordChar { get => TextBox.PasswordChar; set => TextBox.PasswordChar = value; }
        private bool _isPassword = false;
        public TextBox TextBox;
        

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        [Category("Appearance")]
        public bool IsPassword
        {
            get
            {
                return _isPassword;
            }
            set
            {
                _isPassword = value;
                if (value)
                {
                    TextBox.PasswordChar = '•';
                }
                else
                {
                    TextBox.PasswordChar = '\0';
                }
            }
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
            Text = "";
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
            // CaptionLabel
            // 
            this.CaptionLabel.Size = new System.Drawing.Size(0, 13);
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(0, 0);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(100, 20);
            this.TextBox.TabIndex = 2;
            this.TextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox.Multiline = true;

            // 
            // EspackTextBox
            // 
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.CaptionLabel);
            this.Name = "EspackTextBox";
            this.Size = new System.Drawing.Size(154, 25);
            this.Controls.SetChildIndex(this.CaptionLabel, 0);
            this.Controls.SetChildIndex(this.TextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}
