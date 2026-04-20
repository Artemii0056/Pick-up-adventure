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
        private readonly IItemTransferService _transferService;
        private readonly IStoragePickedUpItems _storagePickedUpItems;

        public ItemInteractionFeature(IItemStorage itemStorage, IItemTransferService transferService, IStoragePickedUpItems storagePickedUpItems)
        {
            _itemStorage = itemStorage;
            _transferService = transferService;
            _storagePickedUpItems = storagePickedUpItems;
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
                ActionName = "Подобрать"
            };

            return true;
        }

        public void Interact(IHandService handService, InteractableView interactableView)
        {
            if (interactableView is not ItemView itemView)
                return;
            
            //Тут Сделать логику с новым/повторным подбором?

            _transferService.TryTakeItem(handService, itemView);
        }
    }
}