using AccesoDatosNet;
using EspackControls;
using EspackFormControlsNS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EspackDataGridView
{


    public interface IEspackEditControl : IDataGridViewEditingControl
    {
        EspackFormControlCommon EspackControl { get; }
        DataGridView ParentDataGrid { get; set; }
        string SqlSource { get; set; }
        object Value { get; set; }
        AutoCompleteMode AutoCompleteMode { get; set; }
        AutoCompleteSource AutoCompleteSource { get; set; }
        AutoCompleteStringCollection AutoCompleteCustomSource { get; set; }
        cAccesoDatosNet Conn { get; set; }
    }

    public class CellValueChangedEventArgs : EventArgs
    {
        public int RowIndex { get; set; }
        public int ColIndex { get; set; }
        public object OldValue { get; set; }
        public object NewValue { get; set; }
        
        public CellValueChangedEventArgs(EspackDataGridViewCell cell, object oldValue, object newValue) {
            RowIndex = cell.RowIndex;
            ColIndex = cell.ColumnIndex;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
    
    public class EspackDataGridViewCell : DataGridViewTextBoxCell
    {
        public string SqlSource { get; set; }
        public EspackCellTypes Type { get; set; }
        private IEspackEditControl editControl;
        private AutoCompleteMode? _autoCompleteMode = null;
        private AutoCompleteSource? _autoCompleteSource = null;
        private string _autoCompleteQuery = null;
        public bool IsFilterCell { get; set; }
        public cAccesoDatosNet Conn { get; set; }
        public event EventHandler<CellValueChangedEventArgs> CellValueChanged;

        public string AutoCompleteQuery
        {
            get
            {
                _autoCompleteQuery = _autoCompleteQuery ?? Column.AutoCompleteQuery;
                return _autoCompleteQuery;
            }
            set => _autoCompleteQuery = value;
        }
        public DataGridView Parent { get => DataGridView; }

        public AutoCompleteMode AutoCompleteMode
        {
            get
            {
                _autoCompleteMode = _autoCompleteMode ?? Column.AutoCompleteMode;
                return (AutoCompleteMode)_autoCompleteMode;
            }
            set => _autoCompleteMode = value;
        }
        public AutoCompleteSource AutoCompleteSource
        {
            get
            {
                _autoCompleteSource = _autoCompleteSource ?? Column.AutoCompleteSource;
                return (AutoCompleteSource)_autoCompleteSource;
            }
            set => _autoCompleteSource = value;
        }

        public EspackDataGridViewColumn Column
        {
            get
            {
                return DataGridView == null ? null : (EspackDataGridViewColumn)DataGridView.Columns[ColumnIndex];
            }
        }

        //public AutoCompleteStringCollection AutoCompleteCustomSource { get => editControl.AutoCompleteCustomSource; set => editControl.AutoCompleteCustomSource = value; }

        public override bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }
            set
            {
                if (Column != null)
                {
                    base.ReadOnly = value;
                    if (ReadOnly)
                    {
                        Style.BackColor = Colors.CELLLOCKEDBACKCOLOR;
                        Style.ForeColor = Colors.CELLLOCKEDFORECOLOR;
                    }
                    else
                    {
                        Style.BackColor = Colors.CELLBACKCOLOR;
                        Style.ForeColor = Colors.CELLFORECOLOR;
                    }
                }
            }
        }

        public EspackDataGridViewCell()
        {
            if (Column!=null)
            {
                ReadOnly = Column.Locked;
            }
        }
        public EspackDataGridViewCell(EspackCellTypes type, AutoCompleteMode autoCompleteMode, AutoCompleteSource autoCompleteSource, string autoCompleteQuery, cAccesoDatosNet conn, bool locked=false)
        {
            Type = type;
            AutoCompleteMode = autoCompleteMode;
            AutoCompleteSource = autoCompleteSource;
            AutoCompleteQuery = autoCompleteQuery;
            if (Column != null)
            {
                ReadOnly = locked;
            };
            Style.BackColor = Colors.CELLLOCKEDBACKCOLOR;
            Style.ForeColor = Colors.CELLLOCKEDFORECOLOR;
            Conn = conn;
            //Parent = (EspackDataGridView)DataGridView;
            //Style.BackColor = Colors.CELLFILTERBACKCOLOR;
            //Style.ForeColor = Colors.CELLFILTERFORECOLOR;
        }
        private AutoCompleteStringCollection _localStringCollection;
        public EspackDataGridViewCell(EspackCellTypes type, AutoCompleteMode autoCompleteMode, AutoCompleteSource autoCompleteSource, string[] autoCompleteCustomSource, bool locked = false)
        {
            Type = type;
            AutoCompleteMode = autoCompleteMode;
            AutoCompleteSource = autoCompleteSource;
            _localStringCollection = new AutoCompleteStringCollection();
            _localStringCollection.AddRange(autoCompleteCustomSource);
            if (Column != null)
            {
                ReadOnly = locked;
            };
            Style.BackColor = Colors.CELLLOCKEDBACKCOLOR;
            Style.ForeColor = Colors.CELLLOCKEDFORECOLOR;
            //Parent = (EspackDataGridView)DataGridView;
            //Style.BackColor = Colors.CELLFILTERBACKCOLOR;
            //Style.ForeColor = Colors.CELLFILTERFORECOLOR;
        }
        public AutoCompleteStringCollection AutoCompleteCustomSource { get => GetAutoCompleteCustomSource(); }

        public AutoCompleteStringCollection GetAutoCompleteCustomSource()
        {

            if (AutoCompleteQuery != "" && Parent != null)
            {
                var autoCompleteCustomSource = new AutoCompleteStringCollection();
                using (DynamicRS rs = new DynamicRS(AutoCompleteQuery, Conn))
                {
                    rs.Open();
                    rs.ToList().ForEach(r => autoCompleteCustomSource.Add(r[0].ToString()));
                }
                return autoCompleteCustomSource;
            } else
            {
                if (_localStringCollection != null)
                    return _localStringCollection;
            }
            return null;
        }

        public override object Clone()
        {
            var clone = (EspackDataGridViewCell)base.Clone();
            clone.SqlSource = SqlSource;
            clone.Type = Type;
            clone.Conn = Conn;
            //clone.AutoCompleteQuery = AutoCompleteQuery;
            //clone.AutoCompleteSource = AutoCompleteSource;
            //clone.AutoCompleteMode = AutoCompleteMode;
            //clone.ReadOnly = ReadOnly;
            //clone.AutoCompleteCustomSource = AutoCompleteCustomSource;
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
            editControl.Conn = Conn;
            editControl.EspackControl.ValueChanged -= Control_ValueChanged;
            editControl.SqlSource = Column.SqlSource;
            editControl.AutoCompleteMode = AutoCompleteMode;
            editControl.AutoCompleteSource = AutoCompleteSource;
            editControl.AutoCompleteCustomSource = AutoCompleteCustomSource;
            editControl.EspackControl.Font = this.Parent.Font;
            oldValue = Value;
            editControl.Value = Value;
            editControl.EspackControl.ValueChanged += Control_ValueChanged;
            // Use the default row value when Value property is null.
            //if (this.Value == null)
            //{
            //    editControl.Value = "";
            //}
            //else
            //{
            //    editControl.Value = this.Value;
            //}
        }

        private object oldValue = null;
        private void Control_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (DataGridView?.CurrentCell == this)
                if (e.NewValue != null && e.NewValue?.ToString() != oldValue?.ToString())
                {
                    var eventArgs = new CellValueChangedEventArgs(this, oldValue, e.NewValue);
                    //if (DataGridView.Focus())
                    //    DataGridView.EndEdit();
                    Value = e.NewValue;
                    OnCellValueChanged(eventArgs);
                    //editControl.Control.ValueChanged -= Control_ValueChanged;
                    oldValue = e.NewValue;
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

        public void OnCellValueChanged(CellValueChangedEventArgs e)
        {
            CellValueChanged?.Invoke(this, e);
        }
    }
}
