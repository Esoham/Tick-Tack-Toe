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
                    Board[i, j] = Constants.EmptyCell;  // Use constant for empty cell
                }
            }
        }

        public void MakeMove(int row, int col, char player)
        {
            if (Board[row, col] == Constants.EmptyCell)
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
                   Board[row, col] == Constants.EmptyCell;
        }

        public void MakeAIMove()
        {
            int[]? bestMove = FindBestMove(Constants.AISymbol) ?? FindBestMove(Constants.PlayerSymbol) ?? TakeCenterOrCorner() ?? RandomMove();
            if (bestMove != null)
            {
                MakeMove(bestMove[0], bestMove[1], Constants.AISymbol);
            }
            else
            {
                throw new InvalidOperationException("No valid moves available for AI.");
            }
        }

        private int[]? FindBestMove(char player)
        {
            List<int[]> availableMoves = new List<int[]>();
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    if (Board[i, j] == Constants.EmptyCell)
                    {
                        availableMoves.Add(new int[] { i, j });
                    }
                }
            }
            return availableMoves.Count > 0 ? availableMoves[rand.Next(availableMoves.Count)] : null;
        }

        private int[]? TakeCenterOrCorner()
        {
            var positions = new List<int[]> { new int[] { 0, 0 }, new int[] { 0, 2 }, new int[] { 2, 0 }, new int[] { 2, 2 }, new int[] { 1, 1 } };
            foreach (var pos in positions)
            {
                if (Board[pos[0], pos[1]] == Constants.EmptyCell)
                    return pos;
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
                    if (Board[i, j] == Constants.EmptyCell)
                        availableMoves.Add(new int[] { i, j });
                }
            }
            if (availableMoves.Count > 0)
                return availableMoves[rand.Next(availableMoves.Count)];
            return null;
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
                    if (Board[i, j] == Constants.EmptyCell)
                        return false;
                }
            }
            return true;
        }
    }
}