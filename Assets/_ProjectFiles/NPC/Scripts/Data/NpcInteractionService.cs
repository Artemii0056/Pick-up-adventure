using _ProjectFiles.DialogueSystem.Scripts.Logic;
using _ProjectFiles.NPC.Scripts.Logic;
using UnityEngine;

namespace _ProjectFiles.NPC.Scripts.Data
{
    public class NpcInteractionService : INpcInteractionService
    {
        private readonly INpcStorage _npcStorage;
        private readonly INpcDialogueResolver _dialogueResolver;
        private readonly IDialogueService _dialogueService;

        public NpcInteractionService(
            INpcStorage npcStorage,
            INpcDialogueResolver dialogueResolver,
            IDialogueService dialogueService)
        {
            _npcStorage = npcStorage;
            _dialogueResolver = dialogueResolver;
            _dialogueService = dialogueService;
        }

        public void StartDialogue(int npcId)
        {
            if (!_npcStorage.TryGetState(npcId, out NpcModel npcModel))
            {
                return;
            }

            var dialogue = _dialogueResolver.Resolve(npcModel);

            if (dialogue == null)
            {
                return;
            }

            _dialogueService.StartDialogue(dialogue);
        }
    }
}