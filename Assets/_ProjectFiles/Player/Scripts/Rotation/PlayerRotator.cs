using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using _ProjectFiles.Player.Scripts.Rotation._ProjectFiles.Player.Scripts.Movements.Configs;
using _ProjectFiles.StaticDatas.Scripts;
using UnityEngine;

namespace _ProjectFiles.Player.Scripts.Rotation
{
    public class PlayerRotator : IPlayerRotator
    {
        private readonly IPlayerInputReader _inputReader;
        private float _pitch;

        private readonly float _lookSensitivity;
        private readonly float _minPitch;
        private readonly float _maxPitch;
        private  Transform _cameraRoot;
        private Transform _playerRoot;

        public PlayerRotator(IPlayerInputReader inputReader, IStaticDataService staticDataService)
        {
            PlayerRotationConfig config = staticDataService.PlayerRotationConfig;
            
            _inputReader = inputReader;
            
            _minPitch = config.MinPitch;
            _maxPitch = config.MaxPitch;
            _lookSensitivity = config.LookSensitivity;

            _lookSensitivity = 10f;
        }

        public void Init(Transform cameraRoot, Transform playerRoot)
        {
            _cameraRoot = cameraRoot;
            _playerRoot = playerRoot;
        }

        public void Tick()
        {
            Vector2 lookInput = _inputReader.LookValue;

            float mouseX = lookInput.x * _lookSensitivity;
            float mouseY = lookInput.y * _lookSensitivity;

            _pitch -= mouseY;
            _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

            _cameraRoot.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
            _playerRoot.transform.Rotate(Vector3.up * mouseX);
        }
    }
}