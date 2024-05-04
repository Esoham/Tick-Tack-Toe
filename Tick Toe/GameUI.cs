using System;
namespace Tick_Toe
{
    public class GameUI
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to Tic Tac Toe!");
        }

        public static void DisplayBoard(char[,] board)
        {
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static (int, int) GetUserMove(GameLogic gameLogic)
        {
            Console.WriteLine("Enter your move (row, column):");
            while (true)
            {
                string? input = Console.ReadLine();  // Accept input as potentially nullable
                if (input != null)  // Check for null to safely use the split method
                {
                    string[] parts = input.Split(',');
                    if (parts.Length == 2
                        && int.TryParse(parts[0], out int row) && row >= 0 && row < Constants.GRID_SIZE
                        && int.TryParse(parts[1], out int col) && col >= 0 && col < Constants.GRID_SIZE)
                    {
                        if (gameLogic.Board[row, col] == '-')  // Access Board using the passed GameLogic instance
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

        public static void DisplayResult(char winner)
        {
            if (winner == Constants.TIE_SYMBOL)
                Console.WriteLine("The game is a tie!");
            else
                Console.WriteLine($"Player {winner} wins!");
        }
    }
}