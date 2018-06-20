using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EspackFormControls;
using EspackControls;
using AccesoDatosNet;
using CommonTools;
using System;
using DiverseControls;
using System.Collections.ObjectModel;

namespace EspackDataGrid
{
    public partial class EspackDataGridViewControl : EspackFormControlCommon
    {
        #region Properties
        //public bool IsCTLMOwned { get; set; } = false;
        //public EspackControl ExtraDataLink { get; set; } = null;
        //public EspackControlTypeEnum EspackControlType { get; set; }
        //private string mDBTable;
        private DA mDA = new DA();
        //private EnumStatus mStatus;
        //private string mWhereString;
        private bool mPaginate;
        private int mPageSize;
        private ToolStrip mNavigationBar;
        private EnumStatus mPreviousParentStatus;
        //public bool Protected { get; set; }
        //Properties
        public bool AllowInsert { get; set; }
        public bool AllowUpdate { get; set; }
        public bool AllowDelete { get; set; }
        public int NumPages { get; set; }
        public EspackControl EspackControlParent { get; set; }



        //public DataGridView DataGridView { get; set; } = new DataGridView();
        public DataGridViewCell CurrentCell
        {
            get => FGFocused ? FilterDataGrid.CurrentCell : DataGridView.CurrentCell; 
            set
            {
                if (FGFocused)
                {
                    FilterDataGrid.CurrentCell = value;
                    return;
                }
                DataGridView.CurrentCell = value;
            }
        }
        public DataGridViewRowCollection Rows { get => FGFocused ? FilterDataGrid?.Rows : DataGridView?.Rows; }
        public DataGridViewColumnCollection Columns { get => DataGridView.Columns; }
        public DataGridViewRow CurrentRow { get => DataGridView.CurrentRow; }
        public EspackDataGridViewCell this[int col, int row]
        {
            get => (EspackDataGridViewCell)DataGridView[col, row];
        }
        public DataGridViewRow RowTemplate { get => DataGridView.RowTemplate; set => DataGridView.RowTemplate = value; }
        public int RowCount { get => DataGridView.RowCount; set => DataGridView.RowCount = value; }
        public object DataSource { get => DataGridView.DataSource; set => DataGridView.DataSource = value; }
        public bool RowHeadersVisible
        {
            get => DataGridView.RowHeadersVisible;
            set
            {
                DataGridView.RowHeadersVisible = value;
                if (FilterDataGrid != null)
                    FilterDataGrid.RowHeadersVisible = value;
            }
        }
        public bool ColumnHeadersVisible { get => DataGridView.ColumnHeadersVisible; set => DataGridView.ColumnHeadersVisible = value; }
        public Color GridColor { get => DataGridView.GridColor; set => DataGridView.GridColor = value; }
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
        {
            get => DataGridView.AutoSizeColumnsMode;
            set
            {
                DataGridView.AutoSizeColumnsMode = value;
                if (FilterDataGrid != null)
                    FilterDataGrid.AutoSizeColumnsMode = value;
            }
        }
        public bool AllowUserToResizeColumns
        {
            get => DataGridView.AllowUserToResizeColumns;
            set
            {
                DataGridView.AllowUserToResizeColumns = value;
                if (FilterDataGrid != null)
                    FilterDataGrid.AllowUserToResizeColumns = value;
            }
        }
        public ScrollBar VerticalScrollBar { get => DataGridView.Controls.OfType<VScrollBar>().FirstOrDefault(); }
        public ScrollBar HorizontalScrollBar { get => DataGridView.Controls.OfType<HScrollBar>().FirstOrDefault(); }
        public bool AllowUserToAddRows { get => DataGridView.AllowUserToAddRows; set => DataGridView.AllowUserToAddRows = value; }
        public int HorizontalScrollingOffset { get => DataGridView.HorizontalScrollingOffset; set => DataGridView.HorizontalScrollingOffset = value; }
        public DataGridViewColumnHeadersHeightSizeMode ColumnHeadersHeightSizeMode { get => DataGridView.ColumnHeadersHeightSizeMode; set => DataGridView.ColumnHeadersHeightSizeMode = value; }

        public void Sort(DataGridViewColumn dataGridViewColumn, ListSortDirection direction)
        {
            DataGridView.Sort(dataGridViewColumn, direction);
        }
        public DataGridViewColumn SortedColumn { get => DataGridView.SortedColumn; }
        public SortOrder SortOrder { get => DataGridView.SortOrder; }
        public bool IsCurrentCellInEditMode
        {
            get
            {
                if (DGFocused)
                    return DataGridView.IsCurrentCellInEditMode;
                if (FGFocused)
                    return FilterDataGrid.IsCurrentCellInEditMode;
                return false;
            }
        }
        public bool DGFocused { get; set; }
        public bool FGFocused { get; set; }

        public IEnumerable<EspackDataGridViewCell> DataCellCollection
        {
            get
            {
                var _result = DataGridView?.Rows.OfType<DataGridViewRow>().SelectMany(r => r.Cells.OfType<EspackDataGridViewCell>().Select(c => c));
                return _result;
            }
        }
        public IEnumerable<EspackDataGridViewCell> FilterCellCollection
        {
            get
            {
                var _result = FilterDataGrid?.Rows.OfType<DataGridViewRow>().SelectMany(r => r.Cells.OfType<EspackDataGridViewCell>().Select(c => c));
                return _result;
            }
        }


        //end properties
        public bool BeginEdit(bool selectAll)
        {
            if (FGFocused)
                return FilterDataGrid.BeginEdit(selectAll);
            else
                return DataGridView.BeginEdit(selectAll);
        }
        public bool EndEdit()
        {
            if (FGFocused)
                return FilterDataGrid.EndEdit();
            else
                return DataGridView.EndEdit();
        }
        public bool CancelEdit()
        {
            if (FGFocused)
                return FilterDataGrid.CancelEdit();
            else
                return DataGridView.CancelEdit();
        }
        //public Dictionary<string,Control> VSPrimaryKey { get; set; }

