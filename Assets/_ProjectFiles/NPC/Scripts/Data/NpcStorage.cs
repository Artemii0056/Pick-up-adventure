using System;
using System.Collections.Generic;

namespace _ProjectFiles.NPC.Scripts.Data
{
    public class NpcStorage : INpcStorage
    {
        private readonly Dictionary<int, NpcModel> _models = new();

        public void AddState(NpcModel item)
        {
            if (_models.ContainsKey(item.Id))
                throw new InvalidOperationException($"Item with id {item.Id} already exists.");
            
            _models.Add(item.Id, item);
        }

        public NpcModel GetState(int id)
        {
            if (_models.ContainsKey(id) == false)
                throw new KeyNotFoundException(); 
            
            return _models[id];
        }
    
        public bool TryGetState(int id, out NpcModel model) =>
            _models.TryGetValue(id, out model);
    }
}