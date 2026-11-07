# Tic-Tac-Toe — C# Console Exercise

**Status: historical programming practice**, not a production game or a featured portfolio project.

The project separates a simple console game's entry point, game logic and presentation:
- `Tick Toe/Program.cs` — program entry point.
- `Tick Toe/GameLogic.cs` — game-state logic.
- `Tick Toe/GameUI.cs` — console interface.
- `Tick Toe/Messages.cs` and `Constants.cs` — shared text and values.

The project targets **.NET 7**, which is out of support. Build, runtime behavior and automated tests have **not** been independently verified in this review.

To explore with a compatible .NET SDK:
```bash
dotnet restore "Tick Toe.sln"
dotnet run --project "Tick Toe/Tick Toe.csproj"
```

Potential testing exercises: legal/illegal moves, turn alternation, winning rows/columns/diagonals, ties and replay handling. These are suggested tests, not evidence that a test suite exists.

For professional software QA automation examples, see [CommerceQA](https://github.com/Esoham/QA-Automation-Project).
