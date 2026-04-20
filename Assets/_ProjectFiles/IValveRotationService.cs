using _ProjectFiles.ValveDoor.Scripts.Data;
using _ProjectFiles.ValveDoor.Scripts.View;
using UnityEngine;
using VContainer.Unity;

namespace _ProjectFiles
{
    public interface IValveRotationService
    {
        void StartRotate(ValveView valveView, ValveModel valveModel);
        void StopRotate();
        void Tick();
    }

    public class ValveRotationService : IValveRotationService
    {
        private readonly float _forwardSpeed = 1f;
        private readonly float _backwardSpeed = 1f;

        private ValveView _activeView;
        private ValveModel _activeModel;
        private bool _isRotating;

        public void StartRotate(ValveView valveView, ValveModel valveModel)
        {
            _activeView = valveView;
            _activeModel = valveModel;
            _isRotating = true;
        }

        public void StopRotate()
        {
            _isRotating = false;
        }

        public void Tick()
        {
            if (_activeView == null || _activeModel == null)
                return;

            float progress = _activeModel.Progress;

            if (_isRotating)
                progress = Mathf.MoveTowards(progress, 1f, _forwardSpeed * Time.deltaTime);
            else
                progress = Mathf.MoveTowards(progress, 0f, _backwardSpeed * Time.deltaTime);

            _activeModel.SetProgress(progress);
            _activeView.Render(_activeModel.Progress);

            if (!_isRotating && _activeModel.Progress <= 0f)
            {
                _activeView = null;
                _activeModel = null;
            }
        }
    }
}