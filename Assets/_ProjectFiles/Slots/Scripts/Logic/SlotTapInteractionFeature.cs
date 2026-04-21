using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Core.TransferServices;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.Slots.Scripts.Data;
using _ProjectFiles.Slots.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public class SlotTapInteractionFeature : ITapInteractionFeature
    {
        private readonly ISlotStorage _slotStorage;
        private readonly IItemTransferService _transferService;
        private readonly IHandService _handService;

        public SlotTapInteractionFeature(ISlotStorage slotStorage, IItemTransferService transferService, IHandService handService)
        {
            _slotStorage = slotStorage;
            _transferService = transferService;
            _handService = handService;
        }

        public InteractableItemType Type => InteractableItemType.Slot;

        public bool TryGetInteractData(InteractableView interactableView, out InteractData data)
        {
            data = default;

            if (interactableView is not SlotView slotView)
                return false;

            if (!_handService.HasItem)
                return false;

            if (!_slotStorage.TryGetState(slotView.Id, out SlotModel slotModel))
                return false;

            if (!slotModel.CanPlace(_handService.CurrentItem))
                return false;

            data = new InteractData
            {
                CanInteract = true,
                ActionName = "Положить"
            };

            return true;
        }

        public void Interact(InteractableView interactableView)
        {
            Debug.Log("Slot Interact");
            
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