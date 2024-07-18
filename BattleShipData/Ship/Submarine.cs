using System;

// Define a namespace named Battleship to encapsulate the related classes
namespace Battleship
{
    // Defining a class named Submarine, which inherits from the Ship class
    public class Submarine : Ship
    {
        // Public field to indicate a flag with a default value of true
        public bool flag = true;

        // Constructor for the Submarine class, which calls the base class constructor with a length of 3 and a green color
        public Submarine() : base(3, ConsoleColor.Green)
        {
            // Any additional logic can be added here but none is needed for the moment
        }
    }
}
