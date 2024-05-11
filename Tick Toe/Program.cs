using System;
using Tick_Toe;

class Program
{
    static void Main(string[] args)
    {
        var game = new GameLogic();
        Console.WriteLine(Constants.WelcomeMessage);

        while (!game.GameOver)
        {
            GameUI.DisplayBoard(game);
            try
            {
                // Player's turn
                if (!game.GameOver)
                {
                    var move = GameUI.GetUserMove(game);
                    game.MakeMove(move.Item1, move.Item2, Constants.PlayerSymbol);
                    if (game.GameOver)
                    {
                        Console.WriteLine(game.Winner != Constants.EmptyCell ? $"Winner: {game.Winner}" : Constants.TieMessage);
                        break;
                    }
                }

                // AI's turn
                if (!game.GameOver)
                {
                    game.MakeAIMove();
                    if (game.GameOver)
                    {
                        Console.WriteLine(game.Winner != Constants.EmptyCell ? $"Winner: {game.Winner}" : Constants.TieMessage);
                        break;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(Constants.InputNumbersOnlyError);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorMessage + ex.Message);
            }
        }
    }
}
