public class Path
{
    public string description { get; }
    private Location destination;
    public double safeEncounterChance { get; private set; } = 0.0;
    public double dangerousEncounterChance { get; private set; } = 0.0;
    public double battleEncounterChance { get; private set; } = 0.0;
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

    public void ChoosePath()
    {
        Random random = new();

        //Order of checks are "safe" > "dangerous" > "battle"
        if (safeEncounterChance != 0.0 && random.NextDouble() < safeEncounterChance)
        {
            ChooseEncounter(null); //TODO: Change to the child type of SafeEncounter
            return;
        }
        else if (dangerousEncounterChance != 0.0 && random.NextDouble() < dangerousEncounterChance)
        {
            ChooseEncounter(null); //TODO: Change to the child type of DangerousEncounter
            return;
        }
        else if (battleEncounterChance != 0.0 && random.NextDouble() < battleEncounterChance)
        {
            ChooseEncounter(null); //TODO: Change to the child type of BattleEncounter
            return;
        }

        //If no encounters were triggered, then load the destination location
        GameData.previousLocation= GameData.currentLocation;
        GameData.currentLocation = destination;
    }

    public void ChooseEncounter(Encounter encounter)
    {

    }
}