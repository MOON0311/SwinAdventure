using System;
using SplashKitSDK;

namespace SwinAdventure
{
    public class Program
    {
        public static void Main()
        {
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            Console.Write("Enter your player description (student ID): ");
            string playerDescription = Console.ReadLine();

            Player player = new Player(playerName, playerDescription);

            Item phone = new Item(new string[] { "phone" }, "Phone", "iPhone 13 Pro Max");
            Item laptop = new Item(new string[] { "laptop" }, "Laptop", "Asus Zenbook S13");
            player.Inventory.Put(phone);
            player.Inventory.Put(laptop);

            Bag bag = new Bag(new string[] { "bag" }, "Backpack", "a black backpack");
            player.Inventory.Put(bag);

            Item tablet = new Item(new string[] { "tablet" }, "Tablet", "iPad Mini");
            bag.Inventory.Put(tablet);

            Location classroom = new Location(new string[] { "classroom" }, "Classroom", "EN305");
            Location library = new Location(new string[] { "library" }, "Library", "Library with lots of boooks");
            Location hallway = new Location(new string[] { "hallway" }, "Hallway", "A long hallway.");
            Location staircase = new Location(new string[] { "staircase" }, "Staircase", "Stair to go up or down.");

            Item computer = new Item(new string[] { "computer" }, "Computer", "computer for student");
            Item whiteboard = new Item(new string[] { "whiteboard" }, "Whiteboard", "whiteboard for tutor");
            classroom.AddItem(computer);
            classroom.AddItem(whiteboard);

            Item locker = new Item(new string[] { "locker" }, "Locker", "lockers for student");
            hallway.AddItem(locker);

            Path pathToHallway = new Path(new string[] { "north" }, "North Path", "North path to the hallway.", hallway);
            Path pathToLibrary = new Path(new string[] { "south" }, "South Path", "South path to the library.", library);
            Path pathToClassroom = new Path(new string[] { "south" }, "South Path", "South path to the classroom.", classroom);
            Path pathToStaircase = new Path(new string[] { "east" }, "East Path", "East path to the staircase.", staircase);

            classroom.AddPath("north", pathToHallway);
            classroom.AddPath("south", pathToLibrary);
            hallway.AddPath("south", pathToClassroom);
            hallway.AddPath("east", pathToStaircase);

            player.MoveToLocation(classroom);

            LookCommand look = new LookCommand();
            MoveCommand move = new MoveCommand();

            CommandProcessor commandProcessor = new CommandProcessor();
            commandProcessor.AddCommand(look);
            commandProcessor.AddCommand(move);

            while (true)
            {
                Console.WriteLine("Enter command: (e.g., 'look at (item)', 'look at (item) in bag', 'look at location', move 'direction')");
                string command = Console.ReadLine();

                string[] formattedCommand = command.ToLower().Split(" ");

                if (formattedCommand[0] == "exit")
                {
                    Console.WriteLine("Exiting game.");
                    break;
                }

                Console.WriteLine(commandProcessor.Execute(player, formattedCommand));
            }

        }

    }
}
