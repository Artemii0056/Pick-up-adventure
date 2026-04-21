using _ProjectFiles.Player.Scripts.LookRotation;
using _ProjectFiles.StateMachine.Data;

namespace _ProjectFiles.StateMachine.States
{
    public class GamePlayState : IState
    {
        private readonly IActiveLookRotation _activeLookRotation;
        private readonly PlayerLookRotationHandler _playerLookRotationHandler;

        public GamePlayState(IActiveLookRotation activeLookRotation,
            PlayerLookRotationHandler playerLookRotationHandler)
        {
            _activeLookRotation = activeLookRotation;
            _playerLookRotationHandler = playerLookRotationHandler;
        }

        public void Enter()
        {
            _activeLookRotation.SetHandler(_playerLookRotationHandler);
        }

        public void Exit()
        {
        }
    }
}