        //public string DBField { get; set; }
        //public bool Add { get; set; }
        //public bool Upp { get; set; }
        //public bool Del { get; set; }
        //public int Order { get; set; }
        //public bool PK { get; set; }
        //public bool Search { get; set; }
        //public object DefaultValue { get; set; }
        //public Type DBFieldType { get; set; }

        //private object _value;
        public override object Value
        {
            get => CurrentCell?.Value;
            set
            {
                if (Value != value)
                {
                    var oldValue = Value;
                    Value = value;
                    OnValueChanged(new ValueChangedEventArgs(oldValue, value));
                }
            }
        }


        //filter props
        private bool mFilterRowEnabled;
        public bool IsFilterFocused { get; set; }
        public DataGridViewRow FilterRow { get; set; }
        public bool FilterRowEnabled
        {
            get => mFilterRowEnabled;
            set
            {
                mFilterRowEnabled = value;
                if (value == true)
                {
                    //FilterCells = new List<EspackDataGridViewCell>();
                    AddFilterRow();
                }
                else
                {
                    if (Rows?.Count != 0)
                        Rows?.RemoveAt(0);
                    FilterRow = null;
                    //FilterCells = null;
                }
            }
        }
        public DataGridView FilterDataGrid { get; set; }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<EspackDataGridViewCell> FilterCells { get => FilterDataGrid?.Rows[0].Cells.OfType<EspackDataGridViewCell>().ToList(); }
        //EspackFormControl properties
        //public EspackLabel CaptionLabel { get; set; }
        public override string Caption
        {
            get
            {
                if (CaptionLabel != null)
                {
                    return CaptionLabel.Caption;
                }
                else return null;
            }
            set
            {
                if (CaptionLabel.Parent == null && Parent != null)
                {
                    Parent.Controls.Add(CaptionLabel);
                }
                CaptionLabel.Caption = value;
                //CaptionLabel.Location = new Point(Location.X - CaptionLabel.PreferredWidth - 6, Location.Y);
                CaptionLabel.Location = new Point(base.Location.X, base.Location.Y - CaptionLabel.PreferredHeight - 5);
            }
        }
        public override bool ReadOnly { get => DataGridView.ReadOnly; set => DataGridView.ReadOnly = value; }
        //public DA ParentDA { get; set; }
        //public cAccesoDatosNet ParentConn { get; set; }
        //public DynamicRS DependingRS { get; set; }

        public object this[string ColumnName]
        {
            get
            {
                int i = Columns.Cast<DataGridViewColumn>().FirstOrDefault(x => x.Name == ColumnName).Index;
                return this[i, CurrentRow.Index].Value;
            }
            set
            {
                int i = Columns.Cast<DataGridViewColumn>().FirstOrDefault(x => x.Name == ColumnName).Index;
                this[i, CurrentRow.Index].Value = value;
            }
        }
        //Properties with SPs but in string format, we will use this when assigning a SP by its name
        public string sSPAdd
        {
            set
            {
                if (value != "")
                {
                    mDA.sSPAdd = value;
                    AllowInsert = true;
                }
                else
                {
                    AllowInsert = false;
                }
            }
            get
            {
                return mDA.sSPAdd;
            }
        }

        public string sSPUpp
        {
            set
            {
                if (value != "")
                {
                    mDA.sSPUpp = value;
                    AllowUpdate = true;
                }
                else
                {
                    AllowUpdate = false;
                }
            }
            get
            {
                return mDA.sSPUpp;
            }
        }

        public string sSPDel
        {
            set
            {
                if (value != "")
                {
                    mDA.sSPDel = value;
                    AllowDelete = true;
                }
                else
                {
                    AllowDelete = false;
                }
            }
            get
            {
                return mDA.sSPDel;
            }
        }

        public cAccesoDatosNet Conn { get => mDA.Conn; set => mDA.Conn = value; }

        private string BaseSQL;
        public string SQL
        {
            get
            {
                if (mDA.SelectRS != null)
                {
                    return mDA.SQL;
                }
                else return null;
            }
            set
            {
                if (value != null)
                {
                    mDA.SQL = value;
                }
            }
        }

        //public StatusBar CtlVSStatusBar { get; set; }
        public ToolStripStatusLabel MsgStatusLabel { get; set; }

        public IEnumerable<DataGridViewColumn> ColumnsSPAdd
        {
            get
            {
                return Columns.Cast<DataGridViewColumn>().Where(x => ((EspackDataGridViewColumn)x).Add);
            }
        }
        public IEnumerable<DataGridViewColumn> ColumnsSPUpp
        {
            get
            {
                return Columns.Cast<DataGridViewColumn>().Where(x => ((EspackDataGridViewColumn)x).Upp);
            }
        }
        public IEnumerable<DataGridViewColumn> ColumnsSPDel
        {
            get
            {
                return Columns.Cast<DataGridViewColumn>().Where(x => ((EspackDataGridViewColumn)x).Del);
            }
        }
        public IEnumerable<DataGridViewColumn> ColumnsExternalKeys
        {
            get
            {
                return Columns.Cast<DataGridViewColumn>().Where(x => ((EspackDataGridViewColumn)x).LinkedControl != null);
            }
        }

        public List<DataGridViewRow> ToList()
        {
            return Rows.OfType<DataGridViewRow>().ToList();
        }

        public SqlQuery CtlQuery { get; set; }
        public int Page { get; set; }


