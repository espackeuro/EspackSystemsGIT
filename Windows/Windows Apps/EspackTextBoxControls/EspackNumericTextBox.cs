using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EspackFormControlsNS
{
    public class EspackNumericTextBox : EspackTextBox
    {
        [Category("Numeric Format")]
        public int Precision { get; set; }
        [Category("Numeric Format")]
        public int Length { get; set; }
        [Category("Numeric Format")]
        public bool Mask { get; set; }
        [Category("Numeric Format")]
        public bool ThousandsGroup { set; get; }
        [Category("Numeric Format")]
        public bool AllowSpace { set; get; }

        public EspackNumericTextBox()
    : base()
        {
            TextBox.TextAlign = HorizontalAlignment.Right;
            TextBox.KeyPress += TextBox_KeyPress;
            TextBox.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (ThousandsGroup)
                Text = double.Parse(this.Text == "." ? "0.0" : this.Text).ToString("N" + Precision.ToString());
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            string groupSeparator = numberFormatInfo.NumberGroupSeparator;
            string negativeSign = numberFormatInfo.NegativeSign;

            string keyInput = e.KeyChar.ToString();
            if (Length == 0 || Text.Length < Length + (Precision == 0 ? 0 : Precision + 1))
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    // Digits are OK
                }
                else if (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
                 keyInput.Equals(negativeSign))
                {
                    // Decimal separator is OK
                }
                else if (e.KeyChar == '\b')
                {
                    // Backspace key is OK
                }
                //    else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0)
                //    {
                //     // Let the edit control handle control and alt key combinations
                //    }
                else if (AllowSpace && e.KeyChar == ' ')
                {

                }
            }
            else
            {
                // Consume this invalid key and beep
                e.Handled = true;
                //    MessageBeep();
            }
        }
        public int IntValue
        {
            get
            {
                return Int32.Parse(this.Text);
            }
        }

        public decimal DecimalValue
        {
            get
            {
                return Decimal.Parse(this.Text);
            }
        }

        public new object Value
        {
            get
            {
                if (Text == "")
                {
                    return null;
                }
                else
                    if (Precision != 0)
                {
                    return double.Parse(this.Text == "." ? "0.0" : this.Text);
                }
                else
                {
                    return Int32.Parse(this.Text == "." ? "0.0" : this.Text);
                }

            }
            set
            {
                Text = Value == null ? "" : Value.ToString();
            }
        }
        public override void ClearEspackControl()
        {
            Value = 0;
        }

        private void InitializeComponent()
        {
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
            this.TextBox.TabIndex = 0;
            this.TextBox.Text = "";
            // 
            // EspackNumericTextBox
            // 
            this.Name = "EspackNumericTextBox";
            this.Controls.SetChildIndex(this.TextBox, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

}
