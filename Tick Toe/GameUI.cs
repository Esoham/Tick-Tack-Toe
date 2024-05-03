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
            for (int i = 0; i < Constants.GridSize; i++)
            {
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[] GetUserMove()
        {
            Console.WriteLine("Enter your move (row, column):");
            int row, col;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out row) && row >= 0 && row < Constants.GridSize)
                {
                    if (Int32.TryParse(Console.ReadLine(), out col) && col >= 0 && col < Constants.GridSize)
                    {
                        return new int[] { row, col }; // Return valid move
                    }
                    else
                    {
                        Console.WriteLine("Invalid column. Please enter a number between 0 and " + (Constants.GridSize - 1) + ".");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid row. Please enter a number between 0 and " + (Constants.GridSize - 1) + ".");
                }
                Console.WriteLine("Please re-enter your move (row, column):");
            }
        }

        public static void DisplayResult(char winner)
        {
            if (winner == Constants.TieSymbol)
                Console.WriteLine("The game is a tie!");
            else
                Console.WriteLine($"Player {winner} wins!");
        }
    }

    public static class Constants
    {
        public const int GridSize = 3; // Size of the Tic Tac Toe grid
        public const char TieSymbol = 'T'; // Symbol used to represent a tie in the game
    }
}
