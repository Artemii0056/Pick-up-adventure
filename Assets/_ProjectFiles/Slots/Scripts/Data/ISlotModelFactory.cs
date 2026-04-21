using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Slots.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.Slots.Scripts.Data
{
    public interface ISlotModelFactory
    {
        SlotModel Create(SlotRuleType slotRuleType, int slotId);
        SlotModel Create(int slotId, int itemId);
        SlotModel Create(int slotId, ItemModel initialItem);
    }
}   