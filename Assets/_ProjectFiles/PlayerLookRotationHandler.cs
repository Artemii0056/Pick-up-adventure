using _ProjectFiles.Player.Scripts.Rotation._ProjectFiles.Player.Scripts.Movements.Configs;
using _ProjectFiles.StaticDatas.Scripts;
using UnityEngine;
using VContainer;

namespace _ProjectFiles
{
    public class PlayerLookRotationHandler : ILookRotationHandler
    {
        private float _pitch;
        private readonly float _sensitivity;
        private readonly float _minPitch;
        private readonly float _maxPitch;

        private Transform _cameraRoot;
        private Transform _playerRoot;

        public PlayerLookRotationHandler(
            IStaticDataService staticDataService)
        {
            PlayerRotationConfig config = staticDataService.PlayerRotationConfig;
            _sensitivity = config.LookSensitivity;
            _minPitch = config.MinPitch;
            _maxPitch = config.MaxPitch;
        }

        [Inject]
        public void Init(PlayerTransformRoot playerRoot) => 
            _playerRoot = playerRoot.transform;

        public void Handle(Vector2 lookDelta)
        {
            Debug.Log(_playerRoot == null);
            
            float mouseX = lookDelta.x * _sensitivity;
            float mouseY = lookDelta.y * _sensitivity;

            _pitch -= mouseY;
            _pitch = Mathf.Clamp(_pitch, _minPitch, _maxPitch);

            Camera.main.transform.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
            _playerRoot.Rotate(Vector3.up * mouseX);
        }
    }
}