using System;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Slots.Scripts.Logic;

namespace _ProjectFiles.Slots.Scripts.Data
{
    public class SlotModel 
    {
        private readonly ISlotRule _rule;

        public SlotModel(int id, ISlotRule rule, ItemModel initialItem = null)
        {
            Id = id;
            _rule = rule;
            CurrentItem = initialItem;
        }
        
        public bool IsEmpty => CurrentItem == null;
        public int Id { get; }
        public ItemModel CurrentItem { get; private set; }

        public ItemModel Take()
        {
            if (IsEmpty)
                throw new InvalidOperationException($"Slot {Id} is empty");

            ItemModel item = CurrentItem;
            CurrentItem = null;
            return item;
        }

        public bool CanPlace(ItemModel model)
        {
            if (model == null || !IsEmpty)
                return false;

            return _rule.CanPlace(model.Id, this);
        }

        public void Place(ItemModel item)
        {
            CurrentItem = item;
        }
    }
}