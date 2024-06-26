﻿using System;
namespace Tick_Toe
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                GameUI.ConfigureGame();

                GameUI.DisplayMessage(Messages.WELCOME_MESSAGE);
                GameLogic gameLogic = new GameLogic();
                GameUI.DisplayBoard(gameLogic);

                while (!gameLogic.GameOver)
                {
                    var (row, col) = GameUI.GetUserMove(gameLogic);
                    try
                    {
                        gameLogic.MakeMove(row, col, Constants.PLAYER_SYMBOL);
                    }
                    catch (InvalidOperationException ex)
                    {
                        GameUI.DisplayMessage(ex.Message);
                        continue; // If move is invalid, prompt for input again
                    }
                    GameUI.DisplayBoard(gameLogic);

                    if (gameLogic.GameOver)
                        break;

                    var (aiRow, aiCol) = gameLogic.GetAIMove();
                    gameLogic.MakeMove(aiRow, aiCol, Constants.AI_SYMBOL);
                    GameUI.DisplayBoard(gameLogic);
                }

                GameUI.DisplayGameSummary(gameLogic.Winner);
            } while (GameUI.AskToPlayAgain());
        }
    }
}
