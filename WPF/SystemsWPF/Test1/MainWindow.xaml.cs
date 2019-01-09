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
        public SqlDataAdapter DA { get; set; }
        public int RecordCount { get => DT.Rows.Count; }
        public Collection<CTLRObject> CTLRObjects { get; set; } = new Collection<CTLRObject>();



        public DataRow CurrentRow
        {
            get => DT.Rows.OfType<DataRow>().FirstOrDefault(o => (bool)(o["Shown"] is Boolean ? o["Shown"] : false) == true);
        }
        public int RecordIndex
        {
            get
            {
                return DT.Rows.IndexOf(CurrentRow);
            }
            set
            {
                var _i = RecordIndex;
                DT.Rows[value]["Shown"] = true;
                DT.Rows[_i]["Shown"] = false;
                CurrentRow.AcceptChanges();
            }
        }



        public MainWindow()
        {
            InitializeComponent();
            DS = new DataSet();
            DA = new SqlDataAdapter();

            CTLRObjects.Add(new CTLRObject(txtIdReg, "idreg", add: true, upp: true, del: true, search: true));
            CTLRObjects.Add(new CTLRObject(txtElCampo1, "elCampo1", add: true, upp: true, search: true));
            CTLRObjects.Add(new CTLRObject(txtElCampo2, "elCampo2", add: true, upp: true, search: true));


            var Conn = new SqlConnection("Data Source=DB01;Initial Catalog=TEST;Integrated Security=True");
            DA.SelectCommand = new SqlCommand()
            {
                Connection = Conn,
                CommandText = "Select * from TestTable",
                CommandType = CommandType.Text
            };
            DA.Fill(DS);
            DT = DS.Tables[0];
            DT.Columns.Add(new DataColumn() { ColumnName = "Shown", DataType = System.Type.GetType("System.Boolean") });
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



            CurrentView = DT.DefaultView;




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

        private void cleanShown()
        {
            CurrentView[0]["Shown"] = false;
        }

        private void CmdAddNew_Click(object sender, RoutedEventArgs e)
        {

            var row = CurrentView.AddNew();
            row["Shown"] = true;
            row.EndEdit();
            var row0 = CurrentView[0];
            row0["Shown"] = false;
            row0.EndEdit();
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

        private void CmdPrev_Click(object sender, RoutedEventArgs e)
        {
            if (RecordIndex > 0)
            {
                if (CurrentRow.RowState == DataRowState.Modified || CurrentRow.RowState == DataRowState.Deleted)
                {
                    CurrentRow.RejectChanges();

                }
                RecordIndex--;
            }

        }

        private void CmdNext_Click(object sender, RoutedEventArgs e)
        {
            if (RecordIndex < RecordCount - 1)
            {
                if (CurrentRow.RowState == DataRowState.Modified || CurrentRow.RowState == DataRowState.Deleted)
                {
                    var _r = CurrentRow;
                    _r.RejectChanges();
                    //_r["Shown"] = true;

                }
                RecordIndex++;
            }

        }

        private void CmdSearch_Click(object sender, RoutedEventArgs e)
        {
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
            SearchResultsView.RowFilter = filter;

            //clear all shown records
            foreach (var r in SearchResultsView.ToTable().Rows.OfType<DataRow>().Where(r => (bool)(r["Shown"] is Boolean ? r["Shown"] : false) == true))
                r["Shown"] = false;
            //set shown to the first record of the search results
            if (SearchResultsView.Count != 0)
            {
                SearchResultsView[0]["Shown"] = true;
                CurrentView.RowFilter = "Shown = true";
                CurrentRow.AcceptChanges();
                //DoBind();
            }
            DoBind();
        }

        private void CmdClear_Click(object sender, RoutedEventArgs e)
        {
            cleanShown();
            foreach (var o in CTLRObjects.Where(o => o.TheControl != null))
            {
                o.Clear();
            }
        }
    }


}
