using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_1
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory = new Inventory();

        public Bag(string[] ids, string name, string desc)
            : base(ids, name, desc)
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
                desc = "In the " + Name + " you can see:" + Inventory.ItemList;

                return desc;
            }
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

    }
}
