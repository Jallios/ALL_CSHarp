using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalculateUnitTest; 

namespace UnitTest
{
    [TestClass]
    public class UnitTestCall
    {
        [TestMethod]
        public void Sum_5plus05_6returned()
        {
            double x = 5.5;
            double y = 0.5;
            double expected = 5.5;

            Call c = new Call();
            double actual = c.Sum(x, y);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Diff_5minus05_5returned()
        {
            double x = 5.5;
            double y = 0.5;
            double expected = 5;

            Call c = new Call();
            double actual = c.Diff(x, y);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Multi_5umn05_275returned()
        {
            double x = 5.5;
            double y = 0.5;
            double expected = 2.6;

            Call c = new Call();
            double actual = c.Multi(x, y);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Div_5del05_11returned()
        {
            double x = 5;
            double y = 0.5;
            double expected = 10;

            Call c = new Call();
            double actual = c.Div(x, y);

            Assert.AreEqual(expected, actual);
        }
    }
}
