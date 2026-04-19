using _ProjectFiles.Slots.Scripts.Data;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public interface ISlotRule
    {
        bool CanPlace(int itemId, SlotModel slot);
    }
}