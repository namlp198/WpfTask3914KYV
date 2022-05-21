using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WpfTask3914.Common;
using WpfTask3914.Model;

namespace WpfTask3914.ViewModel
{
    public class CheckFilesViewModel : BaseViewModel
    {
        #region Constructor
        private CheckFilesViewModel()
        {
            LoadListFiles();
        }

        #region Singleton
        private static readonly CheckFilesViewModel _instance = new CheckFilesViewModel();
        public static CheckFilesViewModel Instance
        {
            get { return _instance; }
            private set { }
        }
        #endregion

        #endregion
        #region Propertys
        //List XmlFile
        private List<XmlFile> _listXmlFile;
        public List<XmlFile> ListXmlFile
        {
            get { return _listXmlFile; }
            set { _listXmlFile = value; }
        }

        //List IniFile
        private List<IniFile> _listIniFile;
        public List<IniFile> ListIniFile
        {
            get { return _listIniFile; }
            set { _listIniFile = value; }
        }

        //List JsonFile
        private List<JsonFile> _listJsonFile;
        public List<JsonFile> ListJsonFile
        {
            get { return _listJsonFile; }
            set { _listJsonFile = value; }
        }

        private string _stateCheck = "Checking";
        public string StateCheck
        {
            get { return _stateCheck; }
            set
            {
                _stateCheck = value;
                OnPropertyChanged("StateCheck");
            }
        }
        private string _stateResult = "Waiting...";
        public string StateResult
        {
            get { return _stateResult; }
            set
            {
                _stateResult = value;
                OnPropertyChanged(nameof(StateResult));
            }
        }

        //result check xml file
        private bool _isXmlCheckResult;
        public bool IsXmlCheckResult
        {
            get { return _isXmlCheckResult; }
            set
            {
                _isXmlCheckResult = value;
                OnPropertyChanged(nameof(IsXmlCheckResult));
            }
        }
        //result check ini file
        private bool _isIniCheckResult;
        public bool IsIniCheckResult
        {
            get { return _isIniCheckResult; }
            set
            {
                _isIniCheckResult = value;
                OnPropertyChanged(nameof(IsIniCheckResult));
            }
        }
        //result check json file
        private bool _isJsonCheckResult;
        public bool IsJsonCheckResult
        {
            get { return _isJsonCheckResult; }
            set
            {
                _isJsonCheckResult = value;
                OnPropertyChanged(nameof(IsJsonCheckResult));
            }
        }
        private string _judgeXml;
        public string JudgeXml
        {
            get { return _judgeXml; }
            set { _judgeXml = value; OnPropertyChanged(nameof(JudgeXml)); }
        }
        private string _judgeIni;
        public string JudgeIni
        {
            get { return _judgeIni; }
            set { _judgeIni = value; OnPropertyChanged(nameof(JudgeIni)); }
        }
        private string _judgeJson;
        public string JudgeJson
        {
            get { return _judgeJson; }
            set { _judgeJson = value; OnPropertyChanged(nameof(JudgeJson)); }
        }
        #endregion

