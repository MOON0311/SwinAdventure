using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory = new Inventory();
        private Location _location;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {

        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            GameObject itemFound = _inventory.Fetch(id);

            if (itemFound != null)
            {
                return itemFound;
            }

            if (_location != null)
            {
                itemFound = _location.Locate(id);

                if (itemFound != null)
                {
                    return itemFound;
                }
            }
            return null;
        }
            
        public void MoveToLocation(Location newLocation)
        {
            _location = newLocation;
        }

        public GameObject LocateInInventory(string id)
        {
            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                string locationDescription = _location != null ? _location.Name : "nowhere";
                return $"{Name} {base.FullDescription}.\nYou are carrying\n{_inventory.ItemList}\nYou are in: {locationDescription}";
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location CurrentLocation
        {
            get { return _location; }
            set { _location = value; }
        }
    }
}
