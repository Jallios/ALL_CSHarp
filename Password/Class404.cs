using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace dis
{
    public class Class404
    {
        public string diskriminant(double a, double b, double c)
        {
            string otvet = " ";
            double x1;
            double x2;

            double D;

            D = (Math.Pow(b, 2)) - (4 * a * c);

            if (D > 0)
            {
                x1 = (-b + Math.Sqrt(D)) / (2 * a);
                x2 = (-b - Math.Sqrt(D)) / (2 * a);

                otvet = x1.ToString() +" "+ x2.ToString();
            }
            else if (D == 0)
            {
                x1 = -(b / 2 * a);
                x2 = 0;
                otvet = x1.ToString();
            }
            else if (D < 0)
            {
                otvet = "Нет корней!!!";
            }

            return otvet;
        }
    }
}
