using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brackets;

namespace UnitTestProject1
{
    [TestClass]
    public class BracketTest
    {
        [TestMethod]
        public void Common()
        {
            var input = "(()())";
            Assert.AreEqual("possible", Program.steps(input));

            input = ")))(";
            Assert.AreEqual("impossible", Program.steps(input));

            input = "()))";
            Assert.AreEqual("possible", Program.steps(input));

            input = "()()()())()()()())";
            Assert.AreEqual("possible", Program.steps(input));

            input = "(())";
            Assert.AreEqual("possible", Program.steps(input));

            input = "()()";
            Assert.AreEqual("possible", Program.steps(input));

            input = "(()())()";
            Assert.AreEqual("possible", Program.steps(input));

            input = "(";
            Assert.AreEqual("impossible", Program.steps(input));

            input = "())";
            Assert.AreEqual("impossible", Program.steps(input));

            input = "";
            Assert.AreEqual("possible", Program.steps(input));

            input = "())(";
            Assert.AreEqual("possible", Program.steps(input));

            input = "()))";
            Assert.AreEqual("possible", Program.steps(input));

            input = ")))(";
            Assert.AreEqual("impossible", Program.steps(input));
        }

        [TestMethod]
        public void Special()
        {
            var input = "(()))(()(";
            Assert.AreEqual("impossible", Program.steps(input));

            input = "";
            for (var i = 0; i < 5000; i++)
            {
                var r = new Random();
                input += (r.Next() < .5) ? '(' : ')';
            }
            //Assert.AreEqual("possible", Program.steps(input));
        }
    }
}
