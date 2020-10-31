using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iteration_1
{
    [TestClass]
    public class LookCommandTest
    {
        private Player myPlayer = new Player("Connor", "A programmer");
        private Bag myBag = new Bag(new string[] { "bag", "rucksack" }, "my bag", "this is a good bag");
        private Item myGem = new Item(new string[] { "gem", "jewel" }, "a gem", "This is a mighty fine gem");
        private LookCommand myCommand = new LookCommand();

        [TestMethod]
        public void LookAtMe()
        {
            myPlayer.Inventory.Put(myBag);
            myBag.Inventory.Put(myGem);

            Assert.AreEqual("You are Connor A programmer\nYou are carrying" + myPlayer.Inventory.ItemList, myCommand.Execute(myPlayer, new string[] { "look", "at", "me" }));
        }

        [TestMethod]
        public void LookAtGem()
        {
            myPlayer.Inventory.Put(myGem);

            Assert.AreEqual("This is a mighty fine gem", myCommand.Execute(myPlayer, new string[] { "look", "at", "gem", "in", "Inventory" }));
        }

        [TestMethod]
        public void LookAtUnk()
        {
            Assert.AreEqual("Cannot find gem", myCommand.Execute(myPlayer, new string[] { "look", "at", "gem", "in", "Inventory" }));
        }

        [TestMethod]
        public void LookAtGemInMe()
        {
            myPlayer.Inventory.Put(myGem);

            Assert.AreEqual("This is a mighty fine gem", myCommand.Execute(myPlayer, new string[] { "look", "at", "gem", "in", "inventory" }));
        }

        [TestMethod]
        public void LookAtGemInBag()
        {
            myPlayer.Inventory.Put(myBag);
            myBag.Inventory.Put(myGem);

            Assert.AreEqual("This is a mighty fine gem", myCommand.Execute(myPlayer, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [TestMethod]
        public void LookAtGemInNoBag()
        {
            Assert.AreEqual("Cannot find bag", myCommand.Execute(myPlayer, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [TestMethod]
        public void LookAtNoGemInBag()
        {
            myPlayer.Inventory.Put(myBag);

            Assert.AreEqual("Cannot find gem", myCommand.Execute(myPlayer, new string[] { "look", "at", "gem", "in", "bag" }));
        }

        [TestMethod]
        public void InvalidLook()
        {
            Assert.AreEqual("Invalid input", myCommand.Execute(myPlayer, new string[] { "Pick", "up", "my", "sword" }));
        }
    }
}
