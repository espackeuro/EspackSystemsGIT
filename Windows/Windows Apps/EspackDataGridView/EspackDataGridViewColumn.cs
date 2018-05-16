using CommonTools;
using EspackControls;
using EspackFormControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EspackDataGrid
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

        private EnumStatus status;

        public event EventHandler TextChanged;

        public EnumStatus GetStatus()
        {
            return status;
        }

        public void SetStatus(EnumStatus value)
        {
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
        public EspackFormControl LinkedControl { get; set; }
        public Type DBFieldType { get; set; }
        public string DBField { get; set; }
        public bool Sortable { get; set; }
        public AutoCompleteMode AutoCompleteMode { get; set; }
        public AutoCompleteSource AutoCompleteSource { get; set; }
        public EspackDataGridView Parent { get; set; }
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
            EspackFormControl linkedControl=null, Type dBFieldType=null, string dBField="", bool sortable=false, AutoCompleteMode autoCompleteMode= AutoCompleteMode.None, AutoCompleteSource autoCompleteSource= AutoCompleteSource.None, 
            string autoCompleteQuery = "", EspackCellTypes type= EspackCellTypes.TEXT, int width=0, bool visible = true, string query="")
            :base(new EspackDataGridViewCell(type, autoCompleteMode, autoCompleteSource, autoCompleteQuery, locked))
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
            Sortable = sortable;
            AutoCompleteMode = autoCompleteMode;
            AutoCompleteSource = autoCompleteSource;
            AutoCompleteQuery = autoCompleteQuery;
            //AutoCompleteCustomSource = autoCompleteCustomSource;
            Parent = (EspackDataGridView)DataGridView;
            Type = type;
            AutoSizeMode = width == 0 ? DataGridViewAutoSizeColumnMode.AllCells : DataGridViewAutoSizeColumnMode.None;
            DataPropertyName = DBField;
            Visible = visible;
            SqlSource = query;
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

    }
}
