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
                Display.prefixText = GetLookText();
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

    private String GetLookText()
    {
        StringBuilder sb = new();
        Location? location = GameData.currentLocation;

        if (location == null)
            return "";

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

        return sb.ToString();
    }

}