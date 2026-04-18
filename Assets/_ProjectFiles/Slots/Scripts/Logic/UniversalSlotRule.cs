using _ProjectFiles.Slots.Scripts.View;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public class UniversalSlotRule : IItemSlotRule
    {
        public bool CanPlace(SlotView slotView, int itemId) => 
            true;

        public bool CanTake(int itemId) => 
            true;
    }
}