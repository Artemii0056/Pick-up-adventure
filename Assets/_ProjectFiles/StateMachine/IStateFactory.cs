namespace _ProjectFiles.StateMachine
{
    public interface IStateFactory
    {
        T GetState <T>() where T : IExitableState;
    }
}