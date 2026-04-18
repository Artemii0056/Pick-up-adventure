namespace _ProjectFiles
{
    public class UniversalSlotRule : IItemSlotRule
    {
        public bool CanPlace(Slot slot, int itemId) => 
            true;

        public bool CanTake(int itemId) => 
            true;
    }
}