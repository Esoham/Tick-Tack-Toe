using System;
using Tick_Toe;
class Program
{
    static void Main(string[] args)
    {
        var game = new GameLogic();
        while (true)
        {
            GameUI.DisplayBoard(game);  // Assuming DisplayBoard now requires the entire game object
            try
            {
                (int row, int column) = GameUI.GetUserMove(game);  // Passing the game object
                if (game.IsValidMove(row, column))  // Make sure this method is implemented in GameLogic
                {
                    game.MakeMove(row, column, Constants.PlayerSymbol);  // Define PlayerSymbol in Constants
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
