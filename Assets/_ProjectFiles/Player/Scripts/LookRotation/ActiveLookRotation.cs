using _ProjectFiles.Player.Scripts.Input.InputReader.Scripts;
using UnityEngine;

namespace _ProjectFiles.Player.Scripts.LookRotation
{
    public class ActiveLookRotation : IActiveLookRotation
    {
        private readonly IPlayerInputReader _playerInputReader;
        
        private ILookRotationHandler _currentHandler;
        
        private Vector2 _lookDelta;

        public ActiveLookRotation(IPlayerInputReader playerInputReader) => 
            _playerInputReader = playerInputReader;

        public void SetHandler(ILookRotationHandler handler) => 
            _currentHandler = handler;

        public void Tick()
        {
            if (_playerInputReader.MouseHeld == false) //TODO Почти
                return;
            
            _lookDelta = _playerInputReader.LookValue;
            
            if (_currentHandler == null || _lookDelta == Vector2.zero)
                return;

            _currentHandler.Handle(_lookDelta);
        }
    }
}