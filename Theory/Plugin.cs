using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Lib;

namespace Theory
{
    public class Plugin : IPlugin
    {
        public string name
        {
            get
            {
                return "Теория";
            }
        }
        private TheoryControl theoryControl;
        public UserControl control
        {
            get
            {
                return theoryControl;
            }
        }

        public Plugin()
        {
            theoryControl = new TheoryControl();
        }
    }
}
