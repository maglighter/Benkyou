using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LiveSwitch.TextControl
{
    public partial class Form1
    {
        private Unit currentUnit;

        private void SaveTest()
        {
            SaveEditor();
            testCollection.Save();
            IsModifed = false;
        }

        private bool CloseTest()
        {
            SaveEditor();

            if (IsModifed)
            {
                var rezult = MessageBox.Show("Сохранить изменения теста \"" + testCollection.currentUnitName + "\"?",
                    "Редактор тестов",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1
                );

                switch (rezult)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        SaveTest();
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        return false;
                }
            }
            return true;
        }

        private void ClearTest()
        {
            TaskList.Items.Clear();
            AnswerList.Clear();
            editor.Html = "";
            currentAnswerNum = 0;
            currentTask = null;
            currentTaskNum = 0;
            currentText = null;
            currentUnit = null;
        }

        private void InitTest()
        {
            InitTasks();
            SelectTask(0);
        }

        private bool CreateTest()
        {
            if (CloseTest())
            {
                currentUnit = testCollection.Create();
                this.Text = testCollection.currentUnitName;
                InitTest();
                return true;
            }
            return false;
        }

        private void DeleteTest(string name)
        {
            if (name == testCollection.currentUnitName)
                ClearTest();
            testCollection.Remove(name);
        }

        private void SaveTestAs(string name)
        {
            testCollection.SaveAs(name);
            this.Text = name;
        }

        private void LoadTest(string name)
        {
            currentUnit = testCollection.Load(name);
            this.Text = name;
        }
    }
}
