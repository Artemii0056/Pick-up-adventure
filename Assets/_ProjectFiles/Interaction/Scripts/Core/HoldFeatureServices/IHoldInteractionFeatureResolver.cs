using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;

namespace _ProjectFiles.Interaction.Scripts.Core.HoldFeatureServices
{
    public interface IHoldInteractionFeatureResolver
    {
        bool TryGetInteractData(InteractableView interactableView, out InteractData interactData);

        bool TryInteract(InteractableView interactableView);
        
        void CancelInteract();
    }
}