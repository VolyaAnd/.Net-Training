using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace FirstProject
{
    public class Rectangle : Shape
    {
        Point LeftTop { get; set; }
        Point RightBottom { get; set; }


        public Rectangle(Point point1, Point point2, Line line)
        {
            LeftTop = point1;
            RightBottom = point2;
            ShapeLine = line;
            Validation();
        }

        protected override void Validation()
        {

            if ((RightBottom.X - LeftTop.X) > 10 || (LeftTop.Y - RightBottom.Y) > 10)
            {
                throw new ArgumentException("Not valid lenth of side");
            }

        }

        public override double GetArea()
        {
            return Math.Abs(LeftTop.X - RightBottom.X) * Math.Abs(LeftTop.Y - RightBottom.Y);
        }
    }
}
