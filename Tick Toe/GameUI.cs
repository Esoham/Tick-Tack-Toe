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
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{board[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        public static int[] GetUserMove()
        {
            Console.WriteLine("Enter your move (row, column):");
            int row = Convert.ToInt32(Console.ReadLine());
            int col = Convert.ToInt32(Console.ReadLine());
            return new int[] { row, col };
        }

        public static void DisplayResult(char winner)
        {
            if (winner == 'T')
                Console.WriteLine("The game is a tie!");
            else
                Console.WriteLine($"Player {winner} wins!");
        }
    }
}
