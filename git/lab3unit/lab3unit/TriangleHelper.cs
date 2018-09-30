using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3unit
{
    class TriangleHelper
    {
        public bool TriangleCheck(double d1, double d2, double d3)
        {
            return (d1 < d2 + d3) && (d2 < d1 + d3) && (d3 < d1 + d2) 
                && d1 > 0 && d2 > 0 && d3 > 0;
        }
    }
}
