using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WpfTask3914.Model;

namespace WpfTask3914.ViewModel
{
    public class StartupConfigViewModel : BaseViewModel
    {
        #region Constructor
        private StartupConfigViewModel()
        {
            StartupConfig = MainViewModel.Instance.DeserializeXML();
        }
        #endregion

        #region Singleton
        private static readonly StartupConfigViewModel _instance = new StartupConfigViewModel();
        public static StartupConfigViewModel Instance
        {
            get { return _instance; }
            private set { }
        }
        #endregion
        #region Property
        private StartupConfig _startupConfig;
        public StartupConfig StartupConfig
        {
            get { return _startupConfig; }
            set { _startupConfig = value; }
        }
        private List<Dictionary<string, string>> _lstdicStateActionSt;
        public List<Dictionary<string, string>> LstStateActionSt
        {
            get { return _lstdicStateActionSt; }
            set { _lstdicStateActionSt = value; }
        }
        #endregion

        #region Methods

        public bool CmdAction(string st)
        {

            var lstState = StartupConfig.States.State;
            foreach (var state in lstState)
            {
                if (state.St == st)
                {
                    DoActionSt(st, state.ActionSt);
                    break;
                }
            }
            return true;
        }

        private void DoActionSt(string st, ActionSt action)
        {
            try
            {
                if (!string.IsNullOrEmpty(action.Run))
                {
                    switch (action.Run)
                    {
                        case "P1":
                            RunPrc(StartupConfig.Paths.PathP1);
                            break;
                        case "P2":
                            RunPrc(StartupConfig.Paths.PathP2);
                            break;
                        case "P3":
                            RunPrc(StartupConfig.Paths.PathP3);
                            break;
                        default:
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(action.Kill))
                {
                    switch (action.Kill)
                    {
                        case "P1":
                            KillPrc(StartupConfig.ProcessNames.P1);
                            break;
                        case "P2":
                            KillPrc(StartupConfig.ProcessNames.P2);
                            break;
                        case "P3":
                            KillPrc(StartupConfig.ProcessNames.P3);
                            break;
                        default:
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(action.Show))
                {
                    if (!st.Equals(MainViewModel.Instance.PreState))
                    {
                        MainViewModel.Instance.PreState = st;
                        ShowMsg(action.Show);
                    }
                }
                if (!string.IsNullOrEmpty(action.EndProgram))
                {
                    if (action.EndProgram.Equals("End"))
                    {
                        Application.Current.Dispatcher.Invoke(() =>
                        {
                            Application.Current.Shutdown();
                        });
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowMsg(string subName)
        {
            MessageBox.Show(subName, "Notify", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void KillPrc(string prc)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(prc);
                foreach (Process process in processes)
                {
                    process.Kill();
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Thread.Sleep(10);
        }

        private void RunPrc(string path)
        {
            try
            {
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.Verb = "runas";
                proc.StartInfo.FileName = path;
                proc.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Thread.Sleep(10);
        }
        #endregion
    }
}
