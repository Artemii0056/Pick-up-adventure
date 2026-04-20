using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public interface IHoldInteractionFeature
    {
        void StartHold(IHandService handService, InteractableView itemView);
        void ProcessHold(IHandService handService, InteractableView itemView, float deltaTime);
        void StopHold(IHandService handService, InteractableView itemView);
    }
}