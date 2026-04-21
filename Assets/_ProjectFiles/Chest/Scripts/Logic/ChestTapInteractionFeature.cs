using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Chest.Scripts.View;
using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Items.Keys.Scripts.Data;
using _ProjectFiles.Player.Scripts.Core;

namespace _ProjectFiles.Chest.Scripts.Logic
{
    public class ChestTapInteractionFeature : ITapInteractionFeature
    {
        private readonly IChestStorage _chestStorage; 
        private readonly IHandService _handService;

        public ChestTapInteractionFeature(IChestStorage chestStorage, IHandService handService)
        {
            _chestStorage = chestStorage;
            _handService = handService;
        }

        public InteractableItemType Type => InteractableItemType.Chest;
        
        public bool TryGetInteractData(InteractableView interactableView, out InteractData data)
        {
            data = default;

            if (interactableView is not ChestView chestView)
                return false;

            ChestModel chestModel = _chestStorage.GetState(chestView.Id);

            if (chestModel == null || chestModel.IsOpened)
                return false;

            bool canInteract =
                _handService.CurrentItem is KeyItemModel keyModel &&
                chestModel.CanOpenWith(keyModel);
            
            data = new InteractData
            {
                CanInteract = canInteract,
                ActionName = chestView.Config.ActionName
            };


            return true;
        }

        public void Interact(InteractableView interactableView)
        {
            if (interactableView is not ChestView chestView)
                return;

            ChestModel chestModel = _chestStorage.GetState(chestView.Id);

            if (chestModel == null || chestModel.IsOpened)
                return;

            if (_handService.CurrentItem is not KeyItemModel keyModel)
                return;

            if (!chestModel.CanOpenWith(keyModel))
                return;

            chestModel.Open();
            chestView.Open();
            _chestStorage.Remove(keyModel.Id);
            _handService.Clear();
        }
    }
}