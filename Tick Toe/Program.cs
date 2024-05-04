using System;

namespace Tick_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            GameLogic game = new GameLogic();
            GameUI.DisplayWelcomeMessage();

            while (!game.GameOver)
            {
                GameUI.DisplayBoard(game.Board);
                (int row, int col) = GameUI.GetUserMove(game);  // Pass the game instance here
                game.MakeMove(row, col, 'X');

                if (!game.GameOver)
                {
                    game.MakeAIMove();
                }
            }

            GameUI.DisplayBoard(game.Board);
            GameUI.DisplayResult(game.Winner);
        }
    }
}
