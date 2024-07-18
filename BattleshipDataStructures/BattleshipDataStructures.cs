// BattleshipDataStructures.cs - Partial Sample Solution
// CS3110 - C# Programming
// November 20, 2022

// Module 3 - Ship Classes, OO Design Programming Assignment

using System;

namespace BattleshipDataStructures
{
    class BattleshipDataStructures
    {
        // Set up the various kinds of ships
        private static readonly Ship[] ships = { new PatrolBoat(), new Submarine(), new Destroyer(),
                                                 new Battleship(), new AircraftCarrier() };

        // Our program starts here
        static void Main(string[] args)
        {
            Console.WriteLine("\nBattleship Data Structures");
            Console.WriteLine("==========================\n");

            Console.WriteLine("The Five Different Kinds of Ships Are\n");
            foreach (Ship s in ships)
            {
                Console.WriteLine(s.ToString());
            }

            // Place one ship of each type
            int y = 1;
            foreach (Ship s in ships)
            {
                s.Place(new Position(1, y++), Direction.Horizontal);
            }

            // Test various functional aspects
            ShowPositions("Initially");
            ships[1].Reset();
            ships[3].Reset();
            ShowPositions("After 2 Resets (Submarine + Battleship)");
            Console.WriteLine();

            Attack(1, 1); Attack(2, 1);
            Attack(1, 5); Attack(3, 5); Attack(5, 5);
            ShowPositions("After 5 Attacks (Patrol Boat + Aircraft Carrier");
            Attack(2, 5); Attack(4, 5);
            ShowPositions("After 2 More Attacks (Aircraft Carrier)");

            Console.WriteLine("\nEnd Battleship Data Structures Test\n");
            Console.WriteLine("Press [Enter]");
            Console.ReadLine();
        } // end Main()

        // Display the positions (and properties) of all ships
        static void ShowPositions(string ttl)
        {
            Console.WriteLine("\nShip Positions {0}\n", ttl);
            foreach (Ship s in ships)
            {
                Console.Write("{0,-15}  ", s.ShipType);
                Position[] positions = s.Positions;
                if (positions != null)
                {
                    Console.Write("Sunk={0,-5}", s.Sunk);
                    foreach (Position p in positions)
                    {
                        Console.Write("  {0},{1}:{2}", p.X, p.Y, p.Hit);
                    }
                }
                else
                    Console.Write("none");
                Console.WriteLine();
            }
        } // end ShowPositions()

        // Attack any ship located at (x,y)
        static HitOrMiss Attack(int x, int y)
        {
            HitOrMiss hm = HitOrMiss.Miss;
            foreach (Ship s in ships)
            {
                hm = s.Attack(x, y);
                if (hm == HitOrMiss.Hit)
                    break;
            }
            return hm;
        } // end Attack()

    } // end class BattleshipDataStructures

} // end namespace BattleshipDataStructures


/* ===== Runtime Output =====

Battleship Data Structures
==========================

The Five Different Kinds of Ships Are

Type=PatrolBoat       Length=2  Color=White      IsBS=False
Type=Submarine        Length=3  Color=Cyan       IsBS=False
Type=Destroyer        Length=3  Color=DarkRed    IsBS=False
Type=Battleship       Length=4  Color=DarkGreen  IsBS=True
Type=AircraftCarrier  Length=5  Color=Blue       IsBS=False

Ship Positions Initially

PatrolBoat       Sunk=False  1,1:False  2,1:False
Submarine        Sunk=False  1,2:False  2,2:False  3,2:False
Destroyer        Sunk=False  1,3:False  2,3:False  3,3:False
Battleship       Sunk=False  1,4:False  2,4:False  3,4:False  4,4:False
AircraftCarrier  Sunk=False  1,5:False  2,5:False  3,5:False  4,5:False  5,5:False

Ship Positions After 2 Resets (Submarine + Battleship)

PatrolBoat       Sunk=False  1,1:False  2,1:False
Submarine        none
Destroyer        Sunk=False  1,3:False  2,3:False  3,3:False
Battleship       none
AircraftCarrier  Sunk=False  1,5:False  2,5:False  3,5:False  4,5:False  5,5:False

Ship Positions After 5 Attacks (Patrol Boat + Aircraft Carrier

PatrolBoat       Sunk=True   1,1:True  2,1:True
Submarine        none
Destroyer        Sunk=False  1,3:False  2,3:False  3,3:False
Battleship       none
AircraftCarrier  Sunk=False  1,5:True  2,5:False  3,5:True  4,5:False  5,5:True

Ship Positions After 2 More Attacks (Aircraft Carrier)

PatrolBoat       Sunk=True   1,1:True  2,1:True
Submarine        none
Destroyer        Sunk=False  1,3:False  2,3:False  3,3:False
Battleship       none
AircraftCarrier  Sunk=True   1,5:True  2,5:True  3,5:True  4,5:True  5,5:True

End Battleship Data Structures Test

===== End Runtime Output ===== */
