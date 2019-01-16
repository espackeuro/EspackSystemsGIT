using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TEST2.Model;
using TEST2.ViewModel;
using MvvmFoundation.Wpf;

namespace TEST2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static TestModel testModel = new TestModel();
        public static TestModel TestModel { get { return testModel; } }
        internal static Messenger Messenger
        {
            get { return _messenger; }
        }
        
        readonly static Messenger _messenger = new Messenger();
        //private static RecordSelectionModel rsm = new RecordSelectionModel();

    }
}
