using System.Collections.Generic;
using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public class StoragePickedUpItems : IStoragePickedUpItems
    {
        private readonly Dictionary<int, ItemType> _items = new();
        
        public void AddState(ItemType item, int id)
        {
            if (_items.ContainsKey(id))
                return;
            
            _items.Add(id, item);
        }

        public ItemType GetState(int id) => 
            _items[id];
    }
}