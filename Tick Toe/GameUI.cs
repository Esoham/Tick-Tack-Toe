using System;
using Tick_Toe;
public static class GameUI
{
    // Method to display the game board
    public static void DisplayBoard(GameLogic gameLogic)
    {
        for (int i = 0; i < Constants.GRID_SIZE; i++)
        {
            for (int j = 0; j < Constants.GRID_SIZE; j++)
            {
                Console.Write(gameLogic.Board[i, j] + " ");
            }
            Console.WriteLine(); // Move to the next line after each row
        }
    }

    // Method to get user move
    public static (int, int) GetUserMove(GameLogic gameLogic)
    {
        Console.WriteLine("Enter your move (row, column):");
        while (true)
        {
            string? input = Console.ReadLine();
            if (input != null)
            {
                string[] parts = input.Trim().Split(',');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0].Trim(), out int row) && row >= 0 && row < Constants.GRID_SIZE &&
                    int.TryParse(parts[1].Trim(), out int col) && col >= 0 && col < Constants.GRID_SIZE)
                {
                    if (gameLogic.Board[row, col] == '-')
                    {
                        return (row, col);
                    }
                    else
                    {
                        Console.WriteLine("This spot is already taken, please choose another.");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter row and column as two numbers separated by a comma, each between 0 and {Constants.GRID_SIZE - 1}.");
                }
            }
            else
            {
                Console.WriteLine("No input provided. Please try again:");
            }
        }
    }
}
