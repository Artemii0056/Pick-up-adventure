using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.ValveDoor.Scripts.View;

namespace _ProjectFiles.ValveDoor.Scripts.Logic
{
    public class ValveHoldInteractionFeature : IHoldInteractionFeature
    {
        private readonly IValveRotationService _rotationService;

        public ValveHoldInteractionFeature(IValveRotationService rotationService)
        {
            _rotationService = rotationService;
        }

        public InteractableItemType Type => InteractableItemType.Valve;

        public bool TryGetInteractData(InteractableView interactableView, out InteractData data)
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

        public void Interact(InteractableView interactableView)
        {
            if (interactableView is not ValveView valveView)
                return;

            _rotationService.StartRotate(valveView);
        }

        public void StopInteract()
        {
            _rotationService.StopRotate();
        }
    }
}