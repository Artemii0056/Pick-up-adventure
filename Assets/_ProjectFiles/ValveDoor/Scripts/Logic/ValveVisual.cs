using _ProjectFiles.ValveDoor.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.ValveDoor.Scripts.Logic
{
    public class ValveVisual : MonoBehaviour
    {
        [SerializeField] private Transform _valveTransform;

        private Transform _doorTransform;
        private ValveConfig _config;
        private Vector3 _doorStartLocalPosition;
        private Quaternion _valveStartLocalRotation;

        public void Initialize(ValveConfig config, Transform doorTransform)
        {
            _config = config;
            _doorTransform = doorTransform;

            _doorStartLocalPosition = _doorTransform.localPosition;
            _valveStartLocalRotation = _valveTransform.localRotation;
        }

        public void Render(float progress)
        {
            if (_config == null || _doorTransform == null || _valveTransform == null)
                return;

            progress = Mathf.Clamp01(progress);

            Vector3 doorPosition = _doorStartLocalPosition;
            doorPosition.y += _config.DoorMaxOffsetY * progress;
            _doorTransform.localPosition = doorPosition;

            float valveAngle = _config.ValveMaxAngle * (1f - progress);
            _valveTransform.localRotation =
                _valveStartLocalRotation * Quaternion.Euler(0f, valveAngle, 0f);
        }
    }
}