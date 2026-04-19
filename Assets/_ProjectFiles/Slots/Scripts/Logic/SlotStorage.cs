using System;
using System.Collections.Generic;
using _ProjectFiles.Slots.Scripts.Data;
using Unity.Android.Gradle.Manifest;
using UnityEngine;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public class SlotStorage : ISlotStorage //TODO Обязательно сделать один дженериковый класс!
    {
        private readonly Dictionary<int, SlotModel> _slots = new();

        public void AddState(SlotModel item)
        {
            if (_slots.ContainsKey(item.Id))
                throw new InvalidOperationException($"Item with id {item.Id} already exists.");
            
            Debug.Log(item.Id);
            
            _slots.Add(item.Id, item);
        }
        
        public bool TryFindSlotByItem(int itemId, out SlotModel slot)
        {
            foreach (var slotModel in _slots.Values)
            {
                if (!slotModel.IsEmpty && slotModel.CurrentItem.Id == itemId)
                {
                    slot = slotModel;
                    return true;
                }
            }

            slot = null;
            return false;
        }

        public bool TryGetState(int slotViewId, out SlotModel model)
        {
            model = null;
            
                if (_slots.ContainsKey(slotViewId) == false)
                    return false; 
            
                model = _slots[slotViewId];
                return true;
        }
    }
}