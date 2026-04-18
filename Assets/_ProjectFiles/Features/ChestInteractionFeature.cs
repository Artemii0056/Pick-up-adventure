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

            public InteractData GetInteractData(Player player, InteractableEntity interactableEntity)
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

            public void Interact(Player player, InteractableEntity interactableEntity)
            {
                Chest chest = (Chest)interactableEntity;

                if (player.HasKey == false)
                    return;

                if (player.Hand.ItemType != ItemType.Key)
                    return;

                Key key = (Key)player.Hand;

                if (key.ChestKeyType == chest.KeyType)
                {
                    chest.Open();
                    Debug.Log($"Chest {interactableEntity.Id} opened");
                }
                else
                {
                    Debug.Log($"Заперто!");
                }
            }
        }
    }