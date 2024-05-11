namespace Tick_Toe
{
    public class GameLogic
    {
        public char[,] Board = new char[Constants.GridSize, Constants.GridSize];
        public char Winner = Constants.EmptyCell;
        public bool GameOver = false;

        public GameLogic()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < Constants.GridSize; i++)
                for (int j = 0; j < Constants.GridSize; j++)
                    Board[i, j] = Constants.EmptyCell;
        }

        public bool IsValidIndex(int row, int col)
        {
            return row >= 0 && row < Constants.GridSize && col >= 0 && col < Constants.GridSize;
        }

        public bool IsMoveLegal(int row, int col)
        {
            return IsValidIndex(row, col) && Board[row, col] == Constants.EmptyCell;
        }

        public void MakeMove(int row, int col, char playerSymbol)
        {
            if (IsMoveLegal(row, col))
            {
                Board[row, col] = playerSymbol;
                CheckGameStatus(playerSymbol);
            }
            else
            {
                throw new InvalidOperationException(Constants.InvalidMoveAttemptMessage);
            }
        }

        private void CheckGameStatus(char playerSymbol)
        {
            if (CheckForWin(playerSymbol))
            {
                GameOver = true;
                Winner = playerSymbol;
            }
            else if (CheckForTie())
            {
                GameOver = true;
                Winner = Constants.EmptyCell;  // Signifies a tie
            }
        }

        private bool CheckForWin(char playerSymbol)
        {
            // Checking logic as provided
            // Check rows, columns, and diagonals
            return false; // Placeholder
        }

        private bool CheckForTie()
        {
            // Check if there are no empty spaces left
            return false; // Placeholder
        }

        public void MakeAIMove()  // AI move method
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    if (Board[i, j] == Constants.EmptyCell)
                    {
                        Board[i, j] = Constants.AISymbol;
                        CheckGameStatus(Constants.AISymbol);
                        return;
                    }
                }
            }
        }
    }
}
