using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.NPC.Scripts.View;

namespace _ProjectFiles.NPC.Scripts.Logic
{
    public class NpcTapInteractionFeature : ITapInteractionFeature
    {
        private readonly INpcDialogueSelectorService _selectorService;

        public NpcTapInteractionFeature(INpcDialogueSelectorService selectorService)
        {
            _selectorService = selectorService;
        }

        public InteractableItemType Type => InteractableItemType.NPC;

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

            _selectorService.StartDialogue(npcView.Id);
        }
    }
}