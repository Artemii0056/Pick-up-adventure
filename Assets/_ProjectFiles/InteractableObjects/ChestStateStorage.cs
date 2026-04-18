using System.Collections.Generic;

namespace _ProjectFiles.InteractableObjects
{
    public class ChestStateStorage
    {
        private readonly Dictionary<int, ChestState> _states = new();

        public ChestState GetOrCreate(int id)
        {
            if (_states.TryGetValue(id, out var state))
                return state;

            state = new ChestState();
            _states[id] = state;
            return state;
        }
    }
}