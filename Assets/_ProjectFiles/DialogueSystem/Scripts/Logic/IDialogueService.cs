using System;
using _ProjectFiles.DialogueSystem.Scripts.Data;

namespace _ProjectFiles.DialogueSystem.Scripts.Logic
{
    public interface IDialogueService
    {
        event Action<DialogueNode> NodeChanged;
        event Action DialogueClosed;

        bool IsActive { get; }
        DialogueNode CurrentNode { get; }

        void StartDialogue(DialogueConfig config);
        void SelectChoice(int index);
        void Close();
        void Tick();
    }
}