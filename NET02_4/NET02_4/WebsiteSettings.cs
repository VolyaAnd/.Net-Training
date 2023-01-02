using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NET02_4
{
    public class WebsiteSettings : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            List<Setting> myConfigObject = new List<Setting>();

            foreach (XmlNode childNode in section.ChildNodes)
            {
                var setting = new Setting();
                foreach (XmlAttribute attrib in childNode.Attributes)
                {
                    if(attrib.Name == "uri")
                    {
                        setting.uri = attrib.Value;
                    }
                    if (attrib.Name == "timeout")
                    {
                        setting.timeout = attrib.Value;
                    }
                    if (attrib.Name == "interval")
                    {
                        setting.interval = attrib.Value;
                    }
                    if (attrib.Name == "email")
                    {
                        setting.email = attrib.Value;
                    }
                }
                myConfigObject.Add(setting);
            }
            return myConfigObject;
        }
    }
}
