using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.StaticDatas.Scripts;
using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Movements
{
    public class PlayerMover : IPlayerMover
    {
        private readonly IPlayerInputReader _inputReader;
        private CharacterController _characterController;

        private float _moveSpeed;
        private float _gravity;

        private float _verticalVelocity;
        private Transform _playerTransform;

        public PlayerMover(
            IPlayerInputReader inputReader,
            IStaticDataService staticDataService)
        {
            PlayerMovementConfig config = staticDataService.PlayerMovementConfig;

            _moveSpeed = config.MoveSpeed;
            _gravity = config.Gravity;


            _inputReader = inputReader;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void Init(Transform playerTransform, CharacterController characterController)
        {
            _characterController = characterController;

            _playerTransform = playerTransform;
        }

        public void Tick()
        {
            Vector2 moveInput = _inputReader.MoveValue;

            Vector3 moveDirection = _playerTransform.right * moveInput.x + _playerTransform.forward * moveInput.y;
            Vector3 horizontalVelocity = moveDirection * _moveSpeed;

            if (_characterController.isGrounded && _verticalVelocity < 0f)
            {
                _verticalVelocity = -2f;
            }

            _verticalVelocity += _gravity * Time.deltaTime;

            Vector3 velocity = horizontalVelocity;
            velocity.y = _verticalVelocity;

            _characterController.Move(velocity * Time.deltaTime);
        }
    }
}