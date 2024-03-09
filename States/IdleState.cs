using System.Text;

class IdleState : State
{
    public override string GetOptions()
    {
        int padding = 15;

        StringBuilder sb = new();

        sb.Append("(b)ag".PadRight(padding));
        sb.Append("(i)nteract".PadRight(padding));
        sb.Append("(m)ap".PadRight(padding));

        sb.Append("\n");

        sb.Append("(c)haracter".PadRight(padding));
        sb.Append("(j)ournal".PadRight(padding));
        sb.Append("(q)uit".PadRight(padding));

        sb.Append("\n");

        sb.Append("(e)quipment".PadRight(padding));
        sb.Append("(l)ook".PadRight(padding));
        sb.Append("(t)ravel".PadRight(padding));

        return sb.ToString();
    }

    public override void HandleCommand(string command)
    {
        string[] parts = command.Split(" ");

        switch (parts[0].Trim().ToLower())
        {
            case "b":
            case "bag":
                {
                    break;
                }
            case "c":
            case "character":
                {
                    break;
                }
            case "e":
            case "equipment":
                {
                    break;
                }
            case "i":
            case "interact":
                {
                    Display.prefixText = "You interact with the thing.";
                    break;
                }
            case "j":
            case "journal":
                {
                    break;
                }
            case "l":
            case "look":
                {
                    SetLookText();
                    break;
                }
            case "m":
            case "map":
                {
                    break;
                }
            case "q":
            case "quit":
                {
                    Environment.Exit(0);
                    break;
                }
            case "t":
            case "travel":
                {
                    HandleTravel(parts);
                    SetLookText();
                    break;
                }
            default:
                {
                    Display.warningText = "That is not a valid option.";
                    break;
                }
        }

        Display.suffixText = "What would you like to do?";
        Display.options = GetOptions();
    }

    private void SetLookText()
    {
        StringBuilder sb = new();
        Location? location = GameData.currentLocation;

        if (location == null)
            return;

        sb.Append(location.description);

        Path[] paths = location.GetPaths();

        if (paths.Length > 0 || GameData.previousLocation != null)
        {
            int count = 1;

            sb.Append("\n");
            sb.Append(Display.SubSeparator);
            sb.Append("\n");

            //Show the previous location if it exists
            if (GameData.previousLocation != null)
            {
                sb.Append('\n');
                sb.Append("b : Go back to the previous location (");
                sb.Append(GameData.previousLocation.name);
                sb.Append(")");
            }

            foreach (Path path in paths)
            {
                sb.Append("\n");
                sb.Append(count);
                sb.Append(" : ");
                sb.Append(path.description);

                count++;
            }

            sb.Append("\n");
        }

        Display.prefixText = sb.ToString();
    }

    private void HandleTravel(string[] parts)
    {
        if (parts.Length != 2)
        {
            Display.warningText = "Travel only has one format: [ (t)ravel <location_number> / <(b)ack> ]";
            return;
        }

        if (GameData.currentLocation == null)
        {
            Display.warningText = "You are not currently at a location.";
            return;
        }

        GameData.currentLocation.TryTravel(parts[1]);
    }

}