using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration_1
{
    [TestClass]
    public class Playertest
    {
        Player myPlayer = new Player("connor", "the programmer");
        private Item myItem = new Item(new string[] { "shovel", "spade" }, "a shovel", "This is a mighty fine ");
        private Item myItem1 = new Item(new string[] { "sword", "claymore" }, "a sword", "This is a mighty fine ");

        [TestMethod]
        public void PlayerIdentify()
        {
            Assert.IsTrue(myPlayer.AreYou("me"));
        }

        [TestMethod]
        public void PlayerLocateItems()
        {
            myPlayer.Inventory.Put(myItem);
            Assert.AreEqual(myItem, myPlayer.Locate("shovel"));
            Assert.IsTrue(myPlayer.Inventory.HasItem("shovel"));
        }

        [TestMethod]
        public void PlayerLocateItself()
        {
            Assert.AreEqual(myPlayer, myPlayer.Locate("me"));
        }

        [TestMethod]
        public void PlayerLocatesNothing()
        {
            Assert.AreNotEqual(myItem, myPlayer.Locate("shovel"));
            Assert.IsFalse(myPlayer.Inventory.HasItem("shovel"));
        }

        [TestMethod]
        public void PlayerFullDesc()
        {
            myPlayer.Inventory.Put(myItem);
            myPlayer.Inventory.Put(myItem1);

            Assert.AreEqual("You are connor the programmer\nYou are carrying\n\ta shovel (shovel)\n\ta sword (sword)", myPlayer.FullDescription);
        }
    }
}
