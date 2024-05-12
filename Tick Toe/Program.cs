using System;
using Tick_Toe;
class Program
{
    static void Main(string[] args)
    {
        var game = new GameLogic();
        Console.WriteLine(Constants.WelcomeMessage);

        // Game loop continues until the game is over
        while (!game.GameOver)
        {
            // Display the current state of the game board
            GameUI.DisplayBoard(game);

            // Handle player's turn
            if (!game.GameOver)
            {
                bool validMoveMade = false;
                while (!validMoveMade)
                {
                    try
                    {
                        var move = GameUI.GetUserMove(game);
                        game.MakeMove(move.Item1, move.Item2, Constants.PlayerSymbol);
                        validMoveMade = true;  // Move was successful, break out of the loop
                        if (game.GameOver)
                        {
                            // Announce the result and exit the game loop if the game is over
                            Console.WriteLine(game.Winner != Constants.EmptyCell ? $"Winner: {game.Winner}" : Constants.TieMessage);
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(Constants.InputNumbersOnlyError);
                    }
                    catch (InvalidOperationException ex)  // Catching invalid move exceptions specifically
                    {
                        Console.WriteLine(ex.Message);  // Message like "This spot is already taken"
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(Constants.ErrorMessage + ex.Message);  // Other unexpected errors
                    }
                }
            }

            // Handle AI's turn
            if (!game.GameOver)
            {
                game.MakeAIMove();
                if (game.GameOver)
                {
                    // Announce the result and exit the game loop if the game is over
                    Console.WriteLine(game.Winner != Constants.EmptyCell ? $"Winner: {game.Winner}" : Constants.TieMessage);
                    break;
                }
            }
        }
    }
}