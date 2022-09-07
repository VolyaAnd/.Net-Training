using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET01._1
{
    public abstract class Material : BaseEntity  //can I clone abstract class
    { 
        public Material()
        {
     
        }
        public abstract string ToString();
  
        public bool Equals(Material training) 
        {
            return this.Id == training.Id;
        }
        //public abstract LessonType TrainingType();


    }
}
