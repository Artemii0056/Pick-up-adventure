namespace _ProjectFiles
{
    public interface IActiveLookRotation
    {
        void SetHandler(ILookRotationHandler handler);
        void Tick();
    }
}