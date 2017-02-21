using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Abc;

namespace AbcTest
{
    [TestClass]
    public class AbcTest
    {
        [TestMethod]
        public void AbcTests()
        {
            Assert.AreEqual("1 3 5", Program.solve("1 5 3", "ABC"));

            Assert.AreEqual("6 2 4", Program.solve("6 4 2", "CAB"));
        }
    }
}
