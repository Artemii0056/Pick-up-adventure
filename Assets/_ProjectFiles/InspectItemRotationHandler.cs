using UnityEngine;

namespace _ProjectFiles
{
    public class InspectItemRotationHandler : ILookRotationHandler
    {
        private Transform _target;
        private readonly float _rotateSpeed;

        public InspectItemRotationHandler() => 
            _rotateSpeed = 10; //TODO В конфиг

        public void SetTarget(Transform target) => 
            _target = target;

        public void ClearTarget() => 
            _target = null;

        public void Handle(Vector2 lookDelta)
        {
            if (_target == null)
                return;

            _target.Rotate(Vector3.up, -lookDelta.x * _rotateSpeed, Space.World);
            _target.Rotate(Vector3.right, lookDelta.y * _rotateSpeed, Space.Self);
        }
    }
}