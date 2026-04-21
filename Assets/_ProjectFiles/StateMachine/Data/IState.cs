namespace _ProjectFiles.StateMachine.Data
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}