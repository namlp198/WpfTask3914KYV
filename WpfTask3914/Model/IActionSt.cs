using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTask3914.Model
{
    interface IActionSt
    {
        bool RunP(params string[] para);
        bool KillP(params string[] para);
        void ShowP(string msg);
    }
}
