using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1
{
    public abstract class BaseEntity
    {
        public abstract System.Guid Id { get; set; }
        private string _description;
        private const int maxValueLength = 256;
        public string Description { 
            
            get
            {
                return _description;
            }
            set 
            {
                if (value.Length > maxValueLength)
                {
                    throw new ArgumentException("Description must be shorter then 256 characters");

                }
                else _description = value;
            } 
        }
        public BaseEntity()
        {

        }
    }
}
