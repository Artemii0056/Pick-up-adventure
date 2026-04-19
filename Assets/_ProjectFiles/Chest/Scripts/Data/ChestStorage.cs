using System;
using System.Collections.Generic;

namespace _ProjectFiles.Chest.Scripts.Data
{
    public class ChestStorage : IChestStorage
    {
        private readonly Dictionary<int, ChestModel> _states = new();

        public void AddState(ChestModel state)
        {
            if (_states.ContainsKey(state.Id))
                throw new InvalidOperationException($"Chest with id {state.Id} already exists.");

            _states.Add(state.Id, state);
        }

        public ChestModel GetState(int id)
        {
            if (!_states.TryGetValue(id, out var state))
                throw new KeyNotFoundException($"Chest with id {id} was not found.");

            return state;
        }
    }
}