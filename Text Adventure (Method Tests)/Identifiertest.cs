using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Iteration_1;

namespace Iteration_1
{
    [TestClass]
    public class Identifiertest
    {
        Identifier IdentifiableObj = new Identifier(new string[] { "george", "Wilma" });

        [TestMethod]
        public void TestAreYou()
        {
            Assert.IsTrue(IdentifiableObj.AreYou("george"));
        }

        [TestMethod]
        public void TestNotAreYou()
        {
            Assert.IsFalse(IdentifiableObj.AreYou("Fred"));
        }

        [TestMethod]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(IdentifiableObj.AreYou("GeOrGe"));
        }

        [TestMethod]
        public void TestFirstID()
        {
            Assert.IsTrue(IdentifiableObj.FirstId == "george");
        }

        [TestMethod]
        public void TestAddID()
        {
            IdentifiableObj.AddIdentifier("johnny");
            Assert.IsTrue(IdentifiableObj.AreYou("johnny"));
        }

    }   
}
