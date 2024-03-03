using System.Text;

class IdleState : State
{

    public override string GetOptions()
    {
        StringBuilder sb = new();

        sb.Append("(b)ag".PadRight(15));
        sb.Append("(i)nteract".PadRight(15));
        sb.Append("(m)ap".PadRight(15));
        sb.Append("\n");
        sb.Append("(c)haracter".PadRight(15));
        sb.Append("(j)ournal".PadRight(15));
        sb.Append("(q)uit".PadRight(15));
        sb.Append("\n");
        sb.Append("(e)quipment".PadRight(15));
        sb.Append("(l)ook".PadRight(15));
        sb.Append("(t)ravel".PadRight(15));

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

        if (paths.Length > 0)
        {
            int count = 1;

            sb.Append("\n");
            sb.Append(Display.SubSeparator);
            sb.Append("\n");

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
        if (parts.Length != 2) {
            Display.warningText = "Travel only has one format: [ (t)ravel <location_number> ]";
            return;
        } 
        
        int optionSelect;
        bool success = int.TryParse(parts[1], out optionSelect);

        if (!success) {
            Display.warningText = "The location ID supplied must be a valid integer.";
            return;
        }

        Location? currentLocation = GameData.currentLocation;

        if (currentLocation == null) {
            Display.warningText = "You are not currently at a location.";
            return;
        }

        Path[] paths = currentLocation.GetPaths();

        if (optionSelect < 1 || optionSelect > paths.Length) {
            Display.warningText = $"The option is not valid. It must be between 1 and {paths.Length}.";
            return;
        }

        paths[optionSelect].ChoosePath();
        
        SetLookText();
    }

}