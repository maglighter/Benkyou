using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Test
{
    public class Task
    {
        public string question;
        public List<HtmlAgilityPack.HtmlNode> answers;
        public int trueAnswer;
        public string html;
        public int x;

        public string TaskNumber { get; set; }

        public Task()
        {
            answers = new List<HtmlAgilityPack.HtmlNode>();
        }

        public void Reshuffle()
        {
            StringBuilder html = new StringBuilder();
            html.Append(question);

            var src = new List<HtmlAgilityPack.HtmlNode>(answers);
            Random rand = new Random();
            trueAnswer = -1;
            for (int last = answers.Count, i = 1; last > 0; last--, i++)
            {
                int cur = rand.Next(last);
                if (trueAnswer != -1 && cur == 0)
                    trueAnswer = answers.Count - last;
                html.Append(string.Format("<div>{0}. {1}<div>", i, src[cur].InnerHtml));
                src.RemoveAt(cur);
            }
            this.html = html.ToString();
        }
    }

    public class Unit
    {
        public List<Task> tasks;
        public Uri uri;

        public Unit(string filename, HtmlAgilityPack.HtmlDocument doc)
        {
            tasks = new List<Task>();

            string curDir = Directory.GetCurrentDirectory();
            uri = new Uri(String.Format("file:///{0}/{1}", curDir, filename));

            var tasknodes = doc.DocumentNode.SelectNodes("//div[@class='task']");
            int num = 1;
            foreach (var tasknode in tasknodes)
            {
                Task task = new Task { TaskNumber = num++.ToString() };

                task.question = tasknode.SelectSingleNode("./div[@class='question']").OuterHtml;

                var answernodes = tasknode.SelectNodes("./div[@class='answer']");
                foreach (var answernode in answernodes)
                {
                    task.answers.Add(answernode);
                }
                tasks.Add(task);
            }
        }

        public void Reshuffle()
        {
            foreach (var item in tasks)
            {
                item.Reshuffle();
            }
        }
    }
}
