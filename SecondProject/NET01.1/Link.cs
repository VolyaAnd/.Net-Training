using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1
{
    public enum LinkType
    {
        Unknown,
        HTML,
        Image,
        Audio,
        Video
    }
    public class Link : Material
    {
        private string _linkURI;
        public string linkURI 
        { 
            get { return _linkURI; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Content URI cannot be empty.");
                }
                _linkURI = value;
            }
        }
        public LinkType linkType { get; set; }
        public override Guid Id { get => Id; set => this.GenerateId(); }
        public Link(string linkU, LinkType linkT)
        {
            linkURI = linkU;
            linkType = linkT;
            Description = "This is a section for links";
        }
        public override string ToString()
        {
            return "Here you will find links for the lesson.";
        }

        public object Clone()
        {
            Link cloneClass = new Link("training-center.by", LinkType.Unknown);
            cloneClass.Id = this.Id;
            cloneClass.linkURI = this.linkURI;
            cloneClass.linkType = this.linkType;
            return cloneClass;
        }
        /*
        public override void Validation()
        {
            if (string.IsNullOrEmpty(linkURI))
            {
                throw new ArgumentException("Content URI cannot be empty.");
            }
            
        }
        */


    }
}
