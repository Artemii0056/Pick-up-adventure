using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.Player.Scripts.Resolvers;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public class ItemInteractionFeature : IInteractionFeature
    {
        private readonly IItemStorage _itemStorage;
        private readonly ItemTransferService _transferService;

        public ItemInteractionFeature(IItemStorage itemStorage, ItemTransferService transferService)
        {
            _itemStorage = itemStorage;
            _transferService = transferService;
        }

        public InteractableItemType Type => InteractableItemType.Item;

        public bool TryGetInteractData(IHandService handService, InteractableView interactableView, out InteractData data)
        {
            data = default;

            if (interactableView is not ItemView itemView)
                return false;

            if (handService.HasItem)
                return false;

            ItemModel itemModel = _itemStorage.GetState(itemView.Id);

            if (itemModel == null)
                return false;

            data = new InteractData
            {
                CanInteract = true,
                ActionName = "Взять"
            };

            return true;
        }

        public void Interact(IHandService handService, InteractableView interactableView)
        {
            if (interactableView is not ItemView itemView)
                return;

            _transferService.TryTakeItem(handService, itemView);
        }
    }
}