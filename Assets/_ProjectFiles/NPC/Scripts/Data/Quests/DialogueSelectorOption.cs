using _ProjectFiles.DialogueSystem.Scripts.Data;

namespace _ProjectFiles.NPC.Scripts.Data.Quests
{
    public class DialogueSelectorOption
    {
        public string Title { get; }
        public DialogueConfig Dialogue { get; }

        public DialogueSelectorOption(string title, DialogueConfig dialogue)
        {
            Title = title;
            Dialogue = dialogue;
        }
    }
}