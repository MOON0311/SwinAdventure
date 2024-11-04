using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items = new List<Item>();

        public bool HasItem(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
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
            Item itm = Fetch(id);
            if (itm != null)
            {
                _items.Remove(itm);
            }
            return itm;
        }

        public Item Fetch(string id)
        {
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    return itm;
                }
            }
            return null;
        }

        public string ItemList 
        {
            get
            {
                StringBuilder itemList = new StringBuilder();
                foreach (Item itm in _items)
                {
                    itemList.AppendLine(itm.ShortDescription);
                }
                return itemList.ToString();
            }
        }
    }
}
