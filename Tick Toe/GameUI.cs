using System;

namespace Tick_Toe
{
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

        // Updated IsValidIndex to return a tuple with a boolean and indexes
        private static (bool, int, int) IsValidIndex(string input)
        {
            string[] parts = input.Split(',');
            if (parts.Length == 2 &&
                int.TryParse(parts[0].Trim(), out int row) && row >= 0 && row < Constants.GRID_SIZE &&
                int.TryParse(parts[1].Trim(), out int col) && col >= 0 && col < Constants.GRID_SIZE)
            {
                return (true, row, col);
            }
            return (false, -1, -1);  // Return false with invalid indices
        }

        // Updated GetUserMove to handle the new IsValidIndex structure and return a nullable tuple
        public static (int, int)? GetUserMove(GameLogic gameLogic)
        {
            Console.WriteLine("Enter your move (row, column):");
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    DisplayNoInputMessage();
                    continue;  // Prompt for input again instead of returning null
                }

                var (isValid, row, col) = IsValidIndex(input);
                if (isValid)
                {
                    if (IsValidMove(gameLogic, row, col))
                    {
                        return (row, col);  // Valid move
                    }
                    else
                    {
                        DisplayTakenMessage();  // Inform the spot is taken
                    }
                }
                else
                {
                    DisplayInvalidInputMessage();  // Inform invalid input
                }
            }
        }

        private static bool IsValidMove(GameLogic gameLogic, int row, int col)
        {
            return gameLogic.Board[row, col] == Constants.EmptyCell;
        }

        private static void DisplayTakenMessage()
        {
            Console.WriteLine("This spot is already taken, please choose another.");
        }

        private static void DisplayInvalidInputMessage()
        {
            Console.WriteLine("Invalid input. Please enter row and column as two numbers separated by a comma, each between 0 and " + (Constants.GRID_SIZE - 1) + ".");
        }

        private static void DisplayNoInputMessage()
        {
            Console.WriteLine("No input provided. Please try again:");
        }
    }
}