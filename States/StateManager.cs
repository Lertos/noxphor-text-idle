namespace StateManagement
{
    public enum StateType {IDLE, COMBAT, SHOP, TRAVEL, MENU, DIALOG, DUNGEON, CITY, HOME}

    class StateManager
    {
        private StateType currentState {get; set; } = StateType.IDLE;
        private Dictionary<StateType, State> states = new();

        public StateManager() 
        {
            states.Add(StateType.IDLE, new IdleState());
        }

        public void HandleCommand(string command)
        {
            GetState().HandleCommand(command);
        }

        public string GetOptions()
        {
            return GetState().GetOptions();
        }

        private State GetState()
        {
            if (states.ContainsKey(currentState))
            {
                State? state = states.GetValueOrDefault(currentState);
                
                if (state != null)
                    return state;
                
                throw new NullReferenceException("State does not exist in StateManager state list.");
            }
            return null;
        }
    }
}