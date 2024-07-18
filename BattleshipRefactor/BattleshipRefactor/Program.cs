// BattleshipRefactor -- A refactoring of BattleshipSimple

using System;


namespace BattleshipSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Game of Battleship\n");
            // Recieves the size of the grid from the user
            Console.WriteLine("Specify the size of the grid (5-26) or 'quit': ");
            // Reads the input from the user
            var input = Console.ReadLine();
            // Checks if the user wants to quit
            if (input != "quit") 
            {
                // Checks that the user input is a valid integer
                if (int.TryParse(input, out int gridSize))
                {
                    // Creates a new Battleship game with the input grid size
                    var game = new BattleShipGame(gridSize);
                    ConsoleKeyInfo response;
                    do
                    {
                        // Resets the game for a new round
                        game.Reset();
                        // Plays the game
                        game.Play();

                        // Asks if the user wants to play again
                        Console.WriteLine("Do you want to play again (y/n)");
                        // Reads the users response
                        response = Console.ReadKey();
                        // Resets the color and clears the screen for the next game
                        Console.ResetColor();
                        Console.Clear();

                    } while (response.Key == ConsoleKey.Y);
                }
            }
        }
    }
}
