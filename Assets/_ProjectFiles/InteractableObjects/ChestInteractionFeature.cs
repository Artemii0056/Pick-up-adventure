using _ProjectFiles.InteractableObjects.Scripts;
using _ProjectFiles.Items;
using _ProjectFiles.RaycastResolvers.Scripts;
using UnityEngine;

namespace _ProjectFiles.InteractableObjects
{
    public class ChestInteractionFeature : IInteractionFeature
    {
        private const string RequiredItemId = "key";

        private readonly ChestStateStorage _chestStateStorage;
        private readonly Player _player;
        private readonly ItemStorage _itemStorage;

        public ChestInteractionFeature(ChestStateStorage chestStateStorage, Player player,
            ItemStorage itemStorage) //TODO Должен вернуть какую то логику своей работы
        {
            _chestStateStorage = chestStateStorage;
            _player = player;
            _itemStorage = itemStorage;
        }

        public InteractableItemType Type => InteractableItemType.Chest;

        public void Execute(InteractableEntity interactableEntity)
        {
            var chestState = _chestStateStorage.GetOrCreate(interactableEntity.Id);

            if (chestState.IsOpened)
                return;

            if (!_player.HasKey)
                return;

            chestState.Open();

            // Тут можно дернуть анимацию сундука / событие / view-компонент
            UnityEngine.Debug.Log($"Chest {interactableEntity.Id} opened");
        }

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

            if (player.Hand.InteractableItemType != InteractableItemType.Key)
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

    public struct InteractData
    {
        public InteractData(bool canInteract, string actionName)
        {
            CanInteract = canInteract;
            ActionName = actionName;
        }

        public bool CanInteract { get; set; }
        public string ActionName { get; set; }
    }
}