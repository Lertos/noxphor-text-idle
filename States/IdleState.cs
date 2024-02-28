using System.Text;

class IdleState : State
{

    public override string GetOptions()
    {
        StringBuilder sb = new();

        sb.Append("(l)ook");
        sb.Append("\n");
        sb.Append("(i)nteract");

        return sb.ToString();
    }

    public override void HandleCommand(string command)
    {
        string[] parts = command.Split(" ");
        
        switch (parts[0].Trim().ToLower()) 
        {
            case "l":
            case "look":
            {
                Display.prefixText = "It's bright and also dark at the same time.";
                break;
            }
            case "i":
            case "interact":
            {
                Display.prefixText = "You interact with the thing.";
                break;
            }
            default:
            {
                Display.warningText = "That is not a valid option.";
                break;
            }
        }

        Display.options = GetOptions();
    }

}