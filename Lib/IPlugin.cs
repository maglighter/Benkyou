using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Lib
{
    public interface IPlugin
    {
        string name { get; }
        UserControl control { get; }
    }
}
