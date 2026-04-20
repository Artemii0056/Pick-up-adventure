using _ProjectFiles.StaticDatas.Scripts;

namespace _ProjectFiles.StateMachine.States
{
    public class BootstrapState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;

        public BootstrapState(IGameStateMachine gameStateMachine, IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _staticDataService = staticDataService;
        }

        public void Enter()
        {
            _staticDataService.LoadAll();
            _gameStateMachine.Enter<LoadState>();
        }

        public void Exit()
        {
            
        }
    }
}