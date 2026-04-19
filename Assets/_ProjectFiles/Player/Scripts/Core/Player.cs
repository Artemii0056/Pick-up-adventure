using System;
using System.Collections.Generic;
using _ProjectFiles.Chest.Scripts.Data;
using _ProjectFiles.Chest.Scripts.View;
using _ProjectFiles.Interaction.Scripts.Data;
using _ProjectFiles.Keys.Scripts.Data;
using _ProjectFiles.Keys.Scripts.View;
using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.Player.Scripts.Movements;
using _ProjectFiles.Player.Scripts.Rotation;
using _ProjectFiles.Player.Scripts.View;
using _ProjectFiles.Slots.Scripts.Data;
using _ProjectFiles.Slots.Scripts.View;
using _ProjectFiles.UI;
using UnityEngine;
using VContainer;

namespace _ProjectFiles.Player.Scripts.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;

        [SerializeField] private PlayerHandView _playerHandView;

        [SerializeField] private InfoKeyView _keyView;

        [SerializeField] private KeyView _keyItemView;

        [SerializeField] private ChestView _chestItemView;

        [SerializeField] private CharacterController _characterController;

        public List<SlotView> Slots;

        private ISlotModelFactory _slotModelFactory;
        private IKeyModelFactory _keyModelFactory;
        private IChestModelFactory _chestModelFactor;

        private IPlayerInteractionController _playerInteractionController;

        private IPlayerRotator _playerRotator;
        private IPlayerMover _playerMover;
        private IPlayerInputReader _playerInputReader;

        [Inject]
        public void Constructor(ISlotModelFactory slotModelFactory,
            IKeyModelFactory keyModelFactory,
            IChestModelFactory chestModelFactor,
            IPlayerRotator playerRotator,
            IPlayerMover playerMover,
            IPlayerInteractionController playerInteractionController,
            IPlayerInputReader playerInputReader)
        {
            _slotModelFactory = slotModelFactory;
            _keyModelFactory = keyModelFactory;
            _chestModelFactor = chestModelFactor;

            _playerInteractionController = playerInteractionController;

            _playerRotator = playerRotator;
            _playerRotator.Init(Camera.main.transform, transform);

            _playerMover = playerMover;
            _playerMover.Init(transform, _characterController);

            _playerInputReader = playerInputReader;
            
            playerInputReader.OnEnable();
        }

        private void Start()
        {
            _playerInteractionController.SetLayer(_layerMask);
            _playerInteractionController.Start();

            foreach (var slot2 in Slots)
            {
                _slotModelFactory.Create(slot2.SlotRuleType, slot2.Id); //Сюда нужно передать id предмета, а не слота
            }

            _keyModelFactory.CreateKeyModel(_keyItemView.Id, _keyItemView.ItemType, ChestKeyType.None);
            _chestModelFactor.CreateKeyModel(_chestItemView.Id, InteractableItemType.Chest);
        }

        private void OnDisable()
        {
            _playerInteractionController.Dispose();
            _playerInputReader.OnDisable();
        }

        private void Update()
        {
            _playerInteractionController.Tick();
            _playerRotator.Tick();
            _playerMover.Tick();
        }
    }
}