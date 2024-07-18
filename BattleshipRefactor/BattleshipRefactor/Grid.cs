// BattleshipRefactor -- A refactoring of BattleshipSimple
//
// Creates the grid for the game, adds ships to the grid, detects if there are ships left, displays hit and miss markers,
// and sets the colors for the ships

using System;

namespace BattleshipSimple
{
    internal class Grid
    {
        // Variables to store the grid size, the grid, and the number of ships
        public int gridSize;
        private char[,] grid;
        private int numShips;

        public Grid(int size)
        {
            // Initializes the grid with a specified size
            gridSize = size;
            grid = new char[size, size];
            numShips = 5;

            // Calls InitializeGrid and AddShips methods
            InitializeGrid();
            AddShips();
            
        }

        private void InitializeGrid()
        {
            // Sets all of the grid cells to empty spaces
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    grid[i, j] = ' ';
                }
            }
        }
        public void Draw()
        {
            // Display the letters horizontally
            Console.Write("   | ");
            for (int i = 0; i < gridSize; i++)
            {
                Console.Write(Convert.ToChar('A' + i) + " | ");
            }
            Console.WriteLine();

            // Draw the horizontal separator line
            Console.Write("---#");
            for (int i = 0; i < gridSize; i++)
            {
                Console.Write("---#");
            }
            Console.WriteLine();

            // Loop to display the numbers vertically
            for (int i = 0; i < gridSize; i++)
            {
                Console.Write($"{i + 1:D2} ");

                // Iterates through each cell in the row
                for (int j = 0; j < gridSize; j++)
                {
                    // Calls ShipColors to display the cell contents
                    ShipColors(grid[i, j]);
                }
                Console.Write("|");
                Console.WriteLine();

                // Draw the horizontal separator line
                Console.Write("---#");
                for (int j = 0; j < gridSize; j++)
                {
                    Console.Write("---#");
                }
                Console.WriteLine();
            }
        }

        public void DropBomb(int x, int y)
        {
            // Checks that the coordinates are valid
            if (x < 0 || x >= gridSize || y < 0 || y >= gridSize)
            {
                Console.WriteLine("Invalid coordinates. Please try again.");
                return;
            }

            // Handles hit and miss markers as well as hitting the same spot again
            if (grid[x, y] != ' ' && grid[x, y] != 'H' && grid[x, y] != 'M')
            {
                grid[x, y] = 'H'; // 'X'
                Console.WriteLine("\nHit!");
            }
            else if (grid[x, y] == ' ')
            {
                grid[x, y] = 'M'; // 'O'
                Console.WriteLine("\nMiss!");
            }
            else
            {
                Console.WriteLine("\nYou already hit this spot!");
            }
        }

        public void Reset()
        {
            // Resets the grid and adds ships
            InitializeGrid();
            AddShips();
        }

        private void AddShips()
        {
            // Defining the ship types and sizes of the.
            char[]  ships = new char[] { 'A', 'B', 'D', 'S', 'P' };
            int[]  shipSizes = new int[] { 5, 4, 3, 3, 2 };
            Random random = new Random();
            for (int i = 0; i < numShips; i++)
            {
                // Randomly places ships on the grid
                int x = random.Next(gridSize);
                int y = random.Next(gridSize);
                if (x + shipSizes[i] > gridSize)
                {
                    i--;
                    continue;
                }

                // Checks how many blank spaces are available next to eachother
                var blank = 0;
                for (int j = 0; j < shipSizes[i]; j++)
                {
                    if (grid[x + j, y] == ' ')
                    {
                        blank++;
                    }
                }
                // If the amount of blank spaces equals the ship size, it will put the ship in those spaces
                if (blank == shipSizes[i])
                {
                    for (int j = 0; j < shipSizes[i]; j++)
                    {
                        grid[x + j, y] = ships[i];
                    }
                }
                else
                {
                    i--;
                }

            }

        }

        public bool HasShipsLeft
        {
            // Checks if there are any ships left on the grid
            get
            {
                for (int i = 0; i < gridSize; i++)
                {
                    for (int j = 0; j < gridSize; j++)
                    {
                        if (grid[i, j] != ' ' && grid[i, j] != 'H' && grid[i, j] != 'M')
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        // Defines the colors and symbols for the different cells
        public static void ShipColors(char display)
        {
            //Switch statement for displaying colors and markings for different cases
            switch (display)
            {
                case '.':
                    Console.Write("|   ");
                    break;
                case 'A':
                    Console.Write("|");
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" A ");
                    break;
                case 'B':
                    Console.Write("|");
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" B ");
                    break;
                case 'D':
                    Console.Write("|");
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" D ");
                    break;
                case 'P':
                    Console.Write("|");
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" P ");
                    break;
                case 'S':
                    Console.Write("|");
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" S ");
                    break;
                case 'H':
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" X ");
                    break;
                case 'M':
                    Console.Write("|");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" X ");
                    break;
                default:
                    Console.Write("|   ");
                    break;
            }
            Console.ResetColor();
        }

        public void WinScreen()
        {
            // If no ships are on the grid, the WinScreen will be displayed
            if (HasShipsLeft == false)
            {
                Console.Clear();
                ConsoleColor newForeColor = ConsoleColor.White;
                ConsoleColor newBackColor = ConsoleColor.DarkMagenta;
                Console.ForegroundColor = newForeColor;
                Console.BackgroundColor= newBackColor;
                Console.WriteLine("\nCongratulations!!!!!!");
                Console.WriteLine("\nYou have sunk all of the ships\n\n");
            }
        }
    }
}