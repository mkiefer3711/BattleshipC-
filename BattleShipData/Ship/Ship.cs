using System;

// Define a namespace named Battleship to encapsulate the related classes
namespace Battleship
{
    // Defining a struct named Position to represent the X and Y coordinates
    public struct Position
    {
        public int X;
        public int Y;
    }

    // Defining an enumeration named Direction to represent ship orientations
    public enum Direction
    {
        Horizontal, Vertical
    }
    // Define an abstract class named Ship, which serves as a base class for different ship types
    abstract public class Ship
    {
        // Private fields to store ship information
        private Position[] positions;
        private readonly int length;
        private readonly ConsoleColor color;
        // Public field indicating whether the ship is sunk
        public bool sunk;

        // Defining a virtual property to identify whether the ship is a battleship
        public virtual bool IsBattleShip { get; private set; }

        // Property to get the ship's positions
        public Position[] GetPositions
        {
            get
            {
                return this.positions;
            }
        }
        // Constructor to initialize the ship with length and color
        public Ship(int length, ConsoleColor color)
        {
            this.length = length;
            this.color = color;
            sunk = false;
            this.positions = new Position[length];
        }
        // Method to get the length of the ship
        public int GetLength()
        {
            return this.length;
        }
        // Method to get the color of the ship.
        public ConsoleColor GetConsoleColor()
        {
            return this.color;
        }
        // Virtual method to reset the ship's positions and mark it as not sunk
        public virtual void Reset()
        {
            this.positions = new Position[length];
            this.sunk = false;
        }
        // Method to give the ship coordinates based on the start position and direction
        public void Place(Position start, Direction direction)
        {
            for (int i = 0; i < this.length; i++)
            {
                if (direction == Direction.Horizontal)
                {
                    // Calculate the new position based on the ship's orientation
                    Position newPosition = new()
                    {
                        X = start.Y,
                        Y = start.X + i
                    };
                    this.positions[i] = newPosition;
                }
                else
                {
                    Position newPosition = new()
                    {
                        X = start.Y + i,
                        Y = start.X
                    };
                    this.positions[i] = newPosition;
                }
            }
        }
    }
}