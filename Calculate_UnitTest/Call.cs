using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalculateUnitTest
{
    public class Call
    {
        public double Sum(double x, double y)
        {
            return x + y;
        }
        public double Diff(double x, double y)
        {
            return x - y;
        }
        public double Multi(double x, double y)
        {
            return x * y;
        }
        public double Div(double x, double y)
        {
            return x / y;
        }
    }
}
