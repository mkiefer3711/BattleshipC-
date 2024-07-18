using System;

// Define a namespace named Battleship to encapsulate the related classes
namespace Battleship
{
    // Defining a class named Destroyer, which inherits from the Ship class
    public class Destroyer : Ship
    {
        // Constructor for the Destroyer class, which calls the base class constructor with a length of 2 and a magenta color
        public Destroyer() : base(2, ConsoleColor.Magenta)
        {
            // Any additional logic can be added here but none is needed for the moment
        }
    }
}
