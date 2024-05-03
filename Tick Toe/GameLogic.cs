using System;
using System.Collections.Generic;

namespace Tick_Toe
{
    public class GameLogic
    {
        public char[,] Board { get; private set; } = new char[Constants.GridSize, Constants.GridSize];
        public bool GameOver { get; private set; } = false;
        public char Winner { get; private set; } = ' ';

        public GameLogic()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    Board[i, j] = '-';
                }
            }
        }

        public void MakeMove(int row, int col, char player)
        {
            if (Board[row, col] == '-')
            {
                Board[row, col] = player;
                if (CheckForWin(player))
                {
                    GameOver = true;
                    Winner = player;
                }
                else if (CheckForTie())
                {
                    GameOver = true;
                    Winner = Constants.TieSymbol; // 'T' for tie
                }
            }
        }

        public void MakeAIMove()
        {
            Random rand = new Random();
            List<int[]> availableMoves = new List<int[]>();

            for (int i = 0; i < Constants.GridSize; i++)
            {
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    if (Board[i, j] == '-')
                    {
                        availableMoves.Add(new int[] { i, j });
                    }
                }
            }

            if (availableMoves.Count > 0)
            {
                int moveIndex = rand.Next(availableMoves.Count);
                int[] move = availableMoves[moveIndex];
                Board[move[0], move[1]] = 'O'; // AI moves
                if (CheckForWin('O'))
                {
                    GameOver = true;
                    Winner = 'O';
                }
                else if (CheckForTie())
                {
                    GameOver = true;
                    Winner = Constants.TieSymbol; // 'T' for tie
                }
            }
        }

        private bool CheckForWin(char player)
        {
            // Check horizontal, vertical, and both diagonals
            // Logic to check if the player has won
            return false; // Placeholder logic
        }

        private bool CheckForTie()
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    if (Board[i, j] == '-')
                        return false;
                }
            }
            return true;
        }
    }
}
