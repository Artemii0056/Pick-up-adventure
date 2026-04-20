using _ProjectFiles.Interaction.Scripts.View;
using _ProjectFiles.ValveDoor.Scripts.Data;
using UnityEngine;

namespace _ProjectFiles.ValveDoor.Scripts.View
{
    public class ValveView : InteractableView
    {
        [SerializeField] private Transform _valveTransform;
        [SerializeField] private Transform _doorTransform;
        [SerializeField] private float _doorMaxOffsetY = 2f;
        [SerializeField] private float _valveMaxAngle = 360f;

        private Vector3 _doorStartLocalPosition;
        private Quaternion _valveStartLocalRotation;

        public ValveModel Model { get; } = new();

        private void Awake()
        {
            _doorStartLocalPosition = _doorTransform.localPosition;
            _valveStartLocalRotation = _valveTransform.localRotation;
        }

        public void Render(float progress)
        {
            progress = Mathf.Clamp01(progress);

            Vector3 doorPosition = _doorStartLocalPosition;
            doorPosition.y += _doorMaxOffsetY * progress;
            _doorTransform.localPosition = doorPosition;

            float valveAngle = _valveMaxAngle * (1f - progress);
            _valveTransform.localRotation =
                _valveStartLocalRotation * Quaternion.Euler(0f, 0f, valveAngle);
        }
    }
}