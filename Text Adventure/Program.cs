using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iteration_1;

namespace Iteration5
{
    class Program
    {
        static void Main(string[] args)
        {
            string _playerName;
            string _playerDesc;

            Console.WriteLine("Please enter your player name");
            _playerName = Console.ReadLine();
            Console.WriteLine("Please describe your player");
            _playerDesc = Console.ReadLine();

            Player myPlayer = new Player(_playerName, _playerDesc);

            Item myShovel = new Item(new string[] { "shovel", "spade" }, "a shovel", "this is a mighty fine shovel");
            Item mySword = new Item(new string[] { "sword", "claymore" }, "a sword", "this is a mighty fine sword");
            myPlayer.Inventory.Put(myShovel);
            myPlayer.Inventory.Put(mySword);
            Bag myBag = new Bag(new string[] { "bag", "rucksack" }, "leather bag", "this is a good bag");
            myPlayer.Inventory.Put(myBag);
            Item myGem = new Item(new string[] { "gem", "sparkly rock" }, "a gem", "this is a sparkly gem");
            myBag.Inventory.Put(myGem);


            LookCommand myCommand = new LookCommand();
            string[] myString;

            while (Console.ReadLine() !=  "exit")
            {
                Console.WriteLine("Please enter a command");
                myString = Console.ReadLine().Split(' ');
                Console.WriteLine(myCommand.Execute(myPlayer, myString));
            }
        }

    }
}

