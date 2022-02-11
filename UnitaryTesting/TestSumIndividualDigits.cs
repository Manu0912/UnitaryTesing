using Math;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitaryTesting
{
    [TestClass]
    public class TestSumIndividualDigits
    {
        [TestMethod]
        public void TestSumDigits()
        {
            var res = SumIndividualDigits.SumDigits(25321);
            Assert.IsNotNull(res);
            Assert.AreEqual(13, res);

        }
    }
}
