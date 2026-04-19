using _ProjectFiles.Chest.Scripts.View;
using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Player.Scripts.Core;
using UnityEngine;

namespace _ProjectFiles.Chest.Scripts.Logic
{
    public class ChestInteractionFeature : IInteractionFeature
    {
        private readonly IItemStorage _itemStorage; 

        public ChestInteractionFeature(IItemStorage itemStorage) => 
            _itemStorage = itemStorage;

        public InteractableItemType Type => InteractableItemType.Chest;
        
        public bool TryGetInteractData(IHandService handService, InteractableView interactableView, out InteractData data)
        {
            data = default;
            
            if (interactableView is not ChestView chestView)
                return false;

            ChestModel chestModel = (ChestModel)_itemStorage.GetState(chestView.Id);

            if (chestModel.IsOpened)
                return false;

            if (handService.HasItem == false)
            {
                return false;
            }

            if (handService.CurrentItem is not KeyModel keyModel) 
            {
                return false;
            }

            if (keyModel.ChestKeyType != chestModel.ReqiereKeyType)
            {
                return false;
            }

            data = new InteractData
            {
                CanInteract = true,
                ActionName = "Открыть"
            };

            return true;
        }

        public void Interact(IHandService handService, InteractableView interactableView)
        {
            if (interactableView is not ChestView chestView)
                return;

            ChestModel chestModel = (ChestModel)_itemStorage.GetState(chestView.Id);

            if (chestModel.IsOpened)
                return;

            if (!handService.HasItem)
                return;

            if (handService.CurrentItem is not KeyModel keyModel)
                return;

            if (keyModel.ChestKeyType != chestModel.ReqiereKeyType)
            {
                Debug.Log("Заперто!");
                return;
            }

            chestModel.Open();
            chestView.Open();
            handService.Clear();

            Debug.Log($"Chest {chestView.Id} opened");
        }
    }
}