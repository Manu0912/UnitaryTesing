using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercisesMoshCourse;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitaryTesting
{
    [TestClass]
    public class TestDemeritPointsCalculator
    {
        [TestMethod]
        public void CalculateDemeritPoints_WhenCalled_ShouldReturn0() 
        {
            int res = DemeritPointsCalculator.CalculateDemeritPoints(50);
            Assert.AreEqual(0, res);
        }

        [TestMethod]
        public void CalculateDemeritPoints_WhenCalled_ShouldReturnDemeritPoints()
        {
            int res = DemeritPointsCalculator.CalculateDemeritPoints(100);
            Assert.AreEqual(8, res);
        }

        [TestMethod]
        public void CalculateDemeritPoints_WhenCalled_ShouldReturnArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => DemeritPointsCalculator.CalculateDemeritPoints(-1));
        }
    }
}
