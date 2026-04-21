using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Chest.Scripts.View;
using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Player.Scripts.Core;
using UnityEngine;

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
            
            data = new InteractData
            {
                CanInteract = false,
                ActionName = "Открыть"
            };
            
            if (interactableView is not ChestView chestView)
                return false;

            ChestModel chestModel = _chestStorage.GetState(chestView.Id);

            if (chestModel.IsOpened)
                return false;
            
            data = new InteractData
            {
                CanInteract = true,
                ActionName = "Открыть"
            };
            
            return true;
        }

        public void Interact(InteractableView interactableView)
        {
            if (interactableView is not ChestView chestView)
                return;
            
            ChestModel chestModel = _chestStorage.GetState(chestView.Id);
            
            if (chestModel.IsOpened)
                return;
            
            if (!_handService.HasItem)
                return;
            
            Debug.Log(_handService.CurrentItem.GetType());
            
            if (_handService.CurrentItem is not KeyItemModel keyModel)
                return;
            
            chestModel.Open();
            chestView.Open();
            _handService.Clear();

            Debug.Log($"Chest {chestView.Id} opened");
        }
    }
}