using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_1
{
    public class Player : GameObj, IHaveInventory
    {
        private Inventory _inventory = new Inventory();

        public Player(string name, string desc)
            : base(new string[] {"me", "inventory"}, name, desc)
        {
           
        }

        public GameObj Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id);
            }
           
        }

        public override string FullDescription
        {
            get
            {
                string desc;
                desc = "You are " + Name + " " + base.FullDescription + "\nYou are carrying" + Inventory.ItemList;
                
                return desc;
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }
        

    }
}
