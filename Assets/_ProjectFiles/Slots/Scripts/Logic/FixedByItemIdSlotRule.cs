using _ProjectFiles.Slots.Scripts.View;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public class FixedByItemIdSlotRule : IItemSlotRule
    {
        public bool CanPlace(SlotView slotView, int itemId)
        {
            return slotView.Id == itemId;
        }

        public bool CanTake(int itemId)
        {
            return true;
        }
    }
}