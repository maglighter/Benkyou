using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LiveSwitch.TextControl
{
    public partial class Form1
    {
        private int currentAnswerNum;
        private object syncAnswer = new object();

        private void InitAnswers()
        {
            lock (syncAnswer)
            {
                AnswerList.Items.Clear();

                AnswerList.Items.Add(new ListViewItem("Вопрос"));
                if (currentTask.answers.Count > 0)
                {
                    for (int i = 1; i <= currentTask.answers.Count; i++)
                        AnswerList.Items.Add(new ListViewItem("Ответ " + i.ToString()));
                }
            }
        }

        private void SelectAnswer(int i)
        {
            lock (syncAnswer)
            {
                this.AnswerList.SelectedIndexChanged -= new System.EventHandler(this.AnswerList_SelectedIndexChanged);
                AnswerList.Items[i].Selected = true;
                this.AnswerList.SelectedIndexChanged += new System.EventHandler(this.AnswerList_SelectedIndexChanged);

                currentAnswerNum = i; 
            }

            InitEditor();
        }

        private void AddAnswer()
        {
            lock (syncAnswer)
            {
                if (currentAnswerNum < 1)
                    currentTask.answers.Add("");
                else
                {
                    if (currentAnswerNum <= currentText.answerNum)
                        currentText.answerNum++;
                    currentTask.answers.Insert(currentAnswerNum - 1, "");
                } 
            }

            InitAnswers();
            SelectAnswer(currentAnswerNum);
            IsModifed = true;
        }

        private void DeleteAnswer()
        {
            if (currentTask.answers.Count > 1 && currentAnswerNum != 0)
            {
                lock (syncAnswer)
                {
                    currentTask.answers.RemoveAt(currentAnswerNum - 1);
                    if (currentTask.answers.Count < currentAnswerNum)
                        currentAnswerNum = currentTask.answers.Count;
                }

                InitAnswers();
                SelectAnswer(currentAnswerNum);
            }
            IsModifed = true;
        }

        private void AnswerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AnswerList.SelectedIndices.Count > 0)
            {
                int i = AnswerList.SelectedIndices[0];

                lock (syncAnswer)
                {
                    currentAnswerNum = i; 
                }

                InitEditor();
            }
        }

        private void btBackAnswer_Click(object sender, EventArgs e)
        {
            if (currentAnswerNum > 0)
                SelectAnswer(currentAnswerNum - 1);
        }

        private void btDeleteAnswer_Click(object sender, EventArgs e)
        {
            DeleteAnswer();
        }

        private void btAddAnswer_Click(object sender, EventArgs e)
        {
            AddAnswer();
        }

        private void btNextAnswer_Click(object sender, EventArgs e)
        {
            if (currentAnswerNum < currentTask.answers.Count)
                SelectAnswer(currentAnswerNum + 1);
        }
    }
}
