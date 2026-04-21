using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Core.TransferServices;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.Data;
using _ProjectFiles.Slots.Scripts.View;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public class SlotTapInteractionFeature : ITapInteractionFeature
    {
        private readonly ISlotStorage _slotStorage;
        private readonly IItemTransferService _transferService;
        private readonly IHandService _handService;
        private readonly IItemStorage _itemStorage;

        public SlotTapInteractionFeature(ISlotStorage slotStorage, IItemTransferService transferService, IHandService handService, IItemStorage itemStorage)
        {
            _slotStorage = slotStorage;
            _transferService = transferService;
            _handService = handService;
            _itemStorage = itemStorage;
        }

        public InteractableItemType Type => InteractableItemType.Slot;

        public bool TryGetInteractData(InteractableView interactableView, out InteractData data)
        {
            data = default;

            if (interactableView is not ItemView itemView)
                return false;

            ItemModel itemModel = _itemStorage.GetState(itemView.Id);

            if (itemModel == null)
                return false;

            data = new InteractData
            {
                CanInteract = !_handService.HasItem,
                ActionName = "Подобрать"
            };

            return true;
        }

        public void Interact(InteractableView interactableView)
        {
            if (interactableView is not SlotView slotView)
                return;

            if (!_handService.HasItem)
                return;

            if (!_slotStorage.TryGetState(slotView.Id, out SlotModel slotModel))
                return;

            if (!slotModel.CanPlace(_handService.CurrentItem))
                return;

            _transferService.TryPlaceToSlot(slotView);
        }
    }
}