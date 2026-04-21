using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;

namespace _ProjectFiles.Interaction.Scripts.Core.TapFeatureServices
{
    public interface ITapInteractionFeatureResolver
    {
        bool TryGetInteractData(InteractableView itemView, out InteractData interactData);
        bool TryInteract(InteractableView itemView);
    }
}