using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LiveSwitch.TextControl
{
    public class TestCollection: IList<string>
    {
        private Dictionary<string, string> fileList;
        private List<string> themes;
        private HtmlAgilityPack.HtmlDocument doc;
        public Unit currentUnit
        {
            get;
            private set;
        }
        public string currentUnitName
        {
            get;
            private set;
        }
        public int Count
        {
            get
            {
                return themes.Count;
            }
        }
        bool ICollection<string>.IsReadOnly
        {
            get
            {
                return ((ICollection<string>)themes).IsReadOnly;
            }
        }

        public TestCollection()
        {
            fileList = new Dictionary<string, string>();
            themes = new List<string>();

            var names = Directory.GetFiles("Tests", "*.htm*");
            Array.Sort(names);

            foreach (var name in names)
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.Load(name, Encoding.UTF8);
                string title = doc.DocumentNode.SelectSingleNode("//head/title").InnerText;
                fileList.Add(title, name);
                themes.Add(title);
            }
        }

        private string CreateFileName()
        {
            List<int> nums = new List<int>();
            foreach (var item in fileList)
            {
                nums.Add(int.Parse(Path.GetFileNameWithoutExtension(item.Value)));
            }

            nums.Sort();
            int i = 0;
            foreach (int num in nums)
            {
                if (num > i)
                    break;
                i++;
            }
            return Path.Combine("Tests", i + ".htm");
        }

        public string CreateThemeName()
        {
            List<int> nums = new List<int>();
            foreach (var item in themes)
            {
                try
                {
                    if (item.Substring(0, 5) == "Тема ")
                        nums.Add(int.Parse(item.Substring(5)));
                }
                catch { }
            }

            if (currentUnitName != null && currentUnitName.Substring(0, 5) == "Тема ")
            {
                int curNum = int.Parse(currentUnitName.Substring(5));
                if (nums.IndexOf(curNum) == -1)
                    nums.Add(curNum);
            }

            nums.Sort();
            int i = 0;
            foreach (int num in nums)
            {
                if (num > i)
                    break;
                i++;
            }

            return "Тема " + i;
        }

        public Unit Create()
        {
            string theme = CreateThemeName();
            currentUnitName = theme;

            doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(Properties.Resources.EmptyTest);
            var title = doc.DocumentNode.SelectSingleNode("//head/title");
            title.InnerHtml = theme;

            Unit unit = new Unit(doc);
            currentUnit = unit;
            return unit;
        }

        public void Add(string name)
        {
            doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(Properties.Resources.EmptyTest);
            var title = doc.DocumentNode.SelectSingleNode("//head/title");
            title.InnerHtml = name;

            string filename = CreateFileName();
            fileList.Add(name, filename);
            themes.Add(name);

            var stream = File.CreateText(filename);
            doc.Save(stream);
        }

        public Unit Load(string theme)
        {
            doc = new HtmlAgilityPack.HtmlDocument();
            string fileName = fileList[theme];
            currentUnitName = theme;
            doc.Load(fileName, Encoding.UTF8);
            Unit unit = new Unit(doc);
            currentUnit = unit;
            return unit;
        }

        public void Save()
        {
            var body = doc.DocumentNode.SelectSingleNode("//body");
            body.InnerHtml = "";

            currentUnit.Write(body);

            var stream = File.CreateText(fileList[currentUnitName]);
            doc.Save(stream);
        }

        public void SaveAs(string name)
        {
            string filename;
            if (fileList.TryGetValue(currentUnitName, out filename))
            {
                fileList.Remove(currentUnitName);
                themes.Remove(currentUnitName);
            }
            else
            {
                filename =  CreateFileName();
            }
            fileList.Add(name, filename);
            themes.Add(name);
            themes.Sort();

            doc.DocumentNode.SelectSingleNode("//head/title").InnerHtml = name;
            var body = doc.DocumentNode.SelectSingleNode("//body");
            body.InnerHtml = "";

            currentUnit.Write(body);
            currentUnitName = name;

            var stream = File.CreateText(fileList[currentUnitName]);
            doc.Save(stream);
        }

        public bool Remove(string name)
        {
            string filename = fileList[name];
            fileList.Remove(name);
            themes.Remove(name);
            File.Delete(filename);
            return true;
        }

        public void Rename(string oldName, string newName)
        {
            string filename = fileList[oldName];
            fileList.Remove(oldName);
            fileList.Add(newName, filename);
            themes.Remove(oldName);
            themes.Add(newName);

            doc.Load(filename, Encoding.UTF8);
            doc.DocumentNode.SelectSingleNode("//head/title").InnerHtml = newName;
            var stream = File.CreateText(filename);
            doc.Save(stream);
        }

        #region IList интерфейс
        public string this[int index]
        {
            get { return themes[index]; }
            set { themes[index] = value; }
        }

        public int IndexOf(string item)
        {
            return themes.IndexOf(item);
        }

        void IList<string>.Insert(int index, string item)
        {
            themes.Insert(index, item);
        }

        void IList<string>.RemoveAt(int index)
        {
            themes.RemoveAt(index);
        }

        void ICollection<string>.Clear()
        {
            themes.Clear();
            fileList.Clear();
        }

        bool ICollection<string>.Contains(string item)
        {
            return themes.Contains(item);
        }

        void ICollection<string>.CopyTo(string[] array, int arrayIndex)
        {
            themes.CopyTo(array, arrayIndex);
        }

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return themes.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return themes.GetEnumerator();
        }
        #endregion
    }
}
