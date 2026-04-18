namespace _ProjectFiles
{
    public class UniversalSlotRule : IItemSlotRule
    {
        public bool CanPlace(SlotView slotView, int itemId) => 
            true;

        public bool CanTake(int itemId) => 
            true;
    }
}