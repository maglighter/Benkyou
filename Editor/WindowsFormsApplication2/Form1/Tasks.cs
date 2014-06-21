using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSwitch.TextControl
{
    public partial class Form1
    {
        private Task currentTask;
        private int currentTaskNum;

        private void InitTasks()
        {
            if (currentUnit.tasks.Count > 0)
            {
                TaskList.Items.Clear();

                for (int i = 1; i <= currentUnit.tasks.Count; i++)
                    TaskList.Items.Add(i.ToString());
                lCount.Text = "из " + currentUnit.tasks.Count.ToString();
            }
            else
            {
                TaskList.Items.Add("0");
                lCount.Text = "из 0";
            }
        }

        private void SelectTask(int i)
        {
            if (currentUnit.tasks.Count > 0)
            {
                this.TaskList.SelectedIndexChanged -= new System.EventHandler(this.ThemeList_SelectedIndexChanged);
                TaskList.SelectedIndex = i;
                this.TaskList.SelectedIndexChanged += new System.EventHandler(this.ThemeList_SelectedIndexChanged);
                
                currentTask = currentUnit.tasks[i];
                currentTaskNum = i;
                InitAnswers();
                SelectAnswer(0);
            }
        }

        private void AddTask()
        {
            Task task = new Task();
            currentUnit.tasks.Insert(currentTaskNum, task);
            InitTasks();
            SelectTask(currentTaskNum);
            IsModifed = true;
        }

        private void DeleteTask()
        {
            if (currentUnit.tasks.Count > 1)
            {
                currentUnit.tasks.RemoveAt(currentTaskNum);
                if (currentUnit.tasks.Count <= currentTaskNum)
                    currentTaskNum = currentUnit.tasks.Count - 1;

                InitTasks();

                currentTask = currentUnit.tasks[currentTaskNum];
                SelectTask(currentTaskNum);
                IsModifed = true;
            }
            
        }

        private void ThemeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = TaskList.SelectedIndex;
            SelectTask(i);
        }

        private void btAddTask_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        private void btDeleteTask_Click(object sender, EventArgs e)
        {
            DeleteTask();
        }

        private void btNextTask_Click(object sender, EventArgs e)
        {
            if (currentTaskNum < currentUnit.tasks.Count - 1)
                SelectTask(currentTaskNum + 1);
        }

        private void btBackTask_Click(object sender, EventArgs e)
        {
            if (currentTaskNum > 0)
                SelectTask(currentTaskNum - 1);
        }
    }
}
