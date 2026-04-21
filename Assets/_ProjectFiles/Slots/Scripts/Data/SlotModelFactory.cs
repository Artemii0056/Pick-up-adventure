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
            SlotModel model = new SlotModel(slotId, new UniversalSlotRule());
            _slotStorage.AddState(model);
            return model;
        }
        
        public SlotModel Create(int slotId, int itemId)
        {
            SlotModel model = new SlotModel(slotId, new FixedByIdSlotRule(itemId));
            _slotStorage.AddState(model);
            return model;
        }
        
        public SlotModel Create(int slotId, ItemModel initialItem)
        {
            SlotModel model = new SlotModel(
                slotId,
                new FixedByIdSlotRule(initialItem.Id),
                initialItem);

            _slotStorage.AddState(model);
            return model;
        }
    }
}