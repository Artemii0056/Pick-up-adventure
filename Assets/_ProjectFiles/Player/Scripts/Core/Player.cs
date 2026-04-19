using System.Collections.Generic;
using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Chest.Scripts.Logic;
using _ProjectFiles.Chest.Scripts.View;
using _ProjectFiles.Interaction.Scripts.Core;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.NPC.Scripts.Logic;
using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.Player.Scripts.Raycast.Scripts;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.Slots.Scripts.Data;
using _ProjectFiles.Slots.Scripts.Logic;
using _ProjectFiles.Slots.Scripts.View;
using _ProjectFiles.UI;
using _ProjectFiles.ValveDoor.Scripts.Logic;
using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private bool _debug;
        
        [SerializeField] private InfoKeyView _keyView;
        
        [SerializeField] private PlayerInputReader _playerInputReader;

        private InteractionTargetResolver _interactionTargetResolver;

        private IRaycastService _raycastService;
        
        private IHandService _playerHandService;

        private InteractionFeatureService _interactionFeatureService;
        private IItemStorage _storage; //Сделать несколько стороджей
        private IChestStorage _chestStorage;
        private ISlotStorage _slotStorage;
        
        [SerializeField] private ItemView _keyItemView;

         [SerializeField] private ChestView _chestItemView;
         
         public List<SlotView> Slots { get; set; }
        // [SerializeField] private ItemView _questItemView;

        private void Awake()
        {
            _slotStorage = new SlotStorage();
            _chestStorage = new ChestStorage();
            _storage = new ItemStorage();
            PlayerHandModel playerHandModel = new PlayerHandModel();
            _playerHandService = new PlayerHandService(playerHandModel, _storage);

            foreach (var slot2 in Slots)
            {
                ISlotRule slotRule;
                
                if (slot2.SlotRuleType == SlotRuleType.Universal)
                {
                    slotRule = new UniversalSlotRule();
                }
                else
                {
                    slotRule = new FixedByIdSlotRule(1); 
                }
                
                _slotStorage.AddState(new SlotModel(slot2.Id, slotRule));
            }
            
            _raycastService = new RaycastService();
            _interactionTargetResolver = new InteractionTargetResolver(_raycastService);
                
            ChestInteractionFeature chest = new ChestInteractionFeature(_chestStorage);
            ItemInteractionFeature item = new ItemInteractionFeature(_storage);
            NpcInteractionFeature npc = new NpcInteractionFeature();
            SlotInteractionFeature slot = new SlotInteractionFeature(new SlotStorage());
            ValveInteractionFeature valve = new ValveInteractionFeature();
            _interactionFeatureService = new InteractionFeatureService(new List<IInteractionFeature>
            {
                chest , item, npc, slot, valve
                
            }, _keyView);
            
            _storage.AddState(new ItemModel(_keyItemView.Id, _keyItemView.ItemType));
            
            _chestStorage.AddState(new ChestModel(_chestItemView.Id, InteractableItemType.Chest));
            // _storage.AddState(new ItemModel(_noteItemView.Id, _noteItemView.ItemType));
            // _storage.AddState(new ItemModel(_questItemView.Id, _questItemView.ItemType));

            _playerInputReader.InteractStarted += OnInteractHeld;
        }

        private void OnDisable()
        {
            _playerInputReader.InteractStarted -= OnInteractHeld;
        }

        private void Update()
        {
            DrawDebug();

            if (_interactionTargetResolver.TryResolveTarget(Camera.main, 5f, _layerMask, out InteractableView entity))
            {
                _keyView.gameObject.SetActive(true);
                _interactionFeatureService.TryExecute(_playerHandService, entity);
            }
            else
            {
                _keyView.gameObject.SetActive(false);
            }
        }

        private void OnInteractHeld()
        {
            if (_interactionTargetResolver.TryResolveTarget(Camera.main, 5f, _layerMask, out InteractableView entity))
            {
                _interactionFeatureService.TryInteract(_playerHandService, entity);
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