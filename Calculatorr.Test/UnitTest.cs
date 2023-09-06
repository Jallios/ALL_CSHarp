using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculatorr.Test
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Division_doubletodouble_true()
        {
            double x = 30;
            double y = 7;
            double expected = 4;

            Calc calc = new Calc();
            double actual = Math.Round(calc.Div(x, y));

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Renta_day10movie_true()
        {
            int Day = 90;
            int Price = 100;
            double expected = 4;

            Movie movie = new Movie(price: Price);
            Renta renta = new Renta(movie, day: Day);

            Assert.AreEqual(123, renta.RentaPrice());
        }
    }
}
