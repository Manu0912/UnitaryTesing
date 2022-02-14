using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercisesMoshCourse;

namespace UnitaryTesting
{
    [TestClass]
    public class TestStack
    {
        [TestMethod]
        public void Push_NullArgument_ShouldThrowArgumentNullException()
        {
            var stack = new ExercisesMoshCourse.Stack<string>();

            Assert.ThrowsException<ArgumentNullException>(() => stack.Push(null));
        }

        [TestMethod]
        public void Push_CorrectArgument_AddObject()
        {
            var stack = new ExercisesMoshCourse.Stack<string>();

            stack.Push("example");
            Assert.AreEqual(1, stack.count);
        }

        [TestMethod]
        public void Count_EmptyStack_ReturnZero() 
        {
            var stack = new ExercisesMoshCourse.Stack<string>();
            Assert.AreEqual(0, stack.count);
        }

        [TestMethod]
        public void Pop_NotEmpty_ReturnObject()
        {
            var stack = new ExercisesMoshCourse.Stack<string>();
            string example = "example";

            stack.Push(example);
            Assert.AreEqual(example,stack.Pop());
        }

        [TestMethod]
        public void Pop_Empty_ReturnObject()
        {
            var stack = new ExercisesMoshCourse.Stack<string>();
            Assert.ThrowsException<InvalidOperationException>(() => stack.Pop());
        }

        [TestMethod]
        public void Peek_NotEmpty_ReturnObject()
        {
            var stack = new ExercisesMoshCourse.Stack<string>();
            string example = "example";

            stack.Push(example);

            Assert.AreEqual("a", stack.Peek());
        }

        [TestMethod]
        public void Peek_Empty_ReturnObject()
        {
            var stack = new ExercisesMoshCourse.Stack<string>();

            Assert.ThrowsException<InvalidOperationException>(() => stack.Peek());
        }

    }
}
