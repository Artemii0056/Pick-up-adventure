namespace _ProjectFiles
{
    public class FixedByItemIdSlotRule : IItemSlotRule
    {
        public bool CanPlace(Slot slot, int itemId)
        {
            return slot.Id == itemId;
        }

        public bool CanTake(int itemId)
        {
            return true;
        }
    }
}