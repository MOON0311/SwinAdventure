using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class Path : GameObject
    {
        private Location _destination;

        public Path(string[] ids, string name, string desc, Location destination) : base(ids, name, desc)
        {
            _destination = destination;
        }

        public void MovePlayer(Player player)
        {
            player.CurrentLocation = _destination;
        }

        public Location Destination
        {
            get { return _destination; }
            private set { _destination = value; }
        }
    }

}
