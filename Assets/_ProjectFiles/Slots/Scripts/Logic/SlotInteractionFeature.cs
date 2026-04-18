using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Slots.Scripts.View;

namespace _ProjectFiles.Slots.Scripts.Logic
{
    public class SlotInteractionFeature : IInteractionFeature
    {
        public InteractableItemType Type => InteractableItemType.Slot;

        public InteractData GetInteractData(Player.Scripts.Core.Player player, InteractableView interactableView)
        {
            if (interactableView is not SlotView slotView)
                return default;

            return default;
        }

        public void Interact(Player.Scripts.Core.Player player, InteractableView interactableView)
        {
            if (interactableView is not SlotView slotView)
                return;

            // дальше логика слота
        }
    }
}