        public bool Paginate
        {
            get
            {
                return mPaginate;
            }
            set
            {
                if (value)
                {
                    if (mNavigationBar != null)
                    {
                        return;
                    }
                    else
                    {
                        Page = 1;
                        mPaginate = true;

                        mNavigationBar = new ToolStrip()
                        {
                            Location = new Point(this.Location.X, this.Location.Y + this.Size.Height - 25),
                            Size = new Size(this.Size.Width, RowTemplate.Height), //the height of a row
                            Dock = DockStyle.None
                        };
                        this.Size = new Size(this.Size.Width, this.Size.Height - RowTemplate.Height);
                        this.Parent.FindForm().Controls.Add(mNavigationBar);
                        mNavigationBar.Items.Add(new ToolStripButton()
                        {
                            Name = "btnFirst",
                            Image = (System.Drawing.Image)EspackDataGrid.Properties.Resources.first16
                        });
                        mNavigationBar.Items.Add(new ToolStripButton()
                        {
                            Name = "btnPrev",
                            Image = (System.Drawing.Image)EspackDataGrid.Properties.Resources.prev16
                        });
                        mNavigationBar.Items.Add(new ToolStripLabel()
                        {
                            Name = "Counter",
                            Text = "_/_",
                        });
                        mNavigationBar.Items.Add(new ToolStripButton()
                        {
                            Name = "btnNext",
                            Image = (System.Drawing.Image)EspackDataGrid.Properties.Resources.next16
                        });
                        mNavigationBar.Items.Add(new ToolStripButton()
                        {
                            Name = "btnLast",
                            Image = (System.Drawing.Image)EspackDataGrid.Properties.Resources.last16
                        });
                        mNavigationBar.ItemClicked += mNavigationBar_ItemClicked;
                        mPageSize = this.Size.Height / this.RowTemplate.Height - 3;
                    }
                }
                else
                {
                    if (mNavigationBar != null)
                    {
                        mNavigationBar.Dispose();
                        mNavigationBar = null;
                        this.Size = new Size(this.Size.Width, this.Size.Height + RowTemplate.Height);
                    }
                    mPaginate = false;
                }
            }
        }

        public EnumStatus Status { get => GetStatus(); set => SetStatus(value); }

        public List<EspackDataGridViewColumn> VisibleColumns
        {
            get => Columns.OfType<EspackDataGridViewColumn>().Where(c => c.Visible == true).ToList();
        }

        //public override EnumStatus GetStatus()
        //{
        //    return mStatus;
        //}

        public override void SetStatus(EnumStatus value)
        {
            this.Enabled = true;
            //this.ReadOnly 
            foreach (EspackDataGridViewColumn Col in Columns)
            {
                Col.SetStatus(value);
            }
            mStatus = value;
            switch (value)
            {
                case EnumStatus.ADDNEW:
                    {
                        break;
                    }
                case EnumStatus.EDIT:
                    {


                        if (DataGridView.RowCount == 0 && DataGridView.DataSource == null && AllowInsert)
                        {
                            Rows.Add();
                        }
                        else
                        {
                            DataRow newRow = mDA.Table.NewRow();
                            if (AllowInsert)
                                mDA.Table.Rows.Add(newRow);
                        }
                        DataGridView.Refresh();
                        break;
                    }
                case EnumStatus.DELETE:
                    {
                        break;
                    }
                case EnumStatus.SEARCH:
                    {
                        //RowEditedBool = false;
                        foreach (EspackDataGridViewColumn Col in Columns)
                        {
                            Col.ReadOnly = true;
                        }
                        break;
                    }
                case EnumStatus.NAVIGATE:
                    {
                        foreach (EspackDataGridViewColumn Col in Columns)
                        {
                            Col.ReadOnly = true;
                        }
                        break;
                    }
            }
            if ((GetStatus() == EnumStatus.ADDNEW || GetStatus() == EnumStatus.EDIT) && DataGridView.RowCount > 0)
            {
                foreach (EspackDataGridViewColumn lCol in Columns)
                {
                    lCol.ReadOnly = (!lCol.Upp || lCol.PK || !AllowUpdate);
                }
                foreach (EspackDataGridViewCell lCell in Rows[DataGridView.RowCount - 1].Cells)
                {
                    lCell.ReadOnly = !((EspackDataGridViewColumn)Columns[lCell.ColumnIndex]).Add || ((EspackDataGridViewColumn)Columns[lCell.ColumnIndex]).Locked || !AllowInsert;
                    //if (lCell.ReadOnly)
                    //{
                    //    lCell.Style.BackColor = Colors.CELLLOCKEDBACKCOLOR;
                    //    lCell.Style.ForeColor = Colors.CELLLOCKEDFORECOLOR;
                    //}
                    //else
                    //{
                    //    lCell.Style.BackColor = Colors.CELLBACKCOLOR;
                    //    lCell.Style.ForeColor = Colors.CELLFORECOLOR;
                    //}
                }
                var _candidate = DataGridView.Rows[DataGridView.RowCount - 1].Cells.Cast<DataGridViewCell>().FirstOrDefault(x => x.ReadOnly == false && x.Visible == true);
                var c = _candidate ?? this[0, 0];
                DataGridView.CurrentCell = c;
            }
            if (FilterRowEnabled)
            {
                FilterDataGrid.Rows[0].Cells.OfType<EspackDataGridViewCell>().ToList().ForEach(c => c.ReadOnly = false);
            }
        }

        public string Query { get => GetQuery(); }

        public string GetQuery()
        {
            string lSQL = "";
            List<string> lQueryFields = new List<string>();
            List<string> lWhereFields = new List<string>();
            List<string> lOrderFields = new List<string>();

            foreach (EspackDataGridViewColumn Col in Columns)
            {
                string lDelimiter = CT.IsNumericType(Col.DBFieldType) ? "" : "'";
                if (Col.DBField != "")
                {
                    lQueryFields.Add("[" + Col.Name + "]=" + Col.DBField);

                }
                if (Col.LinkedControl != null)
                {
                    string lValue = "@" + Col.Name;
                    lWhereFields.Add(Col.DBField + "=" + lValue);
                }
                if (Col.Sortable)
                {
                    lOrderFields.Add(Col.DBField);
                }
            }
            //construnt the select clause
            lSQL = "Select " + string.Join(", ", lQueryFields) + " from " + DBTable;
            //add the where clause
            string lWhere = string.Join(" and ", lWhereFields);
            lWhere = lWhere != "" ? " Where " + lWhere : "";
            lSQL = lSQL + lWhere;
            //add the order clause
            string lOrder = string.Join(", ", lOrderFields);
            lOrder = lOrder != "" ? " Order by " + lOrder : "";
            lSQL = lSQL + lOrder;

            return lSQL;
        }

