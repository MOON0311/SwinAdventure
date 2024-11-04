using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] { "move", "go", "head", "leave" }) { }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length != 2 || !AreYou(text[0]))
            {
                return "I don't know how to move like that!";
            }
           
            string direction = text[1].ToLower();

            Path path = p.CurrentLocation.GetPath(direction);

            if (path != null)
            {
                path.MovePlayer(p);
                return $"You move {direction} to {p.CurrentLocation.Name}.";
            }
            else
            {
                return $"There is no path to move {direction}.";
            }
        }
    }

}
