using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.ValveDoor.Scripts.Data;
using _ProjectFiles.ValveDoor.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.ValveDoor.Scripts.Logic
{
    public class ValveInteractionFeature : IHoldInteractionFeature
    {
        private IValveRotationService _valveRotationService;

        public ValveInteractionFeature(IValveRotationService valveRotationService)
        {
            _valveRotationService = valveRotationService;
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
            
            Debug.Log("ValveInteractionFeature Interact");

            _valveRotationService.StartRotate(valveView, valveView.Model);
        }
        
        public void StopInteract()
        {
            Debug.Log("ValveInteractionFeature StopInteract");
            _valveRotationService.StopRotate();
        }
    }
}