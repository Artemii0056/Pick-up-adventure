namespace _ProjectFiles.StateMachine.States
{
    public class LoadState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;

        public LoadState(
            IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {

            //_gameStateMachine.Enter<GameState, GameRuntimeData>(runtimeData);
        }

        public void Exit()
        {
        }
    }
}