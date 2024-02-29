public class Path
{
    public string description {get;}
    private Location destination;
    public double safeEncounterChance {get; private set;} = 0.0;
    public double dangerousEncounterChance {get; private set;} = 0.0;
    public double battleEncounterChance {get; private set;} = 0.0;
    //List of skill requirements
    //List of quest requirements

    public Path(string description, Location destination)
    {
        this.description = description;
        this.destination = destination;
    }

    public Path SafeEncounterChance(double chance)
    {
        safeEncounterChance = chance;
        return this;
    }

    public Path DangerousEncounterChance(double chance)
    {
        dangerousEncounterChance = chance;
        return this;
    }

    public Path BattleEncounterChance(double chance)
    {
        battleEncounterChance = chance;
        return this;
    }
}