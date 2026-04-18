using _ProjectFiles.Slots.Scripts.Data;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public class FixedByIdSlotRule : ISlotRule
    {
        private  readonly int _allowedItemId;

        public FixedByIdSlotRule(int allowedItemId)
        {
            _allowedItemId = allowedItemId;
        }

        public bool CanPlace(int itemId, SlotModel slot)
        {
            return itemId == _allowedItemId;
        }
    }
}