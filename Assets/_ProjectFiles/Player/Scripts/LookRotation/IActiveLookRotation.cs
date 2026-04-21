namespace _ProjectFiles.Player.Scripts.LookRotation
{
    public interface IActiveLookRotation
    {
        void SetHandler(ILookRotationHandler handler);
        void Tick();
    }
}