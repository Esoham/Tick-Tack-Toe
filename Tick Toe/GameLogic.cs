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
            {
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    Board[i, j] = Constants.EmptyCell;
                }
            }
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
                Winner = Constants.EmptyCell;
            }
        }

        private bool CheckForWin(char playerSymbol)
        {
            // Check rows and columns for wins
            for (int i = 0; i < Constants.GridSize; i++)
            {
                if (Board[i, 0] == playerSymbol && Board[i, 1] == playerSymbol && Board[i, 2] == playerSymbol)
                    return true;
                if (Board[0, i] == playerSymbol && Board[1, i] == playerSymbol && Board[2, i] == playerSymbol)
                    return true;
            }

            // Check diagonals for wins
            if (Board[0, 0] == playerSymbol && Board[1, 1] == playerSymbol && Board[2, 2] == playerSymbol)
                return true;
            if (Board[0, 2] == playerSymbol && Board[1, 1] == playerSymbol && Board[2, 0] == playerSymbol)
                return true;

            return false;
        }

        private bool CheckForTie()
        {
            if (CheckForWin(Constants.PlayerSymbol) || CheckForWin(Constants.AISymbol))
                return false;

            for (int i = 0; i < Constants.GridSize; i++)
            {
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    if (Board[i, j] == Constants.EmptyCell)
                        return false;
                }
            }

            return true;
        }

        public void MakeAIMove()
        {
            Random rand = new Random();
            while (true)
            {
                int row = rand.Next(Constants.GridSize);
                int col = rand.Next(Constants.GridSize);
                if (IsMoveLegal(row, col))
                {
                    Board[row, col] = Constants.AISymbol;
                    CheckGameStatus(Constants.AISymbol);
                    break;
                }
            }
        }
    }
}
