using System;

namespace Tick_Toe
{
    public static class GameUI
    {
        public static void ConfigureGame()
        {
            Console.WriteLine(Messages.CONFIGURE_GAME_PROMPT);
            // Additional configuration can be implemented here.
        }

        public static (int, int) GetUserMove(GameLogic gameLogic)
        {
            Console.WriteLine(Messages.ENTER_MOVE_PROMPT);

            while (true)
            {
                string? input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(Messages.NO_INPUT_MESSAGE);
                    continue;
                }

                var (isValid, row, col) = GameLogic.ParseInput(input);

                if (isValid && gameLogic.IsMoveLegal(row, col))
                {
                    return (row, col);
                }

                if (!isValid)
                {
                    Console.WriteLine(Messages.INVALID_INPUT_MESSAGE);
                }
                else
                {
                    Console.WriteLine(Messages.INVALID_MOVE_ATTEMPT_MESSAGE);
                }
            }
        }

        public static void DisplayBoard(GameLogic game)
        {
            Console.WriteLine("Current board state:");
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    Console.Write(game.Board[i, j] + Constants.CELL_SPACING);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static bool AskToPlayAgain()
        {
            Console.WriteLine(Messages.PLAY_AGAIN_PROMPT);
            string? response = Console.ReadLine()?.Trim().ToLower();
            return response == "y" || response == "yes";
        }

        public static void DisplayGameSummary(char winner)
        {
            if (winner == Constants.EMPTY_CELL)
            {
                Console.WriteLine(Messages.TIE_MESSAGE);
            }
            else
            {
                Console.WriteLine($"{Messages.WINNER_MESSAGE} {winner}");
            }
        }

        public static void DisplayMessage(string message)
        {
            // Improved message display with additional formatting or logging if needed
            Console.WriteLine($"[INFO]: {message}");
        }
    }
}
