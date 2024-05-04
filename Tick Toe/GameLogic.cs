using System;
using System.Collections.Generic;
namespace Tick_Toe
{
    public class GameLogic
    {
        public char[,] Board { get; private set; } = new char[Constants.GRID_SIZE, Constants.GRID_SIZE];
        public bool GameOver { get; private set; } = false;
        public char Winner { get; private set; } = ' ';
        private Random rand = new Random();  // Random instance for AI moves

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
        }

        public void MakeAIMove()
        {
            int[]? bestMove = FindBestMove('O') ?? FindBestMove('X') ?? TakeCenterOrCorner() ?? RandomMove();
            if (bestMove != null)
            {
                Board[bestMove[0], bestMove[1]] = 'O';
                UpdateGameState('O');
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
                        bool win = CheckForWin(player);
                        Board[i, j] = '-';
                        if (win)
                        {
                            return new int[] { i, j };
                        }
                    }
                }
            }
            return null;
        }

        private int[]? TakeCenterOrCorner()
        {
            // Prioritize center
            if (Board[1, 1] == '-')
            {
                return new int[] { 1, 1 };
            }
            // Try corners
            int[][] corners = { new int[] { 0, 0 }, new int[] { 0, 2 }, new int[] { 2, 0 }, new int[] { 2, 2 } };
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
            List<int[]> moves = new List<int[]>();
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    if (Board[i, j] == '-')
                    {
                        moves.Add(new int[] { i, j });
                    }
                }
            }
            return moves.Count > 0 ? moves[rand.Next(moves.Count)] : null;
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
            // Check rows and columns
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                if (Board[i, 0] == player && Board[i, 1] == player && Board[i, 2] == player)
                    return true;
                if (Board[0, i] == player && Board[1, i] == player && Board[2, i] == player)
                    return true;
            }

            // Check diagonals
            if (Board[0, 0] == player && Board[1, 1] == player && Board[2, 2] == player)
                return true;
            if (Board[0, 2] == player && Board[1, 1] == player && Board[2, 0] == player)
                return true;

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