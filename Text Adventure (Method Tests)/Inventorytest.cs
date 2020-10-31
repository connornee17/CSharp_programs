using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration_1
{
    [TestClass]
    public class Inventorytest
    {
        private Player myPlayer = new Player("Connor", "A programmer");
        private Inventory myInventory = new Inventory();
        private Item myItem = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine ");
        private Item myItem1 = new Item(new string[] { "sword", "claymore" }, "a sword", "This is a mighty fine ");

        [TestMethod]
        public void AFindItem()
        {
            myInventory.Put(myItem);
            myInventory.Put(myItem1);
            Assert.IsTrue(myInventory.HasItem("shovel"));
        }

        [TestMethod]
        public void BNoItemFind()
        {
            Assert.IsFalse(myInventory.HasItem("A Squid"));
        }

        [TestMethod]
        public void CFetchItem()
        {
            myInventory.Put(myItem);
            myInventory.Put(myItem1);
            Assert.AreEqual(myItem1, myInventory.Fetch("sword"));
            Assert.IsTrue(myInventory.HasItem("sword"));
        }

        [TestMethod]
        public void DTakeItem()
        {
            myInventory.Put(myItem);
            Assert.IsTrue(myInventory.HasItem("shovel"));
            Assert.AreEqual(myItem, myInventory.Take("shovel"));
            Assert.IsFalse(myInventory.HasItem("shovel"));

        }

        [TestMethod]
        public void EItemList()
        {
            myInventory.Put(myItem);
            myInventory.Put(myItem1);

            Assert.AreEqual("\n\ta shovel (shovel)\n\ta sword (sword)", myInventory.ItemList);
        }
    }
}
