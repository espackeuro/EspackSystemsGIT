using System.Linq;
using System.Windows.Forms;

namespace EspackDataGridView
{
    public class DataGridViewExtended : DataGridView
    {
        public bool EndEditing { get; set; } = false;

        public DataGridViewCell NextEditableCell()
        {
            var fromCell = CurrentCell;
            var candidateCell = Rows[fromCell.RowIndex].Cells.OfType<DataGridViewCell>().Where(c => !c.ReadOnly && c.ColumnIndex > fromCell.ColumnIndex).OrderBy(c => c.ColumnIndex).FirstOrDefault();
            //var Cell = VisibleColumns.Where(c => !c.ReadOnly && c.Index > fromCell.ColumnIndex).OrderBy(c => c.Index).FirstOrDefault()?.Cells[fromCell.RowIndex];
            return candidateCell ?? fromCell;
        }
        public bool EndEditControlled()
        {
            if (EndEditing)
                return false;
            EndEditing = true;
            var _result = base.EndEdit();
            EndEditing = false;
            return _result;
        }
    }
}
