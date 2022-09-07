using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
namespace FirstProject
{
    public class Circle : Shape
    {
        Point Center { get; set; }
        int Radius { get; set; }


        public Circle(Point point, int radius, Line line)
        {
            Center = point;
            Radius = radius;
            ShapeLine = line;
            Validation();
        }

        protected override void Validation()
        {

            if (Center.X < 0 || Center.Y < 0)
            {
                throw new ArgumentException("Center coordinate cannot be negative");
            }

        }


        public override double GetArea() //
        {
            return Math.PI * Math.Pow(Radius, 2);

        }
    }
}
