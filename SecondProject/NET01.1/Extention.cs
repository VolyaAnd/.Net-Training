using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Create an extension method that generates
//and assigns a unique identifier to the entity.
namespace NET01._1
{ 
    public static class Extention
    {
        public static System.Guid GenerateId(this BaseEntity entity)
        {
            entity.Id = Guid.NewGuid();
            return entity.Id;
        }
    }
}
