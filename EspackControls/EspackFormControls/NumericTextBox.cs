using System;
using System.Windows.Forms;
using System.Globalization;

namespace EspackFormControls
{
    public class NumericTextBox : EspackTextBox
    {

        bool allowSpace = false;
        public NumericTextBox()
            : base()
        {
            this.TextAlign = HorizontalAlignment.Right;
        }

        //Restricts the entry of characters to digits (including hex), the negative sign,
        //the decimal point, and editing keystrokes (backspace).
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

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
                else if (this.allowSpace && e.KeyChar == ' ')
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

        public int Precision { get; set; }
        public int Length { get; set; }
        public bool Mask { get; set; }
        public bool ThousandsGroup { set; get; }
        public bool AllowSpace
        {
            set
            {
                this.allowSpace = value;
            }

            get
            {
                return this.allowSpace;
            }
        }

        //protected override void OnTextChanged(System.EventArgs e)
        //{
        //    if (ThousandsGroup) {
        //        Text = decimal.Parse(Text).ToString("N");
        //    } 
        //}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
        public void ClearControl()
        {
            Value=0;
        }

    }

}
