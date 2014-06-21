using System;
using System.Collections.Generic;
using System.Text;

namespace LiveSwitch.TextControl
{
    public class Task
    {
        public string question = "";
        public List<string> answers = new List<string>();
        public int trueAnswer;
        public string html;
        public bool Modifed { get; private set; }

        public Task(HtmlAgilityPack.HtmlNode taskNode)
        {
            if (taskNode != null)
            {
                this.question = taskNode.SelectSingleNode("./div[@class='question']").InnerHtml ?? "";

                var answerList = taskNode.SelectNodes("./div[@class='answer']");
                if (answerList != null)
                {
                    foreach (var answerNode in answerList)
                    {
                        this.answers.Add(answerNode.InnerHtml ?? "");
                    }
                }
            }
        }

        public Task()
        {
        }

        internal void Write(HtmlAgilityPack.HtmlNode parent)
        {
            var questionNode = parent.OwnerDocument.CreateElement("div");
            questionNode.Attributes.Add("class", "question");
            questionNode.InnerHtml = question;

            parent.AppendChild(questionNode);

            foreach (var answer in answers)
            {
                var answerNode = parent.OwnerDocument.CreateElement("div");
                answerNode.Attributes.Add("class", "answer");
                answerNode.InnerHtml = answer;

                parent.AppendChild(answerNode);
            }
        }
    }
}
