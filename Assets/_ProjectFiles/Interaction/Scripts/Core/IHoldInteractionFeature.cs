using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public interface IHoldInteractionFeature
    {
        InteractableItemType Type { get; }

        bool TryGetInteractData(InteractableView interactableView, out InteractData interactData);
        void Interact(InteractableView itemView);
        void StopInteract();
    }
}