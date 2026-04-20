using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;

namespace _ProjectFiles.Interaction.Scripts.Core.HoldFeatureServices
{
    public class HoldInteractionFeatureResolver : IHoldInteractionFeatureResolver
    {
        public InteractionInputType Type => InteractionInputType.Hold;

        public bool TryGetInteractData(IHandService handService, InteractableView interactableView, out InteractData interactData)
        {
            throw new System.NotImplementedException();
        }

        public bool TryStartInteraction(IHandService handService, InteractableView interactableView)
        {
            throw new System.NotImplementedException();
        }

        public void CancelInteraction(IHandService handService)
        {
            throw new System.NotImplementedException();
        }

        public void Tick(IHandService handService, float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}