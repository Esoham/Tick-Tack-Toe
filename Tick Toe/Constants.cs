public static class Constants
{
    public const char PlayerSymbol = 'X';
    public const char AISymbol = 'O';
    public const char EmptyCell = '-';  // Placeholder for empty cells

    public const int GridSize = 3;  // Tic Tac Toe grid size

    public const string WelcomeMessage = "Welcome to Tic Tac Toe!";
    public const string EnterMovePrompt = "Enter your move (row, column):";
    public const string NoInputMessage = "No input provided. Please try again.";
    public const string InvalidMoveAttemptMessage = "This spot is already taken, please choose another.";
    public const string InvalidInputMessage = "Invalid input. Please enter row and column as numbers separated by a comma.";
    public const string InputNumbersOnlyError = "Please enter numbers only, separated by a comma.";
    public const string ErrorMessage = "An error occurred: ";
    public const string TieMessage = "The game is a tie!";
    public const string WinnerMessage = "Winner: ";

    public const char InputSeparator = ',';  // Separator for parsing input
}
