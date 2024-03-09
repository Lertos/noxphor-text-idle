public sealed class GameData
{
    private static GameData? instance = null;

    public static Location? currentLocation {get; set;}
    public static Location? previousLocation { get; set; }


    private GameData () {}

    public static GameData Instance ()
    {
        if (instance == null)
            instance = new GameData();

        return instance;
    }

    public static void LoadInitialState()
    {
        SetCurrentLocation();
    }

    internal static void SetCurrentLocation()
    {
        Location basement = new Location(
            "The Basement",
            "It's completely soaked in bath water, with toilet paper all over the ground.",
            Location.Type.BASE,
            [],
            []
        );

        Location porch = new Location(
            "Porch",
            "Stepping over the huge hole right infront of the door, you look out to see an overgrown lawn.",
            Location.Type.BASE,
            [],
            []
        );

        Path[] paths = {
            new Path("Looking down, you see a hidden trapdoor that is ajar.", basement),
            new Path("There is a creaky door waiting to be pushed.", porch)
        };

        currentLocation = new Location(
            "The Shack", 
            "It smells musty and looks no better.",
            Location.Type.BASE,
            paths,
            []
        );
    }
}