using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace NET02._1
{
    public class Author 
    {
        private string name;
        private string surname;
        private const int maxLenth = 200;
        
        public Author(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }
        public string FirstName 
        { 
            get
            {
                return name;
            }
            set
            {
                if(string.IsNullOrEmpty(value) && value.Length > maxLenth)
                {
                    throw new ArgumentException("First Name cannot be empty or greater then 200 chars");
                }
                else 
                    name = value;
            }
        }
        public string LastName 
        {
            get
            {
                return surname;
            }
            set
            {
                if (string.IsNullOrEmpty(value) && value.Length > maxLenth)
                {
                    throw new ArgumentException("Last Name cannot be empty or greater then 200 chars");
                }
                else
                    surname = value;
            }
        }
    }
}
