namespace Tick_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Messages.WelcomeMessage);
            GameLogic gameLogic = new GameLogic();
            GameUI.DisplayBoard(gameLogic);

            while (!gameLogic.GameOver)
            {
                var (row, col) = GameUI.GetUserMove(gameLogic);
                try
                {
                    gameLogic.MakeMove(row, col, Constants.PlayerSymbol);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue; // If move is invalid, prompt for input again
                }
                GameUI.DisplayBoard(gameLogic);

                if (gameLogic.GameOver)
                    break;

                gameLogic.MakeAIMove();
                GameUI.DisplayBoard(gameLogic);
            }

            Console.WriteLine(gameLogic.Winner == Constants.EmptyCell ? Messages.TieMessage : $"{Messages.WinnerMessage} {gameLogic.Winner}");
        }
    }
}
