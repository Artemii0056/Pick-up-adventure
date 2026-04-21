using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public interface IInteractionFeatureService
    {
        void ShowViewData(InteractableView itemView);
        void Interact(InteractableView itemView);
        void Cancel();
    }
}