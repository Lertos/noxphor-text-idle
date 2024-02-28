abstract class State
{
    public abstract string GetOptions();
    public abstract void HandleCommand(string command);
}