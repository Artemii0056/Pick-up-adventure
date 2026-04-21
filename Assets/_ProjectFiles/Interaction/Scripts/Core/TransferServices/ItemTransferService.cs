using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Player.Scripts.View;
using _ProjectFiles.Slots.Scripts.Logic;
using _ProjectFiles.Slots.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.Interaction.Scripts.Core.TransferServices
{
    public class ItemTransferService : IItemTransferService
    {
        private readonly ISlotStorage _slotStorage;
        private readonly IItemStorage _itemStorage;
        private readonly PlayerHandView _handView;
        private readonly IStoragePickedUpItems _storagePickedUpItems;
        private readonly IHandService _handService;

        public ItemTransferService(ISlotStorage slotStorage,
            IItemStorage itemStorage,
            PlayerHandView handView,
            IStoragePickedUpItems storagePickedUpItems,
            IHandService handService)
        {
            _slotStorage = slotStorage;
            _itemStorage = itemStorage;
            _handView = handView;
            _storagePickedUpItems = storagePickedUpItems;
            _handService = handService;
        }

        public bool TryTakeItem(ItemView itemView)
        {
            if (_handService.HasItem)
                return false;
            
            ItemModel itemModel = _itemStorage.GetState(itemView.Id);

            if (itemModel == null)
                return false;

            if (_slotStorage.TryFindSlotByItem(itemModel.Id, out var slot))
            {
                slot.Take();
            }
            
            _storagePickedUpItems.AddState(itemModel.Type, itemView.Id);

            _handService.Put(itemModel, itemView);
            MoveToHand(itemView);

            return true;
        }

        public bool TryPlaceToSlot(SlotView slotView)
        {
            if (!_handService.HasItem)
                return false;

            ItemModel itemModel = _handService.CurrentItem;
            ItemView itemView = _handService.CurrentItemView;
            
            if (_slotStorage.TryGetState(slotView.Id, out var slotModel) == false)
                return false;

            if (!slotModel.CanPlace(itemModel))
                return false;


            slotModel.Place(itemModel);
            slotView.SetItemView(itemView);

            MoveToSlot(itemView, slotView);

            _handService.Clear();

            return true;
        }
        
        private void MoveToHand(ItemView itemView)
        {
            itemView.transform.SetParent(_handView.Transform);
            itemView.transform.localPosition = new Vector3(-0.3f, -0.2f, 0.5f);
            itemView.transform.localRotation = Quaternion.identity;
        }

        private void MoveToSlot(ItemView itemView, SlotView slotView)
        {
            Transform anchor = slotView.ItemAnchor;

            itemView.transform.SetParent(anchor);
            itemView.transform.localPosition = Vector3.zero;
            itemView.transform.localRotation = Quaternion.identity;
        }
    }
}