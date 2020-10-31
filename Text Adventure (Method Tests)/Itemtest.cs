using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration_1
{
    [TestClass]
    public class Itemtest
    {
        private Item myItem = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine shovel");

        [TestMethod]
        public void ItemIdentifier()
        {
            Assert.IsTrue(myItem.AreYou("spade"));
        }

        [TestMethod]
        public void ItemShortDescription()
        {
            Assert.IsTrue(myItem.ShortDescription == "a shovel (shovel)");
        }

        [TestMethod]
        public void ItemFullDescription()
        {
            Assert.IsTrue(myItem.FullDescription == "This is a mighty fine shovel");
        }
    }
}
    
