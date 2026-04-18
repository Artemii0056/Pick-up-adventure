    using _ProjectFiles.InteractableObjects;
    using _ProjectFiles.InteractableObjects.Scripts;
    using _ProjectFiles.RaycastResolvers.Scripts;
    using UnityEngine;

    namespace _ProjectFiles.Features
    {
        public class ChestInteractionFeature : IInteractionFeature
        {
            private const string RequiredItemId = "key";

            public InteractableItemType Type => InteractableItemType.Chest;

            public InteractData GetInteractData(Player.Scripts.Core.Player player, ItemView itemView)
            {
                if (player.HasKey)
                {
                    return new InteractData
                    {
                        CanInteract = true,
                        ActionName = "Открыть" // Сделать SO для этого всего? 
                    };
                }

                return new InteractData
                {
                    CanInteract = false,
                    ActionName = " Нет кея"
                };
            }

            public void Interact(Player.Scripts.Core.Player player, ItemView itemView)
            {
                ChestView chestView = (ChestView)itemView;

                if (player.HasKey == false)
                    return;

                if (player.Hand.ItemType != ItemType.Key)
                    return;

                Key key = (Key)player.Hand;

                if (key.ChestKeyType == chestView.KeyType)
                {
                    chestView.Open();
                    Debug.Log($"Chest {itemView.Id} opened");
                }
                else
                {
                    Debug.Log($"Заперто!");
                }
            }
        }
    }