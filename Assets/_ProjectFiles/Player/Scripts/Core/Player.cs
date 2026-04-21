using _ProjectFiles.Chest.Scripts.View;
using _ProjectFiles.Items.Keys.Scripts.View;
using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.Player.Scripts.Movements;
using _ProjectFiles.Player.Scripts.Rotation;
using _ProjectFiles.Player.Scripts.View;
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

        private IPlayerInteractionController _playerInteractionController;

        private IPlayerRotator _playerRotator;
        private IPlayerMover _playerMover;
        private IPlayerInputReader _playerInputReader;

        [Inject]
        public void Constructor(
            IPlayerRotator playerRotator,
            IPlayerMover playerMover,
            IPlayerInteractionController playerInteractionController,
            IPlayerInputReader playerInputReader)
        {
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

        }

        private void OnDisable()
        {
            _playerInteractionController.Dispose();
            _playerInputReader.OnDisable();
        }

        private void Update()
        {
            _playerInteractionController.Tick();
        }
    }
}