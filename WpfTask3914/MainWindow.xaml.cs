using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using WpfTask3914.Model;
using WpfTask3914.ViewModel;

namespace WpfTask3914
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.lbStateCheck.DataContext = CheckFilesViewModel.Instance;
            this.lbStateResult.DataContext = CheckFilesViewModel.Instance;
            this.tbXmlCheckResult.DataContext = CheckFilesViewModel.Instance;
            this.tbIniCheckResult.DataContext = CheckFilesViewModel.Instance;
            this.tbJsonCheckResult.DataContext = CheckFilesViewModel.Instance;
            this.lbP1.DataContext = MainViewModel.Instance;
            this.lbP2.DataContext = MainViewModel.Instance;
            this.lbP3.DataContext = MainViewModel.Instance;
            
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            bool kq;

            kq = await CheckFilesViewModel.Instance.ReadAndCheckXmlFile();
            if (!kq)
            {
                CheckFilesViewModel.Instance.JudgeXml = "Xml file fail";
                CheckFilesViewModel.Instance.StateResult = "XML FILE FAIL!";
                CheckFilesViewModel.Instance.IsXmlCheckResult = false;
                await Task.Delay(200);

                Application.Current.Shutdown();
            }
            await Task.Delay(200);
            CheckFilesViewModel.Instance.StateResult = "Waiting...";
            kq = await CheckFilesViewModel.Instance.ReadAndCheckIniFile();
            if (!kq)
            {
                CheckFilesViewModel.Instance.JudgeIni = "Ini file fail";
                CheckFilesViewModel.Instance.StateResult = "INI FILE FAIL!";
                CheckFilesViewModel.Instance.IsIniCheckResult = false;

                await Task.Delay(200);
                Application.Current.Shutdown();
            }
            await Task.Delay(200);
            CheckFilesViewModel.Instance.StateResult = "Waiting...";
            kq = await CheckFilesViewModel.Instance.ReadAndCheckJsonFile();
            if (!kq)
            {
                CheckFilesViewModel.Instance.JudgeJson = "Json file fail";
                CheckFilesViewModel.Instance.StateResult = "JSON FILE FAIL!";
                CheckFilesViewModel.Instance.IsJsonCheckResult = false;

                await Task.Delay(200);
                Application.Current.Shutdown();
            }
            await Task.Delay(200);
            CheckFilesViewModel.Instance.StateResult = "CHECK FILE DONE!";
            MainViewModel.Instance.RunTask();

        }
    }
}
