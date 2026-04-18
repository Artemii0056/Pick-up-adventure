using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Slots.Scripts.Data;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public class UniversalSlotRule : ISlotRule
    {
        public bool CanPlace(int itemId, SlotModel slot)
        {
            return true;
        }
    }
}