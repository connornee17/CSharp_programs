using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration_1
{
    [TestClass]
    public class Bagtest
    {
        Bag myBag = new Bag(new string[] { "bag1", "rucksack" }, "first bag", "this is a good bag");
        Bag myBag2 = new Bag(new string[] { "bag2", "rucksack2" }, "second bag", "this is a bad bag");
        private Item myItem = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine ");
        private Item myItem1 = new Item(new string[] { "sword", "claymore" }, "a sword", "This is a mighty fine ");

        [TestMethod]
        public void BagLocateItem()
        {
            myBag.Inventory.Put(myItem);
            Assert.AreEqual(myItem, myBag.Locate("shovel"));
            Assert.IsTrue(myBag.Inventory.HasItem("shovel"));
        }

        [TestMethod]
        public void BagLocateSelf()
        {
            Assert.AreEqual(myBag, myBag.Locate("bag1"));
        }

        [TestMethod]
        public void BagLocateNothing()
        {
            Assert.AreNotEqual(myItem, myBag.Locate("shovel"));
            Assert.IsFalse(myBag.Inventory.HasItem("shovel"));
        }

        [TestMethod]
        public void BagFullDesc()
        {
            myBag.Inventory.Put(myItem);
            myBag.Inventory.Put(myItem1);

            Assert.AreEqual("In the first bag you can see:\n\ta shovel (shovel)\n\ta sword (sword)", myBag.FullDescription);
        }

        [TestMethod]
        public void BagInBag()
        {
            myBag.Inventory.Put(myBag2);
            myBag2.Inventory.Put(myItem);

            Assert.IsTrue(myBag2.Inventory.HasItem("shovel"));
            Assert.IsFalse(myBag.Inventory.HasItem("shovel"));
            Assert.AreEqual(myBag2, myBag.Locate("bag2"));
        }
    }
}
