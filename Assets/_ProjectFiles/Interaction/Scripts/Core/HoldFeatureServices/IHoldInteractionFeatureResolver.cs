using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;

namespace _ProjectFiles.Interaction.Scripts.Core.HoldFeatureServices
{
    public interface IHoldInteractionFeatureResolver
    {
        InteractionInputType Type { get; }
        
        bool TryGetInteractData(
            IHandService handService,
            InteractableView interactableView,
            out InteractData interactData);

        bool TryStartInteraction(
            IHandService handService,
            InteractableView interactableView);

        void CancelInteraction(IHandService handService);

        void Tick(IHandService handService, float deltaTime);
    }
}