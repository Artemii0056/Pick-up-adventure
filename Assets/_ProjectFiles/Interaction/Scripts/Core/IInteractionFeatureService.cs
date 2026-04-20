using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public interface IInteractionFeatureService
    {
        void ShowViewData(IHandService handService, InteractableView itemView);
        void Interact(IHandService handService, InteractableView itemView);
        void Cancel();
    }
}