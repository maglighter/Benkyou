using System;
using System.Collections.Generic;
using System.Text;
using Lib;
using System.Windows.Forms;

namespace Test
{
    public class Plugin : IPlugin
    {
        public string name
        {
            get
            {
                return "Тесты";
            }
        }

        private TestControl testControl = new TestControl();
        public UserControl control
        {
            get
            {
                return testControl;
            }
        }
    }
}
