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
                    Board[i, j] = Constants.EmptyCell;
                }
            }
        }

        public bool IsMoveLegal(int row, int col)
        {
            return Board[row, col] == Constants.EmptyCell;
        }

        public void MakeMove(int row, int col, char playerSymbol)
        {
            if (IsMoveLegal(row, col))
            {
                Board[row, col] = playerSymbol;
                if (CheckForWin(playerSymbol))
                {
                    GameOver = true;
                    Winner = playerSymbol;
                }
                else if (CheckForTie())
                {
                    GameOver = true;
                    Winner = 'T'; // Indicating a tie
                }
            }
            else
            {
                throw new InvalidOperationException("Attempted to place on an occupied spot or out of bounds.");
            }
        }

        public void MakeAIMove()
        {
            int[]? bestMove = SelectRandomMove(); // Updated to use SelectRandomMove
            if (bestMove != null)
            {
                MakeMove(bestMove[0], bestMove[1], Constants.AISymbol); // Assume AISymbol is defined in Constants
            }
            else
            {
                throw new InvalidOperationException("No valid moves available for AI.");
            }
        }

        private bool CheckForWin(char playerSymbol)
        {
            // Implementation needed
            return false; // Dummy implementation
        }

        private bool CheckForTie()
        {
            // Implementation needed
            return false; // Dummy implementation
        }

        public int[]? SelectRandomMove() // Method renamed from FindRandomMove
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
    }
}