// BattleshipRefactor -- A refactoring of BattleshipSimple

using System;

namespace BattleshipSimple
{
    internal class BattleShipGame
    {
        private Grid grid;

        public BattleShipGame(int gridSize)
        {
            // Initialize a new grid with the specified size
            grid = new Grid(gridSize);

        }

        internal void Reset()
        {
            // Calls method to reset the grid
            grid.Reset();
        }

        internal void Play()
        {
            while (grid.HasShipsLeft)
            {
                // Draws the current state of the grid
                grid.Draw();

                //Read input from user
                int x, y;
                Console.WriteLine("\nDrop bomb at location (ex. B9), or type quit to exit: ");
                string input = Console.ReadLine();
                input = input.ToUpper();

                // If the user enters quit, the program will exit
                if (input == "QUIT")
                {
                    return;
                }

                if (input.Length >= 2)
                {
                    // Get the column character from the input
                    char column = input[0];
                    // Get the row number string from the input
                    string rowNumStr = input.Substring(1);

                    // Checks if the first character is a letter and the remaining is a valid integer
                    if (Char.IsLetter(column) && Int32.TryParse(rowNumStr, out x))
                    {
                        x = x - 1;
                        // Checks that the row number is within the valid range
                        if (x >= 0 && x <= grid.gridSize)
                        {
                             y = column - 'A';

                            // Checks that the column index is within the valid range
                            if (y >= 0 && y < grid.gridSize)
                            {
                                // Drop a bomb at the specified location
                               grid.DropBomb(x, y);
                            }
                            else
                            {
                                // Prompts the user to enter another input if the form is invalid
                                Console.WriteLine("Please enter a valid position (ex. B9).");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid position (ex. B9).");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, enter a valid position (ex. B9).");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, enter a valid position (ex. B9).");
                }
            }
            // Draws the final state of the grid and displays the win screen
            grid.Draw();
            grid.WinScreen();
        }
    }
}
