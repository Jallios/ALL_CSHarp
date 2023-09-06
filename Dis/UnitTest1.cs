using Microsoft.VisualStudio.TestTools.UnitTesting;
using dis;
using System;

namespace UnitTestPassword
{
    [TestClass]
    public class UnitTest1
    {
        public double a;
        public double b;
        public double c;
        public string expected;
        public Class404 dis = new Class404();
        public string actual;


        [TestMethod]
        public void Diskriminant_bolshe0_returned_x1_x2()
        {
            a = 2.0; 
            b = 3.0;
            c = 1.0;
            expected = "-0,5 -1";

            actual = dis.diskriminant(a,b,c);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Diskriminant_raven0_returned_x1()
        {
            a = 3.0;
            b = -18.0;
            c = 27.0;
            expected = "27";

            actual = dis.diskriminant(a, b, c);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Diskriminant_menshe0_returned_otvet()
        {
            a = 1;
            b = 2;
            c = 3;
            expected = "Нет корней!!!";

            actual = dis.diskriminant(a, b, c);
            Assert.AreEqual(expected, actual);
        }
    }
}
