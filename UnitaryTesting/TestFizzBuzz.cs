using ExercisesMoshCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitaryTesting
{
    [TestClass]
    public class TestFizzBuzz
    {
        [TestMethod]
        public void GetOutput_WhenCalled_ShouldReturnFizz()
        {
            string res = FizzBuzz.GetOutput(3);
            Assert.AreEqual(res, "Fizz");
        }

        [TestMethod]
        public void GetOutput_WhenCalled_ShouldReturnBuzz()
        {
            string res = FizzBuzz.GetOutput(5);
            Assert.AreEqual(res, "Buzz");
        }

        [TestMethod]
        public void GetOutput_WhenCalled_ShouldReturnFizzBuzz()
        {
            string res = FizzBuzz.GetOutput(15);
            Assert.AreEqual(res, "FizzBuzz");
        }

        [TestMethod]
        public void GetOutput_WhenCalled_ShouldReturnSameNumber()
        {
            string res = FizzBuzz.GetOutput(1);
            Assert.AreEqual(res, "1");
        }
    }
}
