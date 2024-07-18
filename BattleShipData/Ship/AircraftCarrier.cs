using System;

// Define a namespace named Battleship to encapsulate the related classes
namespace Battleship
{
    // Defining a class named AircraftCarrier, which inherits from the Ship class
    public class AircraftCarrier : Ship
    {
        // Constructor for the AircraftCarrier class, which calls the base class constructor with a length of 5 and a red color
        public AircraftCarrier() : base(5, ConsoleColor.Red)
        {
            // Any additional logic can be added here but none is needed for the moment
        }
    }
}
