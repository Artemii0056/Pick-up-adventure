using System;
using _ProjectFiles.Slots.Scripts.Logic;

namespace _ProjectFiles.Slots.Scripts.Data
{
    public class SlotModelFactory : ISlotModelFactory
    {
        private readonly ISlotStorage _slotStorage;

        public SlotModelFactory(ISlotStorage slotStorage) => 
            _slotStorage = slotStorage;

        public SlotModel Create(SlotRuleType slotRuleType, int slotId)
        {
            SlotModel model = new SlotModel(slotId, CreateRule(slotRuleType, slotId));
            _slotStorage.AddState(model);
            return model;
        }

        public SlotModel Create(SlotRuleType slotRuleType, int slotId, int itemId)
        {
            SlotModel model = new SlotModel(slotId, CreateRule(slotRuleType, itemId));
            _slotStorage.AddState(model);
            return model;
        }

        private ISlotRule CreateRule(SlotRuleType slotRuleType, int itemId)
        {
            return slotRuleType switch
            {
                SlotRuleType.Universal => new UniversalSlotRule(),
                SlotRuleType.FixedByItemId => new FixedByIdSlotRule(itemId),
                _ => throw new ArgumentOutOfRangeException(nameof(slotRuleType), slotRuleType, null)
            };
        }
    }
}