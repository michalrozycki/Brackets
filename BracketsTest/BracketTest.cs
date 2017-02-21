using Microsoft.VisualStudio.TestTools.UnitTesting;
using Brackets;

namespace Tests
{
    [TestClass]
    public class BracketTest
    {
        [TestMethod]
        public void BracketTests()
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

            input = "(()))(()(";
            Assert.AreEqual("impossible", Program.steps(input));
        }
    }
}