using System;

namespace BattleshipSimple
{
    class Program
    {

        private static readonly char[,] Grid = new char[,]
        {
            {'.', '.', '.', '.', 'S', 'S', 'S', '.', '.', '.'},
            {'P', 'P', '.', '.', '.', '.', '.', '.', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '.', '.', 'P'},
            {'.', '.', '.', '.', '.', '.', '.', '.', '.', 'P'},
            {'.', '.', 'A', 'A', 'A', 'A', 'A', '.', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', 'B', '.', '.'},
            {'.', 'S', '.', '.', '.', '.', '.', 'B', '.', '.'},
            {'.', 'S', '.', '.', '.', '.', '.', 'B', 'P', 'P'},
            {'.', 'S', '.', '.', '.', '.', '.', 'B', '.', '.'},
            {'.', '.', '.', '.', '.', '.', '.', '.', '.', '.'},
        };

        // Displaying the grid with the correct formatting
        public static void DisplayGrid(char[,] Grid)
        {
            // Displays the letters horizontally
            Console.WriteLine("   | A | B | C | D | E | F | G | H | I | J |");
            Console.WriteLine("---#---#---#---#---#---#---#---#---#---#---#");
            
            // Loop to display the numbers vertically
            for (int i = 0; i < 10; i++)
            {
                if (i == 9)
                {
                    Console.Write("{0} ", i + 1);
                }
                else
                    Console.Write(" {0} ", i + 1);

                // Iterates through each cell in the row
                for (int j = 0; j < 10; j++)
                {
                    // Calls ShipColors to display the cell contents
                    ShipColors(Grid[i, j]);
                }
                Console.Write("|\r\n");
                Console.WriteLine("---#---#---#---#---#---#---#---#---#---#---#");
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
            }
            Console.ResetColor();
        }

        // Main function
        static void Main(string[] args)
        {
            while (true)
            {
                // Displays the grid
                DisplayGrid(Grid);

                // Prompts and receives the user input
                Console.WriteLine("Type 'quit' to exit.");
                Console.WriteLine("Enter your guess (ex. A1, B9, G4): ");
                string input = Console.ReadLine();
                input = input.ToUpper();

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
                    if (Char.IsLetter(column) && Int32.TryParse(rowNumStr, out int row))
                    {
                        // Checks that the row number is within the valid range
                        if (row >= 1 && row <= 10)
                        {
                            int col = column - 'A';

                            // Checks that the column index is within the valid range
                            if (col >= 0 && col < 10)
                            {
                                char cellContent = Grid[row - 1, col];

                                // Checks if the cell is empty
                                if (cellContent == '.')
                                {
                                    Grid[row - 1, col] = 'M';
                                    Console.WriteLine("\nMiss!");
                                }
                                else
                                {
                                    Grid[row - 1, col] = 'H';
                                    Console.WriteLine("\nHit!");
                                }
                            }
                            else
                            {
                                // Prompts the user to enter another input if the form is invalid
                                Console.WriteLine("Please enter a valid position (ex. A1, B9, G4).");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid position (ex. A1, B9, G4).");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input, enter a valid position (ex. A1, B9, G4).");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, enter a valid position (ex. A1, B9, G4).");
                }
            }
            
        }
    }
}
