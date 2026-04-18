namespace _ProjectFiles
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