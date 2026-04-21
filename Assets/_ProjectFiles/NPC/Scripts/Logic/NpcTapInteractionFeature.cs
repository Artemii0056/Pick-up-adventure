using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.NPC.Scripts.Data;
using _ProjectFiles.NPC.Scripts.View;

namespace _ProjectFiles.NPC.Scripts.Logic
{
    public class NpcTapInteractionFeature : ITapInteractionFeature
    {
        private readonly INpcInteractionService _npcInteractionService;

        public NpcTapInteractionFeature(INpcInteractionService npcInteractionService) => 
            _npcInteractionService = npcInteractionService;

        public InteractableItemType Type => InteractableItemType.NPC; //TODO Надо ли? 

        public bool TryGetInteractData(InteractableView interactableView, out InteractData data)
        {
            data = default;

            if (interactableView is not NpcView)
                return false;

            data = new InteractData
            {
                CanInteract = true,
                ActionName = "Говорить"
            };

            return true;
        }

        public void Interact(InteractableView interactableView)
        {
            if (interactableView is not NpcView npcView)
                return;

            _npcInteractionService.StartDialogue(npcView.Id);
        }
    }
}