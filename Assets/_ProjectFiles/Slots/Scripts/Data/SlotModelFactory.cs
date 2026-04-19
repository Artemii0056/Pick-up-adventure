using _ProjectFiles.Slots.Scripts.Logic;

namespace _ProjectFiles.Slots.Scripts.Data
{
    public class SlotModelFactory : ISlotModelFactory
    {
        private readonly ISlotStorage _slotStorage;

        public SlotModelFactory(ISlotStorage slotStorage)
        {
            _slotStorage = slotStorage;
        }

        public SlotModel Create(SlotRuleType slotRuleType, int id)
        {
            ISlotRule slotRule;

            if (slotRuleType == SlotRuleType.Universal)
            {
                slotRule = new UniversalSlotRule();
            }
            else
            {
                slotRule = new FixedByIdSlotRule(id);
            }

            SlotModel model = new SlotModel(id, slotRule);
            _slotStorage.AddState(model);
            return model;
        }
    }
}