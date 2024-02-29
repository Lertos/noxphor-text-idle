//Open file in VSCode window: code -r something.php
//Create new file: type NUL > Battle.cs

using StateManagement;

StateManager stateManager = new StateManager();

Start();

void Start() 
{
    //Load variables and game state
    GameData.LoadInitialState();

    //Start with a fresh console
    Console.Clear();

    stateManager.HandleCommand("l");

    //Start the game
    GameLoop();
}

void GameLoop()
{
    bool quit = false;

    while (!quit)
    {
        //Ask for input from the player
        Display.UpdateText();

        //Handle the players input
        string? command = Console.ReadLine();

        if (command == null || command == "")
        {
            Console.Clear();
            Display.options = stateManager.GetOptions();
            continue;
        }

        //Handle the outcome of the input/action
        stateManager.HandleCommand(command);

        //Start with a fresh console
        Console.Clear();
    }
}