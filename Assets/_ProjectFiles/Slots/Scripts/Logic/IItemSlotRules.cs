namespace _ProjectFiles
{
    public interface IItemSlotRule
    {
        bool CanPlace(SlotView slotView, int itemId);
        bool CanTake(int initialId);
    }
}