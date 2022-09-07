using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
namespace FirstProject
{
    public class Line
    {
        public string Color { get; set; }
        public string Type { get; set; }
        public int Thickness { get; set; }

        public Line(string color, string type, int thickness)
        {
            Color = color;
            Type = type;
            Thickness = thickness;
        }
    }
}
