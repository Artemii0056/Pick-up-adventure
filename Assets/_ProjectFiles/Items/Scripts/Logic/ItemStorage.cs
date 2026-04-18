using System.Collections.Generic;
using _ProjectFiles.RaycastResolvers.Scripts;

namespace _ProjectFiles.Items
{
    public class ItemStorage
    {
        private readonly Dictionary<int, ItemView> _states = new();

        public void AddState(ItemView state)
        {
            if (_states.ContainsKey(state.Id))
                throw new KeyNotFoundException(); //TODO Заменить на нормальный эксепшн
            
            _states.Add(state.Id, state);
        }

        public ItemView GetState(int id)
        {
            if (_states.ContainsKey(id) == false)
                throw new KeyNotFoundException(); 
            
            return _states[id];
        }
    }
}