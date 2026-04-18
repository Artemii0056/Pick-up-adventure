using System.Collections.Generic;
using _ProjectFiles;

public class SlotService
{
    private readonly Dictionary<SlotRuleType, IItemSlotRule> _policies;

    public SlotService()
    {
        _policies = new Dictionary<SlotRuleType, IItemSlotRule>
        {
            { SlotRuleType.Universal, new UniversalSlotRule() },
            { SlotRuleType.FixedByItemId, new FixedByItemIdSlotRule() }
        };
    }

    public bool CanPlace(Slot slot, int itemId)
    {
        if (!slot.IsEmpty)
            return false;

        if (!_policies.TryGetValue(slot.SlotRuleType, out IItemSlotRule policy))
            return false;

        return policy.CanPlace(slot, itemId);
    }

    public bool CanTake(Slot slot)
    {
        return !slot.IsEmpty;
    }

    public void Place(Slot slot, int itemId)
    {
        slot.SetItem(slot);
    }

    public string Take(Slot slot)
    {
        return slot.RemoveItem();
    }
}