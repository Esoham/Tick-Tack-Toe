using System;
using System.Collections.Generic;
namespace Tick_Toe
{
    public class GameLogic
    {
        public char[,] Board { get; private set; } = new char[Constants.GRID_SIZE, Constants.GRID_SIZE];
        public bool GameOver { get; private set; } = false;
        public char Winner { get; private set; } = ' ';
        private static readonly Random rand = new Random();

        public GameLogic()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
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
                UpdateGameState(player);
            }
            else
            {
                throw new InvalidOperationException("Attempted to make a move on an occupied spot.");
            }
        }

        public bool IsValidMove(int row, int col)
        {
            return row >= 0 && row < Constants.GRID_SIZE &&
                   col >= 0 && col < Constants.GRID_SIZE &&
                   Board[row, col] == '-';
        }

        public void MakeAIMove()
        {
            int[]? bestMove = FindBestMove('O') ?? FindBestMove('X') ?? TakeCenterOrCorner() ?? RandomMove();
            if (bestMove != null)
            {
                MakeMove(bestMove[0], bestMove[1], 'O');
            }
            else
            {
                throw new InvalidOperationException("No valid moves available for AI.");
            }
        }

        private int[]? FindBestMove(char player)
        {
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    if (Board[i, j] == '-')
                    {
                        Board[i, j] = player;
                        if (CheckForWin(player))
                        {
                            Board[i, j] = '-';
                            return new int[] { i, j };
                        }
                        Board[i, j] = '-';
                    }
                }
            }
            return null;
        }

        private int[]? TakeCenterOrCorner()
        {
            // Center position (for a 3x3 grid)
            int center = Constants.GRID_SIZE / 2;
            if (Board[center, center] == '-')
            {
                return new int[] { center, center };
            }

            // Corners
            int[][] corners = { new int[] { 0, 0 }, new int[] { 0, Constants.GRID_SIZE - 1 }, new int[] { Constants.GRID_SIZE - 1, 0 }, new int[] { Constants.GRID_SIZE - 1, Constants.GRID_SIZE - 1 } };
            foreach (int[] corner in corners)
            {
                if (Board[corner[0], corner[1]] == '-')
                {
                    return corner;
                }
            }
            return null;
        }

        private int[]? RandomMove()
        {
            List<int[]> availableMoves = new List<int[]>();
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    if (Board[i, j] == '-')
                    {
                        availableMoves.Add(new int[] { i, j });
                    }
                }
            }
            return availableMoves.Count > 0 ? availableMoves[rand.Next(availableMoves.Count)] : null;
        }

        private void UpdateGameState(char player)
        {
            if (CheckForWin(player))
            {
                GameOver = true;
                Winner = player;
            }
            else if (CheckForTie())
            {
                GameOver = true;
                Winner = Constants.TIE_SYMBOL;
            }
        }

        private bool CheckForWin(char player)
        {
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                bool rowWin = true;
                bool colWin = true;
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    rowWin &= (Board[i, j] == player);
                    colWin &= (Board[j, i] == player);
                }
                if (rowWin || colWin) return true;
            }

            bool diag1Win = true;
            bool diag2Win = true;
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                diag1Win &= (Board[i, i] == player);
                diag2Win &= (Board[i, Constants.GRID_SIZE - 1 - i] == player);
            }
            if (diag1Win || diag2Win) return true;

            return false;
        }

        private bool CheckForTie()
        {
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    if (Board[i, j] == '-')
                        return false;
                }
            }
            return true;
        }
    }
}
