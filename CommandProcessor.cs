using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        private List<Command> _commands;

        public CommandProcessor() 
        {
            _commands = new List<Command>();
        }

        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }

        public string Execute(Player player, string[] playerCommand)
        {
            string keyword = playerCommand[0].ToLower();

            foreach (Command command in _commands)
            {
                if (command.AreYou(keyword))    
                {
                    return command.Execute(player, playerCommand);
                }
            }

            return $"Command '{keyword}' not found.";
        }
    }
}
