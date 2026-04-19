using _ProjectFiles.Slots.Scripts.Data;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public interface ISlotStorage
    {
        void AddState(SlotModel item);
        bool TryFindSlotByItem(int itemId, out SlotModel slot);
        bool TryGetState(int slotViewId, out SlotModel model);
    }
}