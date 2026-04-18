using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.ValveDoor.Scripts.View;

namespace _ProjectFiles.ValveDoor.Scripts.Logic
{
    public class ValveInteractionFeature : IInteractionFeature
    {
        public InteractableItemType Type => InteractableItemType.Valve;

        public InteractData GetInteractData(Player.Scripts.Core.Player player, InteractableView interactableView)
        {
            if (interactableView is not ValveView)
                return default;

            return new InteractData
            {
                CanInteract = true,
                ActionName = "Крутить",
            };
        }

        public void Interact(Player.Scripts.Core.Player player, InteractableView interactableView)
        {
            if (interactableView is not ValveView valveView)
                return;

            valveView.RotateStep();
        }
    }
}