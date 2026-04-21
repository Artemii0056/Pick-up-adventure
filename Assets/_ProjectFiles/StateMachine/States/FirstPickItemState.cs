using _ProjectFiles.Items.Scripts.Inspection;
using _ProjectFiles.Items.Scripts.Logic;
using _ProjectFiles.Player.Scripts.LookRotation;
using _ProjectFiles.Player.Scripts.Movements;
using _ProjectFiles.Player.Scripts.Resolvers;
using _ProjectFiles.StateMachine.Data;

namespace _ProjectFiles.StateMachine.States
{
    public class FirstPickUpState : IPayloadState<ItemView>
    {
        private readonly IActiveLookRotation _activeLookRotation;
        private readonly IFirstPickUpItemFlow _firstPickUpItemFlow;
        private readonly IPlayerMover _playerMover;
        private readonly InspectItemRotationHandler _inspectItemRotationHandler;

        public FirstPickUpState(
            IFirstPickUpItemFlow firstPickUpItemFlow, 
            IActiveLookRotation activeLookRotation, 
            InspectItemRotationHandler inspectItemRotationHandler, 
            IPlayerMover playerMover)
        {
            _firstPickUpItemFlow = firstPickUpItemFlow;
            _activeLookRotation = activeLookRotation;
            _inspectItemRotationHandler = inspectItemRotationHandler;
            _playerMover = playerMover;
        }

        public void Enter(ItemView payload)
        {
            _activeLookRotation.SetHandler(_inspectItemRotationHandler);
            _playerMover.Deactivate();
            
            _firstPickUpItemFlow.Show(payload);
        }
        
        public void Exit()
        {
            if (_firstPickUpItemFlow.IsActive)
                _firstPickUpItemFlow.Hide();
            
            _playerMover.Activate();
        }
    }
}