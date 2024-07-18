using System;

// Define a namespace named Battleship to encapsulate the related classes
namespace Battleship
{
    // Defining a class named BattleShip, which inherits from the Ship class
    public class BattleShip : Ship
    {
        // Override the IsBattleShip property from the base class to always return true for battleships
        public override bool IsBattleShip { get { return true; } }

        // Constructor for the BattleShip class, which calls the base class constructor with a length of 4 and a yellow color
        public BattleShip() : base(4, ConsoleColor.Yellow)
        {
            // Any additional logic can be added here but none is needed for the moment
        }
    }
}
