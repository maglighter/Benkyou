using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSwitch.TextControl
{
    public partial class Form1
    {
        private class CurrentText
        {
            public Task task;
            public int answerNum;
        }
        private CurrentText currentText;

        private void InitEditor()
        {
            SaveEditor();

            if (currentAnswerNum > 0)
                editor.Html = currentTask.answers[currentAnswerNum - 1];
            else
                editor.Html = currentTask.question;

            currentText = new CurrentText { task = currentTask, answerNum = currentAnswerNum };
        }

        private void SaveEditor()
        {
            if (currentText != null)
            {
                int i = currentText.answerNum;
                if (i > 0)
                {
                    if (currentText.task.answers[i - 1] != editor.BodyHtml)
                    {
                        currentText.task.answers[i - 1] = editor.BodyHtml ?? "";
                        IsModifed = true;
                    }
                }
                else
                {
                    string predicate = editor.BodyHtml ?? "";
                    if (currentText.task.question != predicate)
                    {
                        currentText.task.question = predicate;
                        IsModifed = true;
                    }
                }
            }
        }
    }
}
