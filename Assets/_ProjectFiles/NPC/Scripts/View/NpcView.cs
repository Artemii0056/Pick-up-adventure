using _ProjectFiles.Dialogue.Scripts.Data;
using _ProjectFiles.Dialogue.Scripts.Logic;
using _ProjectFiles.Dialogue.Scripts.Logic.Quest;
using _ProjectFiles.Interaction.Scripts.View;
using UnityEngine;
using VContainer;

namespace _ProjectFiles.NPC.Scripts.View
{
    public class NpcView : InteractableView
    {
        [SerializeField] private DialogueConfig _dialogueConfig;
        [SerializeField] private DialogueConfig _questCheckConfig;

        private IDialogueService _dialogueService;
        private INpcQuestService _questService;

        [Inject]
        public void Construct(IDialogueService dialogueService, INpcQuestService questService)
        {
            _dialogueService = dialogueService;
            _questService = questService;

        }

        public void StartDialog()
        {
            Debug.Log("TryCompleteQuest failed: quest already completed");
            
            DialogueConfig config;

            if (!_questService.HasActiveQuest)
                config = _dialogueConfig;
            else if (!_questService.IsCompleted)
                config = _questCheckConfig;
            else
                config = _dialogueConfig; // или снова intro

            Debug.Log($"Selected config: {config.name}");
            
            _dialogueService.StartDialogue(config);
        }
    }
}