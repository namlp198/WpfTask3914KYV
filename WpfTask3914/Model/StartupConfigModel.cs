using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfTask3914.ViewModel;

namespace WpfTask3914.Model
{
    [XmlRoot(ElementName = "ProcessNames")]
    public class ProcessNames
    {
        [XmlElement(ElementName = "P1")]
        public string P1 { get; set; }
        [XmlElement(ElementName = "P2")]
        public string P2 { get; set; }
        [XmlElement(ElementName = "P3")]
        public string P3 { get; set; }
    }

    [XmlRoot(ElementName = "Paths")]
    public class Paths
    {
        [XmlElement(ElementName = "PathP1")]
        public string PathP1 { get; set; }
        [XmlElement(ElementName = "PathP2")]
        public string PathP2 { get; set; }
        [XmlElement(ElementName = "PathP3")]
        public string PathP3 { get; set; }
    }

    [XmlRoot(ElementName = "XmlFile")]
    public class XmlFile
    {
        [XmlElement(ElementName = "FileName")]
        public string FileName { get; set; }
        [XmlElement(ElementName = "ItemCheck")]
        public List<string> ItemCheck { get; set; }
    }

    [XmlRoot(ElementName = "XmlFiles")]
    public class XmlFiles
    {
        [XmlElement(ElementName = "XmlFile")]
        public List<XmlFile> XmlFile { get; set; }
    }

    [XmlRoot(ElementName = "IniFile")]
    public class IniFile
    {
        [XmlElement(ElementName = "FileName")]
        public string FileName { get; set; }
        [XmlElement(ElementName = "ItemCheck")]
        public List<string> ItemCheck { get; set; }
    }

    [XmlRoot(ElementName = "IniFiles")]
    public class IniFiles
    {
        [XmlElement(ElementName = "IniFile")]
        public List<IniFile> IniFile { get; set; }
    }

    [XmlRoot(ElementName = "JsonFile")]
    public class JsonFile
    {
        [XmlElement(ElementName = "FileName")]
        public string FileName { get; set; }
        [XmlElement(ElementName = "ItemCheck")]
        public List<string> ItemCheck { get; set; }
    }

    [XmlRoot(ElementName = "JsonFiles")]
    public class JsonFiles
    {
        [XmlElement(ElementName = "JsonFile")]
        public List<JsonFile> JsonFile { get; set; }
    }

    [XmlRoot(ElementName = "Files")]
    public class Files
    {
        [XmlElement(ElementName = "XmlFiles")]
        public XmlFiles XmlFiles { get; set; }
        [XmlElement(ElementName = "IniFiles")]
        public IniFiles IniFiles { get; set; }
        [XmlElement(ElementName = "JsonFiles")]
        public JsonFiles JsonFiles { get; set; }
    }

    [XmlRoot(ElementName = "ActionSt")]
    public class ActionSt
    {
        [XmlElement(ElementName = "Run")]
        public string Run { get; set; }
        [XmlElement(ElementName = "Kill")]
        public string Kill { get; set; }
        [XmlElement(ElementName = "Show")]
        public string Show { get; set; }
        [XmlElement(ElementName = "EndProgram")]
        public string EndProgram { get; set; }
    }

    [XmlRoot(ElementName = "State")]
    public class State
    {
        [XmlElement(ElementName = "St")]
        public string St { get; set; }
        [XmlElement(ElementName = "ActionSt")]
        public ActionSt ActionSt { get; set; }
    }

    [XmlRoot(ElementName = "States")]
    public class States
    {
        [XmlElement(ElementName = "State")]
        public List<State> State { get; set; }
    }

    [XmlRoot(ElementName = "StartupConfig")]
    public class StartupConfig
    {
        [XmlElement(ElementName = "ProcessNames")]
        public ProcessNames ProcessNames { get; set; }
        [XmlElement(ElementName = "Paths")]
        public Paths Paths { get; set; }
        [XmlElement(ElementName = "Files")]
        public Files Files { get; set; }
        [XmlElement(ElementName = "States")]
        public States States { get; set; }
    }
}

