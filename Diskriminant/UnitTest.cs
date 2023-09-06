using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Diskriminant;

namespace Diskriminant
{
    [TestClass]
    public class UnitTest
    {
        public double a;
        public double b;
        public double c;
        public string expected;
        public Class c = new Class();
        public string actual;


        [TestMethod]
        public void Diskriminant_bolshe0_returned_x1_x2()
        {
            password = "Modb";
            expected = 2;
            actual = c.ScoreofPassword(password);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Diskriminant_raven0_returned_x1()
        {
            password = "Modb7";
            expected = 3;
            actual = c.ScoreofPassword(password);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Diskriminant_menshe0_returned_otvet()
        {
            password = "Modb7/";
            expected = 4;
            actual = c.ScoreofPassword(password);
            Assert.AreEqual(expected, actual);
        }
    }
}
