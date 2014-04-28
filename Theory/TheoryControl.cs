using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Lib;

namespace Theory
{
    public partial class TheoryControl : UserControl
    {
        Dictionary<string, Uri> themes;

        public TheoryControl()
        {
            InitializeComponent();
            InitializeThemes();
        }

        private void InitializeThemes()
        {
            var names = Directory.GetFiles("Themes", "*.htm*");
            Array.Sort(names);

            themes = new Dictionary<string, Uri>();
            foreach (var name in names)
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(name);
                string title = doc.DocumentNode.SelectSingleNode("//head/title").InnerText;
                string curDir = Directory.GetCurrentDirectory();
                Uri uri = new Uri(String.Format("file:///{0}/{1}", curDir, name));
                themes.Add(title, uri);
                lbThemes.Items.Add(title);
            }
        }

        private void lbThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.webBrowser1.Url = themes[(string)lbThemes.SelectedItem];
        }
    }
}
