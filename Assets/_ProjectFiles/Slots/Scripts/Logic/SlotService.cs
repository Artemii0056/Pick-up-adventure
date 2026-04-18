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

    public bool CanPlace(SlotView slotView, int itemId)
    {
        if (!slotView.IsEmpty)
            return false;

        if (!_policies.TryGetValue(slotView.SlotRuleType, out IItemSlotRule policy))
            return false;

        return policy.CanPlace(slotView, itemId);
    }

    public bool CanTake(SlotView slotView)
    {
        return !slotView.IsEmpty;
    }

    public void Place(SlotView slotView, int itemId)
    {
      //  slot.SetItem(slot);
    }

    public void Take(SlotView slotView)
    {
       // return slot.RemoveItem();
    }
}