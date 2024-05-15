namespace Tick_Toe
{
    public class GameLogic
    {
        public char[,] Board { get; private set; }
        public char Winner { get; private set; } = Constants.EMPTY_CELL;
        public bool GameOver { get; private set; } = false;

        public GameLogic()
        {
            Board = new char[Constants.GRID_SIZE, Constants.GRID_SIZE];
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    Board[i, j] = Constants.EMPTY_CELL;
                }
            }
        }

        public bool IsValidIndex(int row, int col)
        {
            return row >= 0 && row < Constants.GRID_SIZE && col >= 0 && col < Constants.GRID_SIZE;
        }

        public bool IsMoveLegal(int row, int col)
        {
            return IsValidIndex(row, col) && Board[row, col] == Constants.EMPTY_CELL;
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
                throw new InvalidOperationException(Messages.INVALID_MOVE_ATTEMPT_MESSAGE);
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
                Winner = Constants.EMPTY_CELL;
            }
        }

        private bool HasPlayerWon(char playerSymbol)
        {
            return CheckWin(playerSymbol, true) || CheckWin(playerSymbol, false) || CheckDiagonalsForWin(playerSymbol);
        }

        private bool CheckWin(char playerSymbol, bool isRowCheck)
        {
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                bool win = true;
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    if (isRowCheck)
                    {
                        if (Board[i, j] != playerSymbol)
                        {
                            win = false;
                            break;
                        }
                    }
                    else
                    {
                        if (Board[j, i] != playerSymbol)
                        {
                            win = false;
                            break;
                        }
                    }
                }
                if (win) return true;
            }
            return false;
        }

        private bool CheckDiagonalsForWin(char playerSymbol)
        {
            bool win = true;
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                if (Board[i, i] != playerSymbol)
                {
                    win = false;
                    break;
                }
            }
            if (win) return true;

            win = true;
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                if (Board[i, Constants.GRID_SIZE - 1 - i] != playerSymbol)
                {
                    win = false;
                    break;
                }
            }
            return win;
        }

        private bool IsTie()
        {
            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    if (Board[i, j] == Constants.EMPTY_CELL)
                        return false;
                }
            }
            return true;
        }

        public (int, int) GetAIMove()
        {
            int bestScore = int.MinValue;
            int moveRow = -1, moveCol = -1;

            for (int i = 0; i < Constants.GRID_SIZE; i++)
            {
                for (int j = 0; j < Constants.GRID_SIZE; j++)
                {
                    if (IsMoveLegal(i, j))
                    {
                        Board[i, j] = Constants.AI_SYMBOL;
                        int score = Minimax(Board, 0, false);
                        Board[i, j] = Constants.EMPTY_CELL;

                        if (score > bestScore)
                        {
                            bestScore = score;
                            moveRow = i;
                            moveCol = j;
                        }
                    }
                }
            }
            return (moveRow, moveCol);
        }

        private int Minimax(char[,] board, int depth, bool isMaximizing)
        {
            if (HasPlayerWon(Constants.AI_SYMBOL)) return 10 - depth;
            if (HasPlayerWon(Constants.PLAYER_SYMBOL)) return depth - 10;
            if (IsTie()) return 0;

            if (isMaximizing)
            {
                int bestScore = int.MinValue;
                for (int i = 0; i < Constants.GRID_SIZE; i++)
                {
                    for (int j = 0; j < Constants.GRID_SIZE; j++)
                    {
                        if (board[i, j] == Constants.EMPTY_CELL)
                        {
                            board[i, j] = Constants.AI_SYMBOL;
                            int score = Minimax(board, depth + 1, false);
                            board[i, j] = Constants.EMPTY_CELL;
                            bestScore = Math.Max(score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = int.MaxValue;
                for (int i = 0; i < Constants.GRID_SIZE; i++)
                {
                    for (int j = 0; j < Constants.GRID_SIZE; j++)
                    {
                        if (board[i, j] == Constants.EMPTY_CELL)
                        {
                            board[i, j] = Constants.PLAYER_SYMBOL;
                            int score = Minimax(board, depth + 1, true);
                            board[i, j] = Constants.EMPTY_CELL;
                            bestScore = Math.Min(score, bestScore);
                        }
                    }
                }
                return bestScore;
            }
        }

        public static (bool, int, int) ParseInput(string input)
        {
            string[] parts = input.Split(Constants.INPUT_SEPARATOR);

            if (parts.Length == 2 &&
                int.TryParse(parts[0].Trim(), out int row) &&
                int.TryParse(parts[1].Trim(), out int col))
            {
                return (true, row, col);
            }

            return (false, -1, -1);
        }
    }
}
