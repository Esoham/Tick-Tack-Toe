namespace Tick_Toe
{
    public static class Constants
    {
        public const int GridSize = 3;
        public const char EmptyCell = ' ';
        public const char PlayerSymbol = 'X';
        public const char AISymbol = 'O';
        public const string WelcomeMessage = "Welcome to Tic Tac Toe!";
        public const string EnterMovePrompt = "Enter your move (row, column):";
        public const string SpotTakenMessage = "This spot is already taken, please choose another.";
        public const string InvalidInputMessage = "Invalid input. Please enter row and column as numbers separated by a comma.";
        public const string GameOverMessage = "Game Over. Winner: ";
        public const string TieMessage = "The game is a tie!";
        public const string InputNumbersOnlyError = "Error: Please enter numbers only.";
        public const string ErrorMessage = "An error occurred: ";
        public const char InputSeparator = ',';
        public const string InvalidMoveAttemptMessage = "Attempted to place on an occupied spot or out of bounds.";
    }
}
