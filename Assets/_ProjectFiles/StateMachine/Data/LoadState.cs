using _ProjectFiles.Bootstrap;
using _ProjectFiles.StateMachine.States;
using _ProjectFiles.StaticDatas.Scripts;
using _ProjectFiles.World.Scripts;

namespace _ProjectFiles.StateMachine.Data
{
    public class LoadState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IStaticDataService _staticDataService;
        private readonly IWorldLoader _worldLoader;
        private readonly Bootstrapper _bootstrapper;

        public LoadState(
            IGameStateMachine gameStateMachine,
            Bootstrapper bootstrapper,
            IStaticDataService staticDataService, IWorldLoader worldLoader)
        {
            _gameStateMachine = gameStateMachine;
            _bootstrapper = bootstrapper;
            _staticDataService = staticDataService;
            _worldLoader = worldLoader;
        }

        public void Enter()
        {
            _staticDataService.LoadAll();
            _worldLoader.Load(_bootstrapper.SceneData);
            _gameStateMachine.Enter<GamePlayState>();
        }

        public void Exit()
        {
        }
    }
}