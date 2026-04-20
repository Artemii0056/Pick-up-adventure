using _ProjectFiles.GlobalId.Scripts;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles
{
    public abstract class BaseSlotInitializer<TStarter, TItemModel>
        where TStarter : ItemSlotStarter
        where TItemModel : ItemModel
    {
        private readonly ISlotModelFactory _slotModelFactory;
        private readonly IGlobalIdService _globalIdService;

        protected BaseSlotInitializer(
            ISlotModelFactory slotModelFactory,
            IGlobalIdService globalIdService)
        {
            _slotModelFactory = slotModelFactory;
            _globalIdService = globalIdService;
        }

        public void Initialize(TStarter starter)
        {
            int slotId = _globalIdService.GetNext();
            starter.SlotView.SetId(slotId);

            int itemId = _globalIdService.GetNext();

            SlotModel slotModel = _slotModelFactory.Create(
                starter.SlotView.SlotRuleType,
                slotId,
                itemId);

            TItemModel itemModel = CreateItemModel(starter, itemId);
            slotModel.Place(itemModel);

            ItemView itemView = Object.Instantiate(starter.ItemPrefab, starter.SlotView.ItemAnchor);
            itemView.SetId(itemId);
            itemView.transform.localPosition = Vector3.zero;
            itemView.transform.localRotation = Quaternion.identity;

            starter.SlotView.SetItemView(itemView);
        }

        protected abstract TItemModel CreateItemModel(TStarter starter, int itemId);
    }
}