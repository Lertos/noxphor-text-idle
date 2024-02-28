//Open file in VSCode window: code -r something.php
//Create new file: type NUL > Battle.cs

using StateManagement;

StateManager stateManager = new StateManager();

Start();

void Start() 
{
    //Load variables and game state
    Display.prefixText = "You are in a dense forest.";
    Display.suffixText = "What would you like to do?";
    Display.options = stateManager.GetOptions();

    //Start the game
    GameLoop();
}

void GameLoop()
{
    bool quit = false;

    while (!quit)
    {
        //Start with a fresh console
        Console.Clear();

        //Ask for input from the player
        Display.UpdateText();

        //Handle the players input
        string? command = Console.ReadLine();

        if (command == null || command == "")
            continue;

        //Handle the outcome of the input/action
        stateManager.HandleCommand(command);
    }
}