using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public interface IHoldInteractionFeature
    {
        InteractableItemType Type { get; }

        bool TryGetInteractData(
            IHandService handService,
            InteractableView interactableView,
            out InteractData interactData);

        void StartInteraction(
            IHandService handService,
            InteractableView interactableView);

        void ProcessInteraction(
            IHandService handService,
            InteractableView interactableView,
            float deltaTime);

        void StopInteraction(
            IHandService handService,
            InteractableView interactableView);
    }
}