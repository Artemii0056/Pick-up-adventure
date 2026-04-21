using _ProjectFiles.ValveDoor.Scripts.Logic;
using _ProjectFiles.ValveDoor.Scripts.View;
using UnityEngine;

namespace _ProjectFiles.ValveDoor.Scripts.Data
{
    public class ValveRotationService : IValveRotationService
    {
        private readonly IValveStorage _valveStorage;

        private ValveView _activeView;
        private bool _isRotating;

        public ValveRotationService(IValveStorage valveStorage) => 
            _valveStorage = valveStorage;

        public void StartRotate(ValveView valveView)
        {
            if (valveView == null)
                return;

            _activeView = valveView;
            _isRotating = true;
        }

        public void StopRotate() => 
            _isRotating = false;

        public void Tick()
        {
            if (_activeView == null)
                return;

            ValveModel model = _valveStorage.GetState(_activeView.Id);

            if (model == null)
                return;

            float speed = _isRotating
                ? model.Config.OpenSpeed
                : model.Config.ReturnSpeed;

            float targetProgress = _isRotating ? 1f : 0f;

            float newProgress = Mathf.MoveTowards(
                model.Progress,
                targetProgress,
                speed * Time.deltaTime);

            model.SetProgress(newProgress);
            _activeView.Render(model.Progress);

            if (!_isRotating && model.Progress <= 0f)
                _activeView = null;
        }
    }
}