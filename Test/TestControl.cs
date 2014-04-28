using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using BrightIdeasSoftware;
using Lib;

namespace Test
{
    public partial class TestControl : UserControl
    {
        Dictionary<string, Unit> themes;
        int[] answers;
        bool[] answerchoosed;
        Task currTask;
        Unit currUnit;
        int selectedTaskNum = 0;
        string course = "Дискретная математика";

        private void InitializeObjectListView()
        {
            // Initialize hot item style
            this.hotItemStyle1.ForeColor = activeFontColor;
            RowBorderDecoration rbd = new RowBorderDecoration();
            rbd.BorderPen = new Pen(activeBorderColor, 0.5f);
            rbd.FillBrush = new SolidBrush(Color.FromArgb(100, activeBackColor));
            rbd.CornerRounding = 0;
            rbd.BoundsPadding = new Size(0, 0);
            rbd.LeftColumn = 1;
            this.hotItemStyle1.Decoration = rbd;
            this.objectListView1.BackColor = this.backColor;
            this.objectListView1.ForeColor = this.fontColor;
            this.objectListView1.HighlightBackgroundColor = this.selectedBackColor;
            this.objectListView1.HighlightForegroundColor = this.selectedFontColor;
        }

        public TestControl()
        {
            InitializeComponent();
            InitializeObjectListView();
            try
            {
                tableWorkplace.Dock = DockStyle.Fill;
                tableTests.Dock = DockStyle.Fill;
                ImageList il = new ImageList();
                il.Images.Add("done", Test.Properties.Resources.Done);
                il.Images.Add("process", Test.Properties.Resources.Process);
                this.objectListView1.SmallImageList = il;
                InitializeTests();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void InitializeTests()
        {
            var names = Directory.GetFiles("Tests", "*.htm*");
            Array.Sort(names);

            themes = new Dictionary<string, Unit>();
            foreach (var name in names)
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(name);
                string title = doc.DocumentNode.SelectSingleNode("//head/title").InnerText;
                Unit unit = new Unit(name, doc);
                themes.Add(title, unit);
                lbTests.Items.Add(title);
            }
        }

        private void objectListView1_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
                e.SubItem.ForeColor = fontColor;
        }

        private void lbTests_SelectedIndexChanged(object sender, EventArgs e)
        {
            tableWorkplace.Visible = true;
            tableTests.Visible = false;
            //webBrowser1.Document.Body.InnerHtml = "<h1>Идёт загрузка</h1>";

            try
            {
                currUnit = themes[(string)lbTests.SelectedItem];
                currUnit.Reshuffle();
                webBrowser1.Visible = false;
                webBrowser1.Url = currUnit.uri;
                webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
            }
            catch { }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Unit currUnit = themes[(string)lbTests.SelectedItem];
            webBrowser1.Document.Body.InnerText = "Идёт загрузка";
            webBrowser1.Visible = true;

            answers = new int[currUnit.tasks.Count];
            answerchoosed = new bool[currUnit.tasks.Count];

            SelectTask(0);

            this.objectListView1.SetObjects(currUnit.tasks);
        }

        private string GetImageKey(object obj)
        {
            int num = int.Parse(((Task)obj).TaskNumber) - 1;
            if (selectedTaskNum == num)
                return "process";
            if (answerchoosed[num])
                return "done";
            return "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (rlbAnswers.SelectedIndices.Count == 0)
                return;

            int taskNum = selectedTaskNum;

            int answNum = rlbAnswers.SelectedIndex;
            answers[taskNum] = answNum;
            answerchoosed[taskNum] = true;

            if (taskNum + 1 < currUnit.tasks.Count)
                SelectTask(taskNum + 1);
        }

        private void SelectTask(int p)
        {
            selectedTaskNum = p;
            this.objectListView1.RefreshObject(currTask);

            currTask = currUnit.tasks[p];
            this.objectListView1.RefreshObject(currTask);
            rlbAnswers.Items.Clear();
            for (int i = 1; i <= currTask.answers.Count; i++)
            {
                rlbAnswers.Items.Add(i.ToString());
            }
            webBrowser1.Document.Body.InnerHtml = currTask.html;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableTests.Visible = true;
            tableWorkplace.Visible = false;
            var sdb = new Lib.StudentsDB();
            sdb.insert_answers(answers, answerchoosed, course);

        }

        private void TestControl_FontChanged(object sender, EventArgs e)
        {
            rlbAnswers.Font = this.Font;
        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.objectListView1.SelectedIndices.Count != 0)
            {
                selectedTaskNum = this.objectListView1.SelectedIndices[0];
                SelectTask(this.objectListView1.SelectedIndices[0]);
            }
        }
    }
}
