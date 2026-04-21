namespace _ProjectFiles.StateMachine.Data
{
    public interface IPayloadState<TPayload> : IExitableState
    {
        void Enter(TPayload payload);
    }
}