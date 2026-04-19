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
        private readonly IInteractionFeatureService _interactionFeatureService;
        private readonly IHandService _handService;
        
        private LayerMask _interactionLayerMask;

        public PlayerInteractionController(
            IPlayerInputReader playerInputReader,
            IInteractionTargetResolver interactionTargetResolver,
            IInteractionFeatureService interactionFeatureService,
            IHandService handService)
        {
            _playerInputReader = playerInputReader;
            _interactionTargetResolver = interactionTargetResolver;
            _interactionFeatureService = interactionFeatureService;
            _handService = handService;
        }

        public void SetLayer(LayerMask interactionLayerMask) => 
            _interactionLayerMask = interactionLayerMask;

        public void Start()
        {
            _playerInputReader.InteractStarted += OnInteractStarted;
        }

        public void Tick()
        {
            DrawDebug();

            if (_interactionTargetResolver.TryResolveTarget(
                    Camera.main,
                    5f,
                    _interactionLayerMask,
                    out InteractableView target))
            {
                _interactionFeatureService.TryExecute(_handService, target);
                return;
            }

            _interactionFeatureService.Hide();
        }

        public void Dispose()
        {
            _playerInputReader.InteractStarted -= OnInteractStarted;
        }

        private void OnInteractStarted()
        {
            if (_interactionTargetResolver.TryResolveTarget(
                    Camera.main,
                    5f,
                    _interactionLayerMask,
                    out InteractableView target))
            {
                _interactionFeatureService.TryInteract(_handService, target);
            }
        }

        private void DrawDebug()
        {
#if UNITY_EDITOR
            Camera camera = Camera.main;
            if (camera == null)
                return;

            Debug.DrawRay(
                camera.transform.position,
                camera.transform.forward * 5f,
                Color.green);
#endif
        }
    }
}