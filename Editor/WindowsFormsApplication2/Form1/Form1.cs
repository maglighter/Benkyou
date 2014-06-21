using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LiveSwitch.TextControl
{
    public partial class Form1 : Form
    {
        private TestCollection testCollection;
        private bool IsModifed = false;
        private bool IsNewDocument = true;

        public Form1()
        {
            InitializeComponent();
            testCollection = new TestCollection();
            currentUnit = testCollection.Create();
            this.Text = testCollection.currentUnitName;
            InitTest();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CloseTest())
            {
                bool fail = true;
                while (fail)
                {
                    TestManager openForm = new TestManager(this.testCollection, "Открыть");
                    openForm.ShowDialog();
                    if (openForm.rezult == TestManager.DialogRezult.Cancel)
                        return;
                    try
                    {
                        LoadTest(openForm.selectedItem);
                        fail = false;
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно открыть тест \"" + openForm.selectedItem + "\"",
                            "Редактор тестов",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                if (!fail)
                {
                    InitTest();
                    IsNewDocument = false;
                    IsModifed = false;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseTest())
                e.Cancel = true;
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CreateTest())
            {
                IsNewDocument = true;
                IsModifed = false;
            }
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (testCollection.IndexOf(testCollection.currentUnitName) == -1)
            {
                сохранитькакToolStripMenuItem_Click(sender, e);
            }
            else
            {
                IsNewDocument = false;
                IsModifed = false;
                SaveTest();
            }
        }

        private void сохранитькакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestManager saveForm = new TestManager(this.testCollection, "Сохранить");
            saveForm.ShowDialog();
            if (saveForm.rezult == TestManager.DialogRezult.Select)
            {
                IsNewDocument = false;
                IsModifed = false;
                SaveTestAs(saveForm.selectedItem);
            }
        }

        private void предварительныйпросмотрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestManager testManager = new TestManager(testCollection);
            testManager.ShowDialog();
            if (testManager.rezult == TestManager.DialogRezult.Open)
            {
                try
                {
                    if (CloseTest())
                    {
                        LoadTest(testManager.selectedItem);
                        InitTest();
                    }
                }
                catch { }
            }
        }

        private void AnswerList_Enter(object sender, EventArgs e)
        {
            editor.Focus();
        }
    }
}
