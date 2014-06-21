using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LiveSwitch.TextControl
{
    public class Unit
    {
        public List<Task> tasks;
        private HtmlAgilityPack.HtmlDocument doc;

        public Unit(HtmlAgilityPack.HtmlDocument doc)
        {
            this.doc = doc;

            tasks = new List<Task>();

            var tasknodes = doc.DocumentNode.SelectNodes("//div[@class='task']");
            if (tasknodes != null)
            {
                foreach (var taskNode in tasknodes)
                {
                    tasks.Add(new Task(taskNode));
                }
            }
        }

        public HtmlAgilityPack.HtmlDocument Write(HtmlAgilityPack.HtmlNode parent)
        {
            foreach (var task in tasks)
            {
                HtmlAgilityPack.HtmlNode child = doc.CreateElement("div");
                child.Attributes.Add("class", "task");
                task.Write(child);
                parent.AppendChild(child);
            }

            return doc;
        }
    }
}
