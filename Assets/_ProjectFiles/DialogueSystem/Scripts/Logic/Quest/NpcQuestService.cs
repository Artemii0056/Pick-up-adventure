using System.Collections.Generic;
using System.Linq;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.Player.Scripts.Core;
using UnityEngine;

namespace _ProjectFiles.DialogueSystem.Scripts.Logic.Quest
{
    public class NpcQuestService : INpcQuestService
    {
        private readonly IHandService _handService;
        private readonly IItemStorage _itemStorage;

        private ItemType _requestedItemType = ItemType.None;

        public bool HasActiveQuest { get; private set; }
        public bool IsCompleted { get; private set; }
        public ItemType RequestedItemType => _requestedItemType;

        public NpcQuestService(IHandService handService, IItemStorage itemStorage)
        {
            _handService = handService;
            _itemStorage = itemStorage;
        }

        public void StartQuest()
        {
            Debug.Log("StartQuest");
            
            if (HasActiveQuest)
                return;

            List<ItemType> possibleTypes = _itemStorage.GetAll()
                .Select(x => x.Type)
                .Where(x => x != ItemType.None &&
                            x != ItemType.Key &&
                            x != ItemType.Note)
                .Distinct()
                .ToList();

            if (possibleTypes.Count == 0)
            {
                Debug.LogWarning("Quest cannot start: no valid quest items in ItemStorage.");
                return;
            }

            _requestedItemType = possibleTypes[UnityEngine.Random.Range(0, possibleTypes.Count)];
            HasActiveQuest = true;
            IsCompleted = false;

            Debug.Log($"Quest started: bring {_requestedItemType}");
        }

        public bool TryCompleteQuest()
        {
            Debug.Log("TryCompleteQuest called");

            if (!HasActiveQuest)
            {
                Debug.Log("TryCompleteQuest failed: no active quest");
                return false;
            }

            if (IsCompleted)
            {
                Debug.Log("TryCompleteQuest failed: quest already completed");
                return false;
            }

            if (!_handService.HasItem)
            {
                Debug.Log("TryCompleteQuest failed: no item in hand");
                return false;
            }

            Debug.Log($"Item in hand: {_handService.CurrentItem.Type}, requested: {_requestedItemType}");

            if (_handService.CurrentItem.Type != _requestedItemType)
            {
                Debug.Log("TryCompleteQuest failed: wrong item type");
                return false;
            }

            _handService.Clear();
            IsCompleted = true;

            Debug.Log($"Quest completed with {_requestedItemType}");
            return true;
        }

        public string GetQuestText()
        {
            if (!HasActiveQuest)
                return string.Empty;

            string itemName = GetReadableName(_requestedItemType);

            return IsCompleted
                ? $"✓ Принести: {itemName}"
                : $"☐ Принести: {itemName}";
        }

        private static string GetReadableName(ItemType itemType)
        {
            return itemType switch
            {
                ItemType.SomeObject => "предмет",
                _ => itemType.ToString()
            };
        }
    }
}