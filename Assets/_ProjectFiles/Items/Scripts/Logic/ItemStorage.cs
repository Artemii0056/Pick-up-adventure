using System;
using System.Collections.Generic;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public class ItemStorage : IItemStorage
    {
        private readonly Dictionary<int, ItemModel> _items = new();

        public void AddState(ItemModel item)
        {
            if (_items.ContainsKey(item.Id))
                throw new InvalidOperationException($"Item with id {item.Id} already exists.");
            
            _items.Add(item.Id, item);
        }

        public ItemModel GetState(int id)
        {
            if (_items.ContainsKey(id) == false)
                throw new KeyNotFoundException(); 
            
            return _items[id];
        }

        public IReadOnlyCollection<ItemModel> GetAll()
        {
            return _items.Values;
        }
    }
}