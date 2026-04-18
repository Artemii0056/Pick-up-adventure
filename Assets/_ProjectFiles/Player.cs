using System.Collections.Generic;
using _ProjectFiles.InteractableObjects;
using _ProjectFiles.Items;
using _ProjectFiles.Raycast.Scripts;
using _ProjectFiles.RaycastResolvers.Scripts;
using _ProjectFiles.UI;
using UnityEngine;

namespace _ProjectFiles
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private bool _debug;
        [SerializeField] public bool HasKey;
        
        [SerializeField] private InfoKeyView _keyView;

        private InteractionTargetResolver _interactionTargetResolver;

        private IRaycastService _raycastService;

        public InteractableEntity Hand;
        
        private InteractionFeatureService _interactionFeatureService;
        private ItemStorage _storage;
        
        [SerializeField] private InteractableEntity _interactableEntity;
        [SerializeField] private InteractableEntity _interactableEntity2;
        [SerializeField] private InteractableEntity _interactableEntity3;

        private void Awake()
        {
            _storage = new ItemStorage();
            _raycastService = new RaycastService();
            _interactionTargetResolver = new InteractionTargetResolver(_raycastService);
            ChestInteractionFeature chest = new ChestInteractionFeature(new ChestStateStorage(), this, _storage);
            _interactionFeatureService = new InteractionFeatureService(new List<IInteractionFeature> { chest }, _keyView); //TODO Тут остановился. Дальше тестить в апдейте. 
            _storage.AddState(_interactableEntity);
            _storage.AddState(_interactableEntity2);
            _storage.AddState(_interactableEntity3);
        }

        public void Init()
        {
            
        }

        private void Update()
        {
            DrawDebug();

            if (_interactionTargetResolver.TryResolveTarget(Camera.main, 5f, _layerMask, out InteractableEntity entity))
            {
                _keyView.gameObject.SetActive(true);
                _interactionFeatureService.TryExecute(this, entity);
            }
            else
            {
                _keyView.gameObject.SetActive(false);
            }
        }

        private void DrawDebug()
        {
#if UNITY_EDITOR
            if (!_debug)
                return;

            var camera = Camera.main;
            Debug.DrawRay(
                camera.transform.position,
                camera.transform.forward * 5f,
                Color.green
            );
#endif
        }
    }
}