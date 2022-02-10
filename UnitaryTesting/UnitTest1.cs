using System;
using Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitaryTesting
{
    [TestClass]
    public class MathTest
    {
        [TestMethod]
        public void AddTest(int num1, int num2)
        {
            BasicMath math = new BasicMath();
            double res = math.Add(20, 20);
            Assert.AreEqual(num1 + num2, res);
        }
    }
}