using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;
using WpfTask3914.Model;

namespace WpfTask3914.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Constructor
        private MainViewModel()
        {

        }
        #endregion
        #region Singleton
        private static readonly MainViewModel _instance = new MainViewModel();
        public static MainViewModel Instance
        {
            private set { }
            get { return _instance; }
        }
        #endregion

        #region Property
        private string _preState ="";
        public string PreState
        {
            get { return _preState; }
            set { _preState = value; }
        }
        private string _stP1 = "P1";
        public string StP1
        {
            get { return _stP1; }
            set
            {
                _stP1 = value;
                OnPropertyChanged("StP1");
            }
        }
        private string _stP2 = "P2";
        public string StP2
        {
            get { return _stP2; }
            set
            {
                _stP2 = value;
                OnPropertyChanged("StP2");
            }
        }
        private string _stP3 = "P3";
        public string StP3
        {
            get { return _stP3; }
            set
            {
                _stP3 = value;
                OnPropertyChanged("StP3");
            }
        }
        #endregion
        #region Methods
        public bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        public StartupConfig DeserializeXML()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(StartupConfig));
                using (var reader = new StreamReader(@"C:\Kohyoung\StartupConfig\StartupConfig.xml"))
                {
                    var config = (StartupConfig)serializer.Deserialize(reader);
                    return config;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            #endregion
        }
        public string IsState()
        {
            string state = string.Empty;
            Process[] P1 = Process.GetProcessesByName(StartupConfigViewModel.Instance.StartupConfig.ProcessNames.P1);
            Process[] P2 = Process.GetProcessesByName(StartupConfigViewModel.Instance.StartupConfig.ProcessNames.P2);
            Process[] P3 = Process.GetProcessesByName(StartupConfigViewModel.Instance.StartupConfig.ProcessNames.P3);

            if (P1.Length > 0)
            {
                state += "T";
                StP1 = $"{StartupConfigViewModel.Instance.StartupConfig.ProcessNames.P1} running";
            }
            else
            {
                state += "F";
                StP1 = $"P1";
            }
            if (P2.Length > 0)
            {
                state += "T";
                StP2 = $"{StartupConfigViewModel.Instance.StartupConfig.ProcessNames.P2} running";
            }
            else
            {
                state += "F";
                StP2 = $"P2";
            }
            if (P3.Length > 0)
            {
                state += "T";
                StP3 = $"{StartupConfigViewModel.Instance.StartupConfig.ProcessNames.P3} running";
            }
            else
            {
                state += "F";
                StP3 = $"P3";
            }
            //if (!_preState.Equals(state))
            //    _preState = state;
            Thread.Sleep(100);
            return state;
        }
        public void RunTask()
        {
            CheckFilesViewModel.Instance.StateCheck = "CHECKING PROCESS...";
            Task task = new Task(new Action(() =>
            {
                while (true)
                {
                    string st =IsState();
                    StartupConfigViewModel.Instance.CmdAction(st);
                    Thread.Sleep(200);
                }
            }));
            task.Start();
        }
    }
}
