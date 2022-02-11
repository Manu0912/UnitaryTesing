using Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitaryTesting
{
    [TestClass]
    public class FibonacciTest
    {
        [TestMethod]
        public void TestFibonacciNumber()
        {
            Fibonacci fib = new();
            var res = fib.GetFibonacciNumber(10);
            Assert.IsNotNull(res);
            Assert.AreEqual(55, res);
            
        }
    }
}