        public string DBTable { get; set; }
        private EspackDataGridViewCell oldCurrentCell; //{ get; set; }
        public bool Dirty { get; set; }
        //private EspackDataGridViewControl DataGridView;
        //private int RowEdited;
        //private bool RowEditedBool = false;
        #endregion
        public EspackDataGridViewControl() :
            this(null)
        { }

        public EspackDataGridViewControl(EspackDataGridViewControl dataDataGV = null)
        {
            InitializeComponent();
            AllowDelete = false;
            AllowInsert = false;
            AllowUpdate = false;
            DataGridView.RowHeadersVisible = false;
            DataGridView.CellEnter += EspackDataGridView_CellEnter;
            DataGridView.GotFocus += DataGridView_GotFocus;
            DataGridView.LostFocus += DataGridView_LostFocus;
                GridColor = SystemColors.ButtonFace;
                DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                DataGridView.AllowUserToResizeColumns = true;
                DataGridView.CellBeginEdit += EspackDataGridView_CellBeginEdit;
                DataGridView.CellEndEdit += EspackDataGridView_CellEndEdit;
                DataGridView.CurrentCellDirtyStateChanged += EspackDataGridView_CurrentCellDirtyStateChanged;
                Resize += CtlVSGrid_Resize;
                KeyDown += CtlVSGrid_KeyDown;
                DataGridView.SelectionChanged += EspackDataGridView_SelectionChanged;
                DataGridView.ColumnWidthChanged += EspackDataGridView_ColumnWidthChanged;
                DataGridView.CellLeave += EspackDataGridView_CellLeave;
                //CurrentCellChanged += EspackDataGridView_CurrentCellChanged;
                //this.RowEnter += EspackDataGridView_RowEnter;
                Dirty = false;

            /*
            else
            {
                DataGridView.Sorted += EspackDataGridView_Sorted;
                DataGridView = dataDataGV;
                DataGridView.Scroll += DataGridView_Scroll;
                DataGridView.VerticalScrollBar.VisibleChanged += VerticalScrollBar_VisibleChanged;
            }
            */
            SetStatus(EnumStatus.SEARCH);
            AllowUserToAddRows = false;
            CaptionLabel = new EspackLabel("", this) { AutoSize = true };
            EspackTheme.changeControlFormat(this);

        }

        private void EspackDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            oldCurrentCell = this[e.ColumnIndex, e.RowIndex];
        }

        private void VerticalScrollBar_VisibleChanged(object sender, EventArgs e)
        {
            if (VerticalScrollBar.Visible)
            {
                Width = DataGridView.Width - VerticalScrollBar.Width;
            }
            else
            {
                Width = DataGridView.Width;
            }
            Refresh();
            HorizontalScrollingOffset = DataGridView.HorizontalScrollingOffset;
        }

