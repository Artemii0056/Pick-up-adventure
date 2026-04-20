using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public interface IInteractionFeatureService
    {
        void Update(IHandService handService, InteractableView interactableView);
        void Clear();
        void StartInteraction(IHandService handService, InteractableView interactableView);
        void CancelInteraction(IHandService handService);
        void Tick(IHandService handService, float deltaTime);
    }
}