using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Slots.Scripts.Data;

namespace _ProjectFiles
{
    public class KeySlotInitializer : BaseSlotInitializer<KeySlotStarter, KeyModel>
    {
        private readonly IKeyModelFactory _keyModelFactory;

        public KeySlotInitializer(
            IKeyModelFactory keyModelFactory,
            ISlotModelFactory slotModelFactory,
            IGlobalIdService globalIdService)
            : base(slotModelFactory, globalIdService)
        {
            _keyModelFactory = keyModelFactory;
        }

        protected override KeyModel CreateItemModel(KeySlotStarter starter, int itemId)
        {
            return _keyModelFactory.CreateKeyModel(
                itemId,
                starter.ItemType,
                starter.ChestKeyType);
        }
    }
}