using System.Collections.Generic;
using _ProjectFiles.Chest.Scripts.Logic;
using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Items;
using _ProjectFiles.Items.Scripts.Data;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.NPC.Scripts.Logic;
using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.Player.Scripts.Raycast.Scripts;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.Logic;
using _ProjectFiles.UI;
using _ProjectFiles.ValveDoor.Scripts.Logic;
using UnityEngine;
using UnityEngine.Serialization;

namespace _ProjectFiles.Player.Scripts.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private bool _debug;
        [SerializeField] public bool HasKey;
        
        [SerializeField] private InfoKeyView _keyView;
        
        [SerializeField] private PlayerInputReader _playerInputReader;

        private InteractionTargetResolver _interactionTargetResolver;

        private IRaycastService _raycastService;

        public Item Hand;
        
        private InteractionFeatureService _interactionFeatureService;
        private ItemStorage _storage;
        
        [FormerlySerializedAs("_interactableEntity")] [SerializeField] private ItemView itemView;
        [SerializeField] private ItemView _interactableEntity2;
        [SerializeField] private ItemView _interactableEntity3;

        private void Awake()
        {
            _storage = new ItemStorage();
            _raycastService = new RaycastService();
            _interactionTargetResolver = new InteractionTargetResolver(_raycastService);
                
            ChestInteractionFeature chest = new ChestInteractionFeature();
            ItemInteractionFeature item = new ItemInteractionFeature();
            NpcInteractionFeature npc = new NpcInteractionFeature();
            SlotInteractionFeature slot = new SlotInteractionFeature();
            ValveInteractionFeature valve = new ValveInteractionFeature();
            _interactionFeatureService = new InteractionFeatureService(new List<IInteractionFeature>
            {
                chest , item, npc, slot, valve
                
            }, _keyView);
            
            _storage.AddState(itemView);
            _storage.AddState(_interactableEntity2);
            _storage.AddState(_interactableEntity3);

            _playerInputReader.InteractStarted += OnInteractHeld;
        }

        private void OnDisable()
        {
            _playerInputReader.InteractStarted -= OnInteractHeld;
        }

        private void Update()
        {
            DrawDebug();

            if (_interactionTargetResolver.TryResolveTarget(Camera.main, 5f, _layerMask, out ItemView entity))
            {
                _keyView.gameObject.SetActive(true);
                _interactionFeatureService.TryExecute(this, entity);
            }
            else
            {
                _keyView.gameObject.SetActive(false);
            }
        }

        private void OnInteractHeld()
        {
            if (_interactionTargetResolver.TryResolveTarget(Camera.main, 5f, _layerMask, out ItemView entity))
            {
                _interactionFeatureService.TryInteract(this, entity);
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