using EspackControls;
using System;
using System.Windows.Forms;

namespace VSGrid
{
    public interface IFilterControl: IDataGridViewEditingControl 
    {
        //int? Column { get; set; }
        //int Row { get; set; }
        EspackControl Control { get; }
        //string DataSource { get; set; }
        //DataGridViewCell ParentCell { get; }
        CtlVSGrid ParentDataGrid { get; set; }
        string SqlSource { get; set; }
        //void SendKeyToControl(Keys keyData);
        object Value { get; set; }
    }

    public class FilterCell : DataGridViewTextBoxCell
    {
        public string SqlSource { get; set; }
        public FilterCellTypes Type { get; set; }
        private IFilterControl editControl;

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
            IFilterControl ctl = null;
            switch (Type)
            {
                case FilterCellTypes.CHECKEDCOMBO:
                    editControl = DataGridView.EditingControl as FilterCellCheckedComboBox;
                    break;
                case FilterCellTypes.COMBO:
                    editControl = DataGridView.EditingControl as FilterCellComboBox;
                    break;
                case FilterCellTypes.TEXT:
                case FilterCellTypes.WILDCARDTEXT:
                    editControl = DataGridView.EditingControl as FilterCellTextBox;
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
                    case FilterCellTypes.CHECKEDCOMBO:
                        return typeof(FilterCellCheckedComboBox);
                    case FilterCellTypes.COMBO:
                        return typeof(FilterCellComboBox);
                    case FilterCellTypes.TEXT:
                    case FilterCellTypes.WILDCARDTEXT:
                        return typeof(FilterCellTextBox);
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