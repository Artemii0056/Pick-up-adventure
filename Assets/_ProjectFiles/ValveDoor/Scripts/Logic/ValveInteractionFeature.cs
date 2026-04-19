using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.ValveDoor.Scripts.View;

namespace _ProjectFiles.ValveDoor.Scripts.Logic
{
    public class ValveInteractionFeature : IInteractionFeature
    {
        public InteractableItemType Type => InteractableItemType.Valve;

        public bool TryGetInteractData(IHandService handService, InteractableView interactableView, out InteractData data)
        {
            data = default;

            if (interactableView is not ValveView)
                return false;

            data = new InteractData
            {
                CanInteract = true,
                ActionName = "Крутить"
            };

            return true;
        }

        public void Interact(IHandService handService, InteractableView interactableView)
        {
            if (interactableView is not ValveView valveView)
                return;

            valveView.RotateStep();
        }
    }
}