        #region Methods
        private void LoadListFiles()
        {
            _listXmlFile = StartupConfigViewModel.Instance.StartupConfig.Files.XmlFiles.XmlFile;
            _listIniFile = StartupConfigViewModel.Instance.StartupConfig.Files.IniFiles.IniFile;
            _listJsonFile = StartupConfigViewModel.Instance.StartupConfig.Files.JsonFiles.JsonFile;
        }
        public async Task<bool> ReadAndCheckXmlFile()
        {
            StateCheck = "CHECKING XML FILE...";
            if (_listXmlFile == null)
                return false;
            else
            {
                foreach (var xmlfile in _listXmlFile)
                {
                    if (File.Exists(xmlfile.FileName))
                    {
                        try
                        {
                            XmlDocument xmldoc = new XmlDocument();
                            xmldoc.Load(@"C:\Kohyoung\NEPTUNE\test.xml");
                            XmlElement root = xmldoc.DocumentElement;
                            XmlNodeList nodelist = root.ChildNodes;
                            XmlNodeList temp = nodelist;

                            goto_1:
                            foreach (XmlNode node in nodelist)
                            {
                                if (node.NodeType != XmlNodeType.Comment)
                                {
                                    if (node.ChildNodes.Count > 1)
                                    {
                                        nodelist = node.ChildNodes;
                                        goto goto_1;
                                    }
                                    XmlAttributeCollection xmlnodelistAtri = node.Attributes;
                                goto_2:
                                    foreach (XmlNode item in xmlnodelistAtri)
                                    {
                                        if (item.Attributes != null)
                                        {
                                            xmlnodelistAtri = item.Attributes;
                                            goto goto_2;
                                        }
                                        foreach (string it in xmlfile.ItemCheck)
                                        {
                                            if (item.Value == it)
                                            {
                                                MessageBox.Show("OK");
                                            }
                                        }
                                    }
                                }
                            }
                            //using (var rd = new StreamReader(xmlfile.FileName))
                            //{
                            //    string s = rd.ReadToEnd();

                            //    if (string.IsNullOrEmpty(s))
                            //    {
                            //        MessageBox.Show($"Xml File Empty", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                            //        return false;
                            //    }

                            //    foreach (var item in xmlfile.ItemCheck)
                            //    {
                            //        if (!s.Contains(item))
                            //        {
                            //            MessageBox.Show($"Xml file fail! No has parameter {item}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            //            return false;
                            //        }

                            //    }

                            //}
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }

#if DEBUG == false
                        try
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(xmlfile.FileName);
                            XmlElement root = doc.DocumentElement;
                            XmlNodeList childNodeList = root.ChildNodes;
                            XmlNodeList tempList = childNodeList;
                            int temp = 0;
                            int count = 0;
                            int index = 0;
                            bool flag = false;
                            for (int i = 0; i < childNodeList.Count; i++)
                            {
                                if (childNodeList[i].NodeType != XmlNodeType.Comment)
                                {
                                    if (childNodeList[i].ChildNodes.Count > 1)
                                    {
                                        count = childNodeList[i].ChildNodes.Count;
                                        childNodeList = childNodeList[i].ChildNodes;
                                        if (!flag)
                                            temp = i;
                                        flag = true;
                                        i = -1;
                                    }
                                    else if (childNodeList[i].ChildNodes.Count == 0)
                                    {
                                        MessageBox.Show($"{childNodeList[i].Name} no has value", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        index++;
                                    }
                                }
                                if (i == count - 1)
                                {
                                    i = temp;
                                    childNodeList = tempList;
                                    flag = !flag;
                                    count = 0;
                                }
                            }
                            if (index > 0)
                            {
                                MessageBox.Show($"Total: {index} parameter no has value", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                            
                        }
                        
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Can not read xml file!\n{ex.Message}", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
#endif
                    }
                    else
                    {
                        MessageBox.Show(xmlfile + " no exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                await Task.Delay(100);
                IsXmlCheckResult = true;
                StateResult = "XML FILE GOOD!";
                JudgeXml = "Xml file good";
                return true;

            }
        }
        public async Task<bool> ReadAndCheckIniFile()
        {
            StateCheck = "CHECKING INI FILE...";
            if (_listIniFile == null)
                return false;
            foreach (var inifile in _listIniFile)
            {
                if (File.Exists(inifile.FileName))
                {
                    try
                    {
                        using (var reader = new StreamReader(inifile.FileName))
                        {
                            string s = reader.ReadToEnd();
                            if(string.IsNullOrEmpty(s))
                            {
                                MessageBox.Show($"Ini File Empty", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                            foreach (var item in inifile.ItemCheck)
                            {
                                if(!s.Contains(item))
                                {
                                    MessageBox.Show($"Ini file fail! No has parameter {item}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return false;
                                }
                            }
                        }

#if DEBUG == false
                        var lstDic = InitFileManipulation.GetAllKeysWithAllSection(inifile.FileName);
                        if (lstDic.Count > 0)
                        {
                            int index = 0;
                            foreach (var dic in lstDic)
                            {
                                foreach (KeyValuePair<string, string> kvp in dic)
                                {
                                    if (string.IsNullOrEmpty(kvp.Value))
                                    {
                                        index++;
                                        MessageBox.Show($"{kvp.Key} no has value", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    }
                                }
                            }
                            if (index > 0)
                            {
                                MessageBox.Show($"Total: {index} parameter no has value", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Ini File Empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
#endif
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(inifile + " no exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            await Task.Delay(100);
            StateResult = "INI FILE GOOD!";
            JudgeIni = "Ini file good";
            IsIniCheckResult = true;
            return true;
        }
        public async Task<bool> ReadAndCheckJsonFile()
        {
            StateCheck = "CHECKING JSON FILE...";
            if (_listJsonFile == null)
                return false;
            foreach (var jsonfile in _listJsonFile)
            {
                if (File.Exists(jsonfile.FileName))
                {
                    try
                    {
                        using (var reader = new StreamReader(jsonfile.FileName))
                        {
                            string s = reader.ReadToEnd();
                            if(string.IsNullOrEmpty(s))
                            {
                                MessageBox.Show($"Json File Empty", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                                return false;
                            }
                            foreach (var item in jsonfile.ItemCheck)
                            {
                                if(!s.Contains(item))
                                {
                                    MessageBox.Show($"Json file fail! No has parameter {item}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return false;
                                }
                            }
                        }
#if DEBUG == false
                        //@"C:\Kohyoung\CCI\Vision\test.json"
                        using (StreamReader file = File.OpenText(jsonfile.FileName))
                        using (JsonTextReader reader = new JsonTextReader(file))
                        {
                            JObject jobj = (JObject)JToken.ReadFrom(reader);
                            int index = 0;
                            if (jobj != null)
                            {
                                foreach (var kvp in jobj)
                                {
                                    var jtoken = kvp.Value.Values();
                                    goto_child:
                                    foreach (var item in jtoken)
                                    {
                                        if(item.Children().Values().Count() >= 1)
                                        {
                                            jtoken = item;
                                            goto goto_child;
                                        }
                                        if(item.Type == JTokenType.Undefined)
                                        {
                                            index++;
                                            MessageBox.Show($"{item.Parent} : parameter no has value", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        }
                                    }
                                }
                                if(index > 0)
                                {
                                    MessageBox.Show($"Total: {index} parameter no has value", "error", MessageBoxButton.OK, MessageBoxImage.Error);
                                    return false;
                                }
                            }
                        }
#endif
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show(jsonfile + " no exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            await Task.Delay(100);
            StateResult = "JSON FILE GOOD!";
            JudgeJson = "Json file good";
            IsJsonCheckResult = true;
            return true;
        }
#endregion
    }
}
