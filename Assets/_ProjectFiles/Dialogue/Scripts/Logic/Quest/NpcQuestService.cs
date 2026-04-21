using System.Collections.Generic;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Player.Scripts.Core;
using UnityEngine;

namespace _ProjectFiles.Dialogue.Scripts.Logic.Quest
{
    public class NpcQuestService : INpcQuestService
    {
        private readonly IHandService _handService;

        public bool HasActiveQuest { get; private set; }
        public bool IsCompleted { get; private set; }
        public ItemType RequestedItemType { get; }

        private ItemType _requestedItemType;

        public NpcQuestService(IHandService handService)
        {
            _handService = handService;
        }

        public void StartQuest()
        {
            if (HasActiveQuest)
                return;

            // List<ItemType> possible = new() //TODO Выборку по всем предметам на счене - исключая ключ/запуску
            // {
            //     ItemType.QuestItem
            // };
            //
            // _requestedItemType = possible[Random.Range(0, possible.Count)];

            HasActiveQuest = true;
            IsCompleted = false;

            Debug.Log($"Quest started: bring {_requestedItemType}");
        }

        public bool TryCompleteQuest()
        {
            if (!HasActiveQuest || IsCompleted)
                return false;

            if (!_handService.HasItem)
                return false;

            if (_handService.CurrentItem.Type != _requestedItemType)
            {
                Debug.Log("Wrong item");
                return false;
            }

            _handService.Clear();

            IsCompleted = true;

            Debug.Log("Quest completed");
            return true;
        }

        public string GetQuestText()
        {
            if (!HasActiveQuest)
                return "";

            string name = _requestedItemType.ToString();

            return IsCompleted
                ? $"✓ Принести: {name}"
                : $"☐ Принести: {name}";
        }
    }
}