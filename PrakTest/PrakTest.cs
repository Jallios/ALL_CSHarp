using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prak3;
using System;
using System.Collections.Generic;

namespace PrakTest
{
    [TestClass]
    public class PrakTest
    {
        static List<double> height;

        [ClassInitialize]
        public static void InitializeCurrentTest(TestContext testContext)
        {
            height = new List<double>();

            height.Add(195.5);
            height.Add(165.7);
            height.Add(10.5);
            height.Add(200.4);
            height.Add(134.9);
            height.Add(150.54);
        }

        [TestMethod]
        public void AreEqual()
        {
            List<double> heightTest = new List<double>();

            heightTest.Add(195.5);
            heightTest.Add(165.7);
            heightTest.Add(10.5);
            heightTest.Add(200.4);
            heightTest.Add(134.9);
            heightTest.Add(150.54);

            CollectionAssert.AreEqual(height, heightTest);

        }

        [TestMethod]
        public void AreEquivalent()
        {

            List<double> heightTest = new List<double>();

            heightTest.Add(195.5);
            heightTest.Add(165.7);
            heightTest.Add(10.5);
            heightTest.Add(150.54);
            heightTest.Add(200.4);
            heightTest.Add(134.9);


            CollectionAssert.AreEquivalent(height, heightTest);
        }
        [TestMethod]
        public void DeltaTest()
        {
            double expected = 0.2;
            double delta = 0.07;


            PrakClass prakClass = new PrakClass();
            double actual = prakClass.Percent(10.5,2.5);

            Assert.AreEqual(expected, actual, delta);


        }
    }
}
