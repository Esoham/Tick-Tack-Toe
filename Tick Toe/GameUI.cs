namespace Tick_Toe
{
    public static class GameUI
    {
        public static (int, int) GetUserMove(GameLogic gameLogic)
        {
            Console.WriteLine(Constants.EnterMovePrompt);
            while (true)
            {
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine(Constants.NoInputMessage);
                    continue;
                }

                var (isValid, row, col) = ParseInput(input);
                if (isValid && gameLogic.IsMoveLegal(row, col))
                {
                    return (row, col);
                }
                Console.WriteLine(isValid ? Constants.InvalidMoveAttemptMessage : Constants.InvalidInputMessage);
            }
        }

        private static (bool, int, int) ParseInput(string input)
        {
            string[] parts = input.Split(Constants.InputSeparator);
            if (parts.Length == 2 && int.TryParse(parts[0].Trim(), out int row) && int.TryParse(parts[1].Trim(), out int col))
            {
                return (true, row, col);
            }
            return (false, -1, -1);
        }

        public static void DisplayBoard(GameLogic game)
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    Console.Write(game.Board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
