using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace NET02_2
{
    //[DataContract]
    [XmlType("window")]
    public class Window
    {

        [XmlElement("top")]
        //[DataMember]
        public int? Top { get; set; }

        //[DataMember]
        [XmlElement("left")]
        public int? Left { get; set; }

        //[DataMember]
        [XmlElement("width")]
        public int? Width { get; set; } 

        //[DataMember]
        [XmlElement("height")]
        public int? Height { get; set; }

        //[DataMember]
        [XmlAttribute("title")]
        public string Title { get; set; }
    }
}
