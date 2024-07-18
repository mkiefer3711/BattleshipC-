// Author: Maddison Kiefer
// Class: C# Programming
// This program is ised to store information about five different types of ships,
// such as thier length, position, direction, and if they are sunk or not.

using System;

// Define a namespace named Battleship to encapsulate the related classes
namespace Battleship
{
    // Defining a class named Test to demonstrate using the different ship classes
    public class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise the Ship class and 5 descendent ships");

            // Create a new position with X and Y coordinates set to 0
            Position newPosition = new Position();
            newPosition.X = 0; 
            newPosition.Y = 0;

            // Create an instance of the AircraftCarrier class
            AircraftCarrier ac = new AircraftCarrier();
            Console.ForegroundColor = ac.GetConsoleColor();

            // Place the aircraft carrier horizontally at the specified position
            ac.Place(newPosition, Direction.Horizontal);

            // Display information about the aircraft carrier
            Console.WriteLine("\nKind: " + ac.GetType().Name);
            Console.Write("Coordinates: ");

            // Display the coordinates of each position that the aircraft carrier occupies
            for (int k = 0; k < ac.GetLength(); k++)
            {
                Console.Write(ac.GetPositions[k].X + "," + ac.GetPositions[k].Y + "  ");
            }

            // Display additional information about the aircraft carrier
            Console.WriteLine("\nLength: " + ac.GetLength());
            Console.WriteLine("Sunk: " + ac.sunk);
            Console.WriteLine("isBattleship: " + ac.IsBattleShip);
            // Reset the state of the aircraft carrier
            ac.Reset();

            // Update the position for the next ship
            newPosition.X = 3; 
            newPosition.Y = 1;

            // Create an instance of the BattleShip class
            BattleShip bs = new BattleShip();
            Console.ForegroundColor = bs.GetConsoleColor();

            // Place the battleship vertically at the specified position
            bs.Place(newPosition, Direction.Vertical);

            // Display information about the battleship
            Console.WriteLine("\nKind: " + bs.GetType().Name);
            Console.Write("Coordinates: ");

            // Display the coordinates of each position that the battleship occupies
            for (int k = 0; k < bs.GetLength(); k++)
            {
                Console.Write(bs.GetPositions[k].X + "," + bs.GetPositions[k].Y + "  ");
            }

            // Display additional information about the battleship
            Console.WriteLine("\nLength: " + bs.GetLength());
            Console.WriteLine("Sunk: " + bs.sunk);
            Console.WriteLine("isBattleship: " + bs.IsBattleShip);
            // Reset the state of the battleship
            ac.Reset();

            // Update the position for the next ship
            newPosition.X = 7; 
            newPosition.Y = 6;

            // Create an instance of the Destroyer class
            Destroyer ds = new Destroyer();
            Console.ForegroundColor = ds.GetConsoleColor();

            // Place the destroyer vertically at the specified position
            ds.Place(newPosition, Direction.Vertical);

            // Display information about the destroyer
            Console.WriteLine("\nKind: " + ds.GetType().Name);
            Console.Write("Coordinates: ");

            // Display the coordinates of each position that the destroyer occupies
            for (int k = 0; k < ds.GetLength(); k++)
            {
                Console.Write(ds.GetPositions[k].X + "," + ds.GetPositions[k].Y + "  ");
            }

            // Display additional information about the destroyer
            Console.WriteLine("\nLength: " + ds.GetLength());
            Console.WriteLine("Sunk: " + ds.sunk);
            Console.WriteLine("isBattleship: " + ds.IsBattleShip);
            // Reset the state of the destroyer
            ac.Reset();

            // Update the position for the next ship
            newPosition.X = 4; 
            newPosition.Y = 4;

            // Create an instance of the PatrolBoat class
            PatrolBoat pb = new PatrolBoat();
            Console.ForegroundColor = pb.GetConsoleColor();

            // Place the patrol boat horizontally at the specified position
            pb.Place(newPosition, Direction.Horizontal);

            // Display information about the patrol boat
            Console.WriteLine("\nKind: " + pb.GetType().Name);
            Console.Write("Coordinates: ");

            // Display the coordinates of each position that the patrol boat occupies
            for (int k = 0; k < pb.GetLength(); k++)
            {
                Console.Write(pb.GetPositions[k].X + "," + pb.GetPositions[k].Y + "  ");
            }

            // Display additional information about the patrol boat
            Console.WriteLine("\nLength: " + pb.GetLength());
            Console.WriteLine("Sunk: " + pb.sunk);
            Console.WriteLine("isBattleship: " + pb.IsBattleShip);
            // Reset the state of the patrol boat
            ac.Reset();

            // Update the position for the next ship
            newPosition.X = 0; 
            newPosition.Y = 7;

            // Create an instance of the Submarine class
            Submarine sub = new Submarine();
            Console.ForegroundColor = sub.GetConsoleColor();

            // Place the submarine vertically at the specified position
            sub.Place(newPosition, Direction.Vertical);

            // Display information about the submarine
            Console.WriteLine("\nKind: " + sub.GetType().Name);
            Console.Write("Coordinates: ");

            // Display the coordinates of each position that the submarine occupies
            for (int k = 0; k < sub.GetLength(); k++)
            {
                Console.Write(sub.GetPositions[k].X + "," + sub.GetPositions[k].Y + "  ");
            }

            // Display additional information about the submarine
            Console.WriteLine("\nLength: " + sub.GetLength());
            Console.WriteLine("Sunk: " + sub.flag);
            Console.WriteLine("isBattleship: " + sub.IsBattleShip);
            // Reset the state of the submarine
            ac.Reset();

            // User needs to press 'enter' to end the application
            Console.Write("\nPress [Enter]");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                
        }
    }
}
