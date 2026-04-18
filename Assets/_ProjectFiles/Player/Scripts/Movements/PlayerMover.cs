using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Movements
{
    public class PlayerMover : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private PlayerInputReader _inputReader;

        [SerializeField] private Transform _cameraRoot;

        [Header("Movement")] [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _gravity = -9.81f;

        [Header("Look")] [SerializeField] private float _lookSensitivity = 10f;
        [SerializeField] private float _minPitch = -80f;
        [SerializeField] private float _maxPitch = 80f;

        private CharacterController _characterController;
        private float _verticalVelocity;
        private float _pitch;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            HandleLook();
            HandleMovement();
        }

        private void HandleLook()
        {
            Vector2 lookInput = _inputReader.LookValue;

            float mouseX = lookInput.x * _lookSensitivity;
            float mouseY = lookInput.y * _lookSensitivity;

            _pitch -= mouseY;
            _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

            _cameraRoot.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
            transform.Rotate(Vector3.up * mouseX);
        }

        private void HandleMovement()
        {
            Vector2 moveInput = _inputReader.MoveValue;

            Vector3 moveDirection = transform.right * moveInput.x + transform.forward * moveInput.y;
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