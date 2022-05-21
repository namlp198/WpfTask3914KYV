using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfTask3914.Common
{
    public class InitFileManipulation
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defaut, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        static extern uint GetPrivateProfileSectionNames(IntPtr pszReturnBuffer, uint nSize, string lpFileName);

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpszReturnBuffer, int nSize, string lpFileName);


        /// <summary>
        /// Write Data to the INI File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// Section name
        /// <PARAM name="Key"></PARAM>
        /// Key Name
        /// <PARAM name="Value"></PARAM>
        /// Value Name
        public static void IniWriteValue(string Section, string Key, string Value, string filePath)
        {
            WritePrivateProfileString(Section, Key, Value, filePath);
        }

        /// <summary>
        /// Read Data Value From the Ini File
        /// </summary>
        /// <PARAM name="Section"></PARAM>
        /// <PARAM name="Key"></PARAM>
        /// <PARAM name="Path"></PARAM>
        /// <returns></returns>
        public static string IniReadValue(string Section, string Key, string filePath)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, filePath);
            return temp.ToString();

        }


        /// <summary>
        /// Lay tat ca cac section trong ini file
        /// </summary>
        /// <returns></returns>
        private static string[] SectionNames(string filePath)
        {
            try
            {
                uint MAX_BUFFER = 32767;
                IntPtr pReturnedString = Marshal.AllocCoTaskMem((int)MAX_BUFFER);
                uint bytesReturned = GetPrivateProfileSectionNames(pReturnedString, MAX_BUFFER, filePath);
                if (bytesReturned == 0)
                    return null;
                string local = Marshal.PtrToStringAnsi(pReturnedString, (int)bytesReturned).ToString();
                Marshal.FreeCoTaskMem(pReturnedString);
                //use of Substring below removes terminating null for split
                return local.Substring(0, local.Length - 1).Split('\0');
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
        public static string[] GetSectionNames(string filePath)
        {
            return SectionNames(filePath);
        }

        /// <summary>
        /// Lay key-value theo section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        private static Dictionary<string, string> GetKeys(string section, string filePath)
        {
            byte[] buffer = new byte[2048];

            GetPrivateProfileSection(section, buffer, 2048, filePath);
            string[] tmp = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');

            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (String entry in tmp)
            {
                string key = entry.Substring(0, entry.IndexOf("="));
                string value = entry.Substring(entry.IndexOf("=") + 1, entry.Length - 1 - entry.IndexOf("="));
                result.Add(key, value);
            }

            return result;
        }
        public static Dictionary<string, string> GetKeysWithSection(string section, string filePath)
        {
            return GetKeys(section, filePath);
        }

        /// <summary>
        /// Lay tat ca key-value theo mang section truyen vao
        /// </summary>
        /// <returns></returns>
        private static List<Dictionary<string, string>> GetAllKeys(string filePath)
        {
            byte[] buffer = new byte[4096];
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            string[] temp = SectionNames(filePath); // Lay tat ca cac section trong ini file
            try
            {
                for (int i = 0; i < temp.Length; i++)
                {
                    GetPrivateProfileSection(temp[i], buffer, 4096, filePath);
                    string[] tmp = Encoding.ASCII.GetString(buffer).Trim('\0').Split('\0');
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    foreach (string entry in tmp)
                    {
                        string key = entry.Substring(0, entry.IndexOf("="));
                        string value = entry.Substring(entry.IndexOf("=") + 1, entry.Length - 1 - entry.IndexOf("="));
                        dic.Add(key, value);
                    }
                    result.Add(dic);
                    Array.Clear(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return result;
        }
        public static List<Dictionary<string, string>> GetAllKeysWithAllSection(string filePath)
        {
            return GetAllKeys(filePath);
        }
    }
}
