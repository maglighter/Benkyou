using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Lib;

namespace Benkyou
{
    public partial class Form1 : Form
    {
        List<IPlugin> plugins;
        public Form1()
        {
            InitializeComponent();
            InitializePlugins();
        }

        private void InitializePlugins()
        {
            LoadPlugins();
            StartPlugins();
        }

        private void StartPlugins()
        {
            this.tcWorkSpace.SuspendLayout();
            this.SuspendLayout();
            foreach (var plugin in plugins)
            {
                var page = new TabPage(plugin.name);
                plugin.control.Dock = DockStyle.Fill;
                page.Controls.Add(plugin.control);
                tcWorkSpace.Controls.Add(page);
            }
            this.tcWorkSpace.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private void LoadPlugins()
        {
            string folder = "Plugins";
            plugins = new List<IPlugin>();

            try
            {
                foreach (var name in Directory.GetFiles(folder))
                {
                    var asm = Assembly.LoadFrom(name);
                    foreach (var type in asm.GetExportedTypes())
                    {
                        if (typeof(IPlugin).IsAssignableFrom(type))
                            plugins.Add((IPlugin)Activator.CreateInstance(type));
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                Close();
            }
        }
    }
}
