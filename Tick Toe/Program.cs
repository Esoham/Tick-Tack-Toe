using System;
using Tick_Toe;

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
                int[] move = GameUI.GetUserMove();
                game.MakeMove(move[0], move[1], 'X'); // Player's move

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
