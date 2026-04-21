using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Core.TransferServices;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.StateMachine;
using _ProjectFiles.StateMachine.States;

namespace _ProjectFiles.Items.Scripts.Logic
{
    public class ItemTapInteractionFeature : ITapInteractionFeature
    {
        private readonly IItemStorage _itemStorage;
        private readonly IItemTransferService _transferService;
        private readonly IStoragePickedUpItems _storagePickedUpItems;
        private readonly IFirstPickUpItemFlow _firstPickUpItemFlow;
        private readonly IHandService _handService;
        private readonly IStateMachine _stateMachine;

        public ItemTapInteractionFeature(
            IItemStorage itemStorage, 
            IItemTransferService transferService,
            IStoragePickedUpItems storagePickedUpItems,
            IFirstPickUpItemFlow firstPickUpItemFlow,
            IHandService handService, IStateMachine stateMachine)
        {
            _itemStorage = itemStorage;
            _transferService = transferService;
            _storagePickedUpItems = storagePickedUpItems;
            _firstPickUpItemFlow = firstPickUpItemFlow;
            _handService = handService;
            _stateMachine = stateMachine;
        }

        public InteractableItemType Type => InteractableItemType.Item;

        public bool TryGetInteractData(InteractableView interactableView, out InteractData data)
        {
            data = default;

            if (interactableView is not ItemView itemView)
                return false;

            if (_handService.HasItem)
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
        
        public void Interact(InteractableView interactableView)
        {
            if (interactableView is not ItemView itemView)
                return;
            
            ItemModel itemModel = _itemStorage.GetState(itemView.Id);

            if (itemModel == null)
                return;
            
            bool alreadySeen = _storagePickedUpItems.HasItem(itemModel.Id, itemModel.Type);

            if (alreadySeen)
            {
                _transferService.TryTakeItem(itemView);
                return;
            }

            _stateMachine.Enter<FirstPickUpState, ItemView>(itemView);
            _firstPickUpItemFlow.Show(itemView);
        }
    }
}