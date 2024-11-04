using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Location : GameObject
    {
        private Inventory _inventory;
        private Dictionary<string, Path> _paths;

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
            _paths = new Dictionary<string, Path>();
        }

        public override string FullDescription
        {
            get { return $"{base.FullDescription}\nItems: {_inventory.ItemList}"; }
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            GameObject itemFound = _inventory.Fetch(id);

            return itemFound;
        }

        public void AddItem(Item item)
        {
            _inventory.Put(item);
        }

        public void AddPath(string direction, Path path)
        {
            _paths[direction] = path;
        }

        public Dictionary<string, Path> GetAvailablePaths()
        {
            return _paths;
        }

        public Path GetPath(string direction)
        {
            if (_paths.ContainsKey(direction))
            {
                return _paths[direction];
            }
            return null;
        }

        public Inventory Inventory
        {
            get { return _inventory; }
        }

    }
}
