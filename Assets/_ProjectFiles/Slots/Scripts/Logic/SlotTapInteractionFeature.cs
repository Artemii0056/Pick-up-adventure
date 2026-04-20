using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.Slots.Scripts.Data;
using _ProjectFiles.Slots.Scripts.View;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public class SlotTapInteractionFeature : ITapInteractionFeature
    {
        private readonly ISlotStorage _slotStorage;
        private readonly IItemTransferService _transferService;

        public SlotTapInteractionFeature(ISlotStorage slotStorage, IItemTransferService transferService)
        {
            _slotStorage = slotStorage;
            _transferService = transferService;
        }

        public InteractableItemType Type => InteractableItemType.Slot;

        public bool TryGetInteractData(IHandService handService, InteractableView interactableView, out InteractData data)
        {
            data = default;

            if (interactableView is not SlotView slotView)
                return false;

            if (!handService.HasItem)
                return false;

            if (!_slotStorage.TryGetState(slotView.Id, out SlotModel slotModel))
                return false;

            if (!slotModel.CanPlace(handService.CurrentItem))
                return false;

            data = new InteractData
            {
                CanInteract = true,
                ActionName = "Положить"
            };

            return true;
        }

        public void Interact(IHandService handService, InteractableView interactableView)
        {
            if (interactableView is not SlotView slotView)
                return;

            if (!handService.HasItem)
                return;

            if (!_slotStorage.TryGetState(slotView.Id, out SlotModel slotModel))
                return;

            if (!slotModel.CanPlace(handService.CurrentItem))
                return;

            _transferService.TryPlaceToSlot(handService, slotView);
        }
    }
}