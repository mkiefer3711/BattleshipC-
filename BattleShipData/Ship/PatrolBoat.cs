using System;

// Define a namespace named Battleship to encapsulate the related classes
namespace Battleship
{
    // Defining a class named PatrolBoat, which inherits from the Ship class
    public class PatrolBoat : Ship
    {
        // Constructor for the PatrolBoat class, which calls the base class constructor with a length of 3 and a white color
        public PatrolBoat() : base(3, ConsoleColor.White)
        {
            // Any additional logic can be added here but none is needed for the moment
        }
    }
}
