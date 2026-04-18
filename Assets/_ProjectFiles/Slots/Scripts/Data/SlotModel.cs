using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Slots.Scripts.Logic;

namespace _ProjectFiles.Slots.Scripts.Data
{
    public class SlotModel 
    {
        public int Id { get; }
        public Item CurrentItem { get; private set; }

        private readonly ISlotRule _rule;

        public bool IsEmpty => CurrentItem == null;

        public SlotModel(int id, ISlotRule rule, Item initialItem = null)
        {
            Id = id;
            _rule = rule;
            CurrentItem = initialItem;
        }

        public bool CanTake()
        {
            return CurrentItem != null;
        }

        public Item Take()
        {
            var item = CurrentItem;
            CurrentItem = null;
            return item;
        }

        public bool CanPlace(ItemModel model)
        {
            if (model == null || !IsEmpty)
                return false;

            return _rule.CanPlace(model.Id, this);
        }

        public void Place(Item item)
        {
            CurrentItem = item;
        }
    }
}