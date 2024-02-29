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

}