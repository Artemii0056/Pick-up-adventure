using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.Player.Scripts.Resolvers;
using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Core
{
    public class PlayerInteractionController : IPlayerInteractionController
    {
        private readonly IPlayerInputReader _playerInputReader;
        private readonly IInteractionTargetResolver _interactionTargetResolver;
        private readonly IHandService _handService;
        private readonly IInteractionFeatureService _interactionFeatureService;
        
        private LayerMask _interactionLayerMask;

        public PlayerInteractionController(
            IPlayerInputReader playerInputReader,
            IInteractionTargetResolver interactionTargetResolver,
            IHandService handService,
            IInteractionFeatureService interactionFeatureService)
        {
            _playerInputReader = playerInputReader;
            _interactionTargetResolver = interactionTargetResolver;
            _handService = handService;
            _interactionFeatureService = interactionFeatureService;
        }

        public void SetLayer(LayerMask interactionLayerMask) => 
            _interactionLayerMask = interactionLayerMask;

        public void Start()
        {
            _playerInputReader.InteractStarted += OnInteractStarted;
            _playerInputReader.InteractCanceled += OnInteractCanceled;
        }

        public void Tick()
        {
            if (_interactionTargetResolver.TryResolveTarget(
                    Camera.main,
                    5f,
                    _interactionLayerMask,
                    out InteractableView interactableView))
            {
                _interactionFeatureService.ShowViewData(_handService, interactableView);;
            }
        }

        public void Dispose()
        {
            _playerInputReader.InteractStarted -= OnInteractStarted;
            _playerInputReader.InteractCanceled -= OnInteractCanceled;
        }

        private void OnInteractCanceled()
        {
            _interactionFeatureService.Cancel();
        }

        private void OnInteractStarted()
        {
            if (_interactionTargetResolver.TryResolveTarget(
                    Camera.main,
                    5f,
                    _interactionLayerMask,
                    out InteractableView interactableView))
            {
                _interactionFeatureService.Interact(_handService, interactableView);
            }
        }
    }
}