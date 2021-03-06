﻿using System;
using System.Data;
using System.Windows.Forms;
using AccesoDatosNet;
using EspackControls;
//using Microsoft.Data.Schema.ScriptDom;
//using Microsoft.Data.Schema.ScriptDom.Sql;
using EspackFormControlsNS;

namespace EspackDataGridView
{
    public class EspackEditControlComboBox : EspackComboBox, IEspackEditControl
    {


        protected int rowIndex;
        public EspackFormControlCommon EspackControl { get => this; }
        //private FilterCellTypes _type;
        private string _sqlSource;
        public cAccesoDatosNet Conn { get; set; }
        public EspackEditControlComboBox()
        {
            Enabled = true;
            FlatStyle = FlatStyle.Flat;
            KeyDown += FilterCellComboBox_KeyDown;
            ComboBox.SelectedValueChanged += ComboBox_SelectedValueChanged;
            Caption = "";
            //SelectedValueChanged += FilterCellComboBox_SelectedValueChanged;
            //this.GotFocus += Control_GotFocus;
            //this.LostFocus += Control_LostFocus;
        }

        private void ComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            EditingControlValueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
        }

        private void FilterCellComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
                if (ParentDataGrid.IsCurrentCellInEditMode)
                    ParentDataGrid.EndEdit();
        }

        public DataGridView ParentDataGrid { get; set; }

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
                Source(_sqlSource, Conn);
                if (((DataTable)DataSource).Rows.Count == 1)
                    Text = ((DataTable)DataSource).Rows[0].ItemArray[0].ToString();
            }

        }
        #region IDataGridViewEditingControl
        // IDataGridViewEditingControl members

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView { get => ParentDataGrid; set => ParentDataGrid = value; }

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
                    return true;
                case Keys.Enter:
                    ParentDataGrid.EndEdit();
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
