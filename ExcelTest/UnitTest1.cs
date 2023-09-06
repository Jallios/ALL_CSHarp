using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ExcelTest;

namespace ExcelTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetText_GetTextFromExcelFile()
        {
            Write file = new Write();
            Read read = new Read();
            file.WriteExcelWord("test");
            string expected = "test";

            string actual = read.ReadExcelWord(expected);

            Assert.AreEqual(expected, actual);
        }
    }
}
