using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LiveSwitch.TextControl
{
    public partial class TestManager : Form
    {
        TestCollection list;
        public string selectedItem;
        public TestManager.DialogRezult rezult = DialogRezult.None;
        private string oldName;
        private bool IsNewItem = false;

        public enum DialogRezult
        {
            Select,
            Cancel,
            Open,
            None
        }

        public TestManager(TestCollection list)
        {
            InitList(list);
            tableLayoutPanel1.Visible = false;
            listBox1.Dock = DockStyle.Fill;
            переборToolStripMenuItem.Visible = false;
            выбратьToolStripMenuItem.Visible = false;
            textBox1.Visible = false;
        }

        public TestManager(TestCollection list, string name)
        {
            InitList(list);
            this.button1.Text = name;
            this.Text = name;
        }

        private void InitList(TestCollection list)
        {
            InitializeComponent();
            this.list = list;
            this.selectedItem = null;

            foreach (string item in list)
            {
                this.listBox1.Items.Add(item);
            }

            //if (listBox1.Items.Count > 0)
            //    listBox1.se = 0;
        }

        private void Save()
        {
            selectedItem = textBox1.Text.Trim();
        }

        private void SaveAndClose()
        {
            Save();
            Close();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            this.rezult = TestManager.DialogRezult.Select;
            SaveAndClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.rezult = TestManager.DialogRezult.Select;
            SaveAndClose();
        }

        private void TestManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.rezult == TestManager.DialogRezult.None)
                this.rezult = TestManager.DialogRezult.Cancel;
            Save();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count > 0)
                textBox1.Text = listBox1.SelectedItems[0].Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.rezult = TestManager.DialogRezult.Cancel;
            Close();
        }

        private void выбратьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.rezult = TestManager.DialogRezult.Select;
            SaveAndClose();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                this.rezult = TestManager.DialogRezult.Open;
                SaveAndClose();
            }
        }

        private void добавитьНовыйТестToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IsNewItem = true;
            var newItem = new ListViewItem(list.CreateThemeName());
            listBox1.Items.Add(newItem);
            newItem.BeginEdit();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count > 0)
            {
                list.Remove((string)listBox1.SelectedItems[0].Text);
                listBox1.Items.Remove(listBox1.SelectedItems[0]);
            }
        }

        private void переименоватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                listBox1.SelectedItems[0].BeginEdit();
            }
        }

        private void listBox1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (IsNewItem)
            {
                if (e.Label != null)
                    list.Add(e.Label);
                else
                    list.Add(oldName);
            }
            else
            {
                if (e.Label != null)
                    list.Rename(oldName, e.Label);
            }
            IsNewItem = false;
        }

        private void listBox1_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            oldName = listBox1.Items[e.Item].Text;
        }
    }
}
