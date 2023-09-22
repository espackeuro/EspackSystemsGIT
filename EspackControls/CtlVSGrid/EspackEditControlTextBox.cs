﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
//using Microsoft.Data.Schema.ScriptDom;
//using Microsoft.Data.Schema.ScriptDom.Sql;
using AccesoDatosNet;
using CommonTools;
using EspackControls;
using EspackFormControls;

namespace VSGrid
{
    public enum EspackCellTypes { COMBO, CHECKEDCOMBO, TEXT, WILDCARDTEXT }

    public class EspackEditControlTextBox : EspackTextBox, IEspackEditControl
    {
        protected int rowIndex;
        public EspackControl Control { get => this; }
        //private FilterCellTypes _type;
        private string _sqlSource;
        //public object Value { get => Control.Value; set => Control.Value = value; }
        public EspackEditControlTextBox()
        {
            Enabled = true;
            ReadOnly = false;
            Multiline = true;
            BorderStyle = BorderStyle.None;
            //this.GotFocus += Control_GotFocus;
            //this.LostFocus += Control_LostFocus;
        }


        //public string DataSource { get; set; }

        public CtlVSGrid ParentDataGrid { get; set; }

        private void Control_LostFocus(object sender, System.EventArgs e)
        {
            ParentDataGrid.IsFilterFocused = false;
        }

        private void Control_GotFocus(object sender, System.EventArgs e)
        {
            ParentDataGrid.IsFilterFocused = true;
            ParentDataGrid.ClearSelection();
            
        }
        public void SendKeyToControl(Keys keyData)
        {
            var e = new KeyEventArgs(keyData);
            OnKeyDown(e);
        } 


        public string SqlSource
        {
            get => _sqlSource;
            set
            {
                _sqlSource = value;
                AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection _values = new AutoCompleteStringCollection();
                using (var _rs = new StaticRS(_sqlSource, ParentDataGrid.Conn))
                {
                    _rs.Open();
                    _rs.Rows.ForEach(r => _values.Add(r[0].ToString()));
                }
                AutoCompleteCustomSource = _values;

            }

        }
        #region IDataGridViewEditingControl
        // IDataGridViewEditingControl members

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView { get => ParentDataGrid; set => ParentDataGrid=(CtlVSGrid)value; }

        //
        public object EditingControlFormattedValue
        {
            get
            {
                return Text;
            }
            set
            {
                Text = value.ToString();
            }
        }


        // Implements the IDataGridViewEditingControl.EditingControlRowIndex 
        // property.
        public int EditingControlRowIndex
        {
            get
            {
                return rowIndex;
            }
            set
            {
                rowIndex = value;
            }
        }

        public bool EditingControlValueChanged { get; set; }

        // Implements the IDataGridViewEditingControl
        // .EditingPanelCursor property.
        public Cursor EditingPanelCursor
        {
            get
            {
                return base.Cursor;
            }
        }

        protected override void OnTextChanged(EventArgs eventargs)
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            EditingControlValueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
            base.OnTextChanged(eventargs);
        }

        // Implements the IDataGridViewEditingControl
        // .RepositionEditingControlOnValueChange property.
        public bool RepositionEditingControlOnValueChange
        {
            get
            {
                return false;
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.ApplyCellStyleToEditingControl method.
        public void ApplyCellStyleToEditingControl(
            DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.ForeColor = dataGridViewCellStyle.ForeColor;
            this.BackColor = dataGridViewCellStyle.BackColor;
        }

        // Implements the IDataGridViewEditingControl.EditingControlWantsInputKey 
        // method.
        public bool EditingControlWantsInputKey(
            Keys key, bool dataGridViewWantsInputKey)
        {
            // Let the DateTimePicker handle the keys listed.
            switch (key & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                //case Keys.Enter:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        // Implements the 
        // IDataGridViewEditingControl.GetEditingControlFormattedValue method.
        public object GetEditingControlFormattedValue(
            DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        // Implements the IDataGridViewEditingControl.PrepareEditingControlForEdit 
        // method.
        public void PrepareEditingControlForEdit(bool selectAll)
        {
            // No preparation needs to be done.
        }
        #endregion
    }
}
