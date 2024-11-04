using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] {"look"})
        { 
        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 3 && text[2].ToLower() == "location")
            {
                return LookAtLocation(p);
            }

            if (text.Length != 3 && text.Length != 5)
            {
                return "I don't know how to look like that";
            }

            if (text[0] != "look")
            {
                return "Error in look input";
            }

            if (text[1] != "at")
            {
                return "What do you want to look at?";
            }

            string itemId = text[2];

            IHaveInventory container;

            if (text.Length == 3)
            {
                container = p;
            }
            else
            {
                if (text[3] != "in")
                {
                    return "What do you want to look in?";
                }

                string containerId = text[4];
                container = FetchContainer(p, containerId);
                if (container == null)
                {
                    return $"I cannot find the {containerId}.";
                }
            }

            return LookAtIn(itemId, container);
        }

        private string LookAtLocation(Player p)
        {
            if (p.CurrentLocation != null)
            {
                string description = p.CurrentLocation.FullDescription;

                Dictionary<string, Path> availablePaths = p.CurrentLocation.GetAvailablePaths();

                if (availablePaths.Count > 0)
                {
                    string directions = string.Join(", ", availablePaths.Keys);
                    description += $"\nAvailable directions: {directions}";
                }

                return description;
            }
            return "You are not in any location.";
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            GameObject container = p.Locate(containerId);
            if (container is IHaveInventory)
            {
                return container as IHaveInventory;
            }
            return null;
        }
        public string LookAtIn(string itemId, IHaveInventory container)
        {
            GameObject item = container.Locate(itemId);
            if (item == null)
            {
                if (container is Player)
                {
                    return $"I cannot find the {itemId}.";
                }
                else
                {
                    return $"I cannot find the {itemId} in the { container.Name}.";
                }
            }
            else
            {
                return item.FullDescription;
            }
        }

    }
}
