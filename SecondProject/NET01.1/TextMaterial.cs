using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1
{
    public class TextMaterial : Material
    {
        private string _text;
        public string Text 
        {
            get { return _text; }
            set 
            {
                if (string.IsNullOrEmpty(value) ||  value.Length > maxTextLenght )
                {
                    throw new ArgumentException("Text length cannot be empty or exceed 10 000 characters.");
                }
                _text = value; 
            }
        }
        int maxTextLenght = 10000;
        public override Guid Id { get => Id; set => this.GenerateId(); }
        public TextMaterial(string lessonText)
        {
            Text = lessonText;
            Description = "This is a section for text materials";
        }
        public override string ToString()
        {
            return "Here you will find text materials for the lesson.";
        }

        public object Clone()
        {
            TextMaterial cloneClass = new TextMaterial("Lorem ipsum");
            cloneClass.Id = this.Id;
            cloneClass.Text = this.Text;
            cloneClass.maxTextLenght = this.maxTextLenght; //do I need to clone local variable?
            return cloneClass;
        }
        /*
        public override void Validation()
        {
            if (Text.Length > maxTextLenght && string.IsNullOrEmpty(Text))
            {
                throw new ArgumentException("Text length cannot be empty or exceed 10 000 characters.");
            }
            
        }
        */
    }
}
