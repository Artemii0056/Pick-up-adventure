using _ProjectFiles.Interaction.Scripts.Core.HoldFeatureServices;
using _ProjectFiles.Interaction.Scripts.Core.TapFeatureServices;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Core;
using _ProjectFiles.UI;

namespace _ProjectFiles.Interaction.Scripts.Core
{
    public class InteractionFeatureService : IInteractionFeatureService
    {
        private readonly InfoKeyView _keyView;
        private readonly ITapInteractionFeatureResolver _tapResolver;
        private readonly IHoldInteractionFeatureResolver _holdResolver;
        
        public InteractionFeatureService(InfoKeyView keyView,
            IHoldInteractionFeatureResolver holdResolver,
            ITapInteractionFeatureResolver tapResolver)
        {
            _keyView = keyView;
            _holdResolver = holdResolver;
            _tapResolver = tapResolver;
        }

        public void Interact(IHandService handService, InteractableView itemView)
        {
            if (itemView == null)
                return;
            
            switch (itemView.InteractionInputType) 
            {
                case InteractionInputType.Tap:
                    _tapResolver.TryInteract(itemView);
                    break;
            
                case InteractionInputType.Hold:
                    _holdResolver.TryInteract( itemView);
                    break;
            }
        }

        public void Cancel() => 
            _holdResolver.CancelInteract();

        public void ShowViewData(IHandService handService, InteractableView itemView)
        {
            if (itemView == null)
            {
                HideViewData();
                return;
            }

            if (TryGetInteractData(handService, itemView, out InteractData interactData) == false)
            {
                HideViewData();
                return;
            }

            if (interactData.CanInteract == false)
            {
                HideViewData();
                return;
            }

            _keyView.gameObject.SetActive(true);
            _keyView.UpdateText(interactData.ActionName);
        }

        private bool TryGetInteractData(
            IHandService handService,
            InteractableView itemView,
            out InteractData interactData)
        {
            interactData = default;

            if (_tapResolver.TryGetInteractData(itemView, out interactData))
                return true;

            if (_holdResolver.TryGetInteractData(itemView, out interactData))
                return true;

            return false;
        }

        private void HideViewData()
        {
            _keyView.gameObject.SetActive(false);
        }
    }
}