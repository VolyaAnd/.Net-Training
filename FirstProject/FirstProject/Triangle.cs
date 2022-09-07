using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
namespace FirstProject
{
    public class Triangle : Shape
    {
        Point A { get; set; }
        Point B { get; set; }
        Point C { get; set; }


        public Triangle(Point point1, Point point2, Point point3, Line line)
        {
            A = point1;
            B = point2;
            C = point3;
            ShapeLine = line;
            Validation();
        }

        protected override void Validation()
        {
            double side1 = ((B.X - A.X) ^ 2 + (B.Y - A.Y) ^ 2) ^ (1 / 2);
            double side2 = ((C.X - B.X) ^ 2 + (C.Y - B.Y) ^ 2) ^ (1 / 2);
            double side3 = ((A.X - C.X) ^ 2 + (A.Y - C.Y) ^ 2) ^ (1 / 2);

            if (side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
            {
                throw new ArgumentException("Triangle with such vertices does not exist");
            }
        }

        public override double GetArea()
        {
            return 0.5 * Math.Abs(((A.X - C.X) * (B.Y - C.Y) - (B.X - C.X) * (A.Y - C.Y)));
        }
    }
}
