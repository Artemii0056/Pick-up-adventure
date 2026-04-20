using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;

namespace _ProjectFiles.Interaction.Scripts.Core.TapFeatureServices
{
    public interface ITapInteractionFeatureResolver
    {
        bool TryExecute(IHandService handService, InteractableView itemView);
        bool TryInteract(IHandService handService, InteractableView itemView);
        void Hide();
    }
}