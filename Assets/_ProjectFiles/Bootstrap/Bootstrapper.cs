using _ProjectFiles.Player.Scripts.Movements;
using _ProjectFiles.StateMachine;
using _ProjectFiles.StateMachine.States;
using UnityEngine;
using VContainer;

namespace _ProjectFiles.Bootstrap
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private SceneData _data;
        
        [SerializeField] private Transform _playerRoot;

        private IGameStateMachine _gameStateMachine;
        private IValveRotationService _valveRotationService;
        private IActiveLookRotation _activeLookRotation;
        private IPlayerMover _playerMover;

        [Inject]
        public void Init(
            IGameStateMachine gameStateMachine,
            IValveRotationService valveRotationService,
            IActiveLookRotation activeLookRotation,
            IPlayerMover playerMover)
        {
            _gameStateMachine = gameStateMachine;
            _valveRotationService = valveRotationService;
            _activeLookRotation = activeLookRotation;
            _playerMover = playerMover;
        }

        public SceneData SceneData => _data;

        private void Start()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }

        private void Update()
        {
            _gameStateMachine.Tick();
            _valveRotationService.Tick();
            _activeLookRotation.Tick();
            _playerMover.Tick();
        }
    }
}