using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using Common;

namespace Test1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class CTLRObject
    {
        public CTLRObject(Control theControl, string dBTableField, string dBAddParamName = null, string dBUppParamName = null, string dBDelParamName = null, bool add = false, bool upp = false, bool del = false, bool search = false)
        {
            TheControl = theControl;
            DBTableField = dBTableField ?? throw new ArgumentNullException(nameof(dBTableField));
            DBAddParamName = dBAddParamName ?? (add ? '@' + dBTableField : "");
            DBUppParamName = dBUppParamName ?? (upp ? '@' + dBTableField : "");
            DBDelParamName = dBDelParamName ?? (del ? '@' + dBTableField : "");
            Search = search;
            Add = add;
            Upp = upp;
            Del = del;
        }

        public Control TheControl { get; set; }
        public string DBTableField { get; set; }
        public string DBAddParamName { get; set; }
        public string DBUppParamName { get; set; }
        public string DBDelParamName { get; set; }
        public bool Search { get; set; }
        public bool Add { get; set; }
        public bool Upp { get; set; }
        public bool Del { get; set; }

        public object Value
        {
            get
            {
                switch (TheControl.GetType().ToString())
                {
                    case "System.Windows.Controls.TextBox": return ((TextBox)TheControl).Text;
                    default:
                        return null;
                }
            }
                
            set
            {
                switch (TheControl.GetType().ToString())
                {
                    case "System.Windows.Controls.TextBox": ((TextBox)TheControl).Text = value.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        public void Bind(DependencyProperty dp, DataView source)
        {
            TheControl.SetBinding(dp, new Binding() { Source = source, Path = new PropertyPath(DBTableField), Mode = BindingMode.TwoWay, UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });
        }
        public void UnBind()
        {
            BindingOperations.ClearAllBindings(TheControl);
        }
        public void Clear()
        {
            UnBind();
            if (TheControl is TextBox)
                ((TextBox)TheControl).Text = "";
        }
    }



    public partial class MainWindow : Window
    {
        public DataView CurrentView { get; set; }
        public DataView SearchResultsView { get; set; }
        public DataSet DS { get; set; }
        public DataTable DT { get; set; }
        public SqlConnection Conn { get; set; }
        public SqlDataAdapter DA { get; set; }
        public int RecordCount { get => DT.Rows.Count; }
        public Collection<CTLRObject> CTLRObjects { get; set; } = new Collection<CTLRObject>();
        public long PageSize { get; set; }
        public string OrderPage { get; set; }
        public string SQL { get; set; }
        public long PageNumber { get; set; } = 0;
        public long NumRecords { get; private set; }
        public string CurrentFilter { get; set; }
        public long NumPages { get; private set; }
        public DataRowView CurrentRow
        {
            get
            {
                return SearchResultsView.OfType<DataRowView>().FirstOrDefault(r => (long)r["k"]==NumRecord);
            }
        }
        //public DataRow CurrentRow
        //{
        //    get => DT.Rows.OfType<DataRow>().FirstOrDefault(o => (bool)(o["Shown"] is Boolean ? o["Shown"] : false) == true);
        //}
        public long RecordIndex
        {
            get
            {
                return DT.Rows.IndexOf(CurrentRow.Row);
            }
        }

        public long NumRecord
        {
            get
            {
                if (CurrentView != null)
                    return (long)CurrentView[0]["k"];
                else
                    return -1;
            }
            set
            {
                CurrentView.RowFilter = string.Format("k = {0}", value);
            }
        }



        public async Task GetTotals()
        {
            SqlCommand sc = new SqlCommand(string.Format("Select count(*) from ({0}) b", SQL), Conn);
            if (Conn.State == ConnectionState.Closed)
                Conn.Open();

            SqlDataReader dr = await sc.ExecuteReaderAsync();
            if (dr.Read())
            {
                NumRecords = (int)dr[0];
                NumPages = (NumRecords - 1) / PageSize + 1;
            }
            dr.Close();
            Conn.Close();
        }

        public string PagingSQL(string sql, long pagesize, long page, string keyField, bool requeryTotal = false)
        {
            string _result = string.Format(@";WITH x AS (SELECT *, k = ROW_NUMBER() OVER (ORDER BY {3}) FROM ({0}) b)
SELECT *{4}
FROM x 
WHERE x.k BETWEEN((({1} - 1) * {2}) + 1) AND {1} * {2}
ORDER BY {3}; ", sql, page, pagesize, keyField, requeryTotal ? ", TotalRows = (Select max(k) from x)":"");
            return _result;
        }

        private async Task GetPage(long numPage)
        {
            PageNumber = numPage;
            DA.SelectCommand.CommandText = PagingSQL(SQL, PageSize, PageNumber, OrderPage);
            DS.Dispose();
            DS = null;
            DS = new DataSet();
            await Task.Run(() => DA.Fill(DS));
            DT = DS.Tables[0];
        }

        public MainWindow()
        {
            InitializeComponent();
            DS = new DataSet();
            DA = new SqlDataAdapter();

            CTLRObjects.Add(new CTLRObject(txtIdReg, "idreg", add: true, upp: true, del: true, search: true));
            CTLRObjects.Add(new CTLRObject(txtElCampo1, "elCampo1", add: true, upp: true, search: true));
            CTLRObjects.Add(new CTLRObject(txtElCampo2, "elCampo2", add: true, upp: true, search: true));

            OrderPage = "idreg";
            PageSize = 10;
            PageNumber = 1;
            SQL = "Select * from TestTable";

            



            Conn = new SqlConnection("Data Source=DB01;Initial Catalog=TEST;Integrated Security=True");
            DA.SelectCommand = new SqlCommand()
            {
                Connection = Conn,
                //CommandText = PagingSQL(SQL,PageSize,PageNumber,OrderPage),
                CommandType = CommandType.Text
            };
            //DA.Fill(DS);

            Conn.Open();
            DA.InsertCommand = new SqlCommand()
            {
                Connection = Conn,
                CommandText = "pTestTableAdd",
                CommandType = CommandType.StoredProcedure
            };
            SqlCommandBuilder.DeriveParameters(DA.InsertCommand);
            DA.InsertCommand.Parameters["@msg"].Value = "";

            foreach (var o in CTLRObjects.Where(o => o.Add))
                DA.InsertCommand.Parameters[o.DBAddParamName].SourceColumn = o.DBTableField;

            DA.UpdateCommand = new SqlCommand()
            {
                Connection = Conn,
                CommandText = "pTestTableUpp",
                CommandType = CommandType.StoredProcedure
            };
            SqlCommandBuilder.DeriveParameters(DA.UpdateCommand);


            foreach (var o in CTLRObjects.Where(o => o.Upp))
                DA.UpdateCommand.Parameters[o.DBUppParamName].SourceColumn = o.DBTableField;

            Conn.Close();
            //            Conn.Open();


            //DV.RowFilter = "idreg = 1";



            




        }

        private void DoBind()
        {
            DependencyProperty dp = null;
            foreach (var obj in CTLRObjects)
            {
                if (obj.TheControl is TextBox)
                    dp = TextBox.TextProperty;
                obj.Bind(dp, CurrentView);
            }
        }

        private void DoUnBind()
        {
            foreach (var obj in CTLRObjects)
            {
                obj.UnBind();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.FindVisualChildren<TextBox>().ToList().ForEach(o =>
            {
                if (Validation.GetHasError(o))
                {
                    var _error = Validation.GetErrors(o).FirstOrDefault();
                    MessageBox.Show(string.Format("Error in box {0}: {1}", ((BindingExpression)_error.BindingInError).ResolvedSourcePropertyName, _error.ErrorContent));
                    o.Text = "";
                    return;
                }
            });
            DA.Update(DS);
        }


        private void CmdAddNew_Click(object sender, RoutedEventArgs e)
        {

            var row = CurrentView.AddNew();
            //CurrentView[0]["k"]
            //CurrentRow = row;
            DoBind();
            //DV.RowFilter = "Shown = true";

            //DV.RowStateFilter = DataViewRowState.Added;
        }
        //public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        //{
        //    if (depObj != null)
        //    {

        //        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        //        {
        //            DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
        //            if (child != null && child is T)
        //            {
        //                yield return (T)child;
        //            }

        //            foreach (T childOfChild in FindVisualChildren<T>(child))
        //            {
        //                yield return childOfChild;
        //            }
        //        }
        //    }
        //}

        private async void CmdPrev_Click(object sender, RoutedEventArgs e)
        {
            if (RecordIndex > 0)
            {
                if (CurrentRow.Row.RowState == DataRowState.Modified || CurrentRow.Row.RowState == DataRowState.Deleted)
                {
                    CurrentRow.Row.RejectChanges();

                }
                NumRecord--;
            } else
            {
                if (PageNumber > 1)
                {
                    DoUnBind();
                    var _n = NumRecord;
                    await GetPage(--PageNumber);
                    SearchResultsView = DT.DefaultView;
                    SearchResultsView.RowFilter = CurrentFilter;
                    CurrentView = SearchResultsView.ToTable().DefaultView;
                    NumRecord = _n - 1;
                    DoBind();
                }
            }

        }

        private async void CmdNext_Click(object sender, RoutedEventArgs e)
        {
            if (RecordIndex < RecordCount - 1)
            {
                if (CurrentRow.Row.RowState == DataRowState.Modified || CurrentRow.Row.RowState == DataRowState.Deleted)
                {
                    var _r = CurrentRow.Row;
                    _r.RejectChanges();
                    //_r["Shown"] = true;

                }
                NumRecord++;
            }
            else
            {
                if (PageNumber < NumPages)
                {
                    DoUnBind();
                    var _n = NumRecord;
                    await GetPage(++PageNumber);
                    SearchResultsView = DT.DefaultView;
                    SearchResultsView.RowFilter = CurrentFilter;
                    CurrentView = SearchResultsView.ToTable().DefaultView;
                    NumRecord = _n + 1;
                    DoBind();
                }
            }

        }

        private async void CmdSearch_Click(object sender, RoutedEventArgs e)
        {
            DoUnBind();
            if (DT == null)
            {
                await GetTotals();
                await GetPage(NumPages);
                //NumRecord = (long)DT.Rows[RecordCount - 1]["k"];
            }
            SearchResultsView = DT.DefaultView;
            string filter = "";
            //lets construct the filter
            foreach (var o in CTLRObjects.Where(o => o.Search == true))
            {
                string partial = "";
                if (SearchResultsView.Table.Columns[o.DBTableField].DataType.IsNumericType())
                    if (o.Value.ToString() != "")
                        //for numeric values
                        partial = string.Format("{0} = {1}", o.DBTableField, o.Value);
                    else break;
                else
                    //for string values
                    partial = string.Format("{0} like '%{1}%'", o.DBTableField, o.Value);
                filter += string.Format("{0}{1}", filter != "" ? " and " : "", partial);
            }
            CurrentFilter = filter;
            SearchResultsView.RowFilter = filter;
            CurrentView = SearchResultsView.ToTable().DefaultView;
            NumRecord = (long)DT.Rows[RecordCount - 1]["k"];
            DoBind();
        }

        private void CmdClear_Click(object sender, RoutedEventArgs e)
        {
            foreach (var o in CTLRObjects.Where(o => o.TheControl != null))
            {
                o.Clear();
            }
        }
    }


}
