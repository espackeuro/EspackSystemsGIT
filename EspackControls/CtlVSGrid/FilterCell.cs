using EspackControls;
using System;
using System.Windows.Forms;

namespace VSGrid
{
    public class FilterCell : DataGridViewTextBoxCell
    {
        public string SqlSource { get; set; }
        public EspackCellTypes Type { get; set; }
        private IEspackEditControl editControl;

        public FilterCell()
        {
            Style.BackColor = Colors.CELLFILTERBACKCOLOR;
            Style.ForeColor = Colors.CELLFILTERFORECOLOR;
        }

        public override object Clone()
        {
            var clone =(FilterCell)base.Clone();
            clone.SqlSource = SqlSource;
            clone.Type = Type;
            return clone;
        }
        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            //IEspackEditControl ctl = null;
            switch (Type)
            {
                case EspackCellTypes.CHECKEDCOMBO:
                    editControl = DataGridView.EditingControl as EspackEditControlCheckedComboBox;
                    break;
                case EspackCellTypes.COMBO:
                    editControl = DataGridView.EditingControl as EspackEditControlComboBox;
                    break;
                case EspackCellTypes.TEXT:
                case EspackCellTypes.WILDCARDTEXT:
                    editControl = DataGridView.EditingControl as EspackEditControlTextBox;
                    break;
            }
            editControl.SqlSource = SqlSource;

            // Use the default row value when Value property is null.
            if (this.Value == null)
            {
                editControl.Value = "";
            }
            else
            {
                editControl.Value = this.Value;
            }
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing control that CalendarCell uses.
                switch (Type)
                {
                    case EspackCellTypes.CHECKEDCOMBO:
                        return typeof(EspackEditControlCheckedComboBox);
                    case EspackCellTypes.COMBO:
                        return typeof(EspackEditControlComboBox);
                    case EspackCellTypes.TEXT:
                    case EspackCellTypes.WILDCARDTEXT:
                        return typeof(EspackEditControlTextBox);
                    default:
                        return null;
                }
            }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(string);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return null;
            }
        }
    }
}