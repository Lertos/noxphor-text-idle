public class Location
{
    public enum Type {BASE, SHOP, BATTLE, DUNGEON, HARVEST, CRAFT, HOME}

    public string name {get; private set;}
    public string description {get; private set;}
    private Type locationType {get;}
    private Path[] paths;
    private Location[] pointsOfInterest;
    //List of NPCs

    public Location(string name, string description, Type locationType, Path[] paths, Location[] pointsOfInterest)
    {
        this.name = name;
        this.description = description;
        this.locationType = locationType;
        this.paths = paths;
        this.pointsOfInterest = pointsOfInterest;
    }

    public Path[] GetPaths()
    {
        return paths;
    }

    public void TryTravel(string pathChoice)
    {
        int optionSelect;
        bool success = int.TryParse(pathChoice, out optionSelect);

        if (!success)
        {
            if (pathChoice == "b" || pathChoice == "back")
            {
                TryTravelPrevious();
                return;
            }

            Display.warningText = "The location ID supplied must be a valid integer unless going (b)ack.";
            return;
        }

        Path[] paths = GameData.currentLocation.GetPaths();

        if (paths.Length <= 0)
        {
            Display.warningText = "There are no valid paths. You cannot travel from this location.";
            return;
        }

        if (optionSelect < 1 || optionSelect > paths.Length)
        {
            Display.warningText = $"The option is not valid. It must be between 1 and {paths.Length}.";
            return;
        }

        paths[optionSelect - 1].ChoosePath();
    }

    private void TryTravelPrevious()
    {
        Location? tempLocation = GameData.currentLocation;

        if (tempLocation == null || GameData.previousLocation == null)
        {
            Display.warningText = "(b)ack is not a valid option at this point in time.";
            return;
        }

        GameData.currentLocation = GameData.previousLocation;
        GameData.previousLocation = tempLocation;
    }

}