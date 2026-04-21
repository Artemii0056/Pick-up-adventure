using _ProjectFiles.StateMachine.Data;

namespace _ProjectFiles.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapState(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void Enter()
        {
            _gameStateMachine.Enter<LoadState>();
        }

        public void Exit()
        {
            
        }
    }
}