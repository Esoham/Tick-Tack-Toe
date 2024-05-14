namespace Tick_Toe
{
    public class GameLogic
    {
        public char[,] Board { get; private set; }
        public char Winner { get; private set; } = Constants.EmptyCell;
        public bool GameOver { get; private set; } = false;

        public GameLogic()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            Board = new char[Constants.GridSize, Constants.GridSize];
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
                Console.WriteLine($"Player {playerSymbol} made a move: ({row},{col})");
                CheckGameStatus(playerSymbol);
            }
            else
            {
                Console.WriteLine($"Invalid move by Player {playerSymbol}: ({row},{col}) is already taken or out of bounds.");
                throw new InvalidOperationException(Messages.InvalidMoveAttemptMessage);
            }
        }

        private void CheckGameStatus(char playerSymbol)
        {
            if (HasPlayerWon(playerSymbol))
            {
                GameOver = true;
                Winner = playerSymbol;
            }
            else if (IsTie())
            {
                GameOver = true;
                Winner = Constants.EmptyCell;
            }
        }

        private bool HasPlayerWon(char playerSymbol)
        {
            return CheckRowsForWin(playerSymbol) || CheckColumnsForWin(playerSymbol) || CheckDiagonalsForWin(playerSymbol);
        }

        private bool CheckRowsForWin(char playerSymbol)
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                bool win = true;
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    if (Board[i, j] != playerSymbol)
                    {
                        win = false;
                        break;
                    }
                }
                if (win) return true;
            }
            return false;
        }

        private bool CheckColumnsForWin(char playerSymbol)
        {
            for (int i = 0; i < Constants.GridSize; i++)
            {
                bool win = true;
                for (int j = 0; j < Constants.GridSize; j++)
                {
                    if (Board[j, i] != playerSymbol)
                    {
                        win = false;
                        break;
                    }
                }
                if (win) return true;
            }
            return false;
        }

        private bool CheckDiagonalsForWin(char playerSymbol)
        {
            bool win = true;
            for (int i = 0; i < Constants.GridSize; i++)
            {
                if (Board[i, i] != playerSymbol)
                {
                    win = false;
                    break;
                }
            }
            if (win) return true;

            win = true;
            for (int i = 0; i < Constants.GridSize; i++)
            {
                if (Board[i, Constants.GridSize - 1 - i] != playerSymbol)
                {
                    win = false;
                    break;
                }
            }
            return win;
        }

        private bool IsTie()
        {
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
                    Console.WriteLine($"AI made a move: ({row},{col})");
                    CheckGameStatus(Constants.AISymbol);
                    break;
                }
            }
        }
    }
}
