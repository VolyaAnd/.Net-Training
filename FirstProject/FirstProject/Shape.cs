using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
namespace FirstProject
{
    public abstract class Shape
    {
        public Line ShapeLine { get; set; }

        public Shape()
        {

        }

        public abstract double GetArea();

        protected abstract void Validation();


    }
}
