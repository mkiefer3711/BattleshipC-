using System;

public class Grid
{
    private readonly char[,] grid;
    private readonly int size;

    public Grid(int gridSize)
	{
        size = gridSize;
        grid = new char[size, size];
        Reset();
        GenerateShips();
    }

    public void Reset()
    {
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                grid[i, j] = '.';
            }
        }
    }

    public void Draw()
    {
        Console.WriteLine("   | A | B | C | D | E | F | G | H | I | J |");
        Console.WriteLine("---#---#---#---#---#---#---#---#---#---#---#");

        for (int i = 0; i < size; i++)
        {
            if (i == 9)
            {
                Console.Write($"{i + 1} ");
            }
            else
            {
                Console.Write($" {i + 1} ");
            }

            for (int j = 0; j < size; j++)
            {
                ShipColors(grid[i, j]);
            }

            Console.Write("|\r\n");
            Console.WriteLine("---#---#---#---#---#---#---#---#---#---#---#");
        }
    }

    public void DropBomb(int x, int y)
    {
        if (x >= 0 && x < size && y >= 0 && y < size)
        {
            char cellContent = grid[y, x];
            if (cellContent == '.')
            {
                grid[y, x] = 'M';
                Console.WriteLine("\nMiss!");
            }
            else
            {
                grid[y, x] = 'H';
                Console.WriteLine("\nHit!");
            }
        }
        else
        {
            Console.WriteLine("Invalid coordinates.");
        }
    }

    public bool HasShipsLeft
    {
        get
        {
            foreach (char cell in grid)
            {
                if (cell == 'A' || cell == 'B' || cell == 'P' || cell == 'S')
                {
                    return true;
                }
            }
            return false;
        }
    }

    private void ShipColors(char display)
    {
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
}
