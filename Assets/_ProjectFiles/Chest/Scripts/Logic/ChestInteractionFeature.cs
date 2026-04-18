using _ProjectFiles.Chest.Scripts.View;
using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Keys.View;
using UnityEngine;

namespace _ProjectFiles.Chest.Scripts.Logic
{
    public class ChestInteractionFeature : IInteractionFeature
    {
        public InteractableItemType Type => InteractableItemType.Chest;

        public InteractData GetInteractData(Player.Scripts.Core.Player player, InteractableView interactableView)
        {
            if (interactableView is not ChestView chestView)
                return default;

            if (player.Hand is not KeyView keyView)
            {
                return new InteractData
                {
                    CanInteract = false,
                    ActionName = "Нет ключа"
                };
            }

            if (keyView.ChestKeyType != chestView.KeyType)
            {
                return new InteractData
                {
                    CanInteract = false,
                    ActionName = "Не подходит"
                };
            }

            return new InteractData
            {
                CanInteract = true,
                ActionName = "Открыть"
            };
        }

        public void Interact(Player.Scripts.Core.Player player, InteractableView interactableView)
        {
            if (interactableView is not ChestView chestView)
                return;

            if (player.Hand is not KeyView keyView)
                return;

            if (keyView.ChestKeyType != chestView.KeyType)
            {
                Debug.Log("Заперто!");
                return;
            }

            chestView.Open();
            player.Hand = null;

            Debug.Log($"Chest {chestView.Id} opened");
        }
    }
}