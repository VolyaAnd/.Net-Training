using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NET02_2
{
    ///[DataContract]
    [XmlRoot("config")]
    public class Config
    {
        //[DataMember]
        [XmlElement("login")]
        public Login[] LoginArray { get; set; }

        //validate
        //check all logins
        public void LoginValidate()
        {
            foreach (Login login in LoginArray)
            {
                if (!login.IsValid())
                {
                    Console.WriteLine("Incorrect login: " + login.Name);
                }
            }
        }

        public void FixConfig()
        {
            foreach (Login login in LoginArray)
            {
                login.FixLogin();
            }
        }
        public void Save(string path)
        {
            foreach (Login login in LoginArray)
            {
                login.Save(path);
            }
        }
    }
}
