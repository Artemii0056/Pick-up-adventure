using _ProjectFiles.Dialogue.Scripts.Data;
using _ProjectFiles.Dialogue.Scripts.Logic;
using _ProjectFiles.Interaction.Scripts.View;
using UnityEngine;
using VContainer;

namespace _ProjectFiles.NPC.Scripts.View
{
    public class NpcView : InteractableView
    {
        [SerializeField] private DialogueConfig _dialogueConfig;

        private IDialogueService _dialogueService;

        [Inject]
        public void Construct(IDialogueService dialogueService)
        {
            _dialogueService = dialogueService;
        }

        public void StartDialog()
        {
            _dialogueService.StartDialogue(_dialogueConfig);
        }
    }
}