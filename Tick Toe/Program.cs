using System;
using Tick_Toe;
class Program
{
    static void Main(string[] args)
    {
        var game = new GameLogic();
        while (!game.GameOver)
        {
            GameUI.DisplayBoard(game);
            try
            {
                var move = GameUI.GetUserMove(game);
                if (move.HasValue)
                {
                    (int row, int column) = move.Value;
                    if (game.IsMoveLegal(row, column))
                    {
                        game.MakeMove(row, column, Constants.PlayerSymbol);
                        if (game.GameOver)
                        {
                            Console.WriteLine("Game over!");
                            break;
                        }
                        game.MakeAIMove();
                        if (game.GameOver)
                        {
                            Console.WriteLine("Game over!");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid move, please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("No valid move entered, please try again.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input, please enter numbers only.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
        }
    }
}