using _ProjectFiles.Slots.Scripts.View;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public interface IItemSlotRule
    {
        bool CanPlace(SlotView slotView, int itemId);
        bool CanTake(int initialId);
    }
}