        private void DataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            HorizontalScrollingOffset = DataGridView.HorizontalScrollingOffset;
        }

        private void EspackDataGridView_Sorted(object sender, EventArgs e)
        {
            DataGridView.Sort(DataGridView.Columns[SortedColumn.Index], SortOrder == SortOrder.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
        }

        private void EspackDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (FilterRowEnabled)
                FilterDataGrid.Columns.OfType<DataGridViewColumn>().Where(c => c.Tag.ToInt() == e.Column.Index).First().Width = e.Column.Width;
        }

        private void EspackDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            Dirty = true;
        }

        private void EspackDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            //oldCurrentCell = (EspackDataGridViewCell)CurrentCell;
            //var destinationCell = SelectedCells.Cast<EspackDataGridViewCell>().FirstOrDefault();
            if (cancelSelect)
            {
                DataGridView.SelectionChanged -= EspackDataGridView_SelectionChanged;
                CurrentCell = oldCurrentCell;
                DataGridView.SelectionChanged += EspackDataGridView_SelectionChanged;
                cancelSelect = false;
                return;
            }
            if (oldCurrentCell != null && CurrentCell?.RowIndex != oldCurrentCell.RowIndex)
            {
                if (oldCurrentCell.RowIndex == RowCount - 1 && AllowInsert && Dirty)
                {
                    if (MessageBox.Show("The current line is not yet inserted. Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        DataGridView.SelectionChanged -= EspackDataGridView_SelectionChanged;
                        CurrentCell = oldCurrentCell;
                        DataGridView.SelectionChanged += EspackDataGridView_SelectionChanged;
                    }
                }
                else if (AllowUpdate && Dirty)
                    if (MessageBox.Show("The current line is not yet updated. Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    {
                        DataGridView.SelectionChanged -= EspackDataGridView_SelectionChanged;
                        CurrentCell = oldCurrentCell;
                        DataGridView.SelectionChanged += EspackDataGridView_SelectionChanged;
                    }
            }
            //oldCurrentCell = (EspackDataGridViewCell)CurrentCell; /*/
        }

        //private void EspackDataGridView_CurrentCellChanged(object sender, EventArgs e)
        //{
        //    if (oldCurrentCell!=null && CurrentCell.RowIndex != oldCurrentCell.RowIndex)
        //    {
        //        if (oldCurrentCell.RowIndex == RowCount-1 && AllowInsert && Dirty)
        //        {
        //            if (MessageBox.Show("The current line is not yet inserted. Are you sure?","Warning",MessageBoxButtons.YesNo, MessageBoxIcon.Warning)== DialogResult.No)
        //            {
        //                CurrentCell = oldCurrentCell;
        //            }
        //        } else if (AllowUpdate && Dirty)
        //            if (MessageBox.Show("The current line is not yet updated. Are you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
        //            {
        //                CurrentCell = oldCurrentCell;
        //            }
        //    }
        //}
        private bool cancelSelect = false;
        private bool executed = false;

        //public event EventHandler<ValueChangedEventArgs> ValueChanged;

        private void EspackDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            executed = false;
            if (endEditing)
                return;
            endEditing = true;
            bool commitEdit = false;
            if (e.ColumnIndex == VisibleColumns.Select(c => c.Index).Max())
                commitEdit = true;
            if (CurrentCell.ReadOnly && e.ColumnIndex == VisibleColumns.Select(c => c.Index).Max())
                commitEdit = true;
            if (commitEdit)
            {
                executed = true;
                cancelSelect = !ExecuteCommand(true);
            }
            //else
            //{
            //    cancelSelect = true;
            //    var laCell = NextEditableCell();
            //    CurrentCell = laCell;
            //}
            //oldCurrentCell = (EspackDataGridViewCell)CurrentCell;
            endEditing = false;
            //RowEdited = e.RowIndex;
            //RowEditedBool = true;
        }

        private void DataGridView_LostFocus(object sender, EventArgs e)
        {
            DGFocused = false;
        }

        
        private void DataGridView_GotFocus(object sender, EventArgs e)
        {
            DGFocused = true;
        }


        private EspackDataGridViewCell NextEditableCell(EspackDataGridViewCell fromCell = null)
        {
            fromCell = fromCell ?? (EspackDataGridViewCell)CurrentCell;
            var candidateCell = Rows[fromCell.RowIndex].Cells.OfType<EspackDataGridViewCell>().Where(c => !c.ReadOnly && c.ColumnIndex > fromCell.ColumnIndex).OrderBy(c => c.ColumnIndex).FirstOrDefault();
            //var Cell = VisibleColumns.Where(c => !c.ReadOnly && c.Index > fromCell.ColumnIndex).OrderBy(c => c.Index).FirstOrDefault()?.Cells[fromCell.RowIndex];
            return candidateCell ?? fromCell;
        }

        private void EspackDataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!this[e.ColumnIndex, e.RowIndex].ReadOnly)
            {
                if (!DataGridView.IsCurrentCellInEditMode)
                {
                    ((EspackDataGridViewCell)CurrentCell).Conn= Conn;
                    BeginEdit(true);
                }
            }// else
             //{
             //    if (e.ColumnIndex < VisibleColumns.Select(c => c.Index).Max())
             //        SendKeys.Send("{RIGHT}");
             //}
        }

        ~EspackDataGridViewControl()
        {
            if (CaptionLabel != null)
                CaptionLabel.Dispose();
            CaptionLabel = null;
        }

        private bool endEditing = false;
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if ((keyData == Keys.Enter || keyData == Keys.Tab))
            {
                if (DataGridView.IsCurrentCellInEditMode)
                {
                    EndEdit();
                    if (!cancelSelect && !executed)
                        CurrentCell = NextEditableCell();
                }
                else
                if (!CurrentCell.ReadOnly)
                    BeginEdit(true);
                else
                    SendKeys.Send("{RIGHT}");
                return true;
            }
            else
                return base.ProcessCmdKey(ref msg, keyData);
        }

        #region FilterMethods
        private void AddFilterRow()
        {
            FilterDataGrid = new DataGridView();
            //FilterDataGrid.CellEnter += EspackDataGridView_CellEnter;
            FilterDataGrid.ColumnWidthChanged += FilterDataGrid_ColumnWidthChanged;
            FilterDataGrid.GotFocus += FilterDataGrid_GotFocus;
            FilterDataGrid.LostFocus += FilterDataGrid_LostFocus;
            FilterDataGrid.CellBeginEdit += FilterDataGrid_CellBeginEdit;
            FilterDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            FilterDataGrid.AllowUserToResizeColumns = true;
            //FilterDataGrid.Conn = Conn;
            FilterDataGrid.Location = Location;
            FilterDataGrid.Height = 2 * Rows[0].Height;
            FilterDataGrid.Width = Width;
            FilterDataGrid.ScrollBars = ScrollBars.None;
            FilterDataGrid.RowHeadersVisible = false;
            DataGridView.Dock = DockStyle.None;
            DataGridView.Location = new Point(DataGridView.Location.X, DataGridView.Location.Y + 2 * Rows[0].Height);
            DataGridView.Height = Height - 2 * Rows[0].Height;
            DataGridView.Width = Width;
            DataGridView.Sorted += EspackDataGridView_Sorted;
            DataGridView.Scroll += DataGridView_Scroll;
            VerticalScrollBar.VisibleChanged += VerticalScrollBar_VisibleChanged;
            this.Controls.Add(FilterDataGrid);
            Columns.OfType<EspackDataGridViewColumn>().Where(c => c.Visible == true).ToList().ForEach(c =>
            {
                var column = new EspackDataGridViewColumn
                {
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                    Width = c.Width,
                    Tag = c.Index,
                    HeaderText = c.HeaderText,
                    Name = c.Name,
                    DBField = c.DBField
                };
                FilterDataGrid.Columns.Add(column);
            });
            DataGridView.ColumnHeadersVisible = false;
            FilterRow = new DataGridViewRow();
            FilterDataGrid.Rows.Add(FilterRow);
            //Refresh();
            //FilterRow = FilterDataGrid.Rows[0];
        }

        private void FilterDataGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            FGFocused = true;
        }

        private void FilterDataGrid_LostFocus(object sender, EventArgs e)
        {
             FGFocused = false;
        }

        private void FilterDataGrid_GotFocus(object sender, EventArgs e)
        {
            FGFocused = true;
        }

        private void FilterDataGrid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Columns.OfType<DataGridViewColumn>().Where(c => c.Index == e.Column.Tag.ToInt()).First().Width = e.Column.Width;
        }

        public void AddFilterCell(EspackCellTypes type, int column, string sqlSource = "")
        {
            if (FilterRowEnabled)
            {
                //var col = (EspackDataGridViewColumn)Columns[column];
                FilterDataGrid[column, 0] = new EspackDataGridViewCell(type, AutoCompleteMode.SuggestAppend, AutoCompleteSource.CustomSource, sqlSource, Conn) { SqlSource = sqlSource, IsFilterCell = true };
                FilterCells.Add((EspackDataGridViewCell)FilterDataGrid[column, 0]);
                FilterDataGrid[column, 0].ReadOnly = false;
                ((EspackDataGridViewCell)FilterDataGrid[column, 0]).CellValueChanged += EspackDataGridView_FilterCellValueChanged;


            }
            else
            {
                throw new Exception("Enable Filter Row first");
            }
        }

        private void EspackDataGridView_FilterCellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            //for (int i = 1; i < Rows.Count; i++)
            //    mDA.Table.Rows.RemoveAt(i);
            if (FilterDataGrid.IsCurrentCellInEditMode /*&& !FilterDataGrid.endEditing*/)
                FilterDataGrid.EndEdit();
            List<string> whereList = new List<string>();
            //Dictionary<int, string> valueList = new Dictionary<int, string>();
            foreach (EspackDataGridViewCell c in FilterCells)
            {
                //valueList.Add(c.ColumnIndex, c.Value.ToString());
                if (c.Value?.ToString() != null && c.Value?.ToString() != "")
                {
                    if (c.Type == EspackCellTypes.CHECKEDCOMBO)
                    {
                        var values = string.Format("'{0}'", c.Value.ToString().Replace("|", "','"));
                        whereList.Add(string.Format("{0} in ({1})", c.Column.DBField, values));
                    }
                    else
                        whereList.Add(string.Format("{0} like '%{1}%'", c.Column.DBField, c.Value.ToString()));
                }
            }
            BaseSQL = BaseSQL ?? SQL;
            //Refresh();
            DA _da = new DA(Conn);
            _da.SQL = whereList.Count > 0 ? string.Format("Select * from ({0}) a where {1}", BaseSQL, string.Join(" and ", whereList)) : BaseSQL;
            _da.Open();
            DataGridView.DataSource = _da.Table;
            Refresh();
            //((EspackDataGridViewColumn)Columns[e.ColIndex]).Filter(e.NewValue.ToString(), true);
        }

        #endregion

        private void CtlVSGrid_Resize(object sender, EventArgs e) //resizes the control to multiples of row height
        {
            if (this.Size.Height % RowTemplate.Height != 0)
            {
                //if (this.Size.Height % RowTemplate.Height > RowTemplate.Height / 2)
                //{
                //    this.Size = new Size(this.Size.Width, RowTemplate.Height * ((int)(this.Size.Height / RowTemplate.Height) + 1));
                //}
                //else
                //{
                this.Size = new Size(this.Size.Width, RowTemplate.Height * (int)(this.Size.Height / RowTemplate.Height));
                //}
            }
        }

        //eventhandler
        private void mNavigationBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "btnNext":
                    if (Page < NumPages)
                    {
                        Page++;
                        Navigate();
                    }
                    break;
                case "btnPrev":
                    if (Page > 1)
                    {
                        Page--;
                        Navigate();
                    }
                    break;
                case "btnFirst":
                    Page = 1;
                    Navigate();
                    break;
                case "btnLast":
                    Page = NumPages;
                    Navigate();
                    break;
            }
            mNavigationBar.Items["Counter"].Text = Page.ToString() + "/" + NumPages.ToString();
            return;
        }
        public void Navigate()
        {
            mDA.Open((Page - 1) * mPageSize, mPageSize);
            DataGridView.DataSource = mDA.Table;
            this.Refresh();
        }
        //evenhandler

        private void CtlVSGrid_KeyDown(object sender, KeyEventArgs e)
        {
            SP lCommand;
            string lMsg = "";

            // 20180524 [dvalles] wrong use of null exception when clearing (ESC key) due to the null value in FilterCells
            //if (GetStatus() != EnumStatus.ADDGRIDLINE && GetStatus() != EnumStatus.EDITGRIDLINE && GetStatus() != EnumStatus.EDIT && GetStatus() != EnumStatus.ADDNEW && !(FilterCells.Contains(CurrentCell)))
            if (GetStatus() != EnumStatus.ADDGRIDLINE && GetStatus() != EnumStatus.EDITGRIDLINE && GetStatus() != EnumStatus.EDIT && GetStatus() != EnumStatus.ADDNEW)
            {
                bool lCancel = true;

                if (FilterCells != null)
                {
                    if (FilterCells.Contains(CurrentCell))
                        lCancel = false;
                }

                if (lCancel)
                {
                    CancelEdit();
                    return;
                }
            }

            switch (e.KeyCode)
            {
                //case Keys.Enter:
                //    {
                //        //do
                //        //{
                //        //    CurrentCell = Rows[CurrentCell.RowIndex].Cells[CurrentCell.ColumnIndex + 1];
                //        //    //SendKeys.Send("{RIGHT}");
                //        //}
                //        //while (CurrentCell.ReadOnly && CurrentCell.ColumnIndex < Columns.Count - 1);
                //        //SendKeys.Send("{RIGHT}");
                //        BeginEdit(true);
                //        e.Handled = true;
                //        break;
                //    }
                case Keys.Delete:
                case Keys.Insert:
                    {
                        if (e.KeyCode == Keys.Delete)
                        {
                            if (CurrentCell.RowIndex == Rows.Count - 1)
                                break;

                            if (!AllowDelete)
                            {
                                MessageBox.Show("Deletion not allowed.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                break;
                            }
                            if (MessageBox.Show("This will delete the actual line. Are you sure?", "WARNING", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                lCommand = mDA.DeleteCommand;
                                lMsg = "Line deleted OK";
                            }
                            else
                            {
                                break;
                            }
                            lCommand.Execute();
                            if (lCommand.LastMsg.Substring(0, 2) != "OK")
                            {
                                MessageBox.Show("ERROR:" + lCommand.LastMsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                lMsg = "ERROR:" + lCommand.LastMsg;
                                StatusMsg(lMsg);
                                return;
                            }
                            StatusMsg(lMsg);
                            UpdateEspackControl();
                            if (EspackControlParent != null && !lCommand.Equals(mDA.DeleteCommand))
                            {
                                EspackControlParent.SetStatus(mPreviousParentStatus);
                            }
                            return;
                        }
                        ExecuteCommand();
                        break;
                    }

            }
        }
        private bool ExecuteCommand(bool warning = false)
        {
            SP lCommand;
            string lMsg = "";
            string lWarning = "";
            {
                if (CurrentCell.RowIndex == Rows.Count - 1)
                {
                    if (!AllowInsert)
                    {
                        MessageBox.Show("Insertion not allowed.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }
                    lCommand = mDA.InsertCommand;
                    lMsg = "Line inserted OK";
                    lWarning = "Do you want to insert current line?";
                }
                else
                {
                    if (!AllowUpdate)
                    {
                        MessageBox.Show("Update not allowed.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }
                    lCommand = mDA.UpdateCommand;
                    lMsg = "Line updated OK";
                    lWarning = "Do you want to insert current line?";
                }
            }
            if (warning)
            {
                if (MessageBox.Show(lWarning, "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) != DialogResult.OK)
                {
                    //Dirty = false;
                    return true;
                }

            }
            lCommand.Execute();
            if (lCommand.LastMsg.Substring(0, 2) != "OK")
            {
                MessageBox.Show("ERROR:" + lCommand.LastMsg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lMsg = "ERROR:" + lCommand.LastMsg;
                if (lCommand == mDA.UpdateCommand) //si es un update que ha dado error, reconsultamos el grid para eliminar los valores erróneos
                {
                    //RowEditedBool = false;
                    var x = CurrentCell.ColumnIndex;
                    var y = CurrentCell.RowIndex;
                    UpdateEspackControl();
                    CurrentCell = Rows[y].Cells[x];
                }
                //Dirty = false;
                return false;
            }
            StatusMsg(lMsg);
            Application.DoEvents();
            //RowEditedBool = false;
            UpdateEspackControl();
            if (EspackControlParent != null && !lCommand.Equals(mDA.DeleteCommand))
            {
                EspackControlParent.SetStatus(mPreviousParentStatus);
            }
            return true;
        }

        protected override void OnMove(EventArgs e)
        {
            CaptionLabel.Location = new Point(base.Location.X, base.Location.Y - CaptionLabel.PreferredHeight - 5);
            //CaptionLabel.Location = new Point(Location.X - CaptionLabel.PreferredWidth - 6, Location.Y);
            base.OnMove(e);
        }

        private void EspackDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (CurrentCell.ReadOnly)
            {
                e.Cancel = true;
                return;
            }
            if (EspackControlParent != null /*&& !RowEditedBool*/)
            {
                mPreviousParentStatus = EspackControlParent.GetStatus();
                if (CurrentCell.RowIndex == Rows.Count - 1)
                {
                    EspackControlParent.SetStatus(EnumStatus.ADDGRIDLINE);
                }
                else
                {
                    EspackControlParent.SetStatus(EnumStatus.EDITGRIDLINE);
                }
            }
        }
        public void Start()
        {
            DataGridView.AutoGenerateColumns = false;
            if (SQL != null)
            {
                CtlQuery = CT.SimpleParseSQL(SQL);
                mDA.FillSchema();
                Columns.Clear();
                foreach (DataColumn Col in mDA.Schema)
                {
                    this.Columns.Add(new EspackDataGridViewColumn(name: CtlQuery.SelectFields[Col.ColumnName].DBItemName, dBField: CtlQuery.SelectFields[Col.ColumnName].DBItemName, dBFieldType: Col.DataType));
                }
            }
            else
            {

                SQL = Query;
                BaseSQL = SQL;
                foreach (EspackDataGridViewColumn Col in Columns)
                {
                    if (Col.LinkedControl != null)
                    {
                        mDA.AddParameter(Col.Name, Col.LinkedControl);
                        if (Col.Add) mDA.InsertCommand.AddControlParameter(Col.SPAddParamName, Col.LinkedControl);
                        if (Col.Upp) mDA.UpdateCommand.AddControlParameter(Col.SPUppParamName, Col.LinkedControl);
                        if (Col.Del) mDA.DeleteCommand.AddControlParameter(Col.SPDelParamName, Col.LinkedControl);
                    }
                    else
                    {
                        if (Col.Add) mDA.InsertCommand.AddControlParameter(Col.SPAddParamName, Col);
                        if (Col.Upp) mDA.UpdateCommand.AddControlParameter(Col.SPUppParamName, Col);
                        if (Col.Del) mDA.DeleteCommand.AddControlParameter(Col.SPDelParamName, Col);
                    }
                }
                CtlQuery = CT.SimpleParseSQL(Query);
                mDA.FillSchema();
                foreach (DataColumn Col in mDA.Schema)
                {
                    ((EspackDataGridViewColumn)this.Columns[Col.ColumnName]).DBFieldType = Col.DataType;
                }

            }

            this.Refresh();
        }

        public void AddColumn(string pName, string pDBFieldName = "", string pSPAdd = "", string pSPUpp = "", string pSPDel = "", bool pSortable = false,
                    bool pIsFlag = false, bool pLocked = false, string pQuery = "", int pWidth = 0, string pAlignment = "", string pAttr = "",
                    AutoCompleteMode aMode = AutoCompleteMode.None, AutoCompleteSource aSource = AutoCompleteSource.None, string aQuery = "",
                    bool pPrint = false, bool pVisible = true, bool pPK = false)
        {
            EspackCellTypes type;

            if (pIsFlag)
                type = EspackCellTypes.CHECKEDCOMBO;
            else if (pQuery == "")
                type = EspackCellTypes.TEXT;
            else type = EspackCellTypes.COMBO;
            var _Col = new EspackDataGridViewColumn(name: pName, dBField: pDBFieldName == "" ? pName : pDBFieldName, sPAddParamName: pSPAdd,
                            sPDelParamName: pSPDel, sPUppParamName: pSPUpp, locked: pLocked, width: pWidth, sortable: pSortable, linkedControl: null,
                            autoCompleteMode: aMode, autoCompleteSource: aSource, autoCompleteQuery: aQuery, visible: pVisible, pK: pPK, query: pQuery, type: type);
            Columns.Add(_Col);
        }

        public void AddColumn(string pName, EspackFormControl pLinkedControl, string pSPAdd = "", string pSPUpp = "", string pSPDel = "",
                    AutoCompleteMode aMode = AutoCompleteMode.None, AutoCompleteSource aSource = AutoCompleteSource.None, string aQuery = "",
                    bool pPrint = false, bool pVisible = true, bool pPK = false)
        {
            var _Col = new EspackDataGridViewColumn(name: pName, dBField: pName, sPAddParamName: pSPAdd,
                sPDelParamName: pSPDel, sPUppParamName: pSPUpp, locked: true, width: 0, sortable: false, linkedControl: pLinkedControl,
                autoCompleteMode: aMode, autoCompleteSource: aSource, autoCompleteQuery: aQuery, visible: pVisible, pK: pPK, type: EspackCellTypes.TEXT);
            Columns.Add(_Col);
        }

        public void StatusMsg(string lMsg)
        {
            if (MsgStatusLabel != null) MsgStatusLabel.Text = lMsg;
        }

        public override void UpdateEspackControl()
        {
            string lSql;
            int mNumRecords = 0;
            Page = 1;
            //mDA.SelectRS=new DynamicRS();
            mDA.SelectRS.DS?.Dispose();
            DataGridView.SelectionChanged -= EspackDataGridView_SelectionChanged;
            DataGridView.DataSource = null;
            DataGridView.SelectionChanged += EspackDataGridView_SelectionChanged;
            if (Paginate)
            {
                mDA.Open((Page - 1) * mPageSize, mPageSize);
                lSql = "SELECT NumRecords=count(*) FROM " + CtlQuery.Tablename.DBItemName + " WHERE " + CtlQuery.WhereString;
                DynamicRS lRS = (DynamicRS)new DynamicRS(lSql, Conn);
                foreach (EspackDataGridViewColumn lColumn in ColumnsExternalKeys)
                {
                    lRS.AddControlParameter(lColumn.Name, lColumn.LinkedControl);
                }
                lRS.Open();
                mNumRecords = Convert.ToInt32(lRS["NumRecords"]);
                NumPages = mNumRecords / mPageSize + ((mNumRecords % mPageSize) == 0 ? 0 : 1);
                mNavigationBar.Enabled = NumPages > 1;
                mNavigationBar.Items["Counter"].Text = "1/" + NumPages.ToString();
            }
            else
            {
                mDA.Open();
            }
            DataGridView.SelectionChanged -= EspackDataGridView_SelectionChanged;
            DataGridView.DataSource = mDA.Table;
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Refresh();
            DataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            DataGridView.SelectionChanged += EspackDataGridView_SelectionChanged;
            Dirty = false;
            SetStatus(mStatus);
        }
        public override void ClearEspackControl()
        {
            //RowEditedBool = false;
            DataGridView.DataSource = null;
            this.RowCount = 0;
            //this.ScrollBars = ScrollBars.None;
        }
        public void Print(EspackPrintDocument p)
        {
            p.NewLine(true);
            List<int> _colWidths = new List<int>();
            List<char> _colAligns = new List<char>();
            // get the col max widths
            Columns.Cast<EspackDataGridViewColumn>().ToList().ForEach(x =>
            {
                _colWidths.Add(x.MaxWidth);
                _colAligns.Add(x.IsNumeric ? 'R' : 'L');

            });
            //headers
            var _font = p.CurrentFont;
            p.CurrentFont = new Font(_font, FontStyle.Bold);
            Columns.OfType<DataGridViewColumn>().Where(x => ((EspackDataGridViewColumn)x).Print == true).ToList().ForEach(x =>
            {
                if (_colAligns[x.Index] == 'L')
                    p.Add(x.HeaderCell.Value.ToString().PadRight(_colWidths[x.Index]));
                else
                    p.Add(x.HeaderCell.Value.ToString().PadLeft(_colWidths[x.Index]));
            });

            p.CurrentFont = _font;
            p.NewLine(true);
            Rows.OfType<DataGridViewRow>().ToList().ForEach(r =>
            {
                r.Cells.OfType<DataGridViewCell>().Where(x => ((EspackDataGridViewColumn)x.OwningColumn).Print == true).ToList().ForEach(x =>
                {
                    if (_colAligns[x.ColumnIndex] == 'L')
                        p.Add(x.Value.ToString().PadRight(_colWidths[x.ColumnIndex]));
                    else
                        p.Add(x.Value.ToString().PadLeft(_colWidths[x.ColumnIndex]));
                });
                p.NewLine(true);
            });
            p.NewLine();
            //aggregates
            p.CurrentFont = new Font(_font, FontStyle.Bold);
            var _aggregateList = new AggregateItemList();
            //Columns.OfType<DataGridViewColumn>().Where(x => ((CtlVSColumn)x).Print == true).ToList().ForEach(x => {
            //    string _value = ((CtlVSColumn)x).Aggregate != AggregateOperations.NONE ? ((CtlVSColumn)x).AggregateValue.ToString() : " ";
            //    if (_colAligns[x.Index] == 'L')
            //        p.Add(_value.PadRight(_colWidths[x.Index]));
            //    else
            //        p.Add(_value.PadLeft(_colWidths[x.Index]));
            //});
            Columns.OfType<EspackDataGridViewColumn>().Where(x => x.Aggregate != AggregateOperations.NONE).ToList().ForEach(x => _aggregateList.Items.Add(new AggregateItem() { Aggregate = x.Aggregate, FieldName = ((DataGridViewColumn)x).HeaderCell.Value.ToString(), Value = x.AggregateValue }));
            //Columns.OfType<CtlVSColumn>().Where(x => x.Aggregate != AggregateOperations.NONE).ToList().ForEach(x => _aggregates[string.Format("{0}({1})", x.Aggregate.ToString(), ((DataGridViewColumn)x).HeaderCell.Value.ToString())] = x.AggregateValue.ToString());
            //_aggregates.Select(x => )
            //p.Add(string.Format("{0}({1}) = {2}", x.Aggregate.ToString(), ((DataGridViewColumn)x).HeaderCell.Value.ToString(), x.AggregateValue));
            //    p.NewLine(true);
            //});
            _aggregateList.Items.ForEach(a =>
            {
                p.Add(a.Title.PadLeft(_aggregateList.LenghtTitle));
                p.Add("=");
                p.Add(a.StringValue.PadLeft(_aggregateList.LenghtValue));
                p.NewLine();
            });
            p.CurrentFont = _font;
        }


    }
}
