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

        public NpcQuestService(IHandService handService, IItemStorage itemStorage)
        {
            _handService = handService;
            _itemStorage = itemStorage;
        }
        
        private ItemType _requestedItemType = ItemType.None;

        public bool HasActiveQuest { get; private set; }
        public bool IsCompleted { get; private set; }
        public ItemType RequestedItemType => _requestedItemType;

        public void StartQuest()
        {
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
                return;
            }

            _requestedItemType = possibleTypes[Random.Range(0, possibleTypes.Count)];
            HasActiveQuest = true;
            IsCompleted = false;
        }

        public bool TryCompleteQuest()
        {
            if (!HasActiveQuest)
            {
                return false;
            }

            if (IsCompleted)
            {
                return false;
            }

            if (!_handService.HasItem)
            {
                return false;
            }

            if (_handService.CurrentItem.Type != _requestedItemType)
            {
                return false;
            }

            _handService.Clear();
            IsCompleted = true;

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
                ItemType.SomeObject => ItemType.SomeObject.ToString(),
                _ => itemType.ToString()
            };
        }
    }
}