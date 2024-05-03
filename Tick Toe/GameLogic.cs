using System;

namespace Tick_Toe
{
    public class GameLogic
    {
        public char[,] Board { get; private set; } = new char[3, 3];
        public bool GameOver { get; private set; } = false;
        public char Winner { get; private set; } = ' ';

        public GameLogic()
        {
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
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
                    Winner = 'T'; // 'T' for tie
                }
            }
        }

        private bool CheckForWin(char player)
        {
            // Horizontal, vertical, and diagonal checks
            for (int i = 0; i < 3; i++)
            {
                if ((Board[i, 0] == player && Board[i, 1] == player && Board[i, 2] == player) ||
                    (Board[0, i] == player && Board[1, i] == player && Board[2, i] == player))
                    return true;
            }
            if ((Board[0, 0] == player && Board[1, 1] == player && Board[2, 2] == player) ||
                (Board[0, 2] == player && Board[1, 1] == player && Board[2, 0] == player))
                return true;

            return false;
        }

        private bool CheckForTie()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j] == '-')
                        return false;
                }
            }
            return true;
        }

        public void MakeAIMove()
        {
            // Simple AI logic for demonstration purposes
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j] == '-')
                    {
                        Board[i, j] = 'O';
                        if (CheckForWin('O'))
                        {
                            GameOver = true;
                            Winner = 'O';
                            return;
                        }
                        return; // This ensures only one move is made
                    }
                }
            }
        }
    }
}
