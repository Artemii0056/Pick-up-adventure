using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.StaticDatas.Scripts;
using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Movements
{
    public class PlayerMover : IPlayerMover
    {
        private readonly IPlayerInputReader _inputReader;
        private CharacterController _characterController;

        private readonly float _moveSpeed;
        private readonly float _gravity;

        private float _verticalVelocity;
        private Transform _playerTransform;
        
        private bool _isActive;

        public PlayerMover(
            IPlayerInputReader inputReader,
            IStaticDataService staticDataService)
        {
            PlayerMovementConfig config = staticDataService.PlayerMovementConfig;

            _moveSpeed = config.MoveSpeed;
            _gravity = config.Gravity;
            
            _inputReader = inputReader;

            _isActive = true;
        }

        public void Init(Transform playerTransform, CharacterController characterController)
        {
            _characterController = characterController;

            _playerTransform = playerTransform;
        }

        public void Tick()
        {
            if (_isActive == false)
                return;
            
            Vector2 moveInput = _inputReader.MoveValue;

            Vector3 moveDirection = _playerTransform.right * moveInput.x + _playerTransform.forward * moveInput.y;
            Vector3 horizontalVelocity = moveDirection * _moveSpeed;

            if (_characterController.isGrounded && _verticalVelocity < 0f) 
                _verticalVelocity = -2f;

            _verticalVelocity += _gravity * Time.deltaTime;

            Vector3 velocity = horizontalVelocity;
            velocity.y = _verticalVelocity;

            _characterController.Move(velocity * Time.deltaTime);
        }

        public void Activate() => 
            _isActive = true;

        public void Deactivate() => 
            _isActive = false;
    }
}