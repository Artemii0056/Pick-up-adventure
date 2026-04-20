using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public interface ITapInteractionFeature
    {
        InteractableItemType Type { get; }
        bool TryGetInteractData(InteractableView interactableView, out InteractData data);
        void Interact(InteractableView interactableView);
    }
}