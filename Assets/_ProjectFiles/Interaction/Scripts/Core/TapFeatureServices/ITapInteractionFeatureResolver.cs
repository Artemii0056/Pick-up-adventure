using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;

namespace _ProjectFiles.Interaction.Scripts.Core.TapFeatureServices
{
    public interface ITapInteractionFeatureResolver
    {
        InteractionInputType Type { get; }
        bool TryGetInteractData(IHandService handService, InteractableView itemView, out InteractData interactData);
        bool TryInteract(IHandService handService, InteractableView itemView);
    }
}