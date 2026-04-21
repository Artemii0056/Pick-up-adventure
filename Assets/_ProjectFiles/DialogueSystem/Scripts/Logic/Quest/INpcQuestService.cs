using _ProjectFiles.Items.Scripts.Data;

namespace _ProjectFiles.DialogueSystem.Scripts.Logic.Quest
{
    public interface INpcQuestService
    {
        bool HasActiveQuest { get; }
        bool IsCompleted { get; }
        ItemType RequestedItemType { get; }

        void StartQuest();
        bool TryCompleteQuest();
        string GetQuestText();
    }
}