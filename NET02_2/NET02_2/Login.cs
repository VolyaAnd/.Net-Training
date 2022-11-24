using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NET02_2
{
    [XmlType("login")]
    //[DataContract]
    public class Login
    {
        [XmlAttribute("name")]
        //[DataMember]
        public string Name { get; set; }

        [XmlElement("window")]
        //[DataMember]
        public Window[] WindowArray { get; set; }

        public void PrintLog()
        {
            System.Console.Write("login: " + Name + Environment.NewLine);
            for (int i = 0; i < WindowArray.Length; i++)
            {
 
                System.Console.Write("  " + WindowArray[i].Title + "(" + GetNum(WindowArray[i].Top) +
                    "," +GetNum(WindowArray[i].Left) + "," + GetNum(WindowArray[i].Width) + "," +
                    GetNum(WindowArray[i].Height) + ")" + Environment.NewLine);
            }
        }

        private string GetNum(int? num)
        {
            if (num.HasValue)
            {
                return num.Value.ToString();
            }
            return "?";
        }

        public bool IsValid()
        {
            int mainCount = 0;
            foreach (Window window in WindowArray)
            {
                if (window.Title == "main")
                {
                    mainCount++;
                }

            }
            if (mainCount > 1)
            {
                return false;
            }
            if (mainCount ==1)
            {
                if (!WindowArray[0].Left.HasValue || !WindowArray[0].Top.HasValue ||
                    !WindowArray[0].Width.HasValue || !WindowArray[0].Height.HasValue)
                {
                    return false;
                }
            }
            return true;
        }
        public void FixLogin()
        {
            foreach (Window window in WindowArray)
            {
                if (!window.Left.HasValue)
                {
                    window.Left = 0;
                }
                if (!window.Top.HasValue)
                {
                    window.Top = 0;
                }
                if (!window.Width.HasValue)
                {
                    window.Width = 400;
                }
                if (!window.Height.HasValue)
                {
                    window.Height = 150;
                }
            }
        }
        public void Save(string path)
        {
            var dir = Directory.CreateDirectory(Path.Combine(path, Name));
            using (StreamWriter sw = File.AppendText(Path.Combine(dir.FullName, "config.json")))
            {
                sw.WriteLine(JsonSerializer.Serialize(this));//pointer

            }
        }
    }
    
}
