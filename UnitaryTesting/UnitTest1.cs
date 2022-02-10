using Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitaryTesting
{
    [TestClass]
    public class MathTest
    {
        [TestMethod]
        public void AddTest()
        {
            BasicMath math = new BasicMath();
            double res = math.Add(20, 20);
            Assert.AreEqual(40, res);
        }

        [TestMethod]
        public void Substract()
        {
            BasicMath math = new BasicMath();
            double res = math.Substract(35, 20);
            Assert.AreEqual(15, res);
        }

        [TestMethod]
        public void Multiply()
        {
            BasicMath math = new BasicMath();
            double res = math.Multiply(20, 20);
            Assert.AreEqual(400, res);
        }

        [TestMethod]
        public void Divide()
        {
            BasicMath math = new BasicMath();
            double res = math.Divide(20, 20);
            Assert.AreEqual(1, res);
        }

    }

}