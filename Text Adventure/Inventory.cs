using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_1
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public Inventory()
        {
            
        }

        public bool HasItem(string id)
        {
            foreach(Item s in _items)
            {
                if(s.FirstId == id)
                {
                    return true;
                }
              
            }
            return false;
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach(Item s in _items)
            {
                if (id == s.FirstId)
                {
                    _items.Remove(s);
                    return s;
                }
            }
            return null; // null execption;
        }

        public Item Fetch(string id)
        {
            foreach(Item s in _items)
            {
                if (s.AreYou(id))
                {
                    return s;
                }
            }
            return null;
            //return _items.Find(x => x.AreYou(id));
        }

        public string ItemList
        {
            get
            {
                string mylist = "";
                foreach(Item item in _items)
                {
                    mylist += "\n\t" + (item.ShortDescription);
                }
                return mylist;
            }
        }
    }
}
