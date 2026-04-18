namespace _ProjectFiles
{
    public interface IItemSlotRule
    {
        bool CanPlace(Slot slot, int itemId);
        bool CanTake(int initialId);
    }
}