using AccesoDatosNet;
using CommonTools;
using EspackControls;
using EspackFormControlsNS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EspackDataGridView
{
    public class EspackDataGridViewColumn : DataGridViewColumn, EspackControl
    {
        public bool Add { get; set; }
        public bool Upp { get; set; }
        public bool Del { get; set; }
        public bool PK { get; set; }
        public string SPAddParamName { get;set;}
        public string SPUppParamName { get; set; }
        public string SPDelParamName { get; set; }
        public cAccesoDatosNet Conn { get; set; }
        private EnumStatus status;

        public event EventHandler TextChanged;

        public EnumStatus GetStatus()
        {
            return status;
        }
        private bool oldSortable;
        public void SetStatus(EnumStatus value)
        {
            if (value == EnumStatus.ADDNEW || value == EnumStatus.EDIT)
            {
                Sortable = false;
                SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            else
            {
                Sortable = oldSortable;
                SortMode = Sortable ? DataGridViewColumnSortMode.Automatic : DataGridViewColumnSortMode.NotSortable;
            }
            status = value;
        }

        private bool locked;
        public bool Locked
        {
            get
            {
                return locked;
            }
            set
            {
                locked = value;
                ReadOnly = value;
                Cells.ForEach(c => c.ReadOnly = value);
            }

        }
        public override bool ReadOnly
        {
            get => base.ReadOnly;
            set
            {
                base.ReadOnly = value;
                Cells.ForEach(c => c.ReadOnly = value);
            }
        }
        public EspackFormControlCommon LinkedControl { get; set; }
        public Type DBFieldType { get; set; }
        public string DBField { get; set; }
        public bool Sortable { get; set; }
        public AutoCompleteMode AutoCompleteMode { get; set; }
        public AutoCompleteSource AutoCompleteSource { get; set; }
        public DataGridView Parent { get; set; }
        public string AutoCompleteQuery { get; set; }
        public string SqlSource { get; set; }
        public EspackCellTypes Type { get; set; }
        public bool Print { get; set; }
        public AggregateOperations Aggregate { get; set; } = AggregateOperations.NONE;

        public List<EspackDataGridViewCell> Cells { 
            get
            {

                return DataGridView != null ? DataGridView.Rows.OfType<DataGridViewRow>().Select(x => (EspackDataGridViewCell)x.Cells[Index]).ToList(): new List<EspackDataGridViewCell>() ;
            }
        }

        public List<string> DistinctValues
        {
            get
            {
                return Cells.Select(v => v.Value.ToString()).Distinct().OrderBy(e => e).ToList();
            }
        }
        #region unused interface items
        public EspackControlTypeEnum EspackControlType { get; set; }
        public EspackControl ExtraDataLink { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public int Order { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Search { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object DefaultValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool Protected { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Text { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public void UpdateEspackControl()
        {
            throw new NotImplementedException();
        }

        public void ClearEspackControl()
        {
            throw new NotImplementedException();
        }
        #endregion
        public object Value
        {
            get
            {
                if (DataGridView != null)
                {
                    DataGridView lDG = DataGridView;
                    int lColNumber = Index;
                    if (lDG.CurrentCell != null)
                    {
                        int lRowNumber = lDG.CurrentCell.RowIndex;
                        if (lDG[lColNumber, lRowNumber] != null)
                            return lDG[lColNumber, lRowNumber].Value;
                    }
                }
                return "";
            }
            set
            {
                if (DataGridView != null)
                {
                    DataGridView lDG = DataGridView;
                    int lColNumber = Index;
                    int lRowNumber = lDG.CurrentCell.RowIndex;
                    if (lDG[lColNumber, lRowNumber] != null)
                    {
                        //int lRowNumber = lDG.CurrentCell.RowIndex;
                        lDG[lColNumber, lRowNumber].Value = value;
                    }

                }
            }
        }
        public EspackDataGridViewColumn(string name="", bool pK = false, string sPAddParamName="", string sPUppParamName="", string sPDelParamName="", bool locked=false, 
            EspackFormControlCommon linkedControl=null, Type dBFieldType=null, string dBField="", bool sortable=false, AutoCompleteMode autoCompleteMode= AutoCompleteMode.None, AutoCompleteSource autoCompleteSource= AutoCompleteSource.None, 
            string autoCompleteQuery = "", EspackCellTypes type= EspackCellTypes.TEXT, int width = 0, bool visible = true, string query="", cAccesoDatosNet conn=null, DataGridViewAutoSizeColumnMode autoSizeMode = DataGridViewAutoSizeColumnMode.AllCells)
            :base(new EspackDataGridViewCell(type, autoCompleteMode, autoCompleteSource, autoCompleteQuery, conn, locked))
        {
            Name = name;
            HeaderText = name;
            PK = pK;
            SPAddParamName = sPAddParamName;
            SPUppParamName = sPUppParamName;
            SPDelParamName = sPDelParamName;
            Add= SPAddParamName != "";
            Upp = sPUppParamName != "";
            Del = sPDelParamName != "";
            Locked = locked;
            ReadOnly = locked;
            LinkedControl = linkedControl;
            DBFieldType = dBFieldType;
            DBField = dBField == "" ? name : dBField;
            oldSortable = sortable;
            Sortable = sortable;
            AutoCompleteMode = autoCompleteMode;
            AutoCompleteSource = autoCompleteSource;
            AutoCompleteQuery = autoCompleteQuery;
            Width = width;
            if (width != 0)
                MinimumWidth = width;
            //AutoCompleteCustomSource = autoCompleteCustomSource;
            Parent = DataGridView;
            Type = type;
            AutoSizeMode = autoSizeMode;
            DataPropertyName = Name; //DBField;
            Visible = visible;
            SqlSource = query;
            Resizable = DataGridViewTriState.True;
            //Sortable = true;
            SortMode = Sortable ? DataGridViewColumnSortMode.Automatic : DataGridViewColumnSortMode.NotSortable;
            Conn = conn;
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(EspackDataGridViewCell)))
                {
                    throw new InvalidCastException("Must be a CtlVSGridCell");
                }
                ((EspackDataGridViewCell)value).ReadOnly = Locked;
                base.CellTemplate = value;
            }
        }

        public int MaxWidth
        {
            get
            {
                var _grid = Cells.OfType<EspackDataGridViewCell>().Max(x => x.Value.ToString().Length);
                return _grid > HeaderCell.Value.ToString().Length ? _grid : HeaderCell.Value.ToString().Length;
            }
        }

        public bool IsNumeric
        {
            get
            {
                try
                {
                    Cells.ForEach(c => Single.Parse(c.Value.ToString()));
                }
                catch (FormatException)
                {
                    return false;
                }
                return true;
            }
        }

        public float AggregateValue
        {
            get
            {
                switch (Aggregate)
                {
                    case AggregateOperations.COUNT:
                        return Cells.Count;
                    case AggregateOperations.AVERAGE:
                        if (IsNumeric)
                        {
                            return Cells.Select(x => Single.Parse(x.Value.ToString())).Average();
                        }
                        else
                            throw new InvalidDataException("Not numeric data.");
                    case AggregateOperations.MAX:
                        if (IsNumeric)
                        {
                            return Cells.Select(x => Single.Parse(x.Value.ToString())).Max();
                        }
                        else
                            throw new InvalidDataException("Not numeric data.");
                    case AggregateOperations.MIN:
                        if (IsNumeric)
                        {
                            return Cells.Select(x => Single.Parse(x.Value.ToString())).Min();
                        }
                        else
                            throw new InvalidDataException("Not numeric data.");
                    case AggregateOperations.SUM:
                        if (IsNumeric)
                        {
                            return Cells.Select(x => Single.Parse(x.Value.ToString())).Sum();
                        }
                        else
                            throw new InvalidDataException("Not numeric data.");
                    default:
                        return 0;
                }
            }
        }

        //public void Filter(string text, bool wildcards)
        //{
            
        //    foreach (DataGridViewRow row in DataGridView.Rows)
        //        row.Visible = wildcards ? row.Cells[Index].Value.ToString().Contains(text) : row.Cells[Index].Value.ToString() == text;

        //    //Cells.ForEach(c =>
        //    //{
        //    //    Task.Run(() => DataGridView.Rows[c.RowIndex].Visible = wildcards ? c.Value.ToString().Contains(text) : c.Value.ToString() == text);
        //    //});
        //}
    }
}
