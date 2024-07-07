# AdventureQuestRPG

AdventureQuestRPG is a simple console-based role-playing game (RPG) where players can engage in battles with various monsters. The game is built using C# and demonstrates basic object-oriented programming concepts such as inheritance, polymorphism, encapsulation and interface implementation.

## Getting Started

To get started with AdventureQuestRPG, you will need to have .NET installed on your machine. The game is developed and tested with .NET 7.0, but it should be compatible with other versions that support C# 9.0 or higher.

### Prerequisites

- .NET SDK (Version 7.0 or higher recommended)
- Visual Studio 2022 or any preferred IDE that supports .NET development

### Installation

1. Clone the repository to your local machine using Git:

```
git clone https://github.com/Alz3bi/Adventure-Quest-RPG.git
```

2. Navigate to the cloned repository:

```
cd AdventureQuestRPG
```

3. Build the solution using the .NET CLI:

```
dotnet build
```

4. Run the game:

```
dotnet run --project AdventureQuestRPG
```

## Game Overview

In AdventureQuestRPG, players take on the role of a hero battling against various monsters. The game currently features a simple battle system where the player and the monster take turns attacking each other until one emerges victorious.

### Characters

- **Player**: Represents the hero controlled by the user.
- **Wizard**: A type of monster that the player can battle against.

### Battle System

The `BattleSystem` class handles the logic for battles between the player and monsters. It supports basic actions such as attacking and determining the outcome of battles.

## Testing

The project includes a set of unit tests to verify the functionality of the battle system. These tests are located in the `AdventureQuestRPGTests` project.

To run the tests, use the following command:

```
dotnet test
```

## Contributing

Contributions to AdventureQuestRPG are welcome! Please feel free to submit pull requests or open issues to suggest improvements or add new features.

## License

AdventureQuestRPG is open-source software licensed under the MIT license. See the LICENSE file for more details.
