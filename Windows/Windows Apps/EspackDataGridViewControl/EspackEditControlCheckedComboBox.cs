using System.Windows.Forms;
using AccesoDatosNet;
using EspackControls;
//using Microsoft.Data.Schema.ScriptDom;
//using Microsoft.Data.Schema.ScriptDom.Sql;
using EspackFormControlsNS;

namespace EspackDataGridView
{
    public class EspackEditControlCheckedComboBox : EspackCheckedComboBox, IEspackEditControl
    {


        //private DataGridCell _parentCell;
        protected int rowIndex;
        public EspackFormControlCommon EspackControl { get => this; }
        private string _sqlSource;
        public cAccesoDatosNet Conn { get; set; }
        public EspackEditControlCheckedComboBox()
        {
            Enabled = true;
            FlatStyle = FlatStyle.Flat;
            ValueChanged += FilterCellCheckedComboBox_Changed;
            KeyDown += FilterCellComboBox_KeyDown;
            //this.GotFocus += Control_GotFocus;
            //this.LostFocus += Control_LostFocus;
        }

        private void FilterCellComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                Source(_sqlSource,Conn);
                
            }

        }


        #region IDataGridViewEditingControl
        // IDataGridViewEditingControl members

        // Implements the IDataGridViewEditingControl
        // .EditingControlDataGridView property.
        public DataGridView EditingControlDataGridView { get => ParentDataGrid; set => ParentDataGrid = (DataGridView)value; }

        //
        public object EditingControlFormattedValue { get => Value.ToString(); set => Value = value; }



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




        private void FilterCellCheckedComboBox_Changed(object sender, ValueChangedEventArgs e)
        {
            // Notify the DataGridView that the contents of the cell
            // have changed.
            EditingControlValueChanged = true;
            this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
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
            Value = Text.Replace(", ","|");
        }
        #endregion
    }
}
