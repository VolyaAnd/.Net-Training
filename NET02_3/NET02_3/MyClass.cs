using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET02_3
{
    [TrackingEntity]
    public class MyClass
    {
        [TrackingProperty]
        public string Prop1 { get; set; }

        public string Prop2 { get; set; }

        [TrackingProperty]
        public string Prop3 { get; set; }
    }
}
