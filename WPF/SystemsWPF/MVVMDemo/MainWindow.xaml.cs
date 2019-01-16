using System.Windows;

namespace MVVMDemo
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StudentViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            MVVMDemo.ViewModel.StudentViewModel studentViewModelObject =
               new MVVMDemo.ViewModel.StudentViewModel();
            //studentViewModelObject.LoadStudents();

            //StudentViewControl.DataContext = studentViewModelObject;
        }
    }
}