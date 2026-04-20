namespace _ProjectFiles.Slots.Scripts.Data
{
    public interface ISlotModelFactory
    {
        SlotModel Create(SlotRuleType slotRuleType, int slotId);
        SlotModel Create(SlotRuleType slotRuleType, int slotId, int itemId);
    }
}