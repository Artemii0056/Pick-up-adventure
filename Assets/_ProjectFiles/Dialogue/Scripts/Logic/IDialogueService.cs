using System;
using _ProjectFiles.Dialogue.Scripts.Data;

namespace _ProjectFiles.Dialogue.Scripts.Logic
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