namespace _ProjectFiles.StateMachine.States
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}